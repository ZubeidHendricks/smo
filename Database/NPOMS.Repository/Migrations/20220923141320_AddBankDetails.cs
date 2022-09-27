using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NPOMS.Repository.Migrations
{
    public partial class AddBankDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NpoProfiles_FacilityLists_NpoProfiles_NpoProfileId",
                schema: "mapping",
                table: "NpoProfiles_FacilityLists");

            migrationBuilder.DropForeignKey(
                name: "FK_ServicesRendered_NpoProfiles_NpoProfileId",
                schema: "dbo",
                table: "ServicesRendered");

            migrationBuilder.DropIndex(
                name: "IX_ServicesRendered_NpoProfileId",
                schema: "dbo",
                table: "ServicesRendered");

            migrationBuilder.DropIndex(
                name: "IX_NpoProfiles_FacilityLists_NpoProfileId",
                schema: "mapping",
                table: "NpoProfiles_FacilityLists");

            migrationBuilder.DropColumn(
                name: "CreatedDateTime",
                schema: "dbo",
                table: "AddressInformation");

            migrationBuilder.DropColumn(
                name: "CreatedUserId",
                schema: "dbo",
                table: "AddressInformation");

            migrationBuilder.DropColumn(
                name: "UpdatedDateTime",
                schema: "dbo",
                table: "AddressInformation");

            migrationBuilder.DropColumn(
                name: "UpdatedUserId",
                schema: "dbo",
                table: "AddressInformation");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDateTime",
                schema: "dbo",
                table: "ServicesRendered",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CreatedUserId",
                schema: "dbo",
                table: "ServicesRendered",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDateTime",
                schema: "dbo",
                table: "ServicesRendered",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpdatedUserId",
                schema: "dbo",
                table: "ServicesRendered",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BankDetails",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NpoProfileId = table.Column<int>(type: "int", nullable: false),
                    BankId = table.Column<int>(type: "int", nullable: false),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    AccountTypeId = table.Column<int>(type: "int", nullable: false),
                    AccountNumber = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedUserId = table.Column<int>(type: "int", nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankDetails", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BankDetails",
                schema: "dbo");

            migrationBuilder.DropColumn(
                name: "CreatedDateTime",
                schema: "dbo",
                table: "ServicesRendered");

            migrationBuilder.DropColumn(
                name: "CreatedUserId",
                schema: "dbo",
                table: "ServicesRendered");

            migrationBuilder.DropColumn(
                name: "UpdatedDateTime",
                schema: "dbo",
                table: "ServicesRendered");

            migrationBuilder.DropColumn(
                name: "UpdatedUserId",
                schema: "dbo",
                table: "ServicesRendered");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDateTime",
                schema: "dbo",
                table: "AddressInformation",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CreatedUserId",
                schema: "dbo",
                table: "AddressInformation",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDateTime",
                schema: "dbo",
                table: "AddressInformation",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpdatedUserId",
                schema: "dbo",
                table: "AddressInformation",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ServicesRendered_NpoProfileId",
                schema: "dbo",
                table: "ServicesRendered",
                column: "NpoProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_NpoProfiles_FacilityLists_NpoProfileId",
                schema: "mapping",
                table: "NpoProfiles_FacilityLists",
                column: "NpoProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_NpoProfiles_FacilityLists_NpoProfiles_NpoProfileId",
                schema: "mapping",
                table: "NpoProfiles_FacilityLists",
                column: "NpoProfileId",
                principalSchema: "dbo",
                principalTable: "NpoProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServicesRendered_NpoProfiles_NpoProfileId",
                schema: "dbo",
                table: "ServicesRendered",
                column: "NpoProfileId",
                principalSchema: "dbo",
                principalTable: "NpoProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
