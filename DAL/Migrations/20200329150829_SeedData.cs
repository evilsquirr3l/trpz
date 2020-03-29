using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodTypes_Animals_AnimalId",
                table: "FoodTypes");

            migrationBuilder.DropIndex(
                name: "IX_FoodTypes_AnimalId",
                table: "FoodTypes");

            migrationBuilder.DropColumn(
                name: "AnimalId",
                table: "FoodTypes");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Food",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "AnimalType",
                table: "Animals",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "AnimalFoodType",
                columns: table => new
                {
                    AnimalId = table.Column<int>(nullable: false),
                    FoodTypeId = table.Column<int>(nullable: false)
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
                name: "IX_AnimalFoodType_FoodTypeId",
                table: "AnimalFoodType",
                column: "FoodTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnimalFoodType");

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

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Food");

            migrationBuilder.AddColumn<int>(
                name: "AnimalId",
                table: "FoodTypes",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AnimalType",
                table: "Animals",
                type: "int",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.CreateIndex(
                name: "IX_FoodTypes_AnimalId",
                table: "FoodTypes",
                column: "AnimalId");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodTypes_Animals_AnimalId",
                table: "FoodTypes",
                column: "AnimalId",
                principalTable: "Animals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
