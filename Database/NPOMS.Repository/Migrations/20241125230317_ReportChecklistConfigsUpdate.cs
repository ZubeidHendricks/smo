using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NPOMS.Repository.Migrations
{
    /// <inheritdoc />
    public partial class ReportChecklistConfigsUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "QaurterId",
                schema: "eval",
                table: "Responses",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "QaurterId",
                schema: "eval",
                table: "ResponseHistory",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                schema: "dropdown",
                table: "FundingTemplateTypes",
                columns: new[] { "Id", "IsActive", "Name", "SystemName", "UpdatedDateTime", "UpdatedUserId" },
                values: new object[] { 4, true, "Application Report", "ApplicationReport", null, null });

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 26, 1, 3, 7, 515, DateTimeKind.Local).AddTicks(3829));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 26, 1, 3, 7, 515, DateTimeKind.Local).AddTicks(3846));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 26, 1, 3, 7, 515, DateTimeKind.Local).AddTicks(3847));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 26, 1, 3, 7, 515, DateTimeKind.Local).AddTicks(3849));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 26, 1, 3, 7, 515, DateTimeKind.Local).AddTicks(3850));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 26, 1, 3, 7, 515, DateTimeKind.Local).AddTicks(3852));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 26, 1, 3, 7, 515, DateTimeKind.Local).AddTicks(3853));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 26, 1, 3, 7, 515, DateTimeKind.Local).AddTicks(3854));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 26, 1, 3, 7, 515, DateTimeKind.Local).AddTicks(3856));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 26, 1, 3, 7, 515, DateTimeKind.Local).AddTicks(3857));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 26, 1, 3, 7, 515, DateTimeKind.Local).AddTicks(3858));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 26, 1, 3, 7, 515, DateTimeKind.Local).AddTicks(3860));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 26, 1, 3, 7, 515, DateTimeKind.Local).AddTicks(3861));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 26, 1, 3, 7, 515, DateTimeKind.Local).AddTicks(3863));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 26, 1, 3, 7, 515, DateTimeKind.Local).AddTicks(3864));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 26, 1, 3, 7, 515, DateTimeKind.Local).AddTicks(3865));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 26, 1, 3, 7, 515, DateTimeKind.Local).AddTicks(3867));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 26, 1, 3, 7, 515, DateTimeKind.Local).AddTicks(3868));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 26, 1, 3, 7, 515, DateTimeKind.Local).AddTicks(3870));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 26, 1, 3, 7, 515, DateTimeKind.Local).AddTicks(3871));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 26, 1, 3, 7, 515, DateTimeKind.Local).AddTicks(3872));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 26, 1, 3, 7, 515, DateTimeKind.Local).AddTicks(3874));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 26, 1, 3, 7, 515, DateTimeKind.Local).AddTicks(3875));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 26, 1, 3, 7, 515, DateTimeKind.Local).AddTicks(3876));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 26, 1, 3, 7, 515, DateTimeKind.Local).AddTicks(3878));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 26, 1, 3, 7, 515, DateTimeKind.Local).AddTicks(3879));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 26, 1, 3, 7, 515, DateTimeKind.Local).AddTicks(3917));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 26, 1, 3, 7, 515, DateTimeKind.Local).AddTicks(3925));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 26, 1, 3, 7, 515, DateTimeKind.Local).AddTicks(3927));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 26, 1, 3, 7, 515, DateTimeKind.Local).AddTicks(3934));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 26, 1, 3, 7, 515, DateTimeKind.Local).AddTicks(3951));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 26, 1, 3, 7, 515, DateTimeKind.Local).AddTicks(3953));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 26, 1, 3, 7, 515, DateTimeKind.Local).AddTicks(4522));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 26, 1, 3, 7, 515, DateTimeKind.Local).AddTicks(4526));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 26, 1, 3, 7, 515, DateTimeKind.Local).AddTicks(4528));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 26, 1, 3, 7, 515, DateTimeKind.Local).AddTicks(4530));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 26, 1, 3, 7, 515, DateTimeKind.Local).AddTicks(4532));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 26, 1, 3, 7, 515, DateTimeKind.Local).AddTicks(4534));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 26, 1, 3, 7, 515, DateTimeKind.Local).AddTicks(4536));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "QuestionCategories",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 26, 1, 3, 7, 519, DateTimeKind.Local).AddTicks(8346));

            migrationBuilder.InsertData(
                schema: "eval",
                table: "QuestionCategories",
                columns: new[] { "Id", "CreatedDateTime", "CreatedUserId", "FundingTemplateTypeId", "IsActive", "Name", "UpdatedDateTime", "UpdatedUserId" },
                values: new object[] { 21, new DateTime(2024, 11, 26, 1, 3, 7, 519, DateTimeKind.Local).AddTicks(8359), 1, 4, true, "Application Report", null, null });

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "QuestionSections",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 25, 23, 3, 7, 520, DateTimeKind.Utc).AddTicks(3735));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "QuestionSections",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 25, 23, 3, 7, 520, DateTimeKind.Utc).AddTicks(3737));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "Questions",
                keyColumn: "Id",
                keyValue: 119,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 25, 23, 3, 7, 520, DateTimeKind.Utc).AddTicks(168));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "Questions",
                keyColumn: "Id",
                keyValue: 120,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 25, 23, 3, 7, 520, DateTimeKind.Utc).AddTicks(170));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "Questions",
                keyColumn: "Id",
                keyValue: 121,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 25, 23, 3, 7, 520, DateTimeKind.Utc).AddTicks(171));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "Questions",
                keyColumn: "Id",
                keyValue: 122,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 25, 23, 3, 7, 520, DateTimeKind.Utc).AddTicks(172));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseOptions",
                keyColumn: "Id",
                keyValue: 97,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 25, 23, 3, 7, 520, DateTimeKind.Utc).AddTicks(7065));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseOptions",
                keyColumn: "Id",
                keyValue: 100,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 25, 23, 3, 7, 520, DateTimeKind.Utc).AddTicks(7068));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseOptions",
                keyColumn: "Id",
                keyValue: 101,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 25, 23, 3, 7, 520, DateTimeKind.Utc).AddTicks(7069));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseOptions",
                keyColumn: "Id",
                keyValue: 102,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 25, 23, 3, 7, 520, DateTimeKind.Utc).AddTicks(7070));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseOptions",
                keyColumn: "Id",
                keyValue: 103,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 25, 23, 3, 7, 520, DateTimeKind.Utc).AddTicks(7071));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 26, 1, 3, 7, 520, DateTimeKind.Local).AddTicks(9137));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 26, 1, 3, 7, 520, DateTimeKind.Local).AddTicks(9145));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 26, 1, 3, 7, 520, DateTimeKind.Local).AddTicks(9146));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 26, 1, 3, 7, 520, DateTimeKind.Local).AddTicks(9147));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 26, 1, 3, 7, 520, DateTimeKind.Local).AddTicks(9148));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseTypes",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 26, 1, 3, 7, 520, DateTimeKind.Local).AddTicks(9150));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseTypes",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 26, 1, 3, 7, 520, DateTimeKind.Local).AddTicks(9151));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseTypes",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 26, 1, 3, 7, 520, DateTimeKind.Local).AddTicks(9152));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseTypes",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 26, 1, 3, 7, 520, DateTimeKind.Local).AddTicks(9153));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseTypes",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 26, 1, 3, 7, 520, DateTimeKind.Local).AddTicks(9154));

            migrationBuilder.InsertData(
                schema: "eval",
                table: "QuestionSections",
                columns: new[] { "Id", "CreatedDateTime", "CreatedUserId", "IsActive", "Name", "QuestionCategoryId", "SortOrder", "UpdatedDateTime", "UpdatedUserId" },
                values: new object[] { 35, new DateTime(2024, 11, 25, 23, 3, 7, 520, DateTimeKind.Utc).AddTicks(3739), 1, true, "Report Check list", 21, 1, null, null });

            migrationBuilder.InsertData(
                schema: "eval",
                table: "Questions",
                columns: new[] { "Id", "CreatedDateTime", "CreatedUserId", "IsActive", "Name", "QuestionSectionId", "ResponseTypeId", "SortOrder", "UpdatedDateTime", "UpdatedUserId" },
                values: new object[,]
                {
                    { 123, new DateTime(2024, 11, 25, 23, 3, 7, 520, DateTimeKind.Utc).AddTicks(174), 1, true, "Requires TPA/Submission?", 35, 6, 100, null, null },
                    { 124, new DateTime(2024, 11, 25, 23, 3, 7, 520, DateTimeKind.Utc).AddTicks(175), 1, true, "Verifiable reasons are provided for variance between reported and planned performance", 35, 6, 100, null, null },
                    { 125, new DateTime(2024, 11, 25, 23, 3, 7, 520, DateTimeKind.Utc).AddTicks(176), 1, true, "Reported perfomance informatioom relates to the correct service and output", 35, 6, 100, null, null },
                    { 126, new DateTime(2024, 11, 25, 23, 3, 7, 520, DateTimeKind.Utc).AddTicks(177), 1, true, "Reported performance information is for the correct reporting period", 35, 6, 100, null, null },
                    { 127, new DateTime(2024, 11, 25, 23, 3, 7, 520, DateTimeKind.Utc).AddTicks(179), 1, true, "Supporting documents have a title and page number on each page and signed and dated by the resonsible person", 35, 6, 100, null, null }
                });

            migrationBuilder.InsertData(
                schema: "eval",
                table: "QuestionProperties",
                columns: new[] { "Id", "CommentRequired", "DocumentRequired", "HasComment", "HasDocument", "QuestionId", "Weighting" },
                values: new object[,]
                {
                    { 123, false, false, true, false, 123, 0 },
                    { 124, false, false, true, false, 124, 0 },
                    { 125, false, false, true, false, 125, 0 },
                    { 126, false, false, true, false, 126, 0 },
                    { 127, false, false, true, false, 127, 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "FundingTemplateTypes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "eval",
                table: "QuestionProperties",
                keyColumn: "Id",
                keyValue: 123);

            migrationBuilder.DeleteData(
                schema: "eval",
                table: "QuestionProperties",
                keyColumn: "Id",
                keyValue: 124);

            migrationBuilder.DeleteData(
                schema: "eval",
                table: "QuestionProperties",
                keyColumn: "Id",
                keyValue: 125);

            migrationBuilder.DeleteData(
                schema: "eval",
                table: "QuestionProperties",
                keyColumn: "Id",
                keyValue: 126);

            migrationBuilder.DeleteData(
                schema: "eval",
                table: "QuestionProperties",
                keyColumn: "Id",
                keyValue: 127);

            migrationBuilder.DeleteData(
                schema: "eval",
                table: "Questions",
                keyColumn: "Id",
                keyValue: 123);

            migrationBuilder.DeleteData(
                schema: "eval",
                table: "Questions",
                keyColumn: "Id",
                keyValue: 124);

            migrationBuilder.DeleteData(
                schema: "eval",
                table: "Questions",
                keyColumn: "Id",
                keyValue: 125);

            migrationBuilder.DeleteData(
                schema: "eval",
                table: "Questions",
                keyColumn: "Id",
                keyValue: 126);

            migrationBuilder.DeleteData(
                schema: "eval",
                table: "Questions",
                keyColumn: "Id",
                keyValue: 127);

            migrationBuilder.DeleteData(
                schema: "eval",
                table: "QuestionSections",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                schema: "eval",
                table: "QuestionCategories",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DropColumn(
                name: "QaurterId",
                schema: "eval",
                table: "Responses");

            migrationBuilder.DropColumn(
                name: "QaurterId",
                schema: "eval",
                table: "ResponseHistory");

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 25, 6, 30, 41, 893, DateTimeKind.Local).AddTicks(227));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 25, 6, 30, 41, 893, DateTimeKind.Local).AddTicks(243));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 25, 6, 30, 41, 893, DateTimeKind.Local).AddTicks(245));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 25, 6, 30, 41, 893, DateTimeKind.Local).AddTicks(246));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 25, 6, 30, 41, 893, DateTimeKind.Local).AddTicks(248));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 25, 6, 30, 41, 893, DateTimeKind.Local).AddTicks(250));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 25, 6, 30, 41, 893, DateTimeKind.Local).AddTicks(251));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 25, 6, 30, 41, 893, DateTimeKind.Local).AddTicks(253));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 25, 6, 30, 41, 893, DateTimeKind.Local).AddTicks(254));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 25, 6, 30, 41, 893, DateTimeKind.Local).AddTicks(257));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 25, 6, 30, 41, 893, DateTimeKind.Local).AddTicks(259));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 25, 6, 30, 41, 893, DateTimeKind.Local).AddTicks(261));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 25, 6, 30, 41, 893, DateTimeKind.Local).AddTicks(265));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 25, 6, 30, 41, 893, DateTimeKind.Local).AddTicks(266));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 25, 6, 30, 41, 893, DateTimeKind.Local).AddTicks(268));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 25, 6, 30, 41, 893, DateTimeKind.Local).AddTicks(269));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 25, 6, 30, 41, 893, DateTimeKind.Local).AddTicks(271));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 25, 6, 30, 41, 893, DateTimeKind.Local).AddTicks(272));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 25, 6, 30, 41, 893, DateTimeKind.Local).AddTicks(274));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 25, 6, 30, 41, 893, DateTimeKind.Local).AddTicks(275));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 25, 6, 30, 41, 893, DateTimeKind.Local).AddTicks(277));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 25, 6, 30, 41, 893, DateTimeKind.Local).AddTicks(309));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 25, 6, 30, 41, 893, DateTimeKind.Local).AddTicks(311));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 25, 6, 30, 41, 893, DateTimeKind.Local).AddTicks(313));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 25, 6, 30, 41, 893, DateTimeKind.Local).AddTicks(314));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 25, 6, 30, 41, 893, DateTimeKind.Local).AddTicks(316));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 25, 6, 30, 41, 893, DateTimeKind.Local).AddTicks(317));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 25, 6, 30, 41, 893, DateTimeKind.Local).AddTicks(325));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 25, 6, 30, 41, 893, DateTimeKind.Local).AddTicks(327));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 25, 6, 30, 41, 893, DateTimeKind.Local).AddTicks(343));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 25, 6, 30, 41, 893, DateTimeKind.Local).AddTicks(357));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 25, 6, 30, 41, 893, DateTimeKind.Local).AddTicks(359));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 25, 6, 30, 41, 893, DateTimeKind.Local).AddTicks(1065));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 25, 6, 30, 41, 893, DateTimeKind.Local).AddTicks(1072));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 25, 6, 30, 41, 893, DateTimeKind.Local).AddTicks(1074));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 25, 6, 30, 41, 893, DateTimeKind.Local).AddTicks(1076));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 25, 6, 30, 41, 893, DateTimeKind.Local).AddTicks(1078));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 25, 6, 30, 41, 893, DateTimeKind.Local).AddTicks(1081));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 25, 6, 30, 41, 893, DateTimeKind.Local).AddTicks(1083));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "QuestionCategories",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 25, 6, 30, 41, 898, DateTimeKind.Local).AddTicks(4414));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "QuestionSections",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 25, 4, 30, 41, 899, DateTimeKind.Utc).AddTicks(138));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "QuestionSections",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 25, 4, 30, 41, 899, DateTimeKind.Utc).AddTicks(140));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "Questions",
                keyColumn: "Id",
                keyValue: 119,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 25, 4, 30, 41, 898, DateTimeKind.Utc).AddTicks(6358));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "Questions",
                keyColumn: "Id",
                keyValue: 120,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 25, 4, 30, 41, 898, DateTimeKind.Utc).AddTicks(6360));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "Questions",
                keyColumn: "Id",
                keyValue: 121,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 25, 4, 30, 41, 898, DateTimeKind.Utc).AddTicks(6362));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "Questions",
                keyColumn: "Id",
                keyValue: 122,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 25, 4, 30, 41, 898, DateTimeKind.Utc).AddTicks(6363));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseOptions",
                keyColumn: "Id",
                keyValue: 97,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 25, 4, 30, 41, 899, DateTimeKind.Utc).AddTicks(3920));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseOptions",
                keyColumn: "Id",
                keyValue: 100,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 25, 4, 30, 41, 899, DateTimeKind.Utc).AddTicks(3923));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseOptions",
                keyColumn: "Id",
                keyValue: 101,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 25, 4, 30, 41, 899, DateTimeKind.Utc).AddTicks(3925));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseOptions",
                keyColumn: "Id",
                keyValue: 102,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 25, 4, 30, 41, 899, DateTimeKind.Utc).AddTicks(3927));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseOptions",
                keyColumn: "Id",
                keyValue: 103,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 25, 4, 30, 41, 899, DateTimeKind.Utc).AddTicks(3928));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 25, 6, 30, 41, 899, DateTimeKind.Local).AddTicks(6196));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 25, 6, 30, 41, 899, DateTimeKind.Local).AddTicks(6203));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 25, 6, 30, 41, 899, DateTimeKind.Local).AddTicks(6205));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 25, 6, 30, 41, 899, DateTimeKind.Local).AddTicks(6207));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 25, 6, 30, 41, 899, DateTimeKind.Local).AddTicks(6210));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseTypes",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 25, 6, 30, 41, 899, DateTimeKind.Local).AddTicks(6212));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseTypes",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 25, 6, 30, 41, 899, DateTimeKind.Local).AddTicks(6214));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseTypes",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 25, 6, 30, 41, 899, DateTimeKind.Local).AddTicks(6216));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseTypes",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 25, 6, 30, 41, 899, DateTimeKind.Local).AddTicks(6219));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseTypes",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 25, 6, 30, 41, 899, DateTimeKind.Local).AddTicks(6220));
        }
    }
}
