using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NPOMS.Repository.Migrations
{
    /// <inheritdoc />
    public partial class addendum_statuses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAddendum",
                schema: "fm",
                table: "PaymentSchedules",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsAddendum",
                schema: "fm",
                table: "PaymentScheduleItems",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasAddendum",
                schema: "fm",
                table: "FundingCaptures",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 22, 10, 46, 16, 139, DateTimeKind.Local).AddTicks(3896));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 22, 10, 46, 16, 139, DateTimeKind.Local).AddTicks(3952));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 22, 10, 46, 16, 139, DateTimeKind.Local).AddTicks(3954));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 22, 10, 46, 16, 139, DateTimeKind.Local).AddTicks(3955));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 22, 10, 46, 16, 139, DateTimeKind.Local).AddTicks(3956));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 22, 10, 46, 16, 139, DateTimeKind.Local).AddTicks(3958));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 22, 10, 46, 16, 139, DateTimeKind.Local).AddTicks(3959));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 22, 10, 46, 16, 139, DateTimeKind.Local).AddTicks(3960));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 22, 10, 46, 16, 139, DateTimeKind.Local).AddTicks(3962));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 22, 10, 46, 16, 139, DateTimeKind.Local).AddTicks(3963));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 22, 10, 46, 16, 139, DateTimeKind.Local).AddTicks(3965));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 22, 10, 46, 16, 139, DateTimeKind.Local).AddTicks(3966));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 22, 10, 46, 16, 139, DateTimeKind.Local).AddTicks(3968));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 22, 10, 46, 16, 139, DateTimeKind.Local).AddTicks(3969));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 22, 10, 46, 16, 139, DateTimeKind.Local).AddTicks(3971));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 22, 10, 46, 16, 139, DateTimeKind.Local).AddTicks(3972));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 22, 10, 46, 16, 139, DateTimeKind.Local).AddTicks(3973));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 22, 10, 46, 16, 139, DateTimeKind.Local).AddTicks(3975));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 22, 10, 46, 16, 139, DateTimeKind.Local).AddTicks(3976));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 22, 10, 46, 16, 139, DateTimeKind.Local).AddTicks(3977));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 22, 10, 46, 16, 139, DateTimeKind.Local).AddTicks(3979));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 22, 10, 46, 16, 139, DateTimeKind.Local).AddTicks(3980));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 22, 10, 46, 16, 139, DateTimeKind.Local).AddTicks(3981));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 22, 10, 46, 16, 139, DateTimeKind.Local).AddTicks(3982));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 22, 10, 46, 16, 139, DateTimeKind.Local).AddTicks(3984));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 22, 10, 46, 16, 139, DateTimeKind.Local).AddTicks(3985));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 22, 10, 46, 16, 139, DateTimeKind.Local).AddTicks(3987));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 22, 10, 46, 16, 139, DateTimeKind.Local).AddTicks(3993));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 22, 10, 46, 16, 139, DateTimeKind.Local).AddTicks(3995));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 22, 10, 46, 16, 139, DateTimeKind.Local).AddTicks(4000));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 22, 10, 46, 16, 139, DateTimeKind.Local).AddTicks(4014));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 22, 10, 46, 16, 139, DateTimeKind.Local).AddTicks(4015));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 22, 10, 46, 16, 139, DateTimeKind.Local).AddTicks(4520));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 22, 10, 46, 16, 139, DateTimeKind.Local).AddTicks(4524));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 22, 10, 46, 16, 139, DateTimeKind.Local).AddTicks(4526));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 22, 10, 46, 16, 139, DateTimeKind.Local).AddTicks(4528));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 22, 10, 46, 16, 139, DateTimeKind.Local).AddTicks(4530));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 22, 10, 46, 16, 139, DateTimeKind.Local).AddTicks(4531));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 22, 10, 46, 16, 139, DateTimeKind.Local).AddTicks(4533));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "QuestionCategories",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 22, 10, 46, 16, 143, DateTimeKind.Local).AddTicks(1709));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "QuestionSections",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 22, 8, 46, 16, 143, DateTimeKind.Utc).AddTicks(7725));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "QuestionSections",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 22, 8, 46, 16, 143, DateTimeKind.Utc).AddTicks(7726));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "Questions",
                keyColumn: "Id",
                keyValue: 119,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 22, 8, 46, 16, 143, DateTimeKind.Utc).AddTicks(3166));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "Questions",
                keyColumn: "Id",
                keyValue: 120,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 22, 8, 46, 16, 143, DateTimeKind.Utc).AddTicks(3168));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "Questions",
                keyColumn: "Id",
                keyValue: 121,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 22, 8, 46, 16, 143, DateTimeKind.Utc).AddTicks(3169));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "Questions",
                keyColumn: "Id",
                keyValue: 122,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 22, 8, 46, 16, 143, DateTimeKind.Utc).AddTicks(3170));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseOptions",
                keyColumn: "Id",
                keyValue: 97,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 22, 8, 46, 16, 144, DateTimeKind.Utc).AddTicks(4088));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseOptions",
                keyColumn: "Id",
                keyValue: 100,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 22, 8, 46, 16, 144, DateTimeKind.Utc).AddTicks(4092));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseOptions",
                keyColumn: "Id",
                keyValue: 101,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 22, 8, 46, 16, 144, DateTimeKind.Utc).AddTicks(4093));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseOptions",
                keyColumn: "Id",
                keyValue: 102,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 22, 8, 46, 16, 144, DateTimeKind.Utc).AddTicks(4095));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseOptions",
                keyColumn: "Id",
                keyValue: 103,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 22, 8, 46, 16, 144, DateTimeKind.Utc).AddTicks(4096));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 22, 10, 46, 16, 144, DateTimeKind.Local).AddTicks(6750));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 22, 10, 46, 16, 144, DateTimeKind.Local).AddTicks(6762));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 22, 10, 46, 16, 144, DateTimeKind.Local).AddTicks(6764));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 22, 10, 46, 16, 144, DateTimeKind.Local).AddTicks(6765));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 22, 10, 46, 16, 144, DateTimeKind.Local).AddTicks(6767));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseTypes",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 22, 10, 46, 16, 144, DateTimeKind.Local).AddTicks(6768));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseTypes",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 22, 10, 46, 16, 144, DateTimeKind.Local).AddTicks(6769));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseTypes",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 22, 10, 46, 16, 144, DateTimeKind.Local).AddTicks(6770));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseTypes",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 22, 10, 46, 16, 144, DateTimeKind.Local).AddTicks(6771));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseTypes",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 22, 10, 46, 16, 144, DateTimeKind.Local).AddTicks(6772));

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Statuses",
                columns: new[] { "Id", "Name", "SystemName", "UpdatedDateTime", "UpdatedUserId" },
                values: new object[,]
                {
                    { 25, "Addendum Saved", "AddendumSaved", null, null },
                    { 26, "Addendum Pending Approval", "AddendumPendingApproval", null, null },
                    { 27, "Addendum Approved", "AddendumApproved", null, null },
                    { 28, "Addendum Rejected", "AddendumRejected", null, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Statuses",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Statuses",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Statuses",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Statuses",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DropColumn(
                name: "IsAddendum",
                schema: "fm",
                table: "PaymentSchedules");

            migrationBuilder.DropColumn(
                name: "IsAddendum",
                schema: "fm",
                table: "PaymentScheduleItems");

            migrationBuilder.DropColumn(
                name: "HasAddendum",
                schema: "fm",
                table: "FundingCaptures");

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
    }
}
