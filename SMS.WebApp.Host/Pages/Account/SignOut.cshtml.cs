using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SMS.WebApp.Services.IServices;

namespace SMS.WebApp.Host.Pages.Account
{
    public class SignOutModel : PageModel
    {
        private readonly IAccountServices _services;
        [BindProperty]
        public string ResponseMessage { get; set; }
        public SignOutModel(IAccountServices services)
        {
            _services = services;
        }

        public void OnGet()
        {
            ResponseMessage = "Hello";
        }

        public async Task<IActionResult> OnPost(string returnUrl = null)
        {
            if (returnUrl != null)
            {
                var result = await _services.LogoutAsync();
                ResponseMessage = result.Message;
                return RedirectToPage(returnUrl);
            }
            else
            {
                return RedirectToPage("/Account/SignIn");
            }
        }
    }
}
