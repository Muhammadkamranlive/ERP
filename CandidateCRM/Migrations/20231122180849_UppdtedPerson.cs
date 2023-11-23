using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CandidateCRM.Migrations
{
    public partial class UppdtedPerson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "userId",
                table: "Personals",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "SpouseName",
                table: "Personals",
                newName: "ZipCode");

            migrationBuilder.RenameColumn(
                name: "MiddleName",
                table: "Personals",
                newName: "TypeOfEmployment");

            migrationBuilder.RenameColumn(
                name: "MaritalStatus",
                table: "Personals",
                newName: "State");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Personals",
                newName: "Specialty");

            migrationBuilder.RenameColumn(
                name: "HomeAddress",
                table: "Personals",
                newName: "RetypePassword");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Personals",
                newName: "Profession");

            migrationBuilder.RenameColumn(
                name: "DriversLicenseState",
                table: "Personals",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "DriversLicenseNumber",
                table: "Personals",
                newName: "LocationPreference");

            migrationBuilder.AddColumn<bool>(
                name: "AcceptTermsAndConditions",
                table: "Personals",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Personals",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BestTimeToContact",
                table: "Personals",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BusinessEmail",
                table: "Personals",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BusinessPhone",
                table: "Personals",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Personals",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ComputerChartingSystemExperience",
                table: "Personals",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Personals",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DesiredTravelArea",
                table: "Personals",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "HowDidYouHearAboutUs",
                table: "Personals",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "YearsOfExperience",
                table: "Personals",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AcceptTermsAndConditions",
                table: "Personals");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Personals");

            migrationBuilder.DropColumn(
                name: "BestTimeToContact",
                table: "Personals");

            migrationBuilder.DropColumn(
                name: "BusinessEmail",
                table: "Personals");

            migrationBuilder.DropColumn(
                name: "BusinessPhone",
                table: "Personals");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Personals");

            migrationBuilder.DropColumn(
                name: "ComputerChartingSystemExperience",
                table: "Personals");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Personals");

            migrationBuilder.DropColumn(
                name: "DesiredTravelArea",
                table: "Personals");

            migrationBuilder.DropColumn(
                name: "HowDidYouHearAboutUs",
                table: "Personals");

            migrationBuilder.DropColumn(
                name: "YearsOfExperience",
                table: "Personals");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Personals",
                newName: "userId");

            migrationBuilder.RenameColumn(
                name: "ZipCode",
                table: "Personals",
                newName: "SpouseName");

            migrationBuilder.RenameColumn(
                name: "TypeOfEmployment",
                table: "Personals",
                newName: "MiddleName");

            migrationBuilder.RenameColumn(
                name: "State",
                table: "Personals",
                newName: "MaritalStatus");

            migrationBuilder.RenameColumn(
                name: "Specialty",
                table: "Personals",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "RetypePassword",
                table: "Personals",
                newName: "HomeAddress");

            migrationBuilder.RenameColumn(
                name: "Profession",
                table: "Personals",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Personals",
                newName: "DriversLicenseState");

            migrationBuilder.RenameColumn(
                name: "LocationPreference",
                table: "Personals",
                newName: "DriversLicenseNumber");
        }
    }
}
