using PlinxPlanner.Common.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace PlinxPlanner.Context.Data
{
    public static class DBInitialiser
    {

        /// <summary>
        /// Static method for generating seeding the database.
        /// </summary>
        /// <param name="modelBuilder"></param>
        public static void SeedDB(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasData(new Customer
            {
                CustomerId = 1,
                FirstContactDate = new DateTime(2019, 1, 1),
                FirstName = "Test Fname",
                LastUpdateDate = new DateTime(2019, 1, 1),
                Surname = "Test Surname",
                CompanyName = "Test company 1",
                Title = "Mr"
            },
             new Customer
             {
                 CustomerId = 2,
                 FirstContactDate = new DateTime(2019, 2, 2),
                 FirstName = "Test Fname 2",
                 LastUpdateDate = new DateTime(2019, 2, 2),
                 Surname = "Test Surname 2",
                 Title = "Mrs",
                 CompanyName = "Test company 2",

             });

            modelBuilder.Entity<CustomerAddress>().HasData(new CustomerAddress
            {
                AddressId = 1,
                AddressLine1 = "Line 1 test 1",
                AddressLine2 = "Line 2 Test 1",
                EmailAddress = "Test@Test.com",
                County = "Test County",
                CustomerId = 1,
                MobileNumber = "01234 456789",
                PhoneNumber = "01234 987654",
                Postcode = "Test Postcode",
                PropertyName = null,
                PropertyNumber = "50",
                Town = "Test town"
            },
            new CustomerAddress
            {
                AddressId = 2,
                AddressLine1 = "Line 1 test 2",
                AddressLine2 = "Line 2 Test 2",
                EmailAddress = "Test2@Test.com",
                County = "Test County 2",
                CustomerId = 2,
                MobileNumber = "01234 456781",
                PhoneNumber = "01234 987652",
                Postcode = "Test Postcode 2",
                PropertyName = "Test prop name",
                PropertyNumber = null,
                Town = "Test town 2"
            }
            );

            modelBuilder.Entity<SiteStatus>().HasData(new SiteStatus
            {
                SitesStatusId = 1,
                Name = "Pending"
            },
            new SiteStatus
            {
                SitesStatusId = 2,
                Name = "Created"
            },
            new SiteStatus
            {
                SitesStatusId = 3,
                Name = "Staging"
            },
            new SiteStatus
            {
                SitesStatusId = 4,
                Name = "Live"
            },
            new SiteStatus
            {
                SitesStatusId = 5,
                Name = "Cancelled"
            },
            new SiteStatus
            {
                SitesStatusId = 6,
                Name = "Deleted"
            });

            modelBuilder.Entity<Sitedetails>().HasData(new Sitedetails
            {
                CustomerId = 1,
                PrimaryColor = "FF0000",
                SecondaryColour = "4800FF",
                SiteDetailsId = 1,
                TemplateId = 1,
                SitesStatusId = 1

            }, new Sitedetails
            {
                CustomerId = 2,
                PrimaryColor = "4800FF",
                SecondaryColour = "FF0000",
                SiteDetailsId = 2,
                TemplateId = 2,
                SitesStatusId = 2
            });
        }
    }
}