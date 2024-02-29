using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MP6_UF4_Activity2_CodeFirst.Migrations
{
    public partial class twelve : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductLines_ProductLines",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductLines",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductLines",
                table: "Products");

            migrationBuilder.AddColumn<string>(
                name: "ProductLineId",
                table: "Products",
                type: "VARCHAR(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<byte[]>(
                name: "Imatge",
                table: "ProductLines",
                type: "MEDIUMBLOB",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "MEDIUMBLOB");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductLineId",
                table: "Products",
                column: "ProductLineId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductLines_ProductLineId",
                table: "Products",
                column: "ProductLineId",
                principalTable: "ProductLines",
                principalColumn: "ProductLine",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductLines_ProductLineId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductLineId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductLineId",
                table: "Products");

            migrationBuilder.AddColumn<string>(
                name: "ProductLines",
                table: "Products",
                type: "varchar(50) CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AlterColumn<byte[]>(
                name: "Imatge",
                table: "ProductLines",
                type: "MEDIUMBLOB",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "MEDIUMBLOB",
                oldNullable: true);

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
    }
}
