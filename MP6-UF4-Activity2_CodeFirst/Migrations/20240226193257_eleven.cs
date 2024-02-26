using Microsoft.EntityFrameworkCore.Migrations;

namespace MP6_UF4_Activity2_CodeFirst.Migrations
{
    public partial class eleven : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Customers_CustomerNumberId",
                table: "Orders");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerNumberId",
                table: "Orders",
                type: "INT(11)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INT(11)");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Customers_CustomerNumberId",
                table: "Orders",
                column: "CustomerNumberId",
                principalTable: "Customers",
                principalColumn: "CustomerNumber",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Customers_CustomerNumberId",
                table: "Orders");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerNumberId",
                table: "Orders",
                type: "INT(11)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INT(11)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Customers_CustomerNumberId",
                table: "Orders",
                column: "CustomerNumberId",
                principalTable: "Customers",
                principalColumn: "CustomerNumber",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
