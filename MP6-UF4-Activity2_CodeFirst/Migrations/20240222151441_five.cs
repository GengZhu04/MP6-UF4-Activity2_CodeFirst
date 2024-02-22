using Microsoft.EntityFrameworkCore.Migrations;

namespace MP6_UF4_Activity2_CodeFirst.Migrations
{
    public partial class five : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductCode = table.Column<string>(maxLength: 15, nullable: false),
                    ProductName = table.Column<string>(maxLength: 70, nullable: false),
                    ProductScale = table.Column<string>(maxLength: 10, nullable: false),
                    ProductVendor = table.Column<string>(maxLength: 50, nullable: false),
                    ProductDescription = table.Column<string>(type: "TEXT", nullable: false),
                    QuantityInStock = table.Column<short>(nullable: false),
                    BuyPrice = table.Column<decimal>(type: "DECIMAL(10,2)", nullable: false),
                    MSRP = table.Column<decimal>(type: "DECIMAL(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductCode);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    OrderNumber = table.Column<int>(type: "INT(11)", nullable: false),
                    ProductCode = table.Column<string>(maxLength: 15, nullable: false),
                    QuantityOrdered = table.Column<int>(type: "INT(11)", nullable: false),
                    PriceEach = table.Column<decimal>(type: "DECIMAL(10,2)", nullable: false),
                    OrderLineNumber = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => new { x.ProductCode, x.OrderNumber });
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderNumber",
                        column: x => x.OrderNumber,
                        principalTable: "Orders",
                        principalColumn: "OrderNumber",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Products_ProductCode",
                        column: x => x.ProductCode,
                        principalTable: "Products",
                        principalColumn: "ProductCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderNumber",
                table: "OrderDetails",
                column: "OrderNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
