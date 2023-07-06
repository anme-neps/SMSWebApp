using Microsoft.EntityFrameworkCore;
using SMS.WebApp.Core.IRepositories;
using SMS.WebApp.Data;
using SMS.WebApp.Data.Helper;
using SMS.WebApp.Data.Models.DataModels;
using SMS.WebApp.Data.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.WebApp.Core.Repositories
{
    public class CourseRepositories : ICourseRepositories
    {
        private readonly SMSDbContext _context;
        public CourseRepositories(SMSDbContext context)
        {
            _context = context;
        }
        public async Task<DataResult> CreateCourse(Course courseArgs)
        {
            DataResult result = new DataResult();
            try
            {
                await _context.Courses.AddAsync(courseArgs);
                await _context.SaveChangesAsync();
                result.IsSuccess = true;
                result.Message = "Course created successfully";
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = ex.Message;
            }
            return result;
        }

        public async Task<DataResult> DeleteCourse(Guid courseId)
        {
            DataResult result = new DataResult();
            try
            {
                var course = await _context.Courses.FindAsync(courseId);
                if (course == null)
                {
                    result.IsSuccess = false;
                    result.Message = "No data found";
                }
                course.IsDeleted = true;
                await _context.SaveChangesAsync();
                result.IsSuccess = true;
                result.Message = "Course deleted successfully";
            }
            catch(Exception ex)
            {
                result.IsSuccess= false;
                result.Message = ex.Message;
            }
            return result;
        }
        // Just a Example
        public async Task<IEnumerable<Course>> GetAllCourseAsEnumerable()
        {
            var data = _context.Courses.Where(args => args.IsDeleted == false).Select(s => new Course 
            { 
                CourseName = s.CourseName, 
                TeacherId = s.TeacherId 
            });
            // select * from Courses Where IsDeleted = flase
            // select CourseName from Courses Where IsDeleted = flase
            // select CourseName, TechareId from Courses Where IsDeleted = flase
            return data;
        }

        public async Task<DataResult<CourseViewModel>> GetAllCourse()
        {
            DataResult<CourseViewModel> result = new DataResult<CourseViewModel>();
            try
            {
                result.Data = await _context.Courses
                                            .Where(a => a.IsDeleted == false).Select(s => new CourseViewModel
                                            { 
                                                Id = s.Id,
                                                CourseName = s.CourseName,
                                                TeacherId = s.TeacherId,
                                                TeacherFullName = s.Teacher.FirstName + " " + s.Teacher.LastName
                                            }).ToListAsync();
                result.IsSuccess = true;
                result.Message = "Get all courses successful";
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = ex.Message;
            }
            return result;
        }

        public async Task<DataResult<CourseViewModel>> GetCourseById(Guid courseId)
        {
            DataResult<CourseViewModel> result = new DataResult<CourseViewModel>();
            try
            {
                result.Data = await _context.Courses.Where(a => a.IsDeleted == false && a.Id == courseId).Select(s => new CourseViewModel
                {
                    Id = s.Id,
                    CourseName = s.CourseName,
                    TeacherId = s.TeacherId,
                    TeacherFullName = s.Teacher.FirstName + " " + s.Teacher.LastName
                }).ToListAsync();
                result.IsSuccess = true;
                result.Message = "Get courses successful";
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = ex.Message;
            }
            return result;
        }

        public async Task<DataResult> UpdateCourse(Course courseArgs)
        {
            DataResult result = new DataResult();
            try
            {
                var course = await _context.Courses.FindAsync(courseArgs.Id);
                if(course == null)
                {
                    result.IsSuccess = false;
                    result.Message = " No data found";
                }
                course.CourseName = courseArgs.CourseName;
                course.TeacherId = courseArgs.TeacherId;
                course.UpdateUserName = courseArgs.UpdateUserName;
                course.UpdatedDate = courseArgs.UpdatedDate;
            }
            catch(Exception ex)
            {
                result.IsSuccess = false;
                result.Message = ex.Message;
            }
            return result;
        }
    }
}
