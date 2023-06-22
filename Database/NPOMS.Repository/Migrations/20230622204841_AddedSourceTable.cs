using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NPOMS.Repository.Migrations
{
    public partial class AddedSourceTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AffiliatedOrganisationInformation",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    npoProfileId = table.Column<int>(type: "int", nullable: true),
                    NameOfOrganisation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactPerson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TelephoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedUserId = table.Column<int>(type: "int", nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AffiliatedOrganisationInformation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FinancialMattersExpenditure",
                schema: "fa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    npoProfileId = table.Column<int>(type: "int", nullable: true),
                    ExpenditureDescription = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    AmountOneE = table.Column<decimal>(type: "numeric(18,6)", nullable: false),
                    AmountTwoE = table.Column<decimal>(type: "numeric(18,6)", nullable: false),
                    AmountThreeE = table.Column<decimal>(type: "numeric(18,6)", nullable: false),
                    TotalFundingAmountE = table.Column<int>(type: "int", nullable: false),
                    FundingApplicationDetailId = table.Column<int>(type: "int", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedUserId = table.Column<int>(type: "int", nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinancialMattersExpenditure", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FinancialMattersExpenditure_FundingApplicationDetails_FundingApplicationDetailId",
                        column: x => x.FundingApplicationDetailId,
                        principalSchema: "fa",
                        principalTable: "FundingApplicationDetails",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FinancialMattersIncome",
                schema: "fa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    npoProfileId = table.Column<int>(type: "int", nullable: true),
                    IncomeDescription = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    AmountOneI = table.Column<decimal>(type: "numeric(18,6)", nullable: false),
                    AmountTwoI = table.Column<decimal>(type: "numeric(18,6)", nullable: false),
                    AmountThreeI = table.Column<decimal>(type: "numeric(18,6)", nullable: false),
                    TotalFundingAmountI = table.Column<int>(type: "int", nullable: false),
                    FundingApplicationDetailId = table.Column<int>(type: "int", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedUserId = table.Column<int>(type: "int", nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinancialMattersIncome", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FinancialMattersIncome_FundingApplicationDetails_FundingApplicationDetailId",
                        column: x => x.FundingApplicationDetailId,
                        principalSchema: "fa",
                        principalTable: "FundingApplicationDetails",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FinancialMattersOthers",
                schema: "fa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    npoProfileId = table.Column<int>(type: "int", nullable: true),
                    OtherDescription = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    AmountOneO = table.Column<decimal>(type: "numeric(18,6)", nullable: false),
                    AmountTwoO = table.Column<decimal>(type: "numeric(18,6)", nullable: false),
                    AmountThreeO = table.Column<decimal>(type: "numeric(18,6)", nullable: false),
                    TotalFundingAmountO = table.Column<int>(type: "int", nullable: false),
                    FundingApplicationDetailId = table.Column<int>(type: "int", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedUserId = table.Column<int>(type: "int", nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinancialMattersOthers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FinancialMattersOthers_FundingApplicationDetails_FundingApplicationDetailId",
                        column: x => x.FundingApplicationDetailId,
                        principalSchema: "fa",
                        principalTable: "FundingApplicationDetails",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PreviousYearFinance",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    npoProfileId = table.Column<int>(type: "int", nullable: true),
                    IncomeDescription = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    IncomeAmount = table.Column<int>(type: "int", nullable: true),
                    ExpenditureDescription = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    ExpenditureAmount = table.Column<int>(type: "int", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedUserId = table.Column<int>(type: "int", nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreviousYearFinance", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SourceOfInformation",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NpoProfileId = table.Column<int>(type: "int", nullable: true),
                    SelectedSourceValue = table.Column<int>(type: "int", nullable: true),
                    AdditionalSourceInformation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedUserId = table.Column<int>(type: "int", nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SourceOfInformation", x => x.Id);
                });

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 22, 22, 48, 33, 207, DateTimeKind.Local).AddTicks(8863));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 22, 22, 48, 33, 207, DateTimeKind.Local).AddTicks(8866));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 22, 22, 48, 33, 207, DateTimeKind.Local).AddTicks(8867));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 22, 22, 48, 33, 207, DateTimeKind.Local).AddTicks(8868));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 22, 22, 48, 33, 207, DateTimeKind.Local).AddTicks(8870));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 22, 22, 48, 33, 207, DateTimeKind.Local).AddTicks(8871));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 22, 22, 48, 33, 207, DateTimeKind.Local).AddTicks(8872));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 22, 22, 48, 33, 207, DateTimeKind.Local).AddTicks(8873));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 22, 22, 48, 33, 207, DateTimeKind.Local).AddTicks(8874));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 22, 22, 48, 33, 207, DateTimeKind.Local).AddTicks(8875));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 22, 22, 48, 33, 207, DateTimeKind.Local).AddTicks(8877));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 22, 22, 48, 33, 207, DateTimeKind.Local).AddTicks(8878));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 22, 22, 48, 33, 207, DateTimeKind.Local).AddTicks(8879));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 22, 22, 48, 33, 207, DateTimeKind.Local).AddTicks(8880));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 22, 22, 48, 33, 207, DateTimeKind.Local).AddTicks(8981));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 22, 22, 48, 33, 207, DateTimeKind.Local).AddTicks(8983));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 22, 22, 48, 33, 207, DateTimeKind.Local).AddTicks(8984));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 22, 22, 48, 33, 207, DateTimeKind.Local).AddTicks(8985));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 22, 22, 48, 33, 207, DateTimeKind.Local).AddTicks(8987));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 22, 22, 48, 33, 207, DateTimeKind.Local).AddTicks(8988));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 22, 22, 48, 33, 207, DateTimeKind.Local).AddTicks(8993));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 22, 22, 48, 33, 207, DateTimeKind.Local).AddTicks(8995));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 22, 22, 48, 33, 207, DateTimeKind.Local).AddTicks(8999));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 22, 22, 48, 33, 207, DateTimeKind.Local).AddTicks(9033));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 22, 22, 48, 33, 207, DateTimeKind.Local).AddTicks(9034));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 22, 22, 48, 33, 207, DateTimeKind.Local).AddTicks(9035));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 22, 22, 48, 33, 207, DateTimeKind.Local).AddTicks(9036));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 22, 22, 48, 33, 207, DateTimeKind.Local).AddTicks(9037));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 22, 22, 48, 33, 207, DateTimeKind.Local).AddTicks(9038));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 22, 22, 48, 33, 207, DateTimeKind.Local).AddTicks(9039));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 22, 22, 48, 33, 207, DateTimeKind.Local).AddTicks(9040));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 22, 22, 48, 33, 207, DateTimeKind.Local).AddTicks(9041));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 22, 22, 48, 33, 207, DateTimeKind.Local).AddTicks(8734));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 22, 22, 48, 33, 207, DateTimeKind.Local).AddTicks(8759));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 22, 22, 48, 33, 207, DateTimeKind.Local).AddTicks(8762));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 22, 22, 48, 33, 207, DateTimeKind.Local).AddTicks(8763));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 22, 22, 48, 33, 207, DateTimeKind.Local).AddTicks(8765));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 22, 22, 48, 33, 207, DateTimeKind.Local).AddTicks(8766));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 22, 22, 48, 33, 207, DateTimeKind.Local).AddTicks(8768));

            migrationBuilder.CreateIndex(
                name: "IX_FinancialMattersExpenditure_FundingApplicationDetailId",
                schema: "fa",
                table: "FinancialMattersExpenditure",
                column: "FundingApplicationDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_FinancialMattersIncome_FundingApplicationDetailId",
                schema: "fa",
                table: "FinancialMattersIncome",
                column: "FundingApplicationDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_FinancialMattersOthers_FundingApplicationDetailId",
                schema: "fa",
                table: "FinancialMattersOthers",
                column: "FundingApplicationDetailId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AffiliatedOrganisationInformation",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "FinancialMattersExpenditure",
                schema: "fa");

            migrationBuilder.DropTable(
                name: "FinancialMattersIncome",
                schema: "fa");

            migrationBuilder.DropTable(
                name: "FinancialMattersOthers",
                schema: "fa");

            migrationBuilder.DropTable(
                name: "PreviousYearFinance",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "SourceOfInformation",
                schema: "dbo");

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 22, 16, 3, 57, 606, DateTimeKind.Local).AddTicks(1868));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 22, 16, 3, 57, 606, DateTimeKind.Local).AddTicks(1870));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 22, 16, 3, 57, 606, DateTimeKind.Local).AddTicks(1871));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 22, 16, 3, 57, 606, DateTimeKind.Local).AddTicks(1872));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 22, 16, 3, 57, 606, DateTimeKind.Local).AddTicks(1874));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 22, 16, 3, 57, 606, DateTimeKind.Local).AddTicks(1875));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 22, 16, 3, 57, 606, DateTimeKind.Local).AddTicks(1876));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 22, 16, 3, 57, 606, DateTimeKind.Local).AddTicks(1877));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 22, 16, 3, 57, 606, DateTimeKind.Local).AddTicks(1879));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 22, 16, 3, 57, 606, DateTimeKind.Local).AddTicks(1880));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 22, 16, 3, 57, 606, DateTimeKind.Local).AddTicks(1881));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 22, 16, 3, 57, 606, DateTimeKind.Local).AddTicks(1882));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 22, 16, 3, 57, 606, DateTimeKind.Local).AddTicks(1884));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 22, 16, 3, 57, 606, DateTimeKind.Local).AddTicks(1885));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 22, 16, 3, 57, 606, DateTimeKind.Local).AddTicks(1886));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 22, 16, 3, 57, 606, DateTimeKind.Local).AddTicks(1888));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 22, 16, 3, 57, 606, DateTimeKind.Local).AddTicks(1889));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 22, 16, 3, 57, 606, DateTimeKind.Local).AddTicks(1890));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 22, 16, 3, 57, 606, DateTimeKind.Local).AddTicks(1891));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 22, 16, 3, 57, 606, DateTimeKind.Local).AddTicks(1892));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 22, 16, 3, 57, 606, DateTimeKind.Local).AddTicks(1894));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 22, 16, 3, 57, 606, DateTimeKind.Local).AddTicks(1895));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 22, 16, 3, 57, 606, DateTimeKind.Local).AddTicks(1902));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 22, 16, 3, 57, 606, DateTimeKind.Local).AddTicks(1914));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 22, 16, 3, 57, 606, DateTimeKind.Local).AddTicks(1916));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 22, 16, 3, 57, 606, DateTimeKind.Local).AddTicks(1917));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 22, 16, 3, 57, 606, DateTimeKind.Local).AddTicks(1918));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 22, 16, 3, 57, 606, DateTimeKind.Local).AddTicks(1919));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 22, 16, 3, 57, 606, DateTimeKind.Local).AddTicks(1921));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 22, 16, 3, 57, 606, DateTimeKind.Local).AddTicks(1922));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 22, 16, 3, 57, 606, DateTimeKind.Local).AddTicks(1923));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 22, 16, 3, 57, 606, DateTimeKind.Local).AddTicks(1924));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 22, 16, 3, 57, 606, DateTimeKind.Local).AddTicks(1745));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 22, 16, 3, 57, 606, DateTimeKind.Local).AddTicks(1762));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 22, 16, 3, 57, 606, DateTimeKind.Local).AddTicks(1764));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 22, 16, 3, 57, 606, DateTimeKind.Local).AddTicks(1766));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 22, 16, 3, 57, 606, DateTimeKind.Local).AddTicks(1767));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 22, 16, 3, 57, 606, DateTimeKind.Local).AddTicks(1769));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 22, 16, 3, 57, 606, DateTimeKind.Local).AddTicks(1770));
        }
    }
}
