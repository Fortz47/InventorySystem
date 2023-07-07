using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventorySystem.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedStockInViewModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_StockInViewModel_StockInViewModelId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Warehouse_StockInViewModel_StockInViewModelId",
                table: "Warehouse");

            migrationBuilder.DropIndex(
                name: "IX_Warehouse_StockInViewModelId",
                table: "Warehouse");

            migrationBuilder.DropIndex(
                name: "IX_Products_StockInViewModelId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "StockInViewModelId",
                table: "Warehouse");

            migrationBuilder.DropColumn(
                name: "StockInViewModelId",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "ProductsId",
                table: "StockInViewModel",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WarehouseId",
                table: "StockInViewModel",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_StockInViewModel_ProductsId",
                table: "StockInViewModel",
                column: "ProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_StockInViewModel_WarehouseId",
                table: "StockInViewModel",
                column: "WarehouseId");

            migrationBuilder.AddForeignKey(
                name: "FK_StockInViewModel_Products_ProductsId",
                table: "StockInViewModel",
                column: "ProductsId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StockInViewModel_Warehouse_WarehouseId",
                table: "StockInViewModel",
                column: "WarehouseId",
                principalTable: "Warehouse",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockInViewModel_Products_ProductsId",
                table: "StockInViewModel");

            migrationBuilder.DropForeignKey(
                name: "FK_StockInViewModel_Warehouse_WarehouseId",
                table: "StockInViewModel");

            migrationBuilder.DropIndex(
                name: "IX_StockInViewModel_ProductsId",
                table: "StockInViewModel");

            migrationBuilder.DropIndex(
                name: "IX_StockInViewModel_WarehouseId",
                table: "StockInViewModel");

            migrationBuilder.DropColumn(
                name: "ProductsId",
                table: "StockInViewModel");

            migrationBuilder.DropColumn(
                name: "WarehouseId",
                table: "StockInViewModel");

            migrationBuilder.AddColumn<int>(
                name: "StockInViewModelId",
                table: "Warehouse",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StockInViewModelId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Warehouse_StockInViewModelId",
                table: "Warehouse",
                column: "StockInViewModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_StockInViewModelId",
                table: "Products",
                column: "StockInViewModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_StockInViewModel_StockInViewModelId",
                table: "Products",
                column: "StockInViewModelId",
                principalTable: "StockInViewModel",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Warehouse_StockInViewModel_StockInViewModelId",
                table: "Warehouse",
                column: "StockInViewModelId",
                principalTable: "StockInViewModel",
                principalColumn: "Id");
        }
    }
}
