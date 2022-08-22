using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NPOMS.Repository.Migrations
{
    public partial class AddWorkplanTargets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "indicator");

            migrationBuilder.CreateTable(
                name: "WorkplanTargets",
                schema: "indicator",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActivityId = table.Column<int>(type: "int", nullable: false),
                    FinancialYearId = table.Column<int>(type: "int", nullable: false),
                    FrequencyId = table.Column<int>(type: "int", nullable: false),
                    Annual = table.Column<int>(type: "int", nullable: true),
                    Apr = table.Column<int>(type: "int", nullable: true),
                    May = table.Column<int>(type: "int", nullable: true),
                    Jun = table.Column<int>(type: "int", nullable: true),
                    Jul = table.Column<int>(type: "int", nullable: true),
                    Aug = table.Column<int>(type: "int", nullable: true),
                    Sep = table.Column<int>(type: "int", nullable: true),
                    Oct = table.Column<int>(type: "int", nullable: true),
                    Nov = table.Column<int>(type: "int", nullable: true),
                    Dec = table.Column<int>(type: "int", nullable: true),
                    Jan = table.Column<int>(type: "int", nullable: true),
                    Feb = table.Column<int>(type: "int", nullable: true),
                    Mar = table.Column<int>(type: "int", nullable: true),
                    Quarter1 = table.Column<int>(type: "int", nullable: true),
                    Quarter2 = table.Column<int>(type: "int", nullable: true),
                    Quarter3 = table.Column<int>(type: "int", nullable: true),
                    Quarter4 = table.Column<int>(type: "int", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedUserId = table.Column<int>(type: "int", nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkplanTargets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkplanTargets_FinancialYears_FinancialYearId",
                        column: x => x.FinancialYearId,
                        principalSchema: "core",
                        principalTable: "FinancialYears",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkplanTargets_Frequencies_FrequencyId",
                        column: x => x.FrequencyId,
                        principalSchema: "dropdown",
                        principalTable: "Frequencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkplanTargets_FinancialYearId",
                schema: "indicator",
                table: "WorkplanTargets",
                column: "FinancialYearId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkplanTargets_FrequencyId",
                schema: "indicator",
                table: "WorkplanTargets",
                column: "FrequencyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkplanTargets",
                schema: "indicator");
        }
    }
}
