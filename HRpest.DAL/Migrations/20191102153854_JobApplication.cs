using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HRpest.DAL.Migrations
{
    public partial class JobApplication : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "JobOffers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "JobOffers",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "JobOffers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "EndedOn",
                table: "JobOffers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_JobOffers_CreatedById",
                table: "JobOffers",
                column: "CreatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_JobOffers_Users_CreatedById",
                table: "JobOffers",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobOffers_Users_CreatedById",
                table: "JobOffers");

            migrationBuilder.DropIndex(
                name: "IX_JobOffers_CreatedById",
                table: "JobOffers");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "JobOffers");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "JobOffers");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "JobOffers");

            migrationBuilder.DropColumn(
                name: "EndedOn",
                table: "JobOffers");
        }
    }
}
