using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NPOMS.Repository.Migrations
{
    /// <inheritdoc />
    public partial class AddfundingSDA : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FundingAssessmentFormSDAs",
                schema: "fuas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FundingAssessmentFormId = table.Column<int>(type: "int", nullable: false),
                    ProgrameServiceDeliveryAreaId = table.Column<int>(type: "int", nullable: false),
                    IsSelected = table.Column<bool>(type: "bit", nullable: false),
                    FundingAssessmentFormId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FundingAssessmentFormSDAs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FundingAssessmentFormSDAs_FundingAssessmentForms_FundingAssessmentFormId",
                        column: x => x.FundingAssessmentFormId,
                        principalSchema: "fuas",
                        principalTable: "FundingAssessmentForms",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FundingAssessmentFormSDAs_FundingAssessmentForms_FundingAssessmentFormId1",
                        column: x => x.FundingAssessmentFormId1,
                        principalSchema: "fuas",
                        principalTable: "FundingAssessmentForms",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 4, 22, 11, 28, 160, DateTimeKind.Local).AddTicks(5856));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 4, 22, 11, 28, 160, DateTimeKind.Local).AddTicks(5877));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 4, 22, 11, 28, 160, DateTimeKind.Local).AddTicks(5879));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 4, 22, 11, 28, 160, DateTimeKind.Local).AddTicks(5881));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 4, 22, 11, 28, 160, DateTimeKind.Local).AddTicks(5883));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 4, 22, 11, 28, 160, DateTimeKind.Local).AddTicks(5885));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 4, 22, 11, 28, 160, DateTimeKind.Local).AddTicks(5886));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 4, 22, 11, 28, 160, DateTimeKind.Local).AddTicks(5892));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 4, 22, 11, 28, 160, DateTimeKind.Local).AddTicks(5893));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 4, 22, 11, 28, 160, DateTimeKind.Local).AddTicks(5895));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 4, 22, 11, 28, 160, DateTimeKind.Local).AddTicks(5897));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 4, 22, 11, 28, 160, DateTimeKind.Local).AddTicks(5898));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 4, 22, 11, 28, 160, DateTimeKind.Local).AddTicks(5900));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 4, 22, 11, 28, 160, DateTimeKind.Local).AddTicks(5902));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 4, 22, 11, 28, 160, DateTimeKind.Local).AddTicks(5904));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 4, 22, 11, 28, 160, DateTimeKind.Local).AddTicks(5906));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 4, 22, 11, 28, 160, DateTimeKind.Local).AddTicks(5908));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 4, 22, 11, 28, 160, DateTimeKind.Local).AddTicks(5909));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 4, 22, 11, 28, 160, DateTimeKind.Local).AddTicks(5911));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 4, 22, 11, 28, 160, DateTimeKind.Local).AddTicks(5913));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 4, 22, 11, 28, 160, DateTimeKind.Local).AddTicks(5914));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 4, 22, 11, 28, 160, DateTimeKind.Local).AddTicks(5921));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 4, 22, 11, 28, 160, DateTimeKind.Local).AddTicks(5923));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 4, 22, 11, 28, 160, DateTimeKind.Local).AddTicks(5925));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 4, 22, 11, 28, 160, DateTimeKind.Local).AddTicks(5926));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 4, 22, 11, 28, 160, DateTimeKind.Local).AddTicks(5931));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 4, 22, 11, 28, 160, DateTimeKind.Local).AddTicks(5933));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 4, 22, 11, 28, 160, DateTimeKind.Local).AddTicks(5934));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 4, 22, 11, 28, 160, DateTimeKind.Local).AddTicks(5936));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 4, 22, 11, 28, 160, DateTimeKind.Local).AddTicks(5941));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 4, 22, 11, 28, 160, DateTimeKind.Local).AddTicks(5958));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 4, 22, 11, 28, 160, DateTimeKind.Local).AddTicks(5960));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 4, 22, 11, 28, 160, DateTimeKind.Local).AddTicks(6701));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 4, 22, 11, 28, 160, DateTimeKind.Local).AddTicks(6705));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 4, 22, 11, 28, 160, DateTimeKind.Local).AddTicks(6708));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 4, 22, 11, 28, 160, DateTimeKind.Local).AddTicks(6713));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 4, 22, 11, 28, 160, DateTimeKind.Local).AddTicks(6716));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 4, 22, 11, 28, 160, DateTimeKind.Local).AddTicks(6718));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 4, 22, 11, 28, 160, DateTimeKind.Local).AddTicks(6720));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "QuestionCategories",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 4, 22, 11, 28, 167, DateTimeKind.Local).AddTicks(1815));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "QuestionSections",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 4, 20, 11, 28, 167, DateTimeKind.Utc).AddTicks(7756));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "QuestionSections",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 4, 20, 11, 28, 167, DateTimeKind.Utc).AddTicks(7758));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "Questions",
                keyColumn: "Id",
                keyValue: 119,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 4, 20, 11, 28, 167, DateTimeKind.Utc).AddTicks(3799));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "Questions",
                keyColumn: "Id",
                keyValue: 120,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 4, 20, 11, 28, 167, DateTimeKind.Utc).AddTicks(3801));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "Questions",
                keyColumn: "Id",
                keyValue: 121,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 4, 20, 11, 28, 167, DateTimeKind.Utc).AddTicks(3802));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "Questions",
                keyColumn: "Id",
                keyValue: 122,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 4, 20, 11, 28, 167, DateTimeKind.Utc).AddTicks(3803));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseOptions",
                keyColumn: "Id",
                keyValue: 97,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 4, 20, 11, 28, 168, DateTimeKind.Utc).AddTicks(1750));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseOptions",
                keyColumn: "Id",
                keyValue: 100,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 4, 20, 11, 28, 168, DateTimeKind.Utc).AddTicks(1753));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseOptions",
                keyColumn: "Id",
                keyValue: 101,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 4, 20, 11, 28, 168, DateTimeKind.Utc).AddTicks(1754));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseOptions",
                keyColumn: "Id",
                keyValue: 102,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 4, 20, 11, 28, 168, DateTimeKind.Utc).AddTicks(1755));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseOptions",
                keyColumn: "Id",
                keyValue: 103,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 4, 20, 11, 28, 168, DateTimeKind.Utc).AddTicks(1756));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 4, 22, 11, 28, 168, DateTimeKind.Local).AddTicks(4011));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 4, 22, 11, 28, 168, DateTimeKind.Local).AddTicks(4021));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 4, 22, 11, 28, 168, DateTimeKind.Local).AddTicks(4022));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 4, 22, 11, 28, 168, DateTimeKind.Local).AddTicks(4023));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 4, 22, 11, 28, 168, DateTimeKind.Local).AddTicks(4025));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseTypes",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 4, 22, 11, 28, 168, DateTimeKind.Local).AddTicks(4026));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseTypes",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 4, 22, 11, 28, 168, DateTimeKind.Local).AddTicks(4027));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseTypes",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 4, 22, 11, 28, 168, DateTimeKind.Local).AddTicks(4029));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseTypes",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 4, 22, 11, 28, 168, DateTimeKind.Local).AddTicks(4033));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseTypes",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 4, 22, 11, 28, 168, DateTimeKind.Local).AddTicks(4034));

            migrationBuilder.CreateIndex(
                name: "IX_FundingAssessmentFormSDAs_FundingAssessmentFormId",
                schema: "fuas",
                table: "FundingAssessmentFormSDAs",
                column: "FundingAssessmentFormId");

            migrationBuilder.CreateIndex(
                name: "IX_FundingAssessmentFormSDAs_FundingAssessmentFormId1",
                schema: "fuas",
                table: "FundingAssessmentFormSDAs",
                column: "FundingAssessmentFormId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FundingAssessmentFormSDAs",
                schema: "fuas");

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 3, 18, 34, 36, 350, DateTimeKind.Local).AddTicks(2776));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 3, 18, 34, 36, 350, DateTimeKind.Local).AddTicks(2807));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 3, 18, 34, 36, 350, DateTimeKind.Local).AddTicks(2808));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 3, 18, 34, 36, 350, DateTimeKind.Local).AddTicks(2810));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 3, 18, 34, 36, 350, DateTimeKind.Local).AddTicks(2812));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 3, 18, 34, 36, 350, DateTimeKind.Local).AddTicks(2813));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 3, 18, 34, 36, 350, DateTimeKind.Local).AddTicks(2816));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 3, 18, 34, 36, 350, DateTimeKind.Local).AddTicks(2818));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 3, 18, 34, 36, 350, DateTimeKind.Local).AddTicks(2819));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 3, 18, 34, 36, 350, DateTimeKind.Local).AddTicks(2821));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 3, 18, 34, 36, 350, DateTimeKind.Local).AddTicks(2822));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 3, 18, 34, 36, 350, DateTimeKind.Local).AddTicks(2824));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 3, 18, 34, 36, 350, DateTimeKind.Local).AddTicks(2826));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 3, 18, 34, 36, 350, DateTimeKind.Local).AddTicks(2827));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 3, 18, 34, 36, 350, DateTimeKind.Local).AddTicks(2829));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 3, 18, 34, 36, 350, DateTimeKind.Local).AddTicks(2831));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 3, 18, 34, 36, 350, DateTimeKind.Local).AddTicks(2832));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 3, 18, 34, 36, 350, DateTimeKind.Local).AddTicks(2834));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 3, 18, 34, 36, 350, DateTimeKind.Local).AddTicks(2836));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 3, 18, 34, 36, 350, DateTimeKind.Local).AddTicks(2837));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 3, 18, 34, 36, 350, DateTimeKind.Local).AddTicks(2839));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 3, 18, 34, 36, 350, DateTimeKind.Local).AddTicks(2852));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 3, 18, 34, 36, 350, DateTimeKind.Local).AddTicks(2854));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 3, 18, 34, 36, 350, DateTimeKind.Local).AddTicks(2856));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 3, 18, 34, 36, 350, DateTimeKind.Local).AddTicks(2857));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 3, 18, 34, 36, 350, DateTimeKind.Local).AddTicks(2859));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 3, 18, 34, 36, 350, DateTimeKind.Local).AddTicks(2860));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 3, 18, 34, 36, 350, DateTimeKind.Local).AddTicks(2862));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 3, 18, 34, 36, 350, DateTimeKind.Local).AddTicks(2864));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 3, 18, 34, 36, 350, DateTimeKind.Local).AddTicks(2868));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 3, 18, 34, 36, 350, DateTimeKind.Local).AddTicks(2886));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 3, 18, 34, 36, 350, DateTimeKind.Local).AddTicks(2888));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 3, 18, 34, 36, 350, DateTimeKind.Local).AddTicks(3723));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 3, 18, 34, 36, 350, DateTimeKind.Local).AddTicks(3728));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 3, 18, 34, 36, 350, DateTimeKind.Local).AddTicks(3731));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 3, 18, 34, 36, 350, DateTimeKind.Local).AddTicks(3733));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 3, 18, 34, 36, 350, DateTimeKind.Local).AddTicks(3735));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 3, 18, 34, 36, 350, DateTimeKind.Local).AddTicks(3737));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 3, 18, 34, 36, 350, DateTimeKind.Local).AddTicks(3743));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "QuestionCategories",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 3, 18, 34, 36, 355, DateTimeKind.Local).AddTicks(8724));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "QuestionSections",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 3, 16, 34, 36, 356, DateTimeKind.Utc).AddTicks(4961));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "QuestionSections",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 3, 16, 34, 36, 356, DateTimeKind.Utc).AddTicks(4963));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "Questions",
                keyColumn: "Id",
                keyValue: 119,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 3, 16, 34, 36, 356, DateTimeKind.Utc).AddTicks(710));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "Questions",
                keyColumn: "Id",
                keyValue: 120,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 3, 16, 34, 36, 356, DateTimeKind.Utc).AddTicks(711));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "Questions",
                keyColumn: "Id",
                keyValue: 121,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 3, 16, 34, 36, 356, DateTimeKind.Utc).AddTicks(713));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "Questions",
                keyColumn: "Id",
                keyValue: 122,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 3, 16, 34, 36, 356, DateTimeKind.Utc).AddTicks(714));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseOptions",
                keyColumn: "Id",
                keyValue: 97,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 3, 16, 34, 36, 356, DateTimeKind.Utc).AddTicks(8929));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseOptions",
                keyColumn: "Id",
                keyValue: 100,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 3, 16, 34, 36, 356, DateTimeKind.Utc).AddTicks(8932));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseOptions",
                keyColumn: "Id",
                keyValue: 101,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 3, 16, 34, 36, 356, DateTimeKind.Utc).AddTicks(8933));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseOptions",
                keyColumn: "Id",
                keyValue: 102,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 3, 16, 34, 36, 356, DateTimeKind.Utc).AddTicks(8935));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseOptions",
                keyColumn: "Id",
                keyValue: 103,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 3, 16, 34, 36, 356, DateTimeKind.Utc).AddTicks(8936));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 3, 18, 34, 36, 357, DateTimeKind.Local).AddTicks(1239));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 3, 18, 34, 36, 357, DateTimeKind.Local).AddTicks(1258));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 3, 18, 34, 36, 357, DateTimeKind.Local).AddTicks(1259));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 3, 18, 34, 36, 357, DateTimeKind.Local).AddTicks(1261));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 3, 18, 34, 36, 357, DateTimeKind.Local).AddTicks(1262));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseTypes",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 3, 18, 34, 36, 357, DateTimeKind.Local).AddTicks(1263));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseTypes",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 3, 18, 34, 36, 357, DateTimeKind.Local).AddTicks(1265));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseTypes",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 3, 18, 34, 36, 357, DateTimeKind.Local).AddTicks(1266));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseTypes",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 3, 18, 34, 36, 357, DateTimeKind.Local).AddTicks(1267));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseTypes",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 3, 18, 34, 36, 357, DateTimeKind.Local).AddTicks(1268));
        }
    }
}
