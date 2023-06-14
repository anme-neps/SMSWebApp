using SMS.WebApp.Core.IRepositories;
using SMS.WebApp.Data.Helper;
using SMS.WebApp.Data.Models.DataModels;
using SMS.WebApp.Data.Models.ViewModels;
using SMS.WebApp.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.WebApp.Services.Services
{
    public class StudentServices : IStudentServices
    {
        private readonly IStudentRepositories _studentRepo;
        public StudentServices(IStudentRepositories studentRepo) 
        {
            _studentRepo = studentRepo;
        }
        public async Task<DataResult> CreateStudent(StudentViewModel studentArgs)
        {
            Students stu = new Students
            {
                FirstName = studentArgs.FirstName,
                LastName = studentArgs.LastName,
                DOB = studentArgs.DOB,
                Gender = studentArgs.Gender,
                PhoneNumber = studentArgs.PhoneNumber,
                GradeLevel = studentArgs.GradeLevel,
                CreateUserName = "",
                CreatedDate = DateTime.UtcNow,
                IsDeleted = false,
                UpdateUserName = null,
                UpdatedDate = DateTime.UtcNow,
            };
            var result = await _studentRepo.CreateStudent(stu);
            return result;
        }

        public Task<DataResult> DeleteStudent(Guid studentId)
        {
            throw new NotImplementedException();
        }

        public async Task<DataResult<StudentViewModel>> GetAllStudents()
        { 
            // Define return type variable
            DataResult<StudentViewModel> result = new DataResult<StudentViewModel>();
            // Get data from student repositories
            var response = await _studentRepo.GetAllStudents();
            // Assign value to defined return variable("result") from repositories response
            result.Message = response.Message;
            result.IsSuccess = response.IsSuccess;
            // Map data from students datamodel to StudentViewModel
            result.Data = response.Data.Select(s => new StudentViewModel
                                        {
                                            FirstName = s.FirstName,
                                        }).ToList();
            return result;
        }

        public Task<DataResult> UpdateStudent(StudentViewModel studentArgs)
        {
            throw new NotImplementedException();
        }
    }
}
