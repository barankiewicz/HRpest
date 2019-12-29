using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HRpest.DAL.Migrations
{
    public partial class AddEditedOnFieldToCompany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "EditedOn",
                table: "Companies",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EditedOn",
                table: "Companies");
        }
    }
}
