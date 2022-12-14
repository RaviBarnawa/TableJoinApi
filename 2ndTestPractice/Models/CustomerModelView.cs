using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _2ndTestPractice.Models
{
    public class CustomerModelView
    {
        public int Id { get; set; }
        public int BatchId { get; set; }
        public DateTime DateOfDispatch { get; set; }
        public int CustId { get; set; }
        public string BatchNumber { get; set; }
        public int Qty { get; set; }
        public string CustomerName { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public int ContactNo { get; set; }
    }
}