using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NPOMS.Repository.Migrations
{
    public partial class UpdateEmailTemplates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "core",
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: 19,
                column: "Body",
                value: "<p>Dear {ToUserFullName},</p><p>The indicator actuals for application with Reference Number <span style=\"font-weight: bold;\">{ApplicationRefNo}</span> has been updated with a status of <span style=\"font-weight: bold;\">{status}</span>.</p><p>The financial year and month is <span style=\"font-weight: bold;\">{financialYear}</span> and <span style=\"font-weight: bold;\">{frequencyPeriod}</span> respectively.</p><p>Please <a href=\"{url}/#/workplan-indicator/manage/{npoId}\">click here</a> to access the NPO MS application.</p><p>Kind Regards,<br>NPO MS Team</p>");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: 20,
                column: "Body",
                value: "<p>Dear {ToUserFullName},</p><p>The indicator actuals for application with Reference Number <span style=\"font-weight: bold;\">{ApplicationRefNo}</span> has been submitted for you to review.</p><p>The financial year and month is <span style=\"font-weight: bold;\">{financialYear}</span> and <span style=\"font-weight: bold;\">{frequencyPeriod}</span> respectively.</p><p>Please <a href=\"{url}/#/workplan-indicator/manage/{npoId}\">click here</a> to access the NPO MS application.</p><p>Kind Regards,<br>NPO MS Team</p>");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: 21,
                column: "Body",
                value: "<p>Dear {ToUserFullName},</p><p>The indicator actuals for application with Reference Number <span style=\"font-weight: bold;\">{ApplicationRefNo}</span> has been sent for you to approve.</p><p>The financial year and month is <span style=\"font-weight: bold;\">{financialYear}</span> and <span style=\"font-weight: bold;\">{frequencyPeriod}</span> respectively.</p><p>Please <a href=\"{url}/#/workplan-indicator/manage/{npoId}\">click here</a> to access the NPO MS application.</p><p>Kind Regards,<br>NPO MS Team</p>");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "core",
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: 19,
                column: "Body",
                value: "<p>Dear {ToUserFullName},</p><p>The indicator actuals for application with Reference Number <span style=\"font-weight: bold;\">{ApplicationRefNo}</span> has been updated with a status of <span style=\"font-weight: bold;\">{status}</span>.</p><p>The financial year and month is <span style=\"font-weight: bold;\">{financialYear}</span> and <span style=\"font-weight: bold;\">{frequencyPeriod}</span> respectively.</p><p>Please <a href=\"{url}/#/workplan-indicator/manage/{applicationId}\">click here</a> to access the NPO MS application.</p><p>Kind Regards,<br>NPO MS Team</p>");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: 20,
                column: "Body",
                value: "<p>Dear {ToUserFullName},</p><p>The indicator actuals for application with Reference Number <span style=\"font-weight: bold;\">{ApplicationRefNo}</span> has been submitted for you to review.</p><p>The financial year and month is <span style=\"font-weight: bold;\">{financialYear}</span> and <span style=\"font-weight: bold;\">{frequencyPeriod}</span> respectively.</p><p>Please <a href=\"{url}/#/workplan-indicator/manage/{applicationId}\">click here</a> to access the NPO MS application.</p><p>Kind Regards,<br>NPO MS Team</p>");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: 21,
                column: "Body",
                value: "<p>Dear {ToUserFullName},</p><p>The indicator actuals for application with Reference Number <span style=\"font-weight: bold;\">{ApplicationRefNo}</span> has been sent for you to approve.</p><p>The financial year and month is <span style=\"font-weight: bold;\">{financialYear}</span> and <span style=\"font-weight: bold;\">{frequencyPeriod}</span> respectively.</p><p>Please <a href=\"{url}/#/workplan-indicator/manage/{applicationId}\">click here</a> to access the NPO MS application.</p><p>Kind Regards,<br>NPO MS Team</p>");
        }
    }
}
