using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NPOMS.Repository.Migrations
{
    /// <inheritdoc />
    public partial class ProgrammeDeliveryUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProgrameServiceDeliveryAreas_ProgrammeServiceDelivery_ProgrameServiceDeliveryId",
                schema: "mapping",
                table: "ProgrameServiceDeliveryAreas");

            migrationBuilder.DropForeignKey(
                name: "FK_ProgrammeSDADetail_Regions_ProgrammeServiceDelivery_ProgrameServiceDeliveryId",
                schema: "mapping",
                table: "ProgrammeSDADetail_Regions");

            migrationBuilder.DropColumn(
                name: "ProgrameServiceDeliverId",
                schema: "mapping",
                table: "ProgrammeSDADetail_Regions");

            migrationBuilder.DropColumn(
                name: "ProgrameServiceDeliverId",
                schema: "mapping",
                table: "ProgrameServiceDeliveryAreas");

            migrationBuilder.AlterColumn<int>(
                name: "ProgrameServiceDeliveryId",
                schema: "mapping",
                table: "ProgrammeSDADetail_Regions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProgrameServiceDeliveryId",
                schema: "mapping",
                table: "ProgrameServiceDeliveryAreas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 17, 2, 31, 21, 583, DateTimeKind.Local).AddTicks(2520));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 17, 2, 31, 21, 583, DateTimeKind.Local).AddTicks(2523));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 17, 2, 31, 21, 583, DateTimeKind.Local).AddTicks(2524));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 17, 2, 31, 21, 583, DateTimeKind.Local).AddTicks(2526));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 17, 2, 31, 21, 583, DateTimeKind.Local).AddTicks(2528));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 17, 2, 31, 21, 583, DateTimeKind.Local).AddTicks(2529));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 17, 2, 31, 21, 583, DateTimeKind.Local).AddTicks(2531));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 17, 2, 31, 21, 583, DateTimeKind.Local).AddTicks(2532));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 17, 2, 31, 21, 583, DateTimeKind.Local).AddTicks(2534));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 17, 2, 31, 21, 583, DateTimeKind.Local).AddTicks(2536));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 17, 2, 31, 21, 583, DateTimeKind.Local).AddTicks(2537));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 17, 2, 31, 21, 583, DateTimeKind.Local).AddTicks(2539));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 17, 2, 31, 21, 583, DateTimeKind.Local).AddTicks(2540));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 17, 2, 31, 21, 583, DateTimeKind.Local).AddTicks(2542));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 17, 2, 31, 21, 583, DateTimeKind.Local).AddTicks(2544));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 17, 2, 31, 21, 583, DateTimeKind.Local).AddTicks(2545));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 17, 2, 31, 21, 583, DateTimeKind.Local).AddTicks(2547));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 17, 2, 31, 21, 583, DateTimeKind.Local).AddTicks(2548));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 17, 2, 31, 21, 583, DateTimeKind.Local).AddTicks(2550));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 17, 2, 31, 21, 583, DateTimeKind.Local).AddTicks(2552));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 17, 2, 31, 21, 583, DateTimeKind.Local).AddTicks(2553));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 17, 2, 31, 21, 583, DateTimeKind.Local).AddTicks(2555));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 17, 2, 31, 21, 583, DateTimeKind.Local).AddTicks(2566));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 17, 2, 31, 21, 583, DateTimeKind.Local).AddTicks(2575));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 17, 2, 31, 21, 583, DateTimeKind.Local).AddTicks(2576));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 17, 2, 31, 21, 583, DateTimeKind.Local).AddTicks(2578));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 17, 2, 31, 21, 583, DateTimeKind.Local).AddTicks(2579));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 17, 2, 31, 21, 583, DateTimeKind.Local).AddTicks(2581));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 17, 2, 31, 21, 583, DateTimeKind.Local).AddTicks(2582));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 17, 2, 31, 21, 583, DateTimeKind.Local).AddTicks(2584));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 17, 2, 31, 21, 583, DateTimeKind.Local).AddTicks(2586));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 17, 2, 31, 21, 583, DateTimeKind.Local).AddTicks(2587));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 17, 2, 31, 21, 583, DateTimeKind.Local).AddTicks(2307));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 17, 2, 31, 21, 583, DateTimeKind.Local).AddTicks(2314));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 17, 2, 31, 21, 583, DateTimeKind.Local).AddTicks(2316));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 17, 2, 31, 21, 583, DateTimeKind.Local).AddTicks(2319));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 17, 2, 31, 21, 583, DateTimeKind.Local).AddTicks(2321));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 17, 2, 31, 21, 583, DateTimeKind.Local).AddTicks(2323));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 17, 2, 31, 21, 583, DateTimeKind.Local).AddTicks(2326));

            migrationBuilder.AddForeignKey(
                name: "FK_ProgrameServiceDeliveryAreas_ProgrammeServiceDelivery_ProgrameServiceDeliveryId",
                schema: "mapping",
                table: "ProgrameServiceDeliveryAreas",
                column: "ProgrameServiceDeliveryId",
                principalSchema: "dbo",
                principalTable: "ProgrammeServiceDelivery",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProgrammeSDADetail_Regions_ProgrammeServiceDelivery_ProgrameServiceDeliveryId",
                schema: "mapping",
                table: "ProgrammeSDADetail_Regions",
                column: "ProgrameServiceDeliveryId",
                principalSchema: "dbo",
                principalTable: "ProgrammeServiceDelivery",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProgrameServiceDeliveryAreas_ProgrammeServiceDelivery_ProgrameServiceDeliveryId",
                schema: "mapping",
                table: "ProgrameServiceDeliveryAreas");

            migrationBuilder.DropForeignKey(
                name: "FK_ProgrammeSDADetail_Regions_ProgrammeServiceDelivery_ProgrameServiceDeliveryId",
                schema: "mapping",
                table: "ProgrammeSDADetail_Regions");

            migrationBuilder.AlterColumn<int>(
                name: "ProgrameServiceDeliveryId",
                schema: "mapping",
                table: "ProgrammeSDADetail_Regions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ProgrameServiceDeliverId",
                schema: "mapping",
                table: "ProgrammeSDADetail_Regions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "ProgrameServiceDeliveryId",
                schema: "mapping",
                table: "ProgrameServiceDeliveryAreas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ProgrameServiceDeliverId",
                schema: "mapping",
                table: "ProgrameServiceDeliveryAreas",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.AddForeignKey(
                name: "FK_ProgrameServiceDeliveryAreas_ProgrammeServiceDelivery_ProgrameServiceDeliveryId",
                schema: "mapping",
                table: "ProgrameServiceDeliveryAreas",
                column: "ProgrameServiceDeliveryId",
                principalSchema: "dbo",
                principalTable: "ProgrammeServiceDelivery",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProgrammeSDADetail_Regions_ProgrammeServiceDelivery_ProgrameServiceDeliveryId",
                schema: "mapping",
                table: "ProgrammeSDADetail_Regions",
                column: "ProgrameServiceDeliveryId",
                principalSchema: "dbo",
                principalTable: "ProgrammeServiceDelivery",
                principalColumn: "Id");
        }
    }
}
