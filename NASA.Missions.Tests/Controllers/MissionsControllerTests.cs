using Microsoft.AspNetCore.Mvc;
using Moq;
using NASA.Missions.Web.Controllers;
using NASA.Missions.Web.Models;
using NASA.Missions.Web.Services;

namespace NASA.Missions.Tests.Controllers
{
    public class MissionsControllerTests
    {
        [Fact]
        public async Task Index_Returns_ViewResult_With_Missions()
        {
            // Arrange
            var mockService = new Mock<IMissionService>();
            mockService.Setup(service => service.SearchMissionsAsync(It.IsAny<string>()))
                .ReturnsAsync(new List<Mission> {
                    new Mission { Id = 1, Name = "Apollo 11", Description = "Moon landing mission", Status = "Completed" },
                    new Mission { Id = 2, Name = "Mars Rover", Description = "Mars exploration", Status = "Active" }
                });

            var controller = new MissionsController(mockService.Object);

            // Act
            var result = await controller.Index(null);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var missions = Assert.IsAssignableFrom<IEnumerable<Mission>>(viewResult.Model);
            Assert.Equal(2, missions.Count());
        }

        [Fact]
        public async Task Details_WithValidId_Returns_ViewResult_With_Mission()
        {
            // Arrange
            var mockService = new Mock<IMissionService>();
            mockService.Setup(service => service.GetMissionByIdAsync(1))
                .ReturnsAsync(new Mission { Id = 1, Name = "Apollo 11", Description = "Moon landing mission", Status = "Completed" });

            var controller = new MissionsController(mockService.Object);

            // Act
            var result = await controller.Details(1);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var mission = Assert.IsType<Mission>(viewResult.Model);
            Assert.Equal(1, mission.Id);
            Assert.Equal("Apollo 11", mission.Name);
        }

        [Fact]
        public async Task Details_WithInvalidId_Returns_NotFoundResult()
        {
            // Arrange
            var mockService = new Mock<IMissionService>();
            mockService.Setup(service => service.GetMissionByIdAsync(It.IsAny<int>()))
                .ReturnsAsync((Mission)null);

            var controller = new MissionsController(mockService.Object);

            // Act
            var result = await controller.Details(999);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }
    }
}