using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Realization.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Animals",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    AnimalType = table.Column<string>(nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    Weight = table.Column<int>(nullable: false),
                    FedToTime = table.Column<DateTime>(nullable: false),
                    FoodType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Food",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    FoodType = table.Column<string>(nullable: true),
                    Calorific = table.Column<int>(nullable: false),
                    AssimilationMultiplierCoefficient = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Food", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "Id", "AnimalType", "BirthDate", "FedToTime", "FoodType", "Name", "Weight" },
                values: new object[,]
                {
                    { 1, "Mammal", new DateTime(2020, 4, 18, 19, 43, 19, 883, DateTimeKind.Local).AddTicks(3262), new DateTime(2020, 4, 19, 21, 43, 19, 886, DateTimeKind.Local).AddTicks(2490), "Meat", "Alex", 8000 },
                    { 2, "Bird", new DateTime(2020, 4, 16, 19, 43, 19, 886, DateTimeKind.Local).AddTicks(3955), new DateTime(2020, 4, 19, 19, 43, 19, 886, DateTimeKind.Local).AddTicks(3979), "Corn", "Red", 84 },
                    { 3, "Fish", new DateTime(2020, 4, 16, 19, 43, 19, 886, DateTimeKind.Local).AddTicks(4022), new DateTime(2020, 4, 19, 18, 43, 19, 886, DateTimeKind.Local).AddTicks(4025), "Fish feed", "Nemo", 42 }
                });

            migrationBuilder.InsertData(
                table: "Food",
                columns: new[] { "Id", "AssimilationMultiplierCoefficient", "Calorific", "FoodType", "Name", "Quantity" },
                values: new object[,]
                {
                    { 1, 6, 30000, "Meat", "15 kg of meat", 500 },
                    { 2, 2, 2000, "Corn", "1 kg of corn", 100 },
                    { 3, 3, 1000, "Fish feed", "1 kg of fish corn", 50 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Animals");

            migrationBuilder.DropTable(
                name: "Food");
        }
    }
}
