using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EquinityCommerceApp.DataAccess.Migrations
{
    public partial class CreateEquinityDbWithCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    category_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "100, 1"),
                    category_name = table.Column<string>(type: "varchar(50)", nullable: false),
                    category_display_order = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    created_on = table.Column<DateTime>(type: "date", nullable: false, defaultValue: new DateTime(2022, 9, 8, 11, 31, 14, 674, DateTimeKind.Local).AddTicks(1112))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.category_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "categories");
        }
    }
}
