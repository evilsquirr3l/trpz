using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace dal.Migrations
{
    public partial class RemoveFoodTypeId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FoodTypeId",
                table: "Food");

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "FedToTime" },
                values: new object[] { new DateTime(2020, 4, 3, 18, 33, 2, 361, DateTimeKind.Local).AddTicks(1609), new DateTime(2020, 4, 4, 20, 33, 2, 364, DateTimeKind.Local).AddTicks(3588) });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BirthDate", "FedToTime" },
                values: new object[] { new DateTime(2020, 4, 1, 18, 33, 2, 364, DateTimeKind.Local).AddTicks(5148), new DateTime(2020, 4, 4, 18, 33, 2, 364, DateTimeKind.Local).AddTicks(5173) });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BirthDate", "FedToTime" },
                values: new object[] { new DateTime(2020, 4, 1, 18, 33, 2, 364, DateTimeKind.Local).AddTicks(5216), new DateTime(2020, 4, 4, 17, 33, 2, 364, DateTimeKind.Local).AddTicks(5220) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FoodTypeId",
                table: "Food",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "FedToTime" },
                values: new object[] { new DateTime(2020, 3, 28, 21, 17, 36, 662, DateTimeKind.Local).AddTicks(5627), new DateTime(2020, 3, 29, 23, 17, 36, 665, DateTimeKind.Local).AddTicks(2608) });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BirthDate", "FedToTime" },
                values: new object[] { new DateTime(2020, 3, 26, 21, 17, 36, 665, DateTimeKind.Local).AddTicks(4128), new DateTime(2020, 3, 29, 21, 17, 36, 665, DateTimeKind.Local).AddTicks(4153) });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BirthDate", "FedToTime" },
                values: new object[] { new DateTime(2020, 3, 26, 21, 17, 36, 665, DateTimeKind.Local).AddTicks(4198), new DateTime(2020, 3, 29, 20, 17, 36, 665, DateTimeKind.Local).AddTicks(4202) });
        }
    }
}
