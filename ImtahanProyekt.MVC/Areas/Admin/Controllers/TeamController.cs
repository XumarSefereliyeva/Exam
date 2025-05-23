using ImtahanProyekt.BL.Services;
using ImtahanProyekt.BL.ViewModels;
using ImtahanProyekt.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace ImtahanProyekt.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TeamController : Controller
    {
        private readonly TeamService _teamService;

        public TeamController(TeamService teamService)
        {
            _teamService = teamService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<Team> team = _teamService.GetAllteam();
            return View(team);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(TeamCreateVM teamCreateVM)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            _teamService.Create(teamCreateVM);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Info(int id)
        {
            Team team = _teamService.GetTeamById(id);
            return View(team);
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            Team team= _teamService.GetTeamById(id);
            TeamUpdateVM teamUpdateVM =new TeamUpdateVM();
            teamUpdateVM.Position=team.Position;
            teamUpdateVM.Name=team.Name;
            return View(teamUpdateVM);
        }
        [HttpPost]
        public IActionResult Update(int id, TeamUpdateVM teamUpdateVM)
        {
            _teamService.Update(id, teamUpdateVM);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            _teamService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }

}
