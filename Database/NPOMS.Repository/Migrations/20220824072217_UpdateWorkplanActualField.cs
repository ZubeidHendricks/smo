using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NPOMS.Repository.Migrations
{
    public partial class UpdateWorkplanActualField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Reason",
                schema: "indicator",
                table: "WorkplanActuals",
                newName: "Action");

            migrationBuilder.CreateIndex(
                name: "IX_WorkplanActuals_FrequencyPeriodId",
                schema: "indicator",
                table: "WorkplanActuals",
                column: "FrequencyPeriodId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkplanActuals_FrequencyPeriods_FrequencyPeriodId",
                schema: "indicator",
                table: "WorkplanActuals",
                column: "FrequencyPeriodId",
                principalSchema: "dropdown",
                principalTable: "FrequencyPeriods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkplanActuals_FrequencyPeriods_FrequencyPeriodId",
                schema: "indicator",
                table: "WorkplanActuals");

            migrationBuilder.DropIndex(
                name: "IX_WorkplanActuals_FrequencyPeriodId",
                schema: "indicator",
                table: "WorkplanActuals");

            migrationBuilder.RenameColumn(
                name: "Action",
                schema: "indicator",
                table: "WorkplanActuals",
                newName: "Reason");
        }
    }
}
