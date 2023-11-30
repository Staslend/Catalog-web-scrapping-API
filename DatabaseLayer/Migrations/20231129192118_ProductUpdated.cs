using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatabaseLayer.Migrations
{
    /// <inheritdoc />
    public partial class ProductUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductNumericDataModel",
                columns: table => new
                {
                    product_data_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    product_id = table.Column<int>(type: "int", nullable: false),
                    product_id1 = table.Column<int>(type: "int", nullable: false),
                    product_property_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    property_value = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductNumericDataModel", x => x.product_data_id);
                    table.ForeignKey(
                        name: "FK_ProductNumericDataModel_products_product_id1",
                        column: x => x.product_id1,
                        principalTable: "products",
                        principalColumn: "product_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductTextDataModel",
                columns: table => new
                {
                    product_data_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    product_id = table.Column<int>(type: "int", nullable: false),
                    product_id1 = table.Column<int>(type: "int", nullable: false),
                    product_property_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    property_value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTextDataModel", x => x.product_data_id);
                    table.ForeignKey(
                        name: "FK_ProductTextDataModel_products_product_id1",
                        column: x => x.product_id1,
                        principalTable: "products",
                        principalColumn: "product_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductNumericDataModel_product_id1",
                table: "ProductNumericDataModel",
                column: "product_id1");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTextDataModel_product_id1",
                table: "ProductTextDataModel",
                column: "product_id1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductNumericDataModel");

            migrationBuilder.DropTable(
                name: "ProductTextDataModel");
        }
    }
}
