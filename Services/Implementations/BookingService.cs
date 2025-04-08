using server.Models;
using server.Repositories.Interfaces;
using server.Services.Interfaces;

namespace server.Services.Implementations
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepo;

        public BookingService(IBookingRepository bookingRepo)
        {
            _bookingRepo = bookingRepo;
        }

        public async Task<IEnumerable<Booking>> GetBookingsAsync() =>
            await _bookingRepo.GetBookingAsync();

        public async Task<Booking?> GetBookingByIdAsync(Guid id) =>
            await _bookingRepo.GetBookingByIdAsync(id);

        public async Task AddBookingAsync(Booking booking)
        {
            if (booking.BookingId == Guid.Empty)
            {
                booking.BookingId = Guid.NewGuid();
            }

            await _bookingRepo.AddBookingAsync(booking);
            await _bookingRepo.SaveAsync();
        }

        public async Task UpdateBookingAsync(Booking booking)
        {
            await _bookingRepo.UpdateBookingAsync(booking);
            await _bookingRepo.SaveAsync();
        }

        public async Task DeleteBookingAsync(Guid id)
        {
            await _bookingRepo.DeleteBookingAsync(id);
            await _bookingRepo.SaveAsync();
        }
    }
}
