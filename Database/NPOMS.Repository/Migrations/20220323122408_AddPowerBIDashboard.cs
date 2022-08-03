using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NPOMS.Repository.Migrations
{
    public partial class AddPowerBIDashboard : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmbeddedReports",
                schema: "core",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false),
                    Description = table.Column<string>(type: "varchar(2000)", nullable: true),
                    ReportId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkspaceId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryName = table.Column<string>(type: "varchar(255)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1"),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
                    UpdatedUserId = table.Column<int>(type: "int", nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmbeddedReports", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "core",
                table: "EmbeddedReports",
                columns: new[] { "Id", "CategoryName", "Description", "Name", "ReportId", "UpdatedDateTime", "UpdatedUserId", "WorkspaceId" },
                values: new object[] { 1, "Dashboard", "Dashboard view everything on the system", "Dashboard", "0d26cc25-db2e-403e-815f-989918ea0863", null, null, "1e12372d-bbc2-420a-b033-fcc3daa4ee17" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmbeddedReports",
                schema: "core");
        }
    }
}
