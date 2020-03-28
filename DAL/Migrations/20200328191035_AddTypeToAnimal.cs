using Microsoft.EntityFrameworkCore.Migrations;

namespace dal.Migrations
{
    public partial class AddTypeToAnimal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Animals",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Animals");
        }
    }
}
