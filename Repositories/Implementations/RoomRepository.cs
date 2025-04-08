using Microsoft.EntityFrameworkCore;
using server.Data;
using server.Models;
using server.Repositories.Interfaces;

namespace server.Repositories.Implementations
{
    public class RoomRepository : IRoomRepository
    {
        private readonly HotelBookingDbContext _context;

        public RoomRepository(HotelBookingDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Room>> GetRoomAsync()
        {
            return await _context.Rooms.ToListAsync();
        }

        public async Task<Room?> GetRoomByIdAsync(Guid id)
        {
            return await _context.Rooms.FindAsync(id);
        }

        public async Task AddRoomAsync(Room room)
        {
            await _context.Rooms.AddAsync(room);
        }

        public Task UpdateRoomAsync(Room room)
        {
            _context.Rooms.Entry(room).State = EntityState.Modified;
            return Task.CompletedTask;
        }

        public Task DeleteRoomAsync(Guid id)
        {
            var room = _context.Rooms.Find(id);

            if (room != null)
            {
                _context.Rooms.Remove(room);
            }

            return Task.CompletedTask;
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}