using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NPOMS.Repository.Migrations
{
    public partial class AddSideMenuToPermissionMatrix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "core",
                table: "Permissions",
                columns: new[] { "Id", "CategoryName", "Name", "SystemName", "UpdatedDateTime", "UpdatedUserId" },
                values: new object[,]
                {
                    { 57, "Administration - Side Navigation", "View Settings Side Menu", "SN.Security", null, null },
                    { 58, "Administration - Side Navigation", "View Users Side Menu", "SN.Users", null, null },
                    { 59, "Administration - Side Navigation", "View Permissions Side Menu", "SN.Permissions", null, null },
                    { 60, "Administration - Side Navigation", "View Settings Side Menu", "SN.Settings", null, null },
                    { 61, "Administration - Side Navigation", "View Utilities Sub Menu", "SN.Utilities", null, null },
                    { 62, "Administration - Side Navigation", "View Budgets Sub Menu", "SN.Budgets", null, null },
                    { 63, "Administration - Side Navigation", "View Department Budget Sub Menu", "SN.DeptBudget", null, null },
                    { 64, "Administration - Side Navigation", "View Directorate Budget Sub Menu", "SN.DirectorateBudget", null, null },
                    { 65, "Administration - Side Navigation", "View Programme Budget Sub Menu", "SN.ProgBudget", null, null }
                });

            migrationBuilder.InsertData(
                schema: "mapping",
                table: "Roles_Permissions",
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { 57, 1 },
                    { 58, 1 },
                    { 59, 1 },
                    { 60, 1 },
                    { 61, 1 },
                    { 62, 1 },
                    { 63, 1 },
                    { 64, 1 },
                    { 65, 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "mapping",
                table: "Roles_Permissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 57, 1 });

            migrationBuilder.DeleteData(
                schema: "mapping",
                table: "Roles_Permissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 58, 1 });

            migrationBuilder.DeleteData(
                schema: "mapping",
                table: "Roles_Permissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 59, 1 });

            migrationBuilder.DeleteData(
                schema: "mapping",
                table: "Roles_Permissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 60, 1 });

            migrationBuilder.DeleteData(
                schema: "mapping",
                table: "Roles_Permissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 61, 1 });

            migrationBuilder.DeleteData(
                schema: "mapping",
                table: "Roles_Permissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 62, 1 });

            migrationBuilder.DeleteData(
                schema: "mapping",
                table: "Roles_Permissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 63, 1 });

            migrationBuilder.DeleteData(
                schema: "mapping",
                table: "Roles_Permissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 64, 1 });

            migrationBuilder.DeleteData(
                schema: "mapping",
                table: "Roles_Permissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 65, 1 });

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 65);
        }
    }
}
