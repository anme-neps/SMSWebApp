using SMS.WebApp.Data.Helper;
using SMS.WebApp.Data.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.WebApp.Core.IRepositories
{
    public interface IStudentRepositories
    {
        Task<DataResult> CreateStudent(Students studentArgs);
        Task<DataResult> UpdateStudent(Students studentArgs);
        Task<DataResult> DeleteStudent(Guid studentId);
        Task<DataResult<Students>> GetAllStudents();
    }
}
