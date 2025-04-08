using Microsoft.AspNetCore.Mvc;
using server.Models;
using server.Services.Interfaces;

namespace server.Controllers
{
    [ApiController]
    [Route("api/hotel")]
    public class HotelController : ControllerBase
    {
        private readonly IHotelService _hotelService;

        public HotelController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }

        [HttpGet]
        public async Task<IActionResult> GetHotels()
        {
            var hotels = await _hotelService.GetHotelsAsync();
            return Ok(hotels);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetHotelById(Guid id)
        {
            var hotel = await _hotelService.GetHotelByIdAsync(id);

            if (hotel == null) NotFound();

            return Ok(hotel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateHotel([FromBody] Hotel hotel)
        {
            if (hotel == null) return BadRequest();
            await _hotelService.AddHotelAsync(hotel);
            return CreatedAtAction(nameof(GetHotels), new { id = hotel.HotelId }, hotel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHotel(Guid id, [FromBody] Hotel hotel)
        {
            if (hotel == null || hotel.HotelId != id) return BadRequest();

            var existingHotel = await _hotelService.GetHotelByIdAsync(id);
            if (existingHotel == null) return BadRequest();

            await _hotelService.UpdateHotelAsync(hotel);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotelAsync(Guid id)
        {
            var hotel = await _hotelService.GetHotelByIdAsync(id);

            if (hotel == null) return NotFound();

            await _hotelService.DeleteHotelAsync(id);
            return NoContent();
        }
    }
}
