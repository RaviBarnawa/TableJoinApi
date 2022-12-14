using _2ndTestPractice.IService;
using _2ndTestPractice.Response;
using _2ndTestPractice.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _2ndTestPractice.Controllers
{
    public class CustomerController : ApiController
    {
        ICustomerService customerService;
        public CustomerController()
        {
            customerService = new CustomerService();
        }
        [HttpPost]
        [Route("Api/GetBatchAndCustomer")]
        public ApiResponse GetBatchAndCustomer(DateTime dt)
        {
            return customerService.GetBatchAndCustomer(dt);
        }
        [HttpGet]
        [Route("GetCustomer")]
        public ApiResponse GetCustomer()
        {
            return customerService.GetCustomer();
        }
    }
}
