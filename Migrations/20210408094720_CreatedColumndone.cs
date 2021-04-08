using Microsoft.EntityFrameworkCore.Migrations;

namespace ToDoWebAPI.Migrations
{
    public partial class CreatedColumndone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "done",
                table: "list_items",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "done",
                table: "list_items");
        }
    }
}
