using server.Models;

namespace server.Repositories.Interfaces
{
    public interface IBookingRepository
    {
        Task<IEnumerable<Booking>> GetBookingAsync();
        Task<Booking?> GetBookingByIdAsync(Guid id);
        Task AddBookingAsync(Booking booking);
        Task UpdateBookingAsync(Booking booking);
        Task DeleteBookingAsync(Guid id);
        Task SaveAsync();
    }
}
