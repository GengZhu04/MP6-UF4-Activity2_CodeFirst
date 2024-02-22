using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MP6_UF4_Activity2_CodeFirst.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerNumber = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CustomerName = table.Column<string>(maxLength: 50, nullable: false),
                    ContactLastName = table.Column<string>(maxLength: 50, nullable: false),
                    ContactFirstName = table.Column<string>(maxLength: 50, nullable: false),
                    Phone = table.Column<string>(maxLength: 50, nullable: false),
                    AddressLine1 = table.Column<string>(maxLength: 50, nullable: false),
                    AddressLine2 = table.Column<string>(maxLength: 50, nullable: false),
                    City = table.Column<string>(maxLength: 50, nullable: false),
                    State = table.Column<string>(maxLength: 50, nullable: false),
                    PostalCode = table.Column<string>(maxLength: 15, nullable: false),
                    Country = table.Column<string>(maxLength: 50, nullable: false),
                    SalesRepEmployeeNumber = table.Column<int>(type: "int(11)", nullable: false),
                    CreditLimit = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerNumber);
                    table.ForeignKey(
                        name: "FK_Customers_Employees_SalesRepEmployeeNumber",
                        column: x => x.SalesRepEmployeeNumber,
                        principalTable: "Employees",
                        principalColumn: "EmployeeNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_SalesRepEmployeeNumber",
                table: "Customers",
                column: "SalesRepEmployeeNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
