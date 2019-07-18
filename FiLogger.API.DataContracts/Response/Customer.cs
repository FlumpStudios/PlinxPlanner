using System;

namespace PlinxPlanner.API.DataContracts.Response
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public DateTime? FirstContactDate { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public string CompanyName { get; set; }
        public CustomerAddress CustomerAddress { get; set; }
        public Sitedetails Sitedetails { get; set; }
    }
}
