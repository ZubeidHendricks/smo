using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NPOMS.Repository.Migrations
{
    /// <inheritdoc />
    public partial class ProgrammeSDADetail_Region : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProgrammeServiceDelivery_Regions_RegionId",
                schema: "dbo",
                table: "ProgrammeServiceDelivery");

            migrationBuilder.DropForeignKey(
                name: "FK_ProgrammeServiceDelivery_ServiceDeliveryAreas_ServiceDeliveryAreaId",
                schema: "dbo",
                table: "ProgrammeServiceDelivery");

            migrationBuilder.DropIndex(
                name: "IX_ProgrammeServiceDelivery_RegionId",
                schema: "dbo",
                table: "ProgrammeServiceDelivery");

            migrationBuilder.DropIndex(
                name: "IX_ProgrammeServiceDelivery_ServiceDeliveryAreaId",
                schema: "dbo",
                table: "ProgrammeServiceDelivery");

            migrationBuilder.DropColumn(
                name: "RegionId",
                schema: "dbo",
                table: "ProgrammeServiceDelivery");

            migrationBuilder.DropColumn(
                name: "ServiceDeliveryAreaId",
                schema: "dbo",
                table: "ProgrammeServiceDelivery");

            migrationBuilder.CreateTable(
                name: "ProgrameServiceDeliveryAreas",
                schema: "mapping",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProgrameServiceDeliverId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ProgrameServiceDeliveryId = table.Column<int>(type: "int", nullable: true),
                    ServiceDeliveryAreaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgrameServiceDeliveryAreas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProgrameServiceDeliveryAreas_ProgrammeServiceDelivery_ProgrameServiceDeliveryId",
                        column: x => x.ProgrameServiceDeliveryId,
                        principalSchema: "dbo",
                        principalTable: "ProgrammeServiceDelivery",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProgrameServiceDeliveryAreas_ServiceDeliveryAreas_ServiceDeliveryAreaId",
                        column: x => x.ServiceDeliveryAreaId,
                        principalSchema: "dropdown",
                        principalTable: "ServiceDeliveryAreas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProgrammeSDADetail_Regions",
                schema: "mapping",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ProgrameServiceDeliverId = table.Column<int>(type: "int", nullable: false),
                    ProgrameServiceDeliveryId = table.Column<int>(type: "int", nullable: true),
                    RegionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgrammeSDADetail_Regions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProgrammeSDADetail_Regions_ProgrammeServiceDelivery_ProgrameServiceDeliveryId",
                        column: x => x.ProgrameServiceDeliveryId,
                        principalSchema: "dbo",
                        principalTable: "ProgrammeServiceDelivery",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProgrammeSDADetail_Regions_Regions_RegionId",
                        column: x => x.RegionId,
                        principalSchema: "dropdown",
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 15, 21, 32, 28, 612, DateTimeKind.Local).AddTicks(7501));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 15, 21, 32, 28, 612, DateTimeKind.Local).AddTicks(7504));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 15, 21, 32, 28, 612, DateTimeKind.Local).AddTicks(7505));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 15, 21, 32, 28, 612, DateTimeKind.Local).AddTicks(7507));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 15, 21, 32, 28, 612, DateTimeKind.Local).AddTicks(7508));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 15, 21, 32, 28, 612, DateTimeKind.Local).AddTicks(7509));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 15, 21, 32, 28, 612, DateTimeKind.Local).AddTicks(7511));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 15, 21, 32, 28, 612, DateTimeKind.Local).AddTicks(7512));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 15, 21, 32, 28, 612, DateTimeKind.Local).AddTicks(7514));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 15, 21, 32, 28, 612, DateTimeKind.Local).AddTicks(7515));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 15, 21, 32, 28, 612, DateTimeKind.Local).AddTicks(7516));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 15, 21, 32, 28, 612, DateTimeKind.Local).AddTicks(7518));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 15, 21, 32, 28, 612, DateTimeKind.Local).AddTicks(7519));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 15, 21, 32, 28, 612, DateTimeKind.Local).AddTicks(7520));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 15, 21, 32, 28, 612, DateTimeKind.Local).AddTicks(7522));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 15, 21, 32, 28, 612, DateTimeKind.Local).AddTicks(7523));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 15, 21, 32, 28, 612, DateTimeKind.Local).AddTicks(7524));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 15, 21, 32, 28, 612, DateTimeKind.Local).AddTicks(7527));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 15, 21, 32, 28, 612, DateTimeKind.Local).AddTicks(7528));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 15, 21, 32, 28, 612, DateTimeKind.Local).AddTicks(7529));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 15, 21, 32, 28, 612, DateTimeKind.Local).AddTicks(7530));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 15, 21, 32, 28, 612, DateTimeKind.Local).AddTicks(7532));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 15, 21, 32, 28, 612, DateTimeKind.Local).AddTicks(7539));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 15, 21, 32, 28, 612, DateTimeKind.Local).AddTicks(7547));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 15, 21, 32, 28, 612, DateTimeKind.Local).AddTicks(7548));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 15, 21, 32, 28, 612, DateTimeKind.Local).AddTicks(7549));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 15, 21, 32, 28, 612, DateTimeKind.Local).AddTicks(7551));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 15, 21, 32, 28, 612, DateTimeKind.Local).AddTicks(7552));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 15, 21, 32, 28, 612, DateTimeKind.Local).AddTicks(7553));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 15, 21, 32, 28, 612, DateTimeKind.Local).AddTicks(7555));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 15, 21, 32, 28, 612, DateTimeKind.Local).AddTicks(7556));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 15, 21, 32, 28, 612, DateTimeKind.Local).AddTicks(7557));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 15, 21, 32, 28, 612, DateTimeKind.Local).AddTicks(7361));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 15, 21, 32, 28, 612, DateTimeKind.Local).AddTicks(7367));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 15, 21, 32, 28, 612, DateTimeKind.Local).AddTicks(7370));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 15, 21, 32, 28, 612, DateTimeKind.Local).AddTicks(7372));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 15, 21, 32, 28, 612, DateTimeKind.Local).AddTicks(7374));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 15, 21, 32, 28, 612, DateTimeKind.Local).AddTicks(7376));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 15, 21, 32, 28, 612, DateTimeKind.Local).AddTicks(7378));

            migrationBuilder.CreateIndex(
                name: "IX_ProgrameServiceDeliveryAreas_ProgrameServiceDeliveryId",
                schema: "mapping",
                table: "ProgrameServiceDeliveryAreas",
                column: "ProgrameServiceDeliveryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgrameServiceDeliveryAreas_ServiceDeliveryAreaId",
                schema: "mapping",
                table: "ProgrameServiceDeliveryAreas",
                column: "ServiceDeliveryAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgrammeSDADetail_Regions_ProgrameServiceDeliveryId",
                schema: "mapping",
                table: "ProgrammeSDADetail_Regions",
                column: "ProgrameServiceDeliveryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgrammeSDADetail_Regions_RegionId",
                schema: "mapping",
                table: "ProgrammeSDADetail_Regions",
                column: "RegionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProgrameServiceDeliveryAreas",
                schema: "mapping");

            migrationBuilder.DropTable(
                name: "ProgrammeSDADetail_Regions",
                schema: "mapping");

            migrationBuilder.AddColumn<int>(
                name: "RegionId",
                schema: "dbo",
                table: "ProgrammeServiceDelivery",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ServiceDeliveryAreaId",
                schema: "dbo",
                table: "ProgrammeServiceDelivery",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 15, 17, 59, 11, 507, DateTimeKind.Local).AddTicks(4425));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 15, 17, 59, 11, 507, DateTimeKind.Local).AddTicks(4427));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 15, 17, 59, 11, 507, DateTimeKind.Local).AddTicks(4429));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 15, 17, 59, 11, 507, DateTimeKind.Local).AddTicks(4431));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 15, 17, 59, 11, 507, DateTimeKind.Local).AddTicks(4433));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 15, 17, 59, 11, 507, DateTimeKind.Local).AddTicks(4434));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 15, 17, 59, 11, 507, DateTimeKind.Local).AddTicks(4436));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 15, 17, 59, 11, 507, DateTimeKind.Local).AddTicks(4437));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 15, 17, 59, 11, 507, DateTimeKind.Local).AddTicks(4439));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 15, 17, 59, 11, 507, DateTimeKind.Local).AddTicks(4441));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 15, 17, 59, 11, 507, DateTimeKind.Local).AddTicks(4442));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 15, 17, 59, 11, 507, DateTimeKind.Local).AddTicks(4444));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 15, 17, 59, 11, 507, DateTimeKind.Local).AddTicks(4450));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 15, 17, 59, 11, 507, DateTimeKind.Local).AddTicks(4451));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 15, 17, 59, 11, 507, DateTimeKind.Local).AddTicks(4453));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 15, 17, 59, 11, 507, DateTimeKind.Local).AddTicks(4454));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 15, 17, 59, 11, 507, DateTimeKind.Local).AddTicks(4456));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 15, 17, 59, 11, 507, DateTimeKind.Local).AddTicks(4457));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 15, 17, 59, 11, 507, DateTimeKind.Local).AddTicks(4459));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 15, 17, 59, 11, 507, DateTimeKind.Local).AddTicks(4461));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 15, 17, 59, 11, 507, DateTimeKind.Local).AddTicks(4462));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 15, 17, 59, 11, 507, DateTimeKind.Local).AddTicks(4464));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 15, 17, 59, 11, 507, DateTimeKind.Local).AddTicks(4472));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 15, 17, 59, 11, 507, DateTimeKind.Local).AddTicks(4482));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 15, 17, 59, 11, 507, DateTimeKind.Local).AddTicks(4483));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 15, 17, 59, 11, 507, DateTimeKind.Local).AddTicks(4485));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 15, 17, 59, 11, 507, DateTimeKind.Local).AddTicks(4486));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 15, 17, 59, 11, 507, DateTimeKind.Local).AddTicks(4488));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 15, 17, 59, 11, 507, DateTimeKind.Local).AddTicks(4489));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 15, 17, 59, 11, 507, DateTimeKind.Local).AddTicks(4491));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 15, 17, 59, 11, 507, DateTimeKind.Local).AddTicks(4492));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 15, 17, 59, 11, 507, DateTimeKind.Local).AddTicks(4494));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 15, 17, 59, 11, 507, DateTimeKind.Local).AddTicks(4275));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 15, 17, 59, 11, 507, DateTimeKind.Local).AddTicks(4282));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 15, 17, 59, 11, 507, DateTimeKind.Local).AddTicks(4284));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 15, 17, 59, 11, 507, DateTimeKind.Local).AddTicks(4287));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 15, 17, 59, 11, 507, DateTimeKind.Local).AddTicks(4289));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 15, 17, 59, 11, 507, DateTimeKind.Local).AddTicks(4317));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 15, 17, 59, 11, 507, DateTimeKind.Local).AddTicks(4320));

            migrationBuilder.CreateIndex(
                name: "IX_ProgrammeServiceDelivery_RegionId",
                schema: "dbo",
                table: "ProgrammeServiceDelivery",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgrammeServiceDelivery_ServiceDeliveryAreaId",
                schema: "dbo",
                table: "ProgrammeServiceDelivery",
                column: "ServiceDeliveryAreaId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProgrammeServiceDelivery_Regions_RegionId",
                schema: "dbo",
                table: "ProgrammeServiceDelivery",
                column: "RegionId",
                principalSchema: "dropdown",
                principalTable: "Regions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProgrammeServiceDelivery_ServiceDeliveryAreas_ServiceDeliveryAreaId",
                schema: "dbo",
                table: "ProgrammeServiceDelivery",
                column: "ServiceDeliveryAreaId",
                principalSchema: "dropdown",
                principalTable: "ServiceDeliveryAreas",
                principalColumn: "Id");
        }
    }
}
