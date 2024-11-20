using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NPOMS.Repository.Migrations
{
    /// <inheritdoc />
    public partial class isaddendum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAddendum",
                schema: "fm",
                table: "FundingDetails",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                schema: "core",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 122,
                column: "CategoryName",
                value: "Budgets");

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 20, 10, 25, 47, 728, DateTimeKind.Local).AddTicks(7567));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 20, 10, 25, 47, 728, DateTimeKind.Local).AddTicks(7598));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 20, 10, 25, 47, 728, DateTimeKind.Local).AddTicks(7601));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 20, 10, 25, 47, 728, DateTimeKind.Local).AddTicks(7603));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 20, 10, 25, 47, 728, DateTimeKind.Local).AddTicks(7605));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 20, 10, 25, 47, 728, DateTimeKind.Local).AddTicks(7608));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 20, 10, 25, 47, 728, DateTimeKind.Local).AddTicks(7610));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 20, 10, 25, 47, 728, DateTimeKind.Local).AddTicks(7612));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 20, 10, 25, 47, 728, DateTimeKind.Local).AddTicks(7614));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 20, 10, 25, 47, 728, DateTimeKind.Local).AddTicks(7616));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 20, 10, 25, 47, 728, DateTimeKind.Local).AddTicks(7618));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 20, 10, 25, 47, 728, DateTimeKind.Local).AddTicks(7621));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 20, 10, 25, 47, 728, DateTimeKind.Local).AddTicks(7623));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 20, 10, 25, 47, 728, DateTimeKind.Local).AddTicks(7625));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 20, 10, 25, 47, 728, DateTimeKind.Local).AddTicks(7627));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 20, 10, 25, 47, 728, DateTimeKind.Local).AddTicks(7630));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 20, 10, 25, 47, 728, DateTimeKind.Local).AddTicks(7632));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 20, 10, 25, 47, 728, DateTimeKind.Local).AddTicks(7634));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 20, 10, 25, 47, 728, DateTimeKind.Local).AddTicks(7636));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 20, 10, 25, 47, 728, DateTimeKind.Local).AddTicks(7639));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 20, 10, 25, 47, 728, DateTimeKind.Local).AddTicks(7641));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 20, 10, 25, 47, 728, DateTimeKind.Local).AddTicks(7653));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 20, 10, 25, 47, 728, DateTimeKind.Local).AddTicks(7655));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 20, 10, 25, 47, 728, DateTimeKind.Local).AddTicks(7657));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 20, 10, 25, 47, 728, DateTimeKind.Local).AddTicks(7659));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 20, 10, 25, 47, 728, DateTimeKind.Local).AddTicks(7661));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 20, 10, 25, 47, 728, DateTimeKind.Local).AddTicks(7664));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 20, 10, 25, 47, 728, DateTimeKind.Local).AddTicks(7666));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 20, 10, 25, 47, 728, DateTimeKind.Local).AddTicks(7668));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 20, 10, 25, 47, 728, DateTimeKind.Local).AddTicks(7679));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 20, 10, 25, 47, 728, DateTimeKind.Local).AddTicks(7693));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 20, 10, 25, 47, 728, DateTimeKind.Local).AddTicks(7695));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 20, 10, 25, 47, 728, DateTimeKind.Local).AddTicks(8464));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 20, 10, 25, 47, 728, DateTimeKind.Local).AddTicks(8469));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 20, 10, 25, 47, 728, DateTimeKind.Local).AddTicks(8473));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 20, 10, 25, 47, 728, DateTimeKind.Local).AddTicks(8476));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 20, 10, 25, 47, 728, DateTimeKind.Local).AddTicks(8479));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 20, 10, 25, 47, 728, DateTimeKind.Local).AddTicks(8482));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 20, 10, 25, 47, 728, DateTimeKind.Local).AddTicks(8485));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "QuestionCategories",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 20, 10, 25, 47, 739, DateTimeKind.Local).AddTicks(5890));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "QuestionSections",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 20, 8, 25, 47, 740, DateTimeKind.Utc).AddTicks(5953));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "QuestionSections",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 20, 8, 25, 47, 740, DateTimeKind.Utc).AddTicks(5955));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "Questions",
                keyColumn: "Id",
                keyValue: 119,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 20, 8, 25, 47, 739, DateTimeKind.Utc).AddTicks(9902));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "Questions",
                keyColumn: "Id",
                keyValue: 120,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 20, 8, 25, 47, 739, DateTimeKind.Utc).AddTicks(9905));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "Questions",
                keyColumn: "Id",
                keyValue: 121,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 20, 8, 25, 47, 739, DateTimeKind.Utc).AddTicks(9907));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "Questions",
                keyColumn: "Id",
                keyValue: 122,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 20, 8, 25, 47, 739, DateTimeKind.Utc).AddTicks(9909));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseOptions",
                keyColumn: "Id",
                keyValue: 97,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 20, 8, 25, 47, 741, DateTimeKind.Utc).AddTicks(1519));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseOptions",
                keyColumn: "Id",
                keyValue: 100,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 20, 8, 25, 47, 741, DateTimeKind.Utc).AddTicks(1523));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseOptions",
                keyColumn: "Id",
                keyValue: 101,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 20, 8, 25, 47, 741, DateTimeKind.Utc).AddTicks(1525));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseOptions",
                keyColumn: "Id",
                keyValue: 102,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 20, 8, 25, 47, 741, DateTimeKind.Utc).AddTicks(1527));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseOptions",
                keyColumn: "Id",
                keyValue: 103,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 20, 8, 25, 47, 741, DateTimeKind.Utc).AddTicks(1528));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 20, 10, 25, 47, 741, DateTimeKind.Local).AddTicks(5242));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 20, 10, 25, 47, 741, DateTimeKind.Local).AddTicks(5265));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 20, 10, 25, 47, 741, DateTimeKind.Local).AddTicks(5267));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 20, 10, 25, 47, 741, DateTimeKind.Local).AddTicks(5269));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 20, 10, 25, 47, 741, DateTimeKind.Local).AddTicks(5271));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseTypes",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 20, 10, 25, 47, 741, DateTimeKind.Local).AddTicks(5274));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseTypes",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 20, 10, 25, 47, 741, DateTimeKind.Local).AddTicks(5276));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseTypes",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 20, 10, 25, 47, 741, DateTimeKind.Local).AddTicks(5278));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseTypes",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 20, 10, 25, 47, 741, DateTimeKind.Local).AddTicks(5280));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseTypes",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 20, 10, 25, 47, 741, DateTimeKind.Local).AddTicks(5281));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAddendum",
                schema: "fm",
                table: "FundingDetails");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 122,
                column: "CategoryName",
                value: "Programme");

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 10, 17, 31, 45, 198, DateTimeKind.Local).AddTicks(6914));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 10, 17, 31, 45, 198, DateTimeKind.Local).AddTicks(6942));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 10, 17, 31, 45, 198, DateTimeKind.Local).AddTicks(6944));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 10, 17, 31, 45, 198, DateTimeKind.Local).AddTicks(6946));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 10, 17, 31, 45, 198, DateTimeKind.Local).AddTicks(6948));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 10, 17, 31, 45, 198, DateTimeKind.Local).AddTicks(6950));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 10, 17, 31, 45, 198, DateTimeKind.Local).AddTicks(6952));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 10, 17, 31, 45, 198, DateTimeKind.Local).AddTicks(6954));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 10, 17, 31, 45, 198, DateTimeKind.Local).AddTicks(6956));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 10, 17, 31, 45, 198, DateTimeKind.Local).AddTicks(6958));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 10, 17, 31, 45, 198, DateTimeKind.Local).AddTicks(6960));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 10, 17, 31, 45, 198, DateTimeKind.Local).AddTicks(6961));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 10, 17, 31, 45, 198, DateTimeKind.Local).AddTicks(6963));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 10, 17, 31, 45, 198, DateTimeKind.Local).AddTicks(6965));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 10, 17, 31, 45, 198, DateTimeKind.Local).AddTicks(7002));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 10, 17, 31, 45, 198, DateTimeKind.Local).AddTicks(7005));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 10, 17, 31, 45, 198, DateTimeKind.Local).AddTicks(7007));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 10, 17, 31, 45, 198, DateTimeKind.Local).AddTicks(7008));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 10, 17, 31, 45, 198, DateTimeKind.Local).AddTicks(7010));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 10, 17, 31, 45, 198, DateTimeKind.Local).AddTicks(7012));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 10, 17, 31, 45, 198, DateTimeKind.Local).AddTicks(7017));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 10, 17, 31, 45, 198, DateTimeKind.Local).AddTicks(7027));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 10, 17, 31, 45, 198, DateTimeKind.Local).AddTicks(7029));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 10, 17, 31, 45, 198, DateTimeKind.Local).AddTicks(7031));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 10, 17, 31, 45, 198, DateTimeKind.Local).AddTicks(7033));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 10, 17, 31, 45, 198, DateTimeKind.Local).AddTicks(7035));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 10, 17, 31, 45, 198, DateTimeKind.Local).AddTicks(7037));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 10, 17, 31, 45, 198, DateTimeKind.Local).AddTicks(7038));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 10, 17, 31, 45, 198, DateTimeKind.Local).AddTicks(7040));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 10, 17, 31, 45, 198, DateTimeKind.Local).AddTicks(7046));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 10, 17, 31, 45, 198, DateTimeKind.Local).AddTicks(7063));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 10, 17, 31, 45, 198, DateTimeKind.Local).AddTicks(7065));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 10, 17, 31, 45, 198, DateTimeKind.Local).AddTicks(7847));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 10, 17, 31, 45, 198, DateTimeKind.Local).AddTicks(7852));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 10, 17, 31, 45, 198, DateTimeKind.Local).AddTicks(7854));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 10, 17, 31, 45, 198, DateTimeKind.Local).AddTicks(7857));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 10, 17, 31, 45, 198, DateTimeKind.Local).AddTicks(7860));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 10, 17, 31, 45, 198, DateTimeKind.Local).AddTicks(7862));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 10, 17, 31, 45, 198, DateTimeKind.Local).AddTicks(7865));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "QuestionCategories",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 10, 17, 31, 45, 204, DateTimeKind.Local).AddTicks(5486));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "QuestionSections",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 10, 15, 31, 45, 205, DateTimeKind.Utc).AddTicks(1991));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "QuestionSections",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 10, 15, 31, 45, 205, DateTimeKind.Utc).AddTicks(1993));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "Questions",
                keyColumn: "Id",
                keyValue: 119,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 10, 15, 31, 45, 204, DateTimeKind.Utc).AddTicks(7429));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "Questions",
                keyColumn: "Id",
                keyValue: 120,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 10, 15, 31, 45, 204, DateTimeKind.Utc).AddTicks(7432));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "Questions",
                keyColumn: "Id",
                keyValue: 121,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 10, 15, 31, 45, 204, DateTimeKind.Utc).AddTicks(7433));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "Questions",
                keyColumn: "Id",
                keyValue: 122,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 10, 15, 31, 45, 204, DateTimeKind.Utc).AddTicks(7434));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseOptions",
                keyColumn: "Id",
                keyValue: 97,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 10, 15, 31, 45, 205, DateTimeKind.Utc).AddTicks(5806));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseOptions",
                keyColumn: "Id",
                keyValue: 100,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 10, 15, 31, 45, 205, DateTimeKind.Utc).AddTicks(5810));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseOptions",
                keyColumn: "Id",
                keyValue: 101,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 10, 15, 31, 45, 205, DateTimeKind.Utc).AddTicks(5811));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseOptions",
                keyColumn: "Id",
                keyValue: 102,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 10, 15, 31, 45, 205, DateTimeKind.Utc).AddTicks(5812));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseOptions",
                keyColumn: "Id",
                keyValue: 103,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 10, 15, 31, 45, 205, DateTimeKind.Utc).AddTicks(5816));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 10, 17, 31, 45, 205, DateTimeKind.Local).AddTicks(8005));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 10, 17, 31, 45, 205, DateTimeKind.Local).AddTicks(8022));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 10, 17, 31, 45, 205, DateTimeKind.Local).AddTicks(8023));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 10, 17, 31, 45, 205, DateTimeKind.Local).AddTicks(8025));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 10, 17, 31, 45, 205, DateTimeKind.Local).AddTicks(8026));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseTypes",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 10, 17, 31, 45, 205, DateTimeKind.Local).AddTicks(8028));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseTypes",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 10, 17, 31, 45, 205, DateTimeKind.Local).AddTicks(8030));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseTypes",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 10, 17, 31, 45, 205, DateTimeKind.Local).AddTicks(8031));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseTypes",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 10, 17, 31, 45, 205, DateTimeKind.Local).AddTicks(8033));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseTypes",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 10, 17, 31, 45, 205, DateTimeKind.Local).AddTicks(8034));
        }
    }
}
