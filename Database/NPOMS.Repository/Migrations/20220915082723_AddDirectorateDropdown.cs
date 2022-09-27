using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NPOMS.Repository.Migrations
{
    public partial class AddDirectorateDropdown : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DirectorateId",
                schema: "dropdown",
                table: "Programmes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Directorates",
                schema: "dropdown",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1"),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
                    UpdatedUserId = table.Column<int>(type: "int", nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Directorates", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "dropdown",
                table: "Directorates",
                columns: new[] { "Id", "Description", "Name", "UpdatedDateTime", "UpdatedUserId" },
                values: new object[,]
                {
                    { 1, "", "Children and Families", null, null },
                    { 2, "", "Community Development", null, null },
                    { 3, "", "ECD & Partial Care", null, null },
                    { 4, "", "Facility Management", null, null },
                    { 5, "", "Partnership Development", null, null },
                    { 6, "Restorative Services new 2021 VEP, CP, SA", "Restorative Services", null, null },
                    { 7, "", "Social Crime Prevention", null, null },
                    { 8, "", "Special Programmes", null, null }
                });

            migrationBuilder.InsertData(
                schema: "core",
                table: "Utilities",
                columns: new[] { "Id", "AngularRedirectUrl", "Description", "Name", "SystemAdminUtility", "UpdatedDateTime", "UpdatedUserId" },
                values: new object[] { 65, "utilities/directorate", "Add and/or Update directorates", "Directorate", false, null, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Directorates",
                schema: "dropdown");

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Utilities",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DropColumn(
                name: "DirectorateId",
                schema: "dropdown",
                table: "Programmes");
        }
    }
}
