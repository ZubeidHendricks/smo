using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NPOMS.Repository.Migrations
{
    public partial class UpdatedScorecardsEmailTemplates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "core",
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: 23,
                column: "Body",
                value: "<p>Dear {ToUserFullName}</p><p>The Scorecard for application with reference number</p><p><strong>{ApplicationRefNo}</strong> for financial year<strong> {financialYear} </strong> has been completed.</p><p>To view the scorecard summary please&nbsp;</p><p><a href=\"{url}/#/reviewScorecard/{ApplicationId}\">click here</a> to download a printable version.</p><p>Kind Regards,</p><p>NPO MS Team</p>");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: 25,
                column: "Body",
                value: "<p>Dear {ToUserFullName}</p><p>The Scorecard for <strong>{organisationName}</strong> with reference number <strong>{ApplicationRefNo}</strong> requires amendments.</p><p>To make the amendments, please <a href=\"{url}/#/applications/scorecard/{ApplicationId}\">click here</a> to access.</p><p>Kind Regards,</p><p>NPO MS Team</p>");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "Body", "Subject" },
                values: new object[] { "<p>Dear {ToUserFullName}</p><p>The Scorecard for <strong>{organisationName}</strong> with reference number <strong>{ApplicationRefNo}</strong> has been resubmitted.</p><p>To review the amended scorecard, please <a href=\"{url}/#/applications/reviewScorecard/{ApplicationId}\">click here</a> to access.</p><p>Kind Regards,</p><p>NPO MS Team</p>", "Amended Scorecard Notification - {NPO}" });

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 13, 37, 10, 472, DateTimeKind.Local).AddTicks(8376));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 13, 37, 10, 472, DateTimeKind.Local).AddTicks(8377));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 13, 37, 10, 472, DateTimeKind.Local).AddTicks(8379));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 13, 37, 10, 472, DateTimeKind.Local).AddTicks(8380));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 13, 37, 10, 472, DateTimeKind.Local).AddTicks(8381));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 13, 37, 10, 472, DateTimeKind.Local).AddTicks(8382));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 13, 37, 10, 472, DateTimeKind.Local).AddTicks(8383));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 13, 37, 10, 472, DateTimeKind.Local).AddTicks(8384));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 13, 37, 10, 472, DateTimeKind.Local).AddTicks(8385));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 13, 37, 10, 472, DateTimeKind.Local).AddTicks(8386));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 13, 37, 10, 472, DateTimeKind.Local).AddTicks(8387));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 13, 37, 10, 472, DateTimeKind.Local).AddTicks(8388));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 13, 37, 10, 472, DateTimeKind.Local).AddTicks(8389));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 13, 37, 10, 472, DateTimeKind.Local).AddTicks(8389));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 13, 37, 10, 472, DateTimeKind.Local).AddTicks(8390));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 13, 37, 10, 472, DateTimeKind.Local).AddTicks(8391));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 13, 37, 10, 472, DateTimeKind.Local).AddTicks(8392));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 13, 37, 10, 472, DateTimeKind.Local).AddTicks(8397));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 13, 37, 10, 472, DateTimeKind.Local).AddTicks(8399));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 13, 37, 10, 472, DateTimeKind.Local).AddTicks(8400));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 13, 37, 10, 472, DateTimeKind.Local).AddTicks(8401));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 13, 37, 10, 472, DateTimeKind.Local).AddTicks(8402));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 13, 37, 10, 472, DateTimeKind.Local).AddTicks(8408));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 13, 37, 10, 472, DateTimeKind.Local).AddTicks(8423));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 13, 37, 10, 472, DateTimeKind.Local).AddTicks(8424));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 13, 37, 10, 472, DateTimeKind.Local).AddTicks(8425));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 13, 37, 10, 472, DateTimeKind.Local).AddTicks(8426));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 13, 37, 10, 472, DateTimeKind.Local).AddTicks(8427));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 13, 37, 10, 472, DateTimeKind.Local).AddTicks(8428));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 13, 37, 10, 472, DateTimeKind.Local).AddTicks(8429));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 13, 37, 10, 472, DateTimeKind.Local).AddTicks(8430));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 13, 37, 10, 472, DateTimeKind.Local).AddTicks(8431));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 13, 37, 10, 472, DateTimeKind.Local).AddTicks(8295));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 13, 37, 10, 472, DateTimeKind.Local).AddTicks(8311));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 13, 37, 10, 472, DateTimeKind.Local).AddTicks(8313));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 13, 37, 10, 472, DateTimeKind.Local).AddTicks(8314));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 13, 37, 10, 472, DateTimeKind.Local).AddTicks(8316));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 13, 37, 10, 472, DateTimeKind.Local).AddTicks(8317));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 13, 37, 10, 472, DateTimeKind.Local).AddTicks(8318));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "core",
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: 23,
                column: "Body",
                value: "<p>Dear {ToUserFullName}</p><p>The Scorecard for application with reference number</p><p><strong>{ApplicationRefNo}</strong> for financial year<strong> {financialYear} </strong> has been completed.</p><p>To view the scorecard summary please&nbsp;</p><p><a href=\"{url}/#/reviewScorecard/{npoId}(print:print/{npoId}/2)\">click here</a> to download a printable version.</p><p>Kind Regards,</p><p>NPO MS Team</p>");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: 25,
                column: "Body",
                value: "<p>Dear {ToUserFullName}</p><p>The Scorecard for <strong>{organisationName}</strong> with reference number <strong>{ApplicationRefNo}</strong> requires amendments.</p><p>To make the amendments, please <a href=\"{url}/#/applications\">click here</a> to access.</p><p>Kind Regards,</p><p>NPO MS Team</p>");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "Body", "Subject" },
                values: new object[] { "<p>Dear {ToUserFullName}</p><p>The Scorecard for <strong>{organisationName}</strong> with reference number <strong>{ApplicationRefNo}</strong> has been resubmitted.</p><p>To review the amended scorecard, please <a href=\"{url}/#/applications\">click here</a> to access.</p><p>Kind Regards,</p><p>NPO MS Team</p>", "Scorecard Amendment Notification - {NPO}" });

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 13, 19, 21, 160, DateTimeKind.Local).AddTicks(3282));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 13, 19, 21, 160, DateTimeKind.Local).AddTicks(3287));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 13, 19, 21, 160, DateTimeKind.Local).AddTicks(3290));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 13, 19, 21, 160, DateTimeKind.Local).AddTicks(3292));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 13, 19, 21, 160, DateTimeKind.Local).AddTicks(3295));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 13, 19, 21, 160, DateTimeKind.Local).AddTicks(3297));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 13, 19, 21, 160, DateTimeKind.Local).AddTicks(3300));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 13, 19, 21, 160, DateTimeKind.Local).AddTicks(3302));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 13, 19, 21, 160, DateTimeKind.Local).AddTicks(3305));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 13, 19, 21, 160, DateTimeKind.Local).AddTicks(3309));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 13, 19, 21, 160, DateTimeKind.Local).AddTicks(3312));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 13, 19, 21, 160, DateTimeKind.Local).AddTicks(3314));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 13, 19, 21, 160, DateTimeKind.Local).AddTicks(3317));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 13, 19, 21, 160, DateTimeKind.Local).AddTicks(3319));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 13, 19, 21, 160, DateTimeKind.Local).AddTicks(3322));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 13, 19, 21, 160, DateTimeKind.Local).AddTicks(3324));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 13, 19, 21, 160, DateTimeKind.Local).AddTicks(3326));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 13, 19, 21, 160, DateTimeKind.Local).AddTicks(3328));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 13, 19, 21, 160, DateTimeKind.Local).AddTicks(3331));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 13, 19, 21, 160, DateTimeKind.Local).AddTicks(3333));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 13, 19, 21, 160, DateTimeKind.Local).AddTicks(3342));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 13, 19, 21, 160, DateTimeKind.Local).AddTicks(3344));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 13, 19, 21, 160, DateTimeKind.Local).AddTicks(3353));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 13, 19, 21, 160, DateTimeKind.Local).AddTicks(3380));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 13, 19, 21, 160, DateTimeKind.Local).AddTicks(3382));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 13, 19, 21, 160, DateTimeKind.Local).AddTicks(3384));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 13, 19, 21, 160, DateTimeKind.Local).AddTicks(3387));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 13, 19, 21, 160, DateTimeKind.Local).AddTicks(3389));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 13, 19, 21, 160, DateTimeKind.Local).AddTicks(3391));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 13, 19, 21, 160, DateTimeKind.Local).AddTicks(3393));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 13, 19, 21, 160, DateTimeKind.Local).AddTicks(3395));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 13, 19, 21, 160, DateTimeKind.Local).AddTicks(3398));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 13, 19, 21, 160, DateTimeKind.Local).AddTicks(3065));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 13, 19, 21, 160, DateTimeKind.Local).AddTicks(3097));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 13, 19, 21, 160, DateTimeKind.Local).AddTicks(3101));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 13, 19, 21, 160, DateTimeKind.Local).AddTicks(3104));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 13, 19, 21, 160, DateTimeKind.Local).AddTicks(3107));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 13, 19, 21, 160, DateTimeKind.Local).AddTicks(3110));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 13, 19, 21, 160, DateTimeKind.Local).AddTicks(3113));
        }
    }
}
