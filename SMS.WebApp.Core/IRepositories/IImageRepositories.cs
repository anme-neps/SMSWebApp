using SMS.WebApp.Data.Helper;
using SMS.WebApp.Data.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.WebApp.Core.IRepositories
{
    public interface IImageRepositories
    {
        Task<DataResult> CreateImage(Image imageArgs);
        Task<DataResult> DeleteImage(int imageId);
        Task<DataResult<Image>> GetAllImages();
        Task<DataResult<Image>> GetImageByID(int imageId);
    }
}
