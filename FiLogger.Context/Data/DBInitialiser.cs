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

            modelBuilder.Entity<DefaultExperiance>().HasData(new DefaultExperiance
            {
                Company = "Company 1",
                DefaultContentId = 1,
                DefaultExperianceId = 1,
                Description = "Details of your work experiance go here",
                FromDate = new DateTime(2019, 1, 1),
                ToDate = null,
                JobTitle = "Your Job Title"
            },
            new DefaultExperiance{
                Company = "Company 2",
                DefaultExperianceId = 2,
                DefaultContentId = 1,
                Description = "Details of your work experiance go here",
                FromDate = new DateTime(2018, 1, 1),
                ToDate = new DateTime(2019, 1, 1),
                JobTitle = "Your Job Title"
            },
            new DefaultExperiance
            {
                Company = "Company 3",
                DefaultExperianceId = 3,
                DefaultContentId = 1,
                Description = "Details of your work experiance go here",
                FromDate = new DateTime(2017, 1, 1),
                ToDate = new DateTime(2018, 1, 1),
                JobTitle = "Your Job Title"
            });

            modelBuilder.Entity<DefaultPortfolio>().HasData(new DefaultPortfolio
            {
                DefaultContentId = 1,
                DefaultPortFolioId = 1,
                Link = "http://www.testlink.com",
                Name = "Project 1",
                Type = "Website",
                ImageSrc = "http://www.testsrc.com"
            },
            new DefaultPortfolio
            {
                DefaultContentId = 1,
                DefaultPortFolioId = 2,
                Link = "http://www.testlink.com",
                Name = "Project 2",
                Type = "Website",
                ImageSrc = "http://www.testsrc.com"
            },
            new DefaultPortfolio
            {
                DefaultContentId = 1,
                DefaultPortFolioId = 3,
                Link = "http://www.testlink.com",
                Name = "Project 3",
                Type = "Website",
                ImageSrc = "http://www.testsrc.com"
            },
            new DefaultPortfolio
            {
                DefaultContentId = 1,
                DefaultPortFolioId = 4,
                Link = "http://www.testlink.com",
                Name = "Project 4",
                Type = "App",
                ImageSrc = "http://www.testsrc.com"
            },
            new DefaultPortfolio
            {
                DefaultContentId = 1,
                DefaultPortFolioId = 5,
                Link = "http://www.testlink.com",
                Name = "Project 5",
                Type = "App",
                ImageSrc = "http://www.testsrc.com"
            },
            new DefaultPortfolio
            {
                DefaultContentId = 1,
                DefaultPortFolioId = 6,
                Link = "http://www.testlink.com",
                Name = "Project 6",
                Type = "App",
                ImageSrc = "http://www.testsrc.com"
            });

            modelBuilder.Entity<DefaultComments>().HasData(new DefaultComments {
                Author = "Mr Smith",
                Content = "Comment will be added here",
                DefaultCommentsId = 1,
                DefaultContentId = 1
            },
            new DefaultComments
            {
                Author = "Mrs Jones",
                Content = "Comment will be added here",
                DefaultCommentsId = 2,
                DefaultContentId = 1
            },
            new DefaultComments
            {
                Author = "Dr Peterson",
                Content = "Comment will be added here",
                DefaultCommentsId = 3,
                DefaultContentId = 1
            },
            new DefaultComments
            {
                Author = "Mr Wright",
                Content = "Comment will be added here",
                DefaultCommentsId = 4,
                DefaultContentId = 1
            },
            new DefaultComments
            {
                Author = "Miss Baker",
                Content = "Comment will be added here",
                DefaultCommentsId = 5,
                DefaultContentId = 1
            },
            new DefaultComments
            {
                Author = "Mrs Hall",
                Content = "Comment will be added here",
                DefaultCommentsId = 6,
                DefaultContentId = 1
            });

            modelBuilder.Entity<DefaultSkills>().HasData(new DefaultSkills
            {
                DefaultContentId = 1,
                DefaultSkillsId = 1,
                Name = "C#",
                Value = 90
            },
            new DefaultSkills
            {
                DefaultContentId = 1,
                DefaultSkillsId = 2,
                Name = "CSS",
                Value = 75
            },
            new DefaultSkills
            {
                DefaultContentId = 1,
                DefaultSkillsId = 3,
                Name = "Javascript",
                Value = 80
            },
            new DefaultSkills
            {
                DefaultContentId = 1,
                DefaultSkillsId = 4,
                Name = "SQL",
                Value = 70
            },
            new DefaultSkills
            {
                DefaultContentId = 1,
                DefaultSkillsId = 5,
                Name = "C++",
                Value = 55
            },
            new DefaultSkills
            {
                DefaultContentId = 1,
                DefaultSkillsId = 6,
                Name = "Python",
                Value = 87
            }
            );

            modelBuilder.Entity<DefaultContent>().HasData(new DefaultContent {
                DefaultContentId = 1,
                AboutSection = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                IntroText = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                IntroTitle = "Hi, welcome to my site",
                Footer = "Copyright © 2019 All rights reserved | This template is made with  by Colorlib"
            });
            }
            }
    }
