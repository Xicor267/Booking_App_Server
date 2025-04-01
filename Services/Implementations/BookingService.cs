using server.Models;
using server.Repositories.Interfaces;
using server.Services.Interfaces;

namespace server.Services.Implementations
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepo;

        public BookingService(IBookingRepository bookingRepo) {
            _bookingRepo = bookingRepo;
        }

        public async Task<IEnumerable<Booking>> GetBookingsAsync() => 
            await _bookingRepo.GetBookingAsync();

        public async Task<Booking?> GetBookingByIdAsync(int id) =>
            await _bookingRepo.GetBookingByIdAsync(id);

        public async Task AddBookingAsync(Booking booking)
        {
            await _bookingRepo.AddBookingAsync(booking);
            await _bookingRepo.SaveAsync();
        }
    }
}
