using server.Models;

namespace server.Repositories.Interfaces
{
    public interface IActiveUserRepository
    {
        Task<VisitorCount> GetVisitorCountAsync();
        Task IncrementVisitorCountAsync();
    }
}
