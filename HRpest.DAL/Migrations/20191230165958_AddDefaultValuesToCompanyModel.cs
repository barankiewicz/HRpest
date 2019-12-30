using Microsoft.EntityFrameworkCore.Migrations;

namespace HRpest.DAL.Migrations
{
    public partial class AddDefaultValuesToCompanyModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DefaultEmploymentType",
                table: "Companies",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DefaultNumberOfHoursWeekly",
                table: "Companies",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DefaultNumberOfRemoteHoursWeekly",
                table: "Companies",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DefaultEmploymentType",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "DefaultNumberOfHoursWeekly",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "DefaultNumberOfRemoteHoursWeekly",
                table: "Companies");
        }
    }
}
