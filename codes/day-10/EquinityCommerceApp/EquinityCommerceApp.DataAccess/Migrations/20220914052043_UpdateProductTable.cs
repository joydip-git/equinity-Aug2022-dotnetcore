using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EquinityCommerceApp.DataAccess.Migrations
{
    public partial class UpdateProductTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "created_on",
                table: "categories",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 14, 10, 50, 43, 418, DateTimeKind.Local).AddTicks(7222),
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldDefaultValue: new DateTime(2022, 9, 13, 10, 7, 50, 926, DateTimeKind.Local).AddTicks(8634));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "created_on",
                table: "categories",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 13, 10, 7, 50, 926, DateTimeKind.Local).AddTicks(8634),
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldDefaultValue: new DateTime(2022, 9, 14, 10, 50, 43, 418, DateTimeKind.Local).AddTicks(7222));
        }
    }
}
