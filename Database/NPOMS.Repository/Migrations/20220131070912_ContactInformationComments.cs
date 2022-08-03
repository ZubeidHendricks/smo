using Microsoft.EntityFrameworkCore.Migrations;

namespace NPOMS.Repository.Migrations
{
    public partial class ContactInformationComments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Comments",
                schema: "dbo",
                table: "ContactInformation",
                type: "nvarchar(1000)",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "core",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 38,
                column: "CategoryName",
                value: "Organisation Approval Management");

            migrationBuilder.InsertData(
                schema: "dropdown",
                table: "Positions",
                columns: new[] { "Id", "Name", "UpdatedDateTime", "UpdatedUserId" },
                values: new object[,]
                {
                    { 22, "Project Manager", null, null },
                    { 23, "Programme Manager", null, null }
                });

            migrationBuilder.InsertData(
                schema: "dropdown",
                table: "Titles",
                columns: new[] { "Id", "Name", "UpdatedDateTime", "UpdatedUserId" },
                values: new object[] { 6, "Ms", null, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "Positions",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "Positions",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "Titles",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DropColumn(
                name: "Comments",
                schema: "dbo",
                table: "ContactInformation");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 38,
                column: "CategoryName",
                value: "NPO Organisation Management");
        }
    }
}
