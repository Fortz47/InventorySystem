using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventorySystem.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedStockInViewModelAgain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockInViewModel_Products_ProductsId",
                table: "StockInViewModel");

            migrationBuilder.DropForeignKey(
                name: "FK_StockInViewModel_Warehouse_WarehouseId",
                table: "StockInViewModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StockInViewModel",
                table: "StockInViewModel");

            migrationBuilder.RenameTable(
                name: "StockInViewModel",
                newName: "stockInViewModel");

            migrationBuilder.RenameIndex(
                name: "IX_StockInViewModel_WarehouseId",
                table: "stockInViewModel",
                newName: "IX_stockInViewModel_WarehouseId");

            migrationBuilder.RenameIndex(
                name: "IX_StockInViewModel_ProductsId",
                table: "stockInViewModel",
                newName: "IX_stockInViewModel_ProductsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_stockInViewModel",
                table: "stockInViewModel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_stockInViewModel_Products_ProductsId",
                table: "stockInViewModel",
                column: "ProductsId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_stockInViewModel_Warehouse_WarehouseId",
                table: "stockInViewModel",
                column: "WarehouseId",
                principalTable: "Warehouse",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_stockInViewModel_Products_ProductsId",
                table: "stockInViewModel");

            migrationBuilder.DropForeignKey(
                name: "FK_stockInViewModel_Warehouse_WarehouseId",
                table: "stockInViewModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_stockInViewModel",
                table: "stockInViewModel");

            migrationBuilder.RenameTable(
                name: "stockInViewModel",
                newName: "StockInViewModel");

            migrationBuilder.RenameIndex(
                name: "IX_stockInViewModel_WarehouseId",
                table: "StockInViewModel",
                newName: "IX_StockInViewModel_WarehouseId");

            migrationBuilder.RenameIndex(
                name: "IX_stockInViewModel_ProductsId",
                table: "StockInViewModel",
                newName: "IX_StockInViewModel_ProductsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StockInViewModel",
                table: "StockInViewModel",
                column: "Id");

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
    }
}
