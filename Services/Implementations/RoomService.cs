using server.Models;
using server.Repositories.Interfaces;
using server.Services.Interfaces;

namespace server.Services.Implementations
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;

        public RoomService(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public async Task<IEnumerable<Room>> GetRoomAsync()
        {
            return await _roomRepository.GetRoomAsync();
        }

        public async Task<Room?> GetRoomByIdAsync(Guid id)
        {
            return await _roomRepository.GetRoomByIdAsync(id);
        }

        public async Task AddRoomAsync(Room room)
        {
            if (room.RoomId == Guid.Empty)
            {
                room.RoomId = Guid.NewGuid();
            }

            await _roomRepository.AddRoomAsync(room);
            await _roomRepository.SaveAsync();
        }

        public async Task UpdateRoomAsync(Room room)
        {
            await _roomRepository.UpdateRoomAsync(room);
            await _roomRepository.SaveAsync();
        }

        public async Task DeleteRoomAsync(Guid id)
        {
            await _roomRepository.DeleteRoomAsync(id);
            await _roomRepository.SaveAsync();
        }
    }
}
