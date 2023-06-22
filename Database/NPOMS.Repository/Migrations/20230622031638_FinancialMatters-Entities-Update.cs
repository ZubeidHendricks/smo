using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NPOMS.Repository.Migrations
{
    public partial class FinancialMattersEntitiesUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TotalFundingAmountE",
                schema: "fa",
                table: "FinancialMattersOthers",
                newName: "TotalFundingAmountO");

            migrationBuilder.RenameColumn(
                name: "ExpenditureDescription",
                schema: "fa",
                table: "FinancialMattersOthers",
                newName: "OtherDescription");

            migrationBuilder.RenameColumn(
                name: "AmountTwoE",
                schema: "fa",
                table: "FinancialMattersOthers",
                newName: "AmountTwoO");

            migrationBuilder.RenameColumn(
                name: "AmountThreeE",
                schema: "fa",
                table: "FinancialMattersOthers",
                newName: "AmountThreeO");

            migrationBuilder.RenameColumn(
                name: "AmountOneE",
                schema: "fa",
                table: "FinancialMattersOthers",
                newName: "AmountOneO");

            migrationBuilder.RenameColumn(
                name: "TotalFundingAmountO",
                schema: "fa",
                table: "FinancialMattersExpenditure",
                newName: "TotalFundingAmountE");

            migrationBuilder.RenameColumn(
                name: "OthersDescription",
                schema: "fa",
                table: "FinancialMattersExpenditure",
                newName: "ExpenditureDescription");

            migrationBuilder.RenameColumn(
                name: "AmountTwoO",
                schema: "fa",
                table: "FinancialMattersExpenditure",
                newName: "AmountTwoE");

            migrationBuilder.RenameColumn(
                name: "AmountThreeO",
                schema: "fa",
                table: "FinancialMattersExpenditure",
                newName: "AmountThreeE");

            migrationBuilder.RenameColumn(
                name: "AmountOneO",
                schema: "fa",
                table: "FinancialMattersExpenditure",
                newName: "AmountOneE");

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 22, 5, 16, 28, 654, DateTimeKind.Local).AddTicks(3098));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 22, 5, 16, 28, 654, DateTimeKind.Local).AddTicks(3100));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 22, 5, 16, 28, 654, DateTimeKind.Local).AddTicks(3102));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 22, 5, 16, 28, 654, DateTimeKind.Local).AddTicks(3103));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 22, 5, 16, 28, 654, DateTimeKind.Local).AddTicks(3105));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 22, 5, 16, 28, 654, DateTimeKind.Local).AddTicks(3106));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 22, 5, 16, 28, 654, DateTimeKind.Local).AddTicks(3107));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 22, 5, 16, 28, 654, DateTimeKind.Local).AddTicks(3108));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 22, 5, 16, 28, 654, DateTimeKind.Local).AddTicks(3110));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 22, 5, 16, 28, 654, DateTimeKind.Local).AddTicks(3111));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 22, 5, 16, 28, 654, DateTimeKind.Local).AddTicks(3112));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 22, 5, 16, 28, 654, DateTimeKind.Local).AddTicks(3114));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 22, 5, 16, 28, 654, DateTimeKind.Local).AddTicks(3115));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 22, 5, 16, 28, 654, DateTimeKind.Local).AddTicks(3116));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 22, 5, 16, 28, 654, DateTimeKind.Local).AddTicks(3118));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 22, 5, 16, 28, 654, DateTimeKind.Local).AddTicks(3119));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 22, 5, 16, 28, 654, DateTimeKind.Local).AddTicks(3124));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 22, 5, 16, 28, 654, DateTimeKind.Local).AddTicks(3126));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 22, 5, 16, 28, 654, DateTimeKind.Local).AddTicks(3128));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 22, 5, 16, 28, 654, DateTimeKind.Local).AddTicks(3129));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 22, 5, 16, 28, 654, DateTimeKind.Local).AddTicks(3131));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 22, 5, 16, 28, 654, DateTimeKind.Local).AddTicks(3142));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 22, 5, 16, 28, 654, DateTimeKind.Local).AddTicks(3154));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 22, 5, 16, 28, 654, DateTimeKind.Local).AddTicks(3155));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 22, 5, 16, 28, 654, DateTimeKind.Local).AddTicks(3156));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 22, 5, 16, 28, 654, DateTimeKind.Local).AddTicks(3157));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 22, 5, 16, 28, 654, DateTimeKind.Local).AddTicks(3159));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 22, 5, 16, 28, 654, DateTimeKind.Local).AddTicks(3160));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 22, 5, 16, 28, 654, DateTimeKind.Local).AddTicks(3161));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 22, 5, 16, 28, 654, DateTimeKind.Local).AddTicks(3162));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 22, 5, 16, 28, 654, DateTimeKind.Local).AddTicks(3163));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 22, 5, 16, 28, 654, DateTimeKind.Local).AddTicks(3164));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 22, 5, 16, 28, 654, DateTimeKind.Local).AddTicks(2997));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 22, 5, 16, 28, 654, DateTimeKind.Local).AddTicks(3018));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 22, 5, 16, 28, 654, DateTimeKind.Local).AddTicks(3020));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 22, 5, 16, 28, 654, DateTimeKind.Local).AddTicks(3021));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 22, 5, 16, 28, 654, DateTimeKind.Local).AddTicks(3023));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 22, 5, 16, 28, 654, DateTimeKind.Local).AddTicks(3025));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 22, 5, 16, 28, 654, DateTimeKind.Local).AddTicks(3026));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TotalFundingAmountO",
                schema: "fa",
                table: "FinancialMattersOthers",
                newName: "TotalFundingAmountE");

            migrationBuilder.RenameColumn(
                name: "OtherDescription",
                schema: "fa",
                table: "FinancialMattersOthers",
                newName: "ExpenditureDescription");

            migrationBuilder.RenameColumn(
                name: "AmountTwoO",
                schema: "fa",
                table: "FinancialMattersOthers",
                newName: "AmountTwoE");

            migrationBuilder.RenameColumn(
                name: "AmountThreeO",
                schema: "fa",
                table: "FinancialMattersOthers",
                newName: "AmountThreeE");

            migrationBuilder.RenameColumn(
                name: "AmountOneO",
                schema: "fa",
                table: "FinancialMattersOthers",
                newName: "AmountOneE");

            migrationBuilder.RenameColumn(
                name: "TotalFundingAmountE",
                schema: "fa",
                table: "FinancialMattersExpenditure",
                newName: "TotalFundingAmountO");

            migrationBuilder.RenameColumn(
                name: "ExpenditureDescription",
                schema: "fa",
                table: "FinancialMattersExpenditure",
                newName: "OthersDescription");

            migrationBuilder.RenameColumn(
                name: "AmountTwoE",
                schema: "fa",
                table: "FinancialMattersExpenditure",
                newName: "AmountTwoO");

            migrationBuilder.RenameColumn(
                name: "AmountThreeE",
                schema: "fa",
                table: "FinancialMattersExpenditure",
                newName: "AmountThreeO");

            migrationBuilder.RenameColumn(
                name: "AmountOneE",
                schema: "fa",
                table: "FinancialMattersExpenditure",
                newName: "AmountOneO");

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 20, 11, 49, 412, DateTimeKind.Local).AddTicks(8001));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 20, 11, 49, 412, DateTimeKind.Local).AddTicks(8003));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 20, 11, 49, 412, DateTimeKind.Local).AddTicks(8004));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 20, 11, 49, 412, DateTimeKind.Local).AddTicks(8005));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 20, 11, 49, 412, DateTimeKind.Local).AddTicks(8007));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 20, 11, 49, 412, DateTimeKind.Local).AddTicks(8009));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 20, 11, 49, 412, DateTimeKind.Local).AddTicks(8010));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 20, 11, 49, 412, DateTimeKind.Local).AddTicks(8011));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 20, 11, 49, 412, DateTimeKind.Local).AddTicks(8012));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 20, 11, 49, 412, DateTimeKind.Local).AddTicks(8013));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 20, 11, 49, 412, DateTimeKind.Local).AddTicks(8014));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 20, 11, 49, 412, DateTimeKind.Local).AddTicks(8015));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 20, 11, 49, 412, DateTimeKind.Local).AddTicks(8016));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 20, 11, 49, 412, DateTimeKind.Local).AddTicks(8017));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 20, 11, 49, 412, DateTimeKind.Local).AddTicks(8019));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 20, 11, 49, 412, DateTimeKind.Local).AddTicks(8020));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 20, 11, 49, 412, DateTimeKind.Local).AddTicks(8021));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 20, 11, 49, 412, DateTimeKind.Local).AddTicks(8023));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 20, 11, 49, 412, DateTimeKind.Local).AddTicks(8024));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 20, 11, 49, 412, DateTimeKind.Local).AddTicks(8025));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 20, 11, 49, 412, DateTimeKind.Local).AddTicks(8033));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 20, 11, 49, 412, DateTimeKind.Local).AddTicks(8034));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 20, 11, 49, 412, DateTimeKind.Local).AddTicks(8039));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 20, 11, 49, 412, DateTimeKind.Local).AddTicks(8061));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 20, 11, 49, 412, DateTimeKind.Local).AddTicks(8062));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 20, 11, 49, 412, DateTimeKind.Local).AddTicks(8063));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 20, 11, 49, 412, DateTimeKind.Local).AddTicks(8064));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 20, 11, 49, 412, DateTimeKind.Local).AddTicks(8065));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 20, 11, 49, 412, DateTimeKind.Local).AddTicks(8066));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 20, 11, 49, 412, DateTimeKind.Local).AddTicks(8067));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 20, 11, 49, 412, DateTimeKind.Local).AddTicks(8068));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 20, 11, 49, 412, DateTimeKind.Local).AddTicks(8069));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 20, 11, 49, 412, DateTimeKind.Local).AddTicks(7897));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 20, 11, 49, 412, DateTimeKind.Local).AddTicks(7916));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 20, 11, 49, 412, DateTimeKind.Local).AddTicks(7918));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 20, 11, 49, 412, DateTimeKind.Local).AddTicks(7919));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 20, 11, 49, 412, DateTimeKind.Local).AddTicks(7921));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 20, 11, 49, 412, DateTimeKind.Local).AddTicks(7922));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 20, 11, 49, 412, DateTimeKind.Local).AddTicks(7924));
        }
    }
}
