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
    public class CourseServices : ICourseServices
    {
        private readonly ICourseRepositories _repository;
        public CourseServices(ICourseRepositories repository)
        {
            _repository = repository;
        }

        public async Task<DataResult> CreateCourse(CourseViewModel courseArgs)
        {
            Course cour = new Course
            {
                CourseName = courseArgs.CourseName,
                TeacherId = courseArgs.TeacherId,
                CreatedDate = DateTime.Now,
                CreateUserName = ""
                //IsDeleted = false,
                //UpdateUserName = null,
                //UpdatedDate = null
            };
            var response = await _repository.CreateCourse(cour);
            return response;
        }

        public async Task<DataResult> DeleteCourse(Guid courseId)
        {
            var response = await _repository.DeleteCourse(courseId);
            return response;
        }

        public async Task<DataResult<CourseViewModel>> GetAllCourse()
        {
            var response = await _repository.GetAllCourse();
            return response;
        }

        public async Task<DataResult<CourseViewModel>> GetCourseById(Guid courseId)
        {
            var response = await _repository.GetCourseById(courseId);
            return response;
        }

        public async Task<DataResult> UpdateCourse(CourseViewModel courseArgs)
        {
            Course cour = new Course
            {
                CourseName = courseArgs.CourseName,
                TeacherId = courseArgs.TeacherId,
                UpdateUserName = "",
                UpdatedDate = DateTime.Now
            };
            var response = await _repository.UpdateCourse(cour);
            return response;
        }
    }
}
