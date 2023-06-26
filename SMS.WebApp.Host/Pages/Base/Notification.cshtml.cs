using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Policy;

namespace SMS.WebApp.Host.Pages.Base
{
    public class NotificationModel : PageModel
    {
        [BindProperty]
        public string ModalTitle {get; set;}
        [BindProperty]
        public string Message { get; set;} 
        public void OnGet(string modalTitle, string message)
        {
            ModalTitle = modalTitle;
            Message = message;
        }
    }
}
