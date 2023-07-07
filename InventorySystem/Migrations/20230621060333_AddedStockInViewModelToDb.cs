using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventorySystem.Migrations
{
    /// <inheritdoc />
    public partial class AddedStockInViewModelToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "StockInViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockInViewModel", x => x.Id);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_StockInViewModel_StockInViewModelId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Warehouse_StockInViewModel_StockInViewModelId",
                table: "Warehouse");

            migrationBuilder.DropTable(
                name: "StockInViewModel");

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
        }
    }
}
