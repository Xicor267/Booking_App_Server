using server.Models;
using System.Threading.Tasks;

namespace server.Services.Interfaces
{
    public interface IBookingService
    {
        Task<IEnumerable<Booking>> GetBookingsAsync();
        Task<Booking?> GetBookingByIdAsync(Guid id);
        Task AddBookingAsync(Booking booking);
        Task UpdateBookingAsync(Booking booking);
        Task DeleteBookingAsync(Guid id);
    }
}
