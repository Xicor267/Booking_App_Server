using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using server.Models;
using server.Services.Interfaces;

namespace server.Controllers
{
    [ApiController]
    [Route("api/room")]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;

        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpGet]
        public async Task<IActionResult> GetRoom()
        {
            var room = await _roomService.GetRoomAsync();

            return Ok(room);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoomById(Guid id)
        {
            var room = await _roomService.GetRoomByIdAsync(id);

            if (room == null) return NotFound();

            return Ok(room);
        }

        [HttpPost]
        public async Task<IActionResult> AddRoom([FromBody] Room room)
        {
            if (room == null) return BadRequest();
            await _roomService.AddRoomAsync(room);

            return CreatedAtAction(nameof(GetRoom), new { id = room.RoomId }, room);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRoombyId(Guid id, [FromBody] Room room)
        {
            if (room == null || id != room.RoomId) return BadRequest();

            var existingRoom = await _roomService.GetRoomByIdAsync(id);
            if (existingRoom == null) return BadRequest();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoom(Guid id)
        {
            var room = await _roomService.GetRoomByIdAsync(id);

            if (room == null) return NotFound();

            await _roomService.DeleteRoomAsync(id);
            return NoContent();
        }
    }
}
