using RectanglesSearch.Api.Models;
using RectanglesSearch.Api.Repository;

namespace RectanglesSearch.Api.Services
{
    public class RectangleService : IRectangleService
    {
        private readonly IRectangleRepository _repository;

        public RectangleService(IRectangleRepository repository)
        {
            _repository = repository;
        }

        public async Task<Dictionary<string, List<Rectangle>>> RectanglesSearch(List<RectangleSearchRequest> coordinates)
        {
            var matchedRectanglesWithCoordinates = new Dictionary<string, List<Rectangle>>();

            try
            {
                matchedRectanglesWithCoordinates = await _repository.RectanglesSearchByCoordinates(coordinates);
            }
            catch (Exception)
            {
                throw;
            }

            return matchedRectanglesWithCoordinates;
        }
    }
}
