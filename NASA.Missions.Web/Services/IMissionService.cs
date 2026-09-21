using NASA.Missions.Web.Models;

namespace NASA.Missions.Web.Services
{
    public interface IMissionService
    {
        Task<IEnumerable<Mission>> GetAllMissionsAsync();
        Task<Mission?> GetMissionByIdAsync(int id);
        Task<IEnumerable<Mission>> GetActiveMissionsAsync();
        Task<IEnumerable<Mission>> SearchMissionsAsync(string searchTerm);
        Task<Mission> CreateMissionAsync(Mission mission);
        Task<Mission?> UpdateMissionAsync(int id, Mission mission);
        Task<bool> DeleteMissionAsync(int id);
    }
}