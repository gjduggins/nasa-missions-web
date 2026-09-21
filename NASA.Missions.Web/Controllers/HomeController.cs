using Microsoft.AspNetCore.Mvc;
using NASA.Missions.Web.Models;
using NASA.Missions.Web.Services;
using System.Diagnostics;

namespace NASA.Missions.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMissionService _missionService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IMissionService missionService, ILogger<HomeController> logger)
        {
            _missionService = missionService;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var missions = await _missionService.GetActiveMissionsAsync();
            return View(missions);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}