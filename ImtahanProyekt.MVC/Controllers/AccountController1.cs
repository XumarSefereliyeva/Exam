using ImtahanProyekt.BL.Services;
using ImtahanProyekt.BL.ViewModels;
using ImtahanProyekt.DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Shared;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.General;

namespace ImtahanProyekt.MVC.Controllers
{
    public class AccountController1 : Controller
    {
        private readonly AccountService _accountService;

        public AccountController1(AccountService accountService)
        {
            _accountService = accountService;
        }
        [HttpGet]
        public IActionResult Registr()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Registr(AccountVM accountVM)
        {
           await _accountService.RegistrAsync(accountVM);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(AccountLoginVM accountLoginVM)
        {
            return RedirectToAction(nameof(Index));
        }
    }
}
