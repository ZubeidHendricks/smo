using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NPOMS.Repository.Migrations
{
    /// <inheritdoc />
    public partial class FinancialYearId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FinancialYear",
                schema: "dbo",
                table: "PostReports",
                newName: "FinancialYearId");

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 28, 13, 40, 56, 805, DateTimeKind.Local).AddTicks(7749));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 28, 13, 40, 56, 805, DateTimeKind.Local).AddTicks(7764));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 28, 13, 40, 56, 805, DateTimeKind.Local).AddTicks(7766));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 28, 13, 40, 56, 805, DateTimeKind.Local).AddTicks(7768));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 28, 13, 40, 56, 805, DateTimeKind.Local).AddTicks(7770));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 28, 13, 40, 56, 805, DateTimeKind.Local).AddTicks(7771));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 28, 13, 40, 56, 805, DateTimeKind.Local).AddTicks(7773));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 28, 13, 40, 56, 805, DateTimeKind.Local).AddTicks(7775));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 28, 13, 40, 56, 805, DateTimeKind.Local).AddTicks(7776));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 28, 13, 40, 56, 805, DateTimeKind.Local).AddTicks(7778));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 28, 13, 40, 56, 805, DateTimeKind.Local).AddTicks(7780));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 28, 13, 40, 56, 805, DateTimeKind.Local).AddTicks(7781));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 28, 13, 40, 56, 805, DateTimeKind.Local).AddTicks(7783));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 28, 13, 40, 56, 805, DateTimeKind.Local).AddTicks(7784));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 28, 13, 40, 56, 805, DateTimeKind.Local).AddTicks(7786));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 28, 13, 40, 56, 805, DateTimeKind.Local).AddTicks(7787));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 28, 13, 40, 56, 805, DateTimeKind.Local).AddTicks(7789));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 28, 13, 40, 56, 805, DateTimeKind.Local).AddTicks(7791));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 28, 13, 40, 56, 805, DateTimeKind.Local).AddTicks(7792));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 28, 13, 40, 56, 805, DateTimeKind.Local).AddTicks(7794));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 28, 13, 40, 56, 805, DateTimeKind.Local).AddTicks(7795));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 28, 13, 40, 56, 805, DateTimeKind.Local).AddTicks(7797));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 28, 13, 40, 56, 805, DateTimeKind.Local).AddTicks(7798));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 28, 13, 40, 56, 805, DateTimeKind.Local).AddTicks(7800));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 28, 13, 40, 56, 805, DateTimeKind.Local).AddTicks(7801));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 28, 13, 40, 56, 805, DateTimeKind.Local).AddTicks(7803));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 28, 13, 40, 56, 805, DateTimeKind.Local).AddTicks(7805));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 28, 13, 40, 56, 805, DateTimeKind.Local).AddTicks(7811));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 28, 13, 40, 56, 805, DateTimeKind.Local).AddTicks(7812));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 28, 13, 40, 56, 805, DateTimeKind.Local).AddTicks(7848));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 28, 13, 40, 56, 805, DateTimeKind.Local).AddTicks(7861));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 28, 13, 40, 56, 805, DateTimeKind.Local).AddTicks(7863));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 28, 13, 40, 56, 805, DateTimeKind.Local).AddTicks(8365));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 28, 13, 40, 56, 805, DateTimeKind.Local).AddTicks(8369));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 28, 13, 40, 56, 805, DateTimeKind.Local).AddTicks(8372));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 28, 13, 40, 56, 805, DateTimeKind.Local).AddTicks(8374));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 28, 13, 40, 56, 805, DateTimeKind.Local).AddTicks(8376));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 28, 13, 40, 56, 805, DateTimeKind.Local).AddTicks(8378));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 28, 13, 40, 56, 805, DateTimeKind.Local).AddTicks(8380));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FinancialYearId",
                schema: "dbo",
                table: "PostReports",
                newName: "FinancialYear");

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 1, 15, 51, 766, DateTimeKind.Local).AddTicks(7629));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 1, 15, 51, 766, DateTimeKind.Local).AddTicks(7688));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 1, 15, 51, 766, DateTimeKind.Local).AddTicks(7692));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 1, 15, 51, 766, DateTimeKind.Local).AddTicks(7693));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 1, 15, 51, 766, DateTimeKind.Local).AddTicks(7695));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 1, 15, 51, 766, DateTimeKind.Local).AddTicks(7697));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 1, 15, 51, 766, DateTimeKind.Local).AddTicks(7698));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 1, 15, 51, 766, DateTimeKind.Local).AddTicks(7700));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 1, 15, 51, 766, DateTimeKind.Local).AddTicks(7701));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 1, 15, 51, 766, DateTimeKind.Local).AddTicks(7703));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 1, 15, 51, 766, DateTimeKind.Local).AddTicks(7705));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 1, 15, 51, 766, DateTimeKind.Local).AddTicks(7706));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 1, 15, 51, 766, DateTimeKind.Local).AddTicks(7708));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 1, 15, 51, 766, DateTimeKind.Local).AddTicks(7709));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 1, 15, 51, 766, DateTimeKind.Local).AddTicks(7711));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 1, 15, 51, 766, DateTimeKind.Local).AddTicks(7712));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 1, 15, 51, 766, DateTimeKind.Local).AddTicks(7715));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 1, 15, 51, 766, DateTimeKind.Local).AddTicks(7716));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 1, 15, 51, 766, DateTimeKind.Local).AddTicks(7718));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 1, 15, 51, 766, DateTimeKind.Local).AddTicks(7719));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 1, 15, 51, 766, DateTimeKind.Local).AddTicks(7721));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 1, 15, 51, 766, DateTimeKind.Local).AddTicks(7722));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 1, 15, 51, 766, DateTimeKind.Local).AddTicks(7724));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 1, 15, 51, 766, DateTimeKind.Local).AddTicks(7725));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 1, 15, 51, 766, DateTimeKind.Local).AddTicks(7727));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 1, 15, 51, 766, DateTimeKind.Local).AddTicks(7729));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 1, 15, 51, 766, DateTimeKind.Local).AddTicks(7730));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 1, 15, 51, 766, DateTimeKind.Local).AddTicks(7741));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 1, 15, 51, 766, DateTimeKind.Local).AddTicks(7743));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 1, 15, 51, 766, DateTimeKind.Local).AddTicks(7749));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 1, 15, 51, 766, DateTimeKind.Local).AddTicks(7763));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 1, 15, 51, 766, DateTimeKind.Local).AddTicks(7766));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 1, 15, 51, 766, DateTimeKind.Local).AddTicks(8567));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 1, 15, 51, 766, DateTimeKind.Local).AddTicks(8574));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 1, 15, 51, 766, DateTimeKind.Local).AddTicks(8576));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 1, 15, 51, 766, DateTimeKind.Local).AddTicks(8579));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 1, 15, 51, 766, DateTimeKind.Local).AddTicks(8581));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 1, 15, 51, 766, DateTimeKind.Local).AddTicks(8583));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 1, 15, 51, 766, DateTimeKind.Local).AddTicks(8586));
        }
    }
}
