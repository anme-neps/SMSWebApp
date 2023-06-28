using Microsoft.EntityFrameworkCore;
using SMS.WebApp.Core.IRepositories;
using SMS.WebApp.Data;
using SMS.WebApp.Data.Helper;
using SMS.WebApp.Data.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.WebApp.Core.Repositories
{
    public class TeacherRepositories : ITeacherRepositories
    {
        private readonly SMSDbContext _context;
        public TeacherRepositories(SMSDbContext context)
        {
            _context = context;
        }
        public async Task<DataResult> CreateTeacher(Teacher teacherArgs)
        {
            DataResult result = new DataResult();
            try
            {
                await _context.Teachers.AddAsync(teacherArgs);
                await _context.SaveChangesAsync();
                result.IsSuccess = true;
                result.Message = "Student created successfully";
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = ex.Message;
            }
            return result;
        }

        public async Task<DataResult> DeleteTeacher(Guid teacherId)
        {
            DataResult result = new DataResult();
            try
            {
                //await _context.Students.Where(w => w.Id == studentId).ExecuteDeleteAsync();
                var teacher = await _context.Teachers.Where(w => w.Id == teacherId).FirstOrDefaultAsync();
                if (teacher == null)
                {
                    result.IsSuccess = false;
                    result.Message = "No user found";
                }
                teacher.IsDeleted = true;
                await _context.SaveChangesAsync();
                result.IsSuccess = true;
                result.Message = "Student deleted successfully";
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = ex.Message;
            }
            return result;
        }

        public async Task<DataResult<Teacher>> GetAllTeachers()
        {
            DataResult<Teacher> result = new DataResult<Teacher>();
            try
            {
                result.Data = await _context.Teachers.Where(w => w.IsDeleted == false).ToListAsync();
                result.IsSuccess = true;
                result.Message = "Get students successful";
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = ex.Message;
            }
            return result;
        }

        public async Task<DataResult<Teacher>> GetTeacherByID(Guid teacherID)
        {
            DataResult<Teacher> result = new DataResult<Teacher>();
            try
            {
                result.Data = await _context.Teachers.Where(w => w.Id == teacherID).ToListAsync();
                result.IsSuccess = true;
                result.Message = "Get student by Id success";
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = ex.Message;
            }
            return result;
        }

        public async Task<DataResult> UpdateTeacher(Teacher teacherArgs)
        {
            DataResult result = new DataResult();
            try
            {
                var teacher = await _context.Teachers.Where(w => w.Id == teacherArgs.Id).FirstAsync();
                teacher.FirstName = teacherArgs.FirstName;
                teacher.LastName = teacherArgs.LastName;
                teacher.Phone = teacherArgs.Phone;
                teacher.Gender = teacherArgs.Gender;
                teacher.Email= teacherArgs.Email;
                teacher.Subject = teacherArgs.Subject;
                teacher.DOB = teacherArgs.DOB;
                teacher.UpdateUserName = teacherArgs.UpdateUserName;
                teacher.UpdatedDate = teacherArgs.UpdatedDate;
                //student.ExecuteUpdateAsync();
                await _context.SaveChangesAsync();
                result.IsSuccess = true;
                result.Message = "Update student successful";
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
