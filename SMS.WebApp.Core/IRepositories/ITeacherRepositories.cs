using SMS.WebApp.Data.Helper;
using SMS.WebApp.Data.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.WebApp.Core.IRepositories
{
    public interface ITeacherRepositories
    {
        Task<DataResult> CreateTeacher(Teacher teacherArgs);
        Task<DataResult> UpdateTeacher(Teacher teacherArgs);
        Task<DataResult> DeleteTeacher(Guid teacherId);
        Task<DataResult<Teacher>> GetAllTeachers();
        Task<DataResult<Teacher>> GetTeacherByID(Guid teacherID);
    }
}
