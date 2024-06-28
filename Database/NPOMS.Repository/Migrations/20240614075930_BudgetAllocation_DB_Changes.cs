using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NPOMS.Repository.Migrations
{
    /// <inheritdoc />
    public partial class BudgetAllocation_DB_Changes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Code",
                schema: "dropdown",
                table: "SubProgrammeTypes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                schema: "dropdown",
                table: "Programmes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "Programmes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Code",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "Programmes",
                keyColumn: "Id",
                keyValue: 2,
                column: "Code",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "Programmes",
                keyColumn: "Id",
                keyValue: 3,
                column: "Code",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "Programmes",
                keyColumn: "Id",
                keyValue: 4,
                column: "Code",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "Programmes",
                keyColumn: "Id",
                keyValue: 5,
                column: "Code",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "Programmes",
                keyColumn: "Id",
                keyValue: 6,
                column: "Code",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "Programmes",
                keyColumn: "Id",
                keyValue: 7,
                column: "Code",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "Programmes",
                keyColumn: "Id",
                keyValue: 8,
                column: "Code",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "Programmes",
                keyColumn: "Id",
                keyValue: 9,
                column: "Code",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "Programmes",
                keyColumn: "Id",
                keyValue: 10,
                column: "Code",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "Programmes",
                keyColumn: "Id",
                keyValue: 11,
                column: "Code",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "Programmes",
                keyColumn: "Id",
                keyValue: 12,
                column: "Code",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "Programmes",
                keyColumn: "Id",
                keyValue: 13,
                column: "Code",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "Programmes",
                keyColumn: "Id",
                keyValue: 14,
                column: "Code",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "Programmes",
                keyColumn: "Id",
                keyValue: 15,
                column: "Code",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "Programmes",
                keyColumn: "Id",
                keyValue: 16,
                column: "Code",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "Programmes",
                keyColumn: "Id",
                keyValue: 17,
                column: "Code",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "Programmes",
                keyColumn: "Id",
                keyValue: 18,
                column: "Code",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "Programmes",
                keyColumn: "Id",
                keyValue: 19,
                column: "Code",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "Programmes",
                keyColumn: "Id",
                keyValue: 20,
                column: "Code",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "Programmes",
                keyColumn: "Id",
                keyValue: 21,
                column: "Code",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "Programmes",
                keyColumn: "Id",
                keyValue: 22,
                column: "Code",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "Programmes",
                keyColumn: "Id",
                keyValue: 25,
                column: "Code",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 14, 9, 59, 22, 992, DateTimeKind.Local).AddTicks(8243));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 14, 9, 59, 22, 992, DateTimeKind.Local).AddTicks(8245));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 14, 9, 59, 22, 992, DateTimeKind.Local).AddTicks(8247));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 14, 9, 59, 22, 992, DateTimeKind.Local).AddTicks(8249));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 14, 9, 59, 22, 992, DateTimeKind.Local).AddTicks(8250));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 14, 9, 59, 22, 992, DateTimeKind.Local).AddTicks(8252));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 14, 9, 59, 22, 992, DateTimeKind.Local).AddTicks(8253));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 14, 9, 59, 22, 992, DateTimeKind.Local).AddTicks(8255));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 14, 9, 59, 22, 992, DateTimeKind.Local).AddTicks(8257));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 14, 9, 59, 22, 992, DateTimeKind.Local).AddTicks(8258));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 14, 9, 59, 22, 992, DateTimeKind.Local).AddTicks(8260));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 14, 9, 59, 22, 992, DateTimeKind.Local).AddTicks(8261));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 14, 9, 59, 22, 992, DateTimeKind.Local).AddTicks(8263));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 14, 9, 59, 22, 992, DateTimeKind.Local).AddTicks(8265));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 14, 9, 59, 22, 992, DateTimeKind.Local).AddTicks(8266));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 14, 9, 59, 22, 992, DateTimeKind.Local).AddTicks(8268));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 14, 9, 59, 22, 992, DateTimeKind.Local).AddTicks(8269));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 14, 9, 59, 22, 992, DateTimeKind.Local).AddTicks(8271));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 14, 9, 59, 22, 992, DateTimeKind.Local).AddTicks(8272));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 14, 9, 59, 22, 992, DateTimeKind.Local).AddTicks(8274));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 14, 9, 59, 22, 992, DateTimeKind.Local).AddTicks(8279));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 14, 9, 59, 22, 992, DateTimeKind.Local).AddTicks(8281));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 14, 9, 59, 22, 992, DateTimeKind.Local).AddTicks(8285));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 14, 9, 59, 22, 992, DateTimeKind.Local).AddTicks(8297));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 14, 9, 59, 22, 992, DateTimeKind.Local).AddTicks(8298));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 14, 9, 59, 22, 992, DateTimeKind.Local).AddTicks(8300));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 14, 9, 59, 22, 992, DateTimeKind.Local).AddTicks(8301));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 14, 9, 59, 22, 992, DateTimeKind.Local).AddTicks(8303));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 14, 9, 59, 22, 992, DateTimeKind.Local).AddTicks(8304));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 14, 9, 59, 22, 992, DateTimeKind.Local).AddTicks(8306));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 14, 9, 59, 22, 992, DateTimeKind.Local).AddTicks(8307));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 14, 9, 59, 22, 992, DateTimeKind.Local).AddTicks(8309));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 14, 9, 59, 22, 992, DateTimeKind.Local).AddTicks(7996));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 14, 9, 59, 22, 992, DateTimeKind.Local).AddTicks(8013));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 14, 9, 59, 22, 992, DateTimeKind.Local).AddTicks(8015));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 14, 9, 59, 22, 992, DateTimeKind.Local).AddTicks(8017));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 14, 9, 59, 22, 992, DateTimeKind.Local).AddTicks(8019));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 14, 9, 59, 22, 992, DateTimeKind.Local).AddTicks(8021));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 14, 9, 59, 22, 992, DateTimeKind.Local).AddTicks(8023));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammeTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Code",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammeTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "Code",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammeTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "Code",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammeTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "Code",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammeTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "Code",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammeTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "Code",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammeTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "Code",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammeTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "Code",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammeTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "Code",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammeTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "Code",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammeTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "Code",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammeTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "Code",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammeTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "Code",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammeTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "Code",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammeTypes",
                keyColumn: "Id",
                keyValue: 15,
                column: "Code",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammeTypes",
                keyColumn: "Id",
                keyValue: 16,
                column: "Code",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammeTypes",
                keyColumn: "Id",
                keyValue: 17,
                column: "Code",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammeTypes",
                keyColumn: "Id",
                keyValue: 18,
                column: "Code",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammeTypes",
                keyColumn: "Id",
                keyValue: 19,
                column: "Code",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammeTypes",
                keyColumn: "Id",
                keyValue: 20,
                column: "Code",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammeTypes",
                keyColumn: "Id",
                keyValue: 21,
                column: "Code",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammeTypes",
                keyColumn: "Id",
                keyValue: 22,
                column: "Code",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammeTypes",
                keyColumn: "Id",
                keyValue: 23,
                column: "Code",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammeTypes",
                keyColumn: "Id",
                keyValue: 24,
                column: "Code",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammeTypes",
                keyColumn: "Id",
                keyValue: 25,
                column: "Code",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammeTypes",
                keyColumn: "Id",
                keyValue: 26,
                column: "Code",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammeTypes",
                keyColumn: "Id",
                keyValue: 27,
                column: "Code",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammeTypes",
                keyColumn: "Id",
                keyValue: 28,
                column: "Code",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammeTypes",
                keyColumn: "Id",
                keyValue: 29,
                column: "Code",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammeTypes",
                keyColumn: "Id",
                keyValue: 30,
                column: "Code",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammeTypes",
                keyColumn: "Id",
                keyValue: 31,
                column: "Code",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammeTypes",
                keyColumn: "Id",
                keyValue: 32,
                column: "Code",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammeTypes",
                keyColumn: "Id",
                keyValue: 33,
                column: "Code",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammeTypes",
                keyColumn: "Id",
                keyValue: 34,
                column: "Code",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammeTypes",
                keyColumn: "Id",
                keyValue: 35,
                column: "Code",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammeTypes",
                keyColumn: "Id",
                keyValue: 36,
                column: "Code",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammeTypes",
                keyColumn: "Id",
                keyValue: 37,
                column: "Code",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammeTypes",
                keyColumn: "Id",
                keyValue: 38,
                column: "Code",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammeTypes",
                keyColumn: "Id",
                keyValue: 39,
                column: "Code",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammeTypes",
                keyColumn: "Id",
                keyValue: 40,
                column: "Code",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammeTypes",
                keyColumn: "Id",
                keyValue: 41,
                column: "Code",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammeTypes",
                keyColumn: "Id",
                keyValue: 42,
                column: "Code",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammeTypes",
                keyColumn: "Id",
                keyValue: 43,
                column: "Code",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammeTypes",
                keyColumn: "Id",
                keyValue: 44,
                column: "Code",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammeTypes",
                keyColumn: "Id",
                keyValue: 45,
                column: "Code",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammeTypes",
                keyColumn: "Id",
                keyValue: 46,
                column: "Code",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammeTypes",
                keyColumn: "Id",
                keyValue: 47,
                column: "Code",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammeTypes",
                keyColumn: "Id",
                keyValue: 48,
                column: "Code",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammeTypes",
                keyColumn: "Id",
                keyValue: 49,
                column: "Code",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammeTypes",
                keyColumn: "Id",
                keyValue: 50,
                column: "Code",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammeTypes",
                keyColumn: "Id",
                keyValue: 51,
                column: "Code",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammeTypes",
                keyColumn: "Id",
                keyValue: 52,
                column: "Code",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammeTypes",
                keyColumn: "Id",
                keyValue: 53,
                column: "Code",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammeTypes",
                keyColumn: "Id",
                keyValue: 54,
                column: "Code",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammeTypes",
                keyColumn: "Id",
                keyValue: 55,
                column: "Code",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammeTypes",
                keyColumn: "Id",
                keyValue: 56,
                column: "Code",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammeTypes",
                keyColumn: "Id",
                keyValue: 57,
                column: "Code",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammeTypes",
                keyColumn: "Id",
                keyValue: 58,
                column: "Code",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammeTypes",
                keyColumn: "Id",
                keyValue: 59,
                column: "Code",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammeTypes",
                keyColumn: "Id",
                keyValue: 60,
                column: "Code",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammeTypes",
                keyColumn: "Id",
                keyValue: 61,
                column: "Code",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammeTypes",
                keyColumn: "Id",
                keyValue: 62,
                column: "Code",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammeTypes",
                keyColumn: "Id",
                keyValue: 63,
                column: "Code",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammeTypes",
                keyColumn: "Id",
                keyValue: 64,
                column: "Code",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammeTypes",
                keyColumn: "Id",
                keyValue: 65,
                column: "Code",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammeTypes",
                keyColumn: "Id",
                keyValue: 66,
                column: "Code",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammeTypes",
                keyColumn: "Id",
                keyValue: 67,
                column: "Code",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammeTypes",
                keyColumn: "Id",
                keyValue: 68,
                column: "Code",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammeTypes",
                keyColumn: "Id",
                keyValue: 69,
                column: "Code",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammeTypes",
                keyColumn: "Id",
                keyValue: 70,
                column: "Code",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammeTypes",
                keyColumn: "Id",
                keyValue: 71,
                column: "Code",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                schema: "dropdown",
                table: "SubProgrammeTypes");

            migrationBuilder.DropColumn(
                name: "Code",
                schema: "dropdown",
                table: "Programmes");

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 11, 41, 12, 504, DateTimeKind.Local).AddTicks(4232));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 11, 41, 12, 504, DateTimeKind.Local).AddTicks(4236));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 11, 41, 12, 504, DateTimeKind.Local).AddTicks(4237));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 11, 41, 12, 504, DateTimeKind.Local).AddTicks(4239));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 11, 41, 12, 504, DateTimeKind.Local).AddTicks(4241));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 11, 41, 12, 504, DateTimeKind.Local).AddTicks(4242));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 11, 41, 12, 504, DateTimeKind.Local).AddTicks(4244));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 11, 41, 12, 504, DateTimeKind.Local).AddTicks(4245));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 11, 41, 12, 504, DateTimeKind.Local).AddTicks(4247));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 11, 41, 12, 504, DateTimeKind.Local).AddTicks(4249));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 11, 41, 12, 504, DateTimeKind.Local).AddTicks(4251));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 11, 41, 12, 504, DateTimeKind.Local).AddTicks(4252));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 11, 41, 12, 504, DateTimeKind.Local).AddTicks(4254));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 11, 41, 12, 504, DateTimeKind.Local).AddTicks(4255));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 11, 41, 12, 504, DateTimeKind.Local).AddTicks(4257));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 11, 41, 12, 504, DateTimeKind.Local).AddTicks(4258));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 11, 41, 12, 504, DateTimeKind.Local).AddTicks(4260));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 11, 41, 12, 504, DateTimeKind.Local).AddTicks(4261));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 11, 41, 12, 504, DateTimeKind.Local).AddTicks(4263));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 11, 41, 12, 504, DateTimeKind.Local).AddTicks(4264));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 11, 41, 12, 504, DateTimeKind.Local).AddTicks(4266));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 11, 41, 12, 504, DateTimeKind.Local).AddTicks(4268));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 11, 41, 12, 504, DateTimeKind.Local).AddTicks(4284));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 11, 41, 12, 504, DateTimeKind.Local).AddTicks(4367));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 11, 41, 12, 504, DateTimeKind.Local).AddTicks(4369));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 11, 41, 12, 504, DateTimeKind.Local).AddTicks(4371));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 11, 41, 12, 504, DateTimeKind.Local).AddTicks(4372));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 11, 41, 12, 504, DateTimeKind.Local).AddTicks(4374));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 11, 41, 12, 504, DateTimeKind.Local).AddTicks(4375));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 11, 41, 12, 504, DateTimeKind.Local).AddTicks(4377));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 11, 41, 12, 504, DateTimeKind.Local).AddTicks(4378));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 11, 41, 12, 504, DateTimeKind.Local).AddTicks(4380));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 11, 41, 12, 504, DateTimeKind.Local).AddTicks(3974));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 11, 41, 12, 504, DateTimeKind.Local).AddTicks(3998));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 11, 41, 12, 504, DateTimeKind.Local).AddTicks(4000));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 11, 41, 12, 504, DateTimeKind.Local).AddTicks(4002));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 11, 41, 12, 504, DateTimeKind.Local).AddTicks(4005));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 11, 41, 12, 504, DateTimeKind.Local).AddTicks(4007));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 11, 41, 12, 504, DateTimeKind.Local).AddTicks(4009));
        }
    }
}
