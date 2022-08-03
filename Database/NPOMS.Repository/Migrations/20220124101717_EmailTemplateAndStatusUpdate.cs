using Microsoft.EntityFrameworkCore.Migrations;

namespace NPOMS.Repository.Migrations
{
    public partial class EmailTemplateAndStatusUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "core",
                table: "EmailTemplates",
                columns: new[] { "Id", "Body", "Description", "Name", "Subject" },
                values: new object[,]
                {
                    { 13, "<p>Dear {ToUserFullName},</p><p>Please review the comments regarding the SLA document for application with Reference Number <span style=\"font-weight: bold;\">{ApplicationRefNo}</span>.</p><p>Please <a href=\"{url}/applications\">click here</a> to access the NPO MS application.</p><p>Kind Regards,<br>NPO MS Team</p>", null, "StatusChangedDeptReviewComments", "testing*** Review SLA Comments by Organisation - {NPO}" },
                    { 14, "<p>Dear {ToUserFullName},</p><p>Please review the comments regarding the SLA document for application with Reference Number <span style=\"font-weight: bold;\">{ApplicationRefNo}</span>.</p><p>Please <a href=\"{url}/applications\">click here</a> to access the NPO MS application.</p><p>Kind Regards,<br>NPO MS Team</p>", null, "StatusChangedOrgReviewComments", "testing*** Review SLA Comments by Department - {NPO}" }
                });

            migrationBuilder.UpdateData(
                schema: "core",
                table: "Utilities",
                keyColumn: "Id",
                keyValue: 24,
                column: "SystemAdminUtility",
                value: true);

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Statuses",
                columns: new[] { "Id", "Name", "SystemName", "UpdatedDateTime", "UpdatedUserId" },
                values: new object[,]
                {
                    { 11, "SLA: Department Review Comments", "DeptReviewComments", null, null },
                    { 12, "SLA: Organisation Review Comments", "OrgReviewComments", null, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "core",
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Statuses",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Statuses",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.UpdateData(
                schema: "core",
                table: "Utilities",
                keyColumn: "Id",
                keyValue: 24,
                column: "SystemAdminUtility",
                value: false);
        }
    }
}
