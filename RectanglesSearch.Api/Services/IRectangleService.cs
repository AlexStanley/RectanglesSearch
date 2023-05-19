using RectanglesSearch.Api.Models;

namespace RectanglesSearch.Api.Services
{
    public interface IRectangleService
    {
        Task<Dictionary<string, List<Rectangle>>> RectanglesSearch(List<RectangleSearchRequest> coordinates);
    }
}
