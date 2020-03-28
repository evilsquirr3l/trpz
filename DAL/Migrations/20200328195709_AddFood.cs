using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace dal.Migrations
{
    public partial class AddFood : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Animals");

            migrationBuilder.AddColumn<int>(
                name: "AnimalType",
                table: "Animals",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                table: "Animals",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Weight",
                table: "Animals",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnimalType",
                table: "Animals");

            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "Animals");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "Animals");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Animals",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
