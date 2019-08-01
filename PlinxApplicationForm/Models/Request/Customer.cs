using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlinxApplicationForm.Models.Request
{
    public class Customer
    {
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public DateTime? FirstContactDate { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public string CompanyName { get; set; }
        public CustomerAddress CustomerAddress { get; set; }
        public Sitedetails Sitedetails { get; set; }
    }

    public class CustomerAddress
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

        public Sitedetails Sitedetails { get; set; }
    }

    public class Sitedetails
    {
        public int SiteDetailsId { get; set; }
        public int CustomerId { get; set; }
        public int TemplateId { get; set; }
        public string PrimaryColor { get; set; }
        public string SecondaryColour { get; set; }
        public string Base64Logo { get; set; }
    }
}
