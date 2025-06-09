using server.Data;
using server.Models;
using server.Repositories.Interfaces;
using server.Services.Interfaces;

namespace server.Services.Implementations
{
    public class ActiveUserService : IActiveUserService
    {
        private readonly IActiveUserRepository _activeUserRepository;

        public ActiveUserService(IActiveUserRepository activeUserRepository)
        {
            _activeUserRepository = activeUserRepository;
        }

        public async Task<int> GetTotalVisitorsAsync()
        {
            var counter = await _activeUserRepository.GetVisitorCountAsync();
            return counter.Count;
        }

        public async Task<VisitorCount> GetVisitorCountDataAsync()
        {
            return await _activeUserRepository.GetVisitorCountAsync();
        }

        public async Task TrackVisitorAsync(HttpContext httpContext)
        {
            if (!httpContext.Request.Cookies.ContainsKey("visitor_tracked"))
            {
                await _activeUserRepository.IncrementVisitorCountAsync();

                httpContext.Response.Cookies.Append("visitor_tracked", "1", new CookieOptions
                {
                    Expires = DateTimeOffset.Now.AddDays(1),
                    HttpOnly = true,
                    IsEssential = true,
                    SameSite = SameSiteMode.Lax
                });
            }
        }
    }
}
