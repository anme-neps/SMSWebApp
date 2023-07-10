using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using SMS.WebApp.Data.Models.ViewModels;
using SMS.WebApp.Services.IServices;

namespace SMS.WebApp.Host.Pages.Course
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public List<CourseViewModel>? CourseList { get; set; }
        private readonly ICourseServices _courseServices;
        private readonly ITeacherServicesr _teacherServices;
        public IndexModel(ICourseServices courseServices, ITeacherServicesr teacherServices)
        {
            _courseServices = courseServices;
            _teacherServices = teacherServices;
        }
        public async Task OnGet()
        {
            var response = await _courseServices.GetAllCourse();
            if (response.Data != null)
            {
                CourseList = response.Data;
            }
        }

        public async Task<PartialViewResult> OnGetCreateCourse()
        {
            var teacherList = await _teacherServices.GetAllTeachers();
            CourseViewModel courseModel = new CourseViewModel
            {
                Teachers = teacherList.Data
            };
            return new PartialViewResult
            {
                ViewName = "_CreateCourse",
                ViewData = new ViewDataDictionary<CourseViewModel>(ViewData, courseModel)
            };
        }

        public async Task<IActionResult> OnPostAddCourse(CourseViewModel courseArgs)
        {
            var response = await _courseServices.CreateCourse(courseArgs);
            if (response.IsSuccess)
            {
                return RedirectToAction("/Course/Index");
            }
            return Page();
        }
    }
}
