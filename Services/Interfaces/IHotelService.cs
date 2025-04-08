using server.Models;

namespace server.Services.Interfaces
{
    public interface IHotelService
    {
        Task<IEnumerable<Hotel>> GetHotelsAsync();
        Task<Hotel?> GetHotelByIdAsync(Guid id);
        Task AddHotelAsync(Hotel hotel);
        Task UpdateHotelAsync(Hotel hotel);
        Task DeleteHotelAsync(Guid id);
    }
}
