using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NPOMS.Repository.Migrations
{
    /// <inheritdoc />
    public partial class AddDepartmentCodeToRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DepartmentCode",
                schema: "core",
                table: "Roles",
                type: "nvarchar(255)",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 20, 16, 20, 42, 970, DateTimeKind.Local).AddTicks(7229));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 20, 16, 20, 42, 970, DateTimeKind.Local).AddTicks(7257));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 20, 16, 20, 42, 970, DateTimeKind.Local).AddTicks(7260));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 20, 16, 20, 42, 970, DateTimeKind.Local).AddTicks(7262));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 20, 16, 20, 42, 970, DateTimeKind.Local).AddTicks(7263));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 20, 16, 20, 42, 970, DateTimeKind.Local).AddTicks(7265));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 20, 16, 20, 42, 970, DateTimeKind.Local).AddTicks(7267));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 20, 16, 20, 42, 970, DateTimeKind.Local).AddTicks(7269));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 20, 16, 20, 42, 970, DateTimeKind.Local).AddTicks(7270));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 20, 16, 20, 42, 970, DateTimeKind.Local).AddTicks(7272));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 20, 16, 20, 42, 970, DateTimeKind.Local).AddTicks(7274));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 20, 16, 20, 42, 970, DateTimeKind.Local).AddTicks(7275));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 20, 16, 20, 42, 970, DateTimeKind.Local).AddTicks(7277));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 20, 16, 20, 42, 970, DateTimeKind.Local).AddTicks(7279));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 20, 16, 20, 42, 970, DateTimeKind.Local).AddTicks(7280));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 20, 16, 20, 42, 970, DateTimeKind.Local).AddTicks(7282));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 20, 16, 20, 42, 970, DateTimeKind.Local).AddTicks(7284));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 20, 16, 20, 42, 970, DateTimeKind.Local).AddTicks(7286));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 20, 16, 20, 42, 970, DateTimeKind.Local).AddTicks(7287));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 20, 16, 20, 42, 970, DateTimeKind.Local).AddTicks(7289));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 20, 16, 20, 42, 970, DateTimeKind.Local).AddTicks(7291));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 20, 16, 20, 42, 970, DateTimeKind.Local).AddTicks(7292));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 20, 16, 20, 42, 970, DateTimeKind.Local).AddTicks(7294));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 20, 16, 20, 42, 970, DateTimeKind.Local).AddTicks(7296));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 20, 16, 20, 42, 970, DateTimeKind.Local).AddTicks(7297));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 20, 16, 20, 42, 970, DateTimeKind.Local).AddTicks(7299));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 20, 16, 20, 42, 970, DateTimeKind.Local).AddTicks(7301));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 20, 16, 20, 42, 970, DateTimeKind.Local).AddTicks(7325));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 20, 16, 20, 42, 970, DateTimeKind.Local).AddTicks(7327));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 20, 16, 20, 42, 970, DateTimeKind.Local).AddTicks(7334));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 20, 16, 20, 42, 970, DateTimeKind.Local).AddTicks(7358));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 20, 16, 20, 42, 970, DateTimeKind.Local).AddTicks(7360));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 20, 16, 20, 42, 970, DateTimeKind.Local).AddTicks(8179));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 20, 16, 20, 42, 970, DateTimeKind.Local).AddTicks(8184));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 20, 16, 20, 42, 970, DateTimeKind.Local).AddTicks(8187));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 20, 16, 20, 42, 970, DateTimeKind.Local).AddTicks(8189));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 20, 16, 20, 42, 970, DateTimeKind.Local).AddTicks(8191));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 20, 16, 20, 42, 970, DateTimeKind.Local).AddTicks(8194));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 20, 16, 20, 42, 970, DateTimeKind.Local).AddTicks(8196));

            migrationBuilder.UpdateData(
                schema: "core",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "DepartmentCode",
                value: "ALL");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "DepartmentCode",
                value: "ALL");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "DepartmentCode",
                value: "ALL");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4,
                column: "DepartmentCode",
                value: "DOH");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5,
                column: "DepartmentCode",
                value: "DOH");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6,
                column: "DepartmentCode",
                value: "DSD");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7,
                column: "DepartmentCode",
                value: "DSD");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8,
                column: "DepartmentCode",
                value: "DSD");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 9,
                column: "DepartmentCode",
                value: "DSD");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 10,
                column: "DepartmentCode",
                value: "DOH");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 11,
                column: "DepartmentCode",
                value: "DSD");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 12,
                column: "DepartmentCode",
                value: "DSD");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 13,
                column: "DepartmentCode",
                value: "DSD");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DepartmentCode",
                schema: "core",
                table: "Roles");

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 20, 14, 15, 44, 949, DateTimeKind.Local).AddTicks(4421));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 20, 14, 15, 44, 949, DateTimeKind.Local).AddTicks(4442));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 20, 14, 15, 44, 949, DateTimeKind.Local).AddTicks(4444));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 20, 14, 15, 44, 949, DateTimeKind.Local).AddTicks(4445));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 20, 14, 15, 44, 949, DateTimeKind.Local).AddTicks(4446));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 20, 14, 15, 44, 949, DateTimeKind.Local).AddTicks(4448));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 20, 14, 15, 44, 949, DateTimeKind.Local).AddTicks(4449));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 20, 14, 15, 44, 949, DateTimeKind.Local).AddTicks(4450));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 20, 14, 15, 44, 949, DateTimeKind.Local).AddTicks(4452));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 20, 14, 15, 44, 949, DateTimeKind.Local).AddTicks(4453));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 20, 14, 15, 44, 949, DateTimeKind.Local).AddTicks(4454));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 20, 14, 15, 44, 949, DateTimeKind.Local).AddTicks(4456));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 20, 14, 15, 44, 949, DateTimeKind.Local).AddTicks(4457));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 20, 14, 15, 44, 949, DateTimeKind.Local).AddTicks(4458));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 20, 14, 15, 44, 949, DateTimeKind.Local).AddTicks(4460));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 20, 14, 15, 44, 949, DateTimeKind.Local).AddTicks(4462));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 20, 14, 15, 44, 949, DateTimeKind.Local).AddTicks(4463));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 20, 14, 15, 44, 949, DateTimeKind.Local).AddTicks(4464));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 20, 14, 15, 44, 949, DateTimeKind.Local).AddTicks(4466));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 20, 14, 15, 44, 949, DateTimeKind.Local).AddTicks(4467));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 20, 14, 15, 44, 949, DateTimeKind.Local).AddTicks(4468));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 20, 14, 15, 44, 949, DateTimeKind.Local).AddTicks(4469));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 20, 14, 15, 44, 949, DateTimeKind.Local).AddTicks(4471));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 20, 14, 15, 44, 949, DateTimeKind.Local).AddTicks(4472));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 20, 14, 15, 44, 949, DateTimeKind.Local).AddTicks(4473));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 20, 14, 15, 44, 949, DateTimeKind.Local).AddTicks(4474));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 20, 14, 15, 44, 949, DateTimeKind.Local).AddTicks(4476));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 20, 14, 15, 44, 949, DateTimeKind.Local).AddTicks(4481));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 20, 14, 15, 44, 949, DateTimeKind.Local).AddTicks(4483));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 20, 14, 15, 44, 949, DateTimeKind.Local).AddTicks(4487));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 20, 14, 15, 44, 949, DateTimeKind.Local).AddTicks(4511));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 20, 14, 15, 44, 949, DateTimeKind.Local).AddTicks(4512));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 20, 14, 15, 44, 949, DateTimeKind.Local).AddTicks(4960));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 20, 14, 15, 44, 949, DateTimeKind.Local).AddTicks(4964));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 20, 14, 15, 44, 949, DateTimeKind.Local).AddTicks(4966));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 20, 14, 15, 44, 949, DateTimeKind.Local).AddTicks(4968));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 20, 14, 15, 44, 949, DateTimeKind.Local).AddTicks(4970));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 20, 14, 15, 44, 949, DateTimeKind.Local).AddTicks(4972));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 20, 14, 15, 44, 949, DateTimeKind.Local).AddTicks(4973));
        }
    }
}
