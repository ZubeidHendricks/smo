using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NPOMS.Repository.Migrations
{
    /// <inheritdoc />
    public partial class NewDemographics_Activity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActivitySubDistricts_ActivityDistricts_ActivityDistrictId",
                schema: "mapping",
                table: "ActivitySubDistricts");

            migrationBuilder.DropForeignKey(
                name: "FK_ActivitySubStructures_ActivityDistricts_ActivityDistrictId",
                table: "ActivitySubStructures");

            migrationBuilder.DropIndex(
                name: "IX_ActivitySubStructures_ActivityDistrictId",
                table: "ActivitySubStructures");

            migrationBuilder.DropIndex(
                name: "IX_ActivitySubDistricts_ActivityDistrictId",
                schema: "mapping",
                table: "ActivitySubDistricts");

            migrationBuilder.DropColumn(
                name: "ActivityDistrictId",
                schema: "mapping",
                table: "ActivitySubDistricts");

            migrationBuilder.RenameColumn(
                name: "ActivityDistrictId",
                table: "ActivitySubStructures",
                newName: "MunicipalityId");

            migrationBuilder.RenameColumn(
                name: "subDistrictid",
                schema: "mapping",
                table: "ActivitySubDistricts",
                newName: "SubstructureId");

            migrationBuilder.RenameColumn(
                name: "FacilityDistrictId",
                schema: "mapping",
                table: "ActivitySubDistricts",
                newName: "ActivityId");

            migrationBuilder.RenameColumn(
                name: "FacilityDistrictId",
                schema: "core",
                table: "ActivityDistricts",
                newName: "DemographicDistrictId");

            migrationBuilder.AddColumn<int>(
                name: "ActivityId",
                table: "ActivitySubStructures",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ActivityManicipality",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DemographicDistrictId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubStructureid = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ActivityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityManicipality", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActivityManicipality_Activities_ActivityId",
                        column: x => x.ActivityId,
                        principalSchema: "dbo",
                        principalTable: "Activities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 22, 21, 58, 55, 62, DateTimeKind.Local).AddTicks(5851));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 22, 21, 58, 55, 62, DateTimeKind.Local).AddTicks(5868));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 22, 21, 58, 55, 62, DateTimeKind.Local).AddTicks(5870));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 22, 21, 58, 55, 62, DateTimeKind.Local).AddTicks(5871));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 22, 21, 58, 55, 62, DateTimeKind.Local).AddTicks(5873));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 22, 21, 58, 55, 62, DateTimeKind.Local).AddTicks(5874));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 22, 21, 58, 55, 62, DateTimeKind.Local).AddTicks(5876));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 22, 21, 58, 55, 62, DateTimeKind.Local).AddTicks(5878));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 22, 21, 58, 55, 62, DateTimeKind.Local).AddTicks(5879));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 22, 21, 58, 55, 62, DateTimeKind.Local).AddTicks(5881));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 22, 21, 58, 55, 62, DateTimeKind.Local).AddTicks(5882));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 22, 21, 58, 55, 62, DateTimeKind.Local).AddTicks(5884));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 22, 21, 58, 55, 62, DateTimeKind.Local).AddTicks(5885));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 22, 21, 58, 55, 62, DateTimeKind.Local).AddTicks(5887));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 22, 21, 58, 55, 62, DateTimeKind.Local).AddTicks(5889));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 22, 21, 58, 55, 62, DateTimeKind.Local).AddTicks(5890));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 22, 21, 58, 55, 62, DateTimeKind.Local).AddTicks(5892));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 22, 21, 58, 55, 62, DateTimeKind.Local).AddTicks(5893));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 22, 21, 58, 55, 62, DateTimeKind.Local).AddTicks(5895));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 22, 21, 58, 55, 62, DateTimeKind.Local).AddTicks(5896));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 22, 21, 58, 55, 62, DateTimeKind.Local).AddTicks(5898));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 22, 21, 58, 55, 62, DateTimeKind.Local).AddTicks(5900));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 22, 21, 58, 55, 62, DateTimeKind.Local).AddTicks(5901));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 22, 21, 58, 55, 62, DateTimeKind.Local).AddTicks(5903));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 22, 21, 58, 55, 62, DateTimeKind.Local).AddTicks(5904));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 22, 21, 58, 55, 62, DateTimeKind.Local).AddTicks(5906));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 22, 21, 58, 55, 62, DateTimeKind.Local).AddTicks(5907));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 22, 21, 58, 55, 62, DateTimeKind.Local).AddTicks(5913));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 22, 21, 58, 55, 62, DateTimeKind.Local).AddTicks(5915));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 22, 21, 58, 55, 62, DateTimeKind.Local).AddTicks(5922));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 22, 21, 58, 55, 62, DateTimeKind.Local).AddTicks(5931));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 22, 21, 58, 55, 62, DateTimeKind.Local).AddTicks(5933));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 22, 21, 58, 55, 62, DateTimeKind.Local).AddTicks(6502));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 22, 21, 58, 55, 62, DateTimeKind.Local).AddTicks(6506));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 22, 21, 58, 55, 62, DateTimeKind.Local).AddTicks(6508));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 22, 21, 58, 55, 62, DateTimeKind.Local).AddTicks(6510));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 22, 21, 58, 55, 62, DateTimeKind.Local).AddTicks(6512));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 22, 21, 58, 55, 62, DateTimeKind.Local).AddTicks(6514));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 22, 21, 58, 55, 62, DateTimeKind.Local).AddTicks(6517));

            migrationBuilder.CreateIndex(
                name: "IX_ActivitySubStructures_ActivityId",
                table: "ActivitySubStructures",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivitySubDistricts_ActivityId",
                schema: "mapping",
                table: "ActivitySubDistricts",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityManicipality_ActivityId",
                table: "ActivityManicipality",
                column: "ActivityId");

            migrationBuilder.AddForeignKey(
                name: "FK_ActivitySubDistricts_Activities_ActivityId",
                schema: "mapping",
                table: "ActivitySubDistricts",
                column: "ActivityId",
                principalSchema: "dbo",
                principalTable: "Activities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ActivitySubStructures_Activities_ActivityId",
                table: "ActivitySubStructures",
                column: "ActivityId",
                principalSchema: "dbo",
                principalTable: "Activities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActivitySubDistricts_Activities_ActivityId",
                schema: "mapping",
                table: "ActivitySubDistricts");

            migrationBuilder.DropForeignKey(
                name: "FK_ActivitySubStructures_Activities_ActivityId",
                table: "ActivitySubStructures");

            migrationBuilder.DropTable(
                name: "ActivityManicipality");

            migrationBuilder.DropIndex(
                name: "IX_ActivitySubStructures_ActivityId",
                table: "ActivitySubStructures");

            migrationBuilder.DropIndex(
                name: "IX_ActivitySubDistricts_ActivityId",
                schema: "mapping",
                table: "ActivitySubDistricts");

            migrationBuilder.DropColumn(
                name: "ActivityId",
                table: "ActivitySubStructures");

            migrationBuilder.RenameColumn(
                name: "MunicipalityId",
                table: "ActivitySubStructures",
                newName: "ActivityDistrictId");

            migrationBuilder.RenameColumn(
                name: "SubstructureId",
                schema: "mapping",
                table: "ActivitySubDistricts",
                newName: "subDistrictid");

            migrationBuilder.RenameColumn(
                name: "ActivityId",
                schema: "mapping",
                table: "ActivitySubDistricts",
                newName: "FacilityDistrictId");

            migrationBuilder.RenameColumn(
                name: "DemographicDistrictId",
                schema: "core",
                table: "ActivityDistricts",
                newName: "FacilityDistrictId");

            migrationBuilder.AddColumn<int>(
                name: "ActivityDistrictId",
                schema: "mapping",
                table: "ActivitySubDistricts",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.CreateIndex(
                name: "IX_ActivitySubStructures_ActivityDistrictId",
                table: "ActivitySubStructures",
                column: "ActivityDistrictId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ActivitySubDistricts_ActivityDistrictId",
                schema: "mapping",
                table: "ActivitySubDistricts",
                column: "ActivityDistrictId");

            migrationBuilder.AddForeignKey(
                name: "FK_ActivitySubDistricts_ActivityDistricts_ActivityDistrictId",
                schema: "mapping",
                table: "ActivitySubDistricts",
                column: "ActivityDistrictId",
                principalSchema: "core",
                principalTable: "ActivityDistricts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ActivitySubStructures_ActivityDistricts_ActivityDistrictId",
                table: "ActivitySubStructures",
                column: "ActivityDistrictId",
                principalSchema: "core",
                principalTable: "ActivityDistricts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
