using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NPOMS.Repository.Migrations
{
    /// <inheritdoc />
    public partial class AddedFundingManagementTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "fm");

            migrationBuilder.CreateTable(
                name: "CalculationTypes",
                schema: "dropdown",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    SystemName = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1"),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
                    UpdatedUserId = table.Column<int>(type: "int", nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalculationTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FundingCaptures",
                schema: "fm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RefNo = table.Column<string>(type: "char(15)", nullable: true),
                    NpoId = table.Column<int>(type: "int", nullable: false),
                    FinancialYearId = table.Column<int>(type: "int", nullable: true),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedUserId = table.Column<int>(type: "int", nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FundingCaptures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FundingCaptures_FinancialYears_FinancialYearId",
                        column: x => x.FinancialYearId,
                        principalSchema: "core",
                        principalTable: "FinancialYears",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FundingCaptures_Npos_NpoId",
                        column: x => x.NpoId,
                        principalSchema: "dbo",
                        principalTable: "Npos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FundingCaptures_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalSchema: "dbo",
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FundingTypes",
                schema: "dropdown",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    SystemName = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1"),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
                    UpdatedUserId = table.Column<int>(type: "int", nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FundingTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BankDetails",
                schema: "fm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FundingCaptureId = table.Column<int>(type: "int", nullable: false),
                    ProgramBankDetailsId = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedUserId = table.Column<int>(type: "int", nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BankDetails_FundingCaptures_FundingCaptureId",
                        column: x => x.FundingCaptureId,
                        principalSchema: "fm",
                        principalTable: "FundingCaptures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BankDetails_ProgramBankDetails_ProgramBankDetailsId",
                        column: x => x.ProgramBankDetailsId,
                        principalSchema: "dbo",
                        principalTable: "ProgramBankDetails",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Documents",
                schema: "fm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FundingCaptureId = table.Column<int>(type: "int", nullable: false),
                    TPALink = table.Column<string>(type: "nvarchar(2000)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedUserId = table.Column<int>(type: "int", nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Documents_FundingCaptures_FundingCaptureId",
                        column: x => x.FundingCaptureId,
                        principalSchema: "fm",
                        principalTable: "FundingCaptures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SDAs",
                schema: "fm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FundingCaptureId = table.Column<int>(type: "int", nullable: false),
                    ServiceDeliveryAreaId = table.Column<int>(type: "int", nullable: true),
                    PlaceId = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedUserId = table.Column<int>(type: "int", nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SDAs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SDAs_FundingCaptures_FundingCaptureId",
                        column: x => x.FundingCaptureId,
                        principalSchema: "fm",
                        principalTable: "FundingCaptures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SDAs_Places_PlaceId",
                        column: x => x.PlaceId,
                        principalSchema: "dropdown",
                        principalTable: "Places",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FundingDetails",
                schema: "fm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FundingCaptureId = table.Column<int>(type: "int", nullable: false),
                    FinancialYearId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    FundingTypeId = table.Column<int>(type: "int", nullable: false),
                    FrequencyId = table.Column<int>(type: "int", nullable: true),
                    AllowVariableFunding = table.Column<bool>(type: "bit", nullable: false),
                    AllowClaims = table.Column<bool>(type: "bit", nullable: false),
                    ProgrammeId = table.Column<int>(type: "int", nullable: false),
                    SubProgrammeId = table.Column<int>(type: "int", nullable: false),
                    SubProgrammeTypeId = table.Column<int>(type: "int", nullable: false),
                    AmountAwarded = table.Column<double>(type: "float", nullable: true),
                    CalculationTypeId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedUserId = table.Column<int>(type: "int", nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FundingDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FundingDetails_CalculationTypes_CalculationTypeId",
                        column: x => x.CalculationTypeId,
                        principalSchema: "dropdown",
                        principalTable: "CalculationTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FundingDetails_FinancialYears_FinancialYearId",
                        column: x => x.FinancialYearId,
                        principalSchema: "core",
                        principalTable: "FinancialYears",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FundingDetails_Frequencies_FrequencyId",
                        column: x => x.FrequencyId,
                        principalSchema: "dropdown",
                        principalTable: "Frequencies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FundingDetails_FundingCaptures_FundingCaptureId",
                        column: x => x.FundingCaptureId,
                        principalSchema: "fm",
                        principalTable: "FundingCaptures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FundingDetails_FundingTypes_FundingTypeId",
                        column: x => x.FundingTypeId,
                        principalSchema: "dropdown",
                        principalTable: "FundingTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FundingDetails_Programmes_ProgrammeId",
                        column: x => x.ProgrammeId,
                        principalSchema: "dropdown",
                        principalTable: "Programmes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FundingDetails_SubProgrammeTypes_SubProgrammeTypeId",
                        column: x => x.SubProgrammeTypeId,
                        principalSchema: "dropdown",
                        principalTable: "SubProgrammeTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FundingDetails_SubProgrammes_SubProgrammeId",
                        column: x => x.SubProgrammeId,
                        principalSchema: "dropdown",
                        principalTable: "SubProgrammes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "dropdown",
                table: "CalculationTypes",
                columns: new[] { "Id", "Name", "SystemName", "UpdatedDateTime", "UpdatedUserId" },
                values: new object[,]
                {
                    { 1, "Detailed", "Detailed", null, null },
                    { 2, "Summary", "Summary", null, null }
                });

            migrationBuilder.InsertData(
                schema: "dropdown",
                table: "FundingTypes",
                columns: new[] { "Id", "Name", "SystemName", "UpdatedDateTime", "UpdatedUserId" },
                values: new object[,]
                {
                    { 1, "Adhoc", "Adhoc", null, null },
                    { 2, "Annual", "Annual", null, null }
                });

            migrationBuilder.InsertData(
                schema: "core",
                table: "Permissions",
                columns: new[] { "Id", "CategoryName", "Name", "SystemName", "UpdatedDateTime", "UpdatedUserId" },
                values: new object[] { 133, "Funding Capture", "Delete Funding Capture", "FC.Delete", null, null });

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 28, 14, 19, 15, 708, DateTimeKind.Local).AddTicks(1114));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 28, 14, 19, 15, 708, DateTimeKind.Local).AddTicks(1140));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 28, 14, 19, 15, 708, DateTimeKind.Local).AddTicks(1142));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 28, 14, 19, 15, 708, DateTimeKind.Local).AddTicks(1143));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 28, 14, 19, 15, 708, DateTimeKind.Local).AddTicks(1144));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 28, 14, 19, 15, 708, DateTimeKind.Local).AddTicks(1146));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 28, 14, 19, 15, 708, DateTimeKind.Local).AddTicks(1147));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 28, 14, 19, 15, 708, DateTimeKind.Local).AddTicks(1148));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 28, 14, 19, 15, 708, DateTimeKind.Local).AddTicks(1150));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 28, 14, 19, 15, 708, DateTimeKind.Local).AddTicks(1151));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 28, 14, 19, 15, 708, DateTimeKind.Local).AddTicks(1152));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 28, 14, 19, 15, 708, DateTimeKind.Local).AddTicks(1153));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 28, 14, 19, 15, 708, DateTimeKind.Local).AddTicks(1155));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 28, 14, 19, 15, 708, DateTimeKind.Local).AddTicks(1156));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 28, 14, 19, 15, 708, DateTimeKind.Local).AddTicks(1157));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 28, 14, 19, 15, 708, DateTimeKind.Local).AddTicks(1159));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 28, 14, 19, 15, 708, DateTimeKind.Local).AddTicks(1160));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 28, 14, 19, 15, 708, DateTimeKind.Local).AddTicks(1161));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 28, 14, 19, 15, 708, DateTimeKind.Local).AddTicks(1162));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 28, 14, 19, 15, 708, DateTimeKind.Local).AddTicks(1164));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 28, 14, 19, 15, 708, DateTimeKind.Local).AddTicks(1165));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 28, 14, 19, 15, 708, DateTimeKind.Local).AddTicks(1166));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 28, 14, 19, 15, 708, DateTimeKind.Local).AddTicks(1167));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 28, 14, 19, 15, 708, DateTimeKind.Local).AddTicks(1169));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 28, 14, 19, 15, 708, DateTimeKind.Local).AddTicks(1170));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 28, 14, 19, 15, 708, DateTimeKind.Local).AddTicks(1171));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 28, 14, 19, 15, 708, DateTimeKind.Local).AddTicks(1172));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 28, 14, 19, 15, 708, DateTimeKind.Local).AddTicks(1181));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 28, 14, 19, 15, 708, DateTimeKind.Local).AddTicks(1183));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 28, 14, 19, 15, 708, DateTimeKind.Local).AddTicks(1186));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 28, 14, 19, 15, 708, DateTimeKind.Local).AddTicks(1204));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 28, 14, 19, 15, 708, DateTimeKind.Local).AddTicks(1205));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 28, 14, 19, 15, 708, DateTimeKind.Local).AddTicks(1650));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 28, 14, 19, 15, 708, DateTimeKind.Local).AddTicks(1654));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 28, 14, 19, 15, 708, DateTimeKind.Local).AddTicks(1656));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 28, 14, 19, 15, 708, DateTimeKind.Local).AddTicks(1657));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 28, 14, 19, 15, 708, DateTimeKind.Local).AddTicks(1659));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 28, 14, 19, 15, 708, DateTimeKind.Local).AddTicks(1661));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 28, 14, 19, 15, 708, DateTimeKind.Local).AddTicks(1663));

            migrationBuilder.InsertData(
                schema: "mapping",
                table: "Roles_Permissions",
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 133, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_BankDetails_FundingCaptureId",
                schema: "fm",
                table: "BankDetails",
                column: "FundingCaptureId");

            migrationBuilder.CreateIndex(
                name: "IX_BankDetails_ProgramBankDetailsId",
                schema: "fm",
                table: "BankDetails",
                column: "ProgramBankDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_FundingCaptureId",
                schema: "fm",
                table: "Documents",
                column: "FundingCaptureId");

            migrationBuilder.CreateIndex(
                name: "IX_FundingCaptures_FinancialYearId",
                schema: "fm",
                table: "FundingCaptures",
                column: "FinancialYearId");

            migrationBuilder.CreateIndex(
                name: "IX_FundingCaptures_NpoId",
                schema: "fm",
                table: "FundingCaptures",
                column: "NpoId");

            migrationBuilder.CreateIndex(
                name: "IX_FundingCaptures_StatusId",
                schema: "fm",
                table: "FundingCaptures",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_FundingDetails_CalculationTypeId",
                schema: "fm",
                table: "FundingDetails",
                column: "CalculationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_FundingDetails_FinancialYearId",
                schema: "fm",
                table: "FundingDetails",
                column: "FinancialYearId");

            migrationBuilder.CreateIndex(
                name: "IX_FundingDetails_FrequencyId",
                schema: "fm",
                table: "FundingDetails",
                column: "FrequencyId");

            migrationBuilder.CreateIndex(
                name: "IX_FundingDetails_FundingCaptureId",
                schema: "fm",
                table: "FundingDetails",
                column: "FundingCaptureId");

            migrationBuilder.CreateIndex(
                name: "IX_FundingDetails_FundingTypeId",
                schema: "fm",
                table: "FundingDetails",
                column: "FundingTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_FundingDetails_ProgrammeId",
                schema: "fm",
                table: "FundingDetails",
                column: "ProgrammeId");

            migrationBuilder.CreateIndex(
                name: "IX_FundingDetails_SubProgrammeId",
                schema: "fm",
                table: "FundingDetails",
                column: "SubProgrammeId");

            migrationBuilder.CreateIndex(
                name: "IX_FundingDetails_SubProgrammeTypeId",
                schema: "fm",
                table: "FundingDetails",
                column: "SubProgrammeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SDAs_FundingCaptureId",
                schema: "fm",
                table: "SDAs",
                column: "FundingCaptureId");

            migrationBuilder.CreateIndex(
                name: "IX_SDAs_PlaceId",
                schema: "fm",
                table: "SDAs",
                column: "PlaceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BankDetails",
                schema: "fm");

            migrationBuilder.DropTable(
                name: "Documents",
                schema: "fm");

            migrationBuilder.DropTable(
                name: "FundingDetails",
                schema: "fm");

            migrationBuilder.DropTable(
                name: "SDAs",
                schema: "fm");

            migrationBuilder.DropTable(
                name: "CalculationTypes",
                schema: "dropdown");

            migrationBuilder.DropTable(
                name: "FundingTypes",
                schema: "dropdown");

            migrationBuilder.DropTable(
                name: "FundingCaptures",
                schema: "fm");

            migrationBuilder.DeleteData(
                schema: "mapping",
                table: "Roles_Permissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 133, 1 });

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 133);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 21, 13, 59, 23, 539, DateTimeKind.Local).AddTicks(4815));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 21, 13, 59, 23, 539, DateTimeKind.Local).AddTicks(4832));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 21, 13, 59, 23, 539, DateTimeKind.Local).AddTicks(4833));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 21, 13, 59, 23, 539, DateTimeKind.Local).AddTicks(4835));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 21, 13, 59, 23, 539, DateTimeKind.Local).AddTicks(4836));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 21, 13, 59, 23, 539, DateTimeKind.Local).AddTicks(4837));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 21, 13, 59, 23, 539, DateTimeKind.Local).AddTicks(4839));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 21, 13, 59, 23, 539, DateTimeKind.Local).AddTicks(4840));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 21, 13, 59, 23, 539, DateTimeKind.Local).AddTicks(4841));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 21, 13, 59, 23, 539, DateTimeKind.Local).AddTicks(4843));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 21, 13, 59, 23, 539, DateTimeKind.Local).AddTicks(4844));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 21, 13, 59, 23, 539, DateTimeKind.Local).AddTicks(4845));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 21, 13, 59, 23, 539, DateTimeKind.Local).AddTicks(4847));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 21, 13, 59, 23, 539, DateTimeKind.Local).AddTicks(4848));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 21, 13, 59, 23, 539, DateTimeKind.Local).AddTicks(4849));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 21, 13, 59, 23, 539, DateTimeKind.Local).AddTicks(4851));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 21, 13, 59, 23, 539, DateTimeKind.Local).AddTicks(4852));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 21, 13, 59, 23, 539, DateTimeKind.Local).AddTicks(4854));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 21, 13, 59, 23, 539, DateTimeKind.Local).AddTicks(4855));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 21, 13, 59, 23, 539, DateTimeKind.Local).AddTicks(4856));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 21, 13, 59, 23, 539, DateTimeKind.Local).AddTicks(4857));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 21, 13, 59, 23, 539, DateTimeKind.Local).AddTicks(4859));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 21, 13, 59, 23, 539, DateTimeKind.Local).AddTicks(4860));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 21, 13, 59, 23, 539, DateTimeKind.Local).AddTicks(4861));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 21, 13, 59, 23, 539, DateTimeKind.Local).AddTicks(4863));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 21, 13, 59, 23, 539, DateTimeKind.Local).AddTicks(4864));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 21, 13, 59, 23, 539, DateTimeKind.Local).AddTicks(4865));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 21, 13, 59, 23, 539, DateTimeKind.Local).AddTicks(4873));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 21, 13, 59, 23, 539, DateTimeKind.Local).AddTicks(4874));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 21, 13, 59, 23, 539, DateTimeKind.Local).AddTicks(4879));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 21, 13, 59, 23, 539, DateTimeKind.Local).AddTicks(4891));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 21, 13, 59, 23, 539, DateTimeKind.Local).AddTicks(4892));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 21, 13, 59, 23, 539, DateTimeKind.Local).AddTicks(5356));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 21, 13, 59, 23, 539, DateTimeKind.Local).AddTicks(5361));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 21, 13, 59, 23, 539, DateTimeKind.Local).AddTicks(5363));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 21, 13, 59, 23, 539, DateTimeKind.Local).AddTicks(5365));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 21, 13, 59, 23, 539, DateTimeKind.Local).AddTicks(5366));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 21, 13, 59, 23, 539, DateTimeKind.Local).AddTicks(5368));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 21, 13, 59, 23, 539, DateTimeKind.Local).AddTicks(5370));
        }
    }
}
