using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Voluncare.EntityFramework.Migrations
{
    public partial class m3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ReceiverId",
                table: "Estimates",
                type: "uuid",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReceiverId",
                table: "Estimates");
        }
    }
}
