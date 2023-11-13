using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NPOMS.Repository.Migrations
{
    public partial class SRAndSSRObjectsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SubRecipients",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ObjectiveId = table.Column<int>(type: "int", nullable: false),
                    OrganisationName = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    FundingPeriodStartDate = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    FundingPeriodEndDate = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Budget = table.Column<decimal>(type: "numeric(18,6)", nullable: false),
                    RecipientTypeId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedUserId = table.Column<int>(type: "int", nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubRecipients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubRecipients_Objectives_ObjectiveId",
                        column: x => x.ObjectiveId,
                        principalSchema: "dbo",
                        principalTable: "Objectives",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubSubRecipients",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubRecipientId = table.Column<int>(type: "int", nullable: false),
                    OrganisationName = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    FundingPeriodStartDate = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    FundingPeriodEndDate = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Budget = table.Column<decimal>(type: "numeric(18,6)", nullable: false),
                    RecipientTypeId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedUserId = table.Column<int>(type: "int", nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubSubRecipients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubSubRecipients_SubRecipients_SubRecipientId",
                        column: x => x.SubRecipientId,
                        principalSchema: "dbo",
                        principalTable: "SubRecipients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2023, 10, 19, 8, 43, 10, 720, DateTimeKind.Local).AddTicks(7445));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2023, 10, 19, 8, 43, 10, 720, DateTimeKind.Local).AddTicks(7447));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2023, 10, 19, 8, 43, 10, 720, DateTimeKind.Local).AddTicks(7448));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2023, 10, 19, 8, 43, 10, 720, DateTimeKind.Local).AddTicks(7450));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDateTime",
                value: new DateTime(2023, 10, 19, 8, 43, 10, 720, DateTimeKind.Local).AddTicks(7451));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2023, 10, 19, 8, 43, 10, 720, DateTimeKind.Local).AddTicks(7452));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2023, 10, 19, 8, 43, 10, 720, DateTimeKind.Local).AddTicks(7453));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2023, 10, 19, 8, 43, 10, 720, DateTimeKind.Local).AddTicks(7454));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDateTime",
                value: new DateTime(2023, 10, 19, 8, 43, 10, 720, DateTimeKind.Local).AddTicks(7456));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDateTime",
                value: new DateTime(2023, 10, 19, 8, 43, 10, 720, DateTimeKind.Local).AddTicks(7457));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDateTime",
                value: new DateTime(2023, 10, 19, 8, 43, 10, 720, DateTimeKind.Local).AddTicks(7458));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDateTime",
                value: new DateTime(2023, 10, 19, 8, 43, 10, 720, DateTimeKind.Local).AddTicks(7459));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDateTime",
                value: new DateTime(2023, 10, 19, 8, 43, 10, 720, DateTimeKind.Local).AddTicks(7462));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDateTime",
                value: new DateTime(2023, 10, 19, 8, 43, 10, 720, DateTimeKind.Local).AddTicks(7463));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDateTime",
                value: new DateTime(2023, 10, 19, 8, 43, 10, 720, DateTimeKind.Local).AddTicks(7465));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDateTime",
                value: new DateTime(2023, 10, 19, 8, 43, 10, 720, DateTimeKind.Local).AddTicks(7466));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDateTime",
                value: new DateTime(2023, 10, 19, 8, 43, 10, 720, DateTimeKind.Local).AddTicks(7467));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDateTime",
                value: new DateTime(2023, 10, 19, 8, 43, 10, 720, DateTimeKind.Local).AddTicks(7468));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDateTime",
                value: new DateTime(2023, 10, 19, 8, 43, 10, 720, DateTimeKind.Local).AddTicks(7469));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDateTime",
                value: new DateTime(2023, 10, 19, 8, 43, 10, 720, DateTimeKind.Local).AddTicks(7470));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDateTime",
                value: new DateTime(2023, 10, 19, 8, 43, 10, 720, DateTimeKind.Local).AddTicks(7477));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDateTime",
                value: new DateTime(2023, 10, 19, 8, 43, 10, 720, DateTimeKind.Local).AddTicks(7478));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDateTime",
                value: new DateTime(2023, 10, 19, 8, 43, 10, 720, DateTimeKind.Local).AddTicks(7484));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDateTime",
                value: new DateTime(2023, 10, 19, 8, 43, 10, 720, DateTimeKind.Local).AddTicks(7499));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDateTime",
                value: new DateTime(2023, 10, 19, 8, 43, 10, 720, DateTimeKind.Local).AddTicks(7500));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDateTime",
                value: new DateTime(2023, 10, 19, 8, 43, 10, 720, DateTimeKind.Local).AddTicks(7501));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDateTime",
                value: new DateTime(2023, 10, 19, 8, 43, 10, 720, DateTimeKind.Local).AddTicks(7502));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedDateTime",
                value: new DateTime(2023, 10, 19, 8, 43, 10, 720, DateTimeKind.Local).AddTicks(7503));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedDateTime",
                value: new DateTime(2023, 10, 19, 8, 43, 10, 720, DateTimeKind.Local).AddTicks(7505));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedDateTime",
                value: new DateTime(2023, 10, 19, 8, 43, 10, 720, DateTimeKind.Local).AddTicks(7506));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDateTime",
                value: new DateTime(2023, 10, 19, 8, 43, 10, 720, DateTimeKind.Local).AddTicks(7507));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedDateTime",
                value: new DateTime(2023, 10, 19, 8, 43, 10, 720, DateTimeKind.Local).AddTicks(7508));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2023, 10, 19, 8, 43, 10, 720, DateTimeKind.Local).AddTicks(7345));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2023, 10, 19, 8, 43, 10, 720, DateTimeKind.Local).AddTicks(7363));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2023, 10, 19, 8, 43, 10, 720, DateTimeKind.Local).AddTicks(7365));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2023, 10, 19, 8, 43, 10, 720, DateTimeKind.Local).AddTicks(7366));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2023, 10, 19, 8, 43, 10, 720, DateTimeKind.Local).AddTicks(7368));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2023, 10, 19, 8, 43, 10, 720, DateTimeKind.Local).AddTicks(7369));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2023, 10, 19, 8, 43, 10, 720, DateTimeKind.Local).AddTicks(7371));

            migrationBuilder.InsertData(
                schema: "dropdown",
                table: "RecipientTypes",
                columns: new[] { "Id", "Name", "SystemName", "UpdatedDateTime", "UpdatedUserId" },
                values: new object[] { 3, "Sub-SubRecipient", "SubSubRecipient", null, null });

            migrationBuilder.CreateIndex(
                name: "IX_SubRecipients_ObjectiveId",
                schema: "dbo",
                table: "SubRecipients",
                column: "ObjectiveId");

            migrationBuilder.CreateIndex(
                name: "IX_SubSubRecipients_SubRecipientId",
                schema: "dbo",
                table: "SubSubRecipients",
                column: "SubRecipientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubSubRecipients",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "SubRecipients",
                schema: "dbo");

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "RecipientTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2023, 10, 16, 20, 32, 35, 260, DateTimeKind.Local).AddTicks(5110));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2023, 10, 16, 20, 32, 35, 260, DateTimeKind.Local).AddTicks(5112));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2023, 10, 16, 20, 32, 35, 260, DateTimeKind.Local).AddTicks(5113));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2023, 10, 16, 20, 32, 35, 260, DateTimeKind.Local).AddTicks(5113));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDateTime",
                value: new DateTime(2023, 10, 16, 20, 32, 35, 260, DateTimeKind.Local).AddTicks(5114));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2023, 10, 16, 20, 32, 35, 260, DateTimeKind.Local).AddTicks(5115));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2023, 10, 16, 20, 32, 35, 260, DateTimeKind.Local).AddTicks(5116));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2023, 10, 16, 20, 32, 35, 260, DateTimeKind.Local).AddTicks(5120));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDateTime",
                value: new DateTime(2023, 10, 16, 20, 32, 35, 260, DateTimeKind.Local).AddTicks(5122));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDateTime",
                value: new DateTime(2023, 10, 16, 20, 32, 35, 260, DateTimeKind.Local).AddTicks(5123));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDateTime",
                value: new DateTime(2023, 10, 16, 20, 32, 35, 260, DateTimeKind.Local).AddTicks(5124));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDateTime",
                value: new DateTime(2023, 10, 16, 20, 32, 35, 260, DateTimeKind.Local).AddTicks(5125));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDateTime",
                value: new DateTime(2023, 10, 16, 20, 32, 35, 260, DateTimeKind.Local).AddTicks(5126));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDateTime",
                value: new DateTime(2023, 10, 16, 20, 32, 35, 260, DateTimeKind.Local).AddTicks(5127));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDateTime",
                value: new DateTime(2023, 10, 16, 20, 32, 35, 260, DateTimeKind.Local).AddTicks(5127));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDateTime",
                value: new DateTime(2023, 10, 16, 20, 32, 35, 260, DateTimeKind.Local).AddTicks(5128));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDateTime",
                value: new DateTime(2023, 10, 16, 20, 32, 35, 260, DateTimeKind.Local).AddTicks(5129));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDateTime",
                value: new DateTime(2023, 10, 16, 20, 32, 35, 260, DateTimeKind.Local).AddTicks(5130));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDateTime",
                value: new DateTime(2023, 10, 16, 20, 32, 35, 260, DateTimeKind.Local).AddTicks(5131));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDateTime",
                value: new DateTime(2023, 10, 16, 20, 32, 35, 260, DateTimeKind.Local).AddTicks(5132));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDateTime",
                value: new DateTime(2023, 10, 16, 20, 32, 35, 260, DateTimeKind.Local).AddTicks(5133));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDateTime",
                value: new DateTime(2023, 10, 16, 20, 32, 35, 260, DateTimeKind.Local).AddTicks(5140));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDateTime",
                value: new DateTime(2023, 10, 16, 20, 32, 35, 260, DateTimeKind.Local).AddTicks(5153));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDateTime",
                value: new DateTime(2023, 10, 16, 20, 32, 35, 260, DateTimeKind.Local).AddTicks(5154));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDateTime",
                value: new DateTime(2023, 10, 16, 20, 32, 35, 260, DateTimeKind.Local).AddTicks(5155));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDateTime",
                value: new DateTime(2023, 10, 16, 20, 32, 35, 260, DateTimeKind.Local).AddTicks(5155));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDateTime",
                value: new DateTime(2023, 10, 16, 20, 32, 35, 260, DateTimeKind.Local).AddTicks(5156));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedDateTime",
                value: new DateTime(2023, 10, 16, 20, 32, 35, 260, DateTimeKind.Local).AddTicks(5157));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedDateTime",
                value: new DateTime(2023, 10, 16, 20, 32, 35, 260, DateTimeKind.Local).AddTicks(5158));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedDateTime",
                value: new DateTime(2023, 10, 16, 20, 32, 35, 260, DateTimeKind.Local).AddTicks(5159));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDateTime",
                value: new DateTime(2023, 10, 16, 20, 32, 35, 260, DateTimeKind.Local).AddTicks(5160));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedDateTime",
                value: new DateTime(2023, 10, 16, 20, 32, 35, 260, DateTimeKind.Local).AddTicks(5160));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2023, 10, 16, 20, 32, 35, 260, DateTimeKind.Local).AddTicks(5045));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2023, 10, 16, 20, 32, 35, 260, DateTimeKind.Local).AddTicks(5062));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2023, 10, 16, 20, 32, 35, 260, DateTimeKind.Local).AddTicks(5064));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2023, 10, 16, 20, 32, 35, 260, DateTimeKind.Local).AddTicks(5065));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2023, 10, 16, 20, 32, 35, 260, DateTimeKind.Local).AddTicks(5066));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2023, 10, 16, 20, 32, 35, 260, DateTimeKind.Local).AddTicks(5067));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2023, 10, 16, 20, 32, 35, 260, DateTimeKind.Local).AddTicks(5069));
        }
    }
}
