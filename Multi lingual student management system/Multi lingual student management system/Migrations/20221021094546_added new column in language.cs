using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Multi_lingual_student_management_system.Migrations
{
    public partial class addednewcolumninlanguage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDefault",
                table: "Languages",
                type: "bit",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDefault",
                table: "Languages");
        }
    }
}
