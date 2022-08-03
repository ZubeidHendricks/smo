using Microsoft.EntityFrameworkCore.Migrations;

namespace NPOMS.Repository.Migrations
{
    public partial class ActivityFacilityListMapping : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_FacilityList_FacilityListId",
                schema: "dbo",
                table: "Activities");

            migrationBuilder.DropIndex(
                name: "IX_Activities_FacilityListId",
                schema: "dbo",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "FacilityListId",
                schema: "dbo",
                table: "Activities");

            migrationBuilder.CreateTable(
                name: "Activities_FacilityLists",
                schema: "mapping",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActivityId = table.Column<int>(type: "int", nullable: false),
                    FacilityListId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities_FacilityLists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Activities_FacilityLists_Activities_ActivityId",
                        column: x => x.ActivityId,
                        principalSchema: "dbo",
                        principalTable: "Activities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Activities_FacilityLists_FacilityList_FacilityListId",
                        column: x => x.FacilityListId,
                        principalSchema: "lookup",
                        principalTable: "FacilityList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "dropdown",
                table: "Titles",
                columns: new[] { "Id", "Name", "UpdatedDateTime", "UpdatedUserId" },
                values: new object[] { 7, "Other", null, null });

            migrationBuilder.CreateIndex(
                name: "IX_Activities_FacilityLists_ActivityId",
                schema: "mapping",
                table: "Activities_FacilityLists",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_FacilityLists_FacilityListId",
                schema: "mapping",
                table: "Activities_FacilityLists",
                column: "FacilityListId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Activities_FacilityLists",
                schema: "mapping");

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "Titles",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.AddColumn<int>(
                name: "FacilityListId",
                schema: "dbo",
                table: "Activities",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Activities_FacilityListId",
                schema: "dbo",
                table: "Activities",
                column: "FacilityListId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_FacilityList_FacilityListId",
                schema: "dbo",
                table: "Activities",
                column: "FacilityListId",
                principalSchema: "lookup",
                principalTable: "FacilityList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
