using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NPOMS.Repository.Migrations
{
    public partial class AddedFrequencyPeriod : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FrequencyPeriods",
                schema: "dropdown",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    SystemName = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1"),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
                    UpdatedUserId = table.Column<int>(type: "int", nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FrequencyPeriods", x => x.Id);
                });

            migrationBuilder.UpdateData(
                schema: "core",
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: 2,
                column: "Body",
                value: "<p>Dear {ToUserFullName},</p><p>Please review access for <span style=\"font-weight: bold;\">{UserAccessFullName}</span> to the following Organisation: <span style=\"font-weight: bold;\">{NpoName}</span>.</p><p>Please <a href=\"{url}/#/access-review\">click here</a> to access the NPO MS application.</p><p>Kind Regards,<br>NPO MS Team</p>");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: 5,
                column: "Body",
                value: "<p>Dear {ToUserFullName},</p><p>The application for <span style=\"font-weight: bold;\">{NPO}</span> has been sent to be reviewed. The Reference Number is <span style=\"font-weight: bold;\">{ApplicationRefNo}</span>.</p><p>Please <a href=\"{url}/#/applications\">click here</a> to access the NPO MS application.</p><p>Kind Regards,<br>NPO MS Team</p>");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: 6,
                column: "Body",
                value: "<p>Dear {ToUserFullName},</p><p>The application with Reference Number <span style=\"font-weight: bold;\">{ApplicationRefNo}</span> has been submitted for you to review.</p><p>Please <a href=\"{url}/#/applications\">click here</a> to access the NPO MS application.</p><p>Kind Regards,<br>NPO MS Team</p>");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: 7,
                column: "Body",
                value: "<p>Dear {ToUserFullName},</p><p>There are changes required to the application with Reference Number <span style=\"font-weight: bold;\">{ApplicationRefNo}</span>.</p><p>Please <a href=\"{url}/#/applications\">click here</a> to access the NPO MS application.</p><p>Kind Regards,<br>NPO MS Team</p>");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: 8,
                column: "Body",
                value: "<p>Dear {ToUserFullName},</p><p>The application with Reference Number <span style=\"font-weight: bold;\">{ApplicationRefNo}</span> has been sent for you to approve.</p><p>Please <a href=\"{url}/#/applications\">click here</a> to access the NPO MS application.</p><p>Kind Regards,<br>NPO MS Team</p>");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: 9,
                column: "Body",
                value: "<p>Dear {ToUserFullName},</p><p>The application with Reference Number <span style=\"font-weight: bold;\">{ApplicationRefNo}</span> has been rejected.</p><p>Please <a href=\"{url}/#/applications\">click here</a> to access the NPO MS application.</p><p>Kind Regards,<br>NPO MS Team</p>");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: 10,
                column: "Body",
                value: "<p>Dear {ToUserFullName},</p><p>The application with Reference Number <span style=\"font-weight: bold;\">{ApplicationRefNo}</span> has been approved.</p><p>Please upload the SLA document.</p><p>Please <a href=\"{url}/#/applications\">click here</a> to access the NPO MS application.</p><p>Kind Regards,<br>NPO MS Team</p>");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: 11,
                column: "Body",
                value: "<p>Dear {ToUserFullName},</p><p>The application with Reference Number <span style=\"font-weight: bold;\">{ApplicationRefNo}</span> has been approved.</p><p>Please download the SLA document that requires your signature and upload the signed SLA document.</p><p>Please <a href=\"{url}/#/applications\">click here</a> to access the NPO MS application.</p><p>Kind Regards,<br>NPO MS Team</p>");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: 12,
                column: "Body",
                value: "<p>Dear {ToUserFullName},</p><p>The signed SLA document has been uploaded for application with Reference Number <span style=\"font-weight: bold;\">{ApplicationRefNo}</span>.</p><p>Please <a href=\"{url}/#/applications\">click here</a> to access the NPO MS application.</p><p>Kind Regards,<br>NPO MS Team</p>");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: 13,
                column: "Body",
                value: "<p>Dear {ToUserFullName},</p><p>Please review the comments regarding the SLA document for application with Reference Number <span style=\"font-weight: bold;\">{ApplicationRefNo}</span>.</p><p>Please <a href=\"{url}/#/applications\">click here</a> to access the NPO MS application.</p><p>Kind Regards,<br>NPO MS Team</p>");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: 14,
                column: "Body",
                value: "<p>Dear {ToUserFullName},</p><p>Please review the comments regarding the SLA document for application with Reference Number <span style=\"font-weight: bold;\">{ApplicationRefNo}</span>.</p><p>Please <a href=\"{url}/#/applications\">click here</a> to access the NPO MS application.</p><p>Kind Regards,<br>NPO MS Team</p>");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: 16,
                column: "Body",
                value: "<p>Dear {ToUserFullName},</p><p>Please review the following Organisation: <span style=\"font-weight: bold;\">{NpoName}</span>.</p><p>Please <a href=\"{url}/#/npo-approval\">click here</a> to access the NPO MS application.</p><p>Kind Regards,<br>NPO MS Team</p>");

            migrationBuilder.InsertData(
                schema: "dropdown",
                table: "FrequencyPeriods",
                columns: new[] { "Id", "Name", "SystemName", "UpdatedDateTime", "UpdatedUserId" },
                values: new object[,]
                {
                    { 1, "Annual", "Annual", null, null },
                    { 2, "April", "Apr", null, null },
                    { 3, "May", "May", null, null },
                    { 4, "June", "Jun", null, null },
                    { 5, "July", "Jul", null, null },
                    { 6, "August", "Aug", null, null },
                    { 7, "September", "Sep", null, null },
                    { 8, "October", "Oct", null, null },
                    { 9, "November", "Nov", null, null },
                    { 10, "December", "Dec", null, null },
                    { 11, "January", "Jan", null, null },
                    { 12, "February", "Feb", null, null },
                    { 13, "March", "Mar", null, null },
                    { 14, "Quarter1", "Q1", null, null },
                    { 15, "Quarter2", "Q2", null, null },
                    { 16, "Quarter3", "Q3", null, null },
                    { 17, "Quarter4", "Q4", null, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FrequencyPeriods",
                schema: "dropdown");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: 2,
                column: "Body",
                value: "<p>Dear {ToUserFullName},</p><p>Please review access for <span style=\"font-weight: bold;\">{UserAccessFullName}</span> to the following Organisation: <span style=\"font-weight: bold;\">{NpoName}</span>.</p><p>Please <a href=\"{url}/access-review\">click here</a> to access the NPO MS application.</p><p>Kind Regards,<br>NPO MS Team</p>");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: 5,
                column: "Body",
                value: "<p>Dear {ToUserFullName},</p><p>The application for <span style=\"font-weight: bold;\">{NPO}</span> has been sent to be reviewed. The Reference Number is <span style=\"font-weight: bold;\">{ApplicationRefNo}</span>.</p><p>Please <a href=\"{url}/applications\">click here</a> to access the NPO MS application.</p><p>Kind Regards,<br>NPO MS Team</p>");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: 6,
                column: "Body",
                value: "<p>Dear {ToUserFullName},</p><p>The application with Reference Number <span style=\"font-weight: bold;\">{ApplicationRefNo}</span> has been submitted for you to review.</p><p>Please <a href=\"{url}/applications\">click here</a> to access the NPO MS application.</p><p>Kind Regards,<br>NPO MS Team</p>");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: 7,
                column: "Body",
                value: "<p>Dear {ToUserFullName},</p><p>There are changes required to the application with Reference Number <span style=\"font-weight: bold;\">{ApplicationRefNo}</span>.</p><p>Please <a href=\"{url}/applications\">click here</a> to access the NPO MS application.</p><p>Kind Regards,<br>NPO MS Team</p>");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: 8,
                column: "Body",
                value: "<p>Dear {ToUserFullName},</p><p>The application with Reference Number <span style=\"font-weight: bold;\">{ApplicationRefNo}</span> has been sent for you to approve.</p><p>Please <a href=\"{url}/applications\">click here</a> to access the NPO MS application.</p><p>Kind Regards,<br>NPO MS Team</p>");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: 9,
                column: "Body",
                value: "<p>Dear {ToUserFullName},</p><p>The application with Reference Number <span style=\"font-weight: bold;\">{ApplicationRefNo}</span> has been rejected.</p><p>Please <a href=\"{url}/applications\">click here</a> to access the NPO MS application.</p><p>Kind Regards,<br>NPO MS Team</p>");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: 10,
                column: "Body",
                value: "<p>Dear {ToUserFullName},</p><p>The application with Reference Number <span style=\"font-weight: bold;\">{ApplicationRefNo}</span> has been approved.</p><p>Please upload the SLA document.</p><p>Please <a href=\"{url}/applications\">click here</a> to access the NPO MS application.</p><p>Kind Regards,<br>NPO MS Team</p>");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: 11,
                column: "Body",
                value: "<p>Dear {ToUserFullName},</p><p>The application with Reference Number <span style=\"font-weight: bold;\">{ApplicationRefNo}</span> has been approved.</p><p>Please download the SLA document that requires your signature and upload the signed SLA document.</p><p>Please <a href=\"{url}/applications\">click here</a> to access the NPO MS application.</p><p>Kind Regards,<br>NPO MS Team</p>");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: 12,
                column: "Body",
                value: "<p>Dear {ToUserFullName},</p><p>The signed SLA document has been uploaded for application with Reference Number <span style=\"font-weight: bold;\">{ApplicationRefNo}</span>.</p><p>Please <a href=\"{url}/applications\">click here</a> to access the NPO MS application.</p><p>Kind Regards,<br>NPO MS Team</p>");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: 13,
                column: "Body",
                value: "<p>Dear {ToUserFullName},</p><p>Please review the comments regarding the SLA document for application with Reference Number <span style=\"font-weight: bold;\">{ApplicationRefNo}</span>.</p><p>Please <a href=\"{url}/applications\">click here</a> to access the NPO MS application.</p><p>Kind Regards,<br>NPO MS Team</p>");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: 14,
                column: "Body",
                value: "<p>Dear {ToUserFullName},</p><p>Please review the comments regarding the SLA document for application with Reference Number <span style=\"font-weight: bold;\">{ApplicationRefNo}</span>.</p><p>Please <a href=\"{url}/applications\">click here</a> to access the NPO MS application.</p><p>Kind Regards,<br>NPO MS Team</p>");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: 16,
                column: "Body",
                value: "<p>Dear {ToUserFullName},</p><p>Please review the following Organisation: <span style=\"font-weight: bold;\">{NpoName}</span>.</p><p>Please <a href=\"{url}/npo-approval\">click here</a> to access the NPO MS application.</p><p>Kind Regards,<br>NPO MS Team</p>");
        }
    }
}
