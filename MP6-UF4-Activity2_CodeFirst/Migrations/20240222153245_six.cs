using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MP6_UF4_Activity2_CodeFirst.Migrations
{
    public partial class six : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProductLines",
                table: "Products",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ProductLines",
                columns: table => new
                {
                    ProductLine = table.Column<string>(maxLength: 50, nullable: false),
                    TextDescription = table.Column<string>(maxLength: 4000, nullable: false),
                    HtmlDescription = table.Column<string>(type: "MEDIUMTEXT", nullable: false),
                    Imatge = table.Column<byte[]>(type: "MEDIUMBLOB", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductLines", x => x.ProductLine);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductLines",
                table: "Products",
                column: "ProductLines");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductLines_ProductLines",
                table: "Products",
                column: "ProductLines",
                principalTable: "ProductLines",
                principalColumn: "ProductLine",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductLines_ProductLines",
                table: "Products");

            migrationBuilder.DropTable(
                name: "ProductLines");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductLines",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductLines",
                table: "Products");
        }
    }
}
