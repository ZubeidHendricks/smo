using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NPOMS.Repository.Migrations
{
    public partial class UpdateDropdownDistrictCouncil : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                schema: "dropdown",
                table: "LocalMunicipalities",
                type: "bit",
                nullable: false,
                defaultValueSql: "1",
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<int>(
                name: "CreatedUserId",
                schema: "dropdown",
                table: "LocalMunicipalities",
                type: "int",
                nullable: false,
                defaultValueSql: "1",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDateTime",
                schema: "dropdown",
                table: "LocalMunicipalities",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GetDate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                schema: "dropdown",
                table: "DistrictCouncils",
                type: "bit",
                nullable: false,
                defaultValueSql: "1",
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<int>(
                name: "CreatedUserId",
                schema: "dropdown",
                table: "DistrictCouncils",
                type: "int",
                nullable: false,
                defaultValueSql: "1",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDateTime",
                schema: "dropdown",
                table: "DistrictCouncils",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GetDate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.InsertData(
                schema: "dropdown",
                table: "DistrictCouncils",
                columns: new[] { "Id", "Name", "UpdatedDateTime", "UpdatedUserId" },
                values: new object[,]
                {
                    { 1, "Cape Town", null, null },
                    { 2, "West Coast", null, null },
                    { 3, "Cape Winelands", null, null },
                    { 4, "Overberg", null, null },
                    { 5, "Eden", null, null },
                    { 6, "Central Karoo", null, null }
                });

            migrationBuilder.InsertData(
                schema: "dropdown",
                table: "LocalMunicipalities",
                columns: new[] { "Id", "DistrictCouncilId", "Name", "UpdatedDateTime", "UpdatedUserId" },
                values: new object[,]
                {
                    { 1, 1, "Cape Town", null, null },
                    { 2, 2, "Bergrivier", null, null },
                    { 3, 2, "Cederberg", null, null },
                    { 4, 2, "Matzikama", null, null },
                    { 5, 2, "Saldanha Bay", null, null },
                    { 6, 2, "Swartland", null, null },
                    { 7, 3, "Breede", null, null },
                    { 8, 3, "Drakenstein", null, null },
                    { 9, 3, "Langeberg", null, null },
                    { 10, 3, "Stellenbosch", null, null },
                    { 11, 3, "Witzenberg", null, null },
                    { 12, 4, "Cape Agulhas", null, null },
                    { 13, 4, "Overstrand", null, null },
                    { 14, 4, "Swellendam", null, null },
                    { 15, 4, "Theewaterskloof", null, null },
                    { 16, 5, "Bitou", null, null },
                    { 17, 5, "George", null, null },
                    { 18, 5, "Hessequa", null, null },
                    { 19, 5, "Kannaland", null, null },
                    { 20, 5, "Knysna", null, null },
                    { 21, 5, "Mossel Bay", null, null },
                    { 22, 5, "Oudtshoorn", null, null },
                    { 23, 6, "Beaufort West", null, null },
                    { 24, 6, "Laingsburg", null, null },
                    { 25, 6, "Prince Albert", null, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "LocalMunicipalities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "LocalMunicipalities",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "LocalMunicipalities",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "LocalMunicipalities",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "LocalMunicipalities",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "LocalMunicipalities",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "LocalMunicipalities",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "LocalMunicipalities",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "LocalMunicipalities",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "LocalMunicipalities",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "LocalMunicipalities",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "LocalMunicipalities",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "LocalMunicipalities",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "LocalMunicipalities",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "LocalMunicipalities",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "LocalMunicipalities",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "LocalMunicipalities",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "LocalMunicipalities",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "LocalMunicipalities",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "LocalMunicipalities",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "LocalMunicipalities",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "LocalMunicipalities",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "LocalMunicipalities",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "LocalMunicipalities",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "LocalMunicipalities",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "DistrictCouncils",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "DistrictCouncils",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "DistrictCouncils",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "DistrictCouncils",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "DistrictCouncils",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "DistrictCouncils",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                schema: "dropdown",
                table: "LocalMunicipalities",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValueSql: "1");

            migrationBuilder.AlterColumn<int>(
                name: "CreatedUserId",
                schema: "dropdown",
                table: "LocalMunicipalities",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValueSql: "1");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDateTime",
                schema: "dropdown",
                table: "LocalMunicipalities",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GetDate()");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                schema: "dropdown",
                table: "DistrictCouncils",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValueSql: "1");

            migrationBuilder.AlterColumn<int>(
                name: "CreatedUserId",
                schema: "dropdown",
                table: "DistrictCouncils",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValueSql: "1");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDateTime",
                schema: "dropdown",
                table: "DistrictCouncils",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GetDate()");
        }
    }
}
