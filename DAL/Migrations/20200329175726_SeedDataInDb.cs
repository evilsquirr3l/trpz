using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class SeedDataInDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Food_FoodTypes_FoodTypeId",
                table: "Food");

            migrationBuilder.DropTable(
                name: "AnimalFoodType");

            migrationBuilder.DropIndex(
                name: "IX_Food_FoodTypeId",
                table: "Food");

            migrationBuilder.DeleteData(
                table: "FoodTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "FoodTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "FoodTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AddColumn<string>(
                name: "FoodType",
                table: "Food",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FoodType",
                table: "Animals",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "Id", "AnimalType", "BirthDate", "FedToTime", "FoodType", "Name", "Weight" },
                values: new object[,]
                {
                    { 1, "Mammals", new DateTime(2020, 3, 28, 20, 57, 25, 969, DateTimeKind.Local).AddTicks(8650), new DateTime(2020, 3, 29, 22, 57, 25, 972, DateTimeKind.Local).AddTicks(7950), "Meat", "Alex", 190 },
                    { 2, "Bird", new DateTime(2020, 3, 26, 20, 57, 25, 972, DateTimeKind.Local).AddTicks(9532), new DateTime(2020, 3, 29, 20, 57, 25, 972, DateTimeKind.Local).AddTicks(9559), "Corn", "Red", 2 },
                    { 3, "Fish", new DateTime(2020, 3, 26, 20, 57, 25, 972, DateTimeKind.Local).AddTicks(9605), new DateTime(2020, 3, 29, 19, 57, 25, 972, DateTimeKind.Local).AddTicks(9610), "Fish feed", "Nemo", 1 }
                });

            migrationBuilder.InsertData(
                table: "Food",
                columns: new[] { "Id", "AssimilationMultiplierCoefficient", "Calorific", "FoodType", "FoodTypeId", "Name", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, 3000, "Meat", 0, "5 kg of meat", 500 },
                    { 2, 2, 2000, "Corn", 0, "1 kg of corn", 100 },
                    { 3, 3, 1000, "Fish feed", 0, "1 kg of fish corn", 50 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "FoodType",
                table: "Food");

            migrationBuilder.DropColumn(
                name: "FoodType",
                table: "Animals");

            migrationBuilder.CreateTable(
                name: "AnimalFoodType",
                columns: table => new
                {
                    AnimalId = table.Column<int>(type: "int", nullable: false),
                    FoodTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimalFoodType", x => new { x.AnimalId, x.FoodTypeId });
                    table.ForeignKey(
                        name: "FK_AnimalFoodType_Animals_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Animals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnimalFoodType_FoodTypes_FoodTypeId",
                        column: x => x.FoodTypeId,
                        principalTable: "FoodTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "FoodTypes",
                columns: new[] { "Id", "TypeOfFood" },
                values: new object[] { 1, "Meat" });

            migrationBuilder.InsertData(
                table: "FoodTypes",
                columns: new[] { "Id", "TypeOfFood" },
                values: new object[] { 2, "Corn" });

            migrationBuilder.InsertData(
                table: "FoodTypes",
                columns: new[] { "Id", "TypeOfFood" },
                values: new object[] { 3, "Fish feed" });

            migrationBuilder.InsertData(
                table: "AnimalFoodType",
                columns: new[] { "AnimalId", "FoodTypeId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 2 },
                    { 3, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Food_FoodTypeId",
                table: "Food",
                column: "FoodTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AnimalFoodType_FoodTypeId",
                table: "AnimalFoodType",
                column: "FoodTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Food_FoodTypes_FoodTypeId",
                table: "Food",
                column: "FoodTypeId",
                principalTable: "FoodTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
