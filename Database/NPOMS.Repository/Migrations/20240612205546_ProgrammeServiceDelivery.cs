using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NPOMS.Repository.Migrations
{
    /// <inheritdoc />
    public partial class ProgrammeServiceDelivery : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProgrammeServiceDelivery",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProgramId = table.Column<int>(type: "int", nullable: false),
                    RegionId = table.Column<int>(type: "int", nullable: true),
                    DistrictCouncilId = table.Column<int>(type: "int", nullable: false),
                    LocalMunicipalityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgrammeServiceDelivery", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProgrammeServiceDelivery_DistrictCouncils_DistrictCouncilId",
                        column: x => x.DistrictCouncilId,
                        principalSchema: "dropdown",
                        principalTable: "DistrictCouncils",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProgrammeServiceDelivery_LocalMunicipalities_LocalMunicipalityId",
                        column: x => x.LocalMunicipalityId,
                        principalSchema: "dropdown",
                        principalTable: "LocalMunicipalities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProgrammeServiceDelivery_Regions_RegionId",
                        column: x => x.RegionId,
                        principalSchema: "dropdown",
                        principalTable: "Regions",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                schema: "core",
                table: "Departments",
                keyColumn: "Id",
                keyValue: 5,
                column: "Abbreviation",
                value: "DOTP");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "Departments",
                keyColumn: "Id",
                keyValue: 8,
                column: "Abbreviation",
                value: "DOA");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "Departments",
                keyColumn: "Id",
                keyValue: 11,
                column: "Abbreviation",
                value: "DOH");

            migrationBuilder.InsertData(
                schema: "core",
                table: "Permissions",
                columns: new[] { "Id", "CategoryName", "Name", "SystemName", "UpdatedDateTime", "UpdatedUserId" },
                values: new object[,]
                {
                    { 120, "Administration - Side Navigation", "View Budget Summary Sub Menu", "SN.BudgetSummary", null, null },
                    { 121, "Budgets", "View Budget Summary", "Bud.VBS", null, null }
                });

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 12, 22, 55, 38, 567, DateTimeKind.Local).AddTicks(7108));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 12, 22, 55, 38, 567, DateTimeKind.Local).AddTicks(7110));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 12, 22, 55, 38, 567, DateTimeKind.Local).AddTicks(7112));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 12, 22, 55, 38, 567, DateTimeKind.Local).AddTicks(7114));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 12, 22, 55, 38, 567, DateTimeKind.Local).AddTicks(7115));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 12, 22, 55, 38, 567, DateTimeKind.Local).AddTicks(7117));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 12, 22, 55, 38, 567, DateTimeKind.Local).AddTicks(7118));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 12, 22, 55, 38, 567, DateTimeKind.Local).AddTicks(7120));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 12, 22, 55, 38, 567, DateTimeKind.Local).AddTicks(7122));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 12, 22, 55, 38, 567, DateTimeKind.Local).AddTicks(7123));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 12, 22, 55, 38, 567, DateTimeKind.Local).AddTicks(7125));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 12, 22, 55, 38, 567, DateTimeKind.Local).AddTicks(7126));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 12, 22, 55, 38, 567, DateTimeKind.Local).AddTicks(7133));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 12, 22, 55, 38, 567, DateTimeKind.Local).AddTicks(7134));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 12, 22, 55, 38, 567, DateTimeKind.Local).AddTicks(7136));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 12, 22, 55, 38, 567, DateTimeKind.Local).AddTicks(7137));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 12, 22, 55, 38, 567, DateTimeKind.Local).AddTicks(7139));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 12, 22, 55, 38, 567, DateTimeKind.Local).AddTicks(7140));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 12, 22, 55, 38, 567, DateTimeKind.Local).AddTicks(7142));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 12, 22, 55, 38, 567, DateTimeKind.Local).AddTicks(7143));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 12, 22, 55, 38, 567, DateTimeKind.Local).AddTicks(7145));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 12, 22, 55, 38, 567, DateTimeKind.Local).AddTicks(7146));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 12, 22, 55, 38, 567, DateTimeKind.Local).AddTicks(7154));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 12, 22, 55, 38, 567, DateTimeKind.Local).AddTicks(7163));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 12, 22, 55, 38, 567, DateTimeKind.Local).AddTicks(7164));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 12, 22, 55, 38, 567, DateTimeKind.Local).AddTicks(7166));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 12, 22, 55, 38, 567, DateTimeKind.Local).AddTicks(7167));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 12, 22, 55, 38, 567, DateTimeKind.Local).AddTicks(7169));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 12, 22, 55, 38, 567, DateTimeKind.Local).AddTicks(7170));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 12, 22, 55, 38, 567, DateTimeKind.Local).AddTicks(7172));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 12, 22, 55, 38, 567, DateTimeKind.Local).AddTicks(7173));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 12, 22, 55, 38, 567, DateTimeKind.Local).AddTicks(7175));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 12, 22, 55, 38, 567, DateTimeKind.Local).AddTicks(6986));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 12, 22, 55, 38, 567, DateTimeKind.Local).AddTicks(6993));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 12, 22, 55, 38, 567, DateTimeKind.Local).AddTicks(6996));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 12, 22, 55, 38, 567, DateTimeKind.Local).AddTicks(6998));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 12, 22, 55, 38, 567, DateTimeKind.Local).AddTicks(7001));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 12, 22, 55, 38, 567, DateTimeKind.Local).AddTicks(7003));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 12, 22, 55, 38, 567, DateTimeKind.Local).AddTicks(7005));

            migrationBuilder.InsertData(
                schema: "mapping",
                table: "Roles_Permissions",
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { 120, 1 },
                    { 121, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProgrammeServiceDelivery_DistrictCouncilId",
                schema: "dbo",
                table: "ProgrammeServiceDelivery",
                column: "DistrictCouncilId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgrammeServiceDelivery_LocalMunicipalityId",
                schema: "dbo",
                table: "ProgrammeServiceDelivery",
                column: "LocalMunicipalityId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgrammeServiceDelivery_RegionId",
                schema: "dbo",
                table: "ProgrammeServiceDelivery",
                column: "RegionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProgrammeServiceDelivery",
                schema: "dbo");

            migrationBuilder.DeleteData(
                schema: "mapping",
                table: "Roles_Permissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 120, 1 });

            migrationBuilder.DeleteData(
                schema: "mapping",
                table: "Roles_Permissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 121, 1 });

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 120);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 121);

            migrationBuilder.UpdateData(
                schema: "core",
                table: "Departments",
                keyColumn: "Id",
                keyValue: 5,
                column: "Abbreviation",
                value: "DotP");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "Departments",
                keyColumn: "Id",
                keyValue: 8,
                column: "Abbreviation",
                value: "DoA");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "Departments",
                keyColumn: "Id",
                keyValue: 11,
                column: "Abbreviation",
                value: "DoH");

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 12, 10, 31, 10, 188, DateTimeKind.Local).AddTicks(5178));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 12, 10, 31, 10, 188, DateTimeKind.Local).AddTicks(5180));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 12, 10, 31, 10, 188, DateTimeKind.Local).AddTicks(5182));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 12, 10, 31, 10, 188, DateTimeKind.Local).AddTicks(5183));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 12, 10, 31, 10, 188, DateTimeKind.Local).AddTicks(5184));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 12, 10, 31, 10, 188, DateTimeKind.Local).AddTicks(5186));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 12, 10, 31, 10, 188, DateTimeKind.Local).AddTicks(5187));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 12, 10, 31, 10, 188, DateTimeKind.Local).AddTicks(5188));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 12, 10, 31, 10, 188, DateTimeKind.Local).AddTicks(5190));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 12, 10, 31, 10, 188, DateTimeKind.Local).AddTicks(5191));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 12, 10, 31, 10, 188, DateTimeKind.Local).AddTicks(5192));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 12, 10, 31, 10, 188, DateTimeKind.Local).AddTicks(5194));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 12, 10, 31, 10, 188, DateTimeKind.Local).AddTicks(5196));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 12, 10, 31, 10, 188, DateTimeKind.Local).AddTicks(5197));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 12, 10, 31, 10, 188, DateTimeKind.Local).AddTicks(5198));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 12, 10, 31, 10, 188, DateTimeKind.Local).AddTicks(5200));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 12, 10, 31, 10, 188, DateTimeKind.Local).AddTicks(5201));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 12, 10, 31, 10, 188, DateTimeKind.Local).AddTicks(5203));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 12, 10, 31, 10, 188, DateTimeKind.Local).AddTicks(5204));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 12, 10, 31, 10, 188, DateTimeKind.Local).AddTicks(5205));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 12, 10, 31, 10, 188, DateTimeKind.Local).AddTicks(5206));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 12, 10, 31, 10, 188, DateTimeKind.Local).AddTicks(5208));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 12, 10, 31, 10, 188, DateTimeKind.Local).AddTicks(5213));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 12, 10, 31, 10, 188, DateTimeKind.Local).AddTicks(5225));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 12, 10, 31, 10, 188, DateTimeKind.Local).AddTicks(5227));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 12, 10, 31, 10, 188, DateTimeKind.Local).AddTicks(5228));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 12, 10, 31, 10, 188, DateTimeKind.Local).AddTicks(5229));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 12, 10, 31, 10, 188, DateTimeKind.Local).AddTicks(5231));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 12, 10, 31, 10, 188, DateTimeKind.Local).AddTicks(5253));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 12, 10, 31, 10, 188, DateTimeKind.Local).AddTicks(5254));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 12, 10, 31, 10, 188, DateTimeKind.Local).AddTicks(5255));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 12, 10, 31, 10, 188, DateTimeKind.Local).AddTicks(5257));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 12, 10, 31, 10, 188, DateTimeKind.Local).AddTicks(5056));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 12, 10, 31, 10, 188, DateTimeKind.Local).AddTicks(5064));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 12, 10, 31, 10, 188, DateTimeKind.Local).AddTicks(5066));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 12, 10, 31, 10, 188, DateTimeKind.Local).AddTicks(5068));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 12, 10, 31, 10, 188, DateTimeKind.Local).AddTicks(5070));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 12, 10, 31, 10, 188, DateTimeKind.Local).AddTicks(5072));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 12, 10, 31, 10, 188, DateTimeKind.Local).AddTicks(5074));
        }
    }
}
