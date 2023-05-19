using Microsoft.EntityFrameworkCore;

namespace RectanglesSearch.Api.Models
{
    public class RectangleDbContext : DbContext
    {
        public RectangleDbContext(DbContextOptions<RectangleDbContext> options) : base(options) { }

        public DbSet<Rectangle> Rectangles { get; set; }
    }
}
