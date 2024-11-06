using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NPOMS.Repository.Migrations
{
    /// <inheritdoc />
    public partial class IndicatorReport : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContactInformation_IndicatorReports_IndicatorReportId",
                schema: "dbo",
                table: "ContactInformation");

            migrationBuilder.DropForeignKey(
                name: "FK_IndicatorReports_AccessStatuses_ApprovalStatusId",
                schema: "dbo",
                table: "IndicatorReports");

            migrationBuilder.DropForeignKey(
                name: "FK_IndicatorReports_OrganisationTypes_OrganisationTypeId",
                schema: "dbo",
                table: "IndicatorReports");

            migrationBuilder.DropForeignKey(
                name: "FK_IndicatorReports_Users_ApprovalUserId",
                schema: "dbo",
                table: "IndicatorReports");

            migrationBuilder.DropIndex(
                name: "IX_IndicatorReports_ApprovalStatusId",
                schema: "dbo",
                table: "IndicatorReports");

            migrationBuilder.DropIndex(
                name: "IX_IndicatorReports_ApprovalUserId",
                schema: "dbo",
                table: "IndicatorReports");

            migrationBuilder.DropIndex(
                name: "IX_IndicatorReports_OrganisationTypeId",
                schema: "dbo",
                table: "IndicatorReports");

            migrationBuilder.DropIndex(
                name: "IX_ContactInformation_IndicatorReportId",
                schema: "dbo",
                table: "ContactInformation");

            migrationBuilder.DropColumn(
                name: "Actuals",
                schema: "dbo",
                table: "IndicatorReports");

            migrationBuilder.DropColumn(
                name: "ApprovalStatusId",
                schema: "dbo",
                table: "IndicatorReports");

            migrationBuilder.DropColumn(
                name: "ApprovalUserId",
                schema: "dbo",
                table: "IndicatorReports");

            migrationBuilder.DropColumn(
                name: "OrganisationTypeId",
                schema: "dbo",
                table: "IndicatorReports");

            migrationBuilder.DropColumn(
                name: "IndicatorReportId",
                schema: "dbo",
                table: "ContactInformation");

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 26, 0, 47, 25, 633, DateTimeKind.Local).AddTicks(9389));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 26, 0, 47, 25, 633, DateTimeKind.Local).AddTicks(9407));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 26, 0, 47, 25, 633, DateTimeKind.Local).AddTicks(9408));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 26, 0, 47, 25, 633, DateTimeKind.Local).AddTicks(9410));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 26, 0, 47, 25, 633, DateTimeKind.Local).AddTicks(9412));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 26, 0, 47, 25, 633, DateTimeKind.Local).AddTicks(9413));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 26, 0, 47, 25, 633, DateTimeKind.Local).AddTicks(9415));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 26, 0, 47, 25, 633, DateTimeKind.Local).AddTicks(9416));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 26, 0, 47, 25, 633, DateTimeKind.Local).AddTicks(9418));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 26, 0, 47, 25, 633, DateTimeKind.Local).AddTicks(9419));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 26, 0, 47, 25, 633, DateTimeKind.Local).AddTicks(9421));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 26, 0, 47, 25, 633, DateTimeKind.Local).AddTicks(9422));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 26, 0, 47, 25, 633, DateTimeKind.Local).AddTicks(9424));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 26, 0, 47, 25, 633, DateTimeKind.Local).AddTicks(9425));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 26, 0, 47, 25, 633, DateTimeKind.Local).AddTicks(9427));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 26, 0, 47, 25, 633, DateTimeKind.Local).AddTicks(9428));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 26, 0, 47, 25, 633, DateTimeKind.Local).AddTicks(9430));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 26, 0, 47, 25, 633, DateTimeKind.Local).AddTicks(9431));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 26, 0, 47, 25, 633, DateTimeKind.Local).AddTicks(9433));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 26, 0, 47, 25, 633, DateTimeKind.Local).AddTicks(9434));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 26, 0, 47, 25, 633, DateTimeKind.Local).AddTicks(9436));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 26, 0, 47, 25, 633, DateTimeKind.Local).AddTicks(9437));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 26, 0, 47, 25, 633, DateTimeKind.Local).AddTicks(9439));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 26, 0, 47, 25, 633, DateTimeKind.Local).AddTicks(9440));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 26, 0, 47, 25, 633, DateTimeKind.Local).AddTicks(9442));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 26, 0, 47, 25, 633, DateTimeKind.Local).AddTicks(9443));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 26, 0, 47, 25, 633, DateTimeKind.Local).AddTicks(9445));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 26, 0, 47, 25, 633, DateTimeKind.Local).AddTicks(9452));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 26, 0, 47, 25, 633, DateTimeKind.Local).AddTicks(9455));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 26, 0, 47, 25, 633, DateTimeKind.Local).AddTicks(9464));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 26, 0, 47, 25, 633, DateTimeKind.Local).AddTicks(9475));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 26, 0, 47, 25, 633, DateTimeKind.Local).AddTicks(9476));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 26, 0, 47, 25, 634, DateTimeKind.Local).AddTicks(801));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 26, 0, 47, 25, 634, DateTimeKind.Local).AddTicks(806));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 26, 0, 47, 25, 634, DateTimeKind.Local).AddTicks(809));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 26, 0, 47, 25, 634, DateTimeKind.Local).AddTicks(811));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 26, 0, 47, 25, 634, DateTimeKind.Local).AddTicks(813));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 26, 0, 47, 25, 634, DateTimeKind.Local).AddTicks(815));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 26, 0, 47, 25, 634, DateTimeKind.Local).AddTicks(818));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Actuals",
                schema: "dbo",
                table: "IndicatorReports",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ApprovalStatusId",
                schema: "dbo",
                table: "IndicatorReports",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ApprovalUserId",
                schema: "dbo",
                table: "IndicatorReports",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrganisationTypeId",
                schema: "dbo",
                table: "IndicatorReports",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IndicatorReportId",
                schema: "dbo",
                table: "ContactInformation",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 26, 0, 43, 15, 694, DateTimeKind.Local).AddTicks(1055));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 26, 0, 43, 15, 694, DateTimeKind.Local).AddTicks(1074));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 26, 0, 43, 15, 694, DateTimeKind.Local).AddTicks(1077));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 26, 0, 43, 15, 694, DateTimeKind.Local).AddTicks(1079));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 26, 0, 43, 15, 694, DateTimeKind.Local).AddTicks(1082));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 26, 0, 43, 15, 694, DateTimeKind.Local).AddTicks(1084));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 26, 0, 43, 15, 694, DateTimeKind.Local).AddTicks(1085));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 26, 0, 43, 15, 694, DateTimeKind.Local).AddTicks(1087));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 26, 0, 43, 15, 694, DateTimeKind.Local).AddTicks(1089));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 26, 0, 43, 15, 694, DateTimeKind.Local).AddTicks(1090));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 26, 0, 43, 15, 694, DateTimeKind.Local).AddTicks(1092));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 26, 0, 43, 15, 694, DateTimeKind.Local).AddTicks(1093));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 26, 0, 43, 15, 694, DateTimeKind.Local).AddTicks(1095));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 26, 0, 43, 15, 694, DateTimeKind.Local).AddTicks(1098));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 26, 0, 43, 15, 694, DateTimeKind.Local).AddTicks(1101));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 26, 0, 43, 15, 694, DateTimeKind.Local).AddTicks(1103));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 26, 0, 43, 15, 694, DateTimeKind.Local).AddTicks(1104));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 26, 0, 43, 15, 694, DateTimeKind.Local).AddTicks(1106));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 26, 0, 43, 15, 694, DateTimeKind.Local).AddTicks(1109));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 26, 0, 43, 15, 694, DateTimeKind.Local).AddTicks(1111));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 26, 0, 43, 15, 694, DateTimeKind.Local).AddTicks(1113));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 26, 0, 43, 15, 694, DateTimeKind.Local).AddTicks(1115));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 26, 0, 43, 15, 694, DateTimeKind.Local).AddTicks(1117));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 26, 0, 43, 15, 694, DateTimeKind.Local).AddTicks(1119));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 26, 0, 43, 15, 694, DateTimeKind.Local).AddTicks(1121));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 26, 0, 43, 15, 694, DateTimeKind.Local).AddTicks(1124));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 26, 0, 43, 15, 694, DateTimeKind.Local).AddTicks(1126));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 26, 0, 43, 15, 694, DateTimeKind.Local).AddTicks(1137));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 26, 0, 43, 15, 694, DateTimeKind.Local).AddTicks(1139));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 26, 0, 43, 15, 694, DateTimeKind.Local).AddTicks(1153));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 26, 0, 43, 15, 694, DateTimeKind.Local).AddTicks(1173));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 26, 0, 43, 15, 694, DateTimeKind.Local).AddTicks(1176));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 26, 0, 43, 15, 694, DateTimeKind.Local).AddTicks(1755));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 26, 0, 43, 15, 694, DateTimeKind.Local).AddTicks(1760));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 26, 0, 43, 15, 694, DateTimeKind.Local).AddTicks(1762));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 26, 0, 43, 15, 694, DateTimeKind.Local).AddTicks(1765));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 26, 0, 43, 15, 694, DateTimeKind.Local).AddTicks(1768));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 26, 0, 43, 15, 694, DateTimeKind.Local).AddTicks(1770));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 26, 0, 43, 15, 694, DateTimeKind.Local).AddTicks(1774));

            migrationBuilder.CreateIndex(
                name: "IX_IndicatorReports_ApprovalStatusId",
                schema: "dbo",
                table: "IndicatorReports",
                column: "ApprovalStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_IndicatorReports_ApprovalUserId",
                schema: "dbo",
                table: "IndicatorReports",
                column: "ApprovalUserId");

            migrationBuilder.CreateIndex(
                name: "IX_IndicatorReports_OrganisationTypeId",
                schema: "dbo",
                table: "IndicatorReports",
                column: "OrganisationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactInformation_IndicatorReportId",
                schema: "dbo",
                table: "ContactInformation",
                column: "IndicatorReportId");

            migrationBuilder.AddForeignKey(
                name: "FK_ContactInformation_IndicatorReports_IndicatorReportId",
                schema: "dbo",
                table: "ContactInformation",
                column: "IndicatorReportId",
                principalSchema: "dbo",
                principalTable: "IndicatorReports",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_IndicatorReports_AccessStatuses_ApprovalStatusId",
                schema: "dbo",
                table: "IndicatorReports",
                column: "ApprovalStatusId",
                principalSchema: "dbo",
                principalTable: "AccessStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IndicatorReports_OrganisationTypes_OrganisationTypeId",
                schema: "dbo",
                table: "IndicatorReports",
                column: "OrganisationTypeId",
                principalSchema: "dropdown",
                principalTable: "OrganisationTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_IndicatorReports_Users_ApprovalUserId",
                schema: "dbo",
                table: "IndicatorReports",
                column: "ApprovalUserId",
                principalSchema: "core",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
