using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Voluncare.EntityFramework.Migrations
{
    public partial class changes_dependencies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HelpRequests_VolunteerOrganizations_TakenOrganizationId",
                table: "HelpRequests");

            migrationBuilder.DropIndex(
                name: "IX_HelpRequests_TakenOrganizationId",
                table: "HelpRequests");

            migrationBuilder.AlterColumn<Guid>(
                name: "TakenVolunteerId",
                table: "HelpRequests",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "TakenOrganizationId",
                table: "HelpRequests",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.CreateIndex(
                name: "IX_HelpRequests_TakenVolunteerId",
                table: "HelpRequests",
                column: "TakenVolunteerId");

            migrationBuilder.AddForeignKey(
                name: "FK_HelpRequests_VolunteerOrganizations_TakenVolunteerId",
                table: "HelpRequests",
                column: "TakenVolunteerId",
                principalTable: "VolunteerOrganizations",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HelpRequests_VolunteerOrganizations_TakenVolunteerId",
                table: "HelpRequests");

            migrationBuilder.DropIndex(
                name: "IX_HelpRequests_TakenVolunteerId",
                table: "HelpRequests");

            migrationBuilder.AlterColumn<Guid>(
                name: "TakenVolunteerId",
                table: "HelpRequests",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "TakenOrganizationId",
                table: "HelpRequests",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_HelpRequests_TakenOrganizationId",
                table: "HelpRequests",
                column: "TakenOrganizationId");

            migrationBuilder.AddForeignKey(
                name: "FK_HelpRequests_VolunteerOrganizations_TakenOrganizationId",
                table: "HelpRequests",
                column: "TakenOrganizationId",
                principalTable: "VolunteerOrganizations",
                principalColumn: "Id");
        }
    }
}
