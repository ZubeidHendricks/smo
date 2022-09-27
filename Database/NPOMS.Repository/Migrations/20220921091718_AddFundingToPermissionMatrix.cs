using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NPOMS.Repository.Migrations
{
    public partial class AddFundingToPermissionMatrix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "core",
                table: "Permissions",
                columns: new[] { "Id", "CategoryName", "Name", "SystemName", "UpdatedDateTime", "UpdatedUserId" },
                values: new object[,]
                {
                    { 66, "Top Navigation", "View Funding Menu", "TN.VFM", null, null },
                    { 67, "Funding", "Add NPO/Organisation Funding", "Fund.ANF", null, null },
                    { 68, "Funding", "Edit NPO/Organisation Funding", "Fund.ENF", null, null },
                    { 69, "Funding", "View NPO/Organisation Funding", "Fund.VNF", null, null },
                    { 70, "Funding", "Delete NPO/Organisation Funding", "Fund.DNF", null, null },
                    { 71, "Funding", "View Payment Schedule", "Fund.VPS", null, null },
                    { 72, "Funding", "View Compliance Check", "Fund.CC", null, null },
                    { 73, "Funding", "Show NPO/Organisation Funding Action Buttons", "Fund.SNFA", null, null }
                });

            migrationBuilder.InsertData(
                schema: "mapping",
                table: "Roles_Permissions",
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { 66, 1 },
                    { 67, 1 },
                    { 68, 1 },
                    { 69, 1 },
                    { 70, 1 },
                    { 71, 1 },
                    { 72, 1 },
                    { 73, 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "mapping",
                table: "Roles_Permissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 66, 1 });

            migrationBuilder.DeleteData(
                schema: "mapping",
                table: "Roles_Permissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 67, 1 });

            migrationBuilder.DeleteData(
                schema: "mapping",
                table: "Roles_Permissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 68, 1 });

            migrationBuilder.DeleteData(
                schema: "mapping",
                table: "Roles_Permissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 69, 1 });

            migrationBuilder.DeleteData(
                schema: "mapping",
                table: "Roles_Permissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 70, 1 });

            migrationBuilder.DeleteData(
                schema: "mapping",
                table: "Roles_Permissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 71, 1 });

            migrationBuilder.DeleteData(
                schema: "mapping",
                table: "Roles_Permissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 72, 1 });

            migrationBuilder.DeleteData(
                schema: "mapping",
                table: "Roles_Permissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 73, 1 });

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 73);
        }
    }
}
