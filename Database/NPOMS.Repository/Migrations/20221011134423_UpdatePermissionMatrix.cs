using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NPOMS.Repository.Migrations
{
    public partial class UpdatePermissionMatrix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "core",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 57,
                column: "Name",
                value: "View Security Side Menu");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "core",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 57,
                column: "Name",
                value: "View Settings Side Menu");
        }
    }
}
