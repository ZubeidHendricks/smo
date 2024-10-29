using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NPOMS.Repository.Migrations
{
    /// <inheritdoc />
    public partial class ReportStatusUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FinancialYearId",
                table: "SDIPReports",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FinancialYear",
                schema: "dbo",
                table: "PostReports",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FinancialYearId",
                schema: "dbo",
                table: "IndicatorReports",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FinancialYearId",
                schema: "dbo",
                table: "IncomeAndExpenditureReports",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FinancialYearId",
                schema: "dbo",
                table: "GovernanceReports",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FinancialYearId",
                schema: "dbo",
                table: "AnyOtherInformationReports",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Statuses",
                columns: new[] { "Id", "Name", "SystemName", "UpdatedDateTime", "UpdatedUserId" },
                values: new object[] { 24, "Completed", "Completed", null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Statuses",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DropColumn(
                name: "FinancialYearId",
                table: "SDIPReports");

            migrationBuilder.DropColumn(
                name: "FinancialYear",
                schema: "dbo",
                table: "PostReports");

            migrationBuilder.DropColumn(
                name: "FinancialYearId",
                schema: "dbo",
                table: "IndicatorReports");

            migrationBuilder.DropColumn(
                name: "FinancialYearId",
                schema: "dbo",
                table: "IncomeAndExpenditureReports");

            migrationBuilder.DropColumn(
                name: "FinancialYearId",
                schema: "dbo",
                table: "GovernanceReports");

            migrationBuilder.DropColumn(
                name: "FinancialYearId",
                schema: "dbo",
                table: "AnyOtherInformationReports");

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 24, 23, 52, 24, 332, DateTimeKind.Local).AddTicks(5076));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 24, 23, 52, 24, 332, DateTimeKind.Local).AddTicks(5097));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 24, 23, 52, 24, 332, DateTimeKind.Local).AddTicks(5099));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 24, 23, 52, 24, 332, DateTimeKind.Local).AddTicks(5102));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 24, 23, 52, 24, 332, DateTimeKind.Local).AddTicks(5106));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 24, 23, 52, 24, 332, DateTimeKind.Local).AddTicks(5109));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 24, 23, 52, 24, 332, DateTimeKind.Local).AddTicks(5111));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 24, 23, 52, 24, 332, DateTimeKind.Local).AddTicks(5114));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 24, 23, 52, 24, 332, DateTimeKind.Local).AddTicks(5117));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 24, 23, 52, 24, 332, DateTimeKind.Local).AddTicks(5121));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 24, 23, 52, 24, 332, DateTimeKind.Local).AddTicks(5130));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 24, 23, 52, 24, 332, DateTimeKind.Local).AddTicks(5134));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 24, 23, 52, 24, 332, DateTimeKind.Local).AddTicks(5136));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 24, 23, 52, 24, 332, DateTimeKind.Local).AddTicks(5141));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 24, 23, 52, 24, 332, DateTimeKind.Local).AddTicks(5144));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 24, 23, 52, 24, 332, DateTimeKind.Local).AddTicks(5147));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 24, 23, 52, 24, 332, DateTimeKind.Local).AddTicks(5149));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 24, 23, 52, 24, 332, DateTimeKind.Local).AddTicks(5151));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 24, 23, 52, 24, 332, DateTimeKind.Local).AddTicks(5153));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 24, 23, 52, 24, 332, DateTimeKind.Local).AddTicks(5156));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 24, 23, 52, 24, 332, DateTimeKind.Local).AddTicks(5159));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 24, 23, 52, 24, 332, DateTimeKind.Local).AddTicks(5161));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 24, 23, 52, 24, 332, DateTimeKind.Local).AddTicks(5163));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 24, 23, 52, 24, 332, DateTimeKind.Local).AddTicks(5165));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 24, 23, 52, 24, 332, DateTimeKind.Local).AddTicks(5184));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 24, 23, 52, 24, 332, DateTimeKind.Local).AddTicks(5187));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 24, 23, 52, 24, 332, DateTimeKind.Local).AddTicks(5189));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 24, 23, 52, 24, 332, DateTimeKind.Local).AddTicks(5194));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 24, 23, 52, 24, 332, DateTimeKind.Local).AddTicks(5197));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 24, 23, 52, 24, 332, DateTimeKind.Local).AddTicks(5203));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 24, 23, 52, 24, 332, DateTimeKind.Local).AddTicks(5223));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 24, 23, 52, 24, 332, DateTimeKind.Local).AddTicks(5228));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 24, 23, 52, 24, 332, DateTimeKind.Local).AddTicks(6003));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 24, 23, 52, 24, 332, DateTimeKind.Local).AddTicks(6009));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 24, 23, 52, 24, 332, DateTimeKind.Local).AddTicks(6012));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 24, 23, 52, 24, 332, DateTimeKind.Local).AddTicks(6016));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 24, 23, 52, 24, 332, DateTimeKind.Local).AddTicks(6020));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 24, 23, 52, 24, 332, DateTimeKind.Local).AddTicks(6027));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 24, 23, 52, 24, 332, DateTimeKind.Local).AddTicks(6030));
        }
    }
}
