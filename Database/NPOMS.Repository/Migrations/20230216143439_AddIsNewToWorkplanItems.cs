using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NPOMS.Repository.Migrations
{
    public partial class AddIsNewToWorkplanItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsNew",
                schema: "dbo",
                table: "SustainabilityPlans",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsNew",
                schema: "dbo",
                table: "Resources",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsNew",
                schema: "dbo",
                table: "Objectives",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsNew",
                schema: "dbo",
                table: "Activities",
                type: "bit",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsNew",
                schema: "dbo",
                table: "SustainabilityPlans");

            migrationBuilder.DropColumn(
                name: "IsNew",
                schema: "dbo",
                table: "Resources");

            migrationBuilder.DropColumn(
                name: "IsNew",
                schema: "dbo",
                table: "Objectives");

            migrationBuilder.DropColumn(
                name: "IsNew",
                schema: "dbo",
                table: "Activities");
        }
    }
}
