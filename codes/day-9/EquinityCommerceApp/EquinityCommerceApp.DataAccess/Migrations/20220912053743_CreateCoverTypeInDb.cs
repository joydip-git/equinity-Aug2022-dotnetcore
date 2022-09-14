using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EquinityCommerceApp.DataAccess.Migrations
{
    public partial class CreateCoverTypeInDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "created_on",
                table: "categories",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 12, 11, 7, 43, 319, DateTimeKind.Local).AddTicks(8532),
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldDefaultValue: new DateTime(2022, 9, 8, 11, 31, 14, 674, DateTimeKind.Local).AddTicks(1112));

            migrationBuilder.CreateTable(
                name: "covertypes",
                columns: table => new
                {
                    covertype_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "100, 1"),
                    covertype_name = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_covertypes", x => x.covertype_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "covertypes");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_on",
                table: "categories",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 8, 11, 31, 14, 674, DateTimeKind.Local).AddTicks(1112),
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldDefaultValue: new DateTime(2022, 9, 12, 11, 7, 43, 319, DateTimeKind.Local).AddTicks(8532));
        }
    }
}
