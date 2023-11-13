using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NPOMS.Repository.Migrations
{
    public partial class insertnewtemplatescorecard : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "dropdown",
                table: "FundingTemplateTypes",
                columns: new[] { "Id", "IsActive", "Name", "SystemName", "UpdatedDateTime", "UpdatedUserId" },
                values: new object[] { 2, true, "Score Card Template", "ScoreCardTemplate", null, null });

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2023, 10, 16, 20, 32, 35, 260, DateTimeKind.Local).AddTicks(5110));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2023, 10, 16, 20, 32, 35, 260, DateTimeKind.Local).AddTicks(5112));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2023, 10, 16, 20, 32, 35, 260, DateTimeKind.Local).AddTicks(5113));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2023, 10, 16, 20, 32, 35, 260, DateTimeKind.Local).AddTicks(5113));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDateTime",
                value: new DateTime(2023, 10, 16, 20, 32, 35, 260, DateTimeKind.Local).AddTicks(5114));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2023, 10, 16, 20, 32, 35, 260, DateTimeKind.Local).AddTicks(5115));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2023, 10, 16, 20, 32, 35, 260, DateTimeKind.Local).AddTicks(5116));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2023, 10, 16, 20, 32, 35, 260, DateTimeKind.Local).AddTicks(5120));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDateTime",
                value: new DateTime(2023, 10, 16, 20, 32, 35, 260, DateTimeKind.Local).AddTicks(5122));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDateTime",
                value: new DateTime(2023, 10, 16, 20, 32, 35, 260, DateTimeKind.Local).AddTicks(5123));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDateTime",
                value: new DateTime(2023, 10, 16, 20, 32, 35, 260, DateTimeKind.Local).AddTicks(5124));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDateTime",
                value: new DateTime(2023, 10, 16, 20, 32, 35, 260, DateTimeKind.Local).AddTicks(5125));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDateTime",
                value: new DateTime(2023, 10, 16, 20, 32, 35, 260, DateTimeKind.Local).AddTicks(5126));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDateTime",
                value: new DateTime(2023, 10, 16, 20, 32, 35, 260, DateTimeKind.Local).AddTicks(5127));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDateTime",
                value: new DateTime(2023, 10, 16, 20, 32, 35, 260, DateTimeKind.Local).AddTicks(5127));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDateTime",
                value: new DateTime(2023, 10, 16, 20, 32, 35, 260, DateTimeKind.Local).AddTicks(5128));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDateTime",
                value: new DateTime(2023, 10, 16, 20, 32, 35, 260, DateTimeKind.Local).AddTicks(5129));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDateTime",
                value: new DateTime(2023, 10, 16, 20, 32, 35, 260, DateTimeKind.Local).AddTicks(5130));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDateTime",
                value: new DateTime(2023, 10, 16, 20, 32, 35, 260, DateTimeKind.Local).AddTicks(5131));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDateTime",
                value: new DateTime(2023, 10, 16, 20, 32, 35, 260, DateTimeKind.Local).AddTicks(5132));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDateTime",
                value: new DateTime(2023, 10, 16, 20, 32, 35, 260, DateTimeKind.Local).AddTicks(5133));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDateTime",
                value: new DateTime(2023, 10, 16, 20, 32, 35, 260, DateTimeKind.Local).AddTicks(5140));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDateTime",
                value: new DateTime(2023, 10, 16, 20, 32, 35, 260, DateTimeKind.Local).AddTicks(5153));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDateTime",
                value: new DateTime(2023, 10, 16, 20, 32, 35, 260, DateTimeKind.Local).AddTicks(5154));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDateTime",
                value: new DateTime(2023, 10, 16, 20, 32, 35, 260, DateTimeKind.Local).AddTicks(5155));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDateTime",
                value: new DateTime(2023, 10, 16, 20, 32, 35, 260, DateTimeKind.Local).AddTicks(5155));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDateTime",
                value: new DateTime(2023, 10, 16, 20, 32, 35, 260, DateTimeKind.Local).AddTicks(5156));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedDateTime",
                value: new DateTime(2023, 10, 16, 20, 32, 35, 260, DateTimeKind.Local).AddTicks(5157));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedDateTime",
                value: new DateTime(2023, 10, 16, 20, 32, 35, 260, DateTimeKind.Local).AddTicks(5158));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedDateTime",
                value: new DateTime(2023, 10, 16, 20, 32, 35, 260, DateTimeKind.Local).AddTicks(5159));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDateTime",
                value: new DateTime(2023, 10, 16, 20, 32, 35, 260, DateTimeKind.Local).AddTicks(5160));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedDateTime",
                value: new DateTime(2023, 10, 16, 20, 32, 35, 260, DateTimeKind.Local).AddTicks(5160));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2023, 10, 16, 20, 32, 35, 260, DateTimeKind.Local).AddTicks(5045));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2023, 10, 16, 20, 32, 35, 260, DateTimeKind.Local).AddTicks(5062));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2023, 10, 16, 20, 32, 35, 260, DateTimeKind.Local).AddTicks(5064));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2023, 10, 16, 20, 32, 35, 260, DateTimeKind.Local).AddTicks(5065));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2023, 10, 16, 20, 32, 35, 260, DateTimeKind.Local).AddTicks(5066));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2023, 10, 16, 20, 32, 35, 260, DateTimeKind.Local).AddTicks(5067));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2023, 10, 16, 20, 32, 35, 260, DateTimeKind.Local).AddTicks(5069));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "FundingTemplateTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 17, 20, 46, 50, 132, DateTimeKind.Local).AddTicks(2497));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 17, 20, 46, 50, 132, DateTimeKind.Local).AddTicks(2499));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 17, 20, 46, 50, 132, DateTimeKind.Local).AddTicks(2500));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 17, 20, 46, 50, 132, DateTimeKind.Local).AddTicks(2501));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 17, 20, 46, 50, 132, DateTimeKind.Local).AddTicks(2501));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 17, 20, 46, 50, 132, DateTimeKind.Local).AddTicks(2502));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 17, 20, 46, 50, 132, DateTimeKind.Local).AddTicks(2503));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 17, 20, 46, 50, 132, DateTimeKind.Local).AddTicks(2504));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 17, 20, 46, 50, 132, DateTimeKind.Local).AddTicks(2505));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 17, 20, 46, 50, 132, DateTimeKind.Local).AddTicks(2506));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 17, 20, 46, 50, 132, DateTimeKind.Local).AddTicks(2507));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 17, 20, 46, 50, 132, DateTimeKind.Local).AddTicks(2507));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 17, 20, 46, 50, 132, DateTimeKind.Local).AddTicks(2508));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 17, 20, 46, 50, 132, DateTimeKind.Local).AddTicks(2509));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 17, 20, 46, 50, 132, DateTimeKind.Local).AddTicks(2510));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 17, 20, 46, 50, 132, DateTimeKind.Local).AddTicks(2511));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 17, 20, 46, 50, 132, DateTimeKind.Local).AddTicks(2512));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 17, 20, 46, 50, 132, DateTimeKind.Local).AddTicks(2513));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 17, 20, 46, 50, 132, DateTimeKind.Local).AddTicks(2514));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 17, 20, 46, 50, 132, DateTimeKind.Local).AddTicks(2515));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 17, 20, 46, 50, 132, DateTimeKind.Local).AddTicks(2520));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 17, 20, 46, 50, 132, DateTimeKind.Local).AddTicks(2521));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 17, 20, 46, 50, 132, DateTimeKind.Local).AddTicks(2525));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 17, 20, 46, 50, 132, DateTimeKind.Local).AddTicks(2539));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 17, 20, 46, 50, 132, DateTimeKind.Local).AddTicks(2540));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 17, 20, 46, 50, 132, DateTimeKind.Local).AddTicks(2541));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 17, 20, 46, 50, 132, DateTimeKind.Local).AddTicks(2541));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 17, 20, 46, 50, 132, DateTimeKind.Local).AddTicks(2542));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 17, 20, 46, 50, 132, DateTimeKind.Local).AddTicks(2543));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 17, 20, 46, 50, 132, DateTimeKind.Local).AddTicks(2544));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 17, 20, 46, 50, 132, DateTimeKind.Local).AddTicks(2545));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 17, 20, 46, 50, 132, DateTimeKind.Local).AddTicks(2545));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 17, 20, 46, 50, 132, DateTimeKind.Local).AddTicks(2424));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 17, 20, 46, 50, 132, DateTimeKind.Local).AddTicks(2441));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 17, 20, 46, 50, 132, DateTimeKind.Local).AddTicks(2442));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 17, 20, 46, 50, 132, DateTimeKind.Local).AddTicks(2443));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 17, 20, 46, 50, 132, DateTimeKind.Local).AddTicks(2444));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 17, 20, 46, 50, 132, DateTimeKind.Local).AddTicks(2446));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 17, 20, 46, 50, 132, DateTimeKind.Local).AddTicks(2447));
        }
    }
}
