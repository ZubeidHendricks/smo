using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NPOMS.Repository.Migrations
{
    public partial class UpdateServiceRendered : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDateTime",
                schema: "dbo",
                table: "ServicesRendered");

            migrationBuilder.DropColumn(
                name: "CreatedUserId",
                schema: "dbo",
                table: "ServicesRendered");

            migrationBuilder.DropColumn(
                name: "UpdatedDateTime",
                schema: "dbo",
                table: "ServicesRendered");

            migrationBuilder.DropColumn(
                name: "UpdatedUserId",
                schema: "dbo",
                table: "ServicesRendered");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDateTime",
                schema: "dbo",
                table: "ServicesRendered",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CreatedUserId",
                schema: "dbo",
                table: "ServicesRendered",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDateTime",
                schema: "dbo",
                table: "ServicesRendered",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpdatedUserId",
                schema: "dbo",
                table: "ServicesRendered",
                type: "int",
                nullable: true);
        }
    }
}
