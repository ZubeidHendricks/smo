using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NPOMS.Repository.Migrations
{
    public partial class UpdateUtilityManagementIds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "core",
                table: "Utilities",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Utilities",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Utilities",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Utilities",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.InsertData(
                schema: "core",
                table: "Utilities",
                columns: new[] { "Id", "AngularRedirectUrl", "Description", "Name", "SystemAdminUtility", "UpdatedDateTime", "UpdatedUserId" },
                values: new object[,]
                {
                    { 26, "utilities/directorate", "Add and/or Update directorates", "Directorate", false, null, null },
                    { 27, "utilities/bank", "Add and/or Update banks", "Bank", false, null, null },
                    { 28, "utilities/branch", "Add and/or Update branches", "Branch", false, null, null },
                    { 29, "utilities/account-type", "Add and/or Update account types", "Account Type", false, null, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "core",
                table: "Utilities",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Utilities",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Utilities",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Utilities",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.InsertData(
                schema: "core",
                table: "Utilities",
                columns: new[] { "Id", "AngularRedirectUrl", "CreatedDateTime", "CreatedUserId", "Description", "IsActive", "Name", "SystemAdminUtility", "UpdatedDateTime", "UpdatedUserId" },
                values: new object[,]
                {
                    { 65, "utilities/directorate", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Add and/or Update directorates", false, "Directorate", false, null, null },
                    { 66, "utilities/bank", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Add and/or Update banks", false, "Bank", false, null, null },
                    { 67, "utilities/branch", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Add and/or Update branches", false, "Branch", false, null, null },
                    { 68, "utilities/account-type", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Add and/or Update account types", false, "Account Type", false, null, null }
                });
        }
    }
}
