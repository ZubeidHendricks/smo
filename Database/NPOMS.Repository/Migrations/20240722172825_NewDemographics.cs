using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NPOMS.Repository.Migrations
{
    /// <inheritdoc />
    public partial class NewDemographics : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DistrictDemographics",
                schema: "dropdown",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1"),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
                    UpdatedUserId = table.Column<int>(type: "int", nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DistrictDemographics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ManicipalityDemographics",
                schema: "dropdown",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DistrictDemographicId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1"),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
                    UpdatedUserId = table.Column<int>(type: "int", nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManicipalityDemographics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ManicipalityDemographics_DistrictDemographics_DistrictDemographicId",
                        column: x => x.DistrictDemographicId,
                        principalSchema: "dropdown",
                        principalTable: "DistrictDemographics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubSctrcureDemographics",
                schema: "dropdown",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ManicipalityDemographicId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1"),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
                    UpdatedUserId = table.Column<int>(type: "int", nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubSctrcureDemographics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubSctrcureDemographics_ManicipalityDemographics_ManicipalityDemographicId",
                        column: x => x.ManicipalityDemographicId,
                        principalSchema: "dropdown",
                        principalTable: "ManicipalityDemographics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubDistrictDemographics",
                schema: "dropdown",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubSctrcureDemographicId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1"),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
                    UpdatedUserId = table.Column<int>(type: "int", nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubDistrictDemographics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubDistrictDemographics_SubSctrcureDemographics_SubSctrcureDemographicId",
                        column: x => x.SubSctrcureDemographicId,
                        principalSchema: "dropdown",
                        principalTable: "SubSctrcureDemographics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "dropdown",
                table: "DistrictDemographics",
                columns: new[] { "Id", "Name", "UpdatedDateTime", "UpdatedUserId" },
                values: new object[,]
                {
                    { 1, "MHS", null, null },
                    { 2, "RHS", null, null }
                });

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 22, 19, 28, 14, 959, DateTimeKind.Local).AddTicks(3662));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 22, 19, 28, 14, 959, DateTimeKind.Local).AddTicks(3682));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 22, 19, 28, 14, 959, DateTimeKind.Local).AddTicks(3684));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 22, 19, 28, 14, 959, DateTimeKind.Local).AddTicks(3685));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 22, 19, 28, 14, 959, DateTimeKind.Local).AddTicks(3687));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 22, 19, 28, 14, 959, DateTimeKind.Local).AddTicks(3689));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 22, 19, 28, 14, 959, DateTimeKind.Local).AddTicks(3690));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 22, 19, 28, 14, 959, DateTimeKind.Local).AddTicks(3692));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 22, 19, 28, 14, 959, DateTimeKind.Local).AddTicks(3693));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 22, 19, 28, 14, 959, DateTimeKind.Local).AddTicks(3695));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 22, 19, 28, 14, 959, DateTimeKind.Local).AddTicks(3697));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 22, 19, 28, 14, 959, DateTimeKind.Local).AddTicks(3698));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 22, 19, 28, 14, 959, DateTimeKind.Local).AddTicks(3700));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 22, 19, 28, 14, 959, DateTimeKind.Local).AddTicks(3702));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 22, 19, 28, 14, 959, DateTimeKind.Local).AddTicks(3703));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 22, 19, 28, 14, 959, DateTimeKind.Local).AddTicks(3705));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 22, 19, 28, 14, 959, DateTimeKind.Local).AddTicks(3706));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 22, 19, 28, 14, 959, DateTimeKind.Local).AddTicks(3708));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 22, 19, 28, 14, 959, DateTimeKind.Local).AddTicks(3709));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 22, 19, 28, 14, 959, DateTimeKind.Local).AddTicks(3711));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 22, 19, 28, 14, 959, DateTimeKind.Local).AddTicks(3712));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 22, 19, 28, 14, 959, DateTimeKind.Local).AddTicks(3714));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 22, 19, 28, 14, 959, DateTimeKind.Local).AddTicks(3716));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 22, 19, 28, 14, 959, DateTimeKind.Local).AddTicks(3717));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 22, 19, 28, 14, 959, DateTimeKind.Local).AddTicks(3719));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 22, 19, 28, 14, 959, DateTimeKind.Local).AddTicks(3720));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 22, 19, 28, 14, 959, DateTimeKind.Local).AddTicks(3722));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 22, 19, 28, 14, 959, DateTimeKind.Local).AddTicks(3728));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 22, 19, 28, 14, 959, DateTimeKind.Local).AddTicks(3730));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 22, 19, 28, 14, 959, DateTimeKind.Local).AddTicks(3743));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 22, 19, 28, 14, 959, DateTimeKind.Local).AddTicks(3756));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 22, 19, 28, 14, 959, DateTimeKind.Local).AddTicks(3758));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 22, 19, 28, 14, 959, DateTimeKind.Local).AddTicks(4331));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 22, 19, 28, 14, 959, DateTimeKind.Local).AddTicks(4334));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 22, 19, 28, 14, 959, DateTimeKind.Local).AddTicks(4337));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 22, 19, 28, 14, 959, DateTimeKind.Local).AddTicks(4339));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 22, 19, 28, 14, 959, DateTimeKind.Local).AddTicks(4341));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 22, 19, 28, 14, 959, DateTimeKind.Local).AddTicks(4343));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 22, 19, 28, 14, 959, DateTimeKind.Local).AddTicks(4345));

            migrationBuilder.InsertData(
                schema: "dropdown",
                table: "ManicipalityDemographics",
                columns: new[] { "Id", "DistrictDemographicId", "Name", "UpdatedDateTime", "UpdatedUserId" },
                values: new object[,]
                {
                    { 1, 1, "City of Cape Town Metropolitan Municipality", null, null },
                    { 2, 2, "Cape Winelands District Municipality", null, null },
                    { 3, 2, "Central Karoo District Municipality", null, null },
                    { 4, 2, "Garden Route District Municipality", null, null },
                    { 5, 2, "Overberg District Municipality", null, null },
                    { 6, 2, "West Coast District Municipality", null, null }
                });

            migrationBuilder.InsertData(
                schema: "dropdown",
                table: "SubSctrcureDemographics",
                columns: new[] { "Id", "ManicipalityDemographicId", "Name", "UpdatedDateTime", "UpdatedUserId" },
                values: new object[,]
                {
                    { 1, 1, "KESS", null, null },
                    { 2, 1, "KMSS", null, null },
                    { 3, 1, "NTSS", null, null },
                    { 4, 1, "SWSS", null, null },
                    { 5, 2, "Cape winelands", null, null },
                    { 6, 3, "Central Karoo", null, null },
                    { 7, 4, "Garden Route", null, null },
                    { 8, 5, "Overbrgg", null, null },
                    { 9, 6, "West Coast", null, null }
                });

            migrationBuilder.InsertData(
                schema: "dropdown",
                table: "SubDistrictDemographics",
                columns: new[] { "Id", "Name", "SubSctrcureDemographicId", "UpdatedDateTime", "UpdatedUserId" },
                values: new object[,]
                {
                    { 1, "Cape Town Eastern Health sub-District", 1, null, null },
                    { 2, "Khayelitsha Health sub-District", 1, null, null },
                    { 3, "Klipfontein Health sub-District", 2, null, null },
                    { 4, "Mitchells Plain Health sub-District", 2, null, null },
                    { 5, "Cape Town Northern Health sub-District", 3, null, null },
                    { 6, "Tygerberg Health sub-District", 3, null, null },
                    { 7, "Cape Town Southern Health sub-District", 4, null, null },
                    { 8, "Cape Town Western Health sub-District", 4, null, null },
                    { 9, "Breede Valley Local Municipality", 5, null, null },
                    { 10, "Drakenstein Local Municipality", 5, null, null },
                    { 11, "Langeberg Local Municipality", 5, null, null },
                    { 12, "Stellenbosch Local Municipality", 5, null, null },
                    { 13, "Witzenberg Local Municipality", 5, null, null },
                    { 14, "Beaufort West Local Municipality", 6, null, null },
                    { 15, "Laingsburg Local Municipality", 6, null, null },
                    { 16, "Prince Albert Local Municipality", 6, null, null },
                    { 17, "Bitou Local Municipality", 7, null, null },
                    { 18, "Hessequa Local Municipality", 7, null, null },
                    { 19, "Kannaland Local Municipality", 7, null, null },
                    { 20, "Knysna Local Municipality", 7, null, null },
                    { 21, "Mossel Bay Local Municipality", 7, null, null },
                    { 22, "Oudtshoorn Local Municipality", 7, null, null },
                    { 23, "Cape Agulhas Local Municipality", 8, null, null },
                    { 24, "Overstrand Local Municipality", 8, null, null },
                    { 25, "Swellendam Local Municipality", 8, null, null },
                    { 27, "Theewaterskloof Local Municipality", 8, null, null },
                    { 28, "Bergrivier Local Municipality", 9, null, null },
                    { 29, "Cederberg Local Municipality", 9, null, null },
                    { 30, "Matzikama Local Municipality", 9, null, null },
                    { 31, "Saldanha Bay Local Municipality", 9, null, null },
                    { 32, "Swartland Local Municipality", 9, null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_NpoWorkPlanApproverTrackings_ApplicationId",
                schema: "dbo",
                table: "NpoWorkPlanApproverTrackings",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_NpoUserSatisfactionTrackings_ApplicationId",
                schema: "dbo",
                table: "NpoUserSatisfactionTrackings",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_ManicipalityDemographics_DistrictDemographicId",
                schema: "dropdown",
                table: "ManicipalityDemographics",
                column: "DistrictDemographicId");

            migrationBuilder.CreateIndex(
                name: "IX_SubDistrictDemographics_SubSctrcureDemographicId",
                schema: "dropdown",
                table: "SubDistrictDemographics",
                column: "SubSctrcureDemographicId");

            migrationBuilder.CreateIndex(
                name: "IX_SubSctrcureDemographics_ManicipalityDemographicId",
                schema: "dropdown",
                table: "SubSctrcureDemographics",
                column: "ManicipalityDemographicId");

            migrationBuilder.AddForeignKey(
                name: "FK_NpoUserSatisfactionTrackings_Applications_ApplicationId",
                schema: "dbo",
                table: "NpoUserSatisfactionTrackings",
                column: "ApplicationId",
                principalSchema: "dbo",
                principalTable: "Applications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NpoWorkPlanApproverTrackings_Applications_ApplicationId",
                schema: "dbo",
                table: "NpoWorkPlanApproverTrackings",
                column: "ApplicationId",
                principalSchema: "dbo",
                principalTable: "Applications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NpoUserSatisfactionTrackings_Applications_ApplicationId",
                schema: "dbo",
                table: "NpoUserSatisfactionTrackings");

            migrationBuilder.DropForeignKey(
                name: "FK_NpoWorkPlanApproverTrackings_Applications_ApplicationId",
                schema: "dbo",
                table: "NpoWorkPlanApproverTrackings");

            migrationBuilder.DropTable(
                name: "SubDistrictDemographics",
                schema: "dropdown");

            migrationBuilder.DropTable(
                name: "SubSctrcureDemographics",
                schema: "dropdown");

            migrationBuilder.DropTable(
                name: "ManicipalityDemographics",
                schema: "dropdown");

            migrationBuilder.DropTable(
                name: "DistrictDemographics",
                schema: "dropdown");

            migrationBuilder.DropIndex(
                name: "IX_NpoWorkPlanApproverTrackings_ApplicationId",
                schema: "dbo",
                table: "NpoWorkPlanApproverTrackings");

            migrationBuilder.DropIndex(
                name: "IX_NpoUserSatisfactionTrackings_ApplicationId",
                schema: "dbo",
                table: "NpoUserSatisfactionTrackings");

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 20, 15, 26, 59, 408, DateTimeKind.Local).AddTicks(8234));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 20, 15, 26, 59, 408, DateTimeKind.Local).AddTicks(8251));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 20, 15, 26, 59, 408, DateTimeKind.Local).AddTicks(8253));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 20, 15, 26, 59, 408, DateTimeKind.Local).AddTicks(8255));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 20, 15, 26, 59, 408, DateTimeKind.Local).AddTicks(8256));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 20, 15, 26, 59, 408, DateTimeKind.Local).AddTicks(8258));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 20, 15, 26, 59, 408, DateTimeKind.Local).AddTicks(8260));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 20, 15, 26, 59, 408, DateTimeKind.Local).AddTicks(8261));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 20, 15, 26, 59, 408, DateTimeKind.Local).AddTicks(8263));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 20, 15, 26, 59, 408, DateTimeKind.Local).AddTicks(8264));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 20, 15, 26, 59, 408, DateTimeKind.Local).AddTicks(8266));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 20, 15, 26, 59, 408, DateTimeKind.Local).AddTicks(8268));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 20, 15, 26, 59, 408, DateTimeKind.Local).AddTicks(8270));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 20, 15, 26, 59, 408, DateTimeKind.Local).AddTicks(8271));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 20, 15, 26, 59, 408, DateTimeKind.Local).AddTicks(8273));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 20, 15, 26, 59, 408, DateTimeKind.Local).AddTicks(8274));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 20, 15, 26, 59, 408, DateTimeKind.Local).AddTicks(8276));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 20, 15, 26, 59, 408, DateTimeKind.Local).AddTicks(8277));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 20, 15, 26, 59, 408, DateTimeKind.Local).AddTicks(8279));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 20, 15, 26, 59, 408, DateTimeKind.Local).AddTicks(8280));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 20, 15, 26, 59, 408, DateTimeKind.Local).AddTicks(8282));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 20, 15, 26, 59, 408, DateTimeKind.Local).AddTicks(8283));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 20, 15, 26, 59, 408, DateTimeKind.Local).AddTicks(8285));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 20, 15, 26, 59, 408, DateTimeKind.Local).AddTicks(8286));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 20, 15, 26, 59, 408, DateTimeKind.Local).AddTicks(8288));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 20, 15, 26, 59, 408, DateTimeKind.Local).AddTicks(8289));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 20, 15, 26, 59, 408, DateTimeKind.Local).AddTicks(8291));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 20, 15, 26, 59, 408, DateTimeKind.Local).AddTicks(8297));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 20, 15, 26, 59, 408, DateTimeKind.Local).AddTicks(8298));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 20, 15, 26, 59, 408, DateTimeKind.Local).AddTicks(8307));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 20, 15, 26, 59, 408, DateTimeKind.Local).AddTicks(8319));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 20, 15, 26, 59, 408, DateTimeKind.Local).AddTicks(8321));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 20, 15, 26, 59, 408, DateTimeKind.Local).AddTicks(8931));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 20, 15, 26, 59, 408, DateTimeKind.Local).AddTicks(8936));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 20, 15, 26, 59, 408, DateTimeKind.Local).AddTicks(8938));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 20, 15, 26, 59, 408, DateTimeKind.Local).AddTicks(8941));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 20, 15, 26, 59, 408, DateTimeKind.Local).AddTicks(8943));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 20, 15, 26, 59, 408, DateTimeKind.Local).AddTicks(8945));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 20, 15, 26, 59, 408, DateTimeKind.Local).AddTicks(8947));
        }
    }
}
