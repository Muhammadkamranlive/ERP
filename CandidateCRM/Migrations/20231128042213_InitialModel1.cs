using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CandidateCRM.Migrations
{
    public partial class InitialModel1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Progress",
                table: "GENERALTASKs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Progress",
                table: "GENERALTASKs");
        }
    }
}
