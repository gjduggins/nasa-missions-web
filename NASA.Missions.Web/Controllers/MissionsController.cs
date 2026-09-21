using Microsoft.AspNetCore.Mvc;
using NASA.Missions.Web.Models;
using NASA.Missions.Web.Services;

namespace NASA.Missions.Web.Controllers
{
    public class MissionsController : Controller
    {
        private readonly IMissionService _missionService;

        public MissionsController(IMissionService missionService)
        {
            _missionService = missionService;
        }

        // GET: Missions
        public async Task<IActionResult> Index(string searchString)
        {
            ViewData["CurrentFilter"] = searchString;
            
            var missions = await _missionService.SearchMissionsAsync(searchString ?? string.Empty);
            return View(missions);
        }

        // GET: Missions/Historical
        public async Task<IActionResult> Historical()
        {
            var missions = await _missionService.GetAllMissionsAsync();
            return View(missions);
        }

        // GET: Missions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mission = await _missionService.GetMissionByIdAsync(id.Value);
            if (mission == null)
            {
                return NotFound();
            }

            return View(mission);
        }

        // GET: Missions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Missions/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MissionViewModel missionViewModel)
        {
            if (ModelState.IsValid)
            {
                var mission = new Mission
                {
                    Name = missionViewModel.Name,
                    Description = missionViewModel.Description,
                    LaunchDate = missionViewModel.LaunchDate,
                    EndDate = missionViewModel.EndDate,
                    Status = missionViewModel.Status,
                    ImageUrl = missionViewModel.ImageUrl,
                    Agency = missionViewModel.Agency,
                    Type = missionViewModel.Type
                };

                await _missionService.CreateMissionAsync(mission);
                return RedirectToAction(nameof(Index));
            }
            return View(missionViewModel);
        }

        // GET: Missions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mission = await _missionService.GetMissionByIdAsync(id.Value);
            if (mission == null)
            {
                return NotFound();
            }

            var missionViewModel = new MissionViewModel
            {
                Id = mission.Id,
                Name = mission.Name,
                Description = mission.Description,
                LaunchDate = mission.LaunchDate,
                EndDate = mission.EndDate,
                Status = mission.Status,
                ImageUrl = mission.ImageUrl,
                Agency = mission.Agency,
                Type = mission.Type
            };

            return View(missionViewModel);
        }

        // POST: Missions/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, MissionViewModel missionViewModel)
        {
            if (id != missionViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var mission = new Mission
                {
                    Id = missionViewModel.Id,
                    Name = missionViewModel.Name,
                    Description = missionViewModel.Description,
                    LaunchDate = missionViewModel.LaunchDate,
                    EndDate = missionViewModel.EndDate,
                    Status = missionViewModel.Status,
                    ImageUrl = missionViewModel.ImageUrl,
                    Agency = missionViewModel.Agency,
                    Type = missionViewModel.Type
                };

                var updatedMission = await _missionService.UpdateMissionAsync(id, mission);
                if (updatedMission == null)
                {
                    return NotFound();
                }

                return RedirectToAction(nameof(Index));
            }
            return View(missionViewModel);
        }

        // GET: Missions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mission = await _missionService.GetMissionByIdAsync(id.Value);
            if (mission == null)
            {
                return NotFound();
            }

            return View(mission);
        }

        // POST: Missions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var result = await _missionService.DeleteMissionAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}