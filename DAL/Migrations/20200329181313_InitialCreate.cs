using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace dal.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "Animals",
                table => new
                {
                    Id = table.Column<int>()
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    AnimalType = table.Column<string>(nullable: true),
                    BirthDate = table.Column<DateTime>(),
                    Weight = table.Column<int>(),
                    FedToTime = table.Column<DateTime>(),
                    FoodType = table.Column<string>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_Animals", x => x.Id); });

            migrationBuilder.CreateTable(
                "Food",
                table => new
                {
                    Id = table.Column<int>()
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    FoodTypeId = table.Column<int>(),
                    FoodType = table.Column<string>(nullable: true),
                    Calorific = table.Column<int>(),
                    AssimilationMultiplierCoefficient = table.Column<int>(),
                    Quantity = table.Column<int>()
                },
                constraints: table => { table.PrimaryKey("PK_Food", x => x.Id); });

            migrationBuilder.CreateTable(
                "FoodTypes",
                table => new
                {
                    Id = table.Column<int>()
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeOfFood = table.Column<string>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_FoodTypes", x => x.Id); });

            migrationBuilder.InsertData(
                "Animals",
                new[] {"Id", "AnimalType", "BirthDate", "FedToTime", "FoodType", "Name", "Weight"},
                new object[,]
                {
                    {
                        1, "Mammal", new DateTime(2020, 3, 28, 21, 13, 13, 163, DateTimeKind.Local).AddTicks(2900),
                        new DateTime(2020, 3, 29, 23, 13, 13, 166, DateTimeKind.Local).AddTicks(1562), "Meat", "Alex",
                        190
                    },
                    {
                        2, "Bird", new DateTime(2020, 3, 26, 21, 13, 13, 166, DateTimeKind.Local).AddTicks(3154),
                        new DateTime(2020, 3, 29, 21, 13, 13, 166, DateTimeKind.Local).AddTicks(3181), "Corn", "Red", 2
                    },
                    {
                        3, "Fish", new DateTime(2020, 3, 26, 21, 13, 13, 166, DateTimeKind.Local).AddTicks(3232),
                        new DateTime(2020, 3, 29, 20, 13, 13, 166, DateTimeKind.Local).AddTicks(3236), "Fish feed",
                        "Nemo", 1
                    }
                });

            migrationBuilder.InsertData(
                "Food",
                new[]
                {
                    "Id", "AssimilationMultiplierCoefficient", "Calorific", "FoodType", "FoodTypeId", "Name", "Quantity"
                },
                new object[,]
                {
                    {1, 1, 3000, "Meat", 0, "5 kg of meat", 500},
                    {2, 2, 2000, "Corn", 0, "1 kg of corn", 100},
                    {3, 3, 1000, "Fish feed", 0, "1 kg of fish corn", 50}
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "Animals");

            migrationBuilder.DropTable(
                "Food");

            migrationBuilder.DropTable(
                "FoodTypes");
        }
    }
}