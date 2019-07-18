using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PlinxPlanner.Context.Migrations
{
    public partial class InitialMigration : Migration
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
                name: "Sitedetails",
                columns: table => new
                {
                    SiteDetailsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CustomerId = table.Column<int>(nullable: false),
                    TemplateId = table.Column<int>(nullable: false),
                    PrimaryColor = table.Column<string>(nullable: true),
                    SecondaryColour = table.Column<string>(nullable: true),
                    Base64Logo = table.Column<string>(nullable: true)
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
                });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "CustomerId", "CompanyName", "FirstContactDate", "FirstName", "LastUpdateDate", "Surname", "Title" },
                values: new object[] { 1, "Test company 1", new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Test Fname", new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Test Surname", "Mr" });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "CustomerId", "CompanyName", "FirstContactDate", "FirstName", "LastUpdateDate", "Surname", "Title" },
                values: new object[] { 2, "Test company 2", new DateTime(2019, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Test Fname 2", new DateTime(2019, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Test Surname 2", "Mrs" });

            migrationBuilder.InsertData(
                table: "CustomerAddress",
                columns: new[] { "AddressId", "AddressLine1", "AddressLine2", "County", "CustomerId", "EmailAddress", "MobileNumber", "PhoneNumber", "Postcode", "PropertyName", "PropertyNumber", "Town" },
                values: new object[,]
                {
                    { 1, "Line 1 test 1", "Line 2 Test 1", "Test County", 1, "Test@Test.com", "01234 456789", "01234 987654", "Test Postcode", null, "50", "Test town" },
                    { 2, "Line 1 test 2", "Line 2 Test 2", "Test County 2", 2, "Test2@Test.com", "01234 456781", "01234 987652", "Test Postcode 2", "Test prop name", null, "Test town 2" }
                });

            migrationBuilder.InsertData(
                table: "Sitedetails",
                columns: new[] { "SiteDetailsId", "Base64Logo", "CustomerId", "PrimaryColor", "SecondaryColour", "TemplateId" },
                values: new object[,]
                {
                    { 1, null, 1, "FF0000", "4800FF", 2 },
                    { 2, null, 2, "4800FF", "FF0000", 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAddress_CustomerId",
                table: "CustomerAddress",
                column: "CustomerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sitedetails_CustomerId",
                table: "Sitedetails",
                column: "CustomerId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerAddress");

            migrationBuilder.DropTable(
                name: "Sitedetails");

            migrationBuilder.DropTable(
                name: "Customer");
        }
    }
}
