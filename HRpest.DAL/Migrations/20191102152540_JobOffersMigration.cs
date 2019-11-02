using Microsoft.EntityFrameworkCore.Migrations;

namespace HRpest.DAL.Migrations
{
    public partial class JobOffersMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JobOffers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmploymentType = table.Column<int>(nullable: false),
                    PositionLevel = table.Column<int>(nullable: false),
                    HoursWeekly = table.Column<int>(nullable: false),
                    RemoteHoursWeekly = table.Column<int>(nullable: false),
                    MinimumPay = table.Column<int>(nullable: false),
                    MaximumPay = table.Column<int>(nullable: false),
                    CvHandle = table.Column<string>(nullable: true),
                    PositionName = table.Column<string>(nullable: true),
                    JobDescription = table.Column<string>(nullable: true),
                    UsualTasks = table.Column<string>(nullable: true),
                    JobRequirements = table.Column<string>(nullable: true),
                    JobBenefits = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobOffers", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobOffers");
        }
    }
}
