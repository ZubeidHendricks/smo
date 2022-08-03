using Microsoft.EntityFrameworkCore.Migrations;

namespace NPOMS.Repository.Migrations
{
    public partial class OrganisationApprovalEmailsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "core",
                table: "EmailTemplates",
                columns: new[] { "Id", "Body", "Description", "Name", "Subject" },
                values: new object[,]
                {
                    { 15, "<p>Dear {ToUserFullName},</p><p>Organisation Profile for <span style=\"font-weight: bold;\">{NpoName}</span> has been updated and sent to be reviewed.</p><p>Please <a href=\"{url}\">click here</a> to access the NPO MS application.</p><p>Kind Regards,<br>NPO MS Team</p>", null, "NewOrganisationApproval", "Organisation Profile Updated - {NpoName}" },
                    { 16, "<p>Dear {ToUserFullName},</p><p>Please review the following Organisation: <span style=\"font-weight: bold;\">{NpoName}</span>.</p><p>Please <a href=\"{url}/npo-approval\">click here</a> to access the NPO MS application.</p><p>Kind Regards,<br>NPO MS Team</p>", null, "PendingOrganisationApproval", "Pending Organisation Approval - {NpoName}" },
                    { 17, "<p>Dear {ToUserFullName},</p><p>The following Organisation: <span style=\"font-weight: bold;\">{NpoName}</span> has been approved.</p><p>Please <a href=\"{url}\">click here</a> to access the NPO MS application.</p><p>Kind Regards,<br>NPO MS Team</p>", null, "ApprovedOrganisationApproval", "Organisation Approved - {NpoName}" },
                    { 18, "<p>Dear {ToUserFullName},</p><p>The following Organisation: <span style=\"font-weight: bold;\">{NpoName}</span> has been rejected.</p><p>Please <a href=\"{url}\">click here</a> to access the NPO MS application.</p><p>Kind Regards,<br>NPO MS Team</p>", null, "RejectedOrganisationApproval", "Organisation Rejected - {NpoName}" }
                });

            migrationBuilder.UpdateData(
                schema: "core",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 47,
                column: "CategoryName",
                value: "Training Material");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "core",
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.UpdateData(
                schema: "core",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 47,
                column: "CategoryName",
                value: "PowerBI Dashboard");
        }
    }
}
