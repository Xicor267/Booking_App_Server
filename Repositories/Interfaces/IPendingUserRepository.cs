using server.Models;

namespace server.Repositories.Interfaces
{
    public interface IPendingUserRepository
    {
        Task AddPendingUserAsync(PendingUser pendingUser);
        Task<PendingUser> GetPendingUserByEmailAsync(string email);
        Task DeletePendingUserAsync(string email);
        Task SaveAsync();
    }
}
