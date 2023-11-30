using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatabaseLayer.Migrations
{
    /// <inheritdoc />
    public partial class initialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "shops",
                columns: table => new
                {
                    shop_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    shop_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    shop_domain_name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shops", x => x.shop_id);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    product_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    shop_id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    shop_id1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.product_id);
                    table.ForeignKey(
                        name: "FK_products_shops_shop_id1",
                        column: x => x.shop_id1,
                        principalTable: "shops",
                        principalColumn: "shop_id");
                });

            migrationBuilder.CreateTable(
                name: "URLs",
                columns: table => new
                {
                    url_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    url_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    shop_id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    shop_id1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_URLs", x => x.url_id);
                    table.ForeignKey(
                        name: "FK_URLs_shops_shop_id1",
                        column: x => x.shop_id1,
                        principalTable: "shops",
                        principalColumn: "shop_id");
                });

            migrationBuilder.CreateTable(
                name: "ActionModel",
                columns: table => new
                {
                    action_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    action_name = table.Column<int>(type: "int", nullable: false),
                    ShopModelshop_id = table.Column<int>(type: "int", nullable: true),
                    URLModelurl_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActionModel", x => x.action_id);
                    table.ForeignKey(
                        name: "FK_ActionModel_URLs_URLModelurl_id",
                        column: x => x.URLModelurl_id,
                        principalTable: "URLs",
                        principalColumn: "url_id");
                    table.ForeignKey(
                        name: "FK_ActionModel_shops_ShopModelshop_id",
                        column: x => x.ShopModelshop_id,
                        principalTable: "shops",
                        principalColumn: "shop_id");
                });

            migrationBuilder.CreateTable(
                name: "XPathModel",
                columns: table => new
                {
                    xpath_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    xpath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    property_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    atribute = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShopModelshop_id = table.Column<int>(type: "int", nullable: true),
                    URLModelurl_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_XPathModel", x => x.xpath_id);
                    table.ForeignKey(
                        name: "FK_XPathModel_URLs_URLModelurl_id",
                        column: x => x.URLModelurl_id,
                        principalTable: "URLs",
                        principalColumn: "url_id");
                    table.ForeignKey(
                        name: "FK_XPathModel_shops_ShopModelshop_id",
                        column: x => x.ShopModelshop_id,
                        principalTable: "shops",
                        principalColumn: "shop_id");
                });

            migrationBuilder.CreateTable(
                name: "ActionDataModel",
                columns: table => new
                {
                    action_data_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    action_id = table.Column<int>(type: "int", nullable: false),
                    action_id1 = table.Column<int>(type: "int", nullable: false),
                    action_data = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActionDataModel", x => x.action_data_id);
                    table.ForeignKey(
                        name: "FK_ActionDataModel_ActionModel_action_id1",
                        column: x => x.action_id1,
                        principalTable: "ActionModel",
                        principalColumn: "action_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActionDataModel_action_id1",
                table: "ActionDataModel",
                column: "action_id1");

            migrationBuilder.CreateIndex(
                name: "IX_ActionModel_ShopModelshop_id",
                table: "ActionModel",
                column: "ShopModelshop_id");

            migrationBuilder.CreateIndex(
                name: "IX_ActionModel_URLModelurl_id",
                table: "ActionModel",
                column: "URLModelurl_id");

            migrationBuilder.CreateIndex(
                name: "IX_products_shop_id1",
                table: "products",
                column: "shop_id1");

            migrationBuilder.CreateIndex(
                name: "IX_URLs_shop_id1",
                table: "URLs",
                column: "shop_id1");

            migrationBuilder.CreateIndex(
                name: "IX_XPathModel_ShopModelshop_id",
                table: "XPathModel",
                column: "ShopModelshop_id");

            migrationBuilder.CreateIndex(
                name: "IX_XPathModel_URLModelurl_id",
                table: "XPathModel",
                column: "URLModelurl_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActionDataModel");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "XPathModel");

            migrationBuilder.DropTable(
                name: "ActionModel");

            migrationBuilder.DropTable(
                name: "URLs");

            migrationBuilder.DropTable(
                name: "shops");
        }
    }
}
