using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NPOMS.Repository.Migrations
{
    public partial class StakeHoldersInfoUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsPrimaryContact",
                schema: "dbo",
                table: "ContactInformation",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<string>(
                name: "AddressInformation",
                schema: "dbo",
                table: "ContactInformation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfEmployment",
                schema: "dbo",
                table: "ContactInformation",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GenderId",
                schema: "dbo",
                table: "ContactInformation",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsBoardMember",
                schema: "dbo",
                table: "ContactInformation",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDisabled",
                schema: "dbo",
                table: "ContactInformation",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsSignatory",
                schema: "dbo",
                table: "ContactInformation",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Qualifications",
                schema: "dbo",
                table: "ContactInformation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RaceId",
                schema: "dbo",
                table: "ContactInformation",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Gender",
                schema: "dropdown",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1"),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
                    UpdatedUserId = table.Column<int>(type: "int", nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gender", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Races",
                schema: "dropdown",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1"),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
                    UpdatedUserId = table.Column<int>(type: "int", nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Races", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "dropdown",
                table: "Gender",
                columns: new[] { "Id", "Name", "UpdatedDateTime", "UpdatedUserId" },
                values: new object[,]
                {
                    { 1, "Female", null, null },
                    { 2, "Male", null, null },
                    { 3, "TransGender", null, null }
                });

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 7, 16, 3, 33, 76, DateTimeKind.Local).AddTicks(8253));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 7, 16, 3, 33, 76, DateTimeKind.Local).AddTicks(8255));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 7, 16, 3, 33, 76, DateTimeKind.Local).AddTicks(8256));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 7, 16, 3, 33, 76, DateTimeKind.Local).AddTicks(8257));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 7, 16, 3, 33, 76, DateTimeKind.Local).AddTicks(8257));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 7, 16, 3, 33, 76, DateTimeKind.Local).AddTicks(8258));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 7, 16, 3, 33, 76, DateTimeKind.Local).AddTicks(8259));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 7, 16, 3, 33, 76, DateTimeKind.Local).AddTicks(8260));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 7, 16, 3, 33, 76, DateTimeKind.Local).AddTicks(8261));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 7, 16, 3, 33, 76, DateTimeKind.Local).AddTicks(8262));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 7, 16, 3, 33, 76, DateTimeKind.Local).AddTicks(8263));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 7, 16, 3, 33, 76, DateTimeKind.Local).AddTicks(8263));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 7, 16, 3, 33, 76, DateTimeKind.Local).AddTicks(8264));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 7, 16, 3, 33, 76, DateTimeKind.Local).AddTicks(8265));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 7, 16, 3, 33, 76, DateTimeKind.Local).AddTicks(8266));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 7, 16, 3, 33, 76, DateTimeKind.Local).AddTicks(8267));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 7, 16, 3, 33, 76, DateTimeKind.Local).AddTicks(8268));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 7, 16, 3, 33, 76, DateTimeKind.Local).AddTicks(8274));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 7, 16, 3, 33, 76, DateTimeKind.Local).AddTicks(8275));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 7, 16, 3, 33, 76, DateTimeKind.Local).AddTicks(8276));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 7, 16, 3, 33, 76, DateTimeKind.Local).AddTicks(8277));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 7, 16, 3, 33, 76, DateTimeKind.Local).AddTicks(8278));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 7, 16, 3, 33, 76, DateTimeKind.Local).AddTicks(8286));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 7, 16, 3, 33, 76, DateTimeKind.Local).AddTicks(8299));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 7, 16, 3, 33, 76, DateTimeKind.Local).AddTicks(8300));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 7, 16, 3, 33, 76, DateTimeKind.Local).AddTicks(8301));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 7, 16, 3, 33, 76, DateTimeKind.Local).AddTicks(8301));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 7, 16, 3, 33, 76, DateTimeKind.Local).AddTicks(8302));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 7, 16, 3, 33, 76, DateTimeKind.Local).AddTicks(8303));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 7, 16, 3, 33, 76, DateTimeKind.Local).AddTicks(8304));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 7, 16, 3, 33, 76, DateTimeKind.Local).AddTicks(8304));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 7, 16, 3, 33, 76, DateTimeKind.Local).AddTicks(8305));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 7, 16, 3, 33, 76, DateTimeKind.Local).AddTicks(8145));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 7, 16, 3, 33, 76, DateTimeKind.Local).AddTicks(8160));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 7, 16, 3, 33, 76, DateTimeKind.Local).AddTicks(8162));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 7, 16, 3, 33, 76, DateTimeKind.Local).AddTicks(8163));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 7, 16, 3, 33, 76, DateTimeKind.Local).AddTicks(8164));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 7, 16, 3, 33, 76, DateTimeKind.Local).AddTicks(8165));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 7, 16, 3, 33, 76, DateTimeKind.Local).AddTicks(8167));

            migrationBuilder.InsertData(
                schema: "dropdown",
                table: "Races",
                columns: new[] { "Id", "Name", "UpdatedDateTime", "UpdatedUserId" },
                values: new object[,]
                {
                    { 1, "Asian", null, null },
                    { 2, "Coloured", null, null },
                    { 3, "White", null, null },
                    { 4, "Ethinic2", null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContactInformation_GenderId",
                schema: "dbo",
                table: "ContactInformation",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactInformation_RaceId",
                schema: "dbo",
                table: "ContactInformation",
                column: "RaceId");

            migrationBuilder.AddForeignKey(
                name: "FK_ContactInformation_Gender_GenderId",
                schema: "dbo",
                table: "ContactInformation",
                column: "GenderId",
                principalSchema: "dropdown",
                principalTable: "Gender",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ContactInformation_Races_RaceId",
                schema: "dbo",
                table: "ContactInformation",
                column: "RaceId",
                principalSchema: "dropdown",
                principalTable: "Races",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContactInformation_Gender_GenderId",
                schema: "dbo",
                table: "ContactInformation");

            migrationBuilder.DropForeignKey(
                name: "FK_ContactInformation_Races_RaceId",
                schema: "dbo",
                table: "ContactInformation");

            migrationBuilder.DropTable(
                name: "Gender",
                schema: "dropdown");

            migrationBuilder.DropTable(
                name: "Races",
                schema: "dropdown");

            migrationBuilder.DropIndex(
                name: "IX_ContactInformation_GenderId",
                schema: "dbo",
                table: "ContactInformation");

            migrationBuilder.DropIndex(
                name: "IX_ContactInformation_RaceId",
                schema: "dbo",
                table: "ContactInformation");

            migrationBuilder.DropColumn(
                name: "AddressInformation",
                schema: "dbo",
                table: "ContactInformation");

            migrationBuilder.DropColumn(
                name: "DateOfEmployment",
                schema: "dbo",
                table: "ContactInformation");

            migrationBuilder.DropColumn(
                name: "GenderId",
                schema: "dbo",
                table: "ContactInformation");

            migrationBuilder.DropColumn(
                name: "IsBoardMember",
                schema: "dbo",
                table: "ContactInformation");

            migrationBuilder.DropColumn(
                name: "IsDisabled",
                schema: "dbo",
                table: "ContactInformation");

            migrationBuilder.DropColumn(
                name: "IsSignatory",
                schema: "dbo",
                table: "ContactInformation");

            migrationBuilder.DropColumn(
                name: "Qualifications",
                schema: "dbo",
                table: "ContactInformation");

            migrationBuilder.DropColumn(
                name: "RaceId",
                schema: "dbo",
                table: "ContactInformation");

            migrationBuilder.AlterColumn<bool>(
                name: "IsPrimaryContact",
                schema: "dbo",
                table: "ContactInformation",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 6, 10, 35, 23, 934, DateTimeKind.Local).AddTicks(9764));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 6, 10, 35, 23, 934, DateTimeKind.Local).AddTicks(9766));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 6, 10, 35, 23, 934, DateTimeKind.Local).AddTicks(9767));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 6, 10, 35, 23, 934, DateTimeKind.Local).AddTicks(9768));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 6, 10, 35, 23, 934, DateTimeKind.Local).AddTicks(9769));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 6, 10, 35, 23, 934, DateTimeKind.Local).AddTicks(9770));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 6, 10, 35, 23, 934, DateTimeKind.Local).AddTicks(9771));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 6, 10, 35, 23, 934, DateTimeKind.Local).AddTicks(9772));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 6, 10, 35, 23, 934, DateTimeKind.Local).AddTicks(9773));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 6, 10, 35, 23, 934, DateTimeKind.Local).AddTicks(9796));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 6, 10, 35, 23, 934, DateTimeKind.Local).AddTicks(9798));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 6, 10, 35, 23, 934, DateTimeKind.Local).AddTicks(9799));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 6, 10, 35, 23, 934, DateTimeKind.Local).AddTicks(9800));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 6, 10, 35, 23, 934, DateTimeKind.Local).AddTicks(9801));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 6, 10, 35, 23, 934, DateTimeKind.Local).AddTicks(9802));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 6, 10, 35, 23, 934, DateTimeKind.Local).AddTicks(9803));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 6, 10, 35, 23, 934, DateTimeKind.Local).AddTicks(9804));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 6, 10, 35, 23, 934, DateTimeKind.Local).AddTicks(9805));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 6, 10, 35, 23, 934, DateTimeKind.Local).AddTicks(9806));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 6, 10, 35, 23, 934, DateTimeKind.Local).AddTicks(9807));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 6, 10, 35, 23, 934, DateTimeKind.Local).AddTicks(9812));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 6, 10, 35, 23, 934, DateTimeKind.Local).AddTicks(9813));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 6, 10, 35, 23, 934, DateTimeKind.Local).AddTicks(9819));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 6, 10, 35, 23, 934, DateTimeKind.Local).AddTicks(9832));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 6, 10, 35, 23, 934, DateTimeKind.Local).AddTicks(9833));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 6, 10, 35, 23, 934, DateTimeKind.Local).AddTicks(9833));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 6, 10, 35, 23, 934, DateTimeKind.Local).AddTicks(9834));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 6, 10, 35, 23, 934, DateTimeKind.Local).AddTicks(9835));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 6, 10, 35, 23, 934, DateTimeKind.Local).AddTicks(9836));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 6, 10, 35, 23, 934, DateTimeKind.Local).AddTicks(9837));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 6, 10, 35, 23, 934, DateTimeKind.Local).AddTicks(9838));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 6, 10, 35, 23, 934, DateTimeKind.Local).AddTicks(9839));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 6, 10, 35, 23, 934, DateTimeKind.Local).AddTicks(9674));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 6, 10, 35, 23, 934, DateTimeKind.Local).AddTicks(9695));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 6, 10, 35, 23, 934, DateTimeKind.Local).AddTicks(9697));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 6, 10, 35, 23, 934, DateTimeKind.Local).AddTicks(9698));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 6, 10, 35, 23, 934, DateTimeKind.Local).AddTicks(9699));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 6, 10, 35, 23, 934, DateTimeKind.Local).AddTicks(9701));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 6, 10, 35, 23, 934, DateTimeKind.Local).AddTicks(9702));
        }
    }
}
