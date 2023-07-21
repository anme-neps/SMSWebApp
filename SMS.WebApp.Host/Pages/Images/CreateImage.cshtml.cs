using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SMS.WebApp.Core.IRepositories;
using SMS.WebApp.Data.Models.DataModels;

namespace SMS.WebApp.Host.Pages.Images
{
    public class CreateImageModel : PageModel
    {
        [BindProperty]
        public Image Img { get; set; }
        private readonly IImageRepositories _imageRepo;
        public CreateImageModel(IImageRepositories imageRepo)
        {
            _imageRepo = imageRepo;
        }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost()
        {
            using (var memoryStream = new MemoryStream())
            {
                await Img.ImageFile.CopyToAsync(memoryStream);
                // Upload the file if less than 2 MB  
                if (memoryStream.Length < 2097152)
                {
                    //based on the upload file to create Photo instance.  
                    //You can also check the database, whether the image exists in the database.  
                    var newphoto = new Image()
                    {
                        ImageName = Img.ImageName,
                        Title = Img.Title,
                        CreatedDate = DateTime.Now,
                        CreateUserName = "",
                        ImageData = memoryStream.ToArray()
                    };
                    //add the photo instance to the list. 
                    await _imageRepo.CreateImage(newphoto);
                }
                else
                {
                    ModelState.AddModelError("File", "The file is too large.");
                }
            }
            
            return RedirectToPage("/Images/Index");
        }
    }
}
