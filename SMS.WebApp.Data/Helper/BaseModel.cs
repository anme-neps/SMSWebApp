using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.WebApp.Data.Helper
{
    public class BaseModel
    {
        public DateTime CreatedDate { get; set; }
        public string CreateUserName { get; set; }
        public DateTime? UpdatedDate { get; set;}
        public string? UpdateUserName { get; set; }
        public bool IsDeleted { get; set; }
    }
}
