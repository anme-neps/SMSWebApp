using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SMS.WebApp.Data.Models.DataModels;
using SMS.WebApp.Data.Models.ViewModels;
using SMS.WebApp.Services.IServices;

namespace SMS.WebApp.Host.Pages.Base
{
    public class StudentCRUDModel : PageModel
    {
        private readonly IStudentServices _studentServices;
        [BindProperty]
        public List<StudentViewModel> Students { get; set; }
        public StudentCRUDModel(IStudentServices studentServices)
        {
            _studentServices = studentServices;
        }
        public async Task<IActionResult> OnGet()
        {
            var result = await _studentServices.GetAllStudents();
            if (result.IsSuccess)
            {
                Students = result.Data;
                return Page();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
