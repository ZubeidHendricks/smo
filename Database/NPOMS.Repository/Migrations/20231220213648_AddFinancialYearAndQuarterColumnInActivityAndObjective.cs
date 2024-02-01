using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NPOMS.Repository.Migrations
{
    public partial class AddFinancialYearAndQuarterColumnInActivityAndObjective : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FinantialYear",
                schema: "dbo",
                table: "Objectives",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Quarter",
                schema: "dbo",
                table: "Objectives",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FinantialYear",
                schema: "dbo",
                table: "Activities",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Quarter",
                schema: "dbo",
                table: "Activities",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                schema: "dropdown",
                table: "ApplicationTypes",
                columns: new[] { "Id", "Name", "SystemName", "UpdatedDateTime", "UpdatedUserId" },
                values: new object[] { 4, "Business Plan", "BP", null, null });

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 20, 23, 36, 39, 480, DateTimeKind.Local).AddTicks(2894));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 20, 23, 36, 39, 480, DateTimeKind.Local).AddTicks(2896));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 20, 23, 36, 39, 480, DateTimeKind.Local).AddTicks(2898));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 20, 23, 36, 39, 480, DateTimeKind.Local).AddTicks(2899));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 20, 23, 36, 39, 480, DateTimeKind.Local).AddTicks(2901));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 20, 23, 36, 39, 480, DateTimeKind.Local).AddTicks(2902));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 20, 23, 36, 39, 480, DateTimeKind.Local).AddTicks(2903));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 20, 23, 36, 39, 480, DateTimeKind.Local).AddTicks(2904));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 20, 23, 36, 39, 480, DateTimeKind.Local).AddTicks(2905));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 20, 23, 36, 39, 480, DateTimeKind.Local).AddTicks(2907));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 20, 23, 36, 39, 480, DateTimeKind.Local).AddTicks(2908));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 20, 23, 36, 39, 480, DateTimeKind.Local).AddTicks(2909));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 20, 23, 36, 39, 480, DateTimeKind.Local).AddTicks(2910));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 20, 23, 36, 39, 480, DateTimeKind.Local).AddTicks(2912));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 20, 23, 36, 39, 480, DateTimeKind.Local).AddTicks(2913));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 20, 23, 36, 39, 480, DateTimeKind.Local).AddTicks(2914));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 20, 23, 36, 39, 480, DateTimeKind.Local).AddTicks(2915));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 20, 23, 36, 39, 480, DateTimeKind.Local).AddTicks(2916));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 20, 23, 36, 39, 480, DateTimeKind.Local).AddTicks(2918));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 20, 23, 36, 39, 480, DateTimeKind.Local).AddTicks(2919));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 20, 23, 36, 39, 480, DateTimeKind.Local).AddTicks(2928));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 20, 23, 36, 39, 480, DateTimeKind.Local).AddTicks(2930));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 20, 23, 36, 39, 480, DateTimeKind.Local).AddTicks(2935));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 20, 23, 36, 39, 480, DateTimeKind.Local).AddTicks(2957));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 20, 23, 36, 39, 480, DateTimeKind.Local).AddTicks(2958));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 20, 23, 36, 39, 480, DateTimeKind.Local).AddTicks(2959));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 20, 23, 36, 39, 480, DateTimeKind.Local).AddTicks(2960));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 20, 23, 36, 39, 480, DateTimeKind.Local).AddTicks(2962));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 20, 23, 36, 39, 480, DateTimeKind.Local).AddTicks(2963));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 20, 23, 36, 39, 480, DateTimeKind.Local).AddTicks(2964));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 20, 23, 36, 39, 480, DateTimeKind.Local).AddTicks(2965));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 20, 23, 36, 39, 480, DateTimeKind.Local).AddTicks(2966));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 20, 23, 36, 39, 480, DateTimeKind.Local).AddTicks(2792));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 20, 23, 36, 39, 480, DateTimeKind.Local).AddTicks(2812));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 20, 23, 36, 39, 480, DateTimeKind.Local).AddTicks(2814));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 20, 23, 36, 39, 480, DateTimeKind.Local).AddTicks(2816));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 20, 23, 36, 39, 480, DateTimeKind.Local).AddTicks(2818));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 20, 23, 36, 39, 480, DateTimeKind.Local).AddTicks(2819));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 20, 23, 36, 39, 480, DateTimeKind.Local).AddTicks(2821));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "ApplicationTypes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "FinantialYear",
                schema: "dbo",
                table: "Objectives");

            migrationBuilder.DropColumn(
                name: "Quarter",
                schema: "dbo",
                table: "Objectives");

            migrationBuilder.DropColumn(
                name: "FinantialYear",
                schema: "dbo",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "Quarter",
                schema: "dbo",
                table: "Activities");

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 10, 22, 27, 43, 578, DateTimeKind.Local).AddTicks(8172));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 10, 22, 27, 43, 578, DateTimeKind.Local).AddTicks(8174));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 10, 22, 27, 43, 578, DateTimeKind.Local).AddTicks(8176));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 10, 22, 27, 43, 578, DateTimeKind.Local).AddTicks(8177));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 10, 22, 27, 43, 578, DateTimeKind.Local).AddTicks(8178));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 10, 22, 27, 43, 578, DateTimeKind.Local).AddTicks(8179));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 10, 22, 27, 43, 578, DateTimeKind.Local).AddTicks(8180));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 10, 22, 27, 43, 578, DateTimeKind.Local).AddTicks(8181));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 10, 22, 27, 43, 578, DateTimeKind.Local).AddTicks(8181));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 10, 22, 27, 43, 578, DateTimeKind.Local).AddTicks(8182));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 10, 22, 27, 43, 578, DateTimeKind.Local).AddTicks(8183));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 10, 22, 27, 43, 578, DateTimeKind.Local).AddTicks(8184));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 10, 22, 27, 43, 578, DateTimeKind.Local).AddTicks(8185));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 10, 22, 27, 43, 578, DateTimeKind.Local).AddTicks(8186));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 10, 22, 27, 43, 578, DateTimeKind.Local).AddTicks(8187));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 10, 22, 27, 43, 578, DateTimeKind.Local).AddTicks(8188));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 10, 22, 27, 43, 578, DateTimeKind.Local).AddTicks(8189));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 10, 22, 27, 43, 578, DateTimeKind.Local).AddTicks(8190));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 10, 22, 27, 43, 578, DateTimeKind.Local).AddTicks(8191));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 10, 22, 27, 43, 578, DateTimeKind.Local).AddTicks(8192));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 10, 22, 27, 43, 578, DateTimeKind.Local).AddTicks(8193));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 10, 22, 27, 43, 578, DateTimeKind.Local).AddTicks(8226));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 10, 22, 27, 43, 578, DateTimeKind.Local).AddTicks(8228));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 10, 22, 27, 43, 578, DateTimeKind.Local).AddTicks(8229));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 10, 22, 27, 43, 578, DateTimeKind.Local).AddTicks(8230));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 10, 22, 27, 43, 578, DateTimeKind.Local).AddTicks(8231));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 10, 22, 27, 43, 578, DateTimeKind.Local).AddTicks(8232));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 10, 22, 27, 43, 578, DateTimeKind.Local).AddTicks(8233));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 10, 22, 27, 43, 578, DateTimeKind.Local).AddTicks(8234));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 10, 22, 27, 43, 578, DateTimeKind.Local).AddTicks(8235));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 10, 22, 27, 43, 578, DateTimeKind.Local).AddTicks(8236));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 10, 22, 27, 43, 578, DateTimeKind.Local).AddTicks(8237));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 10, 22, 27, 43, 578, DateTimeKind.Local).AddTicks(8093));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 10, 22, 27, 43, 578, DateTimeKind.Local).AddTicks(8108));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 10, 22, 27, 43, 578, DateTimeKind.Local).AddTicks(8109));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 10, 22, 27, 43, 578, DateTimeKind.Local).AddTicks(8110));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 10, 22, 27, 43, 578, DateTimeKind.Local).AddTicks(8112));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 10, 22, 27, 43, 578, DateTimeKind.Local).AddTicks(8113));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 10, 22, 27, 43, 578, DateTimeKind.Local).AddTicks(8114));
        }
    }
}
