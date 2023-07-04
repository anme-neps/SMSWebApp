using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SMS.WebApp.Data.Helper;
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
        [BindProperty]
        public DataResult Response { get; set; }

        private readonly ITeacherServicesr _teacherServicesr;
        public IndexModel(ITeacherServicesr teacherServicesr)
        {
            _teacherServicesr = teacherServicesr;
        }

        public async Task<IActionResult> OnGet(DataResult resp)
        {
            var response = await _teacherServicesr.GetAllTeachers();
            TeacherList = response.Data;
            GenderList = Enum.GetValues<GenderEnum>().ToList();
            Response = resp;
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            DataResult response = new DataResult();
            if(TeacherVM.Id.Equals(Guid.Empty))
            {
                response = await _teacherServicesr.CreateTeacher(TeacherVM);
            }
            else
            {
                response = await _teacherServicesr.UpdateTeacher(TeacherVM);
            }
            return RedirectToAction("Index", response);
        }

        public async Task<IActionResult> OnGetDeleteTeacher(Guid id)
        {
            var response = await _teacherServicesr.DeleteTeacher(id);
            return RedirectToAction("Index", response);
        }

        public async Task<IActionResult> OnGetUpdateTeacher(Guid id)
        {
            var response = await _teacherServicesr.GetTeacherByID(id);
            return new OkObjectResult(response.Data.First());
        }
    }
}
