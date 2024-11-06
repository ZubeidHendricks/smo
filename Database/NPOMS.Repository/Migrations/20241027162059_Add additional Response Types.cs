using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NPOMS.Repository.Migrations
{
    /// <inheritdoc />
    public partial class AddadditionalResponseTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseTypes",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedDateTime", "Description" },
                values: new object[] { new DateTime(2024, 10, 27, 18, 20, 49, 734, DateTimeKind.Local).AddTicks(3475), "Assessment Funding - Approved, Approved with Conditions, Not Approved" });

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseTypes",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedDateTime", "Description" },
                values: new object[] { new DateTime(2024, 10, 27, 18, 20, 49, 734, DateTimeKind.Local).AddTicks(3482), "Assessment Funding - Approved, Not Approved" });

            migrationBuilder.InsertData(
                schema: "eval",
                table: "ResponseTypes",
                columns: new[] { "Id", "CreatedDateTime", "CreatedUserId", "Description", "IsActive", "Name", "UpdatedDateTime", "UpdatedUserId" },
                values: new object[,]
                {
                    { 12, new DateTime(2024, 10, 27, 18, 20, 49, 734, DateTimeKind.Local).AddTicks(3483), 1, "Assessment Funding - LegislativeCompliance", true, "Q1 - LegislativeCompliance", null, null },
                    { 13, new DateTime(2024, 10, 27, 18, 20, 49, 734, DateTimeKind.Local).AddTicks(3487), 1, "Assessment Funding - PFMACompliance", true, "Q2 - LegislativeCompliance", null, null },
                    { 14, new DateTime(2024, 10, 27, 18, 20, 49, 734, DateTimeKind.Local).AddTicks(3488), 1, "Assessment Funding - PFMACompliance", true, "Q1 - PFMACompliance", null, null },
                    { 15, new DateTime(2024, 10, 27, 18, 20, 49, 734, DateTimeKind.Local).AddTicks(3490), 1, "Assessment Funding - AnalysisPerformance", true, "Q1 - AnalysisPerformance", null, null },
                    { 16, new DateTime(2024, 10, 27, 18, 20, 49, 734, DateTimeKind.Local).AddTicks(3491), 1, "Assessment Funding - AnalysisPerformance", true, "Q2 - AnalysisPerformance", null, null },
                    { 17, new DateTime(2024, 10, 27, 18, 20, 49, 734, DateTimeKind.Local).AddTicks(3492), 1, "Assessment Funding - AnalysisPerformance", true, "Q3 - AnalysisPerformance", null, null },
                    { 18, new DateTime(2024, 10, 27, 18, 20, 49, 734, DateTimeKind.Local).AddTicks(3494), 1, "Assessment Funding - Default", true, "Default", null, null }
                });

            migrationBuilder.InsertData(
                schema: "eval",
                table: "ResponseOptions",
                columns: new[] { "Id", "CreatedDateTime", "CreatedUserId", "IsActive", "Name", "ResponseTypeId", "SystemName", "UpdatedDateTime", "UpdatedUserId" },
                values: new object[,]
                {
                    { 55, new DateTime(2024, 10, 27, 18, 20, 49, 734, DateTimeKind.Local).AddTicks(663), 1, true, "Voluntary Association (VA)", 12, "Option", null, null },
                    { 56, new DateTime(2024, 10, 27, 18, 20, 49, 734, DateTimeKind.Local).AddTicks(664), 1, true, "Non-Profit Company (NPC)", 12, "Option", null, null },
                    { 57, new DateTime(2024, 10, 27, 18, 20, 49, 734, DateTimeKind.Local).AddTicks(666), 1, true, "Trust", 12, "Option", null, null },
                    { 58, new DateTime(2024, 10, 27, 18, 20, 49, 734, DateTimeKind.Local).AddTicks(667), 1, true, "Non-Profit Organisation (NPO)", 12, "Option", null, null },
                    { 59, new DateTime(2024, 10, 27, 18, 20, 49, 734, DateTimeKind.Local).AddTicks(668), 1, true, "Public Benefit Organisation (PBO and 18A)", 12, "Option", null, null },
                    { 60, new DateTime(2024, 10, 27, 18, 20, 49, 734, DateTimeKind.Local).AddTicks(673), 1, true, "1 - Not Registered", 12, "Rating", null, null },
                    { 61, new DateTime(2024, 10, 27, 18, 20, 49, 734, DateTimeKind.Local).AddTicks(674), 1, true, "2 - Registration in process ? acceptable proof/evidence provided", 12, "Rating", null, null },
                    { 62, new DateTime(2024, 10, 27, 18, 20, 49, 734, DateTimeKind.Local).AddTicks(675), 1, true, "3 - Fully Registered", 12, "Rating", null, null },
                    { 63, new DateTime(2024, 10, 27, 18, 20, 49, 734, DateTimeKind.Local).AddTicks(677), 1, true, "Older Persons Act, No 13 of 2006", 13, "Option", null, null },
                    { 64, new DateTime(2024, 10, 27, 18, 20, 49, 734, DateTimeKind.Local).AddTicks(678), 1, true, "Children?s Act, No 38 of 2005", 13, "Option", null, null },
                    { 65, new DateTime(2024, 10, 27, 18, 20, 49, 734, DateTimeKind.Local).AddTicks(679), 1, true, "Prevention and Treatment for Substance Abuse Act, No 70 of 2008", 13, "Option", null, null },
                    { 66, new DateTime(2024, 10, 27, 18, 20, 49, 734, DateTimeKind.Local).AddTicks(681), 1, true, "Other", 13, "Option", null, null },
                    { 67, new DateTime(2024, 10, 27, 18, 20, 49, 734, DateTimeKind.Local).AddTicks(682), 1, true, "0 - Not Applicable", 13, "Rating", null, null },
                    { 68, new DateTime(2024, 10, 27, 18, 20, 49, 734, DateTimeKind.Local).AddTicks(683), 1, true, "1 - Not Registered", 13, "Rating", null, null },
                    { 69, new DateTime(2024, 10, 27, 18, 20, 49, 734, DateTimeKind.Local).AddTicks(684), 1, true, "2 - Registration in Progress", 13, "Rating", null, null },
                    { 70, new DateTime(2024, 10, 27, 18, 20, 49, 734, DateTimeKind.Local).AddTicks(686), 1, true, "3 - Fully Registered", 13, "Rating", null, null },
                    { 71, new DateTime(2024, 10, 27, 18, 20, 49, 734, DateTimeKind.Local).AddTicks(687), 1, true, "Annual Financial Statement", 14, "Option", null, null },
                    { 72, new DateTime(2024, 10, 27, 18, 20, 49, 734, DateTimeKind.Local).AddTicks(689), 1, true, "Certified Financial Statement", 14, "Option", null, null },
                    { 73, new DateTime(2024, 10, 27, 18, 20, 49, 734, DateTimeKind.Local).AddTicks(690), 1, true, "Independent Review", 14, "Option", null, null },
                    { 74, new DateTime(2024, 10, 27, 18, 20, 49, 734, DateTimeKind.Local).AddTicks(691), 1, true, "0 - Not Submitted", 14, "Rating", null, null },
                    { 75, new DateTime(2024, 10, 27, 18, 20, 49, 734, DateTimeKind.Local).AddTicks(692), 1, true, "1 - Extension Granted", 14, "Rating", null, null },
                    { 76, new DateTime(2024, 10, 27, 18, 20, 49, 734, DateTimeKind.Local).AddTicks(694), 1, true, "2 - Submitted", 14, "Rating", null, null },
                    { 77, new DateTime(2024, 10, 27, 18, 20, 49, 734, DateTimeKind.Local).AddTicks(695), 1, true, "Full M&E report as per 3 - year cycle", 15, "Option", null, null },
                    { 78, new DateTime(2024, 10, 27, 18, 20, 49, 734, DateTimeKind.Local).AddTicks(697), 1, true, "Comprehensive monitoring report including Quality Assurance", 15, "Option", null, null },
                    { 79, new DateTime(2024, 10, 27, 18, 20, 49, 734, DateTimeKind.Local).AddTicks(698), 1, true, "Desktop monitoring Assessment     including self-assessment", 15, "Option", null, null },
                    { 80, new DateTime(2024, 10, 27, 18, 20, 49, 734, DateTimeKind.Local).AddTicks(700), 1, true, "Full M&E report with a SDIP and progress report", 15, "Option", null, null },
                    { 81, new DateTime(2024, 10, 27, 18, 20, 49, 734, DateTimeKind.Local).AddTicks(701), 1, true, "Report resulting  from allegations of  fraud and/or  corruption", 15, "Option", null, null },
                    { 82, new DateTime(2024, 10, 27, 18, 20, 49, 734, DateTimeKind.Local).AddTicks(702), 1, true, "1 - No or minimal  performance.  Assess risk to  partnership.", 15, "Rating", null, null },
                    { 83, new DateTime(2024, 10, 27, 18, 20, 49, 734, DateTimeKind.Local).AddTicks(704), 1, true, "2 - Below  competent  performance.  Assess risk to  partnership.", 15, "Rating", null, null },
                    { 84, new DateTime(2024, 10, 27, 18, 20, 49, 734, DateTimeKind.Local).AddTicks(705), 1, true, "3 - Competent  performance as  per the Business  Plan submitted.", 15, "Rating", null, null },
                    { 85, new DateTime(2024, 10, 27, 18, 20, 49, 734, DateTimeKind.Local).AddTicks(706), 1, true, "4 - Good  performance.  Commend partner  for performance.", 15, "Rating", null, null },
                    { 86, new DateTime(2024, 10, 27, 18, 20, 49, 734, DateTimeKind.Local).AddTicks(708), 1, true, "5 - Excellent  performance.  Consider for best  practice standard", 15, "Rating", null, null },
                    { 87, new DateTime(2024, 10, 27, 18, 20, 49, 734, DateTimeKind.Local).AddTicks(712), 1, true, "Q1", 16, "Option", null, null },
                    { 88, new DateTime(2024, 10, 27, 18, 20, 49, 734, DateTimeKind.Local).AddTicks(713), 1, true, "Q2", 16, "Option", null, null },
                    { 89, new DateTime(2024, 10, 27, 18, 20, 49, 734, DateTimeKind.Local).AddTicks(715), 1, true, "Q3", 16, "Option", null, null },
                    { 90, new DateTime(2024, 10, 27, 18, 20, 49, 734, DateTimeKind.Local).AddTicks(716), 1, true, "Q4", 16, "Option", null, null },
                    { 91, new DateTime(2024, 10, 27, 18, 20, 49, 734, DateTimeKind.Local).AddTicks(717), 1, true, "5 - Yes", 16, "Rating", null, null },
                    { 92, new DateTime(2024, 10, 27, 18, 20, 49, 734, DateTimeKind.Local).AddTicks(718), 1, true, "1 - No", 16, "Rating", null, null },
                    { 93, new DateTime(2024, 10, 27, 18, 20, 49, 734, DateTimeKind.Local).AddTicks(720), 1, true, "Q1", 17, "Option", null, null },
                    { 94, new DateTime(2024, 10, 27, 18, 20, 49, 734, DateTimeKind.Local).AddTicks(722), 1, true, "Q2", 17, "Option", null, null },
                    { 95, new DateTime(2024, 10, 27, 18, 20, 49, 734, DateTimeKind.Local).AddTicks(723), 1, true, "Q3", 17, "Option", null, null },
                    { 96, new DateTime(2024, 10, 27, 18, 20, 49, 734, DateTimeKind.Local).AddTicks(725), 1, true, "Q4", 17, "Option", null, null },
                    { 97, new DateTime(2024, 10, 27, 18, 20, 49, 734, DateTimeKind.Local).AddTicks(726), 1, true, "5 - Yes", 17, "Rating", null, null },
                    { 98, new DateTime(2024, 10, 27, 18, 20, 49, 734, DateTimeKind.Local).AddTicks(727), 1, true, "1 - No", 17, "Rating", null, null },
                    { 99, new DateTime(2024, 10, 27, 18, 20, 49, 734, DateTimeKind.Local).AddTicks(728), 1, true, "None", 18, "None", null, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "eval",
                table: "ResponseOptions",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                schema: "eval",
                table: "ResponseOptions",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                schema: "eval",
                table: "ResponseOptions",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                schema: "eval",
                table: "ResponseOptions",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                schema: "eval",
                table: "ResponseOptions",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                schema: "eval",
                table: "ResponseOptions",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                schema: "eval",
                table: "ResponseOptions",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                schema: "eval",
                table: "ResponseOptions",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                schema: "eval",
                table: "ResponseOptions",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                schema: "eval",
                table: "ResponseOptions",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                schema: "eval",
                table: "ResponseOptions",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                schema: "eval",
                table: "ResponseOptions",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                schema: "eval",
                table: "ResponseOptions",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                schema: "eval",
                table: "ResponseOptions",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                schema: "eval",
                table: "ResponseOptions",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                schema: "eval",
                table: "ResponseOptions",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                schema: "eval",
                table: "ResponseOptions",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                schema: "eval",
                table: "ResponseOptions",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                schema: "eval",
                table: "ResponseOptions",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                schema: "eval",
                table: "ResponseOptions",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                schema: "eval",
                table: "ResponseOptions",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                schema: "eval",
                table: "ResponseOptions",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                schema: "eval",
                table: "ResponseOptions",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                schema: "eval",
                table: "ResponseOptions",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                schema: "eval",
                table: "ResponseOptions",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                schema: "eval",
                table: "ResponseOptions",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                schema: "eval",
                table: "ResponseOptions",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                schema: "eval",
                table: "ResponseOptions",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                schema: "eval",
                table: "ResponseOptions",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                schema: "eval",
                table: "ResponseOptions",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                schema: "eval",
                table: "ResponseOptions",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                schema: "eval",
                table: "ResponseOptions",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                schema: "eval",
                table: "ResponseOptions",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                schema: "eval",
                table: "ResponseOptions",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                schema: "eval",
                table: "ResponseOptions",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                schema: "eval",
                table: "ResponseOptions",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                schema: "eval",
                table: "ResponseOptions",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                schema: "eval",
                table: "ResponseOptions",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                schema: "eval",
                table: "ResponseOptions",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                schema: "eval",
                table: "ResponseOptions",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                schema: "eval",
                table: "ResponseOptions",
                keyColumn: "Id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                schema: "eval",
                table: "ResponseOptions",
                keyColumn: "Id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                schema: "eval",
                table: "ResponseOptions",
                keyColumn: "Id",
                keyValue: 97);

            migrationBuilder.DeleteData(
                schema: "eval",
                table: "ResponseOptions",
                keyColumn: "Id",
                keyValue: 98);

            migrationBuilder.DeleteData(
                schema: "eval",
                table: "ResponseOptions",
                keyColumn: "Id",
                keyValue: 99);

            migrationBuilder.DeleteData(
                schema: "eval",
                table: "ResponseTypes",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                schema: "eval",
                table: "ResponseTypes",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                schema: "eval",
                table: "ResponseTypes",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                schema: "eval",
                table: "ResponseTypes",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                schema: "eval",
                table: "ResponseTypes",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                schema: "eval",
                table: "ResponseTypes",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                schema: "eval",
                table: "ResponseTypes",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 15, 37, 12, 729, DateTimeKind.Local).AddTicks(3670));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 15, 37, 12, 729, DateTimeKind.Local).AddTicks(3697));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 15, 37, 12, 729, DateTimeKind.Local).AddTicks(3699));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 15, 37, 12, 729, DateTimeKind.Local).AddTicks(3700));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 15, 37, 12, 729, DateTimeKind.Local).AddTicks(3702));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 15, 37, 12, 729, DateTimeKind.Local).AddTicks(3703));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 15, 37, 12, 729, DateTimeKind.Local).AddTicks(3705));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 15, 37, 12, 729, DateTimeKind.Local).AddTicks(3706));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 15, 37, 12, 729, DateTimeKind.Local).AddTicks(3707));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 15, 37, 12, 729, DateTimeKind.Local).AddTicks(3709));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 15, 37, 12, 729, DateTimeKind.Local).AddTicks(3710));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 15, 37, 12, 729, DateTimeKind.Local).AddTicks(3711));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 15, 37, 12, 729, DateTimeKind.Local).AddTicks(3713));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 15, 37, 12, 729, DateTimeKind.Local).AddTicks(3714));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 15, 37, 12, 729, DateTimeKind.Local).AddTicks(3716));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 15, 37, 12, 729, DateTimeKind.Local).AddTicks(3718));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 15, 37, 12, 729, DateTimeKind.Local).AddTicks(3719));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 15, 37, 12, 729, DateTimeKind.Local).AddTicks(3720));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 15, 37, 12, 729, DateTimeKind.Local).AddTicks(3722));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 15, 37, 12, 729, DateTimeKind.Local).AddTicks(3723));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 15, 37, 12, 729, DateTimeKind.Local).AddTicks(3725));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 15, 37, 12, 729, DateTimeKind.Local).AddTicks(3737));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 15, 37, 12, 729, DateTimeKind.Local).AddTicks(3738));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 15, 37, 12, 729, DateTimeKind.Local).AddTicks(3740));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 15, 37, 12, 729, DateTimeKind.Local).AddTicks(3741));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 15, 37, 12, 729, DateTimeKind.Local).AddTicks(3742));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 15, 37, 12, 729, DateTimeKind.Local).AddTicks(3744));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 15, 37, 12, 729, DateTimeKind.Local).AddTicks(3745));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 15, 37, 12, 729, DateTimeKind.Local).AddTicks(3747));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 15, 37, 12, 729, DateTimeKind.Local).AddTicks(3752));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 15, 37, 12, 729, DateTimeKind.Local).AddTicks(3763));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 15, 37, 12, 729, DateTimeKind.Local).AddTicks(3764));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 15, 37, 12, 729, DateTimeKind.Local).AddTicks(4489));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 15, 37, 12, 729, DateTimeKind.Local).AddTicks(4494));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 15, 37, 12, 729, DateTimeKind.Local).AddTicks(4497));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 15, 37, 12, 729, DateTimeKind.Local).AddTicks(4499));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 15, 37, 12, 729, DateTimeKind.Local).AddTicks(4500));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 15, 37, 12, 729, DateTimeKind.Local).AddTicks(4502));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 15, 37, 12, 729, DateTimeKind.Local).AddTicks(4504));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "QuestionCategories",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 15, 37, 12, 734, DateTimeKind.Local).AddTicks(9155));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "QuestionSections",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 15, 37, 12, 735, DateTimeKind.Local).AddTicks(4764));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "QuestionSections",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 15, 37, 12, 735, DateTimeKind.Local).AddTicks(4768));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "QuestionSections",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 15, 37, 12, 735, DateTimeKind.Local).AddTicks(4770));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "Questions",
                keyColumn: "Id",
                keyValue: 100,
                columns: new[] { "CreatedDateTime", "ResponseTypeId" },
                values: new object[] { new DateTime(2024, 10, 27, 15, 37, 12, 735, DateTimeKind.Local).AddTicks(908), 2 });

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "Questions",
                keyColumn: "Id",
                keyValue: 101,
                columns: new[] { "CreatedDateTime", "ResponseTypeId" },
                values: new object[] { new DateTime(2024, 10, 27, 15, 37, 12, 735, DateTimeKind.Local).AddTicks(913), 2 });

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "Questions",
                keyColumn: "Id",
                keyValue: 102,
                columns: new[] { "CreatedDateTime", "ResponseTypeId" },
                values: new object[] { new DateTime(2024, 10, 27, 15, 37, 12, 735, DateTimeKind.Local).AddTicks(915), 2 });

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "Questions",
                keyColumn: "Id",
                keyValue: 103,
                columns: new[] { "CreatedDateTime", "ResponseTypeId" },
                values: new object[] { new DateTime(2024, 10, 27, 15, 37, 12, 735, DateTimeKind.Local).AddTicks(916), 2 });

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "Questions",
                keyColumn: "Id",
                keyValue: 104,
                columns: new[] { "CreatedDateTime", "ResponseTypeId" },
                values: new object[] { new DateTime(2024, 10, 27, 15, 37, 12, 735, DateTimeKind.Local).AddTicks(921), 2 });

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "Questions",
                keyColumn: "Id",
                keyValue: 106,
                columns: new[] { "CreatedDateTime", "ResponseTypeId" },
                values: new object[] { new DateTime(2024, 10, 27, 15, 37, 12, 735, DateTimeKind.Local).AddTicks(922), 2 });

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "Questions",
                keyColumn: "Id",
                keyValue: 107,
                columns: new[] { "CreatedDateTime", "ResponseTypeId" },
                values: new object[] { new DateTime(2024, 10, 27, 15, 37, 12, 735, DateTimeKind.Local).AddTicks(923), 2 });

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "Questions",
                keyColumn: "Id",
                keyValue: 108,
                columns: new[] { "CreatedDateTime", "ResponseTypeId" },
                values: new object[] { new DateTime(2024, 10, 27, 15, 37, 12, 735, DateTimeKind.Local).AddTicks(925), 2 });

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "Questions",
                keyColumn: "Id",
                keyValue: 109,
                columns: new[] { "CreatedDateTime", "ResponseTypeId" },
                values: new object[] { new DateTime(2024, 10, 27, 15, 37, 12, 735, DateTimeKind.Local).AddTicks(926), 2 });

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "Questions",
                keyColumn: "Id",
                keyValue: 110,
                columns: new[] { "CreatedDateTime", "ResponseTypeId" },
                values: new object[] { new DateTime(2024, 10, 27, 15, 37, 12, 735, DateTimeKind.Local).AddTicks(927), 2 });

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "Questions",
                keyColumn: "Id",
                keyValue: 111,
                columns: new[] { "CreatedDateTime", "ResponseTypeId" },
                values: new object[] { new DateTime(2024, 10, 27, 15, 37, 12, 735, DateTimeKind.Local).AddTicks(928), 2 });

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "Questions",
                keyColumn: "Id",
                keyValue: 112,
                columns: new[] { "CreatedDateTime", "ResponseTypeId" },
                values: new object[] { new DateTime(2024, 10, 27, 15, 37, 12, 735, DateTimeKind.Local).AddTicks(929), 2 });

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "Questions",
                keyColumn: "Id",
                keyValue: 113,
                columns: new[] { "CreatedDateTime", "ResponseTypeId" },
                values: new object[] { new DateTime(2024, 10, 27, 15, 37, 12, 735, DateTimeKind.Local).AddTicks(931), 2 });

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "Questions",
                keyColumn: "Id",
                keyValue: 114,
                columns: new[] { "CreatedDateTime", "ResponseTypeId" },
                values: new object[] { new DateTime(2024, 10, 27, 15, 37, 12, 735, DateTimeKind.Local).AddTicks(932), 2 });

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "Questions",
                keyColumn: "Id",
                keyValue: 115,
                columns: new[] { "CreatedDateTime", "ResponseTypeId" },
                values: new object[] { new DateTime(2024, 10, 27, 15, 37, 12, 735, DateTimeKind.Local).AddTicks(933), 2 });

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "Questions",
                keyColumn: "Id",
                keyValue: 116,
                columns: new[] { "CreatedDateTime", "ResponseTypeId" },
                values: new object[] { new DateTime(2024, 10, 27, 15, 37, 12, 735, DateTimeKind.Local).AddTicks(934), 2 });

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "Questions",
                keyColumn: "Id",
                keyValue: 117,
                columns: new[] { "CreatedDateTime", "ResponseTypeId" },
                values: new object[] { new DateTime(2024, 10, 27, 15, 37, 12, 735, DateTimeKind.Local).AddTicks(935), 2 });

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "Questions",
                keyColumn: "Id",
                keyValue: 118,
                columns: new[] { "CreatedDateTime", "ResponseTypeId" },
                values: new object[] { new DateTime(2024, 10, 27, 15, 37, 12, 735, DateTimeKind.Local).AddTicks(937), 2 });

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseOptions",
                keyColumn: "Id",
                keyValue: 50,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 15, 37, 12, 735, DateTimeKind.Local).AddTicks(8587));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseOptions",
                keyColumn: "Id",
                keyValue: 51,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 15, 37, 12, 735, DateTimeKind.Local).AddTicks(8592));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseOptions",
                keyColumn: "Id",
                keyValue: 52,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 15, 37, 12, 735, DateTimeKind.Local).AddTicks(8594));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseOptions",
                keyColumn: "Id",
                keyValue: 53,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 15, 37, 12, 735, DateTimeKind.Local).AddTicks(8595));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseOptions",
                keyColumn: "Id",
                keyValue: 54,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 15, 37, 12, 735, DateTimeKind.Local).AddTicks(8596));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseTypes",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedDateTime", "Description" },
                values: new object[] { new DateTime(2024, 10, 27, 15, 37, 12, 736, DateTimeKind.Local).AddTicks(558), "Approved, Approved with Conditions, Not Approved" });

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseTypes",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedDateTime", "Description" },
                values: new object[] { new DateTime(2024, 10, 27, 15, 37, 12, 736, DateTimeKind.Local).AddTicks(563), "Approved, Not Approved" });
        }
    }
}
