using SMS.WebApp.Data.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.WebApp.Data.Models.DataModels
{
    public class Course : BaseModel
    {
        public Guid Id { get; set; }
        public string CourseName { get; set; }
        [ForeignKey("TeacherId")]
        public Guid TeacherId { get; set; }
        public Teacher Teacher { get; set;}
    }
}
