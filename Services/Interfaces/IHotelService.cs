using server.Models;

namespace server.Services.Interfaces
{
    public interface IHotelService
    {
        Task<IEnumerable<Hotel>> GetHotelsAsync();
        Task<Hotel?> GetHotelByIdAsync(int id);
        Task AddHotelAsync(Hotel hotel);
    }
}
