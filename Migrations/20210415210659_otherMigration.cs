using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PricesComparation.Migrations
{
    public partial class otherMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Shop_ShopId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Shop_Address_AddressId",
                table: "Shop");

            migrationBuilder.DropIndex(
                name: "IX_Product_ShopId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ShopId",
                table: "Product");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Shop",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AddressId",
                table: "Shop",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Product",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "PriceRecords",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<DateTime>(
                name: "PriceDate",
                table: "PriceRecords",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_Shop_Address_AddressId",
                table: "Shop",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "AdressId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shop_Address_AddressId",
                table: "Shop");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "PriceRecords");

            migrationBuilder.DropColumn(
                name: "PriceDate",
                table: "PriceRecords");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Shop",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "AddressId",
                table: "Shop",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<long>(
                name: "ShopId",
                table: "Product",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Product_ShopId",
                table: "Product",
                column: "ShopId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Shop_ShopId",
                table: "Product",
                column: "ShopId",
                principalTable: "Shop",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Shop_Address_AddressId",
                table: "Shop",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "AdressId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
