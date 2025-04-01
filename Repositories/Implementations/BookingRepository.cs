using Microsoft.EntityFrameworkCore;
using server.Data;
using server.Models;
using server.Repositories.Interfaces;

namespace server.Repositories.Implementations
{
    public class BookingRepository : IBookingRepository 
    {
        private readonly HotelBookingDbContext _context;

        public BookingRepository(HotelBookingDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Booking>> GetBookingAsync() => 
            await _context.Bookings.ToListAsync();

        public async Task<Booking?> GetBookingByIdAsync(int id) => 
            await _context.Bookings.FindAsync(id);

        public async Task AddBookingAsync(Booking booking) =>
            await _context.Bookings.AddAsync(booking);

        public async Task SaveAsync() => 
            await _context.SaveChangesAsync();
    }
}
