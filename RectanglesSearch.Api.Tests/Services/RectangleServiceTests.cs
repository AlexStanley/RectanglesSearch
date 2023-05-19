using RectanglesSearch.Api.Models;
using RectanglesSearch.Api.Repository;
using RectanglesSearch.Api.Services;

namespace RectanglesSearch.Api.Tests.Services
{
    public class RectangleServiceTests
    {
        private readonly IFixture _fixture;
        private readonly Mock<IRectangleRepository> _repositoryMock;
        private readonly RectangleService _rectangleService;

        public RectangleServiceTests()
        {
            _fixture = new Fixture();
            _repositoryMock = _fixture.Freeze<Mock<IRectangleRepository>>();
            _rectangleService = new RectangleService(_repositoryMock.Object);
        }

        [Fact]
        public async Task RectanglesSearch_MultipleCoordinates_ReturnsMatchingRectangles()
        {
            // Arrange
            var coordinates = _fixture.Create<List<RectangleSearchRequest>>();
            var matchedRectanglesWithCoordinates = _fixture.Create<Dictionary<string, List<Rectangle>>>();
            _repositoryMock.Setup(x => x.RectanglesSearchByCoordinates(coordinates)).ReturnsAsync(matchedRectanglesWithCoordinates);

            // Act
            var result = await _rectangleService.RectanglesSearch(coordinates).ConfigureAwait(false);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<Dictionary<string, List<Rectangle>>>();
            _repositoryMock.Verify(x => x.RectanglesSearchByCoordinates(coordinates), Times.Once());
        }

    }
}