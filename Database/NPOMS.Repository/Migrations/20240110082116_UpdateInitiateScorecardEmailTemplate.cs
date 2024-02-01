using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NPOMS.Repository.Migrations
{
    public partial class UpdateInitiateScorecardEmailTemplate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "core",
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: 24,
                column: "Body",
                value: "<p>Dear {ToUserFullName}</p><p>The Scorecard for <strong>{organisationName}</strong> with reference number <strong>{ApplicationRefNo}</strong> is now available for rating.</p><p>If you are required to rate this workplan, please <a href=\"{url}/#/applications\">click here</a> to access.</p><p>Kind Regards,</p><p>NPO MS Team</p>");

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 10, 10, 21, 13, 385, DateTimeKind.Local).AddTicks(3500));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 10, 10, 21, 13, 385, DateTimeKind.Local).AddTicks(3502));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 10, 10, 21, 13, 385, DateTimeKind.Local).AddTicks(3503));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 10, 10, 21, 13, 385, DateTimeKind.Local).AddTicks(3504));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 10, 10, 21, 13, 385, DateTimeKind.Local).AddTicks(3505));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 10, 10, 21, 13, 385, DateTimeKind.Local).AddTicks(3506));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 10, 10, 21, 13, 385, DateTimeKind.Local).AddTicks(3507));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 10, 10, 21, 13, 385, DateTimeKind.Local).AddTicks(3508));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 10, 10, 21, 13, 385, DateTimeKind.Local).AddTicks(3509));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 10, 10, 21, 13, 385, DateTimeKind.Local).AddTicks(3510));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 10, 10, 21, 13, 385, DateTimeKind.Local).AddTicks(3511));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 10, 10, 21, 13, 385, DateTimeKind.Local).AddTicks(3512));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 10, 10, 21, 13, 385, DateTimeKind.Local).AddTicks(3513));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 10, 10, 21, 13, 385, DateTimeKind.Local).AddTicks(3514));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 10, 10, 21, 13, 385, DateTimeKind.Local).AddTicks(3515));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 10, 10, 21, 13, 385, DateTimeKind.Local).AddTicks(3516));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 10, 10, 21, 13, 385, DateTimeKind.Local).AddTicks(3517));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 10, 10, 21, 13, 385, DateTimeKind.Local).AddTicks(3518));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 10, 10, 21, 13, 385, DateTimeKind.Local).AddTicks(3519));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 10, 10, 21, 13, 385, DateTimeKind.Local).AddTicks(3520));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 10, 10, 21, 13, 385, DateTimeKind.Local).AddTicks(3521));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 10, 10, 21, 13, 385, DateTimeKind.Local).AddTicks(3522));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 10, 10, 21, 13, 385, DateTimeKind.Local).AddTicks(3523));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 10, 10, 21, 13, 385, DateTimeKind.Local).AddTicks(3524));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 10, 10, 21, 13, 385, DateTimeKind.Local).AddTicks(3525));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 10, 10, 21, 13, 385, DateTimeKind.Local).AddTicks(3526));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 10, 10, 21, 13, 385, DateTimeKind.Local).AddTicks(3527));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 10, 10, 21, 13, 385, DateTimeKind.Local).AddTicks(3528));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 10, 10, 21, 13, 385, DateTimeKind.Local).AddTicks(3529));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 10, 10, 21, 13, 385, DateTimeKind.Local).AddTicks(3530));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 10, 10, 21, 13, 385, DateTimeKind.Local).AddTicks(3531));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 10, 10, 21, 13, 385, DateTimeKind.Local).AddTicks(3532));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 10, 10, 21, 13, 385, DateTimeKind.Local).AddTicks(3422));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 10, 10, 21, 13, 385, DateTimeKind.Local).AddTicks(3437));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 10, 10, 21, 13, 385, DateTimeKind.Local).AddTicks(3439));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 10, 10, 21, 13, 385, DateTimeKind.Local).AddTicks(3440));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 10, 10, 21, 13, 385, DateTimeKind.Local).AddTicks(3441));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 10, 10, 21, 13, 385, DateTimeKind.Local).AddTicks(3443));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 10, 10, 21, 13, 385, DateTimeKind.Local).AddTicks(3444));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "core",
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: 24,
                column: "Body",
                value: "<p>Dear {ToUserFullName}</p><p>The Scorecard for application with reference number</p><p><strong>{ApplicationRefNo}</strong> for financial year<strong> {financialYear} </strong> has been initiated.</p><p>Please&nbsp;</p><p><a href=\"{url}/#/applications\">click here</a> to add score card.</p><p>Kind Regards,</p><p>NPO MS Team</p>");

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 10, 0, 20, 2, 903, DateTimeKind.Local).AddTicks(2726));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 10, 0, 20, 2, 903, DateTimeKind.Local).AddTicks(2729));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 10, 0, 20, 2, 903, DateTimeKind.Local).AddTicks(2731));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 10, 0, 20, 2, 903, DateTimeKind.Local).AddTicks(2733));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 10, 0, 20, 2, 903, DateTimeKind.Local).AddTicks(2734));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 10, 0, 20, 2, 903, DateTimeKind.Local).AddTicks(2736));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 10, 0, 20, 2, 903, DateTimeKind.Local).AddTicks(2737));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 10, 0, 20, 2, 903, DateTimeKind.Local).AddTicks(2739));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 10, 0, 20, 2, 903, DateTimeKind.Local).AddTicks(2741));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 10, 0, 20, 2, 903, DateTimeKind.Local).AddTicks(2742));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 10, 0, 20, 2, 903, DateTimeKind.Local).AddTicks(2744));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 10, 0, 20, 2, 903, DateTimeKind.Local).AddTicks(2745));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 10, 0, 20, 2, 903, DateTimeKind.Local).AddTicks(2747));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 10, 0, 20, 2, 903, DateTimeKind.Local).AddTicks(2748));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 10, 0, 20, 2, 903, DateTimeKind.Local).AddTicks(2750));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 10, 0, 20, 2, 903, DateTimeKind.Local).AddTicks(2751));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 10, 0, 20, 2, 903, DateTimeKind.Local).AddTicks(2752));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 10, 0, 20, 2, 903, DateTimeKind.Local).AddTicks(2754));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 10, 0, 20, 2, 903, DateTimeKind.Local).AddTicks(2755));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 10, 0, 20, 2, 903, DateTimeKind.Local).AddTicks(2757));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 10, 0, 20, 2, 903, DateTimeKind.Local).AddTicks(2758));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 10, 0, 20, 2, 903, DateTimeKind.Local).AddTicks(2760));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 10, 0, 20, 2, 903, DateTimeKind.Local).AddTicks(2768));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 10, 0, 20, 2, 903, DateTimeKind.Local).AddTicks(2785));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 10, 0, 20, 2, 903, DateTimeKind.Local).AddTicks(2786));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 10, 0, 20, 2, 903, DateTimeKind.Local).AddTicks(2788));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 10, 0, 20, 2, 903, DateTimeKind.Local).AddTicks(2789));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 10, 0, 20, 2, 903, DateTimeKind.Local).AddTicks(2791));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 10, 0, 20, 2, 903, DateTimeKind.Local).AddTicks(2828));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 10, 0, 20, 2, 903, DateTimeKind.Local).AddTicks(2829));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 10, 0, 20, 2, 903, DateTimeKind.Local).AddTicks(2831));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 10, 0, 20, 2, 903, DateTimeKind.Local).AddTicks(2832));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 10, 0, 20, 2, 903, DateTimeKind.Local).AddTicks(2571));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 10, 0, 20, 2, 903, DateTimeKind.Local).AddTicks(2593));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 10, 0, 20, 2, 903, DateTimeKind.Local).AddTicks(2595));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 10, 0, 20, 2, 903, DateTimeKind.Local).AddTicks(2597));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 10, 0, 20, 2, 903, DateTimeKind.Local).AddTicks(2599));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 10, 0, 20, 2, 903, DateTimeKind.Local).AddTicks(2601));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 10, 0, 20, 2, 903, DateTimeKind.Local).AddTicks(2603));
        }
    }
}
