using Microsoft.AspNetCore.Mvc;
using server.Services.Interfaces;

namespace server.Controllers
{
    [ApiController]
    [Route("api")]
    public class ActiveUserController : ControllerBase
    {
        private readonly IActiveUserService _activeUserService;

        public ActiveUserController(IActiveUserService activeUserService)
        {
            _activeUserService = activeUserService;
        }

        [HttpGet("visitor-count")]
        public async Task<IActionResult> GetVisitorCount()
        {
            var count = await _activeUserService.GetTotalVisitorsAsync();
            return Ok(new {Count  = count});
        }

        [HttpGet("visitor-data")]
        public async Task<IActionResult> GetVisitorData()
        {
            var data = await _activeUserService.GetVisitorCountDataAsync();
            return Ok(data);
        }
    }
}
