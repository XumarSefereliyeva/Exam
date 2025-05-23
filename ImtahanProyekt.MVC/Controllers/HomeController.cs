using ImtahanProyekt.BL.Services;
using ImtahanProyekt.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace ImtahanProyekt.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly TeamService _teamService;
        public HomeController(TeamService teamService)
        {
            _teamService = teamService;
        }
        public IActionResult Index()
        {
            List<Team> teams=_teamService.GetAllteam();
            return View(teams);
        }
    }
}
