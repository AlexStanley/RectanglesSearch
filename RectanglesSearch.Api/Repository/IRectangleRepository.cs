using RectanglesSearch.Api.Models;

namespace RectanglesSearch.Api.Repository
{
    public interface IRectangleRepository
    {
        Task<Dictionary<string, List<Rectangle>>> RectanglesSearchByCoordinates(List<RectangleSearchRequest> coordinates);
    }
}
