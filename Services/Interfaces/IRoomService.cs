using server.Models;

namespace server.Services.Interfaces
{
    public interface IRoomService
    {
        Task<IEnumerable<Room>> GetRoomAsync();
        Task<Room?> GetRoomByIdAsync(Guid id);
        Task AddRoomAsync(Room room);
        Task UpdateRoomAsync(Room room);
        Task DeleteRoomAsync(Guid id);
    }
}
