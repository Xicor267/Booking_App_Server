using server.Models;

namespace server.Services.Interfaces
{
    public interface IActiveUserService
    {
        Task<int> GetTotalVisitorsAsync();
        Task<VisitorCount> GetVisitorCountDataAsync();
        Task TrackVisitorAsync(HttpContext httpContext);
    }
}
