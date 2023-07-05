using SMS.WebApp.Data.Helper;
using SMS.WebApp.Data.Models.DataModels;
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
        Task<DataResult<Course>> GetAllCourse();
        Task<DataResult<Course>> GetCourseById(Guid courseId);
    }
}
