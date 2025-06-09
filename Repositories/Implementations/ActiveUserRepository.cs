using Microsoft.EntityFrameworkCore;
using server.Data;
using server.Models;
using server.Repositories.Interfaces;

namespace server.Repositories.Implementations
{
    public class ActiveUserRepository : IActiveUserRepository
    {
        private readonly HotelBookingDbContext _context;

        public ActiveUserRepository(HotelBookingDbContext context)
        {
            _context = context;
        }

        public async Task<VisitorCount> GetVisitorCountAsync()
        {
            var counter = await _context.VisitorCounts.FirstOrDefaultAsync();
            if (counter == null)
            {
                counter = new VisitorCount() { Count = 0};
                _context.VisitorCounts.Add(counter);
                await _context.SaveChangesAsync();
            }

            return counter;
        }

        public async Task IncrementVisitorCountAsync()
        {
            var counter = await GetVisitorCountAsync();
            counter.Count++;
            counter.LastUpdated = DateTime.UtcNow;
            await _context.SaveChangesAsync();
        }
    }
}
