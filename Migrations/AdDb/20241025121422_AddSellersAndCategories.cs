using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace radlab4._0.Migrations.AdDb
{
    /// <inheritdoc />
    public partial class AddSellersAndCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ads_Category_CategoryId",
                table: "Ads");

            migrationBuilder.DropForeignKey(
                name: "FK_Ads_Seller_SellerId",
                table: "Ads");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Seller",
                table: "Seller");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Category",
                table: "Category");

            migrationBuilder.RenameTable(
                name: "Seller",
                newName: "Sellers");

            migrationBuilder.RenameTable(
                name: "Category",
                newName: "Categories");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sellers",
                table: "Sellers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ads_Categories_CategoryId",
                table: "Ads",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ads_Sellers_SellerId",
                table: "Ads",
                column: "SellerId",
                principalTable: "Sellers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ads_Categories_CategoryId",
                table: "Ads");

            migrationBuilder.DropForeignKey(
                name: "FK_Ads_Sellers_SellerId",
                table: "Ads");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sellers",
                table: "Sellers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.RenameTable(
                name: "Sellers",
                newName: "Seller");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "Category");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Seller",
                table: "Seller",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category",
                table: "Category",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ads_Category_CategoryId",
                table: "Ads",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ads_Seller_SellerId",
                table: "Ads",
                column: "SellerId",
                principalTable: "Seller",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
