using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatabaseLayer.Migrations
{
    /// <inheritdoc />
    public partial class JustInCaseMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductNumericDataModel_products_product_id1",
                table: "ProductNumericDataModel");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductTextDataModel_products_product_id1",
                table: "ProductTextDataModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductTextDataModel",
                table: "ProductTextDataModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductNumericDataModel",
                table: "ProductNumericDataModel");

            migrationBuilder.RenameTable(
                name: "ProductTextDataModel",
                newName: "productsTextData");

            migrationBuilder.RenameTable(
                name: "ProductNumericDataModel",
                newName: "productsNumericData");

            migrationBuilder.RenameIndex(
                name: "IX_ProductTextDataModel_product_id1",
                table: "productsTextData",
                newName: "IX_productsTextData_product_id1");

            migrationBuilder.RenameIndex(
                name: "IX_ProductNumericDataModel_product_id1",
                table: "productsNumericData",
                newName: "IX_productsNumericData_product_id1");

            migrationBuilder.AlterColumn<int>(
                name: "shop_id",
                table: "URLs",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "multipaged",
                table: "URLs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "pageProperty",
                table: "URLs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "pageProperty",
                table: "shops",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_productsTextData",
                table: "productsTextData",
                column: "product_data_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_productsNumericData",
                table: "productsNumericData",
                column: "product_data_id");

            migrationBuilder.AddForeignKey(
                name: "FK_productsNumericData_products_product_id1",
                table: "productsNumericData",
                column: "product_id1",
                principalTable: "products",
                principalColumn: "product_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_productsTextData_products_product_id1",
                table: "productsTextData",
                column: "product_id1",
                principalTable: "products",
                principalColumn: "product_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_productsNumericData_products_product_id1",
                table: "productsNumericData");

            migrationBuilder.DropForeignKey(
                name: "FK_productsTextData_products_product_id1",
                table: "productsTextData");

            migrationBuilder.DropPrimaryKey(
                name: "PK_productsTextData",
                table: "productsTextData");

            migrationBuilder.DropPrimaryKey(
                name: "PK_productsNumericData",
                table: "productsNumericData");

            migrationBuilder.DropColumn(
                name: "multipaged",
                table: "URLs");

            migrationBuilder.DropColumn(
                name: "pageProperty",
                table: "URLs");

            migrationBuilder.DropColumn(
                name: "pageProperty",
                table: "shops");

            migrationBuilder.RenameTable(
                name: "productsTextData",
                newName: "ProductTextDataModel");

            migrationBuilder.RenameTable(
                name: "productsNumericData",
                newName: "ProductNumericDataModel");

            migrationBuilder.RenameIndex(
                name: "IX_productsTextData_product_id1",
                table: "ProductTextDataModel",
                newName: "IX_ProductTextDataModel_product_id1");

            migrationBuilder.RenameIndex(
                name: "IX_productsNumericData_product_id1",
                table: "ProductNumericDataModel",
                newName: "IX_ProductNumericDataModel_product_id1");

            migrationBuilder.AlterColumn<string>(
                name: "shop_id",
                table: "URLs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductTextDataModel",
                table: "ProductTextDataModel",
                column: "product_data_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductNumericDataModel",
                table: "ProductNumericDataModel",
                column: "product_data_id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductNumericDataModel_products_product_id1",
                table: "ProductNumericDataModel",
                column: "product_id1",
                principalTable: "products",
                principalColumn: "product_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductTextDataModel_products_product_id1",
                table: "ProductTextDataModel",
                column: "product_id1",
                principalTable: "products",
                principalColumn: "product_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
