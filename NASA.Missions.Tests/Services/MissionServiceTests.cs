using Microsoft.EntityFrameworkCore;
using Moq;
using NASA.Missions.Web.Data;
using NASA.Missions.Web.Models;
using NASA.Missions.Web.Services;

namespace NASA.Missions.Tests.Services
{
    public class MissionServiceTests
    {
        [Fact]
        public async Task GetAllMissionsAsync_ReturnsAllMissions()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<MissionDbContext>()
                .UseInMemoryDatabase(databaseName: "GetAllMissionsTest")
                .Options;

            using var context = new MissionDbContext(options);
            context.Missions.AddRange(
                new Mission { Id = 1, Name = "Apollo 11", Description = "Moon landing mission", Status = "Completed" },
                new Mission { Id = 2, Name = "Mars Rover", Description = "Mars exploration", Status = "Active" }
            );
            await context.SaveChangesAsync();

            var service = new MissionService(context);

            // Act
            var result = await service.GetAllMissionsAsync();

            // Assert
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task GetMissionByIdAsync_ExistingId_ReturnsMission()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<MissionDbContext>()
                .UseInMemoryDatabase(databaseName: "GetMissionByIdTest")
                .Options;

            using var context = new MissionDbContext(options);
            var mission = new Mission { Id = 1, Name = "Apollo 11", Description = "Moon landing mission", Status = "Completed" };
            context.Missions.Add(mission);
            await context.SaveChangesAsync();

            var service = new MissionService(context);

            // Act
            var result = await service.GetMissionByIdAsync(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Apollo 11", result.Name);
        }

        [Fact]
        public async Task GetMissionByIdAsync_NonExistingId_ReturnsNull()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<MissionDbContext>()
                .UseInMemoryDatabase(databaseName: "GetMissionByIdNonExistingTest")
                .Options;

            using var context = new MissionDbContext(options);
            var service = new MissionService(context);

            // Act
            var result = await service.GetMissionByIdAsync(999);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task CreateMissionAsync_AddsMissionToDatabase()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<MissionDbContext>()
                .UseInMemoryDatabase(databaseName: "CreateMissionTest")
                .Options;

            using var context = new MissionDbContext(options);
            var service = new MissionService(context);
            var mission = new Mission { Name = "New Mission", Description = "Test mission", Status = "Planned" };

            // Act
            var result = await service.CreateMissionAsync(mission);

            // Assert
            Assert.Equal(1, context.Missions.Count());
            Assert.Equal("New Mission", result.Name);
        }
    }
}