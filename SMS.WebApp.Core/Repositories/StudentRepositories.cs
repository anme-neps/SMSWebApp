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
    public class StudentRepositories : IStudentRepositories
    {
        private readonly SMSDbContext _context;
        public StudentRepositories(SMSDbContext context)
        {
            _context = context;
        }
        public async Task<DataResult> CreateStudent(Students studentArgs)
        {
            DataResult result = new DataResult();
            try
            {
                await _context.Students.AddAsync(studentArgs);
                await _context.SaveChangesAsync();
                result.IsSuccess = true;
                result.Message = "Student created successfully";
            }
            catch (Exception ex)
            {
                result.IsSuccess= false;
                result.Message = ex.Message;
            }
            return result;
        }

        public async Task<DataResult> DeleteStudent(Guid studentId)
        {
            DataResult result = new DataResult();
            try
            {
                await _context.Students.Where(w => w.Id == studentId).ExecuteDeleteAsync();
                await _context.SaveChangesAsync();
                result.IsSuccess = true;
                result.Message = "Student deleted successfully";
            }
            catch (Exception ex)
            {
                result.IsSuccess= false;
                result.Message = ex.Message;
            }
            return result;
        }

        public async Task<DataResult<Students>> GetAllStudents()
        {
            DataResult<Students> result = new DataResult<Students>();
            try
            {
                result.Data = await _context.Students.Where(w => w.IsDeleted == false).ToListAsync();
                result.IsSuccess = true;
                result.Message = "Get students successful";
            }
            catch(Exception ex)
            {
                result.IsSuccess= false;
                result.Message = ex.Message;
            }
            return result;
        }

        public async Task<DataResult> UpdateStudent(Students studentArgs)
        {
            DataResult result = new DataResult();
            try
            {
                var student = await _context.Students.Where(w => w.Id == studentArgs.Id).FirstAsync();
                student.FirstName = studentArgs.FirstName;
                student.LastName = studentArgs.LastName;
                student.PhoneNumber = studentArgs.PhoneNumber;
                //student.ExecuteUpdateAsync();
                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                result.IsSuccess= false;
                result.Message = ex.Message;
            }
            return result;
        }
    }
}
