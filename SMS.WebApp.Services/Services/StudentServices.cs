using SMS.WebApp.Core.IRepositories;
using SMS.WebApp.Data.Helper;
using SMS.WebApp.Data.Models.DataModels;
using SMS.WebApp.Data.Models.Enums;
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
                CreateUserName = studentArgs.UserName,
                CreatedDate = DateTime.UtcNow,
                IsDeleted = false,
                UpdateUserName = null,
                UpdatedDate = null,
            };
            var result = await _studentRepo.CreateStudent(stu);
            return result;
        }

        public async Task<DataResult> DeleteStudent(Guid studentId)
        {
            return await _studentRepo.DeleteStudent(studentId);
        }

        public async Task<DataResult<StudentViewModel>> GetAllStudents()
        { 
            // Define return type variable
            DataResult<StudentViewModel> result = new DataResult<StudentViewModel>();
            // Get data from student repositories
            DataResult<Students> response = await _studentRepo.GetAllStudents();
            // Assign value to defined return variable("result") from repositories response
            result.Message = response.Message;
            result.IsSuccess = response.IsSuccess;
            // Map data from students datamodel to StudentViewModel
            result.Data = response.Data.Select(s => new StudentViewModel
                                        {
                                            StudentId = s.Id,
                                            FirstName = s.FirstName,
                                            LastName = s.LastName,
                                            DOB = s.DOB,
                                            Gender = s.Gender,
                                            PhoneNumber = s.PhoneNumber,
                                            GradeLevel = s.GradeLevel
                                        }).ToList();
            return result;
        }

        public async Task<DataResult<GenderEnum>> GetGenderList()
        {
            DataResult<GenderEnum> result = new DataResult<GenderEnum>();
            result.Data = Enum.GetValues<GenderEnum>().ToList();
            return result;
        }

        public async Task<DataResult<StudentViewModel>> GetStudentByID(Guid studentId)
        {
            DataResult<StudentViewModel> result = new DataResult<StudentViewModel>();
            var response = await _studentRepo.GetStudentsByID(studentId);
            result.Message = response.Message;
            result.IsSuccess = response.IsSuccess;
            result.Data = response.Data.Select(s => new StudentViewModel
                                        {
                                            StudentId = s.Id,
                                            FirstName = s.FirstName,
                                            LastName = s.LastName,
                                            DOB = s.DOB,
                                            Gender = s.Gender,
                                            PhoneNumber = s.PhoneNumber,
                                            GradeLevel = s.GradeLevel
                                        }).ToList();
            return result;
        }

        public async Task<DataResult> UpdateStudent(StudentViewModel studentArgs)
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
            var result = await _studentRepo.UpdateStudent(stu);
            return result;
        }
    }
}
