using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NPOMS.Repository.Migrations
{
    public partial class AddRegistrationStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PBONumber",
                schema: "dbo",
                table: "Npos",
                type: "nvarchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RegistrationStatusId",
                schema: "dbo",
                table: "Npos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Section18Receipts",
                schema: "dbo",
                table: "Npos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "RegistrationStatuses",
                schema: "dropdown",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    SystemName = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1"),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
                    UpdatedUserId = table.Column<int>(type: "int", nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistrationStatuses", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "dropdown",
                table: "RegistrationStatuses",
                columns: new[] { "Id", "Name", "SystemName", "UpdatedDateTime", "UpdatedUserId" },
                values: new object[] { 1, "Registered", "Registered", null, null });

            migrationBuilder.InsertData(
                schema: "dropdown",
                table: "RegistrationStatuses",
                columns: new[] { "Id", "Name", "SystemName", "UpdatedDateTime", "UpdatedUserId" },
                values: new object[] { 2, "Not Registered", "NotRegistered", null, null });

            migrationBuilder.InsertData(
                schema: "dropdown",
                table: "RegistrationStatuses",
                columns: new[] { "Id", "Name", "SystemName", "UpdatedDateTime", "UpdatedUserId" },
                values: new object[] { 3, "In Progress", "InProgress", null, null });

            migrationBuilder.CreateIndex(
                name: "IX_Npos_RegistrationStatusId",
                schema: "dbo",
                table: "Npos",
                column: "RegistrationStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Npos_RegistrationStatuses_RegistrationStatusId",
                schema: "dbo",
                table: "Npos",
                column: "RegistrationStatusId",
                principalSchema: "dropdown",
                principalTable: "RegistrationStatuses",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Npos_RegistrationStatuses_RegistrationStatusId",
                schema: "dbo",
                table: "Npos");

            migrationBuilder.DropTable(
                name: "RegistrationStatuses",
                schema: "dropdown");

            migrationBuilder.DropIndex(
                name: "IX_Npos_RegistrationStatusId",
                schema: "dbo",
                table: "Npos");

            migrationBuilder.DropColumn(
                name: "PBONumber",
                schema: "dbo",
                table: "Npos");

            migrationBuilder.DropColumn(
                name: "RegistrationStatusId",
                schema: "dbo",
                table: "Npos");

            migrationBuilder.DropColumn(
                name: "Section18Receipts",
                schema: "dbo",
                table: "Npos");
        }
    }
}
