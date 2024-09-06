using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NPOMS.Repository.Migrations
{
    /// <inheritdoc />
    public partial class UpdateFundingEmailTemplates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "core",
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "Body", "Subject" },
                values: new object[] { "<p>Dear {ToUserFullName},</p><p>Thank you for submitting the funding for <span style=\"font-weight: bold;\">{NpoName} ({NpoRefNo})</span> for the <span style=\"font-weight: bold;\">{FinancialYearName}</span> financial year.</p><p>It has been sent to be approved.</p><p>Please <a href=\"{url}/#/funding-capture\">click here</a> to access the NPO MS application.</p><p>Kind Regards,<br>NPO MS Team</p>", "Funding submitted for Organisation - {NpoName} ({NpoRefNo})" });

            migrationBuilder.UpdateData(
                schema: "core",
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "Body", "Subject" },
                values: new object[] { "<p>Dear {ToUserFullName},</p><p>The funding for <span style=\"font-weight: bold;\">{NpoName} ({NpoRefNo})</span> for the <span style=\"font-weight: bold;\">{FinancialYearName}</span> financial year has been {action}.</p><p>Please <a href=\"{url}/#/funding-capture\">click here</a> to access the NPO MS application.</p><p>Kind Regards,<br>NPO MS Team</p>", "Funding {StatusName} for Organisation - {NpoName} ({NpoRefNo})" });

            migrationBuilder.UpdateData(
                schema: "core",
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "Body", "Subject" },
                values: new object[] { "<p>Dear {ToUserFullName},</p><p>The funding for <span style=\"font-weight: bold;\">{NpoName} ({NpoRefNo})</span> for the <span style=\"font-weight: bold;\">{FinancialYearName}</span> financial year has been sent for you to {action}.</p><p>Please <a href=\"{url}/#/funding-capture\">click here</a> to access the NPO MS application.</p><p>Kind Regards,<br>NPO MS Team</p>", "Funding {StatusName} for Organisation - {NpoName} ({NpoRefNo})" });

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 6, 12, 32, 58, 985, DateTimeKind.Local).AddTicks(6094));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 6, 12, 32, 58, 985, DateTimeKind.Local).AddTicks(6118));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 6, 12, 32, 58, 985, DateTimeKind.Local).AddTicks(6120));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 6, 12, 32, 58, 985, DateTimeKind.Local).AddTicks(6122));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 6, 12, 32, 58, 985, DateTimeKind.Local).AddTicks(6124));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 6, 12, 32, 58, 985, DateTimeKind.Local).AddTicks(6126));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 6, 12, 32, 58, 985, DateTimeKind.Local).AddTicks(6128));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 6, 12, 32, 58, 985, DateTimeKind.Local).AddTicks(6131));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 6, 12, 32, 58, 985, DateTimeKind.Local).AddTicks(6133));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 6, 12, 32, 58, 985, DateTimeKind.Local).AddTicks(6135));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 6, 12, 32, 58, 985, DateTimeKind.Local).AddTicks(6136));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 6, 12, 32, 58, 985, DateTimeKind.Local).AddTicks(6138));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 6, 12, 32, 58, 985, DateTimeKind.Local).AddTicks(6140));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 6, 12, 32, 58, 985, DateTimeKind.Local).AddTicks(6142));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 6, 12, 32, 58, 985, DateTimeKind.Local).AddTicks(6144));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 6, 12, 32, 58, 985, DateTimeKind.Local).AddTicks(6146));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 6, 12, 32, 58, 985, DateTimeKind.Local).AddTicks(6148));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 6, 12, 32, 58, 985, DateTimeKind.Local).AddTicks(6154));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 6, 12, 32, 58, 985, DateTimeKind.Local).AddTicks(6155));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 6, 12, 32, 58, 985, DateTimeKind.Local).AddTicks(6157));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 6, 12, 32, 58, 985, DateTimeKind.Local).AddTicks(6248));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 6, 12, 32, 58, 985, DateTimeKind.Local).AddTicks(6266));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 6, 12, 32, 58, 985, DateTimeKind.Local).AddTicks(6268));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 6, 12, 32, 58, 985, DateTimeKind.Local).AddTicks(6270));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 6, 12, 32, 58, 985, DateTimeKind.Local).AddTicks(6272));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 6, 12, 32, 58, 985, DateTimeKind.Local).AddTicks(6273));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 6, 12, 32, 58, 985, DateTimeKind.Local).AddTicks(6275));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 6, 12, 32, 58, 985, DateTimeKind.Local).AddTicks(6277));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 6, 12, 32, 58, 985, DateTimeKind.Local).AddTicks(6279));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 6, 12, 32, 58, 985, DateTimeKind.Local).AddTicks(6288));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 6, 12, 32, 58, 985, DateTimeKind.Local).AddTicks(6311));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 6, 12, 32, 58, 985, DateTimeKind.Local).AddTicks(6313));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 6, 12, 32, 58, 985, DateTimeKind.Local).AddTicks(8219));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 6, 12, 32, 58, 985, DateTimeKind.Local).AddTicks(8230));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 6, 12, 32, 58, 985, DateTimeKind.Local).AddTicks(8233));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 6, 12, 32, 58, 985, DateTimeKind.Local).AddTicks(8235));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 6, 12, 32, 58, 985, DateTimeKind.Local).AddTicks(8238));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 6, 12, 32, 58, 985, DateTimeKind.Local).AddTicks(8240));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 6, 12, 32, 58, 985, DateTimeKind.Local).AddTicks(8243));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "core",
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "Body", "Subject" },
                values: new object[] { "<p>Dear {ToUserFullName},</p><p>Thank you for submitting the funding for <span style=\"font-weight: bold;\">{NpoName}</span> for the <span style=\"font-weight: bold;\">{FinancialYearName}</span> financial year.</p><p>It has been sent to be approved.</p><p>Please <a href=\"{url}/#/funding-capture\">click here</a> to access the NPO MS application.</p><p>Kind Regards,<br>NPO MS Team</p>", "Funding submitted for Organisation - {NpoName}" });

            migrationBuilder.UpdateData(
                schema: "core",
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "Body", "Subject" },
                values: new object[] { "<p>Dear {ToUserFullName},</p><p>The funding for <span style=\"font-weight: bold;\">{NpoName}</span> for the <span style=\"font-weight: bold;\">{FinancialYearName}</span> financial year has been {action}.</p><p>Please <a href=\"{url}/#/funding-capture\">click here</a> to access the NPO MS application.</p><p>Kind Regards,<br>NPO MS Team</p>", "Funding {StatusName} for Organisation - {NpoName} ({FinancialYearName})" });

            migrationBuilder.UpdateData(
                schema: "core",
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "Body", "Subject" },
                values: new object[] { "<p>Dear {ToUserFullName},</p><p>The funding for <span style=\"font-weight: bold;\">{NpoName}</span> for the <span style=\"font-weight: bold;\">{FinancialYearName}</span> financial year has been sent for you to {action}.</p><p>Please <a href=\"{url}/#/funding-capture\">click here</a> to access the NPO MS application.</p><p>Kind Regards,<br>NPO MS Team</p>", "Funding {StatusName} for Organisation - {NpoName} ({FinancialYearName})" });

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 3, 14, 47, 49, 82, DateTimeKind.Local).AddTicks(8150));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 3, 14, 47, 49, 82, DateTimeKind.Local).AddTicks(8173));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 3, 14, 47, 49, 82, DateTimeKind.Local).AddTicks(8175));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 3, 14, 47, 49, 82, DateTimeKind.Local).AddTicks(8177));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 3, 14, 47, 49, 82, DateTimeKind.Local).AddTicks(8178));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 3, 14, 47, 49, 82, DateTimeKind.Local).AddTicks(8180));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 3, 14, 47, 49, 82, DateTimeKind.Local).AddTicks(8182));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 3, 14, 47, 49, 82, DateTimeKind.Local).AddTicks(8184));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 3, 14, 47, 49, 82, DateTimeKind.Local).AddTicks(8185));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 3, 14, 47, 49, 82, DateTimeKind.Local).AddTicks(8187));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 3, 14, 47, 49, 82, DateTimeKind.Local).AddTicks(8189));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 3, 14, 47, 49, 82, DateTimeKind.Local).AddTicks(8191));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 3, 14, 47, 49, 82, DateTimeKind.Local).AddTicks(8193));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 3, 14, 47, 49, 82, DateTimeKind.Local).AddTicks(8195));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 3, 14, 47, 49, 82, DateTimeKind.Local).AddTicks(8196));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 3, 14, 47, 49, 82, DateTimeKind.Local).AddTicks(8198));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 3, 14, 47, 49, 82, DateTimeKind.Local).AddTicks(8201));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 3, 14, 47, 49, 82, DateTimeKind.Local).AddTicks(8203));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 3, 14, 47, 49, 82, DateTimeKind.Local).AddTicks(8205));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 3, 14, 47, 49, 82, DateTimeKind.Local).AddTicks(8207));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 3, 14, 47, 49, 82, DateTimeKind.Local).AddTicks(8208));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 3, 14, 47, 49, 82, DateTimeKind.Local).AddTicks(8210));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 3, 14, 47, 49, 82, DateTimeKind.Local).AddTicks(8212));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 3, 14, 47, 49, 82, DateTimeKind.Local).AddTicks(8215));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 3, 14, 47, 49, 82, DateTimeKind.Local).AddTicks(8216));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 3, 14, 47, 49, 82, DateTimeKind.Local).AddTicks(8218));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 3, 14, 47, 49, 82, DateTimeKind.Local).AddTicks(8220));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 3, 14, 47, 49, 82, DateTimeKind.Local).AddTicks(8231));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 3, 14, 47, 49, 82, DateTimeKind.Local).AddTicks(8233));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 3, 14, 47, 49, 82, DateTimeKind.Local).AddTicks(8240));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 3, 14, 47, 49, 82, DateTimeKind.Local).AddTicks(8263));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 3, 14, 47, 49, 82, DateTimeKind.Local).AddTicks(8265));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 3, 14, 47, 49, 82, DateTimeKind.Local).AddTicks(9132));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 3, 14, 47, 49, 82, DateTimeKind.Local).AddTicks(9141));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 3, 14, 47, 49, 82, DateTimeKind.Local).AddTicks(9144));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 3, 14, 47, 49, 82, DateTimeKind.Local).AddTicks(9146));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 3, 14, 47, 49, 82, DateTimeKind.Local).AddTicks(9149));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 3, 14, 47, 49, 82, DateTimeKind.Local).AddTicks(9151));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 3, 14, 47, 49, 82, DateTimeKind.Local).AddTicks(9154));
        }
    }
}
