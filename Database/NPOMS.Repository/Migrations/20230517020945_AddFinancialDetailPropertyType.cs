using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NPOMS.Repository.Migrations
{
    public partial class AddFinancialDetailPropertyType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PropertyTypes",
                schema: "dropdown",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OnGeneralLevel = table.Column<bool>(type: "bit", nullable: false),
                    OnSubsidyLevel = table.Column<bool>(type: "bit", nullable: false),
                    CanDefineName = table.Column<bool>(type: "bit", nullable: false),
                    ValueOnGeneralLevel = table.Column<bool>(type: "bit", nullable: false),
                    ValueOnSybsidyLevel = table.Column<bool>(type: "bit", nullable: false),
                    HaveBreakDown = table.Column<bool>(type: "bit", nullable: false),
                    HaveRelatedProperty = table.Column<bool>(type: "bit", nullable: false),
                    IsBusinessRule = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUserID = table.Column<int>(type: "int", nullable: false),
                    UpdatedUserID = table.Column<int>(type: "int", nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HaveFrequency = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PropertySubTypes",
                schema: "dropdown",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PropertyTypeID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HaveComment = table.Column<bool>(type: "bit", nullable: false),
                    Repeatable = table.Column<bool>(type: "bit", nullable: false),
                    Frequency = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUserID = table.Column<int>(type: "int", nullable: false),
                    UpdatedUserID = table.Column<int>(type: "int", nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertySubTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PropertySubTypes_PropertyTypes_PropertyTypeID",
                        column: x => x.PropertyTypeID,
                        principalSchema: "dropdown",
                        principalTable: "PropertyTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FinancialDetails",
                schema: "fa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationId = table.Column<int>(type: "int", nullable: false),
                    PropertyId = table.Column<int>(type: "int", nullable: false),
                    SubPropertyId = table.Column<int>(type: "int", nullable: false),
                    Property = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubProperty = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AmountOne = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AmountTwo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AmountThree = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedUserId = table.Column<int>(type: "int", nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ChangesRequired = table.Column<bool>(type: "bit", nullable: true),
                    IsNew = table.Column<bool>(type: "bit", nullable: true),
                    PropertyTypeId = table.Column<int>(type: "int", nullable: true),
                    PropertySubTypeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinancialDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FinancialDetails_PropertySubTypes_PropertySubTypeId",
                        column: x => x.PropertySubTypeId,
                        principalSchema: "dropdown",
                        principalTable: "PropertySubTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FinancialDetails_PropertyTypes_PropertyTypeId",
                        column: x => x.PropertyTypeId,
                        principalSchema: "dropdown",
                        principalTable: "PropertyTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                schema: "dropdown",
                table: "PropertyTypes",
                columns: new[] { "Id", "CanDefineName", "Code", "CreatedDateTime", "CreatedUserID", "HaveBreakDown", "HaveFrequency", "HaveRelatedProperty", "IsActive", "IsBusinessRule", "IsDeleted", "Name", "OnGeneralLevel", "OnSubsidyLevel", "UpdatedDateTime", "UpdatedUserID", "ValueOnGeneralLevel", "ValueOnSybsidyLevel" },
                values: new object[,]
                {
                    { 1, false, "AdministrationFee", new DateTime(2023, 5, 17, 4, 9, 36, 57, DateTimeKind.Local).AddTicks(8656), 3, false, false, false, true, false, false, "Administration Fee (%)", true, false, null, null, false, true },
                    { 2, false, "PostItem", new DateTime(2023, 5, 17, 4, 9, 36, 57, DateTimeKind.Local).AddTicks(8679), 3, true, false, false, true, false, false, "Post Cost", true, true, null, null, true, false },
                    { 3, true, "UnitItem", new DateTime(2023, 5, 17, 4, 9, 36, 57, DateTimeKind.Local).AddTicks(8682), 3, true, true, false, true, false, false, "Unit Cost", false, true, null, null, false, true },
                    { 4, false, "OperationalItem", new DateTime(2023, 5, 17, 4, 9, 36, 57, DateTimeKind.Local).AddTicks(8684), 3, true, false, true, true, false, false, "Operational Cost (With Break Down)", false, true, null, null, false, false },
                    { 6, false, "RuleForSocialWorkers", new DateTime(2023, 5, 17, 4, 9, 36, 57, DateTimeKind.Local).AddTicks(8686), 3, false, false, true, true, true, false, "Rule For Social Workers", false, true, null, null, false, false },
                    { 7, false, "UIFFee", new DateTime(2023, 5, 17, 4, 9, 36, 57, DateTimeKind.Local).AddTicks(8688), 3, false, false, false, true, false, false, "UIF Fee (%)", true, true, null, null, true, false },
                    { 8, false, "COIDAFee", new DateTime(2023, 5, 17, 4, 9, 36, 57, DateTimeKind.Local).AddTicks(8690), 3, false, false, false, true, false, false, "COIDA Fee (%)", true, false, null, null, true, false }
                });

            migrationBuilder.InsertData(
                schema: "dropdown",
                table: "PropertySubTypes",
                columns: new[] { "Id", "CreatedDateTime", "CreatedUserID", "Frequency", "HaveComment", "IsActive", "IsDeleted", "Name", "PropertyTypeID", "Repeatable", "UpdatedDateTime", "UpdatedUserID" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 17, 4, 9, 36, 57, DateTimeKind.Local).AddTicks(8767), 3, 12, false, true, false, "Monthly", 3, true, null, null },
                    { 2, new DateTime(2023, 5, 17, 4, 9, 36, 57, DateTimeKind.Local).AddTicks(8770), 3, 1, false, true, false, "Annually", 3, true, null, null },
                    { 3, new DateTime(2023, 5, 17, 4, 9, 36, 57, DateTimeKind.Local).AddTicks(8772), 3, 264, false, true, false, "264 Days", 3, true, null, null },
                    { 4, new DateTime(2023, 5, 17, 4, 9, 36, 57, DateTimeKind.Local).AddTicks(8774), 3, 240, false, true, false, "240 Days", 3, true, null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_FinancialDetails_PropertySubTypeId",
                schema: "fa",
                table: "FinancialDetails",
                column: "PropertySubTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_FinancialDetails_PropertyTypeId",
                schema: "fa",
                table: "FinancialDetails",
                column: "PropertyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertySubTypes_PropertyTypeID",
                schema: "dropdown",
                table: "PropertySubTypes",
                column: "PropertyTypeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FinancialDetails",
                schema: "fa");

            migrationBuilder.DropTable(
                name: "PropertySubTypes",
                schema: "dropdown");

            migrationBuilder.DropTable(
                name: "PropertyTypes",
                schema: "dropdown");
        }
    }
}
