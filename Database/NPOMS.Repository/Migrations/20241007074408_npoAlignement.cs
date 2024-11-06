using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NPOMS.Repository.Migrations
{
    /// <inheritdoc />
    public partial class npoAlignement : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Assumptions",
                schema: "dropdown",
                table: "NPOIndicator");

            migrationBuilder.DropColumn(
                name: "CalculationType",
                schema: "dropdown",
                table: "NPOIndicator");

            migrationBuilder.DropColumn(
                name: "DataLimitations",
                schema: "dropdown",
                table: "NPOIndicator");

            migrationBuilder.DropColumn(
                name: "DesiredPerformance",
                schema: "dropdown",
                table: "NPOIndicator");

            migrationBuilder.DropColumn(
                name: "DisaggregationOfBeneficiaries",
                schema: "dropdown",
                table: "NPOIndicator");

            migrationBuilder.DropColumn(
                name: "ImplementationData",
                schema: "dropdown",
                table: "NPOIndicator");

            migrationBuilder.DropColumn(
                name: "IndicatorDesc",
                schema: "dropdown",
                table: "NPOIndicator");

            migrationBuilder.DropColumn(
                name: "IndicatorResponsibility",
                schema: "dropdown",
                table: "NPOIndicator");

            migrationBuilder.DropColumn(
                name: "IndicatorValue",
                schema: "dropdown",
                table: "NPOIndicator");

            migrationBuilder.DropColumn(
                name: "KeyBeneficiaries",
                schema: "dropdown",
                table: "NPOIndicator");

            migrationBuilder.DropColumn(
                name: "MeansOfVerification",
                schema: "dropdown",
                table: "NPOIndicator");

            migrationBuilder.DropColumn(
                name: "MethodOfCalculation",
                schema: "dropdown",
                table: "NPOIndicator");

            migrationBuilder.DropColumn(
                name: "OutputTitle",
                schema: "dropdown",
                table: "NPOIndicator");

            migrationBuilder.DropColumn(
                name: "PSIP",
                schema: "dropdown",
                table: "NPOIndicator");

            migrationBuilder.DropColumn(
                name: "Purpose",
                schema: "dropdown",
                table: "NPOIndicator");

            migrationBuilder.DropColumn(
                name: "ReportingCycle",
                schema: "dropdown",
                table: "NPOIndicator");

            migrationBuilder.DropColumn(
                name: "ShortDefinition",
                schema: "dropdown",
                table: "NPOIndicator");

            migrationBuilder.DropColumn(
                name: "SourceOfData",
                schema: "dropdown",
                table: "NPOIndicator");

            migrationBuilder.DropColumn(
                name: "SpatialLocationOfIndicator",
                schema: "dropdown",
                table: "NPOIndicator");

            migrationBuilder.RenameColumn(
                name: "TypeOfIndicatorStandard",
                schema: "dropdown",
                table: "NPOIndicator",
                newName: "SubprogrammeType");

            migrationBuilder.RenameColumn(
                name: "TypeOfIndicatorServiceDelivery",
                schema: "dropdown",
                table: "NPOIndicator",
                newName: "Programme");

            migrationBuilder.RenameColumn(
                name: "TypeOfIndicatorDemandDriven",
                schema: "dropdown",
                table: "NPOIndicator",
                newName: "OrganisationName");

            migrationBuilder.RenameColumn(
                name: "SubProgrammeTypeId",
                schema: "dropdown",
                table: "NPOIndicator",
                newName: "Ccode");

            migrationBuilder.RenameColumn(
                name: "SpatialTransformation",
                schema: "dropdown",
                table: "NPOIndicator",
                newName: "IndicatorId");

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "NPOIndicator",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Ccode", "IndicatorId", "OrganisationName", "Programme", "Q1", "Q2", "Q3", "Q4", "SubprogrammeType" },
                values: new object[] { 3185, "3.3.1.1", "ACVV Cape Town", "Child care and protection services", "10", "20", "30", "40", "SERV ORGANISATION (CHILD CARE)" });

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 7, 9, 43, 59, 145, DateTimeKind.Local).AddTicks(2112));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 7, 9, 43, 59, 145, DateTimeKind.Local).AddTicks(2128));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 7, 9, 43, 59, 145, DateTimeKind.Local).AddTicks(2130));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 7, 9, 43, 59, 145, DateTimeKind.Local).AddTicks(2132));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 7, 9, 43, 59, 145, DateTimeKind.Local).AddTicks(2133));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 7, 9, 43, 59, 145, DateTimeKind.Local).AddTicks(2135));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 7, 9, 43, 59, 145, DateTimeKind.Local).AddTicks(2137));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 7, 9, 43, 59, 145, DateTimeKind.Local).AddTicks(2138));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 7, 9, 43, 59, 145, DateTimeKind.Local).AddTicks(2140));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 7, 9, 43, 59, 145, DateTimeKind.Local).AddTicks(2142));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 7, 9, 43, 59, 145, DateTimeKind.Local).AddTicks(2143));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 7, 9, 43, 59, 145, DateTimeKind.Local).AddTicks(2145));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 7, 9, 43, 59, 145, DateTimeKind.Local).AddTicks(2146));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 7, 9, 43, 59, 145, DateTimeKind.Local).AddTicks(2148));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 7, 9, 43, 59, 145, DateTimeKind.Local).AddTicks(2149));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 7, 9, 43, 59, 145, DateTimeKind.Local).AddTicks(2151));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 7, 9, 43, 59, 145, DateTimeKind.Local).AddTicks(2152));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 7, 9, 43, 59, 145, DateTimeKind.Local).AddTicks(2154));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 7, 9, 43, 59, 145, DateTimeKind.Local).AddTicks(2156));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 7, 9, 43, 59, 145, DateTimeKind.Local).AddTicks(2157));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 7, 9, 43, 59, 145, DateTimeKind.Local).AddTicks(2159));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 7, 9, 43, 59, 145, DateTimeKind.Local).AddTicks(2160));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 7, 9, 43, 59, 145, DateTimeKind.Local).AddTicks(2162));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 7, 9, 43, 59, 145, DateTimeKind.Local).AddTicks(2163));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 7, 9, 43, 59, 145, DateTimeKind.Local).AddTicks(2165));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 7, 9, 43, 59, 145, DateTimeKind.Local).AddTicks(2166));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 7, 9, 43, 59, 145, DateTimeKind.Local).AddTicks(2168));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 7, 9, 43, 59, 145, DateTimeKind.Local).AddTicks(2175));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 7, 9, 43, 59, 145, DateTimeKind.Local).AddTicks(2176));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 7, 9, 43, 59, 145, DateTimeKind.Local).AddTicks(2183));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 7, 9, 43, 59, 145, DateTimeKind.Local).AddTicks(2199));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 7, 9, 43, 59, 145, DateTimeKind.Local).AddTicks(2201));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 7, 9, 43, 59, 145, DateTimeKind.Local).AddTicks(2745));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 7, 9, 43, 59, 145, DateTimeKind.Local).AddTicks(2749));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 7, 9, 43, 59, 145, DateTimeKind.Local).AddTicks(2752));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 7, 9, 43, 59, 145, DateTimeKind.Local).AddTicks(2754));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 7, 9, 43, 59, 145, DateTimeKind.Local).AddTicks(2756));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 7, 9, 43, 59, 145, DateTimeKind.Local).AddTicks(2758));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 7, 9, 43, 59, 145, DateTimeKind.Local).AddTicks(2760));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SubprogrammeType",
                schema: "dropdown",
                table: "NPOIndicator",
                newName: "TypeOfIndicatorStandard");

            migrationBuilder.RenameColumn(
                name: "Programme",
                schema: "dropdown",
                table: "NPOIndicator",
                newName: "TypeOfIndicatorServiceDelivery");

            migrationBuilder.RenameColumn(
                name: "OrganisationName",
                schema: "dropdown",
                table: "NPOIndicator",
                newName: "TypeOfIndicatorDemandDriven");

            migrationBuilder.RenameColumn(
                name: "IndicatorId",
                schema: "dropdown",
                table: "NPOIndicator",
                newName: "SpatialTransformation");

            migrationBuilder.RenameColumn(
                name: "Ccode",
                schema: "dropdown",
                table: "NPOIndicator",
                newName: "SubProgrammeTypeId");

            migrationBuilder.AddColumn<string>(
                name: "Assumptions",
                schema: "dropdown",
                table: "NPOIndicator",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CalculationType",
                schema: "dropdown",
                table: "NPOIndicator",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DataLimitations",
                schema: "dropdown",
                table: "NPOIndicator",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DesiredPerformance",
                schema: "dropdown",
                table: "NPOIndicator",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DisaggregationOfBeneficiaries",
                schema: "dropdown",
                table: "NPOIndicator",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImplementationData",
                schema: "dropdown",
                table: "NPOIndicator",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IndicatorDesc",
                schema: "dropdown",
                table: "NPOIndicator",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IndicatorResponsibility",
                schema: "dropdown",
                table: "NPOIndicator",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IndicatorValue",
                schema: "dropdown",
                table: "NPOIndicator",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KeyBeneficiaries",
                schema: "dropdown",
                table: "NPOIndicator",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MeansOfVerification",
                schema: "dropdown",
                table: "NPOIndicator",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MethodOfCalculation",
                schema: "dropdown",
                table: "NPOIndicator",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OutputTitle",
                schema: "dropdown",
                table: "NPOIndicator",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PSIP",
                schema: "dropdown",
                table: "NPOIndicator",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Purpose",
                schema: "dropdown",
                table: "NPOIndicator",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReportingCycle",
                schema: "dropdown",
                table: "NPOIndicator",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShortDefinition",
                schema: "dropdown",
                table: "NPOIndicator",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SourceOfData",
                schema: "dropdown",
                table: "NPOIndicator",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SpatialLocationOfIndicator",
                schema: "dropdown",
                table: "NPOIndicator",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "NPOIndicator",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Assumptions", "CalculationType", "DataLimitations", "DesiredPerformance", "DisaggregationOfBeneficiaries", "ImplementationData", "IndicatorDesc", "IndicatorResponsibility", "IndicatorValue", "KeyBeneficiaries", "MeansOfVerification", "MethodOfCalculation", "OutputTitle", "PSIP", "Purpose", "Q1", "Q2", "Q3", "Q4", "ReportingCycle", "ShortDefinition", "SourceOfData", "SpatialLocationOfIndicator", "SpatialTransformation", "SubProgrammeTypeId", "TypeOfIndicatorDemandDriven", "TypeOfIndicatorServiceDelivery", "TypeOfIndicatorStandard" },
                values: new object[] { "Social worker assessments of Older Persons for take up into the residential facilities are completed timeously.", "Non-Cumulative", "None.", "On Target", "Target for Older persons", "See approved AOP-2.2.1.1.", "Number of subsidised beds in residential care facilities for Older Persons.", "Director: Vulnerable Groups", "2.2.1.1", "Older Persons in accordance with the Older Persons Act (13/2006).", "BAS Reconciliation Reports.", "Count and report on the number of subsidies for bed spaces transferred to funded NPOs. Annual output is the highest achieved across the quarters.", "Residential care services/facilities are available for Older Persons.", "Wellbeing", "Residential facilities provide for the care of Older Persons.", "4661", "4661", "4661", "4661", "Quarterly", "The indicator counts the total number of subsidies transferred by the DSD to NPO residential facilities for Older Persons (i.e. 60 years and older) during the reporting period.", "HOD approved NPO funding submission(s) for the Sub-directorate: Services to Older Persons.", "Multiple Locations", "Services are provided in all six (6) DSD regions of the Province.", 1, "Yes", "NO", "NO" });

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
    }
}
