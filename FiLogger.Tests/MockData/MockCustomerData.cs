using PlinxPlanner.Common.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using dm = PlinxPlanner.Common.Models;
using vm = PlinxPlanner.API.DataContracts;

namespace PlinxPlanner.API.Tests.MockData
{
    public static class MockCustomerData
    {
        #region domain model mocks
        public static Customer MockCustomerDetails_dm()
        {
            return new Customer
            {
                CustomerId = 1,
                FirstName = "Tommy",
                Surname = "Test",
                FirstContactDate = new System.DateTime(2019, 1, 1),
                LastUpdateDate = new System.DateTime(2019, 1, 1),
                Title = "Mr",
                CustomerAddress = new CustomerAddress()
            };
        }

        public static IEnumerable<dm.Customer> MockCustomerDetailsList_dm()
        {
            return new List<dm.Customer>()
            {
                new dm.Customer
                {
                    CustomerId = 1,
                    FirstName = "Tommy",
                    Surname = "Test",
                    FirstContactDate = new System.DateTime(2019,1,1),
                    LastUpdateDate = new System.DateTime(2019, 1, 1),
                    Title ="Mr",
                    CustomerAddress = new CustomerAddress()
                },
                new dm.Customer
                {
                    CustomerId = 2,
                    FirstName = "Joe",
                    Surname = "Blogs",
                    FirstContactDate = new System.DateTime(2019,1,1),
                    LastUpdateDate = new System.DateTime(2019, 1, 1),
                    Title ="Mr",
                    CustomerAddress = new CustomerAddress()
                }
            };
        }

        public static vm.Request.CustomerPostRequest MockPostRequestModel()
        {
            return new vm.Request.CustomerPostRequest()
            {
                CustomerId = 1,
                FirstName = "Tommy",
                Surname = "Test",
                FirstContactDate = new System.DateTime(2019,1,1),
                LastUpdateDate = new System.DateTime(2019, 1, 1),
                Title ="Mr"               
            };
        }
        #endregion

        #region View model mocks
        public static vm.Response.Customer MockCustomerDetails_vm()
        {
            return new vm.Response.Customer
            {
                CustomerId = 1,
                FirstName = "Tommy",
                Surname = "Test",
                FirstContactDate = new System.DateTime(2019, 1, 1),
                LastUpdateDate = new System.DateTime(2019, 1, 1),
                Title = "Mr",
                CustomerAddress = new vm.Response.CustomerAddress(),
              
            };
        }

        public static IEnumerable<vm.Response.Customer> MockCustomerDetailsList_vm()
        {
            return new List<vm.Response.Customer> {
               new vm.Response.Customer
                {
                    CustomerId = 1,
                    FirstName = "Tommy",
                    Surname = "Test",
                    FirstContactDate = new System.DateTime(2019,1,1),
                    LastUpdateDate = new System.DateTime(2019, 1, 1),
                    Title ="Mr",
                    CustomerAddress = new vm.Response.CustomerAddress(),
              
                },
                new vm.Response.Customer
                {
                    CustomerId = 2,
                    FirstName = "Joe",
                    Surname = "Blogs",
                    FirstContactDate = new System.DateTime(2019,1,1),
                    LastUpdateDate = new System.DateTime(2019, 1, 1),
                    Title ="Mr",
                    CustomerAddress = new vm.Response.CustomerAddress(),
                    
                }
            };

        }
        #endregion
    }
}
