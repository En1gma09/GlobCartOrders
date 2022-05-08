using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GlobCartOrderService.Infra.Data.Migrations
{
    public partial class AddUpdatedAtProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Products",
                type: "Date",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Products");
        }
    }
}
