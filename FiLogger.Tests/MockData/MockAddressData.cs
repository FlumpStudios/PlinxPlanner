using PlinxPlanner.Common.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using dm = PlinxPlanner.Common.Models;
using vm = PlinxPlanner.API.DataContracts;

namespace PlinxPlanner.API.Tests.MockData
{
    class MockAddressData
    {
        public static IEnumerable<dm.CustomerAddress> MockCustomerAddress_List_dm()
        {
            return new List<dm.CustomerAddress>
            {
                new dm.CustomerAddress
                {
                    AddressId = 1,
                    AddressLine1 = "Test first line 1",
                    AddressLine2 = "Test second line 1 ",
                    County = "Test Country 1",
                    CustomerId = 3,
                    EmailAddress = "Test Email 1",
                    MobileNumber = "Test Mobile Number 1",
                    PhoneNumber = "Test phone number 1",
                    Postcode = "Test postcode 1",
                    PropertyName = "Test property name 1",
                    PropertyNumber = "Test property number 1 ",
                    Town = "Test town 1"
                },
                new dm.CustomerAddress
                {
                    AddressId = 2,
                    AddressLine1 = "Test first line 2",
                    AddressLine2 = "Test second line 2 ",
                    County = "Test Country 2",
                    CustomerId = 2,
                    EmailAddress = "Test Email 2",
                    MobileNumber = "Test Mobile Number 2",
                    PhoneNumber = "Test phone number 2",
                    Postcode = "Test postcode 2",
                    PropertyName = "Test property name 2",
                    PropertyNumber = "Test property number 2",
                    Town = "Test town 2"
                },
                new dm.CustomerAddress
                {
                    AddressId = 3,
                    AddressLine1 = "Test first line 3",
                    AddressLine2 = "Test second line 3 ",
                    County = "Test Country 3",
                    CustomerId = 1,
                    EmailAddress = "Test Email 3",
                    MobileNumber = "Test Mobile Number 3",
                    PhoneNumber = "Test phone number 3",
                    Postcode = "Test postcode 3",
                    PropertyName = "Test property name 3",
                    PropertyNumber = "Test property number 3",
                    Town = "Test town 3"
                }
            };
        }

        public static dm.CustomerAddress MockCustomerAddress_dm()
        {

            return new dm.CustomerAddress
            {
                AddressId = 1,
                AddressLine1 = "Test first line 1",
                AddressLine2 = "Test second line 1 ",
                County = "Test Country 1",
                CustomerId = 1,
                EmailAddress = "Test Email 1",
                MobileNumber = "Test Mobile Number 1",
                PhoneNumber = "Test phone number 1",
                Postcode = "Test postcode 1",
                PropertyName = "Test property name 1",
                PropertyNumber = "Test property number 1 ",
                Town = "Test town 1"
            };
        }

        public static IEnumerable<vm.Response.CustomerAddress> MockCustomerAddress_List_vm()
        {
            return new List<vm.Response.CustomerAddress>
            {
                new vm.Response.CustomerAddress
                {
                    AddressId = 1,
                    AddressLine1 = "Test first line 1",
                    AddressLine2 = "Test second line 1 ",
                    County = "Test Country 1",
                    CustomerId = 3,
                    EmailAddress = "Test Email 1",
                    MobileNumber = "Test Mobile Number 1",
                    PhoneNumber = "Test phone number 1",
                    Postcode = "Test postcode 1",
                    PropertyName = "Test property name 1",
                    PropertyNumber = "Test property number 1 ",
                    Town = "Test town 1"
                },
                new vm.Response.CustomerAddress
                {
                    AddressId = 2,
                    AddressLine1 = "Test first line 2",
                    AddressLine2 = "Test second line 2 ",
                    County = "Test Country 2",
                    CustomerId = 2,
                    EmailAddress = "Test Email 2",
                    MobileNumber = "Test Mobile Number 2",
                    PhoneNumber = "Test phone number 2",
                    Postcode = "Test postcode 2",
                    PropertyName = "Test property name 2",
                    PropertyNumber = "Test property number 2",
                    Town = "Test town 2"
                },
                new vm.Response.CustomerAddress
                {
                    AddressId = 3,
                    AddressLine1 = "Test first line 3",
                    AddressLine2 = "Test second line 3 ",
                    County = "Test Country 3",
                    CustomerId = 1,
                    EmailAddress = "Test Email 3",
                    MobileNumber = "Test Mobile Number 3",
                    PhoneNumber = "Test phone number 3",
                    Postcode = "Test postcode 3",
                    PropertyName = "Test property name 3",
                    PropertyNumber = "Test property number 3",
                    Town = "Test town 3"
                }
            };
        }

        public static vm.Response.CustomerAddress MockCustomerAddress_vm()
        {

            return new vm.Response.CustomerAddress
            {
                AddressId = 1,
                AddressLine1 = "Test first line 1",
                AddressLine2 = "Test second line 1 ",
                County = "Test Country 1",
                CustomerId = 3,
                EmailAddress = "Test Email 1",
                MobileNumber = "Test Mobile Number 1",
                PhoneNumber = "Test phone number 1",
                Postcode = "Test postcode 1",
                PropertyName = "Test property name 1",
                PropertyNumber = "Test property number 1 ",
                Town = "Test town 1"
            };
        }

        public static vm.Request.CustomerAddressPostRequest MockCustomerAddress_vm_postrequest()
        {
            return new vm.Request.CustomerAddressPostRequest
            {
                AddressId = 1,
                AddressLine1 = "Test first line 1",
                AddressLine2 = "Test second line 1 ",
                County = "Test Country 1",
                CustomerId = 3,
                EmailAddress = "Test Email 1",
                MobileNumber = "Test Mobile Number 1",
                PhoneNumber = "Test phone number 1",
                Postcode = "Test postcode 1",
                PropertyName = "Test property name 1",
                PropertyNumber = "Test property number 1 ",
                Town = "Test town 1"
            };
        }
    }
}
