using SMS.WebApp.Data.Helper;
using SMS.WebApp.Data.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.WebApp.Services.IServices
{
    public interface ITeacherServicesr
    {
        Task<DataResult> CreateTeacher(TeacherViewModel teacherArgs);
        Task<DataResult> UpdateTeacher(TeacherViewModel teacherArgs);
        Task<DataResult> DeleteTeacher(Guid teacherId);
        Task<DataResult<TeacherViewModel>> GetAllTeachers();
        Task<DataResult<TeacherViewModel>> GetTeacherByID(Guid teacherID);
    }
}
