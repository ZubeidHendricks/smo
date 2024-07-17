using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NPOMS.Repository.Migrations
{
    /// <inheritdoc />
    public partial class ActivityUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActivityDistricts_FacilityDistricts_FacilityDistrictId",
                schema: "core",
                table: "ActivityDistricts");

            migrationBuilder.DropIndex(
                name: "IX_ActivitySubStructures_ActivityDistrictId",
                table: "ActivitySubStructures");

            migrationBuilder.DropIndex(
                name: "IX_ActivityDistricts_ActivityId",
                schema: "core",
                table: "ActivityDistricts");

            migrationBuilder.DropIndex(
                name: "IX_ActivityDistricts_FacilityDistrictId",
                schema: "core",
                table: "ActivityDistricts");

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 17, 22, 40, 45, 410, DateTimeKind.Local).AddTicks(3050));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 17, 22, 40, 45, 410, DateTimeKind.Local).AddTicks(3074));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 17, 22, 40, 45, 410, DateTimeKind.Local).AddTicks(3077));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 17, 22, 40, 45, 410, DateTimeKind.Local).AddTicks(3079));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 17, 22, 40, 45, 410, DateTimeKind.Local).AddTicks(3081));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 17, 22, 40, 45, 410, DateTimeKind.Local).AddTicks(3083));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 17, 22, 40, 45, 410, DateTimeKind.Local).AddTicks(3086));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 17, 22, 40, 45, 410, DateTimeKind.Local).AddTicks(3088));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 17, 22, 40, 45, 410, DateTimeKind.Local).AddTicks(3090));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 17, 22, 40, 45, 410, DateTimeKind.Local).AddTicks(3092));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 17, 22, 40, 45, 410, DateTimeKind.Local).AddTicks(3094));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 17, 22, 40, 45, 410, DateTimeKind.Local).AddTicks(3096));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 17, 22, 40, 45, 410, DateTimeKind.Local).AddTicks(3098));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 17, 22, 40, 45, 410, DateTimeKind.Local).AddTicks(3100));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 17, 22, 40, 45, 410, DateTimeKind.Local).AddTicks(3102));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 17, 22, 40, 45, 410, DateTimeKind.Local).AddTicks(3104));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 17, 22, 40, 45, 410, DateTimeKind.Local).AddTicks(3105));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 17, 22, 40, 45, 410, DateTimeKind.Local).AddTicks(3108));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 17, 22, 40, 45, 410, DateTimeKind.Local).AddTicks(3109));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 17, 22, 40, 45, 410, DateTimeKind.Local).AddTicks(3111));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 17, 22, 40, 45, 410, DateTimeKind.Local).AddTicks(3113));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 17, 22, 40, 45, 410, DateTimeKind.Local).AddTicks(3115));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 17, 22, 40, 45, 410, DateTimeKind.Local).AddTicks(3117));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 17, 22, 40, 45, 410, DateTimeKind.Local).AddTicks(3119));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 17, 22, 40, 45, 410, DateTimeKind.Local).AddTicks(3121));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 17, 22, 40, 45, 410, DateTimeKind.Local).AddTicks(3123));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 17, 22, 40, 45, 410, DateTimeKind.Local).AddTicks(3159));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 17, 22, 40, 45, 410, DateTimeKind.Local).AddTicks(3169));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 17, 22, 40, 45, 410, DateTimeKind.Local).AddTicks(3171));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 17, 22, 40, 45, 410, DateTimeKind.Local).AddTicks(3183));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 17, 22, 40, 45, 410, DateTimeKind.Local).AddTicks(3200));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 17, 22, 40, 45, 410, DateTimeKind.Local).AddTicks(3202));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 17, 22, 40, 45, 410, DateTimeKind.Local).AddTicks(4034));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 17, 22, 40, 45, 410, DateTimeKind.Local).AddTicks(4039));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 17, 22, 40, 45, 410, DateTimeKind.Local).AddTicks(4042));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 17, 22, 40, 45, 410, DateTimeKind.Local).AddTicks(4045));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 17, 22, 40, 45, 410, DateTimeKind.Local).AddTicks(4048));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 17, 22, 40, 45, 410, DateTimeKind.Local).AddTicks(4050));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 17, 22, 40, 45, 410, DateTimeKind.Local).AddTicks(4053));

            migrationBuilder.CreateIndex(
                name: "IX_ActivitySubStructures_ActivityDistrictId",
                table: "ActivitySubStructures",
                column: "ActivityDistrictId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ActivityDistricts_ActivityId",
                schema: "core",
                table: "ActivityDistricts",
                column: "ActivityId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ActivitySubStructures_ActivityDistrictId",
                table: "ActivitySubStructures");

            migrationBuilder.DropIndex(
                name: "IX_ActivityDistricts_ActivityId",
                schema: "core",
                table: "ActivityDistricts");

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 17, 14, 6, 59, 828, DateTimeKind.Local).AddTicks(9779));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 17, 14, 6, 59, 828, DateTimeKind.Local).AddTicks(9810));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 17, 14, 6, 59, 828, DateTimeKind.Local).AddTicks(9814));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 17, 14, 6, 59, 828, DateTimeKind.Local).AddTicks(9818));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 17, 14, 6, 59, 828, DateTimeKind.Local).AddTicks(9821));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 17, 14, 6, 59, 828, DateTimeKind.Local).AddTicks(9826));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 17, 14, 6, 59, 828, DateTimeKind.Local).AddTicks(9829));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 17, 14, 6, 59, 828, DateTimeKind.Local).AddTicks(9832));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 17, 14, 6, 59, 828, DateTimeKind.Local).AddTicks(9835));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 17, 14, 6, 59, 828, DateTimeKind.Local).AddTicks(9838));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 17, 14, 6, 59, 828, DateTimeKind.Local).AddTicks(9841));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 17, 14, 6, 59, 828, DateTimeKind.Local).AddTicks(9844));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 17, 14, 6, 59, 828, DateTimeKind.Local).AddTicks(9847));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 17, 14, 6, 59, 828, DateTimeKind.Local).AddTicks(9850));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 17, 14, 6, 59, 828, DateTimeKind.Local).AddTicks(9853));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 17, 14, 6, 59, 828, DateTimeKind.Local).AddTicks(9856));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 17, 14, 6, 59, 828, DateTimeKind.Local).AddTicks(9859));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 17, 14, 6, 59, 828, DateTimeKind.Local).AddTicks(9862));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 17, 14, 6, 59, 828, DateTimeKind.Local).AddTicks(9865));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 17, 14, 6, 59, 828, DateTimeKind.Local).AddTicks(9868));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 17, 14, 6, 59, 828, DateTimeKind.Local).AddTicks(9871));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 17, 14, 6, 59, 828, DateTimeKind.Local).AddTicks(9893));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 17, 14, 6, 59, 828, DateTimeKind.Local).AddTicks(9896));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 17, 14, 6, 59, 828, DateTimeKind.Local).AddTicks(9899));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 17, 14, 6, 59, 828, DateTimeKind.Local).AddTicks(9902));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 17, 14, 6, 59, 828, DateTimeKind.Local).AddTicks(9905));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 17, 14, 6, 59, 828, DateTimeKind.Local).AddTicks(9908));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 17, 14, 6, 59, 828, DateTimeKind.Local).AddTicks(9912));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 17, 14, 6, 59, 828, DateTimeKind.Local).AddTicks(9915));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 17, 14, 6, 59, 828, DateTimeKind.Local).AddTicks(9927));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 17, 14, 6, 59, 828, DateTimeKind.Local).AddTicks(9954));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 17, 14, 6, 59, 828, DateTimeKind.Local).AddTicks(9958));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 17, 14, 6, 59, 829, DateTimeKind.Local).AddTicks(3251));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 17, 14, 6, 59, 829, DateTimeKind.Local).AddTicks(3271));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 17, 14, 6, 59, 829, DateTimeKind.Local).AddTicks(3275));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 17, 14, 6, 59, 829, DateTimeKind.Local).AddTicks(3279));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 17, 14, 6, 59, 829, DateTimeKind.Local).AddTicks(3283));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 17, 14, 6, 59, 829, DateTimeKind.Local).AddTicks(3287));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 17, 14, 6, 59, 829, DateTimeKind.Local).AddTicks(3290));

            migrationBuilder.CreateIndex(
                name: "IX_ActivitySubStructures_ActivityDistrictId",
                table: "ActivitySubStructures",
                column: "ActivityDistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityDistricts_ActivityId",
                schema: "core",
                table: "ActivityDistricts",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityDistricts_FacilityDistrictId",
                schema: "core",
                table: "ActivityDistricts",
                column: "FacilityDistrictId");

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityDistricts_FacilityDistricts_FacilityDistrictId",
                schema: "core",
                table: "ActivityDistricts",
                column: "FacilityDistrictId",
                principalSchema: "dropdown",
                principalTable: "FacilityDistricts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
