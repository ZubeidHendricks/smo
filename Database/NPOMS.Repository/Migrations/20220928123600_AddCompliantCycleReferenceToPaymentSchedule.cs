using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NPOMS.Repository.Migrations
{
    public partial class AddCompliantCycleReferenceToPaymentSchedule : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_PaymentSchedules_CompliantCycleId",
                schema: "dbo",
                table: "PaymentSchedules",
                column: "CompliantCycleId");

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentSchedules_CompliantCycles_CompliantCycleId",
                schema: "dbo",
                table: "PaymentSchedules",
                column: "CompliantCycleId",
                principalSchema: "dbo",
                principalTable: "CompliantCycles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentSchedules_CompliantCycles_CompliantCycleId",
                schema: "dbo",
                table: "PaymentSchedules");

            migrationBuilder.DropIndex(
                name: "IX_PaymentSchedules_CompliantCycleId",
                schema: "dbo",
                table: "PaymentSchedules");
        }
    }
}
