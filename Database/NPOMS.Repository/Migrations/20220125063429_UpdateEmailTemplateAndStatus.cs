using Microsoft.EntityFrameworkCore.Migrations;

namespace NPOMS.Repository.Migrations
{
    public partial class UpdateEmailTemplateAndStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "core",
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Name", "Subject" },
                values: new object[] { "StatusChangedDeptComments", "testing*** Review SLA Comments by Department - {NPO}" });

            migrationBuilder.UpdateData(
                schema: "core",
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Name", "Subject" },
                values: new object[] { "StatusChangedOrgComments", "testing*** Review SLA Comments by Organisation - {NPO}" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Statuses",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Name", "SystemName" },
                values: new object[] { "SLA: Comments Submitted (Dept)", "DeptComments" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Statuses",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Name", "SystemName" },
                values: new object[] { "SLA: Comments Submitted (Org)", "OrgComments" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "core",
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Name", "Subject" },
                values: new object[] { "StatusChangedDeptReviewComments", "testing*** Review SLA Comments by Organisation - {NPO}" });

            migrationBuilder.UpdateData(
                schema: "core",
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Name", "Subject" },
                values: new object[] { "StatusChangedOrgReviewComments", "testing*** Review SLA Comments by Department - {NPO}" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Statuses",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Name", "SystemName" },
                values: new object[] { "SLA: Department Review Comments", "DeptReviewComments" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Statuses",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Name", "SystemName" },
                values: new object[] { "SLA: Organisation Review Comments", "OrgReviewComments" });
        }
    }
}
