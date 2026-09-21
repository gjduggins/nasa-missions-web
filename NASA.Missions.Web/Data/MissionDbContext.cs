using Microsoft.EntityFrameworkCore;
using NASA.Missions.Web.Models;

namespace NASA.Missions.Web.Data
{
    public class MissionDbContext : DbContext
    {
        public MissionDbContext(DbContextOptions<MissionDbContext> options) : base(options)
        {
        }

        public DbSet<Mission> Missions => Set<Mission>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Mission>().HasData(
                new Mission
                {
                    Id = 1,
                    Name = "Apollo 11",
                    Description = "First crewed mission to land on the Moon",
                    LaunchDate = new DateTime(1969, 7, 16),
                    EndDate = new DateTime(1969, 7, 24),
                    Status = "Completed",
                    ImageUrl = "/images/apollo11.jpg",
                    Type = "Manned Lunar Landing"
                },
                new Mission
                {
                    Id = 2,
                    Name = "Mars Rover Perseverance",
                    Description = "Robotic mission to explore Mars and search for signs of ancient life",
                    LaunchDate = new DateTime(2020, 7, 30),
                    EndDate = null,
                    Status = "Active",
                    ImageUrl = "/images/perseverance.jpg",
                    Type = "Mars Exploration"
                },
                new Mission
                {
                    Id = 3,
                    Name = "Hubble Space Telescope",
                    Description = "Space telescope launched into low Earth orbit",
                    LaunchDate = new DateTime(1990, 4, 24),
                    EndDate = null,
                    Status = "Active",
                    ImageUrl = "/images/hubble.jpg",
                    Type = "Space Observatory"
                },
                new Mission
                {
                    Id = 4,
                    Name = "Voyager 1",
                    Description = "Space probe launched to study outer Solar System and interstellar space",
                    LaunchDate = new DateTime(1977, 9, 5),
                    EndDate = null,
                    Status = "Active",
                    ImageUrl = "/images/voyager1.jpg",
                    Type = "Deep Space Exploration"
                }
            );
        }
    }
}