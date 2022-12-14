using _2ndTestPractice.IService;
using _2ndTestPractice.Models;
using _2ndTestPractice.Response;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Configuration.Internal;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace _2ndTestPractice.Service
{
    public class CustomerService : ICustomerService
    {
        string ConnectionString;
        public CustomerService()
        {
            ConnectionString = ConfigurationManager.AppSettings.Get("ConnectionString");
        }
        public ApiResponse GetBatchAndCustomer(DateTime dt)
        {
            try
            {
                using(var conn = new SqlConnection(ConnectionString))
                {
                    var cmd = new SqlCommand("select tblBatchDispatch.*,tblBatch.BatchNumber,tblBatch.Qty,tblCustomer.CustomerName,tblCustomer.Gender,tblCustomer.Email,tblCustomer.ContactNo from tblBatchDispatch join tblBatch on tblBatchDispatch.BatchId = tblBatch.Id join tblCustomer on tblBatchDispatch.CustId = tblCustomer.Id");
                    cmd.Connection = conn;
                    conn.Open();
                    var Result=cmd.ExecuteReader();
                    List<CustomerModelView>list=new List<CustomerModelView>();
                    while (Result.Read())
                    {
                        list.Add(new CustomerModelView()
                        {
                            Id = (int)Result["Id"],
                            BatchId = (int)Result["BatchId"],
                            BatchNumber = (string)Result["BatchNumber"],
                            CustId = (int)Result["CustId"],
                            ContactNo = (int)Result["ContactNo"],
                            Qty = (int)Result["Qty"],
                            Email = (string)Result["Email"],
                            CustomerName = (string)Result["CustomerName"],
                            Gender = (string)Result["Gender"],
                            DateOfDispatch = (DateTime)Result["DateOfDispatch"]

                        }); ;
                    }
                    conn.Close();
                    return new ApiResponse()
                    {
                        Data = list.Where(x=>x.DateOfDispatch==dt).ToList(),
                        version="0.15",
                        Message="Success",
                        Status=200,
                    };
                }
            }
            catch(Exception ex)
            {
                return new ApiResponse() 
                {
                    Data=null,
                    version="0.15",
                    Message = ex.Message,
                    Status=500,
                };
            }
            throw new NotImplementedException();
        }
        public ApiResponse GetCustomer()
        {
            try
            {
                using (var conn = new SqlConnection(ConnectionString))
                {
                    var cmd = new SqlCommand("select tblBatchDispatch.*,tblBatch.BatchNumber,tblBatch.Qty,tblCustomer.CustomerName,tblCustomer.Gender,tblCustomer.Email,tblCustomer.ContactNo from tblBatchDispatch join tblBatch on tblBatchDispatch.BatchId = tblBatch.Id join tblCustomer on tblBatchDispatch.CustId = tblCustomer.Id");
                    cmd.Connection = conn;
                    conn.Open();
                    var Result = cmd.ExecuteReader();
                    List<CustomerModelView> list = new List<CustomerModelView>();
                    while (Result.Read())
                    {
                        list.Add(new CustomerModelView()
                        {
                            Id = (int)Result["Id"],
                            BatchId = (int)Result["BatchId"],
                            BatchNumber = (string)Result["BatchNumber"],
                            CustId = (int)Result["CustId"],
                            ContactNo = (int)Result["ContactNo"],
                            Qty = (int)Result["Qty"],
                            Email = (string)Result["Email"],
                            CustomerName = (string)Result["CustomerName"],
                            Gender = (string)Result["Gender"],
                        });
                    }
                    conn.Close();
                    return new ApiResponse()
                    {
                        Data = list,
                        Message = "success",
                        Status = 200,
                        version = "1.0",
                    };
                }
            }
            catch (Exception ex)
            {
                return new ApiResponse()
                {
                    Data = null,
                    Message = ex.Message,
                    Status = 500,
                    version = "1.0",
                };
            }

            throw new NotImplementedException();
        }

        public ApiResponse GetCustomerDetail(int BatchNo)
        {

            throw new NotImplementedException();
        }
    }
}