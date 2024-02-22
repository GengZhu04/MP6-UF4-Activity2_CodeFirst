using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MP6_UF4_Activity2_CodeFirst.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Offices",
                columns: table => new
                {
                    OfficeCode = table.Column<string>(maxLength: 10, nullable: false),
                    City = table.Column<string>(maxLength: 50, nullable: false),
                    Phone = table.Column<string>(maxLength: 50, nullable: false),
                    AddressLine1 = table.Column<string>(maxLength: 50, nullable: false),
                    AddressLine2 = table.Column<string>(maxLength: 50, nullable: false),
                    State = table.Column<string>(maxLength: 50, nullable: false),
                    Country = table.Column<string>(maxLength: 50, nullable: false),
                    PostalCode = table.Column<string>(maxLength: 15, nullable: false),
                    Territory = table.Column<string>(maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offices", x => x.OfficeCode);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeNumber = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    Extension = table.Column<string>(maxLength: 10, nullable: false),
                    Email = table.Column<string>(maxLength: 100, nullable: false),
                    OfficeCode = table.Column<string>(maxLength: 10, nullable: false),
                    ReportsTo = table.Column<int>(type: "int(11)", nullable: false),
                    JobTitle = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeNumber);
                    table.ForeignKey(
                        name: "FK_Employees_Offices_OfficeCode",
                        column: x => x.OfficeCode,
                        principalTable: "Offices",
                        principalColumn: "OfficeCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_Employees_ReportsTo",
                        column: x => x.ReportsTo,
                        principalTable: "Employees",
                        principalColumn: "EmployeeNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_OfficeCode",
                table: "Employees",
                column: "OfficeCode");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ReportsTo",
                table: "Employees",
                column: "ReportsTo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Offices");
        }
    }
}
