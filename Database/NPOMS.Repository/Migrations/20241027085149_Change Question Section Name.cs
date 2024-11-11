using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NPOMS.Repository.Migrations
{
    /// <inheritdoc />
    public partial class ChangeQuestionSectionName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "QuestionSections",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "CreatedDateTime", "Name" },
                values: new object[] { new DateTime(2024, 10, 27, 10, 51, 40, 739, DateTimeKind.Local).AddTicks(1334), "Analysis Performance" });

           
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 21, 9, 20, 8, 391, DateTimeKind.Local).AddTicks(4814));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 21, 9, 20, 8, 391, DateTimeKind.Local).AddTicks(4840));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 21, 9, 20, 8, 391, DateTimeKind.Local).AddTicks(4842));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 21, 9, 20, 8, 391, DateTimeKind.Local).AddTicks(4844));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 21, 9, 20, 8, 391, DateTimeKind.Local).AddTicks(4846));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 21, 9, 20, 8, 391, DateTimeKind.Local).AddTicks(4847));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 21, 9, 20, 8, 391, DateTimeKind.Local).AddTicks(4849));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 21, 9, 20, 8, 391, DateTimeKind.Local).AddTicks(4854));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 21, 9, 20, 8, 391, DateTimeKind.Local).AddTicks(4856));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 21, 9, 20, 8, 391, DateTimeKind.Local).AddTicks(4858));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 21, 9, 20, 8, 391, DateTimeKind.Local).AddTicks(4859));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 21, 9, 20, 8, 391, DateTimeKind.Local).AddTicks(4861));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 21, 9, 20, 8, 391, DateTimeKind.Local).AddTicks(4863));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 21, 9, 20, 8, 391, DateTimeKind.Local).AddTicks(4865));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 21, 9, 20, 8, 391, DateTimeKind.Local).AddTicks(4867));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 21, 9, 20, 8, 391, DateTimeKind.Local).AddTicks(4869));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 21, 9, 20, 8, 391, DateTimeKind.Local).AddTicks(4870));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 21, 9, 20, 8, 391, DateTimeKind.Local).AddTicks(4872));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 21, 9, 20, 8, 391, DateTimeKind.Local).AddTicks(4874));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 21, 9, 20, 8, 391, DateTimeKind.Local).AddTicks(4876));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 21, 9, 20, 8, 391, DateTimeKind.Local).AddTicks(4877));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 21, 9, 20, 8, 391, DateTimeKind.Local).AddTicks(4898));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 21, 9, 20, 8, 391, DateTimeKind.Local).AddTicks(4900));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 21, 9, 20, 8, 391, DateTimeKind.Local).AddTicks(4902));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 21, 9, 20, 8, 391, DateTimeKind.Local).AddTicks(4903));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 21, 9, 20, 8, 391, DateTimeKind.Local).AddTicks(4905));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 21, 9, 20, 8, 391, DateTimeKind.Local).AddTicks(4907));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 21, 9, 20, 8, 391, DateTimeKind.Local).AddTicks(4909));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 21, 9, 20, 8, 391, DateTimeKind.Local).AddTicks(4910));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 21, 9, 20, 8, 391, DateTimeKind.Local).AddTicks(4918));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 21, 9, 20, 8, 391, DateTimeKind.Local).AddTicks(4938));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 21, 9, 20, 8, 391, DateTimeKind.Local).AddTicks(4939));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 21, 9, 20, 8, 391, DateTimeKind.Local).AddTicks(5857));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 21, 9, 20, 8, 391, DateTimeKind.Local).AddTicks(5862));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 21, 9, 20, 8, 391, DateTimeKind.Local).AddTicks(5864));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 21, 9, 20, 8, 391, DateTimeKind.Local).AddTicks(5870));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 21, 9, 20, 8, 391, DateTimeKind.Local).AddTicks(5872));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 21, 9, 20, 8, 391, DateTimeKind.Local).AddTicks(5874));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 21, 9, 20, 8, 391, DateTimeKind.Local).AddTicks(5876));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "QuestionCategories",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 21, 9, 20, 8, 398, DateTimeKind.Local).AddTicks(1869));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "QuestionSections",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 21, 9, 20, 8, 399, DateTimeKind.Local).AddTicks(1670));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "QuestionSections",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 21, 9, 20, 8, 399, DateTimeKind.Local).AddTicks(1680));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "QuestionSections",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "CreatedDateTime", "Name" },
                values: new object[] { new DateTime(2024, 10, 21, 9, 20, 8, 399, DateTimeKind.Local).AddTicks(1681), "AnalysisPerformance" });

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "Questions",
                keyColumn: "Id",
                keyValue: 100,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 21, 9, 20, 8, 398, DateTimeKind.Local).AddTicks(5267));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "Questions",
                keyColumn: "Id",
                keyValue: 101,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 21, 9, 20, 8, 398, DateTimeKind.Local).AddTicks(5287));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "Questions",
                keyColumn: "Id",
                keyValue: 102,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 21, 9, 20, 8, 398, DateTimeKind.Local).AddTicks(5289));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "Questions",
                keyColumn: "Id",
                keyValue: 103,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 21, 9, 20, 8, 398, DateTimeKind.Local).AddTicks(5291));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "Questions",
                keyColumn: "Id",
                keyValue: 104,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 21, 9, 20, 8, 398, DateTimeKind.Local).AddTicks(5293));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "Questions",
                keyColumn: "Id",
                keyValue: 106,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 21, 9, 20, 8, 398, DateTimeKind.Local).AddTicks(5295));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "Questions",
                keyColumn: "Id",
                keyValue: 107,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 21, 9, 20, 8, 398, DateTimeKind.Local).AddTicks(5297));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "Questions",
                keyColumn: "Id",
                keyValue: 108,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 21, 9, 20, 8, 398, DateTimeKind.Local).AddTicks(5299));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "Questions",
                keyColumn: "Id",
                keyValue: 109,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 21, 9, 20, 8, 398, DateTimeKind.Local).AddTicks(5339));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "Questions",
                keyColumn: "Id",
                keyValue: 110,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 21, 9, 20, 8, 398, DateTimeKind.Local).AddTicks(5341));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "Questions",
                keyColumn: "Id",
                keyValue: 111,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 21, 9, 20, 8, 398, DateTimeKind.Local).AddTicks(5343));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "Questions",
                keyColumn: "Id",
                keyValue: 112,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 21, 9, 20, 8, 398, DateTimeKind.Local).AddTicks(5345));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "Questions",
                keyColumn: "Id",
                keyValue: 113,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 21, 9, 20, 8, 398, DateTimeKind.Local).AddTicks(5346));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "Questions",
                keyColumn: "Id",
                keyValue: 114,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 21, 9, 20, 8, 398, DateTimeKind.Local).AddTicks(5348));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "Questions",
                keyColumn: "Id",
                keyValue: 115,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 21, 9, 20, 8, 398, DateTimeKind.Local).AddTicks(5350));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseOptions",
                keyColumn: "Id",
                keyValue: 50,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 21, 9, 20, 8, 399, DateTimeKind.Local).AddTicks(4003));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseOptions",
                keyColumn: "Id",
                keyValue: 51,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 21, 9, 20, 8, 399, DateTimeKind.Local).AddTicks(4011));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseOptions",
                keyColumn: "Id",
                keyValue: 52,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 21, 9, 20, 8, 399, DateTimeKind.Local).AddTicks(4013));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseOptions",
                keyColumn: "Id",
                keyValue: 53,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 21, 9, 20, 8, 399, DateTimeKind.Local).AddTicks(4014));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseOptions",
                keyColumn: "Id",
                keyValue: 54,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 21, 9, 20, 8, 399, DateTimeKind.Local).AddTicks(4016));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 21, 9, 20, 8, 399, DateTimeKind.Local).AddTicks(6286));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 21, 9, 20, 8, 399, DateTimeKind.Local).AddTicks(6295));
        }
    }
}
