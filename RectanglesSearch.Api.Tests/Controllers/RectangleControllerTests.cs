using Microsoft.AspNetCore.Mvc;
using RectanglesSearch.Api.Controllers;
using RectanglesSearch.Api.Models;
using RectanglesSearch.Api.Services;

namespace RectanglesSearch.Api.Tests.Controllers
{
    public class RectangleControllerTests
    {
        private readonly IFixture _fixture;
        private readonly Mock<IRectangleService> _serviceMock;
        private readonly RectangleController _rectangleController;

        public RectangleControllerTests()
        {
            _fixture = new Fixture();
            _serviceMock = _fixture.Freeze<Mock<IRectangleService>>();
            _rectangleController = new RectangleController(_serviceMock.Object);
        }

        [Fact]
        public async Task SearchRectangles_MultipleCoordinates_ShouldReturnOkResponse()
        {
            // Arrange
            var coordinates = _fixture.Create<List<RectangleSearchRequest>>();
            var matchedRectanglesWithCoordinates = _fixture.Create<Dictionary<string, List<Rectangle>>>();
            _serviceMock.Setup(x => x.RectanglesSearch(coordinates)).ReturnsAsync(matchedRectanglesWithCoordinates);

            // Act
            var result = await _rectangleController.SearchRectangles(coordinates).ConfigureAwait(false);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<IActionResult>();
            result.Should().BeAssignableTo<OkObjectResult>();
            result.As<OkObjectResult>().Value
                .Should()
                .NotBeNull()
                .And.BeOfType(matchedRectanglesWithCoordinates.GetType());
            _serviceMock.Verify(x => x.RectanglesSearch(coordinates), Times.Once());
        }
    }
}