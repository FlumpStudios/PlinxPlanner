using PlinxApplicationForm.Models;
using PlinxApplicationForm.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlinxApplicationForm.Helpers
{
    public static class ModelMapper
    {
        public static Customer Map(ApplicationFormModel x)
        {
            var mappedEntity = new Customer()
            {
                CompanyName = x.CompanyName,
                CustomerAddress = new CustomerAddress
                {
                    AddressLine1 = x.AddressLine1,
                    AddressLine2 = x.AddressLine2,
                    EmailAddress = x.EmailAddress,
                    County = x.County,
                    MobileNumber = x.MobileNumber,
                    PhoneNumber = x.PhoneNumber,
                    Postcode = x.Postcode,
                    PropertyName = x.PropertyName,
                    PropertyNumber = x.PropertyNumber,
                    Town = x.Town
                },
                FirstContactDate = x.FirstContactDate,
                FirstName = x.FirstName,
                LastUpdateDate = x.FirstContactDate,
                Sitedetails = new Sitedetails()
                {
                    Base64Logo = null,
                    PrimaryColor = x.PrimaryColor,
                    SecondaryColour = x.SecondaryColour,
                    TemplateId = x.TemplateId
                },
                Surname = x.Surname,
                Title = x.Title
            };

            return mappedEntity;
        }
    }
}
