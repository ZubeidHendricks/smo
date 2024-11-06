using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NPOMS.Repository.Migrations
{
    /// <inheritdoc />
    public partial class OutputTitleactive : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IndicatorReportId",
                schema: "dbo",
                table: "ContactInformation",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "IndicatorReports",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Programme = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubProgramme = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubProgrammeType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Group = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServiceDeliveryArea = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    FinancialYear = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OutputTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Targets = table.Column<int>(type: "int", nullable: false),
                    IndicatorId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Actuals = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Variance = table.Column<int>(type: "int", nullable: false),
                    DeviationReason = table.Column<int>(type: "int", nullable: false),
                    AdjustedActual = table.Column<int>(type: "int", nullable: true),
                    AdjustedVariance = table.Column<int>(type: "int", nullable: true),
                    ApplicationId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QaurterId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedUserId = table.Column<int>(type: "int", nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ApprovalStatusId = table.Column<int>(type: "int", nullable: false),
                    ApprovalUserId = table.Column<int>(type: "int", nullable: true),
                    ApprovalDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OrganisationTypeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndicatorReports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IndicatorReports_AccessStatuses_ApprovalStatusId",
                        column: x => x.ApprovalStatusId,
                        principalSchema: "dbo",
                        principalTable: "AccessStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IndicatorReports_OrganisationTypes_OrganisationTypeId",
                        column: x => x.OrganisationTypeId,
                        principalSchema: "dropdown",
                        principalTable: "OrganisationTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_IndicatorReports_Users_ApprovalUserId",
                        column: x => x.ApprovalUserId,
                        principalSchema: "core",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_IndicatorReports_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalSchema: "core",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "Indicator",
                keyColumn: "Id",
                keyValue: 1,
                column: "OutputTitle",
                value: "Residential care services/facilities are available for Older Persons.");

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
                name: "IX_ContactInformation_IndicatorReportId",
                schema: "dbo",
                table: "ContactInformation",
                column: "IndicatorReportId");

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
                name: "IX_IndicatorReports_CreatedUserId",
                schema: "dbo",
                table: "IndicatorReports",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_IndicatorReports_OrganisationTypeId",
                schema: "dbo",
                table: "IndicatorReports",
                column: "OrganisationTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ContactInformation_IndicatorReports_IndicatorReportId",
                schema: "dbo",
                table: "ContactInformation",
                column: "IndicatorReportId",
                principalSchema: "dbo",
                principalTable: "IndicatorReports",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContactInformation_IndicatorReports_IndicatorReportId",
                schema: "dbo",
                table: "ContactInformation");

            migrationBuilder.DropTable(
                name: "IndicatorReports",
                schema: "dbo");

            migrationBuilder.DropIndex(
                name: "IX_ContactInformation_IndicatorReportId",
                schema: "dbo",
                table: "ContactInformation");

            migrationBuilder.DropColumn(
                name: "IndicatorReportId",
                schema: "dbo",
                table: "ContactInformation");

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "Indicator",
                keyColumn: "Id",
                keyValue: 1,
                column: "OutputTitle",
                value: "OutputTitle");

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 25, 11, 22, 37, 478, DateTimeKind.Local).AddTicks(1741));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 25, 11, 22, 37, 478, DateTimeKind.Local).AddTicks(1756));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 25, 11, 22, 37, 478, DateTimeKind.Local).AddTicks(1758));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 25, 11, 22, 37, 478, DateTimeKind.Local).AddTicks(1759));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 25, 11, 22, 37, 478, DateTimeKind.Local).AddTicks(1761));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 25, 11, 22, 37, 478, DateTimeKind.Local).AddTicks(1762));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 25, 11, 22, 37, 478, DateTimeKind.Local).AddTicks(1764));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 25, 11, 22, 37, 478, DateTimeKind.Local).AddTicks(1765));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 25, 11, 22, 37, 478, DateTimeKind.Local).AddTicks(1767));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 25, 11, 22, 37, 478, DateTimeKind.Local).AddTicks(1768));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 25, 11, 22, 37, 478, DateTimeKind.Local).AddTicks(1770));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 25, 11, 22, 37, 478, DateTimeKind.Local).AddTicks(1771));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 25, 11, 22, 37, 478, DateTimeKind.Local).AddTicks(1773));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 25, 11, 22, 37, 478, DateTimeKind.Local).AddTicks(1775));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 25, 11, 22, 37, 478, DateTimeKind.Local).AddTicks(1776));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 25, 11, 22, 37, 478, DateTimeKind.Local).AddTicks(1778));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 25, 11, 22, 37, 478, DateTimeKind.Local).AddTicks(1779));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 25, 11, 22, 37, 478, DateTimeKind.Local).AddTicks(1781));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 25, 11, 22, 37, 478, DateTimeKind.Local).AddTicks(1782));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 25, 11, 22, 37, 478, DateTimeKind.Local).AddTicks(1784));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 25, 11, 22, 37, 478, DateTimeKind.Local).AddTicks(1785));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 25, 11, 22, 37, 478, DateTimeKind.Local).AddTicks(1787));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 25, 11, 22, 37, 478, DateTimeKind.Local).AddTicks(1788));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 25, 11, 22, 37, 478, DateTimeKind.Local).AddTicks(1790));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 25, 11, 22, 37, 478, DateTimeKind.Local).AddTicks(1792));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 25, 11, 22, 37, 478, DateTimeKind.Local).AddTicks(1793));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 25, 11, 22, 37, 478, DateTimeKind.Local).AddTicks(1795));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 25, 11, 22, 37, 478, DateTimeKind.Local).AddTicks(1804));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 25, 11, 22, 37, 478, DateTimeKind.Local).AddTicks(1805));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 25, 11, 22, 37, 478, DateTimeKind.Local).AddTicks(1810));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 25, 11, 22, 37, 478, DateTimeKind.Local).AddTicks(1826));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 25, 11, 22, 37, 478, DateTimeKind.Local).AddTicks(1828));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 25, 11, 22, 37, 478, DateTimeKind.Local).AddTicks(2453));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 25, 11, 22, 37, 478, DateTimeKind.Local).AddTicks(2457));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 25, 11, 22, 37, 478, DateTimeKind.Local).AddTicks(2459));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 25, 11, 22, 37, 478, DateTimeKind.Local).AddTicks(2461));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 25, 11, 22, 37, 478, DateTimeKind.Local).AddTicks(2464));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 25, 11, 22, 37, 478, DateTimeKind.Local).AddTicks(2466));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 25, 11, 22, 37, 478, DateTimeKind.Local).AddTicks(2468));
        }
    }
}
