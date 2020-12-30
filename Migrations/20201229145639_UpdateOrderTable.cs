using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Commerce.Migrations
{
    public partial class UpdateOrderTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Value",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Orders",
                newName: "Status");

            migrationBuilder.AddColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "OrderNumber",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropColumn(
                name: "OrderDate",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderNumber",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Orders",
                newName: "Description");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Value",
                table: "Orders",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
