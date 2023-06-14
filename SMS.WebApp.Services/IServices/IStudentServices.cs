using SMS.WebApp.Data.Helper;
using SMS.WebApp.Data.Models.DataModels;
using SMS.WebApp.Data.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.WebApp.Services.IServices
{
    public interface IStudentServices
    {
        Task<DataResult> CreateStudent(StudentViewModel studentArgs);
        Task<DataResult> UpdateStudent(StudentViewModel studentArgs);
        Task<DataResult> DeleteStudent(Guid studentId);
        Task<DataResult<StudentViewModel>> GetAllStudents();
    }
}
