using Microsoft.EntityFrameworkCore.Migrations;

namespace NPOMS.Repository.Migrations
{
    public partial class AddIsActiveToNpoProfile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                schema: "dbo",
                table: "NpoProfiles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                schema: "core",
                table: "EmailAccounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FromDisplayName", "FromEmail" },
                values: new object[] { "NPO Management System", "no-reply@westerncape.gov.za" });

            migrationBuilder.UpdateData(
                schema: "core",
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: 1,
                column: "Subject",
                value: "Access Request Created");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: 2,
                column: "Subject",
                value: "Access Request Submitted");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: 3,
                column: "Subject",
                value: "Access Request Approved");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: 4,
                column: "Subject",
                value: "Access Request Rejected");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: 5,
                column: "Subject",
                value: "Application Submitted - {NPO}");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: 6,
                column: "Subject",
                value: "Application Pending Review - {NPO}");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: 7,
                column: "Subject",
                value: "Amendments Required - {NPO}");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: 8,
                column: "Subject",
                value: "Application Pending Approval - {NPO}");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: 9,
                column: "Subject",
                value: "Application Rejected - {NPO}");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: 10,
                column: "Subject",
                value: "Application Pending SLA - {NPO}");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: 11,
                column: "Subject",
                value: "Application Pending Signed SLA - {NPO}");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: 12,
                column: "Subject",
                value: "Application Accepted SLA - {NPO}");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: 13,
                column: "Subject",
                value: "Review SLA Comments by Department - {NPO}");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: 14,
                column: "Subject",
                value: "Review SLA Comments by Organisation - {NPO}");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "EmbeddedReports",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ReportId", "WorkspaceId" },
                values: new object[] { "270ec198-88c7-4e9b-b429-b6b99ace164f", "38cbb1ed-23d8-4c7d-830a-4f7a39086eca" });

            migrationBuilder.UpdateData(
                schema: "core",
                table: "Utilities",
                keyColumn: "Id",
                keyValue: 10,
                column: "SystemAdminUtility",
                value: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                schema: "dbo",
                table: "NpoProfiles");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "EmailAccounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FromDisplayName", "FromEmail" },
                values: new object[] { "npoms-no-reply", "npoms.no-reply@westerncape.gov.za" });

            migrationBuilder.UpdateData(
                schema: "core",
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: 1,
                column: "Subject",
                value: "testing*** Access Request Created");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: 2,
                column: "Subject",
                value: "testing*** Access Request Submitted");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: 3,
                column: "Subject",
                value: "testing*** Access Request Approved");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: 4,
                column: "Subject",
                value: "testing*** Access Request Rejected");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: 5,
                column: "Subject",
                value: "testing*** Application Submitted - {NPO}");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: 6,
                column: "Subject",
                value: "testing*** Application Pending Review - {NPO}");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: 7,
                column: "Subject",
                value: "testing*** Amendments Required - {NPO}");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: 8,
                column: "Subject",
                value: "testing*** Application Pending Approval - {NPO}");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: 9,
                column: "Subject",
                value: "testing*** Application Rejected - {NPO}");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: 10,
                column: "Subject",
                value: "testing*** Application Pending SLA - {NPO}");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: 11,
                column: "Subject",
                value: "testing*** Application Pending Signed SLA - {NPO}");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: 12,
                column: "Subject",
                value: "testing*** Application Accepted SLA - {NPO}");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: 13,
                column: "Subject",
                value: "testing*** Review SLA Comments by Department - {NPO}");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: 14,
                column: "Subject",
                value: "testing*** Review SLA Comments by Organisation - {NPO}");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "EmbeddedReports",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ReportId", "WorkspaceId" },
                values: new object[] { "0d26cc25-db2e-403e-815f-989918ea0863", "1e12372d-bbc2-420a-b033-fcc3daa4ee17" });

            migrationBuilder.UpdateData(
                schema: "core",
                table: "Utilities",
                keyColumn: "Id",
                keyValue: 10,
                column: "SystemAdminUtility",
                value: false);
        }
    }
}
