using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MP6_UF4_Activity2_CodeFirst.Migrations
{
    public partial class third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    CustomerNumber = table.Column<int>(type: "int(11)", nullable: false),
                    CheckNumber = table.Column<string>(maxLength: 50, nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "date", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => new { x.CustomerNumber, x.CheckNumber });
                    table.ForeignKey(
                        name: "FK_Payments_Customers_CustomerNumber",
                        column: x => x.CustomerNumber,
                        principalTable: "Customers",
                        principalColumn: "CustomerNumber",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Payments");
        }
    }
}
