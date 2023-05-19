using RectanglesSearch.Api.Models;

namespace RectanglesSearch.Api.Data
{
    public class InitializationDbWithData
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();
            SeedData(serviceScope.ServiceProvider.GetService<RectangleDbContext>());
        }

        private static void SeedData(RectangleDbContext context)
        {
            if (!context.Rectangles.Any())
            {
                var random = new Random();

                for (int i = 0; i < 200; i++)
                {
                    var rectangle = new Rectangle
                    {
                        XCoordinate = random.Next(0, 200),
                        YCoordinate = random.Next(0, 200),
                        Width = random.Next(5, 100),
                        Height = random.Next(5, 100)
                    };

                    context.Rectangles.Add(rectangle);
                }

                context.SaveChanges();
            }
        }
    }
}
