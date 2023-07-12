using SMS.WebApp.Data.Helper;
using SMS.WebApp.Data.Models.DataModels;
using SMS.WebApp.Data.Models.RequestModels;
using SMS.WebApp.Data.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.WebApp.Core.IRepositories
{
    public interface ICourseRepositories
    {
        Task<DataResult> CreateCourse(Course courseArgs);
        Task<DataResult> UpdateCourse(Course courseArgs);
        Task<DataResult> DeleteCourse(Guid courseId);
        Task<DataResult<CourseViewModel>> GetAllCourse(RequestQueryParams queryParams);
        Task<DataResult<CourseViewModel>> GetCourseById(Guid courseId);
    }
}
