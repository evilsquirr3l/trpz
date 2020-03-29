using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace dal.Migrations
{
    public partial class DeleteFoodTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "FoodTypes");

            migrationBuilder.UpdateData(
                "Animals",
                "Id",
                1,
                new[] {"BirthDate", "FedToTime"},
                new object[]
                {
                    new DateTime(2020, 3, 28, 21, 17, 36, 662, DateTimeKind.Local).AddTicks(5627),
                    new DateTime(2020, 3, 29, 23, 17, 36, 665, DateTimeKind.Local).AddTicks(2608)
                });

            migrationBuilder.UpdateData(
                "Animals",
                "Id",
                2,
                new[] {"BirthDate", "FedToTime"},
                new object[]
                {
                    new DateTime(2020, 3, 26, 21, 17, 36, 665, DateTimeKind.Local).AddTicks(4128),
                    new DateTime(2020, 3, 29, 21, 17, 36, 665, DateTimeKind.Local).AddTicks(4153)
                });

            migrationBuilder.UpdateData(
                "Animals",
                "Id",
                3,
                new[] {"BirthDate", "FedToTime"},
                new object[]
                {
                    new DateTime(2020, 3, 26, 21, 17, 36, 665, DateTimeKind.Local).AddTicks(4198),
                    new DateTime(2020, 3, 29, 20, 17, 36, 665, DateTimeKind.Local).AddTicks(4202)
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "FoodTypes",
                table => new
                {
                    Id = table.Column<int>("int")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeOfFood = table.Column<string>("nvarchar(max)", nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_FoodTypes", x => x.Id); });

            migrationBuilder.UpdateData(
                "Animals",
                "Id",
                1,
                new[] {"BirthDate", "FedToTime"},
                new object[]
                {
                    new DateTime(2020, 3, 28, 21, 13, 13, 163, DateTimeKind.Local).AddTicks(2900),
                    new DateTime(2020, 3, 29, 23, 13, 13, 166, DateTimeKind.Local).AddTicks(1562)
                });

            migrationBuilder.UpdateData(
                "Animals",
                "Id",
                2,
                new[] {"BirthDate", "FedToTime"},
                new object[]
                {
                    new DateTime(2020, 3, 26, 21, 13, 13, 166, DateTimeKind.Local).AddTicks(3154),
                    new DateTime(2020, 3, 29, 21, 13, 13, 166, DateTimeKind.Local).AddTicks(3181)
                });

            migrationBuilder.UpdateData(
                "Animals",
                "Id",
                3,
                new[] {"BirthDate", "FedToTime"},
                new object[]
                {
                    new DateTime(2020, 3, 26, 21, 13, 13, 166, DateTimeKind.Local).AddTicks(3232),
                    new DateTime(2020, 3, 29, 20, 13, 13, 166, DateTimeKind.Local).AddTicks(3236)
                });
        }
    }
}