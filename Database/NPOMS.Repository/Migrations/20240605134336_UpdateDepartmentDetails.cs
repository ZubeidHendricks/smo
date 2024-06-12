using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NPOMS.Repository.Migrations
{
    public partial class UpdateDepartmentDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DenodoDepartmentName",
                schema: "core",
                table: "Departments",
                type: "nvarchar(255)",
                nullable: false,
                defaultValue: "Not Applicable");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1,
                column: "DenodoDepartmentName",
                value: "Not Applicable");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2,
                column: "DenodoDepartmentName",
                value: "Western Cape Economic Development And Tourism");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Abbreviation", "DenodoDepartmentName", "Name" },
                values: new object[] { "WCMD", "Western Cape Mobility", "Mobility" });

            migrationBuilder.UpdateData(
                schema: "core",
                table: "Departments",
                keyColumn: "Id",
                keyValue: 4,
                column: "DenodoDepartmentName",
                value: "Western Cape Education");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "Departments",
                keyColumn: "Id",
                keyValue: 5,
                column: "DenodoDepartmentName",
                value: "Western Cape Premier");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "Departments",
                keyColumn: "Id",
                keyValue: 6,
                column: "DenodoDepartmentName",
                value: "Western Cape Treasury");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "Departments",
                keyColumn: "Id",
                keyValue: 7,
                column: "DenodoDepartmentName",
                value: "Western Cape Social Development");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "Departments",
                keyColumn: "Id",
                keyValue: 8,
                column: "DenodoDepartmentName",
                value: "Western Cape Agriculture");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "Departments",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Abbreviation", "DenodoDepartmentName", "Name" },
                values: new object[] { "DOCS", "Western Cape Police Oversight and Community Safety", "Police Oversight and Community Safety" });

            migrationBuilder.UpdateData(
                schema: "core",
                table: "Departments",
                keyColumn: "Id",
                keyValue: 10,
                column: "DenodoDepartmentName",
                value: "Western Cape Cultural Affairs And Sport");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "Departments",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DenodoDepartmentName", "Name" },
                values: new object[] { "Western Cape Government: Health and Wellness", "Health and Wellness" });

            migrationBuilder.UpdateData(
                schema: "core",
                table: "Departments",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Abbreviation", "DenodoDepartmentName", "Name" },
                values: new object[] { "DOI", "Western Cape Infrastructure", "Infrastructure" });

            migrationBuilder.UpdateData(
                schema: "core",
                table: "Departments",
                keyColumn: "Id",
                keyValue: 13,
                column: "DenodoDepartmentName",
                value: "Western Cape Local Government");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "Departments",
                keyColumn: "Id",
                keyValue: 14,
                column: "DenodoDepartmentName",
                value: "Not Applicable");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "Departments",
                keyColumn: "Id",
                keyValue: 15,
                column: "DenodoDepartmentName",
                value: "Western Cape Environmental Affairs Development Planning");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "Departments",
                keyColumn: "Id",
                keyValue: 16,
                column: "DenodoDepartmentName",
                value: "Not Applicable");

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 5, 15, 43, 28, 164, DateTimeKind.Local).AddTicks(317));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 5, 15, 43, 28, 164, DateTimeKind.Local).AddTicks(324));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 5, 15, 43, 28, 164, DateTimeKind.Local).AddTicks(327));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 5, 15, 43, 28, 164, DateTimeKind.Local).AddTicks(330));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 5, 15, 43, 28, 164, DateTimeKind.Local).AddTicks(332));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 5, 15, 43, 28, 164, DateTimeKind.Local).AddTicks(335));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 5, 15, 43, 28, 164, DateTimeKind.Local).AddTicks(338));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 5, 15, 43, 28, 164, DateTimeKind.Local).AddTicks(340));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 5, 15, 43, 28, 164, DateTimeKind.Local).AddTicks(343));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 5, 15, 43, 28, 164, DateTimeKind.Local).AddTicks(345));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 5, 15, 43, 28, 164, DateTimeKind.Local).AddTicks(350));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 5, 15, 43, 28, 164, DateTimeKind.Local).AddTicks(352));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 5, 15, 43, 28, 164, DateTimeKind.Local).AddTicks(355));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 5, 15, 43, 28, 164, DateTimeKind.Local).AddTicks(357));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 5, 15, 43, 28, 164, DateTimeKind.Local).AddTicks(408));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 5, 15, 43, 28, 164, DateTimeKind.Local).AddTicks(410));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 5, 15, 43, 28, 164, DateTimeKind.Local).AddTicks(413));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 5, 15, 43, 28, 164, DateTimeKind.Local).AddTicks(416));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 5, 15, 43, 28, 164, DateTimeKind.Local).AddTicks(419));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 5, 15, 43, 28, 164, DateTimeKind.Local).AddTicks(421));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 5, 15, 43, 28, 164, DateTimeKind.Local).AddTicks(424));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 5, 15, 43, 28, 164, DateTimeKind.Local).AddTicks(426));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 5, 15, 43, 28, 164, DateTimeKind.Local).AddTicks(442));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 5, 15, 43, 28, 164, DateTimeKind.Local).AddTicks(487));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 5, 15, 43, 28, 164, DateTimeKind.Local).AddTicks(490));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 5, 15, 43, 28, 164, DateTimeKind.Local).AddTicks(492));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 5, 15, 43, 28, 164, DateTimeKind.Local).AddTicks(495));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 5, 15, 43, 28, 164, DateTimeKind.Local).AddTicks(498));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 5, 15, 43, 28, 164, DateTimeKind.Local).AddTicks(500));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 5, 15, 43, 28, 164, DateTimeKind.Local).AddTicks(503));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 5, 15, 43, 28, 164, DateTimeKind.Local).AddTicks(506));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 5, 15, 43, 28, 164, DateTimeKind.Local).AddTicks(508));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 5, 15, 43, 28, 163, DateTimeKind.Local).AddTicks(9893));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 5, 15, 43, 28, 163, DateTimeKind.Local).AddTicks(9961));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 5, 15, 43, 28, 163, DateTimeKind.Local).AddTicks(9966));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 5, 15, 43, 28, 163, DateTimeKind.Local).AddTicks(9969));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 5, 15, 43, 28, 163, DateTimeKind.Local).AddTicks(9973));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 5, 15, 43, 28, 163, DateTimeKind.Local).AddTicks(9976));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 5, 15, 43, 28, 163, DateTimeKind.Local).AddTicks(9980));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DenodoDepartmentName",
                schema: "core",
                table: "Departments");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Abbreviation", "Name" },
                values: new object[] { "DTPW", "Transport and Public Works" });

            migrationBuilder.UpdateData(
                schema: "core",
                table: "Departments",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Abbreviation", "Name" },
                values: new object[] { "DCS", "Community Safety" });

            migrationBuilder.UpdateData(
                schema: "core",
                table: "Departments",
                keyColumn: "Id",
                keyValue: 11,
                column: "Name",
                value: "Health");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "Departments",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Abbreviation", "Name" },
                values: new object[] { "DHS", "Human Settlements" });

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 5, 28, 12, 14, 46, 991, DateTimeKind.Local).AddTicks(7713));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 5, 28, 12, 14, 46, 991, DateTimeKind.Local).AddTicks(7715));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 5, 28, 12, 14, 46, 991, DateTimeKind.Local).AddTicks(7717));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 5, 28, 12, 14, 46, 991, DateTimeKind.Local).AddTicks(7719));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDateTime",
                value: new DateTime(2024, 5, 28, 12, 14, 46, 991, DateTimeKind.Local).AddTicks(7720));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 5, 28, 12, 14, 46, 991, DateTimeKind.Local).AddTicks(7722));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 5, 28, 12, 14, 46, 991, DateTimeKind.Local).AddTicks(7723));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 5, 28, 12, 14, 46, 991, DateTimeKind.Local).AddTicks(7729));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDateTime",
                value: new DateTime(2024, 5, 28, 12, 14, 46, 991, DateTimeKind.Local).AddTicks(7730));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDateTime",
                value: new DateTime(2024, 5, 28, 12, 14, 46, 991, DateTimeKind.Local).AddTicks(7731));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDateTime",
                value: new DateTime(2024, 5, 28, 12, 14, 46, 991, DateTimeKind.Local).AddTicks(7733));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDateTime",
                value: new DateTime(2024, 5, 28, 12, 14, 46, 991, DateTimeKind.Local).AddTicks(7734));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDateTime",
                value: new DateTime(2024, 5, 28, 12, 14, 46, 991, DateTimeKind.Local).AddTicks(7736));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDateTime",
                value: new DateTime(2024, 5, 28, 12, 14, 46, 991, DateTimeKind.Local).AddTicks(7737));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDateTime",
                value: new DateTime(2024, 5, 28, 12, 14, 46, 991, DateTimeKind.Local).AddTicks(7739));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDateTime",
                value: new DateTime(2024, 5, 28, 12, 14, 46, 991, DateTimeKind.Local).AddTicks(7740));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDateTime",
                value: new DateTime(2024, 5, 28, 12, 14, 46, 991, DateTimeKind.Local).AddTicks(7741));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDateTime",
                value: new DateTime(2024, 5, 28, 12, 14, 46, 991, DateTimeKind.Local).AddTicks(7743));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDateTime",
                value: new DateTime(2024, 5, 28, 12, 14, 46, 991, DateTimeKind.Local).AddTicks(7744));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDateTime",
                value: new DateTime(2024, 5, 28, 12, 14, 46, 991, DateTimeKind.Local).AddTicks(7746));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDateTime",
                value: new DateTime(2024, 5, 28, 12, 14, 46, 991, DateTimeKind.Local).AddTicks(7747));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDateTime",
                value: new DateTime(2024, 5, 28, 12, 14, 46, 991, DateTimeKind.Local).AddTicks(7749));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDateTime",
                value: new DateTime(2024, 5, 28, 12, 14, 46, 991, DateTimeKind.Local).AddTicks(7750));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDateTime",
                value: new DateTime(2024, 5, 28, 12, 14, 46, 991, DateTimeKind.Local).AddTicks(7751));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDateTime",
                value: new DateTime(2024, 5, 28, 12, 14, 46, 991, DateTimeKind.Local).AddTicks(7753));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDateTime",
                value: new DateTime(2024, 5, 28, 12, 14, 46, 991, DateTimeKind.Local).AddTicks(7754));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDateTime",
                value: new DateTime(2024, 5, 28, 12, 14, 46, 991, DateTimeKind.Local).AddTicks(7756));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedDateTime",
                value: new DateTime(2024, 5, 28, 12, 14, 46, 991, DateTimeKind.Local).AddTicks(7772));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedDateTime",
                value: new DateTime(2024, 5, 28, 12, 14, 46, 991, DateTimeKind.Local).AddTicks(7775));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedDateTime",
                value: new DateTime(2024, 5, 28, 12, 14, 46, 991, DateTimeKind.Local).AddTicks(7776));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDateTime",
                value: new DateTime(2024, 5, 28, 12, 14, 46, 991, DateTimeKind.Local).AddTicks(7777));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedDateTime",
                value: new DateTime(2024, 5, 28, 12, 14, 46, 991, DateTimeKind.Local).AddTicks(7779));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 5, 28, 12, 14, 46, 991, DateTimeKind.Local).AddTicks(7568));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 5, 28, 12, 14, 46, 991, DateTimeKind.Local).AddTicks(7580));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 5, 28, 12, 14, 46, 991, DateTimeKind.Local).AddTicks(7582));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 5, 28, 12, 14, 46, 991, DateTimeKind.Local).AddTicks(7584));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 5, 28, 12, 14, 46, 991, DateTimeKind.Local).AddTicks(7585));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 5, 28, 12, 14, 46, 991, DateTimeKind.Local).AddTicks(7587));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 5, 28, 12, 14, 46, 991, DateTimeKind.Local).AddTicks(7589));
        }
    }
}
