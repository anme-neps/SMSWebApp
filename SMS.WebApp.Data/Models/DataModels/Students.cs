﻿using SMS.WebApp.Data.Helper;
using SMS.WebApp.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.WebApp.Data.Models.DataModels
{
    public class Students : BaseModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public GenderEnum Gender { get; set; }
        public string GradeLevel { get; set; }
        public string PhoneNumber { get; set; }
    }
}
