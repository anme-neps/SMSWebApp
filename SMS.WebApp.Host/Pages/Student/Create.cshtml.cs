using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SMS.WebApp.Data.Models.ViewModels;
using SMS.WebApp.Services.IServices;

namespace SMS.WebApp.Host.Pages.Student
{
    public class CreateModel : PageModel
    {
        private readonly IStudentServices _studentServices;
        [BindProperty]
        public StudentViewModel StudentViewModel { get; set; }
        public CreateModel(IStudentServices studentServices)
        {
            _studentServices = studentServices;
        }

        public void OnGet()
        {
        }
    }
}
