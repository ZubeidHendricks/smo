using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NPOMS.Repository.Migrations
{
    public partial class AddDataInQuarterlyPeriodTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                schema: "core",
                table: "QuarterlyPeriod",
                type: "bit",
                nullable: false,
                defaultValueSql: "1",
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<int>(
                name: "CreatedUserId",
                schema: "core",
                table: "QuarterlyPeriod",
                type: "int",
                nullable: false,
                defaultValueSql: "1",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDateTime",
                schema: "core",
                table: "QuarterlyPeriod",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GetDate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

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

            migrationBuilder.InsertData(
                schema: "core",
                table: "QuarterlyPeriod",
                columns: new[] { "Id", "Abbreviation", "Name", "UpdatedDateTime", "UpdatedUserId" },
                values: new object[,]
                {
                    { 1, "Q1", "Quarter1", null, null },
                    { 2, "Q2", "Quarter2", null, null },
                    { 3, "Q3", "Quarter3", null, null }
                });

            migrationBuilder.InsertData(
                schema: "core",
                table: "QuarterlyPeriod",
                columns: new[] { "Id", "Abbreviation", "Name", "UpdatedDateTime", "UpdatedUserId" },
                values: new object[] { 4, "Q4", "Quarter4", null, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "core",
                table: "QuarterlyPeriod",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "QuarterlyPeriod",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "QuarterlyPeriod",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "QuarterlyPeriod",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                schema: "core",
                table: "QuarterlyPeriod",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValueSql: "1");

            migrationBuilder.AlterColumn<int>(
                name: "CreatedUserId",
                schema: "core",
                table: "QuarterlyPeriod",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValueSql: "1");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDateTime",
                schema: "core",
                table: "QuarterlyPeriod",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GetDate()");

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 21, 12, 7, 5, 686, DateTimeKind.Local).AddTicks(7815));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 21, 12, 7, 5, 686, DateTimeKind.Local).AddTicks(7817));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 21, 12, 7, 5, 686, DateTimeKind.Local).AddTicks(7818));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 21, 12, 7, 5, 686, DateTimeKind.Local).AddTicks(7820));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 21, 12, 7, 5, 686, DateTimeKind.Local).AddTicks(7821));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 21, 12, 7, 5, 686, DateTimeKind.Local).AddTicks(7822));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 21, 12, 7, 5, 686, DateTimeKind.Local).AddTicks(7823));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 21, 12, 7, 5, 686, DateTimeKind.Local).AddTicks(7824));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 21, 12, 7, 5, 686, DateTimeKind.Local).AddTicks(7825));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 21, 12, 7, 5, 686, DateTimeKind.Local).AddTicks(7827));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 21, 12, 7, 5, 686, DateTimeKind.Local).AddTicks(7828));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 21, 12, 7, 5, 686, DateTimeKind.Local).AddTicks(7829));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 21, 12, 7, 5, 686, DateTimeKind.Local).AddTicks(7830));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 21, 12, 7, 5, 686, DateTimeKind.Local).AddTicks(7831));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 21, 12, 7, 5, 686, DateTimeKind.Local).AddTicks(7832));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 21, 12, 7, 5, 686, DateTimeKind.Local).AddTicks(7834));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 21, 12, 7, 5, 686, DateTimeKind.Local).AddTicks(7835));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 21, 12, 7, 5, 686, DateTimeKind.Local).AddTicks(7836));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 21, 12, 7, 5, 686, DateTimeKind.Local).AddTicks(7837));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 21, 12, 7, 5, 686, DateTimeKind.Local).AddTicks(7838));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 21, 12, 7, 5, 686, DateTimeKind.Local).AddTicks(7839));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 21, 12, 7, 5, 686, DateTimeKind.Local).AddTicks(7840));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 21, 12, 7, 5, 686, DateTimeKind.Local).AddTicks(7848));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 21, 12, 7, 5, 686, DateTimeKind.Local).AddTicks(7864));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 21, 12, 7, 5, 686, DateTimeKind.Local).AddTicks(7866));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 21, 12, 7, 5, 686, DateTimeKind.Local).AddTicks(7867));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 21, 12, 7, 5, 686, DateTimeKind.Local).AddTicks(7868));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 21, 12, 7, 5, 686, DateTimeKind.Local).AddTicks(7869));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 21, 12, 7, 5, 686, DateTimeKind.Local).AddTicks(7870));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 21, 12, 7, 5, 686, DateTimeKind.Local).AddTicks(7871));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 21, 12, 7, 5, 686, DateTimeKind.Local).AddTicks(7872));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 21, 12, 7, 5, 686, DateTimeKind.Local).AddTicks(7873));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 21, 12, 7, 5, 686, DateTimeKind.Local).AddTicks(7719));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 21, 12, 7, 5, 686, DateTimeKind.Local).AddTicks(7740));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 21, 12, 7, 5, 686, DateTimeKind.Local).AddTicks(7742));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 21, 12, 7, 5, 686, DateTimeKind.Local).AddTicks(7744));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 21, 12, 7, 5, 686, DateTimeKind.Local).AddTicks(7746));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 21, 12, 7, 5, 686, DateTimeKind.Local).AddTicks(7747));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2023, 12, 21, 12, 7, 5, 686, DateTimeKind.Local).AddTicks(7749));
        }
    }
}
