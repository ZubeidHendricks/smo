using Microsoft.EntityFrameworkCore.Migrations;

namespace NPOMS.Repository.Migrations
{
    public partial class UpdateUtilityManagement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "core",
                table: "Utilities",
                columns: new[] { "Id", "AngularRedirectUrl", "Description", "Name", "SystemAdminUtility", "UpdatedDateTime", "UpdatedUserId" },
                values: new object[] { 24, "utilities/management", "Add and/or Update utility management", "Utility Management", true, null, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "core",
                table: "Utilities",
                keyColumn: "Id",
                keyValue: 24);
        }
    }
}
