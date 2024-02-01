using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NPOMS.Repository.Migrations
{
    public partial class AddNewData_DocumentType_PermissionMatrix_FundingTemplateType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "core",
                table: "DocumentTypes",
                columns: new[] { "Id", "Description", "IsActive", "Location", "Name", "UpdatedDateTime", "UpdatedUserId" },
                values: new object[,]
                {
                    { 22, "Declaration of Interest", true, "FundedNpo", "Declaration of Interest", null, null },
                    { 23, "Declaration of Bidder Interest", true, "FundedNpo", "Declaration of Bidder Interest", null, null },
                    { 24, "Duly Authorized Representative Signature", true, "FundedNpo", "Duly Authorized Representative Signature", null, null },
                    { 25, "Testimonials", true, "FundedNpo", "Testimonials", null, null },
                    { 26, "Others", true, "FundedNpo", "Others", null, null }
                });

            migrationBuilder.InsertData(
                schema: "dropdown",
                table: "FundingTemplateTypes",
                columns: new[] { "Id", "IsActive", "Name", "SystemName", "UpdatedDateTime", "UpdatedUserId" },
                values: new object[] { 3, true, "Business Plan Template", "BusinessPlanTemplate", null, null });

            migrationBuilder.InsertData(
                schema: "core",
                table: "Permissions",
                columns: new[] { "Id", "CategoryName", "Name", "SystemName", "UpdatedDateTime", "UpdatedUserId" },
                values: new object[,]
                {
                    { 115, "InitiateScorecard", "Initiate Score card", "WFA.InitiateScorecard", null, null },
                    { 116, "CloseScorecard", "Close Score card", "WFA.CloseScorecard", null, null }
                });

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 4, 10, 40, 58, 66, DateTimeKind.Local).AddTicks(867));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 4, 10, 40, 58, 66, DateTimeKind.Local).AddTicks(870));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 4, 10, 40, 58, 66, DateTimeKind.Local).AddTicks(872));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 4, 10, 40, 58, 66, DateTimeKind.Local).AddTicks(873));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 4, 10, 40, 58, 66, DateTimeKind.Local).AddTicks(875));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 4, 10, 40, 58, 66, DateTimeKind.Local).AddTicks(876));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 4, 10, 40, 58, 66, DateTimeKind.Local).AddTicks(878));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 4, 10, 40, 58, 66, DateTimeKind.Local).AddTicks(879));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 4, 10, 40, 58, 66, DateTimeKind.Local).AddTicks(880));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 4, 10, 40, 58, 66, DateTimeKind.Local).AddTicks(882));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 4, 10, 40, 58, 66, DateTimeKind.Local).AddTicks(883));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 4, 10, 40, 58, 66, DateTimeKind.Local).AddTicks(885));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 4, 10, 40, 58, 66, DateTimeKind.Local).AddTicks(886));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 4, 10, 40, 58, 66, DateTimeKind.Local).AddTicks(888));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 4, 10, 40, 58, 66, DateTimeKind.Local).AddTicks(889));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 4, 10, 40, 58, 66, DateTimeKind.Local).AddTicks(891));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 4, 10, 40, 58, 66, DateTimeKind.Local).AddTicks(892));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 4, 10, 40, 58, 66, DateTimeKind.Local).AddTicks(893));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 4, 10, 40, 58, 66, DateTimeKind.Local).AddTicks(895));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 4, 10, 40, 58, 66, DateTimeKind.Local).AddTicks(896));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 4, 10, 40, 58, 66, DateTimeKind.Local).AddTicks(898));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 4, 10, 40, 58, 66, DateTimeKind.Local).AddTicks(899));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 4, 10, 40, 58, 66, DateTimeKind.Local).AddTicks(901));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 4, 10, 40, 58, 66, DateTimeKind.Local).AddTicks(902));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 4, 10, 40, 58, 66, DateTimeKind.Local).AddTicks(903));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 4, 10, 40, 58, 66, DateTimeKind.Local).AddTicks(905));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 4, 10, 40, 58, 66, DateTimeKind.Local).AddTicks(906));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 4, 10, 40, 58, 66, DateTimeKind.Local).AddTicks(908));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 4, 10, 40, 58, 66, DateTimeKind.Local).AddTicks(912));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 4, 10, 40, 58, 66, DateTimeKind.Local).AddTicks(914));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 4, 10, 40, 58, 66, DateTimeKind.Local).AddTicks(915));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 4, 10, 40, 58, 66, DateTimeKind.Local).AddTicks(917));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 4, 10, 40, 58, 66, DateTimeKind.Local).AddTicks(723));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 4, 10, 40, 58, 66, DateTimeKind.Local).AddTicks(745));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 4, 10, 40, 58, 66, DateTimeKind.Local).AddTicks(748));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 4, 10, 40, 58, 66, DateTimeKind.Local).AddTicks(749));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 4, 10, 40, 58, 66, DateTimeKind.Local).AddTicks(751));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 4, 10, 40, 58, 66, DateTimeKind.Local).AddTicks(753));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 4, 10, 40, 58, 66, DateTimeKind.Local).AddTicks(755));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "core",
                table: "DocumentTypes",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "DocumentTypes",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "DocumentTypes",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "DocumentTypes",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "DocumentTypes",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "FundingTemplateTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 115);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 116);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 21, 12, 14, 45, 117, DateTimeKind.Local).AddTicks(2995));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 21, 12, 14, 45, 117, DateTimeKind.Local).AddTicks(2998));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 21, 12, 14, 45, 117, DateTimeKind.Local).AddTicks(3000));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 21, 12, 14, 45, 117, DateTimeKind.Local).AddTicks(3002));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 21, 12, 14, 45, 117, DateTimeKind.Local).AddTicks(3003));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 21, 12, 14, 45, 117, DateTimeKind.Local).AddTicks(3005));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 21, 12, 14, 45, 117, DateTimeKind.Local).AddTicks(3007));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 21, 12, 14, 45, 117, DateTimeKind.Local).AddTicks(3008));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 21, 12, 14, 45, 117, DateTimeKind.Local).AddTicks(3010));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 21, 12, 14, 45, 117, DateTimeKind.Local).AddTicks(3011));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 21, 12, 14, 45, 117, DateTimeKind.Local).AddTicks(3013));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 21, 12, 14, 45, 117, DateTimeKind.Local).AddTicks(3014));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 21, 12, 14, 45, 117, DateTimeKind.Local).AddTicks(3016));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 21, 12, 14, 45, 117, DateTimeKind.Local).AddTicks(3017));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 21, 12, 14, 45, 117, DateTimeKind.Local).AddTicks(3019));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 21, 12, 14, 45, 117, DateTimeKind.Local).AddTicks(3020));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 21, 12, 14, 45, 117, DateTimeKind.Local).AddTicks(3022));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 21, 12, 14, 45, 117, DateTimeKind.Local).AddTicks(3024));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 21, 12, 14, 45, 117, DateTimeKind.Local).AddTicks(3025));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 21, 12, 14, 45, 117, DateTimeKind.Local).AddTicks(3027));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 21, 12, 14, 45, 117, DateTimeKind.Local).AddTicks(3028));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 21, 12, 14, 45, 117, DateTimeKind.Local).AddTicks(3030));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 21, 12, 14, 45, 117, DateTimeKind.Local).AddTicks(3039));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 21, 12, 14, 45, 117, DateTimeKind.Local).AddTicks(3056));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 21, 12, 14, 45, 117, DateTimeKind.Local).AddTicks(3058));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 21, 12, 14, 45, 117, DateTimeKind.Local).AddTicks(3059));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 21, 12, 14, 45, 117, DateTimeKind.Local).AddTicks(3061));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 21, 12, 14, 45, 117, DateTimeKind.Local).AddTicks(3062));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 21, 12, 14, 45, 117, DateTimeKind.Local).AddTicks(3069));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 21, 12, 14, 45, 117, DateTimeKind.Local).AddTicks(3073));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 21, 12, 14, 45, 117, DateTimeKind.Local).AddTicks(3074));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 21, 12, 14, 45, 117, DateTimeKind.Local).AddTicks(3076));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 21, 12, 14, 45, 117, DateTimeKind.Local).AddTicks(2826));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 21, 12, 14, 45, 117, DateTimeKind.Local).AddTicks(2851));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 21, 12, 14, 45, 117, DateTimeKind.Local).AddTicks(2854));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 21, 12, 14, 45, 117, DateTimeKind.Local).AddTicks(2856));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 21, 12, 14, 45, 117, DateTimeKind.Local).AddTicks(2858));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 21, 12, 14, 45, 117, DateTimeKind.Local).AddTicks(2860));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 21, 12, 14, 45, 117, DateTimeKind.Local).AddTicks(2862));
        }
    }
}
