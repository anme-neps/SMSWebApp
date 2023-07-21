using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SMS.WebApp.Core.IRepositories;
using SMS.WebApp.Data.Models.DataModels;

namespace SMS.WebApp.Host.Pages.Images
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public List<Image> Imgs { get; set; }
        private readonly IImageRepositories _imageRepo;
        public IndexModel(IImageRepositories imageRepo)
        {
            _imageRepo = imageRepo;
        }
        public async Task<IActionResult> OnGet()
        {
            var result = await _imageRepo.GetAllImages();
            if (result.IsSuccess)
            {
                Imgs = result.Data;
                return Page();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
