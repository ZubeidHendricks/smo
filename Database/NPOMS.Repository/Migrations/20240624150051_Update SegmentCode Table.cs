using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NPOMS.Repository.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSegmentCodeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SubProgramId",
                schema: "mapping",
                table: "Segment_Code",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 24, 17, 0, 44, 960, DateTimeKind.Local).AddTicks(1963));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 24, 17, 0, 44, 960, DateTimeKind.Local).AddTicks(1968));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 24, 17, 0, 44, 960, DateTimeKind.Local).AddTicks(1971));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 24, 17, 0, 44, 960, DateTimeKind.Local).AddTicks(1974));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 24, 17, 0, 44, 960, DateTimeKind.Local).AddTicks(1977));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 24, 17, 0, 44, 960, DateTimeKind.Local).AddTicks(1980));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 24, 17, 0, 44, 960, DateTimeKind.Local).AddTicks(1983));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 24, 17, 0, 44, 960, DateTimeKind.Local).AddTicks(1986));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 24, 17, 0, 44, 960, DateTimeKind.Local).AddTicks(1990));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 24, 17, 0, 44, 960, DateTimeKind.Local).AddTicks(1993));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 24, 17, 0, 44, 960, DateTimeKind.Local).AddTicks(2044));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 24, 17, 0, 44, 960, DateTimeKind.Local).AddTicks(2047));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 24, 17, 0, 44, 960, DateTimeKind.Local).AddTicks(2050));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 24, 17, 0, 44, 960, DateTimeKind.Local).AddTicks(2053));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 24, 17, 0, 44, 960, DateTimeKind.Local).AddTicks(2071));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 24, 17, 0, 44, 960, DateTimeKind.Local).AddTicks(2074));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 24, 17, 0, 44, 960, DateTimeKind.Local).AddTicks(2076));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 24, 17, 0, 44, 960, DateTimeKind.Local).AddTicks(2079));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 24, 17, 0, 44, 960, DateTimeKind.Local).AddTicks(2082));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 24, 17, 0, 44, 960, DateTimeKind.Local).AddTicks(2085));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 24, 17, 0, 44, 960, DateTimeKind.Local).AddTicks(2088));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 24, 17, 0, 44, 960, DateTimeKind.Local).AddTicks(2091));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 24, 17, 0, 44, 960, DateTimeKind.Local).AddTicks(2101));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 24, 17, 0, 44, 960, DateTimeKind.Local).AddTicks(2124));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 24, 17, 0, 44, 960, DateTimeKind.Local).AddTicks(2128));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 24, 17, 0, 44, 960, DateTimeKind.Local).AddTicks(2131));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 24, 17, 0, 44, 960, DateTimeKind.Local).AddTicks(2133));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 24, 17, 0, 44, 960, DateTimeKind.Local).AddTicks(2136));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 24, 17, 0, 44, 960, DateTimeKind.Local).AddTicks(2139));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 24, 17, 0, 44, 960, DateTimeKind.Local).AddTicks(2142));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 24, 17, 0, 44, 960, DateTimeKind.Local).AddTicks(2144));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 24, 17, 0, 44, 960, DateTimeKind.Local).AddTicks(2147));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 24, 17, 0, 44, 960, DateTimeKind.Local).AddTicks(1768));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 24, 17, 0, 44, 960, DateTimeKind.Local).AddTicks(1800));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 24, 17, 0, 44, 960, DateTimeKind.Local).AddTicks(1805));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 24, 17, 0, 44, 960, DateTimeKind.Local).AddTicks(1809));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 24, 17, 0, 44, 960, DateTimeKind.Local).AddTicks(1813));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 24, 17, 0, 44, 960, DateTimeKind.Local).AddTicks(1818));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 24, 17, 0, 44, 960, DateTimeKind.Local).AddTicks(1822));

            migrationBuilder.UpdateData(
                schema: "mapping",
                table: "Segment_Code",
                keyColumn: "Id",
                keyValue: 1,
                column: "SubProgramId",
                value: 16);

            migrationBuilder.UpdateData(
                schema: "mapping",
                table: "Segment_Code",
                keyColumn: "Id",
                keyValue: 2,
                column: "SubProgramId",
                value: 17);

            migrationBuilder.UpdateData(
                schema: "mapping",
                table: "Segment_Code",
                keyColumn: "Id",
                keyValue: 3,
                column: "SubProgramId",
                value: 20);

            migrationBuilder.UpdateData(
                schema: "mapping",
                table: "Segment_Code",
                keyColumn: "Id",
                keyValue: 4,
                column: "SubProgramId",
                value: 24);

            migrationBuilder.UpdateData(
                schema: "mapping",
                table: "Segment_Code",
                keyColumn: "Id",
                keyValue: 5,
                column: "SubProgramId",
                value: 25);

            migrationBuilder.UpdateData(
                schema: "mapping",
                table: "Segment_Code",
                keyColumn: "Id",
                keyValue: 6,
                column: "SubProgramId",
                value: 38);

            migrationBuilder.UpdateData(
                schema: "mapping",
                table: "Segment_Code",
                keyColumn: "Id",
                keyValue: 7,
                column: "SubProgramId",
                value: 38);

            migrationBuilder.UpdateData(
                schema: "mapping",
                table: "Segment_Code",
                keyColumn: "Id",
                keyValue: 8,
                column: "SubProgramId",
                value: 40);

            migrationBuilder.UpdateData(
                schema: "mapping",
                table: "Segment_Code",
                keyColumn: "Id",
                keyValue: 9,
                column: "SubProgramId",
                value: 41);

            migrationBuilder.UpdateData(
                schema: "mapping",
                table: "Segment_Code",
                keyColumn: "Id",
                keyValue: 10,
                column: "SubProgramId",
                value: 44);

            migrationBuilder.UpdateData(
                schema: "mapping",
                table: "Segment_Code",
                keyColumn: "Id",
                keyValue: 11,
                column: "SubProgramId",
                value: 46);

            migrationBuilder.UpdateData(
                schema: "mapping",
                table: "Segment_Code",
                keyColumn: "Id",
                keyValue: 12,
                column: "SubProgramId",
                value: 47);

            migrationBuilder.UpdateData(
                schema: "mapping",
                table: "Segment_Code",
                keyColumn: "Id",
                keyValue: 13,
                column: "SubProgramId",
                value: 48);

            migrationBuilder.UpdateData(
                schema: "mapping",
                table: "Segment_Code",
                keyColumn: "Id",
                keyValue: 14,
                column: "SubProgramId",
                value: 55);

            migrationBuilder.UpdateData(
                schema: "mapping",
                table: "Segment_Code",
                keyColumn: "Id",
                keyValue: 15,
                column: "SubProgramId",
                value: 56);

            migrationBuilder.UpdateData(
                schema: "mapping",
                table: "Segment_Code",
                keyColumn: "Id",
                keyValue: 16,
                column: "SubProgramId",
                value: 56);

            migrationBuilder.UpdateData(
                schema: "mapping",
                table: "Segment_Code",
                keyColumn: "Id",
                keyValue: 17,
                column: "SubProgramId",
                value: 56);

            migrationBuilder.UpdateData(
                schema: "mapping",
                table: "Segment_Code",
                keyColumn: "Id",
                keyValue: 18,
                column: "SubProgramId",
                value: 56);

            migrationBuilder.UpdateData(
                schema: "mapping",
                table: "Segment_Code",
                keyColumn: "Id",
                keyValue: 19,
                column: "SubProgramId",
                value: 57);

            migrationBuilder.UpdateData(
                schema: "mapping",
                table: "Segment_Code",
                keyColumn: "Id",
                keyValue: 20,
                column: "SubProgramId",
                value: 58);

            migrationBuilder.UpdateData(
                schema: "mapping",
                table: "Segment_Code",
                keyColumn: "Id",
                keyValue: 21,
                column: "SubProgramId",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "mapping",
                table: "Segment_Code",
                keyColumn: "Id",
                keyValue: 22,
                column: "SubProgramId",
                value: 63);

            migrationBuilder.UpdateData(
                schema: "mapping",
                table: "Segment_Code",
                keyColumn: "Id",
                keyValue: 23,
                column: "SubProgramId",
                value: 65);

            migrationBuilder.UpdateData(
                schema: "mapping",
                table: "Segment_Code",
                keyColumn: "Id",
                keyValue: 24,
                column: "SubProgramId",
                value: 55);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubProgramId",
                schema: "mapping",
                table: "Segment_Code");

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 24, 11, 4, 19, 738, DateTimeKind.Local).AddTicks(6445));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 24, 11, 4, 19, 738, DateTimeKind.Local).AddTicks(6459));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 24, 11, 4, 19, 738, DateTimeKind.Local).AddTicks(6462));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 24, 11, 4, 19, 738, DateTimeKind.Local).AddTicks(6466));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 24, 11, 4, 19, 738, DateTimeKind.Local).AddTicks(6469));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 24, 11, 4, 19, 738, DateTimeKind.Local).AddTicks(6472));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 24, 11, 4, 19, 738, DateTimeKind.Local).AddTicks(6476));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 24, 11, 4, 19, 738, DateTimeKind.Local).AddTicks(6479));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 24, 11, 4, 19, 738, DateTimeKind.Local).AddTicks(6482));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 24, 11, 4, 19, 738, DateTimeKind.Local).AddTicks(6485));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 24, 11, 4, 19, 738, DateTimeKind.Local).AddTicks(6488));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 24, 11, 4, 19, 738, DateTimeKind.Local).AddTicks(6492));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 24, 11, 4, 19, 738, DateTimeKind.Local).AddTicks(6495));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 24, 11, 4, 19, 738, DateTimeKind.Local).AddTicks(6498));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 24, 11, 4, 19, 738, DateTimeKind.Local).AddTicks(6539));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 24, 11, 4, 19, 738, DateTimeKind.Local).AddTicks(6545));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 24, 11, 4, 19, 738, DateTimeKind.Local).AddTicks(6548));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 24, 11, 4, 19, 738, DateTimeKind.Local).AddTicks(6552));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 24, 11, 4, 19, 738, DateTimeKind.Local).AddTicks(6555));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 24, 11, 4, 19, 738, DateTimeKind.Local).AddTicks(6558));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 24, 11, 4, 19, 738, DateTimeKind.Local).AddTicks(6562));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 24, 11, 4, 19, 738, DateTimeKind.Local).AddTicks(6565));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 24, 11, 4, 19, 738, DateTimeKind.Local).AddTicks(6577));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 24, 11, 4, 19, 738, DateTimeKind.Local).AddTicks(6620));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 24, 11, 4, 19, 738, DateTimeKind.Local).AddTicks(6624));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 24, 11, 4, 19, 738, DateTimeKind.Local).AddTicks(6627));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 24, 11, 4, 19, 738, DateTimeKind.Local).AddTicks(6631));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 24, 11, 4, 19, 738, DateTimeKind.Local).AddTicks(6634));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 24, 11, 4, 19, 738, DateTimeKind.Local).AddTicks(6637));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 24, 11, 4, 19, 738, DateTimeKind.Local).AddTicks(6641));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 24, 11, 4, 19, 738, DateTimeKind.Local).AddTicks(6644));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 24, 11, 4, 19, 738, DateTimeKind.Local).AddTicks(6647));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 24, 11, 4, 19, 738, DateTimeKind.Local).AddTicks(5763));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 24, 11, 4, 19, 738, DateTimeKind.Local).AddTicks(5802));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 24, 11, 4, 19, 738, DateTimeKind.Local).AddTicks(5809));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 24, 11, 4, 19, 738, DateTimeKind.Local).AddTicks(5815));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 24, 11, 4, 19, 738, DateTimeKind.Local).AddTicks(5820));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 24, 11, 4, 19, 738, DateTimeKind.Local).AddTicks(5826));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 24, 11, 4, 19, 738, DateTimeKind.Local).AddTicks(5831));
        }
    }
}
