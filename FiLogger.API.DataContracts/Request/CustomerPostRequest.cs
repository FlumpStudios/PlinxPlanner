using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PlinxPlanner.API.DataContracts.Request
{
    public class CustomerPostRequest
    {
        public int CustomerId { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public DateTime? FirstContactDate { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public string CompanyName { get; set; }
        public CustomerAddressPostRequest CustomerAddress { get; set; }
        public SiteDetailsPostrequest Sitedetails { get; set; }
    }
}
