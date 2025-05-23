using ImtahanProyekt.BL.ViewModels;
using ImtahanProyekt.DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImtahanProyekt.BL.Services
{
    public  class AccountService
    {
        private readonly UserManager<AppUser> _userManager;

        public AccountService(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<string> RegistrAsync(AccountVM accountVM)
        {
            AppUser appUser = new AppUser();
            appUser.Email = accountVM.Email;
            appUser.UserName = accountVM.Name;


          IdentityResult result= await _userManager.CreateAsync(appUser,accountVM.password);
            if(!result.Succeeded)
            {
                foreach(var error in result.Errors)
                {
                    return "Error";
                    
                }
            }
            return result.ToString();   

        }

    }
}
