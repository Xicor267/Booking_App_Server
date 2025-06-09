using server.Repositories.Interfaces;
using server.Services.Interfaces;

namespace server.Middleware
{
    public class VisitorTrackingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public VisitorTrackingMiddleware(RequestDelegate next, IServiceScopeFactory serviceScopeFactory)
        {
            _next = next;
            _serviceScopeFactory = serviceScopeFactory;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Create a new scope to resolve scoped services
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var activeUserRepository = scope.ServiceProvider.GetRequiredService<IActiveUserRepository>();

                // Increment the visitor count
                await activeUserRepository.IncrementVisitorCountAsync();
            }

            // Call the next middleware in the pipeline
            await _next(context);
        }
    }
}
