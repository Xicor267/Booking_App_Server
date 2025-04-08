using server.Models;

namespace server.Repositories.Interfaces
{
    public interface IRoomRepository
    {
        Task<IEnumerable<Room>> GetRoomAsync();
        Task<Room?> GetRoomByIdAsync(Guid id);
        Task AddRoomAsync(Room room);
        Task UpdateRoomAsync(Room room);
        Task DeleteRoomAsync(Guid id);
        Task SaveAsync();
    }
}
