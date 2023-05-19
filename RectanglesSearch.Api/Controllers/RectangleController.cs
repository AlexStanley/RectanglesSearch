using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RectanglesSearch.Api.Models;
using RectanglesSearch.Api.Services;

namespace RectanglesSearch.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RectangleController : ControllerBase
    {
        private readonly IRectangleService _service;

        public RectangleController(IRectangleService service)
        {
            _service = service;
        }

        [HttpPost("searchcoordinates")]
        [Authorize]
        public async Task<IActionResult> SearchRectangles([FromBody] List<RectangleSearchRequest> coordinates)
        {
            var matchedRectanglesWithCoordinates = await _service.RectanglesSearch(coordinates);

            return Ok(matchedRectanglesWithCoordinates);
        }
    }
}
