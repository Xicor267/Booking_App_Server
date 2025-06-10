using Microsoft.EntityFrameworkCore;
using server.Data;
using server.Models;
using server.Repositories.Interfaces;

namespace server.Repositories.Implementations
{
    public class PendingUserRepository : IPendingUserRepository
    {
        private readonly HotelBookingDbContext _context;

        public PendingUserRepository(HotelBookingDbContext context)
        {
            _context = context;
        }

        public async Task AddPendingUserAsync(PendingUser pendingUser)
        {
            await _context.PendingUsers.AddAsync(pendingUser);
        }

        public async Task<PendingUser> GetPendingUserByEmailAsync(string email)
        {
            return await _context.PendingUsers.FirstOrDefaultAsync(p => p.Email == email);
        }

        public async Task DeletePendingUserAsync(string email)
        {
            var pendingUser = await _context.PendingUsers.FirstOrDefaultAsync(p => p.Email == email);
            if (pendingUser != null)
            {
                _context.PendingUsers.Remove(pendingUser);
            }
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
