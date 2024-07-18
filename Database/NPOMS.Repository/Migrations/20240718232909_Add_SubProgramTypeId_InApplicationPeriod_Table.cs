using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NPOMS.Repository.Migrations
{
    /// <inheritdoc />
    public partial class Add_SubProgramTypeId_InApplicationPeriod_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SubProgrammeTypeId",
                schema: "dbo",
                table: "ApplicationPeriods",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 19, 1, 29, 0, 839, DateTimeKind.Local).AddTicks(8899));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 19, 1, 29, 0, 839, DateTimeKind.Local).AddTicks(8923));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 19, 1, 29, 0, 839, DateTimeKind.Local).AddTicks(8925));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 19, 1, 29, 0, 839, DateTimeKind.Local).AddTicks(8927));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 19, 1, 29, 0, 839, DateTimeKind.Local).AddTicks(8928));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 19, 1, 29, 0, 839, DateTimeKind.Local).AddTicks(8930));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 19, 1, 29, 0, 839, DateTimeKind.Local).AddTicks(8932));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 19, 1, 29, 0, 839, DateTimeKind.Local).AddTicks(8933));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 19, 1, 29, 0, 839, DateTimeKind.Local).AddTicks(8935));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 19, 1, 29, 0, 839, DateTimeKind.Local).AddTicks(8936));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 19, 1, 29, 0, 839, DateTimeKind.Local).AddTicks(8939));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 19, 1, 29, 0, 839, DateTimeKind.Local).AddTicks(8940));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 19, 1, 29, 0, 839, DateTimeKind.Local).AddTicks(8942));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 19, 1, 29, 0, 839, DateTimeKind.Local).AddTicks(8943));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 19, 1, 29, 0, 839, DateTimeKind.Local).AddTicks(8945));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 19, 1, 29, 0, 839, DateTimeKind.Local).AddTicks(8946));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 19, 1, 29, 0, 839, DateTimeKind.Local).AddTicks(8948));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 19, 1, 29, 0, 839, DateTimeKind.Local).AddTicks(8949));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 19, 1, 29, 0, 839, DateTimeKind.Local).AddTicks(8951));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 19, 1, 29, 0, 839, DateTimeKind.Local).AddTicks(8952));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 19, 1, 29, 0, 839, DateTimeKind.Local).AddTicks(8954));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 19, 1, 29, 0, 839, DateTimeKind.Local).AddTicks(8955));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 19, 1, 29, 0, 839, DateTimeKind.Local).AddTicks(8957));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 19, 1, 29, 0, 839, DateTimeKind.Local).AddTicks(8958));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 19, 1, 29, 0, 839, DateTimeKind.Local).AddTicks(8960));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 19, 1, 29, 0, 839, DateTimeKind.Local).AddTicks(8961));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 19, 1, 29, 0, 839, DateTimeKind.Local).AddTicks(8963));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 19, 1, 29, 0, 839, DateTimeKind.Local).AddTicks(8975));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 19, 1, 29, 0, 839, DateTimeKind.Local).AddTicks(8977));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 19, 1, 29, 0, 839, DateTimeKind.Local).AddTicks(8989));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 19, 1, 29, 0, 839, DateTimeKind.Local).AddTicks(9002));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 19, 1, 29, 0, 839, DateTimeKind.Local).AddTicks(9003));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 19, 1, 29, 0, 839, DateTimeKind.Local).AddTicks(9696));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 19, 1, 29, 0, 839, DateTimeKind.Local).AddTicks(9701));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 19, 1, 29, 0, 839, DateTimeKind.Local).AddTicks(9703));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 19, 1, 29, 0, 839, DateTimeKind.Local).AddTicks(9706));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 19, 1, 29, 0, 839, DateTimeKind.Local).AddTicks(9708));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 19, 1, 29, 0, 839, DateTimeKind.Local).AddTicks(9710));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 19, 1, 29, 0, 839, DateTimeKind.Local).AddTicks(9712));

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationPeriods_SubProgrammeTypeId",
                schema: "dbo",
                table: "ApplicationPeriods",
                column: "SubProgrammeTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationPeriods_SubProgrammeTypes_SubProgrammeTypeId",
                schema: "dbo",
                table: "ApplicationPeriods",
                column: "SubProgrammeTypeId",
                principalSchema: "dropdown",
                principalTable: "SubProgrammeTypes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationPeriods_SubProgrammeTypes_SubProgrammeTypeId",
                schema: "dbo",
                table: "ApplicationPeriods");

            migrationBuilder.DropIndex(
                name: "IX_ApplicationPeriods_SubProgrammeTypeId",
                schema: "dbo",
                table: "ApplicationPeriods");

            migrationBuilder.DropColumn(
                name: "SubProgrammeTypeId",
                schema: "dbo",
                table: "ApplicationPeriods");

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 14, 12, 31, 4, 777, DateTimeKind.Local).AddTicks(6760));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 14, 12, 31, 4, 777, DateTimeKind.Local).AddTicks(6800));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 14, 12, 31, 4, 777, DateTimeKind.Local).AddTicks(6802));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 14, 12, 31, 4, 777, DateTimeKind.Local).AddTicks(6803));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 14, 12, 31, 4, 777, DateTimeKind.Local).AddTicks(6805));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 14, 12, 31, 4, 777, DateTimeKind.Local).AddTicks(6806));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 14, 12, 31, 4, 777, DateTimeKind.Local).AddTicks(6808));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 14, 12, 31, 4, 777, DateTimeKind.Local).AddTicks(6809));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 14, 12, 31, 4, 777, DateTimeKind.Local).AddTicks(6848));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 14, 12, 31, 4, 777, DateTimeKind.Local).AddTicks(6849));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 14, 12, 31, 4, 777, DateTimeKind.Local).AddTicks(6851));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 14, 12, 31, 4, 777, DateTimeKind.Local).AddTicks(6853));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 14, 12, 31, 4, 777, DateTimeKind.Local).AddTicks(6854));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 14, 12, 31, 4, 777, DateTimeKind.Local).AddTicks(6856));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 14, 12, 31, 4, 777, DateTimeKind.Local).AddTicks(6857));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 14, 12, 31, 4, 777, DateTimeKind.Local).AddTicks(6859));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 14, 12, 31, 4, 777, DateTimeKind.Local).AddTicks(6860));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 14, 12, 31, 4, 777, DateTimeKind.Local).AddTicks(6862));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 14, 12, 31, 4, 777, DateTimeKind.Local).AddTicks(6863));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 14, 12, 31, 4, 777, DateTimeKind.Local).AddTicks(6865));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 14, 12, 31, 4, 777, DateTimeKind.Local).AddTicks(6866));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 14, 12, 31, 4, 777, DateTimeKind.Local).AddTicks(6880));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 14, 12, 31, 4, 777, DateTimeKind.Local).AddTicks(6882));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 14, 12, 31, 4, 777, DateTimeKind.Local).AddTicks(6883));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 14, 12, 31, 4, 777, DateTimeKind.Local).AddTicks(6885));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 14, 12, 31, 4, 777, DateTimeKind.Local).AddTicks(6886));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 14, 12, 31, 4, 777, DateTimeKind.Local).AddTicks(6888));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 14, 12, 31, 4, 777, DateTimeKind.Local).AddTicks(6889));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 14, 12, 31, 4, 777, DateTimeKind.Local).AddTicks(6891));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 14, 12, 31, 4, 777, DateTimeKind.Local).AddTicks(6896));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 14, 12, 31, 4, 777, DateTimeKind.Local).AddTicks(6921));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 14, 12, 31, 4, 777, DateTimeKind.Local).AddTicks(6923));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 14, 12, 31, 4, 777, DateTimeKind.Local).AddTicks(7701));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 14, 12, 31, 4, 777, DateTimeKind.Local).AddTicks(7706));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 14, 12, 31, 4, 777, DateTimeKind.Local).AddTicks(7709));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 14, 12, 31, 4, 777, DateTimeKind.Local).AddTicks(7712));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 14, 12, 31, 4, 777, DateTimeKind.Local).AddTicks(7714));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 14, 12, 31, 4, 777, DateTimeKind.Local).AddTicks(7716));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 14, 12, 31, 4, 777, DateTimeKind.Local).AddTicks(7718));
        }
    }
}
