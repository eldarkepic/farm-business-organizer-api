using Microsoft.EntityFrameworkCore.Migrations;

namespace farma_api.Migrations
{
    public partial class productUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Partners_Company_CompanyID",
                table: "Partners");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Warehouses_WarehouseId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "WarehouseId",
                table: "Products",
                newName: "CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_WarehouseId",
                table: "Products",
                newName: "IX_Products_CompanyId");

            migrationBuilder.RenameColumn(
                name: "CompanyID",
                table: "Partners",
                newName: "CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_Partners_CompanyID",
                table: "Partners",
                newName: "IX_Partners_CompanyId");

            migrationBuilder.AddColumn<int>(
                name: "WarehouseId",
                table: "ProductVariations",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CompanyId",
                table: "Partners",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductVariations_WarehouseId",
                table: "ProductVariations",
                column: "WarehouseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Partners_Company_CompanyId",
                table: "Partners",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "CompanyID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Company_CompanyId",
                table: "Products",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "CompanyID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductVariations_Warehouses_WarehouseId",
                table: "ProductVariations",
                column: "WarehouseId",
                principalTable: "Warehouses",
                principalColumn: "WarehouseId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Partners_Company_CompanyId",
                table: "Partners");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Company_CompanyId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductVariations_Warehouses_WarehouseId",
                table: "ProductVariations");

            migrationBuilder.DropIndex(
                name: "IX_ProductVariations_WarehouseId",
                table: "ProductVariations");

            migrationBuilder.DropColumn(
                name: "WarehouseId",
                table: "ProductVariations");

            migrationBuilder.RenameColumn(
                name: "CompanyId",
                table: "Products",
                newName: "WarehouseId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_CompanyId",
                table: "Products",
                newName: "IX_Products_WarehouseId");

            migrationBuilder.RenameColumn(
                name: "CompanyId",
                table: "Partners",
                newName: "CompanyID");

            migrationBuilder.RenameIndex(
                name: "IX_Partners_CompanyId",
                table: "Partners",
                newName: "IX_Partners_CompanyID");

            migrationBuilder.AlterColumn<int>(
                name: "CompanyID",
                table: "Partners",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Partners_Company_CompanyID",
                table: "Partners",
                column: "CompanyID",
                principalTable: "Company",
                principalColumn: "CompanyID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Warehouses_WarehouseId",
                table: "Products",
                column: "WarehouseId",
                principalTable: "Warehouses",
                principalColumn: "WarehouseId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
