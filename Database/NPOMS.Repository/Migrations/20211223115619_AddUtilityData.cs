using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NPOMS.Repository.Migrations
{
    public partial class AddUtilityData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                schema: "core",
                table: "Utilities",
                type: "bit",
                nullable: false,
                defaultValueSql: "1",
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<int>(
                name: "CreatedUserId",
                schema: "core",
                table: "Utilities",
                type: "int",
                nullable: false,
                defaultValueSql: "1",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDateTime",
                schema: "core",
                table: "Utilities",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GetDate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.InsertData(
                schema: "core",
                table: "Utilities",
                columns: new[] { "Id", "AngularRedirectUrl", "Description", "Name", "SystemAdminUtility", "UpdatedDateTime", "UpdatedUserId" },
                values: new object[,]
                {
                    { 1, "utilities/department", "Add and/or Update departments", "Department", true, null, null },
                    { 21, "utilities/service-type", "Add and/or Update service types", "Service Type", false, null, null },
                    { 20, "utilities/resource-type", "Add and/or Update resource types", "Resource Type", false, null, null },
                    { 19, "utilities/recipient-type", "Add and/or Update recipient types", "Recipient Type", false, null, null },
                    { 18, "utilities/provision-type", "Add and/or Update provision types", "Provision Type", false, null, null },
                    { 17, "utilities/programme", "Add and/or Update programmes", "Programme", false, null, null },
                    { 16, "utilities/position", "Add and/or Update positions", "Position", false, null, null },
                    { 15, "utilities/organisation-type", "Add and/or Update organisation types", "Organisation Type", false, null, null },
                    { 14, "utilities/facility-type", "Add and/or Update facility types", "Facility Type", true, null, null },
                    { 13, "utilities/facility-sub-district", "Add and/or Update facility sub-districts", "Facility Sub-District", false, null, null },
                    { 22, "utilities/sub-programme", "Add and/or Update sub-programmes", "Sub-Programme", false, null, null },
                    { 12, "utilities/facility-district", "Add and/or Update facility districts", "Facility District", false, null, null },
                    { 10, "utilities/application-type", "Add and/or Update application types", "Application Type", false, null, null },
                    { 9, "utilities/allocation-type", "Add and/or Update allocation types", "Allocation Type", false, null, null },
                    { 8, "utilities/activity-type", "Add and/or Update activity types", "Activity Type", false, null, null },
                    { 7, "utilities/status", "Add and/or Update statuses", "Status", true, null, null },
                    { 6, "utilities/access-status", "Add and/or Update access statuses", "Access Status", true, null, null },
                    { 5, "utilities/role", "Add and/or Update roles", "Role", true, null, null },
                    { 4, "utilities/financial-year", "Add and/or Update financial years", "Financial Year", true, null, null },
                    { 3, "utilities/email-account", "Add and/or Update email accounts", "Email Account", true, null, null },
                    { 2, "utilities/document-type", "Add and/or Update document types", "Document Type", false, null, null },
                    { 11, "utilities/facility-class", "Add and/or Update facility classes", "Facility Class", false, null, null },
                    { 23, "utilities/title", "Add and/or Update titles", "Title", false, null, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "core",
                table: "Utilities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Utilities",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Utilities",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Utilities",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Utilities",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Utilities",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Utilities",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Utilities",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Utilities",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Utilities",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Utilities",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Utilities",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Utilities",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Utilities",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Utilities",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Utilities",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Utilities",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Utilities",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Utilities",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Utilities",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Utilities",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Utilities",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Utilities",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                schema: "core",
                table: "Utilities",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValueSql: "1");

            migrationBuilder.AlterColumn<int>(
                name: "CreatedUserId",
                schema: "core",
                table: "Utilities",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValueSql: "1");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDateTime",
                schema: "core",
                table: "Utilities",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GetDate()");
        }
    }
}
