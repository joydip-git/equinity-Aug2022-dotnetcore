using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EquinityCommerceApp.DataAccess.Migrations
{
    public partial class CreateProductTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "created_on",
                table: "categories",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 13, 10, 7, 50, 926, DateTimeKind.Local).AddTicks(8634),
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldDefaultValue: new DateTime(2022, 9, 12, 11, 7, 43, 319, DateTimeKind.Local).AddTicks(8532));

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    product_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "100, 1"),
                    product_name = table.Column<string>(type: "varchar(50)", nullable: false),
                    product_author = table.Column<string>(type: "varchar(50)", nullable: false),
                    product_isbn = table.Column<string>(type: "varchar(10)", nullable: false),
                    product_description = table.Column<string>(type: "varchar(max)", nullable: true),
                    product_list_price = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0.0m),
                    product_price = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0.0m),
                    product_fifty_price = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0.0m),
                    product_hundred_price = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0.0m),
                    product_image_url = table.Column<string>(type: "varchar(max)", nullable: true),
                    category_id = table.Column<int>(type: "int", nullable: true),
                    cover_type_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.product_id);
                    table.ForeignKey(
                        name: "FK_products_categories_category_id",
                        column: x => x.category_id,
                        principalTable: "categories",
                        principalColumn: "category_id");
                    table.ForeignKey(
                        name: "FK_products_covertypes_cover_type_id",
                        column: x => x.cover_type_id,
                        principalTable: "covertypes",
                        principalColumn: "covertype_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_products_category_id",
                table: "products",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_products_cover_type_id",
                table: "products",
                column: "cover_type_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_on",
                table: "categories",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 12, 11, 7, 43, 319, DateTimeKind.Local).AddTicks(8532),
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldDefaultValue: new DateTime(2022, 9, 13, 10, 7, 50, 926, DateTimeKind.Local).AddTicks(8634));
        }
    }
}
