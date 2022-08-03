using Microsoft.EntityFrameworkCore.Migrations;

namespace NPOMS.Repository.Migrations
{
    public partial class AddNgoOrganisationType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "dropdown",
                table: "OrganisationTypes",
                columns: new[] { "Id", "Description", "Name", "UpdatedDateTime", "UpdatedUserId" },
                values: new object[] { 13, "Non Governmental Organisation", "NGO", null, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "OrganisationTypes",
                keyColumn: "Id",
                keyValue: 13);
        }
    }
}
