using Microsoft.AspNetCore.Identity;
using SMS.WebApp.Core.IRepositories;
using SMS.WebApp.Data.Helper;
using SMS.WebApp.Data.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.WebApp.Core.Repositories
{
    public class AccountRepositories : IAccountRepositories
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        public AccountRepositories(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<DataResult> LoginAsync(LoginViewModel model)
        {
            DataResult result = new DataResult();
            SignInResult response = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);
            if (response.Succeeded)
            {
                result.IsSuccess = true;
                result.Message = "User login success";
            }
            else
            {
                result.IsSuccess = false;
                result.Message = "No user found";
            }
            return result;
        }

        public async Task<DataResult> RegisterAsync(RegisterViewModel model)
        {
            DataResult result = new DataResult();
            var user = new IdentityUser
            {
                UserName = model.UserName,
                Email = model.Email
            };
            var response = await _userManager.CreateAsync(user, model.Password);
            if(response.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);
            }
            return result;
        }
    }
}
