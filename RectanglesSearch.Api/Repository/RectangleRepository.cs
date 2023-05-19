using Microsoft.EntityFrameworkCore;
using RectanglesSearch.Api.Models;

namespace RectanglesSearch.Api.Repository
{
    public class RectangleRepository : IRectangleRepository
    {
        private readonly RectangleDbContext _context;
        public RectangleRepository(RectangleDbContext context)
        {
            _context = context;
        }

        public async Task<Dictionary<string, List<Rectangle>>> RectanglesSearchByCoordinates(List<RectangleSearchRequest> coordinates)
        {
            var matchedRectanglesWithCoordinates = new Dictionary<string, List<Rectangle>>();

            foreach (var coordinate in coordinates)
            {
                var rectanglesForCoordinate = await _context.Rectangles
                    .Where(r => coordinate.XCoordinate >= r.XCoordinate
                    && coordinate.XCoordinate <= (r.XCoordinate + r.Width)
                    && coordinate.YCoordinate >= r.YCoordinate
                    && coordinate.YCoordinate <= (r.YCoordinate + r.Height)
                ).ToListAsync();

                matchedRectanglesWithCoordinates
                    .Add($"X: {coordinate.XCoordinate}, Y: {coordinate.YCoordinate}", rectanglesForCoordinate);
            }

            return matchedRectanglesWithCoordinates;
        }
    }
}
