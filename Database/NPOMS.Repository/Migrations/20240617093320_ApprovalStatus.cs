using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NPOMS.Repository.Migrations
{
    /// <inheritdoc />
    public partial class ApprovalStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ApprovalStatusId",
                schema: "dbo",
                table: "ProgrammeServiceDelivery",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ApprovalStatusId",
                schema: "dbo",
                table: "ProgramContactInformation",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ApprovalStatusId",
                schema: "dbo",
                table: "ProgramBankDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 17, 11, 33, 10, 407, DateTimeKind.Local).AddTicks(2014));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 17, 11, 33, 10, 407, DateTimeKind.Local).AddTicks(2017));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 17, 11, 33, 10, 407, DateTimeKind.Local).AddTicks(2018));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 17, 11, 33, 10, 407, DateTimeKind.Local).AddTicks(2020));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 17, 11, 33, 10, 407, DateTimeKind.Local).AddTicks(2021));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 17, 11, 33, 10, 407, DateTimeKind.Local).AddTicks(2023));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 17, 11, 33, 10, 407, DateTimeKind.Local).AddTicks(2024));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 17, 11, 33, 10, 407, DateTimeKind.Local).AddTicks(2026));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 17, 11, 33, 10, 407, DateTimeKind.Local).AddTicks(2027));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 17, 11, 33, 10, 407, DateTimeKind.Local).AddTicks(2029));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 17, 11, 33, 10, 407, DateTimeKind.Local).AddTicks(2030));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 17, 11, 33, 10, 407, DateTimeKind.Local).AddTicks(2032));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 17, 11, 33, 10, 407, DateTimeKind.Local).AddTicks(2033));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 17, 11, 33, 10, 407, DateTimeKind.Local).AddTicks(2035));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 17, 11, 33, 10, 407, DateTimeKind.Local).AddTicks(2036));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 17, 11, 33, 10, 407, DateTimeKind.Local).AddTicks(2038));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 17, 11, 33, 10, 407, DateTimeKind.Local).AddTicks(2039));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 17, 11, 33, 10, 407, DateTimeKind.Local).AddTicks(2040));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 17, 11, 33, 10, 407, DateTimeKind.Local).AddTicks(2042));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 17, 11, 33, 10, 407, DateTimeKind.Local).AddTicks(2043));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 17, 11, 33, 10, 407, DateTimeKind.Local).AddTicks(2045));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 17, 11, 33, 10, 407, DateTimeKind.Local).AddTicks(2046));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 17, 11, 33, 10, 407, DateTimeKind.Local).AddTicks(2053));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 17, 11, 33, 10, 407, DateTimeKind.Local).AddTicks(2060));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 17, 11, 33, 10, 407, DateTimeKind.Local).AddTicks(2061));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 17, 11, 33, 10, 407, DateTimeKind.Local).AddTicks(2063));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 17, 11, 33, 10, 407, DateTimeKind.Local).AddTicks(2064));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 17, 11, 33, 10, 407, DateTimeKind.Local).AddTicks(2066));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 17, 11, 33, 10, 407, DateTimeKind.Local).AddTicks(2068));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 17, 11, 33, 10, 407, DateTimeKind.Local).AddTicks(2069));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 17, 11, 33, 10, 407, DateTimeKind.Local).AddTicks(2071));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 17, 11, 33, 10, 407, DateTimeKind.Local).AddTicks(2072));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 17, 11, 33, 10, 407, DateTimeKind.Local).AddTicks(1877));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 17, 11, 33, 10, 407, DateTimeKind.Local).AddTicks(1883));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 17, 11, 33, 10, 407, DateTimeKind.Local).AddTicks(1885));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 17, 11, 33, 10, 407, DateTimeKind.Local).AddTicks(1888));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 17, 11, 33, 10, 407, DateTimeKind.Local).AddTicks(1890));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 17, 11, 33, 10, 407, DateTimeKind.Local).AddTicks(1892));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 17, 11, 33, 10, 407, DateTimeKind.Local).AddTicks(1894));

            migrationBuilder.CreateIndex(
                name: "IX_ProgrammeServiceDelivery_ApprovalStatusId",
                schema: "dbo",
                table: "ProgrammeServiceDelivery",
                column: "ApprovalStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramContactInformation_ApprovalStatusId",
                schema: "dbo",
                table: "ProgramContactInformation",
                column: "ApprovalStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramBankDetails_ApprovalStatusId",
                schema: "dbo",
                table: "ProgramBankDetails",
                column: "ApprovalStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProgramBankDetails_AccessStatuses_ApprovalStatusId",
                schema: "dbo",
                table: "ProgramBankDetails",
                column: "ApprovalStatusId",
                principalSchema: "dbo",
                principalTable: "AccessStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProgramContactInformation_AccessStatuses_ApprovalStatusId",
                schema: "dbo",
                table: "ProgramContactInformation",
                column: "ApprovalStatusId",
                principalSchema: "dbo",
                principalTable: "AccessStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProgrammeServiceDelivery_AccessStatuses_ApprovalStatusId",
                schema: "dbo",
                table: "ProgrammeServiceDelivery",
                column: "ApprovalStatusId",
                principalSchema: "dbo",
                principalTable: "AccessStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProgramBankDetails_AccessStatuses_ApprovalStatusId",
                schema: "dbo",
                table: "ProgramBankDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_ProgramContactInformation_AccessStatuses_ApprovalStatusId",
                schema: "dbo",
                table: "ProgramContactInformation");

            migrationBuilder.DropForeignKey(
                name: "FK_ProgrammeServiceDelivery_AccessStatuses_ApprovalStatusId",
                schema: "dbo",
                table: "ProgrammeServiceDelivery");

            migrationBuilder.DropIndex(
                name: "IX_ProgrammeServiceDelivery_ApprovalStatusId",
                schema: "dbo",
                table: "ProgrammeServiceDelivery");

            migrationBuilder.DropIndex(
                name: "IX_ProgramContactInformation_ApprovalStatusId",
                schema: "dbo",
                table: "ProgramContactInformation");

            migrationBuilder.DropIndex(
                name: "IX_ProgramBankDetails_ApprovalStatusId",
                schema: "dbo",
                table: "ProgramBankDetails");

            migrationBuilder.DropColumn(
                name: "ApprovalStatusId",
                schema: "dbo",
                table: "ProgrammeServiceDelivery");

            migrationBuilder.DropColumn(
                name: "ApprovalStatusId",
                schema: "dbo",
                table: "ProgramContactInformation");

            migrationBuilder.DropColumn(
                name: "ApprovalStatusId",
                schema: "dbo",
                table: "ProgramBankDetails");

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
        }
    }
}
