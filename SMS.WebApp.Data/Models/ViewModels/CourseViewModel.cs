using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.WebApp.Data.Models.ViewModels
{
    public class CourseViewModel
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string CourseName { get; set; }
        [Required]
        public Guid TeacherId { get; set; }
        [Required]
        public string TeacherFullName { get; set; }
    }
}
