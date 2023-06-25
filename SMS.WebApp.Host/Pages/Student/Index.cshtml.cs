using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SMS.WebApp.Data.Models.ViewModels;
using SMS.WebApp.Services.IServices;

namespace SMS.WebApp.Host.Pages.Student
{
    public class IndexModel : PageModel
    {
        private readonly IStudentServices _studentServices;
        [BindProperty]
        public List<StudentViewModel> Students { get; set; }
        public IndexModel(IStudentServices studentServices)
        {
            _studentServices = studentServices;
        }
        public async Task<IActionResult> OnGet()
        {
            var result = await _studentServices.GetAllStudents();
            if(result.IsSuccess)
            {
                Students = result.Data;
                return Page();
            }
            else
            {
                return NotFound();
            }
        }

        public async Task<IActionResult> OnPostDelete(Guid id)
        {
            var result = await _studentServices.DeleteStudent(id);
            if (result.IsSuccess)
            {
                return Page();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
