using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Portfel.Migrations
{
    public partial class init3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Group",
                table: "Transactions",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "date",
                table: "Transactions",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Group",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "date",
                table: "Transactions");
        }
    }
}
