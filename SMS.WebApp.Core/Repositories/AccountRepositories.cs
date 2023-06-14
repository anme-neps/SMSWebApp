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
            var user = await _userManager.FindByEmailAsync(model.Email);
            SignInResult signinResult = await _signInManager.PasswordSignInAsync(user.UserName, model.Password, false, lockoutOnFailure: true);
            //Get the matched email user details
            if (signinResult.Succeeded) { 
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
                //await _signInManager.SignInAsync(user, false);
                result.IsSuccess = true;
                result.Message = "User creation success";
            }
            else
            {
                result.IsSuccess = false;
                result.Message = "Could not register user";
            }
            return result;
        }
    }
}
