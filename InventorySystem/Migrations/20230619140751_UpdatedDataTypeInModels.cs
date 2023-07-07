using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventorySystem.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedDataTypeInModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Products_ProductsId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_ProductsId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "StockMovement");

            migrationBuilder.DropColumn(
                name: "DateIn",
                table: "StockIn");

            migrationBuilder.DropColumn(
                name: "ExpDate",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "MFD",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductsId",
                table: "Categories");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Date",
                table: "StockMovement",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DateIn",
                table: "StockIn",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ExpDate",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MFD",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductsId",
                table: "Categories",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ProductsId",
                table: "Categories",
                column: "ProductsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Products_ProductsId",
                table: "Categories",
                column: "ProductsId",
                principalTable: "Products",
                principalColumn: "Id");
        }
    }
}
