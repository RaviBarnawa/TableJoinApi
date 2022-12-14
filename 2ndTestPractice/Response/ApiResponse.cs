using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _2ndTestPractice.Response
{
    public class ApiResponse
    {
        public int Status { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
        public string version { get; set; }
    }
}