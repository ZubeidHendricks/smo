using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NPOMS.Repository.Migrations
{
    /// <inheritdoc />
    public partial class Updated_ProgrammeBudget_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                schema: "budget",
                table: "ProgrammeBudgets");

            migrationBuilder.RenameColumn(
                name: "DirectorateBudgetId",
                schema: "budget",
                table: "ProgrammeBudgets",
                newName: "SubProgrammeTypeId");

            migrationBuilder.RenameColumn(
                name: "Amount",
                schema: "budget",
                table: "ProgrammeBudgets",
                newName: "OriginalBudgetAmount");

            migrationBuilder.AlterColumn<string>(
                name: "FinancialYearId",
                schema: "budget",
                table: "ProgrammeBudgets",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<decimal>(
                name: "AdjustedBudgetAmount",
                schema: "budget",
                table: "ProgrammeBudgets",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "DepartmentName",
                schema: "budget",
                table: "ProgrammeBudgets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ObjectiveCode",
                schema: "budget",
                table: "ProgrammeBudgets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProgrammeName",
                schema: "budget",
                table: "ProgrammeBudgets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ResponsibilityCode",
                schema: "budget",
                table: "ProgrammeBudgets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SubProgrammeId",
                schema: "budget",
                table: "ProgrammeBudgets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "SubProgrammeName",
                schema: "budget",
                table: "ProgrammeBudgets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SubProgrammeTypeName",
                schema: "budget",
                table: "ProgrammeBudgets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 20, 0, 55, 34, 544, DateTimeKind.Local).AddTicks(6386));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 20, 0, 55, 34, 544, DateTimeKind.Local).AddTicks(6390));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 20, 0, 55, 34, 544, DateTimeKind.Local).AddTicks(6393));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 20, 0, 55, 34, 544, DateTimeKind.Local).AddTicks(6397));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 20, 0, 55, 34, 544, DateTimeKind.Local).AddTicks(6400));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 20, 0, 55, 34, 544, DateTimeKind.Local).AddTicks(6403));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 20, 0, 55, 34, 544, DateTimeKind.Local).AddTicks(6406));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 20, 0, 55, 34, 544, DateTimeKind.Local).AddTicks(6412));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 20, 0, 55, 34, 544, DateTimeKind.Local).AddTicks(6415));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 20, 0, 55, 34, 544, DateTimeKind.Local).AddTicks(6418));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 20, 0, 55, 34, 544, DateTimeKind.Local).AddTicks(6422));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 20, 0, 55, 34, 544, DateTimeKind.Local).AddTicks(6425));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 20, 0, 55, 34, 544, DateTimeKind.Local).AddTicks(6428));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 20, 0, 55, 34, 544, DateTimeKind.Local).AddTicks(6431));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 20, 0, 55, 34, 544, DateTimeKind.Local).AddTicks(6434));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 20, 0, 55, 34, 544, DateTimeKind.Local).AddTicks(6437));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 20, 0, 55, 34, 544, DateTimeKind.Local).AddTicks(6440));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 20, 0, 55, 34, 544, DateTimeKind.Local).AddTicks(6444));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 20, 0, 55, 34, 544, DateTimeKind.Local).AddTicks(6447));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 20, 0, 55, 34, 544, DateTimeKind.Local).AddTicks(6450));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 20, 0, 55, 34, 544, DateTimeKind.Local).AddTicks(6453));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 20, 0, 55, 34, 544, DateTimeKind.Local).AddTicks(6456));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 20, 0, 55, 34, 544, DateTimeKind.Local).AddTicks(6479));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 20, 0, 55, 34, 544, DateTimeKind.Local).AddTicks(6490));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 20, 0, 55, 34, 544, DateTimeKind.Local).AddTicks(6493));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 20, 0, 55, 34, 544, DateTimeKind.Local).AddTicks(6496));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 20, 0, 55, 34, 544, DateTimeKind.Local).AddTicks(6499));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 20, 0, 55, 34, 544, DateTimeKind.Local).AddTicks(6503));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 20, 0, 55, 34, 544, DateTimeKind.Local).AddTicks(6506));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 20, 0, 55, 34, 544, DateTimeKind.Local).AddTicks(6509));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 20, 0, 55, 34, 544, DateTimeKind.Local).AddTicks(6512));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 20, 0, 55, 34, 544, DateTimeKind.Local).AddTicks(6515));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 20, 0, 55, 34, 544, DateTimeKind.Local).AddTicks(5996));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 20, 0, 55, 34, 544, DateTimeKind.Local).AddTicks(6014));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 20, 0, 55, 34, 544, DateTimeKind.Local).AddTicks(6020));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 20, 0, 55, 34, 544, DateTimeKind.Local).AddTicks(6025));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 20, 0, 55, 34, 544, DateTimeKind.Local).AddTicks(6030));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 20, 0, 55, 34, 544, DateTimeKind.Local).AddTicks(6037));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 20, 0, 55, 34, 544, DateTimeKind.Local).AddTicks(6041));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdjustedBudgetAmount",
                schema: "budget",
                table: "ProgrammeBudgets");

            migrationBuilder.DropColumn(
                name: "DepartmentName",
                schema: "budget",
                table: "ProgrammeBudgets");

            migrationBuilder.DropColumn(
                name: "ObjectiveCode",
                schema: "budget",
                table: "ProgrammeBudgets");

            migrationBuilder.DropColumn(
                name: "ProgrammeName",
                schema: "budget",
                table: "ProgrammeBudgets");

            migrationBuilder.DropColumn(
                name: "ResponsibilityCode",
                schema: "budget",
                table: "ProgrammeBudgets");

            migrationBuilder.DropColumn(
                name: "SubProgrammeId",
                schema: "budget",
                table: "ProgrammeBudgets");

            migrationBuilder.DropColumn(
                name: "SubProgrammeName",
                schema: "budget",
                table: "ProgrammeBudgets");

            migrationBuilder.DropColumn(
                name: "SubProgrammeTypeName",
                schema: "budget",
                table: "ProgrammeBudgets");

            migrationBuilder.RenameColumn(
                name: "SubProgrammeTypeId",
                schema: "budget",
                table: "ProgrammeBudgets",
                newName: "DirectorateBudgetId");

            migrationBuilder.RenameColumn(
                name: "OriginalBudgetAmount",
                schema: "budget",
                table: "ProgrammeBudgets",
                newName: "Amount");

            migrationBuilder.AlterColumn<int>(
                name: "FinancialYearId",
                schema: "budget",
                table: "ProgrammeBudgets",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                schema: "budget",
                table: "ProgrammeBudgets",
                type: "nvarchar(2000)",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 19, 14, 10, 52, 391, DateTimeKind.Local).AddTicks(3243));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 19, 14, 10, 52, 391, DateTimeKind.Local).AddTicks(3261));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 19, 14, 10, 52, 391, DateTimeKind.Local).AddTicks(3265));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 19, 14, 10, 52, 391, DateTimeKind.Local).AddTicks(3269));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 19, 14, 10, 52, 391, DateTimeKind.Local).AddTicks(3273));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 19, 14, 10, 52, 391, DateTimeKind.Local).AddTicks(3276));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 19, 14, 10, 52, 391, DateTimeKind.Local).AddTicks(3280));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 19, 14, 10, 52, 391, DateTimeKind.Local).AddTicks(3284));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 19, 14, 10, 52, 391, DateTimeKind.Local).AddTicks(3289));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 19, 14, 10, 52, 391, DateTimeKind.Local).AddTicks(3292));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 19, 14, 10, 52, 391, DateTimeKind.Local).AddTicks(3296));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 19, 14, 10, 52, 391, DateTimeKind.Local).AddTicks(3300));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 19, 14, 10, 52, 391, DateTimeKind.Local).AddTicks(3303));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 19, 14, 10, 52, 391, DateTimeKind.Local).AddTicks(3307));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 19, 14, 10, 52, 391, DateTimeKind.Local).AddTicks(3310));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 19, 14, 10, 52, 391, DateTimeKind.Local).AddTicks(3314));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 19, 14, 10, 52, 391, DateTimeKind.Local).AddTicks(3317));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 19, 14, 10, 52, 391, DateTimeKind.Local).AddTicks(3434));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 19, 14, 10, 52, 391, DateTimeKind.Local).AddTicks(3438));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 19, 14, 10, 52, 391, DateTimeKind.Local).AddTicks(3441));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 19, 14, 10, 52, 391, DateTimeKind.Local).AddTicks(3445));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 19, 14, 10, 52, 391, DateTimeKind.Local).AddTicks(3449));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 19, 14, 10, 52, 391, DateTimeKind.Local).AddTicks(3479));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 19, 14, 10, 52, 391, DateTimeKind.Local).AddTicks(3491));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 19, 14, 10, 52, 391, DateTimeKind.Local).AddTicks(3495));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 19, 14, 10, 52, 391, DateTimeKind.Local).AddTicks(3498));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 19, 14, 10, 52, 391, DateTimeKind.Local).AddTicks(3502));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 19, 14, 10, 52, 391, DateTimeKind.Local).AddTicks(3505));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 19, 14, 10, 52, 391, DateTimeKind.Local).AddTicks(3509));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 19, 14, 10, 52, 391, DateTimeKind.Local).AddTicks(3513));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 19, 14, 10, 52, 391, DateTimeKind.Local).AddTicks(3516));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 19, 14, 10, 52, 391, DateTimeKind.Local).AddTicks(3520));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 19, 14, 10, 52, 391, DateTimeKind.Local).AddTicks(2047));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 19, 14, 10, 52, 391, DateTimeKind.Local).AddTicks(2068));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 19, 14, 10, 52, 391, DateTimeKind.Local).AddTicks(2074));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 19, 14, 10, 52, 391, DateTimeKind.Local).AddTicks(2079));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 19, 14, 10, 52, 391, DateTimeKind.Local).AddTicks(2084));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 19, 14, 10, 52, 391, DateTimeKind.Local).AddTicks(2089));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 19, 14, 10, 52, 391, DateTimeKind.Local).AddTicks(2094));
        }
    }
}
