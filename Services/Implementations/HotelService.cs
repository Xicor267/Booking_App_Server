using Microsoft.Extensions.Hosting;
using server.Models;
using server.Repositories.Implementations;
using server.Repositories.Interfaces;
using server.Services.Interfaces;

namespace server.Services.Implementations
{
    public class HotelService : IHotelService
    {
        private readonly IHotelRepository _hotelRepository;

        public HotelService(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }

        public async Task<IEnumerable<Hotel>> GetHotelsAsync() =>
            await _hotelRepository.GetHotelsAsync();

        public async Task<Hotel?> GetHotelByIdAsync(int id) =>
            await _hotelRepository.GetHotelByIdAsync(id);

        public async Task AddHotelAsync(Hotel hotel)
        {
            await _hotelRepository.AddHotelAsync(hotel);
            await _hotelRepository.SaveAsync();
        }
    }
}
