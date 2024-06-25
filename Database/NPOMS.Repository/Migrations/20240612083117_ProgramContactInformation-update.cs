using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NPOMS.Repository.Migrations
{
    /// <inheritdoc />
    public partial class ProgramContactInformationupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfEmployment",
                schema: "dbo",
                table: "ProgramContactInformation",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                schema: "dbo",
                table: "ProgramContactInformation",
                type: "nvarchar(255)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GenderId",
                schema: "dbo",
                table: "ProgramContactInformation",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdNumber",
                schema: "dbo",
                table: "ProgramContactInformation",
                type: "nvarchar(13)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsBoardMember",
                schema: "dbo",
                table: "ProgramContactInformation",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsSignatory",
                schema: "dbo",
                table: "ProgramContactInformation",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsWrittenAgreementSignatory",
                schema: "dbo",
                table: "ProgramContactInformation",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                schema: "dbo",
                table: "ProgramContactInformation",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                schema: "dbo",
                table: "ProgramContactInformation",
                type: "nvarchar(255)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PassportNumber",
                schema: "dbo",
                table: "ProgramContactInformation",
                type: "nvarchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PositionId",
                schema: "dbo",
                table: "ProgramContactInformation",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Qualifications",
                schema: "dbo",
                table: "ProgramContactInformation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "RSAIdNumber",
                schema: "dbo",
                table: "ProgramContactInformation",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "RaceId",
                schema: "dbo",
                table: "ProgramContactInformation",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TitleId",
                schema: "dbo",
                table: "ProgramContactInformation",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "YearsOfExperience",
                schema: "dbo",
                table: "ProgramContactInformation",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 12, 10, 31, 10, 188, DateTimeKind.Local).AddTicks(5178));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 12, 10, 31, 10, 188, DateTimeKind.Local).AddTicks(5180));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 12, 10, 31, 10, 188, DateTimeKind.Local).AddTicks(5182));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 12, 10, 31, 10, 188, DateTimeKind.Local).AddTicks(5183));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 12, 10, 31, 10, 188, DateTimeKind.Local).AddTicks(5184));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 12, 10, 31, 10, 188, DateTimeKind.Local).AddTicks(5186));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 12, 10, 31, 10, 188, DateTimeKind.Local).AddTicks(5187));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 12, 10, 31, 10, 188, DateTimeKind.Local).AddTicks(5188));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 12, 10, 31, 10, 188, DateTimeKind.Local).AddTicks(5190));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 12, 10, 31, 10, 188, DateTimeKind.Local).AddTicks(5191));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 12, 10, 31, 10, 188, DateTimeKind.Local).AddTicks(5192));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 12, 10, 31, 10, 188, DateTimeKind.Local).AddTicks(5194));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 12, 10, 31, 10, 188, DateTimeKind.Local).AddTicks(5196));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 12, 10, 31, 10, 188, DateTimeKind.Local).AddTicks(5197));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 12, 10, 31, 10, 188, DateTimeKind.Local).AddTicks(5198));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 12, 10, 31, 10, 188, DateTimeKind.Local).AddTicks(5200));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 12, 10, 31, 10, 188, DateTimeKind.Local).AddTicks(5201));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 12, 10, 31, 10, 188, DateTimeKind.Local).AddTicks(5203));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 12, 10, 31, 10, 188, DateTimeKind.Local).AddTicks(5204));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 12, 10, 31, 10, 188, DateTimeKind.Local).AddTicks(5205));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 12, 10, 31, 10, 188, DateTimeKind.Local).AddTicks(5206));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 12, 10, 31, 10, 188, DateTimeKind.Local).AddTicks(5208));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 12, 10, 31, 10, 188, DateTimeKind.Local).AddTicks(5213));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 12, 10, 31, 10, 188, DateTimeKind.Local).AddTicks(5225));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 12, 10, 31, 10, 188, DateTimeKind.Local).AddTicks(5227));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 12, 10, 31, 10, 188, DateTimeKind.Local).AddTicks(5228));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 12, 10, 31, 10, 188, DateTimeKind.Local).AddTicks(5229));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 12, 10, 31, 10, 188, DateTimeKind.Local).AddTicks(5231));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 12, 10, 31, 10, 188, DateTimeKind.Local).AddTicks(5253));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 12, 10, 31, 10, 188, DateTimeKind.Local).AddTicks(5254));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 12, 10, 31, 10, 188, DateTimeKind.Local).AddTicks(5255));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 12, 10, 31, 10, 188, DateTimeKind.Local).AddTicks(5257));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 12, 10, 31, 10, 188, DateTimeKind.Local).AddTicks(5056));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 12, 10, 31, 10, 188, DateTimeKind.Local).AddTicks(5064));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 12, 10, 31, 10, 188, DateTimeKind.Local).AddTicks(5066));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 12, 10, 31, 10, 188, DateTimeKind.Local).AddTicks(5068));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 12, 10, 31, 10, 188, DateTimeKind.Local).AddTicks(5070));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 12, 10, 31, 10, 188, DateTimeKind.Local).AddTicks(5072));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 12, 10, 31, 10, 188, DateTimeKind.Local).AddTicks(5074));

            migrationBuilder.CreateIndex(
                name: "IX_ProgramContactInformation_GenderId",
                schema: "dbo",
                table: "ProgramContactInformation",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramContactInformation_LanguageId",
                schema: "dbo",
                table: "ProgramContactInformation",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramContactInformation_PositionId",
                schema: "dbo",
                table: "ProgramContactInformation",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramContactInformation_RaceId",
                schema: "dbo",
                table: "ProgramContactInformation",
                column: "RaceId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramContactInformation_TitleId",
                schema: "dbo",
                table: "ProgramContactInformation",
                column: "TitleId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProgramContactInformation_Gender_GenderId",
                schema: "dbo",
                table: "ProgramContactInformation",
                column: "GenderId",
                principalSchema: "dropdown",
                principalTable: "Gender",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProgramContactInformation_Languages_LanguageId",
                schema: "dbo",
                table: "ProgramContactInformation",
                column: "LanguageId",
                principalSchema: "dropdown",
                principalTable: "Languages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProgramContactInformation_Positions_PositionId",
                schema: "dbo",
                table: "ProgramContactInformation",
                column: "PositionId",
                principalSchema: "dropdown",
                principalTable: "Positions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProgramContactInformation_Races_RaceId",
                schema: "dbo",
                table: "ProgramContactInformation",
                column: "RaceId",
                principalSchema: "dropdown",
                principalTable: "Races",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProgramContactInformation_Titles_TitleId",
                schema: "dbo",
                table: "ProgramContactInformation",
                column: "TitleId",
                principalSchema: "dropdown",
                principalTable: "Titles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProgramContactInformation_Gender_GenderId",
                schema: "dbo",
                table: "ProgramContactInformation");

            migrationBuilder.DropForeignKey(
                name: "FK_ProgramContactInformation_Languages_LanguageId",
                schema: "dbo",
                table: "ProgramContactInformation");

            migrationBuilder.DropForeignKey(
                name: "FK_ProgramContactInformation_Positions_PositionId",
                schema: "dbo",
                table: "ProgramContactInformation");

            migrationBuilder.DropForeignKey(
                name: "FK_ProgramContactInformation_Races_RaceId",
                schema: "dbo",
                table: "ProgramContactInformation");

            migrationBuilder.DropForeignKey(
                name: "FK_ProgramContactInformation_Titles_TitleId",
                schema: "dbo",
                table: "ProgramContactInformation");

            migrationBuilder.DropIndex(
                name: "IX_ProgramContactInformation_GenderId",
                schema: "dbo",
                table: "ProgramContactInformation");

            migrationBuilder.DropIndex(
                name: "IX_ProgramContactInformation_LanguageId",
                schema: "dbo",
                table: "ProgramContactInformation");

            migrationBuilder.DropIndex(
                name: "IX_ProgramContactInformation_PositionId",
                schema: "dbo",
                table: "ProgramContactInformation");

            migrationBuilder.DropIndex(
                name: "IX_ProgramContactInformation_RaceId",
                schema: "dbo",
                table: "ProgramContactInformation");

            migrationBuilder.DropIndex(
                name: "IX_ProgramContactInformation_TitleId",
                schema: "dbo",
                table: "ProgramContactInformation");

            migrationBuilder.DropColumn(
                name: "DateOfEmployment",
                schema: "dbo",
                table: "ProgramContactInformation");

            migrationBuilder.DropColumn(
                name: "FirstName",
                schema: "dbo",
                table: "ProgramContactInformation");

            migrationBuilder.DropColumn(
                name: "GenderId",
                schema: "dbo",
                table: "ProgramContactInformation");

            migrationBuilder.DropColumn(
                name: "IdNumber",
                schema: "dbo",
                table: "ProgramContactInformation");

            migrationBuilder.DropColumn(
                name: "IsBoardMember",
                schema: "dbo",
                table: "ProgramContactInformation");

            migrationBuilder.DropColumn(
                name: "IsSignatory",
                schema: "dbo",
                table: "ProgramContactInformation");

            migrationBuilder.DropColumn(
                name: "IsWrittenAgreementSignatory",
                schema: "dbo",
                table: "ProgramContactInformation");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                schema: "dbo",
                table: "ProgramContactInformation");

            migrationBuilder.DropColumn(
                name: "LastName",
                schema: "dbo",
                table: "ProgramContactInformation");

            migrationBuilder.DropColumn(
                name: "PassportNumber",
                schema: "dbo",
                table: "ProgramContactInformation");

            migrationBuilder.DropColumn(
                name: "PositionId",
                schema: "dbo",
                table: "ProgramContactInformation");

            migrationBuilder.DropColumn(
                name: "Qualifications",
                schema: "dbo",
                table: "ProgramContactInformation");

            migrationBuilder.DropColumn(
                name: "RSAIdNumber",
                schema: "dbo",
                table: "ProgramContactInformation");

            migrationBuilder.DropColumn(
                name: "RaceId",
                schema: "dbo",
                table: "ProgramContactInformation");

            migrationBuilder.DropColumn(
                name: "TitleId",
                schema: "dbo",
                table: "ProgramContactInformation");

            migrationBuilder.DropColumn(
                name: "YearsOfExperience",
                schema: "dbo",
                table: "ProgramContactInformation");

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 10, 20, 35, 57, 715, DateTimeKind.Local).AddTicks(5582));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 10, 20, 35, 57, 715, DateTimeKind.Local).AddTicks(5584));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 10, 20, 35, 57, 715, DateTimeKind.Local).AddTicks(5586));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 10, 20, 35, 57, 715, DateTimeKind.Local).AddTicks(5588));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 10, 20, 35, 57, 715, DateTimeKind.Local).AddTicks(5589));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 10, 20, 35, 57, 715, DateTimeKind.Local).AddTicks(5591));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 10, 20, 35, 57, 715, DateTimeKind.Local).AddTicks(5593));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 10, 20, 35, 57, 715, DateTimeKind.Local).AddTicks(5594));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 10, 20, 35, 57, 715, DateTimeKind.Local).AddTicks(5596));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 10, 20, 35, 57, 715, DateTimeKind.Local).AddTicks(5597));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 10, 20, 35, 57, 715, DateTimeKind.Local).AddTicks(5599));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 10, 20, 35, 57, 715, DateTimeKind.Local).AddTicks(5607));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 10, 20, 35, 57, 715, DateTimeKind.Local).AddTicks(5609));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 10, 20, 35, 57, 715, DateTimeKind.Local).AddTicks(5610));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 10, 20, 35, 57, 715, DateTimeKind.Local).AddTicks(5612));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 10, 20, 35, 57, 715, DateTimeKind.Local).AddTicks(5613));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 10, 20, 35, 57, 715, DateTimeKind.Local).AddTicks(5615));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 10, 20, 35, 57, 715, DateTimeKind.Local).AddTicks(5616));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 10, 20, 35, 57, 715, DateTimeKind.Local).AddTicks(5618));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 10, 20, 35, 57, 715, DateTimeKind.Local).AddTicks(5619));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 10, 20, 35, 57, 715, DateTimeKind.Local).AddTicks(5633));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 10, 20, 35, 57, 715, DateTimeKind.Local).AddTicks(5635));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 10, 20, 35, 57, 715, DateTimeKind.Local).AddTicks(5644));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 10, 20, 35, 57, 715, DateTimeKind.Local).AddTicks(5656));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 10, 20, 35, 57, 715, DateTimeKind.Local).AddTicks(5658));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 10, 20, 35, 57, 715, DateTimeKind.Local).AddTicks(5659));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 10, 20, 35, 57, 715, DateTimeKind.Local).AddTicks(5661));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 10, 20, 35, 57, 715, DateTimeKind.Local).AddTicks(5662));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 10, 20, 35, 57, 715, DateTimeKind.Local).AddTicks(5664));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 10, 20, 35, 57, 715, DateTimeKind.Local).AddTicks(5665));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 10, 20, 35, 57, 715, DateTimeKind.Local).AddTicks(5667));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 10, 20, 35, 57, 715, DateTimeKind.Local).AddTicks(5668));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 10, 20, 35, 57, 715, DateTimeKind.Local).AddTicks(5438));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 10, 20, 35, 57, 715, DateTimeKind.Local).AddTicks(5459));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 10, 20, 35, 57, 715, DateTimeKind.Local).AddTicks(5461));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 10, 20, 35, 57, 715, DateTimeKind.Local).AddTicks(5463));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 10, 20, 35, 57, 715, DateTimeKind.Local).AddTicks(5466));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 10, 20, 35, 57, 715, DateTimeKind.Local).AddTicks(5468));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 10, 20, 35, 57, 715, DateTimeKind.Local).AddTicks(5470));
        }
    }
}
