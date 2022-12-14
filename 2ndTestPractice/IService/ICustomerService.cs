using _2ndTestPractice.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2ndTestPractice.IService
{
    internal interface ICustomerService
    {
        ApiResponse GetBatchAndCustomer(DateTime dt);
        ApiResponse GetCustomer();
        ApiResponse GetCustomerDetail(int BatchNo);
    }
}
