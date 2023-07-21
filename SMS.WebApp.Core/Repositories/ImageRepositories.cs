using Microsoft.EntityFrameworkCore;
using SMS.WebApp.Core.IRepositories;
using SMS.WebApp.Data;
using SMS.WebApp.Data.Helper;
using SMS.WebApp.Data.Models.DataModels;
using SMS.WebApp.Data.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.WebApp.Core.Repositories
{
    public class ImageRepositories : IImageRepositories
    {
        private readonly SMSDbContext _context;
        public ImageRepositories(SMSDbContext context) 
        { 
            _context = context;
        }
        public async Task<DataResult> CreateImage(Image imageArgs)
        {
            DataResult result = new DataResult();
            try
            {
                await _context.Images.AddAsync(imageArgs);
                await _context.SaveChangesAsync();
                result.IsSuccess = true;
                result.Message = "Image created successfully";
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = ex.Message;
            }
            return result;
        }

        public async Task<DataResult> DeleteImage(int imageId)
        {
            DataResult result = new DataResult();
            try
            {
                var course = await _context.Images.FindAsync(imageId);
                if (course == null)
                {
                    result.IsSuccess = false;
                    result.Message = "No data found";
                }
                course.IsDeleted = true;
                await _context.SaveChangesAsync();
                result.IsSuccess = true;
                result.Message = "Image deleted successfully";
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = ex.Message;
            }
            return result;
        }

        public async Task<DataResult<Image>> GetAllImages()
        {
            DataResult<Image> result = new DataResult<Image>();
            try
            {
                result.Data = await _context.Images.Where(a => a.IsDeleted == false).ToListAsync();
                result.IsSuccess = true;
                result.Message = "Get all courses successful";
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = ex.Message;
            }
            return result;
        }

        public async Task<DataResult<Image>> GetImageByID(int imageId)
        {
            DataResult<Image> result = new DataResult<Image>();
            try
            {
                result.Data = await _context.Images.Where(a => a.IsDeleted == false && a.ImageId == imageId).ToListAsync();
                result.IsSuccess = true;
                result.Message = "Get all courses successful";
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = ex.Message;
            }
            return result;
        }
    }
}
