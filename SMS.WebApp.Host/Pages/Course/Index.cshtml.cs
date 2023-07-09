using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SMS.WebApp.Data.Models.ViewModels;
using SMS.WebApp.Services.IServices;

namespace SMS.WebApp.Host.Pages.Course
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public List<CourseViewModel>? CourseList { get; set; }
        private readonly ICourseServices _courseServices;
        public IndexModel(ICourseServices courseServices)
        {
            _courseServices = courseServices;
        }
        public async void OnGet()
        {
            var response = await _courseServices.GetAllCourse();
            if (response.Data != null)
            {
                CourseList = response.Data;
            }
        }

        public async Task<PartialViewResult> OnGetCreateCourse()
        {
            return new PartialViewResult
            {
                ViewName = "_CreateCourse",
                //ViewData = new ViewDataDictionary<IEnumerable<Customer>>(ViewData, Customers)
            };
        }
    }
}
