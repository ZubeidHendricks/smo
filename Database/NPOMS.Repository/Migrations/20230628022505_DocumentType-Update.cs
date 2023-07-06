using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NPOMS.Repository.Migrations
{
    public partial class DocumentTypeUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "core",
                table: "DocumentTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "Name",
                value: "Audited Annual Financial Statement");

            migrationBuilder.InsertData(
                schema: "core",
                table: "DocumentTypes",
                columns: new[] { "Id", "Description", "IsActive", "Location", "Name", "UpdatedDateTime", "UpdatedUserId" },
                values: new object[,]
                {
                    { 16, "Organisations last 3 month’s Bank Statements \r\n\r\n(Only applicable for organisations not funded in 2023/24 applying for less than R600 000.00 funding) ", true, "FundApp", "Bank Statements", null, null },
                    { 17, "BAS Entity Form (NPOs funded in 2023/24 only)", true, "FundApp", "BAS Entity Form", null, null },
                    { 18, "Application Declaration", true, "FundApp", "Application Declaration", null, null },
                    { 19, "Schedule A: Enrolment Form", true, "FundApp", "Enrolment Form", null, null }
                });

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 28, 4, 24, 56, 277, DateTimeKind.Local).AddTicks(2611));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 28, 4, 24, 56, 277, DateTimeKind.Local).AddTicks(2613));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 28, 4, 24, 56, 277, DateTimeKind.Local).AddTicks(2615));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 28, 4, 24, 56, 277, DateTimeKind.Local).AddTicks(2616));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 28, 4, 24, 56, 277, DateTimeKind.Local).AddTicks(2618));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 28, 4, 24, 56, 277, DateTimeKind.Local).AddTicks(2619));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 28, 4, 24, 56, 277, DateTimeKind.Local).AddTicks(2620));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 28, 4, 24, 56, 277, DateTimeKind.Local).AddTicks(2622));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 28, 4, 24, 56, 277, DateTimeKind.Local).AddTicks(2623));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 28, 4, 24, 56, 277, DateTimeKind.Local).AddTicks(2624));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 28, 4, 24, 56, 277, DateTimeKind.Local).AddTicks(2625));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 28, 4, 24, 56, 277, DateTimeKind.Local).AddTicks(2627));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 28, 4, 24, 56, 277, DateTimeKind.Local).AddTicks(2628));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 28, 4, 24, 56, 277, DateTimeKind.Local).AddTicks(2629));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 28, 4, 24, 56, 277, DateTimeKind.Local).AddTicks(2631));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 28, 4, 24, 56, 277, DateTimeKind.Local).AddTicks(2632));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 28, 4, 24, 56, 277, DateTimeKind.Local).AddTicks(2633));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 28, 4, 24, 56, 277, DateTimeKind.Local).AddTicks(2634));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 28, 4, 24, 56, 277, DateTimeKind.Local).AddTicks(2639));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 28, 4, 24, 56, 277, DateTimeKind.Local).AddTicks(2640));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 28, 4, 24, 56, 277, DateTimeKind.Local).AddTicks(2646));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 28, 4, 24, 56, 277, DateTimeKind.Local).AddTicks(2648));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 28, 4, 24, 56, 277, DateTimeKind.Local).AddTicks(2653));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 28, 4, 24, 56, 277, DateTimeKind.Local).AddTicks(2674));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 28, 4, 24, 56, 277, DateTimeKind.Local).AddTicks(2675));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 28, 4, 24, 56, 277, DateTimeKind.Local).AddTicks(2676));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 28, 4, 24, 56, 277, DateTimeKind.Local).AddTicks(2677));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 28, 4, 24, 56, 277, DateTimeKind.Local).AddTicks(2678));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 28, 4, 24, 56, 277, DateTimeKind.Local).AddTicks(2680));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 28, 4, 24, 56, 277, DateTimeKind.Local).AddTicks(2681));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 28, 4, 24, 56, 277, DateTimeKind.Local).AddTicks(2682));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 28, 4, 24, 56, 277, DateTimeKind.Local).AddTicks(2683));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 28, 4, 24, 56, 277, DateTimeKind.Local).AddTicks(2500));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 28, 4, 24, 56, 277, DateTimeKind.Local).AddTicks(2520));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 28, 4, 24, 56, 277, DateTimeKind.Local).AddTicks(2522));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 28, 4, 24, 56, 277, DateTimeKind.Local).AddTicks(2524));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 28, 4, 24, 56, 277, DateTimeKind.Local).AddTicks(2526));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 28, 4, 24, 56, 277, DateTimeKind.Local).AddTicks(2527));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 28, 4, 24, 56, 277, DateTimeKind.Local).AddTicks(2529));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "core",
                table: "DocumentTypes",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "DocumentTypes",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "DocumentTypes",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "DocumentTypes",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.UpdateData(
                schema: "core",
                table: "DocumentTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "Name",
                value: "Audited Annual Financial");

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 23, 14, 6, 48, 260, DateTimeKind.Local).AddTicks(1155));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 23, 14, 6, 48, 260, DateTimeKind.Local).AddTicks(1158));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 23, 14, 6, 48, 260, DateTimeKind.Local).AddTicks(1159));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 23, 14, 6, 48, 260, DateTimeKind.Local).AddTicks(1160));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 23, 14, 6, 48, 260, DateTimeKind.Local).AddTicks(1161));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 23, 14, 6, 48, 260, DateTimeKind.Local).AddTicks(1163));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 23, 14, 6, 48, 260, DateTimeKind.Local).AddTicks(1164));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 23, 14, 6, 48, 260, DateTimeKind.Local).AddTicks(1165));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 23, 14, 6, 48, 260, DateTimeKind.Local).AddTicks(1166));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 23, 14, 6, 48, 260, DateTimeKind.Local).AddTicks(1167));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 23, 14, 6, 48, 260, DateTimeKind.Local).AddTicks(1168));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 23, 14, 6, 48, 260, DateTimeKind.Local).AddTicks(1169));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 23, 14, 6, 48, 260, DateTimeKind.Local).AddTicks(1171));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 23, 14, 6, 48, 260, DateTimeKind.Local).AddTicks(1172));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 23, 14, 6, 48, 260, DateTimeKind.Local).AddTicks(1173));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 23, 14, 6, 48, 260, DateTimeKind.Local).AddTicks(1174));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 23, 14, 6, 48, 260, DateTimeKind.Local).AddTicks(1176));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 23, 14, 6, 48, 260, DateTimeKind.Local).AddTicks(1177));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 23, 14, 6, 48, 260, DateTimeKind.Local).AddTicks(1178));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 23, 14, 6, 48, 260, DateTimeKind.Local).AddTicks(1179));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 23, 14, 6, 48, 260, DateTimeKind.Local).AddTicks(1180));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 23, 14, 6, 48, 260, DateTimeKind.Local).AddTicks(1182));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 23, 14, 6, 48, 260, DateTimeKind.Local).AddTicks(1194));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 23, 14, 6, 48, 260, DateTimeKind.Local).AddTicks(1204));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 23, 14, 6, 48, 260, DateTimeKind.Local).AddTicks(1205));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 23, 14, 6, 48, 260, DateTimeKind.Local).AddTicks(1206));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 23, 14, 6, 48, 260, DateTimeKind.Local).AddTicks(1208));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 23, 14, 6, 48, 260, DateTimeKind.Local).AddTicks(1209));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 23, 14, 6, 48, 260, DateTimeKind.Local).AddTicks(1210));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 23, 14, 6, 48, 260, DateTimeKind.Local).AddTicks(1211));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 23, 14, 6, 48, 260, DateTimeKind.Local).AddTicks(1212));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 23, 14, 6, 48, 260, DateTimeKind.Local).AddTicks(1216));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 23, 14, 6, 48, 260, DateTimeKind.Local).AddTicks(1023));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 23, 14, 6, 48, 260, DateTimeKind.Local).AddTicks(1046));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 23, 14, 6, 48, 260, DateTimeKind.Local).AddTicks(1047));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 23, 14, 6, 48, 260, DateTimeKind.Local).AddTicks(1049));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 23, 14, 6, 48, 260, DateTimeKind.Local).AddTicks(1050));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 23, 14, 6, 48, 260, DateTimeKind.Local).AddTicks(1052));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 23, 14, 6, 48, 260, DateTimeKind.Local).AddTicks(1053));
        }
    }
}
