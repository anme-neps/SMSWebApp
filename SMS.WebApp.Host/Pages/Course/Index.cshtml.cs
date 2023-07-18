using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using SMS.WebApp.Data.Models.RequestModels;
using SMS.WebApp.Data.Models.ViewModels;
using SMS.WebApp.Services.IServices;

namespace SMS.WebApp.Host.Pages.Course
{
    // Allow Annynomus | Authorize
    [Authorize]
    public class IndexModel : PageModel
    {
        [BindProperty]
        public List<CourseViewModel>? CourseList { get; set; }
        [BindProperty]
        public int PageCount { get; set; }
        private readonly ICourseServices _courseServices;
        private readonly ITeacherServicesr _teacherServices;
        public IndexModel(ICourseServices courseServices, ITeacherServicesr teacherServices)
        {
            _courseServices = courseServices;
            _teacherServices = teacherServices;
        }
        public async Task OnGet(int pageSize, int currentPage)
        {
            //Set Session
            HttpContext.Session.SetString("sessionDemo", "Value Stored in Session");
            RequestQueryParams queryParams = new RequestQueryParams
            {
                PageSize = pageSize == 0 ? 1 : pageSize,
                CurrentPage = currentPage == 0 ? 1 : currentPage
            };
            var response = await _courseServices.GetAllCourse(queryParams);
            if (response.Data != null)
            {
                CourseList = response.Data;
                PageCount = Convert.ToInt32(Math.Ceiling(response.TotalCount / (double)queryParams.PageSize));
            }
        }

        public async Task<PartialViewResult> OnGetCreateCourse()
        {
            //Get Session 
            var sess = HttpContext.Session.GetString("sessionDemo");
            var teacherList = await _teacherServices.GetAllTeachers();
            CourseViewModel courseModel = new CourseViewModel
            {
                Teachers = teacherList.Data,
                SessionExample = sess
            };
            return new PartialViewResult
            {
                ViewName = "_CreateCourse",
                ViewData = new ViewDataDictionary<CourseViewModel>(ViewData, courseModel)
            };
        }

        public async Task<PartialViewResult> OnGetUpdateCourse(Guid id)
        {
            var teacherList = await _teacherServices.GetAllTeachers();
            var course = await _courseServices.GetCourseById(id);
            var courseModel = course.Data.First();
            courseModel.Teachers = teacherList.Data;
            return new PartialViewResult
            {
                ViewName = "_UpdateCourse",
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

        public async Task<IActionResult> OnGetDeleteCourse(Guid courseId)
        {
            var response = await _courseServices.DeleteCourse(courseId);
            if(response.IsSuccess)
            {
                return RedirectToAction("/Course/Index");
            }
            return Page();
        }
    }
}
