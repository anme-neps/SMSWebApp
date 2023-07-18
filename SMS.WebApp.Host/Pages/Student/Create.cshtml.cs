using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SMS.WebApp.Data.Models.Enums;
using SMS.WebApp.Data.Models.ViewModels;
using SMS.WebApp.Services.IServices;

namespace SMS.WebApp.Host.Pages.Student
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly IStudentServices _studentServices;
        [BindProperty]
        public StudentViewModel StudentViewModel { get; set; }
        [BindProperty]
        public List<GenderEnum> GenderList { get; set; }
        public CreateModel(IStudentServices studentServices)
        {
            _studentServices = studentServices;
        }

        public async Task<IActionResult> OnGet()
        {
            var result = await _studentServices.GetGenderList();
            if (result.Data != null) 
            {
                GenderList = result.Data;
            }
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            StudentViewModel.UserName = User.Identity.Name;
            if(ModelState.IsValid)
            {
                var response = await _studentServices.CreateStudent(StudentViewModel);
                if (response.IsSuccess)
                {
                    return RedirectToPage("/Student/Index");
                }
                else
                {
                    return Page();
                }
            }
            return Page();
        }

        public async Task<JsonResult> OnGetGender()
        {
            var result = await _studentServices.GetGenderList();
            return new JsonResult(result);
        }
    }
}
