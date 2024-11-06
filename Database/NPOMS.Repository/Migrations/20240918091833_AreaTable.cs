using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NPOMS.Repository.Migrations
{
    /// <inheritdoc />
    public partial class AreaTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AreaId",
                schema: "dropdown",
                table: "SubDistrictDemographics",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SubParentiId",
                schema: "dropdown",
                table: "ManicipalityDemographics",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsSubParent",
                schema: "dropdown",
                table: "DistrictDemographics",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Areas",
                schema: "dropdown",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    DistrictId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1"),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
                    UpdatedUserId = table.Column<int>(type: "int", nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DistrictDemographicId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Areas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Areas_DistrictDemographics_DistrictDemographicId",
                        column: x => x.DistrictDemographicId,
                        principalSchema: "dropdown",
                        principalTable: "DistrictDemographics",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                schema: "dropdown",
                table: "Areas",
                columns: new[] { "Id", "DistrictDemographicId", "DistrictId", "Name", "UpdatedDateTime", "UpdatedUserId" },
                values: new object[,]
                {
                    { 1, null, 3, "Central", null, null },
                    { 2, null, 3, "North", null, null },
                    { 3, null, 3, "East", null, null },
                    { 4, null, 3, "South", null, null }
                });

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "DistrictDemographics",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsSubParent",
                value: false);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "DistrictDemographics",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsSubParent",
                value: false);

            migrationBuilder.InsertData(
                schema: "dropdown",
                table: "DistrictDemographics",
                columns: new[] { "Id", "IsSubParent", "Name", "UpdatedDateTime", "UpdatedUserId" },
                values: new object[] { 3, true, "CHS", null, null });

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "ManicipalityDemographics",
                keyColumn: "Id",
                keyValue: 1,
                column: "SubParentiId",
                value: 3);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "ManicipalityDemographics",
                keyColumn: "Id",
                keyValue: 2,
                column: "SubParentiId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "ManicipalityDemographics",
                keyColumn: "Id",
                keyValue: 3,
                column: "SubParentiId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "ManicipalityDemographics",
                keyColumn: "Id",
                keyValue: 4,
                column: "SubParentiId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "ManicipalityDemographics",
                keyColumn: "Id",
                keyValue: 5,
                column: "SubParentiId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "ManicipalityDemographics",
                keyColumn: "Id",
                keyValue: 6,
                column: "SubParentiId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 18, 11, 18, 23, 781, DateTimeKind.Local).AddTicks(1380));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 18, 11, 18, 23, 781, DateTimeKind.Local).AddTicks(1400));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 18, 11, 18, 23, 781, DateTimeKind.Local).AddTicks(1402));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 18, 11, 18, 23, 781, DateTimeKind.Local).AddTicks(1403));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 18, 11, 18, 23, 781, DateTimeKind.Local).AddTicks(1405));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 18, 11, 18, 23, 781, DateTimeKind.Local).AddTicks(1406));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 18, 11, 18, 23, 781, DateTimeKind.Local).AddTicks(1408));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 18, 11, 18, 23, 781, DateTimeKind.Local).AddTicks(1409));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 18, 11, 18, 23, 781, DateTimeKind.Local).AddTicks(1411));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 18, 11, 18, 23, 781, DateTimeKind.Local).AddTicks(1413));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 18, 11, 18, 23, 781, DateTimeKind.Local).AddTicks(1414));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 18, 11, 18, 23, 781, DateTimeKind.Local).AddTicks(1416));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 18, 11, 18, 23, 781, DateTimeKind.Local).AddTicks(1417));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 18, 11, 18, 23, 781, DateTimeKind.Local).AddTicks(1419));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 18, 11, 18, 23, 781, DateTimeKind.Local).AddTicks(1421));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 18, 11, 18, 23, 781, DateTimeKind.Local).AddTicks(1422));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 18, 11, 18, 23, 781, DateTimeKind.Local).AddTicks(1425));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 18, 11, 18, 23, 781, DateTimeKind.Local).AddTicks(1426));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 18, 11, 18, 23, 781, DateTimeKind.Local).AddTicks(1428));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 18, 11, 18, 23, 781, DateTimeKind.Local).AddTicks(1429));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 18, 11, 18, 23, 781, DateTimeKind.Local).AddTicks(1431));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 18, 11, 18, 23, 781, DateTimeKind.Local).AddTicks(1433));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 18, 11, 18, 23, 781, DateTimeKind.Local).AddTicks(1434));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 18, 11, 18, 23, 781, DateTimeKind.Local).AddTicks(1436));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 18, 11, 18, 23, 781, DateTimeKind.Local).AddTicks(1438));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 18, 11, 18, 23, 781, DateTimeKind.Local).AddTicks(1439));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 18, 11, 18, 23, 781, DateTimeKind.Local).AddTicks(1441));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 18, 11, 18, 23, 781, DateTimeKind.Local).AddTicks(1461));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 18, 11, 18, 23, 781, DateTimeKind.Local).AddTicks(1462));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 18, 11, 18, 23, 781, DateTimeKind.Local).AddTicks(1467));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 18, 11, 18, 23, 781, DateTimeKind.Local).AddTicks(1479));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 18, 11, 18, 23, 781, DateTimeKind.Local).AddTicks(1481));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 18, 11, 18, 23, 781, DateTimeKind.Local).AddTicks(2117));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 18, 11, 18, 23, 781, DateTimeKind.Local).AddTicks(2121));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 18, 11, 18, 23, 781, DateTimeKind.Local).AddTicks(2123));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 18, 11, 18, 23, 781, DateTimeKind.Local).AddTicks(2126));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 18, 11, 18, 23, 781, DateTimeKind.Local).AddTicks(2128));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 18, 11, 18, 23, 781, DateTimeKind.Local).AddTicks(2130));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 18, 11, 18, 23, 781, DateTimeKind.Local).AddTicks(2174));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubDistrictDemographics",
                keyColumn: "Id",
                keyValue: 1,
                column: "AreaId",
                value: 3);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubDistrictDemographics",
                keyColumn: "Id",
                keyValue: 2,
                column: "AreaId",
                value: 3);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubDistrictDemographics",
                keyColumn: "Id",
                keyValue: 3,
                column: "AreaId",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubDistrictDemographics",
                keyColumn: "Id",
                keyValue: 4,
                column: "AreaId",
                value: 4);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubDistrictDemographics",
                keyColumn: "Id",
                keyValue: 5,
                column: "AreaId",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubDistrictDemographics",
                keyColumn: "Id",
                keyValue: 6,
                column: "AreaId",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubDistrictDemographics",
                keyColumn: "Id",
                keyValue: 7,
                column: "AreaId",
                value: 4);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubDistrictDemographics",
                keyColumn: "Id",
                keyValue: 8,
                column: "AreaId",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubDistrictDemographics",
                keyColumn: "Id",
                keyValue: 9,
                column: "AreaId",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubDistrictDemographics",
                keyColumn: "Id",
                keyValue: 10,
                column: "AreaId",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubDistrictDemographics",
                keyColumn: "Id",
                keyValue: 11,
                column: "AreaId",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubDistrictDemographics",
                keyColumn: "Id",
                keyValue: 12,
                column: "AreaId",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubDistrictDemographics",
                keyColumn: "Id",
                keyValue: 13,
                column: "AreaId",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubDistrictDemographics",
                keyColumn: "Id",
                keyValue: 14,
                column: "AreaId",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubDistrictDemographics",
                keyColumn: "Id",
                keyValue: 15,
                column: "AreaId",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubDistrictDemographics",
                keyColumn: "Id",
                keyValue: 16,
                column: "AreaId",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubDistrictDemographics",
                keyColumn: "Id",
                keyValue: 17,
                column: "AreaId",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubDistrictDemographics",
                keyColumn: "Id",
                keyValue: 18,
                column: "AreaId",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubDistrictDemographics",
                keyColumn: "Id",
                keyValue: 19,
                column: "AreaId",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubDistrictDemographics",
                keyColumn: "Id",
                keyValue: 20,
                column: "AreaId",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubDistrictDemographics",
                keyColumn: "Id",
                keyValue: 21,
                column: "AreaId",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubDistrictDemographics",
                keyColumn: "Id",
                keyValue: 22,
                column: "AreaId",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubDistrictDemographics",
                keyColumn: "Id",
                keyValue: 23,
                column: "AreaId",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubDistrictDemographics",
                keyColumn: "Id",
                keyValue: 24,
                column: "AreaId",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubDistrictDemographics",
                keyColumn: "Id",
                keyValue: 25,
                column: "AreaId",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubDistrictDemographics",
                keyColumn: "Id",
                keyValue: 27,
                column: "AreaId",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubDistrictDemographics",
                keyColumn: "Id",
                keyValue: 28,
                column: "AreaId",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubDistrictDemographics",
                keyColumn: "Id",
                keyValue: 29,
                column: "AreaId",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubDistrictDemographics",
                keyColumn: "Id",
                keyValue: 30,
                column: "AreaId",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubDistrictDemographics",
                keyColumn: "Id",
                keyValue: 31,
                column: "AreaId",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubDistrictDemographics",
                keyColumn: "Id",
                keyValue: 32,
                column: "AreaId",
                value: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Areas_DistrictDemographicId",
                schema: "dropdown",
                table: "Areas",
                column: "DistrictDemographicId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Areas",
                schema: "dropdown");

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "DistrictDemographics",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "AreaId",
                schema: "dropdown",
                table: "SubDistrictDemographics");

            migrationBuilder.DropColumn(
                name: "SubParentiId",
                schema: "dropdown",
                table: "ManicipalityDemographics");

            migrationBuilder.DropColumn(
                name: "IsSubParent",
                schema: "dropdown",
                table: "DistrictDemographics");

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 10, 19, 1, 14, 376, DateTimeKind.Local).AddTicks(7275));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 10, 19, 1, 14, 376, DateTimeKind.Local).AddTicks(7284));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 10, 19, 1, 14, 376, DateTimeKind.Local).AddTicks(7286));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 10, 19, 1, 14, 376, DateTimeKind.Local).AddTicks(7287));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 10, 19, 1, 14, 376, DateTimeKind.Local).AddTicks(7289));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 10, 19, 1, 14, 376, DateTimeKind.Local).AddTicks(7290));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 10, 19, 1, 14, 376, DateTimeKind.Local).AddTicks(7292));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 10, 19, 1, 14, 376, DateTimeKind.Local).AddTicks(7294));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 10, 19, 1, 14, 376, DateTimeKind.Local).AddTicks(7296));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 10, 19, 1, 14, 376, DateTimeKind.Local).AddTicks(7298));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 10, 19, 1, 14, 376, DateTimeKind.Local).AddTicks(7300));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 10, 19, 1, 14, 376, DateTimeKind.Local).AddTicks(7301));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 10, 19, 1, 14, 376, DateTimeKind.Local).AddTicks(7303));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 10, 19, 1, 14, 376, DateTimeKind.Local).AddTicks(7304));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 10, 19, 1, 14, 376, DateTimeKind.Local).AddTicks(7306));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 10, 19, 1, 14, 376, DateTimeKind.Local).AddTicks(7307));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 10, 19, 1, 14, 376, DateTimeKind.Local).AddTicks(7309));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 10, 19, 1, 14, 376, DateTimeKind.Local).AddTicks(7310));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 10, 19, 1, 14, 376, DateTimeKind.Local).AddTicks(7312));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 10, 19, 1, 14, 376, DateTimeKind.Local).AddTicks(7313));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 10, 19, 1, 14, 376, DateTimeKind.Local).AddTicks(7315));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 10, 19, 1, 14, 376, DateTimeKind.Local).AddTicks(7317));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 10, 19, 1, 14, 376, DateTimeKind.Local).AddTicks(7318));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 10, 19, 1, 14, 376, DateTimeKind.Local).AddTicks(7320));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 10, 19, 1, 14, 376, DateTimeKind.Local).AddTicks(7347));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 10, 19, 1, 14, 376, DateTimeKind.Local).AddTicks(7348));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 10, 19, 1, 14, 376, DateTimeKind.Local).AddTicks(7350));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 10, 19, 1, 14, 376, DateTimeKind.Local).AddTicks(7351));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 10, 19, 1, 14, 376, DateTimeKind.Local).AddTicks(7353));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 10, 19, 1, 14, 376, DateTimeKind.Local).AddTicks(7364));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 10, 19, 1, 14, 376, DateTimeKind.Local).AddTicks(7370));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 10, 19, 1, 14, 376, DateTimeKind.Local).AddTicks(7372));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 10, 19, 1, 14, 376, DateTimeKind.Local).AddTicks(7863));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 10, 19, 1, 14, 376, DateTimeKind.Local).AddTicks(7867));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 10, 19, 1, 14, 376, DateTimeKind.Local).AddTicks(7869));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 10, 19, 1, 14, 376, DateTimeKind.Local).AddTicks(7872));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 10, 19, 1, 14, 376, DateTimeKind.Local).AddTicks(7874));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 10, 19, 1, 14, 376, DateTimeKind.Local).AddTicks(7876));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 9, 10, 19, 1, 14, 376, DateTimeKind.Local).AddTicks(7879));
        }
    }
}
