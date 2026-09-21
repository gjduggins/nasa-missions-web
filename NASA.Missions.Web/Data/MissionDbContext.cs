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
                    Description = "Apollo 11 was the first crewed mission to successfully land humans on the Moon. Launched on July 16, 1969, the mission achieved one of humanity's greatest technological feats when Neil Armstrong and Buzz Aldrin became the first humans to walk on the lunar surface on July 20, 1969. The mission fulfilled President Kennedy's 1961 promise to land humans on the Moon before the end of the decade.",
                    LaunchDate = new DateTime(1969, 7, 16),
                    EndDate = new DateTime(1969, 7, 24),
                    Status = "Completed",
                    ImageUrl = "/images/apollo11.jpg",
                    Type = "Manned Lunar Landing"
                },
                new Mission
                {
                    Id = 2,
                    Name = "Voyager 1",
                    Description = "Launched in 1977, Voyager 1 is the farthest human-made object from Earth and continues to transmit data from interstellar space. The spacecraft conducted flybys of Jupiter and Saturn, providing detailed images and data of these gas giants and their moons. Notably, it discovered active volcanoes on Jupiter's moon Io and intricate details of Saturn's rings. In 2012, it became the first spacecraft to enter interstellar space, crossing the heliopause.",
                    LaunchDate = new DateTime(1977, 9, 5),
                    EndDate = null,
                    Status = "Active",
                    ImageUrl = "/images/voyager1.jpg",
                    Type = "Deep Space Exploration"
                },
                new Mission
                {
                    Id = 3,
                    Name = "Hubble Space Telescope",
                    Description = "Launched in 1990, the Hubble Space Telescope has revolutionized our understanding of the universe by providing unprecedented views of distant galaxies, nebulae, and other celestial phenomena. Orbiting Earth at an altitude of approximately 550 kilometers, Hubble has made over 1.5 million observations and contributed to more than 18,000 scientific papers. Its discoveries include determining the rate of expansion of the universe and providing evidence for dark energy.",
                    LaunchDate = new DateTime(1990, 4, 24),
                    EndDate = null,
                    Status = "Active",
                    ImageUrl = "/images/hubble.jpg",
                    Type = "Space Observatory"
                },
                new Mission
                {
                    Id = 4,
                    Name = "Mars Pathfinder",
                    Description = "Landed on Mars in 1997 with the Sojourner rover, demonstrating a low-cost method for delivering scientific instruments to Mars. The mission was the second of the Discovery program and the first to use a rover on Mars. It successfully tested innovative landing systems including airbags for cushioning impact and provided extensive geological data about the Martian surface. The mission operated for 83 sols (85 Earth days) and paved the way for future Mars rovers.",
                    LaunchDate = new DateTime(1996, 12, 4),
                    EndDate = new DateTime(1997, 10, 7),
                    Status = "Completed",
                    ImageUrl = "/images/pathfinder.jpg",
                    Type = "Mars Exploration"
                },
                new Mission
                {
                    Id = 5,
                    Name = "Cassini-Huygens",
                    Description = "Launched in 1997 to study Saturn and its moons, the Cassini-Huygens mission was a collaboration between NASA, ESA, and ASI. The mission spent 13 years studying Saturn's system, making groundbreaking discoveries including liquid methane lakes on Titan and water vapor geysers on Enceladus. The mission ended in 2017 with a controlled descent into Saturn's atmosphere, protecting potentially habitable moons from contamination. Cassini revolutionized our understanding of Saturn's complex ring system and magnetosphere.",
                    LaunchDate = new DateTime(1997, 10, 15),
                    EndDate = new DateTime(2017, 9, 15),
                    Status = "Completed",
                    ImageUrl = "/images/cassini.jpg",
                    Type = "Planetary Exploration"
                },
                new Mission
                {
                    Id = 6,
                    Name = "Mars Rover Perseverance",
                    Description = "Robotic mission to explore Mars and search for signs of ancient life. Perseverance landed in Jezero Crater in February 2021, a location chosen for its potential to preserve signs of past microbial life. The rover is equipped with advanced scientific instruments to analyze Martian rocks and soil, and it carries the Ingenuity helicopter, the first aircraft to achieve powered flight on another planet. Perseverance is also collecting rock samples for future return to Earth by the Mars Sample Return mission.",
                    LaunchDate = new DateTime(2020, 7, 30),
                    EndDate = null,
                    Status = "Active",
                    ImageUrl = "/images/perseverance.jpg",
                    Type = "Mars Exploration"
                }
            );
        }
    }
}