using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.WebApp.Data.Helper
{
    public class DataResult
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
    public class DataResult<T>
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public int TotalCount { get; set; }
        public List<T> Data { get; set; }
    }
}
