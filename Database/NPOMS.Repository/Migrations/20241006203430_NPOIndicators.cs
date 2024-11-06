using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NPOMS.Repository.Migrations
{
    /// <inheritdoc />
    public partial class NPOIndicators : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NPOIndicator",
                schema: "dropdown",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubProgrammeTypeId = table.Column<int>(type: "int", nullable: false),
                    IndicatorValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IndicatorDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OutputTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Year = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    AnnualTarget = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Q1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Q2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Q3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Q4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShortDefinition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Purpose = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KeyBeneficiaries = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SourceOfData = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataLimitations = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Assumptions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MeansOfVerification = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MethodOfCalculation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CalculationType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReportingCycle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DesiredPerformance = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeOfIndicatorServiceDelivery = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeOfIndicatorDemandDriven = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeOfIndicatorStandard = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpatialLocationOfIndicator = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IndicatorResponsibility = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpatialTransformation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisaggregationOfBeneficiaries = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PSIP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImplementationData = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NPOIndicator", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "dropdown",
                table: "NPOIndicator",
                columns: new[] { "Id", "AnnualTarget", "Assumptions", "CalculationType", "DataLimitations", "DesiredPerformance", "DisaggregationOfBeneficiaries", "ImplementationData", "IndicatorDesc", "IndicatorResponsibility", "IndicatorValue", "IsActive", "KeyBeneficiaries", "MeansOfVerification", "MethodOfCalculation", "OutputTitle", "PSIP", "Purpose", "Q1", "Q2", "Q3", "Q4", "ReportingCycle", "ShortDefinition", "SourceOfData", "SpatialLocationOfIndicator", "SpatialTransformation", "SubProgrammeTypeId", "TypeOfIndicatorDemandDriven", "TypeOfIndicatorServiceDelivery", "TypeOfIndicatorStandard", "Year" },
                values: new object[] { 1, "4661", "Social worker assessments of Older Persons for take up into the residential facilities are completed timeously.", "Non-Cumulative", "None.", "On Target", "Target for Older persons", "See approved AOP-2.2.1.1.", "Number of subsidised beds in residential care facilities for Older Persons.", "Director: Vulnerable Groups", "2.2.1.1", false, "Older Persons in accordance with the Older Persons Act (13/2006).", "BAS Reconciliation Reports.", "Count and report on the number of subsidies for bed spaces transferred to funded NPOs. Annual output is the highest achieved across the quarters.", "Residential care services/facilities are available for Older Persons.", "Wellbeing", "Residential facilities provide for the care of Older Persons.", "4661", "4661", "4661", "4661", "Quarterly", "The indicator counts the total number of subsidies transferred by the DSD to NPO residential facilities for Older Persons (i.e. 60 years and older) during the reporting period.", "HOD approved NPO funding submission(s) for the Sub-directorate: Services to Older Persons.", "Multiple Locations", "Services are provided in all six (6) DSD regions of the Province.", 1, "Yes", "NO", "NO", "2024/25" });

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 6, 22, 34, 21, 917, DateTimeKind.Local).AddTicks(9148));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 6, 22, 34, 21, 917, DateTimeKind.Local).AddTicks(9166));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 6, 22, 34, 21, 917, DateTimeKind.Local).AddTicks(9168));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 6, 22, 34, 21, 917, DateTimeKind.Local).AddTicks(9170));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 6, 22, 34, 21, 917, DateTimeKind.Local).AddTicks(9172));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 6, 22, 34, 21, 917, DateTimeKind.Local).AddTicks(9173));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 6, 22, 34, 21, 917, DateTimeKind.Local).AddTicks(9175));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 6, 22, 34, 21, 917, DateTimeKind.Local).AddTicks(9177));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 6, 22, 34, 21, 917, DateTimeKind.Local).AddTicks(9178));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 6, 22, 34, 21, 917, DateTimeKind.Local).AddTicks(9180));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 6, 22, 34, 21, 917, DateTimeKind.Local).AddTicks(9181));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 6, 22, 34, 21, 917, DateTimeKind.Local).AddTicks(9183));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 6, 22, 34, 21, 917, DateTimeKind.Local).AddTicks(9184));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 6, 22, 34, 21, 917, DateTimeKind.Local).AddTicks(9186));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 6, 22, 34, 21, 917, DateTimeKind.Local).AddTicks(9188));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 6, 22, 34, 21, 917, DateTimeKind.Local).AddTicks(9190));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 6, 22, 34, 21, 917, DateTimeKind.Local).AddTicks(9191));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 6, 22, 34, 21, 917, DateTimeKind.Local).AddTicks(9193));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 6, 22, 34, 21, 917, DateTimeKind.Local).AddTicks(9194));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 6, 22, 34, 21, 917, DateTimeKind.Local).AddTicks(9196));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 6, 22, 34, 21, 917, DateTimeKind.Local).AddTicks(9197));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 6, 22, 34, 21, 917, DateTimeKind.Local).AddTicks(9199));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 6, 22, 34, 21, 917, DateTimeKind.Local).AddTicks(9200));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 6, 22, 34, 21, 917, DateTimeKind.Local).AddTicks(9202));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 6, 22, 34, 21, 917, DateTimeKind.Local).AddTicks(9203));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 6, 22, 34, 21, 917, DateTimeKind.Local).AddTicks(9205));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 6, 22, 34, 21, 917, DateTimeKind.Local).AddTicks(9206));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 6, 22, 34, 21, 917, DateTimeKind.Local).AddTicks(9215));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 6, 22, 34, 21, 917, DateTimeKind.Local).AddTicks(9216));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 6, 22, 34, 21, 917, DateTimeKind.Local).AddTicks(9222));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 6, 22, 34, 21, 917, DateTimeKind.Local).AddTicks(9238));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 6, 22, 34, 21, 917, DateTimeKind.Local).AddTicks(9240));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 6, 22, 34, 21, 917, DateTimeKind.Local).AddTicks(9840));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 6, 22, 34, 21, 917, DateTimeKind.Local).AddTicks(9844));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 6, 22, 34, 21, 917, DateTimeKind.Local).AddTicks(9846));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 6, 22, 34, 21, 917, DateTimeKind.Local).AddTicks(9848));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 6, 22, 34, 21, 917, DateTimeKind.Local).AddTicks(9850));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 6, 22, 34, 21, 917, DateTimeKind.Local).AddTicks(9853));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 6, 22, 34, 21, 917, DateTimeKind.Local).AddTicks(9855));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NPOIndicator",
                schema: "dropdown");

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 19, 0, 3, 10, 162, DateTimeKind.Local).AddTicks(6947));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 19, 0, 3, 10, 162, DateTimeKind.Local).AddTicks(6964));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 19, 0, 3, 10, 162, DateTimeKind.Local).AddTicks(6966));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 19, 0, 3, 10, 162, DateTimeKind.Local).AddTicks(6968));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 19, 0, 3, 10, 162, DateTimeKind.Local).AddTicks(6969));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 19, 0, 3, 10, 162, DateTimeKind.Local).AddTicks(6971));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 19, 0, 3, 10, 162, DateTimeKind.Local).AddTicks(6972));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 19, 0, 3, 10, 162, DateTimeKind.Local).AddTicks(6974));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 19, 0, 3, 10, 162, DateTimeKind.Local).AddTicks(6975));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 19, 0, 3, 10, 162, DateTimeKind.Local).AddTicks(6977));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 19, 0, 3, 10, 162, DateTimeKind.Local).AddTicks(6978));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 19, 0, 3, 10, 162, DateTimeKind.Local).AddTicks(6980));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 19, 0, 3, 10, 162, DateTimeKind.Local).AddTicks(6981));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 19, 0, 3, 10, 162, DateTimeKind.Local).AddTicks(6983));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 19, 0, 3, 10, 162, DateTimeKind.Local).AddTicks(6984));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 19, 0, 3, 10, 162, DateTimeKind.Local).AddTicks(6986));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 19, 0, 3, 10, 162, DateTimeKind.Local).AddTicks(6987));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 19, 0, 3, 10, 162, DateTimeKind.Local).AddTicks(6989));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 19, 0, 3, 10, 162, DateTimeKind.Local).AddTicks(6991));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 19, 0, 3, 10, 162, DateTimeKind.Local).AddTicks(6992));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 19, 0, 3, 10, 162, DateTimeKind.Local).AddTicks(6994));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 19, 0, 3, 10, 162, DateTimeKind.Local).AddTicks(6995));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 19, 0, 3, 10, 162, DateTimeKind.Local).AddTicks(6997));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 19, 0, 3, 10, 162, DateTimeKind.Local).AddTicks(6998));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 19, 0, 3, 10, 162, DateTimeKind.Local).AddTicks(7000));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 19, 0, 3, 10, 162, DateTimeKind.Local).AddTicks(7001));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 19, 0, 3, 10, 162, DateTimeKind.Local).AddTicks(7003));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 19, 0, 3, 10, 162, DateTimeKind.Local).AddTicks(7011));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 19, 0, 3, 10, 162, DateTimeKind.Local).AddTicks(7013));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 19, 0, 3, 10, 162, DateTimeKind.Local).AddTicks(7018));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 19, 0, 3, 10, 162, DateTimeKind.Local).AddTicks(7037));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 19, 0, 3, 10, 162, DateTimeKind.Local).AddTicks(7039));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 19, 0, 3, 10, 162, DateTimeKind.Local).AddTicks(7694));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 19, 0, 3, 10, 162, DateTimeKind.Local).AddTicks(7698));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 19, 0, 3, 10, 162, DateTimeKind.Local).AddTicks(7700));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 19, 0, 3, 10, 162, DateTimeKind.Local).AddTicks(7703));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 19, 0, 3, 10, 162, DateTimeKind.Local).AddTicks(7705));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 19, 0, 3, 10, 162, DateTimeKind.Local).AddTicks(7707));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 19, 0, 3, 10, 162, DateTimeKind.Local).AddTicks(7709));
        }
    }
}
