using Microsoft.EntityFrameworkCore.Migrations;

namespace HRpest.DAL.Migrations
{
    public partial class ChangeCompanyToCreatedFor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobOffers_Companies_CompanyId",
                table: "JobOffers");

            migrationBuilder.DropIndex(
                name: "IX_JobOffers_CompanyId",
                table: "JobOffers");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "JobOffers");

            migrationBuilder.AddColumn<int>(
                name: "CreatedForId",
                table: "JobOffers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_JobOffers_CreatedForId",
                table: "JobOffers",
                column: "CreatedForId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobOffers_Companies_CreatedForId",
                table: "JobOffers",
                column: "CreatedForId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobOffers_Companies_CreatedForId",
                table: "JobOffers");

            migrationBuilder.DropIndex(
                name: "IX_JobOffers_CreatedForId",
                table: "JobOffers");

            migrationBuilder.DropColumn(
                name: "CreatedForId",
                table: "JobOffers");

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "JobOffers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_JobOffers_CompanyId",
                table: "JobOffers",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobOffers_Companies_CompanyId",
                table: "JobOffers",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
