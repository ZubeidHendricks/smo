using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NPOMS.Repository.Migrations
{
    /// <inheritdoc />
    public partial class MunicipalityIdupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActivityManicipality_Activities_ActivityId",
                table: "ActivityManicipality");

            migrationBuilder.DropIndex(
                name: "IX_ActivityDistricts_ActivityId",
                schema: "core",
                table: "ActivityDistricts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ActivityManicipality",
                table: "ActivityManicipality");

            migrationBuilder.DropColumn(
                name: "SubStructureid",
                table: "ActivityManicipality");

            migrationBuilder.RenameTable(
                name: "ActivityManicipality",
                newName: "ActivityManicipalities");

            migrationBuilder.RenameIndex(
                name: "IX_ActivityManicipality_ActivityId",
                table: "ActivityManicipalities",
                newName: "IX_ActivityManicipalities_ActivityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ActivityManicipalities",
                table: "ActivityManicipalities",
                column: "Id");

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 23, 2, 2, 45, 79, DateTimeKind.Local).AddTicks(152));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 23, 2, 2, 45, 79, DateTimeKind.Local).AddTicks(169));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 23, 2, 2, 45, 79, DateTimeKind.Local).AddTicks(171));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 23, 2, 2, 45, 79, DateTimeKind.Local).AddTicks(173));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 23, 2, 2, 45, 79, DateTimeKind.Local).AddTicks(175));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 23, 2, 2, 45, 79, DateTimeKind.Local).AddTicks(177));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 23, 2, 2, 45, 79, DateTimeKind.Local).AddTicks(178));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 23, 2, 2, 45, 79, DateTimeKind.Local).AddTicks(180));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 23, 2, 2, 45, 79, DateTimeKind.Local).AddTicks(181));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 23, 2, 2, 45, 79, DateTimeKind.Local).AddTicks(224));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 23, 2, 2, 45, 79, DateTimeKind.Local).AddTicks(225));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 23, 2, 2, 45, 79, DateTimeKind.Local).AddTicks(227));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 23, 2, 2, 45, 79, DateTimeKind.Local).AddTicks(229));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 23, 2, 2, 45, 79, DateTimeKind.Local).AddTicks(230));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 23, 2, 2, 45, 79, DateTimeKind.Local).AddTicks(232));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 23, 2, 2, 45, 79, DateTimeKind.Local).AddTicks(234));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 23, 2, 2, 45, 79, DateTimeKind.Local).AddTicks(235));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 23, 2, 2, 45, 79, DateTimeKind.Local).AddTicks(237));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 23, 2, 2, 45, 79, DateTimeKind.Local).AddTicks(239));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 23, 2, 2, 45, 79, DateTimeKind.Local).AddTicks(240));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 23, 2, 2, 45, 79, DateTimeKind.Local).AddTicks(242));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 23, 2, 2, 45, 79, DateTimeKind.Local).AddTicks(244));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 23, 2, 2, 45, 79, DateTimeKind.Local).AddTicks(245));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 23, 2, 2, 45, 79, DateTimeKind.Local).AddTicks(247));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 23, 2, 2, 45, 79, DateTimeKind.Local).AddTicks(249));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 23, 2, 2, 45, 79, DateTimeKind.Local).AddTicks(250));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 23, 2, 2, 45, 79, DateTimeKind.Local).AddTicks(252));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 23, 2, 2, 45, 79, DateTimeKind.Local).AddTicks(262));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 23, 2, 2, 45, 79, DateTimeKind.Local).AddTicks(264));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 23, 2, 2, 45, 79, DateTimeKind.Local).AddTicks(272));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 23, 2, 2, 45, 79, DateTimeKind.Local).AddTicks(285));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 23, 2, 2, 45, 79, DateTimeKind.Local).AddTicks(287));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 23, 2, 2, 45, 79, DateTimeKind.Local).AddTicks(880));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 23, 2, 2, 45, 79, DateTimeKind.Local).AddTicks(883));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 23, 2, 2, 45, 79, DateTimeKind.Local).AddTicks(885));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 23, 2, 2, 45, 79, DateTimeKind.Local).AddTicks(888));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 23, 2, 2, 45, 79, DateTimeKind.Local).AddTicks(890));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 23, 2, 2, 45, 79, DateTimeKind.Local).AddTicks(892));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 23, 2, 2, 45, 79, DateTimeKind.Local).AddTicks(894));

            migrationBuilder.CreateIndex(
                name: "IX_ActivityDistricts_ActivityId",
                schema: "core",
                table: "ActivityDistricts",
                column: "ActivityId");

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityManicipalities_Activities_ActivityId",
                table: "ActivityManicipalities",
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
                name: "FK_ActivityManicipalities_Activities_ActivityId",
                table: "ActivityManicipalities");

            migrationBuilder.DropIndex(
                name: "IX_ActivityDistricts_ActivityId",
                schema: "core",
                table: "ActivityDistricts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ActivityManicipalities",
                table: "ActivityManicipalities");

            migrationBuilder.RenameTable(
                name: "ActivityManicipalities",
                newName: "ActivityManicipality");

            migrationBuilder.RenameIndex(
                name: "IX_ActivityManicipalities_ActivityId",
                table: "ActivityManicipality",
                newName: "IX_ActivityManicipality_ActivityId");

            migrationBuilder.AddColumn<int>(
                name: "SubStructureid",
                table: "ActivityManicipality",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ActivityManicipality",
                table: "ActivityManicipality",
                column: "Id");

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 22, 22, 13, 36, 480, DateTimeKind.Local).AddTicks(569));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 22, 22, 13, 36, 480, DateTimeKind.Local).AddTicks(590));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 22, 22, 13, 36, 480, DateTimeKind.Local).AddTicks(592));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 22, 22, 13, 36, 480, DateTimeKind.Local).AddTicks(594));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 22, 22, 13, 36, 480, DateTimeKind.Local).AddTicks(596));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 22, 22, 13, 36, 480, DateTimeKind.Local).AddTicks(597));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 22, 22, 13, 36, 480, DateTimeKind.Local).AddTicks(600));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 22, 22, 13, 36, 480, DateTimeKind.Local).AddTicks(601));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 22, 22, 13, 36, 480, DateTimeKind.Local).AddTicks(603));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 22, 22, 13, 36, 480, DateTimeKind.Local).AddTicks(604));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 22, 22, 13, 36, 480, DateTimeKind.Local).AddTicks(606));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 22, 22, 13, 36, 480, DateTimeKind.Local).AddTicks(607));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 22, 22, 13, 36, 480, DateTimeKind.Local).AddTicks(609));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 22, 22, 13, 36, 480, DateTimeKind.Local).AddTicks(611));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 22, 22, 13, 36, 480, DateTimeKind.Local).AddTicks(612));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 22, 22, 13, 36, 480, DateTimeKind.Local).AddTicks(614));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 22, 22, 13, 36, 480, DateTimeKind.Local).AddTicks(615));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 22, 22, 13, 36, 480, DateTimeKind.Local).AddTicks(617));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 22, 22, 13, 36, 480, DateTimeKind.Local).AddTicks(618));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 22, 22, 13, 36, 480, DateTimeKind.Local).AddTicks(620));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 22, 22, 13, 36, 480, DateTimeKind.Local).AddTicks(621));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 22, 22, 13, 36, 480, DateTimeKind.Local).AddTicks(623));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 22, 22, 13, 36, 480, DateTimeKind.Local).AddTicks(624));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 22, 22, 13, 36, 480, DateTimeKind.Local).AddTicks(626));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 22, 22, 13, 36, 480, DateTimeKind.Local).AddTicks(627));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 22, 22, 13, 36, 480, DateTimeKind.Local).AddTicks(629));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 22, 22, 13, 36, 480, DateTimeKind.Local).AddTicks(630));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 22, 22, 13, 36, 480, DateTimeKind.Local).AddTicks(639));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 22, 22, 13, 36, 480, DateTimeKind.Local).AddTicks(640));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 22, 22, 13, 36, 480, DateTimeKind.Local).AddTicks(647));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 22, 22, 13, 36, 480, DateTimeKind.Local).AddTicks(656));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 22, 22, 13, 36, 480, DateTimeKind.Local).AddTicks(657));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 22, 22, 13, 36, 480, DateTimeKind.Local).AddTicks(1245));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 22, 22, 13, 36, 480, DateTimeKind.Local).AddTicks(1249));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 22, 22, 13, 36, 480, DateTimeKind.Local).AddTicks(1252));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 22, 22, 13, 36, 480, DateTimeKind.Local).AddTicks(1254));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 22, 22, 13, 36, 480, DateTimeKind.Local).AddTicks(1256));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 22, 22, 13, 36, 480, DateTimeKind.Local).AddTicks(1258));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 22, 22, 13, 36, 480, DateTimeKind.Local).AddTicks(1261));

            migrationBuilder.CreateIndex(
                name: "IX_ActivityDistricts_ActivityId",
                schema: "core",
                table: "ActivityDistricts",
                column: "ActivityId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityManicipality_Activities_ActivityId",
                table: "ActivityManicipality",
                column: "ActivityId",
                principalSchema: "dbo",
                principalTable: "Activities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
