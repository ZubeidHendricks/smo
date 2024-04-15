using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NPOMS.Repository.Migrations
{
    public partial class Add_AmmendedScorecardEmailTemplate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "core",
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "Body", "Subject" },
                values: new object[] { "<p>Dear {ToUserFullName}</p><p>The Scorecard for <strong>{organisationName}</strong> with reference number <strong>{ApplicationRefNo}</strong> requires amendments.</p><p>To make the amendments, please <a href=\"{url}/#/applications\">click here</a> to access.</p><p>Kind Regards,</p><p>NPO MS Team</p>", "Scorecard Amendment Notification - {NPO}" });

            migrationBuilder.InsertData(
                schema: "core",
                table: "EmailTemplates",
                columns: new[] { "Id", "Body", "Description", "Name", "Subject" },
                values: new object[] { 26, "<p>Dear {ToUserFullName}</p><p>The Scorecard for <strong>{organisationName}</strong> with reference number <strong>{ApplicationRefNo}</strong> has been resubmitted.</p><p>To review the amended scorecard, please <a href=\"{url}/#/applications\">click here</a> to access.</p><p>Kind Regards,</p><p>NPO MS Team</p>", null, "AmendedScorecard", "Scorecard Amendment Notification - {NPO}" });

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 3, 28, 10, 32, 44, 418, DateTimeKind.Local).AddTicks(170));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 3, 28, 10, 32, 44, 418, DateTimeKind.Local).AddTicks(174));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 3, 28, 10, 32, 44, 418, DateTimeKind.Local).AddTicks(176));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 3, 28, 10, 32, 44, 418, DateTimeKind.Local).AddTicks(178));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDateTime",
                value: new DateTime(2024, 3, 28, 10, 32, 44, 418, DateTimeKind.Local).AddTicks(180));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 3, 28, 10, 32, 44, 418, DateTimeKind.Local).AddTicks(182));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 3, 28, 10, 32, 44, 418, DateTimeKind.Local).AddTicks(184));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 3, 28, 10, 32, 44, 418, DateTimeKind.Local).AddTicks(186));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDateTime",
                value: new DateTime(2024, 3, 28, 10, 32, 44, 418, DateTimeKind.Local).AddTicks(188));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDateTime",
                value: new DateTime(2024, 3, 28, 10, 32, 44, 418, DateTimeKind.Local).AddTicks(190));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDateTime",
                value: new DateTime(2024, 3, 28, 10, 32, 44, 418, DateTimeKind.Local).AddTicks(192));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDateTime",
                value: new DateTime(2024, 3, 28, 10, 32, 44, 418, DateTimeKind.Local).AddTicks(194));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDateTime",
                value: new DateTime(2024, 3, 28, 10, 32, 44, 418, DateTimeKind.Local).AddTicks(196));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDateTime",
                value: new DateTime(2024, 3, 28, 10, 32, 44, 418, DateTimeKind.Local).AddTicks(197));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDateTime",
                value: new DateTime(2024, 3, 28, 10, 32, 44, 418, DateTimeKind.Local).AddTicks(199));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDateTime",
                value: new DateTime(2024, 3, 28, 10, 32, 44, 418, DateTimeKind.Local).AddTicks(201));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDateTime",
                value: new DateTime(2024, 3, 28, 10, 32, 44, 418, DateTimeKind.Local).AddTicks(203));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDateTime",
                value: new DateTime(2024, 3, 28, 10, 32, 44, 418, DateTimeKind.Local).AddTicks(205));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDateTime",
                value: new DateTime(2024, 3, 28, 10, 32, 44, 418, DateTimeKind.Local).AddTicks(207));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDateTime",
                value: new DateTime(2024, 3, 28, 10, 32, 44, 418, DateTimeKind.Local).AddTicks(209));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDateTime",
                value: new DateTime(2024, 3, 28, 10, 32, 44, 418, DateTimeKind.Local).AddTicks(211));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDateTime",
                value: new DateTime(2024, 3, 28, 10, 32, 44, 418, DateTimeKind.Local).AddTicks(213));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDateTime",
                value: new DateTime(2024, 3, 28, 10, 32, 44, 418, DateTimeKind.Local).AddTicks(214));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDateTime",
                value: new DateTime(2024, 3, 28, 10, 32, 44, 418, DateTimeKind.Local).AddTicks(216));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDateTime",
                value: new DateTime(2024, 3, 28, 10, 32, 44, 418, DateTimeKind.Local).AddTicks(218));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDateTime",
                value: new DateTime(2024, 3, 28, 10, 32, 44, 418, DateTimeKind.Local).AddTicks(220));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDateTime",
                value: new DateTime(2024, 3, 28, 10, 32, 44, 418, DateTimeKind.Local).AddTicks(222));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedDateTime",
                value: new DateTime(2024, 3, 28, 10, 32, 44, 418, DateTimeKind.Local).AddTicks(224));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedDateTime",
                value: new DateTime(2024, 3, 28, 10, 32, 44, 418, DateTimeKind.Local).AddTicks(226));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedDateTime",
                value: new DateTime(2024, 3, 28, 10, 32, 44, 418, DateTimeKind.Local).AddTicks(228));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDateTime",
                value: new DateTime(2024, 3, 28, 10, 32, 44, 418, DateTimeKind.Local).AddTicks(230));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedDateTime",
                value: new DateTime(2024, 3, 28, 10, 32, 44, 418, DateTimeKind.Local).AddTicks(231));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 3, 28, 10, 32, 44, 417, DateTimeKind.Local).AddTicks(9969));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 3, 28, 10, 32, 44, 418, DateTimeKind.Local).AddTicks(27));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 3, 28, 10, 32, 44, 418, DateTimeKind.Local).AddTicks(30));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 3, 28, 10, 32, 44, 418, DateTimeKind.Local).AddTicks(32));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 3, 28, 10, 32, 44, 418, DateTimeKind.Local).AddTicks(70));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 3, 28, 10, 32, 44, 418, DateTimeKind.Local).AddTicks(72));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 3, 28, 10, 32, 44, 418, DateTimeKind.Local).AddTicks(75));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "core",
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.UpdateData(
                schema: "core",
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "Body", "Subject" },
                values: new object[] { "<p>Dear {ToUserFullName}</p><p>The Scorecard for <strong>{organisationName}</strong> with reference number <strong>{ApplicationRefNo}</strong> has been rejected.</p><p>To review the rejection, please <a href=\"{url}/#/applications\">click here</a> to access.</p><p>Kind Regards,</p><p>NPO MS Team</p>", "Scorecard Rejected Notification - {NPO}" });

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 3, 25, 13, 59, 25, 439, DateTimeKind.Local).AddTicks(1426));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 3, 25, 13, 59, 25, 439, DateTimeKind.Local).AddTicks(1428));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 3, 25, 13, 59, 25, 439, DateTimeKind.Local).AddTicks(1435));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 3, 25, 13, 59, 25, 439, DateTimeKind.Local).AddTicks(1436));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDateTime",
                value: new DateTime(2024, 3, 25, 13, 59, 25, 439, DateTimeKind.Local).AddTicks(1437));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 3, 25, 13, 59, 25, 439, DateTimeKind.Local).AddTicks(1438));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 3, 25, 13, 59, 25, 439, DateTimeKind.Local).AddTicks(1439));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 3, 25, 13, 59, 25, 439, DateTimeKind.Local).AddTicks(1440));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDateTime",
                value: new DateTime(2024, 3, 25, 13, 59, 25, 439, DateTimeKind.Local).AddTicks(1441));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDateTime",
                value: new DateTime(2024, 3, 25, 13, 59, 25, 439, DateTimeKind.Local).AddTicks(1442));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDateTime",
                value: new DateTime(2024, 3, 25, 13, 59, 25, 439, DateTimeKind.Local).AddTicks(1443));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDateTime",
                value: new DateTime(2024, 3, 25, 13, 59, 25, 439, DateTimeKind.Local).AddTicks(1444));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDateTime",
                value: new DateTime(2024, 3, 25, 13, 59, 25, 439, DateTimeKind.Local).AddTicks(1445));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDateTime",
                value: new DateTime(2024, 3, 25, 13, 59, 25, 439, DateTimeKind.Local).AddTicks(1446));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDateTime",
                value: new DateTime(2024, 3, 25, 13, 59, 25, 439, DateTimeKind.Local).AddTicks(1447));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDateTime",
                value: new DateTime(2024, 3, 25, 13, 59, 25, 439, DateTimeKind.Local).AddTicks(1448));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDateTime",
                value: new DateTime(2024, 3, 25, 13, 59, 25, 439, DateTimeKind.Local).AddTicks(1449));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDateTime",
                value: new DateTime(2024, 3, 25, 13, 59, 25, 439, DateTimeKind.Local).AddTicks(1453));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDateTime",
                value: new DateTime(2024, 3, 25, 13, 59, 25, 439, DateTimeKind.Local).AddTicks(1455));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDateTime",
                value: new DateTime(2024, 3, 25, 13, 59, 25, 439, DateTimeKind.Local).AddTicks(1456));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDateTime",
                value: new DateTime(2024, 3, 25, 13, 59, 25, 439, DateTimeKind.Local).AddTicks(1457));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDateTime",
                value: new DateTime(2024, 3, 25, 13, 59, 25, 439, DateTimeKind.Local).AddTicks(1458));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDateTime",
                value: new DateTime(2024, 3, 25, 13, 59, 25, 439, DateTimeKind.Local).AddTicks(1465));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDateTime",
                value: new DateTime(2024, 3, 25, 13, 59, 25, 439, DateTimeKind.Local).AddTicks(1477));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDateTime",
                value: new DateTime(2024, 3, 25, 13, 59, 25, 439, DateTimeKind.Local).AddTicks(1478));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDateTime",
                value: new DateTime(2024, 3, 25, 13, 59, 25, 439, DateTimeKind.Local).AddTicks(1479));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDateTime",
                value: new DateTime(2024, 3, 25, 13, 59, 25, 439, DateTimeKind.Local).AddTicks(1479));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedDateTime",
                value: new DateTime(2024, 3, 25, 13, 59, 25, 439, DateTimeKind.Local).AddTicks(1480));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedDateTime",
                value: new DateTime(2024, 3, 25, 13, 59, 25, 439, DateTimeKind.Local).AddTicks(1481));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedDateTime",
                value: new DateTime(2024, 3, 25, 13, 59, 25, 439, DateTimeKind.Local).AddTicks(1482));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDateTime",
                value: new DateTime(2024, 3, 25, 13, 59, 25, 439, DateTimeKind.Local).AddTicks(1483));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedDateTime",
                value: new DateTime(2024, 3, 25, 13, 59, 25, 439, DateTimeKind.Local).AddTicks(1484));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 3, 25, 13, 59, 25, 439, DateTimeKind.Local).AddTicks(1336));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 3, 25, 13, 59, 25, 439, DateTimeKind.Local).AddTicks(1354));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 3, 25, 13, 59, 25, 439, DateTimeKind.Local).AddTicks(1356));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 3, 25, 13, 59, 25, 439, DateTimeKind.Local).AddTicks(1357));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 3, 25, 13, 59, 25, 439, DateTimeKind.Local).AddTicks(1358));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 3, 25, 13, 59, 25, 439, DateTimeKind.Local).AddTicks(1359));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 3, 25, 13, 59, 25, 439, DateTimeKind.Local).AddTicks(1361));
        }
    }
}
