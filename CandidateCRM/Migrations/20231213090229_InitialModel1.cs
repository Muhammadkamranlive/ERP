using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CandidateCRM.Migrations
{
    public partial class InitialModel1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BusinessPhone",
                table: "Personals");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BusinessPhone",
                table: "Personals",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
