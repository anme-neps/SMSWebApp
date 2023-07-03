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
    public class TeacherServices : ITeacherServicesr
    {
        private readonly ITeacherRepositories _teacherRepo;
        public TeacherServices(ITeacherRepositories teacherRepo)
        {
            _teacherRepo = teacherRepo;
        }

        public async Task<DataResult> CreateTeacher(TeacherViewModel teacherArgs)
        {
            Teacher data = new Teacher
            {
                FirstName = teacherArgs.FirstName,
                LastName = teacherArgs.LastName,
                DOB = teacherArgs.DOB,
                Gender = teacherArgs.Gender,
                Email = teacherArgs.Email,
                Phone = teacherArgs.Phone,
                Subject = teacherArgs.Subject,
                CreatedDate = DateTime.Now,
                CreateUserName = Environment.UserName,
                IsDeleted = false,
                UpdatedDate = null,
                UpdateUserName = null,
            };
            var result = await _teacherRepo.CreateTeacher(data);
            return result;
        }

        public async Task<DataResult> DeleteTeacher(Guid teacherId)
        {
            var result = await _teacherRepo.DeleteTeacher(teacherId);
            return result;
        }

        public async Task<DataResult<TeacherViewModel>> GetAllTeachers()
        {
            DataResult<TeacherViewModel> teacherList = new DataResult<TeacherViewModel>();
            var response = await _teacherRepo.GetAllTeachers();
            teacherList.Data = response.Data.Select(s => new TeacherViewModel
            {
                Id = s.Id,
                FirstName = s.FirstName,
                LastName = s.LastName,
                DOB = s.DOB,
                Email = s.Email,
                Phone = s.Phone,
                Gender = s.Gender,
                Subject = s.Subject,
            }).ToList();
            teacherList.Message = response.Message;
            teacherList.IsSuccess = response.IsSuccess;
            return teacherList;
        }

        public async Task<DataResult<TeacherViewModel>> GetTeacherByID(Guid teacherID)
        {
            DataResult<TeacherViewModel> teacherList = new DataResult<TeacherViewModel>();
            var response = await _teacherRepo.GetTeacherByID(teacherID);
            teacherList.Data = response.Data.Select(s => new TeacherViewModel
            {
                Id = s.Id,
                FirstName = s.FirstName,
                LastName = s.LastName,
                DOB = s.DOB,
                Email = s.Email,
                Phone = s.Phone,
                Gender = s.Gender,
                Subject = s.Subject,
            }).ToList();
            teacherList.Message = response.Message;
            teacherList.IsSuccess = response.IsSuccess;
            return teacherList;
        }

        public async Task<DataResult> UpdateTeacher(TeacherViewModel teacherArgs)
        {
            Teacher data = new Teacher
            {
                FirstName = teacherArgs.FirstName,
                LastName = teacherArgs.LastName,
                DOB = teacherArgs.DOB,
                Gender = teacherArgs.Gender,
                Email = teacherArgs.Email,
                Phone = teacherArgs.Phone,
                Subject = teacherArgs.Subject,
                IsDeleted = false,
                UpdatedDate = DateTime.Now,
                // TODO : implement method to get username
                UpdateUserName = "",
            };
            var result = await _teacherRepo.UpdateTeacher(data);
            return result;
        }
    }
}
