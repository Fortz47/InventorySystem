using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventorySystem.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedStockMovementModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_WarehouseProduct_WarehouseProductId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Warehouse_WarehouseProduct_WarehouseProductId",
                table: "Warehouse");

            migrationBuilder.DropIndex(
                name: "IX_Warehouse_WarehouseProductId",
                table: "Warehouse");

            migrationBuilder.DropIndex(
                name: "IX_Products_WarehouseProductId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "WarehouseProductId",
                table: "Warehouse");

            migrationBuilder.DropColumn(
                name: "WarehouseProductId",
                table: "Products");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WarehouseProductId",
                table: "Warehouse",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WarehouseProductId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Warehouse_WarehouseProductId",
                table: "Warehouse",
                column: "WarehouseProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_WarehouseProductId",
                table: "Products",
                column: "WarehouseProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_WarehouseProduct_WarehouseProductId",
                table: "Products",
                column: "WarehouseProductId",
                principalTable: "WarehouseProduct",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Warehouse_WarehouseProduct_WarehouseProductId",
                table: "Warehouse",
                column: "WarehouseProductId",
                principalTable: "WarehouseProduct",
                principalColumn: "Id");
        }
    }
}
