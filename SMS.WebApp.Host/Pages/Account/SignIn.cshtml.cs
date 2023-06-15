using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SMS.WebApp.Data.Models.ViewModels;
using SMS.WebApp.Services.IServices;

namespace SMS.WebApp.Host.Pages
{
    public class SignInModel : PageModel
    {
        [BindProperty]
        public LoginViewModel Account { get; set; }
        private readonly IAccountServices _services;
        public SignInModel(IAccountServices services)
        {
            _services = services;
        }
        public void OnGet()
        {
        }
        
        public async Task<IActionResult> OnPost() 
        {
            //var name = User.Identity.Name;
            var result = await _services.LoginAsync(this.Account);
            if (result.IsSuccess)
            { 
                return RedirectToPage("/Index");
            }
            return Page();
        }
    }
}
