using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NPOMS.Repository.Migrations
{
    public partial class AddCCodeToNpo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FinancialMatters_FundingApplicationDetails_FundingApplicationDetailId",
                schema: "fa",
                table: "FinancialMatters");

            migrationBuilder.DropForeignKey(
                name: "FK_FinancialMatters_PropertySubTypes_PropertySubTypeId",
                schema: "fa",
                table: "FinancialMatters");

            migrationBuilder.DropForeignKey(
                name: "FK_FinancialMatters_PropertyTypes_PropertyTypeId",
                schema: "fa",
                table: "FinancialMatters");

            migrationBuilder.DropIndex(
                name: "IX_FinancialMatters_PropertySubTypeId",
                schema: "fa",
                table: "FinancialMatters");

            migrationBuilder.DropIndex(
                name: "IX_FinancialMatters_PropertyTypeId",
                schema: "fa",
                table: "FinancialMatters");

            migrationBuilder.DropColumn(
                name: "PropertyId",
                schema: "fa",
                table: "FinancialMatters");

            migrationBuilder.DropColumn(
                name: "PropertySubTypeId",
                schema: "fa",
                table: "FinancialMatters");

            migrationBuilder.DropColumn(
                name: "PropertyTypeId",
                schema: "fa",
                table: "FinancialMatters");

            migrationBuilder.DropColumn(
                name: "SubProperty",
                schema: "fa",
                table: "FinancialMatters");

            migrationBuilder.DropColumn(
                name: "SubPropertyId",
                schema: "fa",
                table: "FinancialMatters");

            migrationBuilder.DropColumn(
                name: "Type",
                schema: "fa",
                table: "FinancialMatters");

            migrationBuilder.AddColumn<string>(
                name: "CCode",
                schema: "dbo",
                table: "Npos",
                type: "nvarchar(255)",
                nullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                schema: "fa",
                table: "FinancialMatters",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<int>(
                name: "FundingApplicationDetailId",
                schema: "fa",
                table: "FinancialMatters",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CreatedUserId",
                schema: "fa",
                table: "FinancialMatters",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDateTime",
                schema: "fa",
                table: "FinancialMatters",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 16, 6, 8, 485, DateTimeKind.Local).AddTicks(9919));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 16, 6, 8, 485, DateTimeKind.Local).AddTicks(9921));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 16, 6, 8, 485, DateTimeKind.Local).AddTicks(9923));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 16, 6, 8, 485, DateTimeKind.Local).AddTicks(9924));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 16, 6, 8, 485, DateTimeKind.Local).AddTicks(9926));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 16, 6, 8, 485, DateTimeKind.Local).AddTicks(9927));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 16, 6, 8, 485, DateTimeKind.Local).AddTicks(9929));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 16, 6, 8, 485, DateTimeKind.Local).AddTicks(9930));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 16, 6, 8, 485, DateTimeKind.Local).AddTicks(9932));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 16, 6, 8, 485, DateTimeKind.Local).AddTicks(9933));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 16, 6, 8, 485, DateTimeKind.Local).AddTicks(9936));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 16, 6, 8, 485, DateTimeKind.Local).AddTicks(9937));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 16, 6, 8, 485, DateTimeKind.Local).AddTicks(9939));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 16, 6, 8, 485, DateTimeKind.Local).AddTicks(9940));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 16, 6, 8, 485, DateTimeKind.Local).AddTicks(9943));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 16, 6, 8, 485, DateTimeKind.Local).AddTicks(9944));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 16, 6, 8, 485, DateTimeKind.Local).AddTicks(9946));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 16, 6, 8, 485, DateTimeKind.Local).AddTicks(9947));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 16, 6, 8, 485, DateTimeKind.Local).AddTicks(9949));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 16, 6, 8, 485, DateTimeKind.Local).AddTicks(9950));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 16, 6, 8, 485, DateTimeKind.Local).AddTicks(9952));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 16, 6, 8, 485, DateTimeKind.Local).AddTicks(9953));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 16, 6, 8, 485, DateTimeKind.Local).AddTicks(9967));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 16, 6, 8, 485, DateTimeKind.Local).AddTicks(9980));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 16, 6, 8, 485, DateTimeKind.Local).AddTicks(9983));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 16, 6, 8, 485, DateTimeKind.Local).AddTicks(9985));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 16, 6, 8, 485, DateTimeKind.Local).AddTicks(9986));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 16, 6, 8, 485, DateTimeKind.Local).AddTicks(9988));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 16, 6, 8, 485, DateTimeKind.Local).AddTicks(9990));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 16, 6, 8, 485, DateTimeKind.Local).AddTicks(9991));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 16, 6, 8, 485, DateTimeKind.Local).AddTicks(9993));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 16, 6, 8, 485, DateTimeKind.Local).AddTicks(9994));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 16, 6, 8, 485, DateTimeKind.Local).AddTicks(9773));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 16, 6, 8, 485, DateTimeKind.Local).AddTicks(9792));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 16, 6, 8, 485, DateTimeKind.Local).AddTicks(9795));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 16, 6, 8, 485, DateTimeKind.Local).AddTicks(9797));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 16, 6, 8, 485, DateTimeKind.Local).AddTicks(9799));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 16, 6, 8, 485, DateTimeKind.Local).AddTicks(9801));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 16, 6, 8, 485, DateTimeKind.Local).AddTicks(9803));

            migrationBuilder.AddForeignKey(
                name: "FK_FinancialMatters_FundingApplicationDetails_FundingApplicationDetailId",
                schema: "fa",
                table: "FinancialMatters",
                column: "FundingApplicationDetailId",
                principalSchema: "fa",
                principalTable: "FundingApplicationDetails",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FinancialMatters_FundingApplicationDetails_FundingApplicationDetailId",
                schema: "fa",
                table: "FinancialMatters");

            migrationBuilder.DropColumn(
                name: "CCode",
                schema: "dbo",
                table: "Npos");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                schema: "fa",
                table: "FinancialMatters",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FundingApplicationDetailId",
                schema: "fa",
                table: "FinancialMatters",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CreatedUserId",
                schema: "fa",
                table: "FinancialMatters",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDateTime",
                schema: "fa",
                table: "FinancialMatters",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PropertyId",
                schema: "fa",
                table: "FinancialMatters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PropertySubTypeId",
                schema: "fa",
                table: "FinancialMatters",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PropertyTypeId",
                schema: "fa",
                table: "FinancialMatters",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SubProperty",
                schema: "fa",
                table: "FinancialMatters",
                type: "nvarchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SubPropertyId",
                schema: "fa",
                table: "FinancialMatters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                schema: "fa",
                table: "FinancialMatters",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 9, 17, 32, 27, 346, DateTimeKind.Local).AddTicks(1836));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 9, 17, 32, 27, 346, DateTimeKind.Local).AddTicks(1839));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 9, 17, 32, 27, 346, DateTimeKind.Local).AddTicks(1840));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 9, 17, 32, 27, 346, DateTimeKind.Local).AddTicks(1842));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 9, 17, 32, 27, 346, DateTimeKind.Local).AddTicks(1878));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 9, 17, 32, 27, 346, DateTimeKind.Local).AddTicks(1880));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 9, 17, 32, 27, 346, DateTimeKind.Local).AddTicks(1881));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 9, 17, 32, 27, 346, DateTimeKind.Local).AddTicks(1883));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 9, 17, 32, 27, 346, DateTimeKind.Local).AddTicks(1884));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 9, 17, 32, 27, 346, DateTimeKind.Local).AddTicks(1885));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 9, 17, 32, 27, 346, DateTimeKind.Local).AddTicks(1887));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 9, 17, 32, 27, 346, DateTimeKind.Local).AddTicks(1888));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 9, 17, 32, 27, 346, DateTimeKind.Local).AddTicks(1889));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 9, 17, 32, 27, 346, DateTimeKind.Local).AddTicks(1891));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 9, 17, 32, 27, 346, DateTimeKind.Local).AddTicks(1892));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 9, 17, 32, 27, 346, DateTimeKind.Local).AddTicks(1893));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 9, 17, 32, 27, 346, DateTimeKind.Local).AddTicks(1895));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 9, 17, 32, 27, 346, DateTimeKind.Local).AddTicks(1896));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 9, 17, 32, 27, 346, DateTimeKind.Local).AddTicks(1897));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 9, 17, 32, 27, 346, DateTimeKind.Local).AddTicks(1899));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 9, 17, 32, 27, 346, DateTimeKind.Local).AddTicks(1907));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 9, 17, 32, 27, 346, DateTimeKind.Local).AddTicks(1909));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 9, 17, 32, 27, 346, DateTimeKind.Local).AddTicks(1915));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 9, 17, 32, 27, 346, DateTimeKind.Local).AddTicks(1937));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 9, 17, 32, 27, 346, DateTimeKind.Local).AddTicks(1939));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 9, 17, 32, 27, 346, DateTimeKind.Local).AddTicks(1940));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 9, 17, 32, 27, 346, DateTimeKind.Local).AddTicks(1941));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 9, 17, 32, 27, 346, DateTimeKind.Local).AddTicks(1942));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 9, 17, 32, 27, 346, DateTimeKind.Local).AddTicks(1944));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 9, 17, 32, 27, 346, DateTimeKind.Local).AddTicks(1945));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 9, 17, 32, 27, 346, DateTimeKind.Local).AddTicks(1946));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 9, 17, 32, 27, 346, DateTimeKind.Local).AddTicks(1947));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 9, 17, 32, 27, 346, DateTimeKind.Local).AddTicks(1727));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 9, 17, 32, 27, 346, DateTimeKind.Local).AddTicks(1747));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 9, 17, 32, 27, 346, DateTimeKind.Local).AddTicks(1750));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 9, 17, 32, 27, 346, DateTimeKind.Local).AddTicks(1751));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 9, 17, 32, 27, 346, DateTimeKind.Local).AddTicks(1753));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 9, 17, 32, 27, 346, DateTimeKind.Local).AddTicks(1755));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 9, 17, 32, 27, 346, DateTimeKind.Local).AddTicks(1757));

            migrationBuilder.CreateIndex(
                name: "IX_FinancialMatters_PropertySubTypeId",
                schema: "fa",
                table: "FinancialMatters",
                column: "PropertySubTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_FinancialMatters_PropertyTypeId",
                schema: "fa",
                table: "FinancialMatters",
                column: "PropertyTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_FinancialMatters_FundingApplicationDetails_FundingApplicationDetailId",
                schema: "fa",
                table: "FinancialMatters",
                column: "FundingApplicationDetailId",
                principalSchema: "fa",
                principalTable: "FundingApplicationDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FinancialMatters_PropertySubTypes_PropertySubTypeId",
                schema: "fa",
                table: "FinancialMatters",
                column: "PropertySubTypeId",
                principalSchema: "dropdown",
                principalTable: "PropertySubTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FinancialMatters_PropertyTypes_PropertyTypeId",
                schema: "fa",
                table: "FinancialMatters",
                column: "PropertyTypeId",
                principalSchema: "dropdown",
                principalTable: "PropertyTypes",
                principalColumn: "Id");
        }
    }
}
