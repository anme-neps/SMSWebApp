using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SMS.WebApp.Data.Models.Enums;
using SMS.WebApp.Data.Models.ViewModels;
using SMS.WebApp.Services.IServices;

namespace SMS.WebApp.Host.Pages.Student
{
    public class UpdateModel : PageModel
    {
        private readonly IStudentServices _studentServices;
        [BindProperty]
        public StudentViewModel StudentViewModel { get; set; }
        [BindProperty]
        public List<GenderEnum> GenderList { get; set; }
        public UpdateModel(IStudentServices studentServices)
        {
            _studentServices = studentServices;
        }
        public async void OnGet(Guid id)
        {
            //Get student by ID
            var response = await _studentServices.GetStudentByID(id);
            var resp = await _studentServices.GetGenderList();
            if(response.Data != null)
            {
                StudentViewModel = response.Data.FirstOrDefault();
            }
            if(resp.Data != null) 
            {
                GenderList = resp.Data;
            }
        }

        public async Task<IActionResult> OnPost()
        {
            var response = await _studentServices.UpdateStudent(StudentViewModel);
            if (response.IsSuccess)
            {
                return RedirectToPage("/Student/Index");
            }
            return Page();
        }
    }
}
