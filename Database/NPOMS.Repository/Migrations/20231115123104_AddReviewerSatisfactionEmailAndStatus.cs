using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NPOMS.Repository.Migrations
{
    public partial class AddReviewerSatisfactionEmailAndStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "core",
                table: "EmailTemplates",
                columns: new[] { "Id", "Body", "Description", "Name", "Subject" },
                values: new object[] { 22, "<p>Dear {ToUserFullName},</p><p>The application with Reference Number <span style=\"font-weight: bold;\">{ApplicationRefNo}</span> has been sent to you to indicate your reviewer satisfaction.</p><p>Please ignore this email if you have indicated your reviewer satisfaction.</p><p>Please <a href=\"{url}/#/applications\">click here</a> to access the NPO MS application.</p><p>Kind Regards,<br>NPO MS Team</p>", null, "StatusChangedPendingReviewerSatisfaction", "Application Pending Reviewer Satisfaction - {NPO}" });

            migrationBuilder.UpdateData(
                schema: "core",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 112,
                column: "CategoryName",
                value: "AddScorecard");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 113,
                column: "CategoryName",
                value: "ReviewScorecard");

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2023, 11, 15, 14, 30, 56, 904, DateTimeKind.Local).AddTicks(8942));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2023, 11, 15, 14, 30, 56, 904, DateTimeKind.Local).AddTicks(8944));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2023, 11, 15, 14, 30, 56, 904, DateTimeKind.Local).AddTicks(8946));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2023, 11, 15, 14, 30, 56, 904, DateTimeKind.Local).AddTicks(8947));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDateTime",
                value: new DateTime(2023, 11, 15, 14, 30, 56, 904, DateTimeKind.Local).AddTicks(8948));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2023, 11, 15, 14, 30, 56, 904, DateTimeKind.Local).AddTicks(8949));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2023, 11, 15, 14, 30, 56, 904, DateTimeKind.Local).AddTicks(8951));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2023, 11, 15, 14, 30, 56, 904, DateTimeKind.Local).AddTicks(8952));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDateTime",
                value: new DateTime(2023, 11, 15, 14, 30, 56, 904, DateTimeKind.Local).AddTicks(8953));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDateTime",
                value: new DateTime(2023, 11, 15, 14, 30, 56, 904, DateTimeKind.Local).AddTicks(8954));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDateTime",
                value: new DateTime(2023, 11, 15, 14, 30, 56, 904, DateTimeKind.Local).AddTicks(8956));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDateTime",
                value: new DateTime(2023, 11, 15, 14, 30, 56, 904, DateTimeKind.Local).AddTicks(8957));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDateTime",
                value: new DateTime(2023, 11, 15, 14, 30, 56, 904, DateTimeKind.Local).AddTicks(8958));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDateTime",
                value: new DateTime(2023, 11, 15, 14, 30, 56, 904, DateTimeKind.Local).AddTicks(8959));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDateTime",
                value: new DateTime(2023, 11, 15, 14, 30, 56, 904, DateTimeKind.Local).AddTicks(8960));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDateTime",
                value: new DateTime(2023, 11, 15, 14, 30, 56, 904, DateTimeKind.Local).AddTicks(8962));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDateTime",
                value: new DateTime(2023, 11, 15, 14, 30, 56, 904, DateTimeKind.Local).AddTicks(8963));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDateTime",
                value: new DateTime(2023, 11, 15, 14, 30, 56, 904, DateTimeKind.Local).AddTicks(8964));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDateTime",
                value: new DateTime(2023, 11, 15, 14, 30, 56, 904, DateTimeKind.Local).AddTicks(8965));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDateTime",
                value: new DateTime(2023, 11, 15, 14, 30, 56, 904, DateTimeKind.Local).AddTicks(8966));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDateTime",
                value: new DateTime(2023, 11, 15, 14, 30, 56, 904, DateTimeKind.Local).AddTicks(8979));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDateTime",
                value: new DateTime(2023, 11, 15, 14, 30, 56, 904, DateTimeKind.Local).AddTicks(8980));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDateTime",
                value: new DateTime(2023, 11, 15, 14, 30, 56, 904, DateTimeKind.Local).AddTicks(8985));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDateTime",
                value: new DateTime(2023, 11, 15, 14, 30, 56, 904, DateTimeKind.Local).AddTicks(9000));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDateTime",
                value: new DateTime(2023, 11, 15, 14, 30, 56, 904, DateTimeKind.Local).AddTicks(9001));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDateTime",
                value: new DateTime(2023, 11, 15, 14, 30, 56, 904, DateTimeKind.Local).AddTicks(9002));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDateTime",
                value: new DateTime(2023, 11, 15, 14, 30, 56, 904, DateTimeKind.Local).AddTicks(9004));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedDateTime",
                value: new DateTime(2023, 11, 15, 14, 30, 56, 904, DateTimeKind.Local).AddTicks(9005));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedDateTime",
                value: new DateTime(2023, 11, 15, 14, 30, 56, 904, DateTimeKind.Local).AddTicks(9006));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedDateTime",
                value: new DateTime(2023, 11, 15, 14, 30, 56, 904, DateTimeKind.Local).AddTicks(9007));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDateTime",
                value: new DateTime(2023, 11, 15, 14, 30, 56, 904, DateTimeKind.Local).AddTicks(9008));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedDateTime",
                value: new DateTime(2023, 11, 15, 14, 30, 56, 904, DateTimeKind.Local).AddTicks(9009));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2023, 11, 15, 14, 30, 56, 904, DateTimeKind.Local).AddTicks(8835));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2023, 11, 15, 14, 30, 56, 904, DateTimeKind.Local).AddTicks(8854));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2023, 11, 15, 14, 30, 56, 904, DateTimeKind.Local).AddTicks(8856));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2023, 11, 15, 14, 30, 56, 904, DateTimeKind.Local).AddTicks(8858));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2023, 11, 15, 14, 30, 56, 904, DateTimeKind.Local).AddTicks(8859));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2023, 11, 15, 14, 30, 56, 904, DateTimeKind.Local).AddTicks(8861));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2023, 11, 15, 14, 30, 56, 904, DateTimeKind.Local).AddTicks(8863));

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Statuses",
                columns: new[] { "Id", "Name", "SystemName", "UpdatedDateTime", "UpdatedUserId" },
                values: new object[] { 23, "Pending Reviewer Satisfaction", "PendingReviewerSatisfaction", null, null });

            migrationBuilder.CreateIndex(
                name: "IX_Responses_CreatedUserId",
                schema: "eval",
                table: "Responses",
                column: "CreatedUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Responses_Users_CreatedUserId",
                schema: "eval",
                table: "Responses",
                column: "CreatedUserId",
                principalSchema: "core",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Responses_Users_CreatedUserId",
                schema: "eval",
                table: "Responses");

            migrationBuilder.DropIndex(
                name: "IX_Responses_CreatedUserId",
                schema: "eval",
                table: "Responses");

            migrationBuilder.DeleteData(
                schema: "core",
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Statuses",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.UpdateData(
                schema: "core",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 112,
                column: "CategoryName",
                value: "Scorecard");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 113,
                column: "CategoryName",
                value: "Scorecard");

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2023, 11, 7, 10, 6, 41, 665, DateTimeKind.Local).AddTicks(2444));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2023, 11, 7, 10, 6, 41, 665, DateTimeKind.Local).AddTicks(2447));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2023, 11, 7, 10, 6, 41, 665, DateTimeKind.Local).AddTicks(2449));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2023, 11, 7, 10, 6, 41, 665, DateTimeKind.Local).AddTicks(2451));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDateTime",
                value: new DateTime(2023, 11, 7, 10, 6, 41, 665, DateTimeKind.Local).AddTicks(2452));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2023, 11, 7, 10, 6, 41, 665, DateTimeKind.Local).AddTicks(2454));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2023, 11, 7, 10, 6, 41, 665, DateTimeKind.Local).AddTicks(2455));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2023, 11, 7, 10, 6, 41, 665, DateTimeKind.Local).AddTicks(2644));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDateTime",
                value: new DateTime(2023, 11, 7, 10, 6, 41, 665, DateTimeKind.Local).AddTicks(2660));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDateTime",
                value: new DateTime(2023, 11, 7, 10, 6, 41, 665, DateTimeKind.Local).AddTicks(2662));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDateTime",
                value: new DateTime(2023, 11, 7, 10, 6, 41, 665, DateTimeKind.Local).AddTicks(2664));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDateTime",
                value: new DateTime(2023, 11, 7, 10, 6, 41, 665, DateTimeKind.Local).AddTicks(2666));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDateTime",
                value: new DateTime(2023, 11, 7, 10, 6, 41, 665, DateTimeKind.Local).AddTicks(2667));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDateTime",
                value: new DateTime(2023, 11, 7, 10, 6, 41, 665, DateTimeKind.Local).AddTicks(2669));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDateTime",
                value: new DateTime(2023, 11, 7, 10, 6, 41, 665, DateTimeKind.Local).AddTicks(2670));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDateTime",
                value: new DateTime(2023, 11, 7, 10, 6, 41, 665, DateTimeKind.Local).AddTicks(2672));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDateTime",
                value: new DateTime(2023, 11, 7, 10, 6, 41, 665, DateTimeKind.Local).AddTicks(2673));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDateTime",
                value: new DateTime(2023, 11, 7, 10, 6, 41, 665, DateTimeKind.Local).AddTicks(2675));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDateTime",
                value: new DateTime(2023, 11, 7, 10, 6, 41, 665, DateTimeKind.Local).AddTicks(2676));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDateTime",
                value: new DateTime(2023, 11, 7, 10, 6, 41, 665, DateTimeKind.Local).AddTicks(2678));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDateTime",
                value: new DateTime(2023, 11, 7, 10, 6, 41, 665, DateTimeKind.Local).AddTicks(2680));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDateTime",
                value: new DateTime(2023, 11, 7, 10, 6, 41, 665, DateTimeKind.Local).AddTicks(2700));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDateTime",
                value: new DateTime(2023, 11, 7, 10, 6, 41, 665, DateTimeKind.Local).AddTicks(2715));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDateTime",
                value: new DateTime(2023, 11, 7, 10, 6, 41, 665, DateTimeKind.Local).AddTicks(2717));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDateTime",
                value: new DateTime(2023, 11, 7, 10, 6, 41, 665, DateTimeKind.Local).AddTicks(2718));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDateTime",
                value: new DateTime(2023, 11, 7, 10, 6, 41, 665, DateTimeKind.Local).AddTicks(2720));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDateTime",
                value: new DateTime(2023, 11, 7, 10, 6, 41, 665, DateTimeKind.Local).AddTicks(2721));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedDateTime",
                value: new DateTime(2023, 11, 7, 10, 6, 41, 665, DateTimeKind.Local).AddTicks(2723));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedDateTime",
                value: new DateTime(2023, 11, 7, 10, 6, 41, 665, DateTimeKind.Local).AddTicks(2724));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedDateTime",
                value: new DateTime(2023, 11, 7, 10, 6, 41, 665, DateTimeKind.Local).AddTicks(2726));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDateTime",
                value: new DateTime(2023, 11, 7, 10, 6, 41, 665, DateTimeKind.Local).AddTicks(2727));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedDateTime",
                value: new DateTime(2023, 11, 7, 10, 6, 41, 665, DateTimeKind.Local).AddTicks(2728));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2023, 11, 7, 10, 6, 41, 665, DateTimeKind.Local).AddTicks(2148));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2023, 11, 7, 10, 6, 41, 665, DateTimeKind.Local).AddTicks(2175));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2023, 11, 7, 10, 6, 41, 665, DateTimeKind.Local).AddTicks(2178));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2023, 11, 7, 10, 6, 41, 665, DateTimeKind.Local).AddTicks(2179));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2023, 11, 7, 10, 6, 41, 665, DateTimeKind.Local).AddTicks(2181));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2023, 11, 7, 10, 6, 41, 665, DateTimeKind.Local).AddTicks(2183));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2023, 11, 7, 10, 6, 41, 665, DateTimeKind.Local).AddTicks(2185));
        }
    }
}
