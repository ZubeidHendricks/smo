using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NPOMS.Repository.Migrations
{
    /// <inheritdoc />
    public partial class Indicator : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AddColumn<int>(
            //    name: "LinkId",
            //    schema: "dropdown",
            //    table: "SubDistrictDemographics",
            //    type: "int",
            //    nullable: false,
                //defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Indicator",
                schema: "dropdown",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubProgrammeTypeId = table.Column<int>(type: "int", nullable: false),
                    IndicatorValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_Indicator", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "dropdown",
                table: "Indicator",
                columns: new[] { "Id", "AnnualTarget", "Assumptions", "CalculationType", "DataLimitations", "DesiredPerformance", "DisaggregationOfBeneficiaries", "ImplementationData", "IndicatorResponsibility", "IndicatorValue", "KeyBeneficiaries", "MeansOfVerification", "MethodOfCalculation", "PSIP", "Purpose", "Q1", "Q2", "Q3", "Q4", "ReportingCycle", "ShortDefinition", "SourceOfData", "SpatialLocationOfIndicator", "SpatialTransformation", "SubProgrammeTypeId", "TypeOfIndicatorDemandDriven", "TypeOfIndicatorServiceDelivery", "TypeOfIndicatorStandard" },
                values: new object[] { 1, "4661", "Social worker assessments of Older Persons for take up into the residential facilities are completed timeously.", "Non-Cumulative", "None.", "On Target", "Target for Older persons", "See approved AOP-2.2.1.1.", "Director: Vulnerable Groups", "2.2.1.1", "Older Persons in accordance with the Older Persons Act (13/2006).", "BAS Reconciliation Reports.", "Count and report on the number of subsidies for bed spaces transferred to funded NPOs. Annual output is the highest achieved across the quarters.", "Wellbeing", "Residential facilities provide for the care of Older Persons.", "4661", "4661", "4661", "4661", "Quarterly", "The indicator counts the total number of subsidies transferred by the DSD to NPO residential facilities for Older Persons (i.e. 60 years and older) during the reporting period.", "HOD approved NPO funding submission(s) for the Sub-directorate: Services to Older Persons.", "Multiple Locations", "Services are provided in all six (6) DSD regions of the Province.", 1, "Yes", "NO", "NO" });

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 15, 23, 18, 38, 642, DateTimeKind.Local).AddTicks(1434));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 15, 23, 18, 38, 642, DateTimeKind.Local).AddTicks(1449));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 15, 23, 18, 38, 642, DateTimeKind.Local).AddTicks(1451));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 15, 23, 18, 38, 642, DateTimeKind.Local).AddTicks(1453));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 15, 23, 18, 38, 642, DateTimeKind.Local).AddTicks(1455));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 15, 23, 18, 38, 642, DateTimeKind.Local).AddTicks(1456));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 15, 23, 18, 38, 642, DateTimeKind.Local).AddTicks(1458));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 15, 23, 18, 38, 642, DateTimeKind.Local).AddTicks(1460));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 15, 23, 18, 38, 642, DateTimeKind.Local).AddTicks(1462));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 15, 23, 18, 38, 642, DateTimeKind.Local).AddTicks(1463));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 15, 23, 18, 38, 642, DateTimeKind.Local).AddTicks(1465));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 15, 23, 18, 38, 642, DateTimeKind.Local).AddTicks(1467));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 15, 23, 18, 38, 642, DateTimeKind.Local).AddTicks(1468));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 15, 23, 18, 38, 642, DateTimeKind.Local).AddTicks(1470));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 15, 23, 18, 38, 642, DateTimeKind.Local).AddTicks(1471));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 15, 23, 18, 38, 642, DateTimeKind.Local).AddTicks(1473));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 15, 23, 18, 38, 642, DateTimeKind.Local).AddTicks(1475));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 15, 23, 18, 38, 642, DateTimeKind.Local).AddTicks(1476));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 15, 23, 18, 38, 642, DateTimeKind.Local).AddTicks(1478));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 15, 23, 18, 38, 642, DateTimeKind.Local).AddTicks(1479));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 15, 23, 18, 38, 642, DateTimeKind.Local).AddTicks(1481));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 15, 23, 18, 38, 642, DateTimeKind.Local).AddTicks(1483));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 15, 23, 18, 38, 642, DateTimeKind.Local).AddTicks(1484));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 15, 23, 18, 38, 642, DateTimeKind.Local).AddTicks(1486));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 15, 23, 18, 38, 642, DateTimeKind.Local).AddTicks(1487));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 15, 23, 18, 38, 642, DateTimeKind.Local).AddTicks(1489));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 15, 23, 18, 38, 642, DateTimeKind.Local).AddTicks(1491));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 15, 23, 18, 38, 642, DateTimeKind.Local).AddTicks(1492));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 15, 23, 18, 38, 642, DateTimeKind.Local).AddTicks(1494));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 15, 23, 18, 38, 642, DateTimeKind.Local).AddTicks(1503));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 15, 23, 18, 38, 642, DateTimeKind.Local).AddTicks(1516));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 15, 23, 18, 38, 642, DateTimeKind.Local).AddTicks(1518));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 15, 23, 18, 38, 642, DateTimeKind.Local).AddTicks(2111));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 15, 23, 18, 38, 642, DateTimeKind.Local).AddTicks(2115));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 15, 23, 18, 38, 642, DateTimeKind.Local).AddTicks(2118));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 15, 23, 18, 38, 642, DateTimeKind.Local).AddTicks(2120));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 15, 23, 18, 38, 642, DateTimeKind.Local).AddTicks(2122));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 15, 23, 18, 38, 642, DateTimeKind.Local).AddTicks(2124));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 15, 23, 18, 38, 642, DateTimeKind.Local).AddTicks(2126));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubDistrictDemographics",
                keyColumn: "Id",
                keyValue: 1,
                column: "LinkId",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubDistrictDemographics",
                keyColumn: "Id",
                keyValue: 2,
                column: "LinkId",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubDistrictDemographics",
                keyColumn: "Id",
                keyValue: 3,
                column: "LinkId",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubDistrictDemographics",
                keyColumn: "Id",
                keyValue: 4,
                column: "LinkId",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubDistrictDemographics",
                keyColumn: "Id",
                keyValue: 5,
                column: "LinkId",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubDistrictDemographics",
                keyColumn: "Id",
                keyValue: 6,
                column: "LinkId",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubDistrictDemographics",
                keyColumn: "Id",
                keyValue: 7,
                column: "LinkId",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubDistrictDemographics",
                keyColumn: "Id",
                keyValue: 8,
                column: "LinkId",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubDistrictDemographics",
                keyColumn: "Id",
                keyValue: 9,
                column: "LinkId",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubDistrictDemographics",
                keyColumn: "Id",
                keyValue: 10,
                column: "LinkId",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubDistrictDemographics",
                keyColumn: "Id",
                keyValue: 11,
                column: "LinkId",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubDistrictDemographics",
                keyColumn: "Id",
                keyValue: 12,
                column: "LinkId",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubDistrictDemographics",
                keyColumn: "Id",
                keyValue: 13,
                column: "LinkId",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubDistrictDemographics",
                keyColumn: "Id",
                keyValue: 14,
                column: "LinkId",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubDistrictDemographics",
                keyColumn: "Id",
                keyValue: 15,
                column: "LinkId",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubDistrictDemographics",
                keyColumn: "Id",
                keyValue: 16,
                column: "LinkId",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubDistrictDemographics",
                keyColumn: "Id",
                keyValue: 17,
                column: "LinkId",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubDistrictDemographics",
                keyColumn: "Id",
                keyValue: 18,
                column: "LinkId",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubDistrictDemographics",
                keyColumn: "Id",
                keyValue: 19,
                column: "LinkId",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubDistrictDemographics",
                keyColumn: "Id",
                keyValue: 20,
                column: "LinkId",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubDistrictDemographics",
                keyColumn: "Id",
                keyValue: 21,
                column: "LinkId",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubDistrictDemographics",
                keyColumn: "Id",
                keyValue: 22,
                column: "LinkId",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubDistrictDemographics",
                keyColumn: "Id",
                keyValue: 23,
                column: "LinkId",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubDistrictDemographics",
                keyColumn: "Id",
                keyValue: 24,
                column: "LinkId",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubDistrictDemographics",
                keyColumn: "Id",
                keyValue: 25,
                column: "LinkId",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubDistrictDemographics",
                keyColumn: "Id",
                keyValue: 27,
                column: "LinkId",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubDistrictDemographics",
                keyColumn: "Id",
                keyValue: 28,
                column: "LinkId",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubDistrictDemographics",
                keyColumn: "Id",
                keyValue: 29,
                column: "LinkId",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubDistrictDemographics",
                keyColumn: "Id",
                keyValue: 30,
                column: "LinkId",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubDistrictDemographics",
                keyColumn: "Id",
                keyValue: 31,
                column: "LinkId",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubDistrictDemographics",
                keyColumn: "Id",
                keyValue: 32,
                column: "LinkId",
                value: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Indicator",
                schema: "dropdown");

            migrationBuilder.DropColumn(
                name: "LinkId",
                schema: "dropdown",
                table: "SubDistrictDemographics");

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 3, 14, 47, 49, 82, DateTimeKind.Local).AddTicks(8150));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 3, 14, 47, 49, 82, DateTimeKind.Local).AddTicks(8173));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 3, 14, 47, 49, 82, DateTimeKind.Local).AddTicks(8175));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 3, 14, 47, 49, 82, DateTimeKind.Local).AddTicks(8177));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 3, 14, 47, 49, 82, DateTimeKind.Local).AddTicks(8178));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 3, 14, 47, 49, 82, DateTimeKind.Local).AddTicks(8180));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 3, 14, 47, 49, 82, DateTimeKind.Local).AddTicks(8182));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 3, 14, 47, 49, 82, DateTimeKind.Local).AddTicks(8184));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 3, 14, 47, 49, 82, DateTimeKind.Local).AddTicks(8185));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 3, 14, 47, 49, 82, DateTimeKind.Local).AddTicks(8187));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 3, 14, 47, 49, 82, DateTimeKind.Local).AddTicks(8189));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 3, 14, 47, 49, 82, DateTimeKind.Local).AddTicks(8191));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 3, 14, 47, 49, 82, DateTimeKind.Local).AddTicks(8193));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 3, 14, 47, 49, 82, DateTimeKind.Local).AddTicks(8195));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 3, 14, 47, 49, 82, DateTimeKind.Local).AddTicks(8196));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 3, 14, 47, 49, 82, DateTimeKind.Local).AddTicks(8198));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 3, 14, 47, 49, 82, DateTimeKind.Local).AddTicks(8201));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 3, 14, 47, 49, 82, DateTimeKind.Local).AddTicks(8203));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 3, 14, 47, 49, 82, DateTimeKind.Local).AddTicks(8205));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 3, 14, 47, 49, 82, DateTimeKind.Local).AddTicks(8207));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 3, 14, 47, 49, 82, DateTimeKind.Local).AddTicks(8208));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 3, 14, 47, 49, 82, DateTimeKind.Local).AddTicks(8210));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 3, 14, 47, 49, 82, DateTimeKind.Local).AddTicks(8212));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 3, 14, 47, 49, 82, DateTimeKind.Local).AddTicks(8215));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 3, 14, 47, 49, 82, DateTimeKind.Local).AddTicks(8216));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 3, 14, 47, 49, 82, DateTimeKind.Local).AddTicks(8218));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 3, 14, 47, 49, 82, DateTimeKind.Local).AddTicks(8220));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 3, 14, 47, 49, 82, DateTimeKind.Local).AddTicks(8231));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 3, 14, 47, 49, 82, DateTimeKind.Local).AddTicks(8233));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 3, 14, 47, 49, 82, DateTimeKind.Local).AddTicks(8240));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 3, 14, 47, 49, 82, DateTimeKind.Local).AddTicks(8263));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 3, 14, 47, 49, 82, DateTimeKind.Local).AddTicks(8265));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 3, 14, 47, 49, 82, DateTimeKind.Local).AddTicks(9132));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 3, 14, 47, 49, 82, DateTimeKind.Local).AddTicks(9141));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 3, 14, 47, 49, 82, DateTimeKind.Local).AddTicks(9144));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 3, 14, 47, 49, 82, DateTimeKind.Local).AddTicks(9146));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 3, 14, 47, 49, 82, DateTimeKind.Local).AddTicks(9149));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 3, 14, 47, 49, 82, DateTimeKind.Local).AddTicks(9151));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 3, 14, 47, 49, 82, DateTimeKind.Local).AddTicks(9154));
        }
    }
}
