using server.Models;

namespace server.Repositories.Interfaces
{
    public interface IHotelRepository
    {
        Task<IEnumerable<Hotel>> GetHotelsAsync();
        Task<Hotel?> GetHotelByIdAsync(int id);
        Task AddHotelAsync(Hotel hotel);
        Task SaveAsync();
    }
}
