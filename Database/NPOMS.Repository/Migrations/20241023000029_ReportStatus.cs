using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NPOMS.Repository.Migrations
{
    /// <inheritdoc />
    public partial class ReportStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "SDIPReports",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                schema: "dbo",
                table: "PostReports",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                schema: "dbo",
                table: "IndicatorReports",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                schema: "dbo",
                table: "IncomeAndExpenditureReports",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                schema: "dbo",
                table: "GovernanceReports",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
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
                value: new DateTime(2024, 10, 23, 2, 0, 18, 352, DateTimeKind.Local).AddTicks(1315));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 23, 2, 0, 18, 352, DateTimeKind.Local).AddTicks(1332));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 23, 2, 0, 18, 352, DateTimeKind.Local).AddTicks(1334));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 23, 2, 0, 18, 352, DateTimeKind.Local).AddTicks(1336));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 23, 2, 0, 18, 352, DateTimeKind.Local).AddTicks(1340));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 23, 2, 0, 18, 352, DateTimeKind.Local).AddTicks(1343));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 23, 2, 0, 18, 352, DateTimeKind.Local).AddTicks(1345));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 23, 2, 0, 18, 352, DateTimeKind.Local).AddTicks(1348));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 23, 2, 0, 18, 352, DateTimeKind.Local).AddTicks(1350));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 23, 2, 0, 18, 352, DateTimeKind.Local).AddTicks(1351));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 23, 2, 0, 18, 352, DateTimeKind.Local).AddTicks(1353));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 23, 2, 0, 18, 352, DateTimeKind.Local).AddTicks(1355));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 23, 2, 0, 18, 352, DateTimeKind.Local).AddTicks(1357));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 23, 2, 0, 18, 352, DateTimeKind.Local).AddTicks(1359));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 23, 2, 0, 18, 352, DateTimeKind.Local).AddTicks(1362));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 23, 2, 0, 18, 352, DateTimeKind.Local).AddTicks(1364));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 23, 2, 0, 18, 352, DateTimeKind.Local).AddTicks(1365));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 23, 2, 0, 18, 352, DateTimeKind.Local).AddTicks(1367));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 23, 2, 0, 18, 352, DateTimeKind.Local).AddTicks(1370));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 23, 2, 0, 18, 352, DateTimeKind.Local).AddTicks(1372));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 23, 2, 0, 18, 352, DateTimeKind.Local).AddTicks(1374));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 23, 2, 0, 18, 352, DateTimeKind.Local).AddTicks(1376));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 23, 2, 0, 18, 352, DateTimeKind.Local).AddTicks(1379));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 23, 2, 0, 18, 352, DateTimeKind.Local).AddTicks(1381));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 23, 2, 0, 18, 352, DateTimeKind.Local).AddTicks(1384));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 23, 2, 0, 18, 352, DateTimeKind.Local).AddTicks(1386));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 23, 2, 0, 18, 352, DateTimeKind.Local).AddTicks(1389));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 23, 2, 0, 18, 352, DateTimeKind.Local).AddTicks(1396));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 23, 2, 0, 18, 352, DateTimeKind.Local).AddTicks(1399));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 23, 2, 0, 18, 352, DateTimeKind.Local).AddTicks(1405));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 23, 2, 0, 18, 352, DateTimeKind.Local).AddTicks(1426));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 23, 2, 0, 18, 352, DateTimeKind.Local).AddTicks(1428));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 23, 2, 0, 18, 352, DateTimeKind.Local).AddTicks(1999));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 23, 2, 0, 18, 352, DateTimeKind.Local).AddTicks(2006));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 23, 2, 0, 18, 352, DateTimeKind.Local).AddTicks(2009));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 23, 2, 0, 18, 352, DateTimeKind.Local).AddTicks(2014));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 23, 2, 0, 18, 352, DateTimeKind.Local).AddTicks(2073));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 23, 2, 0, 18, 352, DateTimeKind.Local).AddTicks(2079));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 23, 2, 0, 18, 352, DateTimeKind.Local).AddTicks(2081));

            migrationBuilder.CreateIndex(
                name: "IX_SDIPReports_StatusId",
                table: "SDIPReports",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_PostReports_StatusId",
                schema: "dbo",
                table: "PostReports",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_IndicatorReports_StatusId",
                schema: "dbo",
                table: "IndicatorReports",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_IncomeAndExpenditureReports_StatusId",
                schema: "dbo",
                table: "IncomeAndExpenditureReports",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_GovernanceReports_StatusId",
                schema: "dbo",
                table: "GovernanceReports",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_AnyOtherInformationReports_StatusId",
                schema: "dbo",
                table: "AnyOtherInformationReports",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_AnyOtherInformationReports_Statuses_StatusId",
                schema: "dbo",
                table: "AnyOtherInformationReports",
                column: "StatusId",
                principalSchema: "dbo",
                principalTable: "Statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GovernanceReports_Statuses_StatusId",
                schema: "dbo",
                table: "GovernanceReports",
                column: "StatusId",
                principalSchema: "dbo",
                principalTable: "Statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IncomeAndExpenditureReports_Statuses_StatusId",
                schema: "dbo",
                table: "IncomeAndExpenditureReports",
                column: "StatusId",
                principalSchema: "dbo",
                principalTable: "Statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IndicatorReports_Statuses_StatusId",
                schema: "dbo",
                table: "IndicatorReports",
                column: "StatusId",
                principalSchema: "dbo",
                principalTable: "Statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PostReports_Statuses_StatusId",
                schema: "dbo",
                table: "PostReports",
                column: "StatusId",
                principalSchema: "dbo",
                principalTable: "Statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SDIPReports_Statuses_StatusId",
                table: "SDIPReports",
                column: "StatusId",
                principalSchema: "dbo",
                principalTable: "Statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnyOtherInformationReports_Statuses_StatusId",
                schema: "dbo",
                table: "AnyOtherInformationReports");

            migrationBuilder.DropForeignKey(
                name: "FK_GovernanceReports_Statuses_StatusId",
                schema: "dbo",
                table: "GovernanceReports");

            migrationBuilder.DropForeignKey(
                name: "FK_IncomeAndExpenditureReports_Statuses_StatusId",
                schema: "dbo",
                table: "IncomeAndExpenditureReports");

            migrationBuilder.DropForeignKey(
                name: "FK_IndicatorReports_Statuses_StatusId",
                schema: "dbo",
                table: "IndicatorReports");

            migrationBuilder.DropForeignKey(
                name: "FK_PostReports_Statuses_StatusId",
                schema: "dbo",
                table: "PostReports");

            migrationBuilder.DropForeignKey(
                name: "FK_SDIPReports_Statuses_StatusId",
                table: "SDIPReports");

            migrationBuilder.DropIndex(
                name: "IX_SDIPReports_StatusId",
                table: "SDIPReports");

            migrationBuilder.DropIndex(
                name: "IX_PostReports_StatusId",
                schema: "dbo",
                table: "PostReports");

            migrationBuilder.DropIndex(
                name: "IX_IndicatorReports_StatusId",
                schema: "dbo",
                table: "IndicatorReports");

            migrationBuilder.DropIndex(
                name: "IX_IncomeAndExpenditureReports_StatusId",
                schema: "dbo",
                table: "IncomeAndExpenditureReports");

            migrationBuilder.DropIndex(
                name: "IX_GovernanceReports_StatusId",
                schema: "dbo",
                table: "GovernanceReports");

            migrationBuilder.DropIndex(
                name: "IX_AnyOtherInformationReports_StatusId",
                schema: "dbo",
                table: "AnyOtherInformationReports");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "SDIPReports");

            migrationBuilder.DropColumn(
                name: "StatusId",
                schema: "dbo",
                table: "PostReports");

            migrationBuilder.DropColumn(
                name: "StatusId",
                schema: "dbo",
                table: "IndicatorReports");

            migrationBuilder.DropColumn(
                name: "StatusId",
                schema: "dbo",
                table: "IncomeAndExpenditureReports");

            migrationBuilder.DropColumn(
                name: "StatusId",
                schema: "dbo",
                table: "GovernanceReports");

            migrationBuilder.DropColumn(
                name: "StatusId",
                schema: "dbo",
                table: "AnyOtherInformationReports");

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 21, 10, 46, 15, 241, DateTimeKind.Local).AddTicks(9225));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 21, 10, 46, 15, 241, DateTimeKind.Local).AddTicks(9252));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 21, 10, 46, 15, 241, DateTimeKind.Local).AddTicks(9255));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 21, 10, 46, 15, 241, DateTimeKind.Local).AddTicks(9258));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 21, 10, 46, 15, 241, DateTimeKind.Local).AddTicks(9260));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 21, 10, 46, 15, 241, DateTimeKind.Local).AddTicks(9263));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 21, 10, 46, 15, 241, DateTimeKind.Local).AddTicks(9265));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 21, 10, 46, 15, 241, DateTimeKind.Local).AddTicks(9268));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 21, 10, 46, 15, 241, DateTimeKind.Local).AddTicks(9270));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 21, 10, 46, 15, 241, DateTimeKind.Local).AddTicks(9273));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 21, 10, 46, 15, 241, DateTimeKind.Local).AddTicks(9275));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 21, 10, 46, 15, 241, DateTimeKind.Local).AddTicks(9278));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 21, 10, 46, 15, 241, DateTimeKind.Local).AddTicks(9280));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 21, 10, 46, 15, 241, DateTimeKind.Local).AddTicks(9284));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 21, 10, 46, 15, 241, DateTimeKind.Local).AddTicks(9286));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 21, 10, 46, 15, 241, DateTimeKind.Local).AddTicks(9288));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 21, 10, 46, 15, 241, DateTimeKind.Local).AddTicks(9291));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 21, 10, 46, 15, 241, DateTimeKind.Local).AddTicks(9293));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 21, 10, 46, 15, 241, DateTimeKind.Local).AddTicks(9296));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 21, 10, 46, 15, 241, DateTimeKind.Local).AddTicks(9298));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 21, 10, 46, 15, 241, DateTimeKind.Local).AddTicks(9301));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 21, 10, 46, 15, 241, DateTimeKind.Local).AddTicks(9316));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 21, 10, 46, 15, 241, DateTimeKind.Local).AddTicks(9318));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 21, 10, 46, 15, 241, DateTimeKind.Local).AddTicks(9321));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 21, 10, 46, 15, 241, DateTimeKind.Local).AddTicks(9323));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 21, 10, 46, 15, 241, DateTimeKind.Local).AddTicks(9326));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 21, 10, 46, 15, 241, DateTimeKind.Local).AddTicks(9328));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 21, 10, 46, 15, 241, DateTimeKind.Local).AddTicks(9331));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 21, 10, 46, 15, 241, DateTimeKind.Local).AddTicks(9333));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 21, 10, 46, 15, 241, DateTimeKind.Local).AddTicks(9343));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 21, 10, 46, 15, 241, DateTimeKind.Local).AddTicks(9360));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 21, 10, 46, 15, 241, DateTimeKind.Local).AddTicks(9362));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 21, 10, 46, 15, 242, DateTimeKind.Local).AddTicks(205));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 21, 10, 46, 15, 242, DateTimeKind.Local).AddTicks(213));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 21, 10, 46, 15, 242, DateTimeKind.Local).AddTicks(217));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 21, 10, 46, 15, 242, DateTimeKind.Local).AddTicks(220));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 21, 10, 46, 15, 242, DateTimeKind.Local).AddTicks(224));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 21, 10, 46, 15, 242, DateTimeKind.Local).AddTicks(227));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 21, 10, 46, 15, 242, DateTimeKind.Local).AddTicks(230));
        }
    }
}
