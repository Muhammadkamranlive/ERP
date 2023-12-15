using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CandidateCRM.Migrations
{
    public partial class InitialModel3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ReceiverId",
                table: "Attachments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SenderId",
                table: "Attachments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Attachments",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReceiverId",
                table: "Attachments");

            migrationBuilder.DropColumn(
                name: "SenderId",
                table: "Attachments");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Attachments");
        }
    }
}
