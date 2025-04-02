using Microsoft.EntityFrameworkCore;
using server.Data;
using server.Models;
using server.Repositories.Interfaces;

namespace server.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly HotelBookingDbContext _context;

        public UserRepository(HotelBookingDbContext context) {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetUserAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User?> GetUserByIdAsync(Guid id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task AddUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
        }

        public Task UpdateUserAsync(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            return Task.CompletedTask;
        }

        public Task DeleteUserAsync(Guid id)
        {
            var user = _context.Users.Find(id);
            if (user != null) {
                _context.Users.Remove(user);
            };

            return Task.CompletedTask;
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
