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

        public async Task<Hotel?> GetHotelByIdAsync(Guid id) =>
            await _hotelRepository.GetHotelByIdAsync(id);

        public async Task AddHotelAsync(Hotel hotel)
        {
            if (hotel.HotelId == Guid.Empty)
            {
                hotel.HotelId = Guid.NewGuid();
            }

            await _hotelRepository.AddHotelAsync(hotel);
            await _hotelRepository.SaveAsync();
        }

        public async Task UpdateHotelAysnc(Hotel hotel)
        {
            await _hotelRepository.UpdateHotelAsync(hotel);
            await _hotelRepository.SaveAsync();
        }

        public async Task DeleteHotelAsync(Guid id)
        {
            await _hotelRepository.DeleteHotelAsync(id);
            await _hotelRepository.SaveAsync();
        }

        public async Task UpdateHotelAsync(Hotel hotel)
        {
            await _hotelRepository.UpdateHotelAsync(hotel);
            await _hotelRepository.SaveAsync();
        }
    }
}
