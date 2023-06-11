using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Voluncare.EntityFramework.Migrations
{
    public partial class m3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HelpRequests_Users_UserId",
                table: "HelpRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_HelpRequests_VolunteerOrganizations_TakenVolunteerId",
                table: "HelpRequests");

            migrationBuilder.DropIndex(
                name: "IX_HelpRequests_UserId",
                table: "HelpRequests");

            migrationBuilder.CreateIndex(
                name: "IX_HelpRequests_TakenOrganizationId",
                table: "HelpRequests",
                column: "TakenOrganizationId");

            migrationBuilder.AddForeignKey(
                name: "FK_HelpRequests_Users_TakenVolunteerId",
                table: "HelpRequests",
                column: "TakenVolunteerId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HelpRequests_VolunteerOrganizations_TakenOrganizationId",
                table: "HelpRequests",
                column: "TakenOrganizationId",
                principalTable: "VolunteerOrganizations",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HelpRequests_Users_TakenVolunteerId",
                table: "HelpRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_HelpRequests_VolunteerOrganizations_TakenOrganizationId",
                table: "HelpRequests");

            migrationBuilder.DropIndex(
                name: "IX_HelpRequests_TakenOrganizationId",
                table: "HelpRequests");

            migrationBuilder.CreateIndex(
                name: "IX_HelpRequests_UserId",
                table: "HelpRequests",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_HelpRequests_Users_UserId",
                table: "HelpRequests",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HelpRequests_VolunteerOrganizations_TakenVolunteerId",
                table: "HelpRequests",
                column: "TakenVolunteerId",
                principalTable: "VolunteerOrganizations",
                principalColumn: "Id");
        }
    }
}
