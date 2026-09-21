using NASA.Missions.Web.Data;
using NASA.Missions.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace NASA.Missions.Web.Services
{
    public class MissionService : IMissionService
    {
        private readonly MissionDbContext _context;

        public MissionService(MissionDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Mission>> GetAllMissionsAsync()
        {
            return await _context.Missions.OrderBy(m => m.Name).ToListAsync();
        }

        public async Task<Mission?> GetMissionByIdAsync(int id)
        {
            return await _context.Missions.FindAsync(id);
        }

        public async Task<IEnumerable<Mission>> GetActiveMissionsAsync()
        {
            return await _context.Missions
                .Where(m => m.IsActive)
                .OrderBy(m => m.Name)
                .ToListAsync();
        }

        public async Task<IEnumerable<Mission>> SearchMissionsAsync(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return await GetAllMissionsAsync();
            }

            return await _context.Missions
                .Where(m => m.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                            m.Description.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                            m.Type.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                .OrderBy(m => m.Name)
                .ToListAsync();
        }

        public async Task<Mission> CreateMissionAsync(Mission mission)
        {
            _context.Missions.Add(mission);
            await _context.SaveChangesAsync();
            return mission;
        }

        public async Task<Mission?> UpdateMissionAsync(int id, Mission mission)
        {
            var existingMission = await _context.Missions.FindAsync(id);
            if (existingMission == null)
            {
                return null;
            }

            existingMission.Name = mission.Name;
            existingMission.Description = mission.Description;
            existingMission.LaunchDate = mission.LaunchDate;
            existingMission.EndDate = mission.EndDate;
            existingMission.Status = mission.Status;
            existingMission.ImageUrl = mission.ImageUrl;
            existingMission.Type = mission.Type;

            await _context.SaveChangesAsync();
            return existingMission;
        }

        public async Task<bool> DeleteMissionAsync(int id)
        {
            var mission = await _context.Missions.FindAsync(id);
            if (mission == null)
            {
                return false;
            }

            _context.Missions.Remove(mission);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}