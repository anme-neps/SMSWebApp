using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SMS.WebApp.Data.Models.Enums;
using SMS.WebApp.Data.Models.ViewModels;
using SMS.WebApp.Services.IServices;

namespace SMS.WebApp.Host.Pages.Teacher
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public List<TeacherViewModel> TeacherList { get; set; }
        [BindProperty]
        public TeacherViewModel TeacherVM { get; set; }
        [BindProperty]
        public List<GenderEnum> GenderList { get; set; }
        private readonly ITeacherServicesr _teacherServicesr;
        public IndexModel(ITeacherServicesr teacherServicesr)
        {
            _teacherServicesr = teacherServicesr;
        }

        public async Task<IActionResult> OnGet()
        {
            var response = await _teacherServicesr.GetAllTeachers();
            TeacherList = response.Data;
            GenderList = Enum.GetValues<GenderEnum>().ToList();
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            var response = await _teacherServicesr.CreateTeacher(TeacherVM);
            return RedirectToAction("Index");
        }
    }
}
