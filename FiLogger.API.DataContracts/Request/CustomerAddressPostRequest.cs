using System;
using System.Collections.Generic;
using System.Text;

namespace PlinxPlanner.API.DataContracts.Request
{
    public class CustomerAddressPostRequest
    {
        public int AddressId { get; set; }
        public int CustomerId { get; set; }

        public string PhoneNumber { get; set; }

        public string MobileNumber { get; set; }

        public string EmailAddress { get; set; }

        public string Postcode { get; set; }

        public string PropertyNumber { get; set; }

        public string PropertyName { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string Town { get; set; }

        public string County { get; set; }

    }
}
