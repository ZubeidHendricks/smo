using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NPOMS.Repository.Migrations
{
    public partial class FinancialMattersSave : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FinancialMattersExpenditure",
                schema: "fa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    npoProfileId = table.Column<int>(type: "int", nullable: true),
                    OthersDescription = table.Column<string>(type: "nvarchar(255)", nullable: true),
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
                    table.PrimaryKey("PK_FinancialMattersOthers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FinancialMattersOthers_FundingApplicationDetails_FundingApplicationDetailId",
                        column: x => x.FundingApplicationDetailId,
                        principalSchema: "fa",
                        principalTable: "FundingApplicationDetails",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 20, 11, 49, 412, DateTimeKind.Local).AddTicks(8001));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 20, 11, 49, 412, DateTimeKind.Local).AddTicks(8003));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 20, 11, 49, 412, DateTimeKind.Local).AddTicks(8004));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 20, 11, 49, 412, DateTimeKind.Local).AddTicks(8005));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 20, 11, 49, 412, DateTimeKind.Local).AddTicks(8007));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 20, 11, 49, 412, DateTimeKind.Local).AddTicks(8009));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 20, 11, 49, 412, DateTimeKind.Local).AddTicks(8010));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 20, 11, 49, 412, DateTimeKind.Local).AddTicks(8011));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 20, 11, 49, 412, DateTimeKind.Local).AddTicks(8012));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 20, 11, 49, 412, DateTimeKind.Local).AddTicks(8013));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 20, 11, 49, 412, DateTimeKind.Local).AddTicks(8014));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 20, 11, 49, 412, DateTimeKind.Local).AddTicks(8015));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 20, 11, 49, 412, DateTimeKind.Local).AddTicks(8016));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 20, 11, 49, 412, DateTimeKind.Local).AddTicks(8017));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 20, 11, 49, 412, DateTimeKind.Local).AddTicks(8019));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 20, 11, 49, 412, DateTimeKind.Local).AddTicks(8020));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 20, 11, 49, 412, DateTimeKind.Local).AddTicks(8021));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 20, 11, 49, 412, DateTimeKind.Local).AddTicks(8023));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 20, 11, 49, 412, DateTimeKind.Local).AddTicks(8024));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 20, 11, 49, 412, DateTimeKind.Local).AddTicks(8025));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 20, 11, 49, 412, DateTimeKind.Local).AddTicks(8033));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 20, 11, 49, 412, DateTimeKind.Local).AddTicks(8034));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 20, 11, 49, 412, DateTimeKind.Local).AddTicks(8039));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 20, 11, 49, 412, DateTimeKind.Local).AddTicks(8061));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 20, 11, 49, 412, DateTimeKind.Local).AddTicks(8062));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 20, 11, 49, 412, DateTimeKind.Local).AddTicks(8063));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 20, 11, 49, 412, DateTimeKind.Local).AddTicks(8064));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 20, 11, 49, 412, DateTimeKind.Local).AddTicks(8065));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 20, 11, 49, 412, DateTimeKind.Local).AddTicks(8066));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 20, 11, 49, 412, DateTimeKind.Local).AddTicks(8067));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 20, 11, 49, 412, DateTimeKind.Local).AddTicks(8068));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 20, 11, 49, 412, DateTimeKind.Local).AddTicks(8069));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 20, 11, 49, 412, DateTimeKind.Local).AddTicks(7897));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 20, 11, 49, 412, DateTimeKind.Local).AddTicks(7916));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 20, 11, 49, 412, DateTimeKind.Local).AddTicks(7918));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 20, 11, 49, 412, DateTimeKind.Local).AddTicks(7919));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 20, 11, 49, 412, DateTimeKind.Local).AddTicks(7921));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 20, 11, 49, 412, DateTimeKind.Local).AddTicks(7922));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 20, 11, 49, 412, DateTimeKind.Local).AddTicks(7924));

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
                name: "FinancialMattersExpenditure",
                schema: "fa");

            migrationBuilder.DropTable(
                name: "FinancialMattersIncome",
                schema: "fa");

            migrationBuilder.DropTable(
                name: "FinancialMattersOthers",
                schema: "fa");

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 9, 56, 39, 735, DateTimeKind.Local).AddTicks(278));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 9, 56, 39, 735, DateTimeKind.Local).AddTicks(281));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 9, 56, 39, 735, DateTimeKind.Local).AddTicks(282));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 9, 56, 39, 735, DateTimeKind.Local).AddTicks(284));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 9, 56, 39, 735, DateTimeKind.Local).AddTicks(285));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 9, 56, 39, 735, DateTimeKind.Local).AddTicks(321));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 9, 56, 39, 735, DateTimeKind.Local).AddTicks(323));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 9, 56, 39, 735, DateTimeKind.Local).AddTicks(324));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 9, 56, 39, 735, DateTimeKind.Local).AddTicks(325));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 9, 56, 39, 735, DateTimeKind.Local).AddTicks(327));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 9, 56, 39, 735, DateTimeKind.Local).AddTicks(328));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 9, 56, 39, 735, DateTimeKind.Local).AddTicks(329));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 9, 56, 39, 735, DateTimeKind.Local).AddTicks(331));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 9, 56, 39, 735, DateTimeKind.Local).AddTicks(332));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 9, 56, 39, 735, DateTimeKind.Local).AddTicks(333));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 9, 56, 39, 735, DateTimeKind.Local).AddTicks(334));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 9, 56, 39, 735, DateTimeKind.Local).AddTicks(336));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 9, 56, 39, 735, DateTimeKind.Local).AddTicks(337));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 9, 56, 39, 735, DateTimeKind.Local).AddTicks(338));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 9, 56, 39, 735, DateTimeKind.Local).AddTicks(339));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 9, 56, 39, 735, DateTimeKind.Local).AddTicks(346));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 9, 56, 39, 735, DateTimeKind.Local).AddTicks(348));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 9, 56, 39, 735, DateTimeKind.Local).AddTicks(353));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 9, 56, 39, 735, DateTimeKind.Local).AddTicks(372));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 9, 56, 39, 735, DateTimeKind.Local).AddTicks(373));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 9, 56, 39, 735, DateTimeKind.Local).AddTicks(374));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 9, 56, 39, 735, DateTimeKind.Local).AddTicks(375));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 9, 56, 39, 735, DateTimeKind.Local).AddTicks(376));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 9, 56, 39, 735, DateTimeKind.Local).AddTicks(377));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 9, 56, 39, 735, DateTimeKind.Local).AddTicks(379));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 9, 56, 39, 735, DateTimeKind.Local).AddTicks(380));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 9, 56, 39, 735, DateTimeKind.Local).AddTicks(381));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 9, 56, 39, 735, DateTimeKind.Local).AddTicks(170));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 9, 56, 39, 735, DateTimeKind.Local).AddTicks(189));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 9, 56, 39, 735, DateTimeKind.Local).AddTicks(191));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 9, 56, 39, 735, DateTimeKind.Local).AddTicks(193));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 9, 56, 39, 735, DateTimeKind.Local).AddTicks(195));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 9, 56, 39, 735, DateTimeKind.Local).AddTicks(196));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2023, 6, 21, 9, 56, 39, 735, DateTimeKind.Local).AddTicks(198));
        }
    }
}
