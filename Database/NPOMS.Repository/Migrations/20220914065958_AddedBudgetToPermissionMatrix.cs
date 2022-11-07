using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NPOMS.Repository.Migrations
{
    public partial class AddedBudgetToPermissionMatrix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "core",
                table: "Permissions",
                columns: new[] { "Id", "CategoryName", "Name", "SystemName", "UpdatedDateTime", "UpdatedUserId" },
                values: new object[,]
                {
                    { 48, "Budgets", "Add Budget", "Bud.Add", null, null },
                    { 49, "Budgets", "Edit Budget", "Bud.Edit", null, null },
                    { 50, "Budgets", "View List of Budgets", "Bud.View", null, null },
                    { 51, "Budgets", "Add Directorate Budget", "Bud.ADB", null, null },
                    { 52, "Budgets", "Edit Directorate Budget", "Bud.EDB", null, null },
                    { 53, "Budgets", "View List of Directorate Budgets", "Bud.VDB", null, null },
                    { 54, "Budgets", "Add Programme Budget", "Bud.APB", null, null },
                    { 55, "Budgets", "Edit Programme Budget", "Bud.EPB", null, null },
                    { 56, "Budgets", "View List of Programme Budgets", "Bud.VPB", null, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 56);
        }
    }
}
