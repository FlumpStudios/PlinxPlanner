using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PlinxPlanner.Context.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    CustomerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(maxLength: 20, nullable: true),
                    FirstName = table.Column<string>(maxLength: 50, nullable: true),
                    Surname = table.Column<string>(maxLength: 50, nullable: true),
                    FirstContactDate = table.Column<DateTime>(nullable: true),
                    LastUpdateDate = table.Column<DateTime>(nullable: true),
                    CompanyName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "DefaultContent",
                columns: table => new
                {
                    DefaultContentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IntroTitle = table.Column<string>(nullable: true),
                    IntroText = table.Column<string>(nullable: true),
                    AboutSection = table.Column<string>(nullable: true),
                    Footer = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DefaultContent", x => x.DefaultContentId);
                });

            migrationBuilder.CreateTable(
                name: "SiteStatus",
                columns: table => new
                {
                    SitesStatusId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiteStatus", x => x.SitesStatusId);
                });

            migrationBuilder.CreateTable(
                name: "CustomerAddress",
                columns: table => new
                {
                    AddressId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CustomerId = table.Column<int>(nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 30, nullable: true),
                    MobileNumber = table.Column<string>(maxLength: 30, nullable: true),
                    EmailAddress = table.Column<string>(maxLength: 100, nullable: true),
                    Postcode = table.Column<string>(maxLength: 20, nullable: true),
                    PropertyNumber = table.Column<string>(maxLength: 20, nullable: true),
                    PropertyName = table.Column<string>(maxLength: 50, nullable: true),
                    AddressLine1 = table.Column<string>(maxLength: 50, nullable: true),
                    AddressLine2 = table.Column<string>(maxLength: 50, nullable: true),
                    Town = table.Column<string>(maxLength: 50, nullable: true),
                    County = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerAddress", x => x.AddressId);
                    table.ForeignKey(
                        name: "FK_CustomerAddress_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DefaultComments",
                columns: table => new
                {
                    DefaultCommentsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DefaultContentId = table.Column<int>(nullable: false),
                    Content = table.Column<string>(nullable: true),
                    Author = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DefaultComments", x => x.DefaultCommentsId);
                    table.ForeignKey(
                        name: "FK_DefaultComments_DefaultContent_DefaultContentId",
                        column: x => x.DefaultContentId,
                        principalTable: "DefaultContent",
                        principalColumn: "DefaultContentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DefaultExperiance",
                columns: table => new
                {
                    DefaultExperianceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DefaultContentId = table.Column<int>(nullable: false),
                    FromDate = table.Column<DateTime>(nullable: true),
                    ToDate = table.Column<DateTime>(nullable: true),
                    JobTitle = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Company = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DefaultExperiance", x => x.DefaultExperianceId);
                    table.ForeignKey(
                        name: "FK_DefaultExperiance_DefaultContent_DefaultContentId",
                        column: x => x.DefaultContentId,
                        principalTable: "DefaultContent",
                        principalColumn: "DefaultContentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DefaultPortfolio",
                columns: table => new
                {
                    DefaultPortFolioId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DefaultContentId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Link = table.Column<string>(nullable: true),
                    ImageSrc = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DefaultPortfolio", x => x.DefaultPortFolioId);
                    table.ForeignKey(
                        name: "FK_DefaultPortfolio_DefaultContent_DefaultContentId",
                        column: x => x.DefaultContentId,
                        principalTable: "DefaultContent",
                        principalColumn: "DefaultContentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DefaultSkills",
                columns: table => new
                {
                    DefaultSkillsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DefaultContentId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Value = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DefaultSkills", x => x.DefaultSkillsId);
                    table.ForeignKey(
                        name: "FK_DefaultSkills_DefaultContent_DefaultContentId",
                        column: x => x.DefaultContentId,
                        principalTable: "DefaultContent",
                        principalColumn: "DefaultContentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sitedetails",
                columns: table => new
                {
                    SiteDetailsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CustomerId = table.Column<int>(nullable: false),
                    SitesStatusId = table.Column<int>(nullable: false),
                    TemplateId = table.Column<int>(nullable: false),
                    PrimaryColor = table.Column<string>(nullable: true),
                    SecondaryColour = table.Column<string>(nullable: true),
                    Base64Logo = table.Column<string>(nullable: true),
                    SuperUserCreated = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sitedetails", x => x.SiteDetailsId);
                    table.ForeignKey(
                        name: "FK_Sitedetails_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sitedetails_SiteStatus_SitesStatusId",
                        column: x => x.SitesStatusId,
                        principalTable: "SiteStatus",
                        principalColumn: "SitesStatusId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "CustomerId", "CompanyName", "FirstContactDate", "FirstName", "LastUpdateDate", "Surname", "Title" },
                values: new object[,]
                {
                    { 1, "Test company 1", new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Test Fname", new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Test Surname", "Mr" },
                    { 2, "Test company 2", new DateTime(2019, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Test Fname 2", new DateTime(2019, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Test Surname 2", "Mrs" }
                });

            migrationBuilder.InsertData(
                table: "DefaultContent",
                columns: new[] { "DefaultContentId", "AboutSection", "Footer", "IntroText", "IntroTitle" },
                values: new object[] { 1, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", "Copyright © 2019 All rights reserved | This template is made with  by Colorlib", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.", "Hi, welcome to my site" });

            migrationBuilder.InsertData(
                table: "SiteStatus",
                columns: new[] { "SitesStatusId", "Name" },
                values: new object[,]
                {
                    { 1, "Pending" },
                    { 2, "Created" },
                    { 3, "Staging" },
                    { 4, "Live" },
                    { 5, "Cancelled" },
                    { 6, "Deleted" }
                });

            migrationBuilder.InsertData(
                table: "CustomerAddress",
                columns: new[] { "AddressId", "AddressLine1", "AddressLine2", "County", "CustomerId", "EmailAddress", "MobileNumber", "PhoneNumber", "Postcode", "PropertyName", "PropertyNumber", "Town" },
                values: new object[,]
                {
                    { 1, "Line 1 test 1", "Line 2 Test 1", "Test County", 1, "Test@Test.com", "01234 456789", "01234 987654", "Test Postcode", null, "50", "Test town" },
                    { 2, "Line 1 test 2", "Line 2 Test 2", "Test County 2", 2, "Test2@Test.com", "01234 456781", "01234 987652", "Test Postcode 2", "Test prop name", null, "Test town 2" }
                });

            migrationBuilder.InsertData(
                table: "DefaultComments",
                columns: new[] { "DefaultCommentsId", "Author", "Content", "DefaultContentId" },
                values: new object[,]
                {
                    { 1, "Mr Smith", "Comment will be added here", 1 },
                    { 2, "Mrs Jones", "Comment will be added here", 1 },
                    { 3, "Dr Peterson", "Comment will be added here", 1 },
                    { 4, "Mr Wright", "Comment will be added here", 1 },
                    { 5, "Miss Baker", "Comment will be added here", 1 },
                    { 6, "Mrs Hall", "Comment will be added here", 1 }
                });

            migrationBuilder.InsertData(
                table: "DefaultExperiance",
                columns: new[] { "DefaultExperianceId", "Company", "DefaultContentId", "Description", "FromDate", "JobTitle", "ToDate" },
                values: new object[,]
                {
                    { 1, "Company 1", 1, "Details of your work experiance go here", new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Your Job Title", null },
                    { 2, "Company 2", 1, "Details of your work experiance go here", new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Your Job Title", new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "Company 3", 1, "Details of your work experiance go here", new DateTime(2017, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Your Job Title", new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "DefaultPortfolio",
                columns: new[] { "DefaultPortFolioId", "DefaultContentId", "ImageSrc", "Link", "Name", "Type" },
                values: new object[,]
                {
                    { 6, 1, "http://www.testsrc.com", "http://www.testlink.com", "Project 6", "App" },
                    { 5, 1, "http://www.testsrc.com", "http://www.testlink.com", "Project 5", "App" },
                    { 4, 1, "http://www.testsrc.com", "http://www.testlink.com", "Project 4", "App" },
                    { 2, 1, "http://www.testsrc.com", "http://www.testlink.com", "Project 2", "Website" },
                    { 1, 1, "http://www.testsrc.com", "http://www.testlink.com", "Project 1", "Website" },
                    { 3, 1, "http://www.testsrc.com", "http://www.testlink.com", "Project 3", "Website" }
                });

            migrationBuilder.InsertData(
                table: "DefaultSkills",
                columns: new[] { "DefaultSkillsId", "DefaultContentId", "Name", "Value" },
                values: new object[,]
                {
                    { 1, 1, "C#", 90 },
                    { 2, 1, "CSS", 75 },
                    { 3, 1, "Javascript", 80 },
                    { 4, 1, "SQL", 70 },
                    { 5, 1, "C++", 55 },
                    { 6, 1, "Python", 87 }
                });

            migrationBuilder.InsertData(
                table: "Sitedetails",
                columns: new[] { "SiteDetailsId", "Base64Logo", "CustomerId", "PrimaryColor", "SecondaryColour", "SitesStatusId", "SuperUserCreated", "TemplateId" },
                values: new object[,]
                {
                    { 1, null, 1, "FF0000", "4800FF", 1, false, 1 },
                    { 2, null, 2, "4800FF", "FF0000", 2, false, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAddress_CustomerId",
                table: "CustomerAddress",
                column: "CustomerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DefaultComments_DefaultContentId",
                table: "DefaultComments",
                column: "DefaultContentId");

            migrationBuilder.CreateIndex(
                name: "IX_DefaultExperiance_DefaultContentId",
                table: "DefaultExperiance",
                column: "DefaultContentId");

            migrationBuilder.CreateIndex(
                name: "IX_DefaultPortfolio_DefaultContentId",
                table: "DefaultPortfolio",
                column: "DefaultContentId");

            migrationBuilder.CreateIndex(
                name: "IX_DefaultSkills_DefaultContentId",
                table: "DefaultSkills",
                column: "DefaultContentId");

            migrationBuilder.CreateIndex(
                name: "IX_Sitedetails_CustomerId",
                table: "Sitedetails",
                column: "CustomerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sitedetails_SitesStatusId",
                table: "Sitedetails",
                column: "SitesStatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerAddress");

            migrationBuilder.DropTable(
                name: "DefaultComments");

            migrationBuilder.DropTable(
                name: "DefaultExperiance");

            migrationBuilder.DropTable(
                name: "DefaultPortfolio");

            migrationBuilder.DropTable(
                name: "DefaultSkills");

            migrationBuilder.DropTable(
                name: "Sitedetails");

            migrationBuilder.DropTable(
                name: "DefaultContent");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "SiteStatus");
        }
    }
}
