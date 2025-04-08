using server.Models;

namespace server.Repositories.Interfaces
{
    public interface IHotelRepository
    {
        Task<IEnumerable<Hotel>> GetHotelsAsync();
        Task<Hotel?> GetHotelByIdAsync(Guid id);
        Task AddHotelAsync(Hotel hotel);
        Task UpdateHotelAsync(Hotel hotel);
        Task DeleteHotelAsync(Guid id);
        Task SaveAsync();
    }
}
