using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PricesComparation.Migrations
{
    public partial class modificationClasses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Product");

            migrationBuilder.CreateTable(
                name: "ProductShops",
                columns: table => new
                {
                    ProductShopId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    ShopId = table.Column<int>(type: "int", nullable: true),
                    Price = table.Column<double>(type: "double", nullable: false),
                    PriceDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductShops", x => x.ProductShopId);
                    table.ForeignKey(
                        name: "FK_ProductShops_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductShops_Shop_ShopId",
                        column: x => x.ShopId,
                        principalTable: "Shop",
                        principalColumn: "ShopId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PriceRecords",
                columns: table => new
                {
                    RecordId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ProductShopId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceRecords", x => x.RecordId);
                    table.ForeignKey(
                        name: "FK_PriceRecords_ProductShops_ProductShopId",
                        column: x => x.ProductShopId,
                        principalTable: "ProductShops",
                        principalColumn: "ProductShopId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PriceRecords_ProductShopId",
                table: "PriceRecords",
                column: "ProductShopId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductShops_ProductId",
                table: "ProductShops",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductShops_ShopId",
                table: "ProductShops",
                column: "ShopId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PriceRecords");

            migrationBuilder.DropTable(
                name: "ProductShops");

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Product",
                type: "double",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
