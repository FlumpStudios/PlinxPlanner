﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PlinxPlanner.Context.Data;

namespace PlinxPlanner.Context.Migrations
{
    [DbContext(typeof(AP_ReplacementContext))]
    partial class AP_ReplacementContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PlinxPlanner.Common.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CompanyName");

                    b.Property<DateTime?>("FirstContactDate");

                    b.Property<string>("FirstName")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("LastUpdateDate");

                    b.Property<string>("Surname")
                        .HasMaxLength(50);

                    b.Property<string>("Title")
                        .HasMaxLength(20);

                    b.HasKey("CustomerId");

                    b.ToTable("Customer");

                    b.HasData(
                        new
                        {
                            CustomerId = 1,
                            CompanyName = "Test company 1",
                            FirstContactDate = new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Test Fname",
                            LastUpdateDate = new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Surname = "Test Surname",
                            Title = "Mr"
                        },
                        new
                        {
                            CustomerId = 2,
                            CompanyName = "Test company 2",
                            FirstContactDate = new DateTime(2019, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Test Fname 2",
                            LastUpdateDate = new DateTime(2019, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Surname = "Test Surname 2",
                            Title = "Mrs"
                        });
                });

            modelBuilder.Entity("PlinxPlanner.Common.Models.CustomerAddress", b =>
                {
                    b.Property<int>("AddressId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AddressLine1")
                        .HasMaxLength(50);

                    b.Property<string>("AddressLine2")
                        .HasMaxLength(50);

                    b.Property<string>("County")
                        .HasMaxLength(50);

                    b.Property<int>("CustomerId");

                    b.Property<string>("EmailAddress")
                        .HasMaxLength(100);

                    b.Property<string>("MobileNumber")
                        .HasMaxLength(30);

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(30);

                    b.Property<string>("Postcode")
                        .HasMaxLength(20);

                    b.Property<string>("PropertyName")
                        .HasMaxLength(50);

                    b.Property<string>("PropertyNumber")
                        .HasMaxLength(20);

                    b.Property<string>("Town")
                        .HasMaxLength(50);

                    b.HasKey("AddressId");

                    b.HasIndex("CustomerId")
                        .IsUnique();

                    b.ToTable("CustomerAddress");

                    b.HasData(
                        new
                        {
                            AddressId = 1,
                            AddressLine1 = "Line 1 test 1",
                            AddressLine2 = "Line 2 Test 1",
                            County = "Test County",
                            CustomerId = 1,
                            EmailAddress = "Test@Test.com",
                            MobileNumber = "01234 456789",
                            PhoneNumber = "01234 987654",
                            Postcode = "Test Postcode",
                            PropertyNumber = "50",
                            Town = "Test town"
                        },
                        new
                        {
                            AddressId = 2,
                            AddressLine1 = "Line 1 test 2",
                            AddressLine2 = "Line 2 Test 2",
                            County = "Test County 2",
                            CustomerId = 2,
                            EmailAddress = "Test2@Test.com",
                            MobileNumber = "01234 456781",
                            PhoneNumber = "01234 987652",
                            Postcode = "Test Postcode 2",
                            PropertyName = "Test prop name",
                            Town = "Test town 2"
                        });
                });

            modelBuilder.Entity("PlinxPlanner.Common.Models.Sitedetails", b =>
                {
                    b.Property<int>("SiteDetailsId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Base64Logo");

                    b.Property<int>("CustomerId");

                    b.Property<string>("PrimaryColor");

                    b.Property<string>("SecondaryColour");

                    b.Property<int>("TemplateId");

                    b.HasKey("SiteDetailsId");

                    b.HasIndex("CustomerId")
                        .IsUnique();

                    b.ToTable("Sitedetails");

                    b.HasData(
                        new
                        {
                            SiteDetailsId = 1,
                            CustomerId = 1,
                            PrimaryColor = "FF0000",
                            SecondaryColour = "4800FF",
                            TemplateId = 2
                        },
                        new
                        {
                            SiteDetailsId = 2,
                            CustomerId = 2,
                            PrimaryColor = "4800FF",
                            SecondaryColour = "FF0000",
                            TemplateId = 4
                        });
                });

            modelBuilder.Entity("PlinxPlanner.Common.Models.CustomerAddress", b =>
                {
                    b.HasOne("PlinxPlanner.Common.Models.Customer")
                        .WithOne("CustomerAddress")
                        .HasForeignKey("PlinxPlanner.Common.Models.CustomerAddress", "CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PlinxPlanner.Common.Models.Sitedetails", b =>
                {
                    b.HasOne("PlinxPlanner.Common.Models.Customer")
                        .WithOne("Sitedetails")
                        .HasForeignKey("PlinxPlanner.Common.Models.Sitedetails", "CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
