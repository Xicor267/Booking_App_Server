using Microsoft.AspNetCore.Mvc;
using server.Models;
using server.Services.Interfaces;

namespace server.Controllers
{
    [ApiController]
    [Route("apt/[controller]")]
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

        [HttpPost]
        public async Task<IActionResult> BookRoom([FromBody] Booking booking)
        {
            if (booking == null) return BadRequest();
            await _bookingService.AddBookingAsync(booking);
            return CreatedAtAction(nameof(GetBookings), new {id  = booking.Id}, booking);
        }
    }
}
