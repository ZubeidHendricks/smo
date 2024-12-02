using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NPOMS.Repository.Migrations
{
    /// <inheritdoc />
    public partial class VerifyActualUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FinancialYearId",
                table: "VerifyActuals",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IndicatorValue",
                table: "VerifyActuals",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProgrammeId",
                table: "VerifyActuals",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SubProgrammeId",
                table: "VerifyActuals",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SubProgrammeTypeId",
                table: "VerifyActuals",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 12, 1, 22, 0, 26, 355, DateTimeKind.Local).AddTicks(9705));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 12, 1, 22, 0, 26, 355, DateTimeKind.Local).AddTicks(9738));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 12, 1, 22, 0, 26, 355, DateTimeKind.Local).AddTicks(9740));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 12, 1, 22, 0, 26, 355, DateTimeKind.Local).AddTicks(9743));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDateTime",
                value: new DateTime(2024, 12, 1, 22, 0, 26, 355, DateTimeKind.Local).AddTicks(9746));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 12, 1, 22, 0, 26, 355, DateTimeKind.Local).AddTicks(9748));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 12, 1, 22, 0, 26, 355, DateTimeKind.Local).AddTicks(9751));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 12, 1, 22, 0, 26, 355, DateTimeKind.Local).AddTicks(9753));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDateTime",
                value: new DateTime(2024, 12, 1, 22, 0, 26, 355, DateTimeKind.Local).AddTicks(9756));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDateTime",
                value: new DateTime(2024, 12, 1, 22, 0, 26, 355, DateTimeKind.Local).AddTicks(9758));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDateTime",
                value: new DateTime(2024, 12, 1, 22, 0, 26, 355, DateTimeKind.Local).AddTicks(9761));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDateTime",
                value: new DateTime(2024, 12, 1, 22, 0, 26, 355, DateTimeKind.Local).AddTicks(9763));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDateTime",
                value: new DateTime(2024, 12, 1, 22, 0, 26, 355, DateTimeKind.Local).AddTicks(9766));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDateTime",
                value: new DateTime(2024, 12, 1, 22, 0, 26, 355, DateTimeKind.Local).AddTicks(9770));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDateTime",
                value: new DateTime(2024, 12, 1, 22, 0, 26, 355, DateTimeKind.Local).AddTicks(9772));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDateTime",
                value: new DateTime(2024, 12, 1, 22, 0, 26, 355, DateTimeKind.Local).AddTicks(9775));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDateTime",
                value: new DateTime(2024, 12, 1, 22, 0, 26, 355, DateTimeKind.Local).AddTicks(9777));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDateTime",
                value: new DateTime(2024, 12, 1, 22, 0, 26, 355, DateTimeKind.Local).AddTicks(9780));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDateTime",
                value: new DateTime(2024, 12, 1, 22, 0, 26, 355, DateTimeKind.Local).AddTicks(9782));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDateTime",
                value: new DateTime(2024, 12, 1, 22, 0, 26, 355, DateTimeKind.Local).AddTicks(9785));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDateTime",
                value: new DateTime(2024, 12, 1, 22, 0, 26, 355, DateTimeKind.Local).AddTicks(9787));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDateTime",
                value: new DateTime(2024, 12, 1, 22, 0, 26, 355, DateTimeKind.Local).AddTicks(9802));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDateTime",
                value: new DateTime(2024, 12, 1, 22, 0, 26, 355, DateTimeKind.Local).AddTicks(9805));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDateTime",
                value: new DateTime(2024, 12, 1, 22, 0, 26, 355, DateTimeKind.Local).AddTicks(9808));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDateTime",
                value: new DateTime(2024, 12, 1, 22, 0, 26, 355, DateTimeKind.Local).AddTicks(9810));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDateTime",
                value: new DateTime(2024, 12, 1, 22, 0, 26, 355, DateTimeKind.Local).AddTicks(9813));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDateTime",
                value: new DateTime(2024, 12, 1, 22, 0, 26, 355, DateTimeKind.Local).AddTicks(9815));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedDateTime",
                value: new DateTime(2024, 12, 1, 22, 0, 26, 355, DateTimeKind.Local).AddTicks(9818));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedDateTime",
                value: new DateTime(2024, 12, 1, 22, 0, 26, 355, DateTimeKind.Local).AddTicks(9820));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedDateTime",
                value: new DateTime(2024, 12, 1, 22, 0, 26, 355, DateTimeKind.Local).AddTicks(9838));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDateTime",
                value: new DateTime(2024, 12, 1, 22, 0, 26, 355, DateTimeKind.Local).AddTicks(9868));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedDateTime",
                value: new DateTime(2024, 12, 1, 22, 0, 26, 355, DateTimeKind.Local).AddTicks(9871));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 12, 1, 22, 0, 26, 356, DateTimeKind.Local).AddTicks(999));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 12, 1, 22, 0, 26, 356, DateTimeKind.Local).AddTicks(1005));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 12, 1, 22, 0, 26, 356, DateTimeKind.Local).AddTicks(1008));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 12, 1, 22, 0, 26, 356, DateTimeKind.Local).AddTicks(1012));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 12, 1, 22, 0, 26, 356, DateTimeKind.Local).AddTicks(1015));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 12, 1, 22, 0, 26, 356, DateTimeKind.Local).AddTicks(1018));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 12, 1, 22, 0, 26, 356, DateTimeKind.Local).AddTicks(1022));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "QuestionCategories",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDateTime",
                value: new DateTime(2024, 12, 1, 22, 0, 26, 364, DateTimeKind.Local).AddTicks(3412));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "QuestionCategories",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDateTime",
                value: new DateTime(2024, 12, 1, 22, 0, 26, 364, DateTimeKind.Local).AddTicks(3436));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "QuestionSections",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedDateTime",
                value: new DateTime(2024, 12, 1, 20, 0, 26, 365, DateTimeKind.Utc).AddTicks(3547));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "QuestionSections",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedDateTime",
                value: new DateTime(2024, 12, 1, 20, 0, 26, 365, DateTimeKind.Utc).AddTicks(3550));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "QuestionSections",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedDateTime",
                value: new DateTime(2024, 12, 1, 20, 0, 26, 365, DateTimeKind.Utc).AddTicks(3552));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "Questions",
                keyColumn: "Id",
                keyValue: 119,
                column: "CreatedDateTime",
                value: new DateTime(2024, 12, 1, 20, 0, 26, 364, DateTimeKind.Utc).AddTicks(6806));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "Questions",
                keyColumn: "Id",
                keyValue: 120,
                column: "CreatedDateTime",
                value: new DateTime(2024, 12, 1, 20, 0, 26, 364, DateTimeKind.Utc).AddTicks(6809));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "Questions",
                keyColumn: "Id",
                keyValue: 121,
                column: "CreatedDateTime",
                value: new DateTime(2024, 12, 1, 20, 0, 26, 364, DateTimeKind.Utc).AddTicks(6811));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "Questions",
                keyColumn: "Id",
                keyValue: 122,
                column: "CreatedDateTime",
                value: new DateTime(2024, 12, 1, 20, 0, 26, 364, DateTimeKind.Utc).AddTicks(6813));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "Questions",
                keyColumn: "Id",
                keyValue: 123,
                column: "CreatedDateTime",
                value: new DateTime(2024, 12, 1, 20, 0, 26, 364, DateTimeKind.Utc).AddTicks(6815));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "Questions",
                keyColumn: "Id",
                keyValue: 124,
                column: "CreatedDateTime",
                value: new DateTime(2024, 12, 1, 20, 0, 26, 364, DateTimeKind.Utc).AddTicks(6817));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "Questions",
                keyColumn: "Id",
                keyValue: 125,
                column: "CreatedDateTime",
                value: new DateTime(2024, 12, 1, 20, 0, 26, 364, DateTimeKind.Utc).AddTicks(6819));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "Questions",
                keyColumn: "Id",
                keyValue: 126,
                column: "CreatedDateTime",
                value: new DateTime(2024, 12, 1, 20, 0, 26, 364, DateTimeKind.Utc).AddTicks(6821));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "Questions",
                keyColumn: "Id",
                keyValue: 127,
                column: "CreatedDateTime",
                value: new DateTime(2024, 12, 1, 20, 0, 26, 364, DateTimeKind.Utc).AddTicks(6823));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseOptions",
                keyColumn: "Id",
                keyValue: 97,
                column: "CreatedDateTime",
                value: new DateTime(2024, 12, 1, 20, 0, 26, 366, DateTimeKind.Utc).AddTicks(1485));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseOptions",
                keyColumn: "Id",
                keyValue: 100,
                column: "CreatedDateTime",
                value: new DateTime(2024, 12, 1, 20, 0, 26, 366, DateTimeKind.Utc).AddTicks(1491));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseOptions",
                keyColumn: "Id",
                keyValue: 101,
                column: "CreatedDateTime",
                value: new DateTime(2024, 12, 1, 20, 0, 26, 366, DateTimeKind.Utc).AddTicks(1493));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseOptions",
                keyColumn: "Id",
                keyValue: 102,
                column: "CreatedDateTime",
                value: new DateTime(2024, 12, 1, 20, 0, 26, 366, DateTimeKind.Utc).AddTicks(1495));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseOptions",
                keyColumn: "Id",
                keyValue: 103,
                column: "CreatedDateTime",
                value: new DateTime(2024, 12, 1, 20, 0, 26, 366, DateTimeKind.Utc).AddTicks(1497));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDateTime",
                value: new DateTime(2024, 12, 1, 22, 0, 26, 366, DateTimeKind.Local).AddTicks(5750));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDateTime",
                value: new DateTime(2024, 12, 1, 22, 0, 26, 366, DateTimeKind.Local).AddTicks(5773));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDateTime",
                value: new DateTime(2024, 12, 1, 22, 0, 26, 366, DateTimeKind.Local).AddTicks(5775));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDateTime",
                value: new DateTime(2024, 12, 1, 22, 0, 26, 366, DateTimeKind.Local).AddTicks(5777));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDateTime",
                value: new DateTime(2024, 12, 1, 22, 0, 26, 366, DateTimeKind.Local).AddTicks(5779));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseTypes",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDateTime",
                value: new DateTime(2024, 12, 1, 22, 0, 26, 366, DateTimeKind.Local).AddTicks(5781));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseTypes",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDateTime",
                value: new DateTime(2024, 12, 1, 22, 0, 26, 366, DateTimeKind.Local).AddTicks(5783));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseTypes",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDateTime",
                value: new DateTime(2024, 12, 1, 22, 0, 26, 366, DateTimeKind.Local).AddTicks(5785));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseTypes",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDateTime",
                value: new DateTime(2024, 12, 1, 22, 0, 26, 366, DateTimeKind.Local).AddTicks(5787));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseTypes",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDateTime",
                value: new DateTime(2024, 12, 1, 22, 0, 26, 366, DateTimeKind.Local).AddTicks(5789));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FinancialYearId",
                table: "VerifyActuals");

            migrationBuilder.DropColumn(
                name: "IndicatorValue",
                table: "VerifyActuals");

            migrationBuilder.DropColumn(
                name: "ProgrammeId",
                table: "VerifyActuals");

            migrationBuilder.DropColumn(
                name: "SubProgrammeId",
                table: "VerifyActuals");

            migrationBuilder.DropColumn(
                name: "SubProgrammeTypeId",
                table: "VerifyActuals");

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 12, 1, 20, 54, 45, 200, DateTimeKind.Local).AddTicks(792));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 12, 1, 20, 54, 45, 200, DateTimeKind.Local).AddTicks(814));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 12, 1, 20, 54, 45, 200, DateTimeKind.Local).AddTicks(818));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 12, 1, 20, 54, 45, 200, DateTimeKind.Local).AddTicks(822));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDateTime",
                value: new DateTime(2024, 12, 1, 20, 54, 45, 200, DateTimeKind.Local).AddTicks(825));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 12, 1, 20, 54, 45, 200, DateTimeKind.Local).AddTicks(829));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 12, 1, 20, 54, 45, 200, DateTimeKind.Local).AddTicks(832));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 12, 1, 20, 54, 45, 200, DateTimeKind.Local).AddTicks(835));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDateTime",
                value: new DateTime(2024, 12, 1, 20, 54, 45, 200, DateTimeKind.Local).AddTicks(838));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDateTime",
                value: new DateTime(2024, 12, 1, 20, 54, 45, 200, DateTimeKind.Local).AddTicks(841));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDateTime",
                value: new DateTime(2024, 12, 1, 20, 54, 45, 200, DateTimeKind.Local).AddTicks(845));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDateTime",
                value: new DateTime(2024, 12, 1, 20, 54, 45, 200, DateTimeKind.Local).AddTicks(848));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDateTime",
                value: new DateTime(2024, 12, 1, 20, 54, 45, 200, DateTimeKind.Local).AddTicks(851));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDateTime",
                value: new DateTime(2024, 12, 1, 20, 54, 45, 200, DateTimeKind.Local).AddTicks(855));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDateTime",
                value: new DateTime(2024, 12, 1, 20, 54, 45, 200, DateTimeKind.Local).AddTicks(858));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDateTime",
                value: new DateTime(2024, 12, 1, 20, 54, 45, 200, DateTimeKind.Local).AddTicks(861));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDateTime",
                value: new DateTime(2024, 12, 1, 20, 54, 45, 200, DateTimeKind.Local).AddTicks(865));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDateTime",
                value: new DateTime(2024, 12, 1, 20, 54, 45, 200, DateTimeKind.Local).AddTicks(868));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDateTime",
                value: new DateTime(2024, 12, 1, 20, 54, 45, 200, DateTimeKind.Local).AddTicks(872));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDateTime",
                value: new DateTime(2024, 12, 1, 20, 54, 45, 200, DateTimeKind.Local).AddTicks(875));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDateTime",
                value: new DateTime(2024, 12, 1, 20, 54, 45, 200, DateTimeKind.Local).AddTicks(878));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDateTime",
                value: new DateTime(2024, 12, 1, 20, 54, 45, 200, DateTimeKind.Local).AddTicks(881));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDateTime",
                value: new DateTime(2024, 12, 1, 20, 54, 45, 200, DateTimeKind.Local).AddTicks(884));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDateTime",
                value: new DateTime(2024, 12, 1, 20, 54, 45, 200, DateTimeKind.Local).AddTicks(887));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDateTime",
                value: new DateTime(2024, 12, 1, 20, 54, 45, 200, DateTimeKind.Local).AddTicks(891));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDateTime",
                value: new DateTime(2024, 12, 1, 20, 54, 45, 200, DateTimeKind.Local).AddTicks(893));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDateTime",
                value: new DateTime(2024, 12, 1, 20, 54, 45, 200, DateTimeKind.Local).AddTicks(896));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedDateTime",
                value: new DateTime(2024, 12, 1, 20, 54, 45, 200, DateTimeKind.Local).AddTicks(899));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedDateTime",
                value: new DateTime(2024, 12, 1, 20, 54, 45, 200, DateTimeKind.Local).AddTicks(903));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedDateTime",
                value: new DateTime(2024, 12, 1, 20, 54, 45, 200, DateTimeKind.Local).AddTicks(941));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDateTime",
                value: new DateTime(2024, 12, 1, 20, 54, 45, 200, DateTimeKind.Local).AddTicks(982));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedDateTime",
                value: new DateTime(2024, 12, 1, 20, 54, 45, 200, DateTimeKind.Local).AddTicks(986));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 12, 1, 20, 54, 45, 202, DateTimeKind.Local).AddTicks(2580));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 12, 1, 20, 54, 45, 202, DateTimeKind.Local).AddTicks(2603));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 12, 1, 20, 54, 45, 202, DateTimeKind.Local).AddTicks(2607));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 12, 1, 20, 54, 45, 202, DateTimeKind.Local).AddTicks(2611));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 12, 1, 20, 54, 45, 202, DateTimeKind.Local).AddTicks(2616));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 12, 1, 20, 54, 45, 202, DateTimeKind.Local).AddTicks(2620));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 12, 1, 20, 54, 45, 202, DateTimeKind.Local).AddTicks(2624));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "QuestionCategories",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDateTime",
                value: new DateTime(2024, 12, 1, 20, 54, 45, 229, DateTimeKind.Local).AddTicks(1677));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "QuestionCategories",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDateTime",
                value: new DateTime(2024, 12, 1, 20, 54, 45, 229, DateTimeKind.Local).AddTicks(1692));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "QuestionSections",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedDateTime",
                value: new DateTime(2024, 12, 1, 18, 54, 45, 231, DateTimeKind.Utc).AddTicks(7346));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "QuestionSections",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedDateTime",
                value: new DateTime(2024, 12, 1, 18, 54, 45, 231, DateTimeKind.Utc).AddTicks(7355));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "QuestionSections",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedDateTime",
                value: new DateTime(2024, 12, 1, 18, 54, 45, 231, DateTimeKind.Utc).AddTicks(7358));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "Questions",
                keyColumn: "Id",
                keyValue: 119,
                column: "CreatedDateTime",
                value: new DateTime(2024, 12, 1, 18, 54, 45, 230, DateTimeKind.Utc).AddTicks(509));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "Questions",
                keyColumn: "Id",
                keyValue: 120,
                column: "CreatedDateTime",
                value: new DateTime(2024, 12, 1, 18, 54, 45, 230, DateTimeKind.Utc).AddTicks(516));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "Questions",
                keyColumn: "Id",
                keyValue: 121,
                column: "CreatedDateTime",
                value: new DateTime(2024, 12, 1, 18, 54, 45, 230, DateTimeKind.Utc).AddTicks(519));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "Questions",
                keyColumn: "Id",
                keyValue: 122,
                column: "CreatedDateTime",
                value: new DateTime(2024, 12, 1, 18, 54, 45, 230, DateTimeKind.Utc).AddTicks(521));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "Questions",
                keyColumn: "Id",
                keyValue: 123,
                column: "CreatedDateTime",
                value: new DateTime(2024, 12, 1, 18, 54, 45, 230, DateTimeKind.Utc).AddTicks(524));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "Questions",
                keyColumn: "Id",
                keyValue: 124,
                column: "CreatedDateTime",
                value: new DateTime(2024, 12, 1, 18, 54, 45, 230, DateTimeKind.Utc).AddTicks(526));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "Questions",
                keyColumn: "Id",
                keyValue: 125,
                column: "CreatedDateTime",
                value: new DateTime(2024, 12, 1, 18, 54, 45, 230, DateTimeKind.Utc).AddTicks(529));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "Questions",
                keyColumn: "Id",
                keyValue: 126,
                column: "CreatedDateTime",
                value: new DateTime(2024, 12, 1, 18, 54, 45, 230, DateTimeKind.Utc).AddTicks(531));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "Questions",
                keyColumn: "Id",
                keyValue: 127,
                column: "CreatedDateTime",
                value: new DateTime(2024, 12, 1, 18, 54, 45, 230, DateTimeKind.Utc).AddTicks(534));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseOptions",
                keyColumn: "Id",
                keyValue: 97,
                column: "CreatedDateTime",
                value: new DateTime(2024, 12, 1, 18, 54, 45, 233, DateTimeKind.Utc).AddTicks(3002));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseOptions",
                keyColumn: "Id",
                keyValue: 100,
                column: "CreatedDateTime",
                value: new DateTime(2024, 12, 1, 18, 54, 45, 233, DateTimeKind.Utc).AddTicks(3011));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseOptions",
                keyColumn: "Id",
                keyValue: 101,
                column: "CreatedDateTime",
                value: new DateTime(2024, 12, 1, 18, 54, 45, 233, DateTimeKind.Utc).AddTicks(3014));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseOptions",
                keyColumn: "Id",
                keyValue: 102,
                column: "CreatedDateTime",
                value: new DateTime(2024, 12, 1, 18, 54, 45, 233, DateTimeKind.Utc).AddTicks(3016));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseOptions",
                keyColumn: "Id",
                keyValue: 103,
                column: "CreatedDateTime",
                value: new DateTime(2024, 12, 1, 18, 54, 45, 233, DateTimeKind.Utc).AddTicks(3018));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDateTime",
                value: new DateTime(2024, 12, 1, 20, 54, 45, 234, DateTimeKind.Local).AddTicks(2643));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDateTime",
                value: new DateTime(2024, 12, 1, 20, 54, 45, 234, DateTimeKind.Local).AddTicks(2659));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDateTime",
                value: new DateTime(2024, 12, 1, 20, 54, 45, 234, DateTimeKind.Local).AddTicks(2662));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDateTime",
                value: new DateTime(2024, 12, 1, 20, 54, 45, 234, DateTimeKind.Local).AddTicks(2664));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDateTime",
                value: new DateTime(2024, 12, 1, 20, 54, 45, 234, DateTimeKind.Local).AddTicks(2667));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseTypes",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDateTime",
                value: new DateTime(2024, 12, 1, 20, 54, 45, 234, DateTimeKind.Local).AddTicks(2669));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseTypes",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDateTime",
                value: new DateTime(2024, 12, 1, 20, 54, 45, 234, DateTimeKind.Local).AddTicks(2672));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseTypes",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDateTime",
                value: new DateTime(2024, 12, 1, 20, 54, 45, 234, DateTimeKind.Local).AddTicks(2675));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseTypes",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDateTime",
                value: new DateTime(2024, 12, 1, 20, 54, 45, 234, DateTimeKind.Local).AddTicks(2677));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseTypes",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDateTime",
                value: new DateTime(2024, 12, 1, 20, 54, 45, 234, DateTimeKind.Local).AddTicks(2679));
        }
    }
}
