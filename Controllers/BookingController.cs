using Microsoft.AspNetCore.Mvc;
using server.Models;
using server.Services.Interfaces;

namespace server.Controllers
{
    [ApiController]
    [Route("api/booking")]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }


        [HttpGet]
        public async Task<IActionResult> GetBookings()
        {
            var bookings = await _bookingService.GetBookingsAsync();
            return Ok(bookings);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookingById(Guid id)
        {
            var booking = await _bookingService.GetBookingByIdAsync(id);

            if (booking == null)
            {
                return NotFound();
            }

            return Ok(booking);
        }

        [HttpPost]
        public async Task<IActionResult> BookRoom([FromBody] Booking booking)
        {
            if (booking == null) return BadRequest();
            await _bookingService.AddBookingAsync(booking);
            return CreatedAtAction(nameof(GetBookings), new { id = booking.BookingId }, booking);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBookingRoom(Guid id, [FromBody] Booking booking)
        {
            if (booking == null || booking.BookingId != id)
            {
                return BadRequest();
            }

            var existingBookingId = await _bookingService.GetBookingByIdAsync(id);
            if (existingBookingId == null) return BadRequest();

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBookingRoom(Guid id)
        {
            var booking = await _bookingService.GetBookingByIdAsync(id);
            if (booking == null)
            {
                return NotFound();
            }

            await _bookingService.DeleteBookingAsync(id);

            return NoContent();
        }
    }
}
