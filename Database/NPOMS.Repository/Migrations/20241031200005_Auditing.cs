using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NPOMS.Repository.Migrations
{
    /// <inheritdoc />
    public partial class Auditing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Comments",
                table: "SDIPReports",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Comments",
                schema: "dbo",
                table: "PostReports",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Comments",
                schema: "dbo",
                table: "IndicatorReports",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Comments",
                schema: "dbo",
                table: "IncomeAndExpenditureReports",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReportComments",
                schema: "dbo",
                table: "GovernanceReports",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Comments",
                schema: "dbo",
                table: "AnyOtherInformationReports",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AnyOtherReportAudits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnyOtherInformationReportId = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnyOtherReportAudits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnyOtherReportAudits_AnyOtherInformationReports_AnyOtherInformationReportId",
                        column: x => x.AnyOtherInformationReportId,
                        principalSchema: "dbo",
                        principalTable: "AnyOtherInformationReports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GovernanceAudits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GovernanceReportId = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GovernanceAudits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GovernanceAudits_GovernanceReports_GovernanceReportId",
                        column: x => x.GovernanceReportId,
                        principalSchema: "dbo",
                        principalTable: "GovernanceReports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IncomeReportAudit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IncomeAndExpenditureReportId = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncomeReportAudit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IncomeReportAudit_IncomeAndExpenditureReports_IncomeAndExpenditureReportId",
                        column: x => x.IncomeAndExpenditureReportId,
                        principalSchema: "dbo",
                        principalTable: "IncomeAndExpenditureReports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IndicatorReportAudits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IndicatorReportId = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndicatorReportAudits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IndicatorReportAudits_IndicatorReports_IndicatorReportId",
                        column: x => x.IndicatorReportId,
                        principalSchema: "dbo",
                        principalTable: "IndicatorReports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PostAudits",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostReportId = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostAudits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostAudits_PostReports_PostReportId",
                        column: x => x.PostReportId,
                        principalSchema: "dbo",
                        principalTable: "PostReports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SDIPReportAudits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SDIPReportId = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SDIPReportAudits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SDIPReportAudits_SDIPReports_SDIPReportId",
                        column: x => x.SDIPReportId,
                        principalTable: "SDIPReports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 31, 21, 59, 55, 480, DateTimeKind.Local).AddTicks(8753));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 31, 21, 59, 55, 480, DateTimeKind.Local).AddTicks(8836));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 31, 21, 59, 55, 480, DateTimeKind.Local).AddTicks(8838));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 31, 21, 59, 55, 480, DateTimeKind.Local).AddTicks(8840));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 31, 21, 59, 55, 480, DateTimeKind.Local).AddTicks(8841));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 31, 21, 59, 55, 480, DateTimeKind.Local).AddTicks(8843));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 31, 21, 59, 55, 480, DateTimeKind.Local).AddTicks(8845));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 31, 21, 59, 55, 480, DateTimeKind.Local).AddTicks(8846));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 31, 21, 59, 55, 480, DateTimeKind.Local).AddTicks(8848));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 31, 21, 59, 55, 480, DateTimeKind.Local).AddTicks(8850));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 31, 21, 59, 55, 480, DateTimeKind.Local).AddTicks(8851));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 31, 21, 59, 55, 480, DateTimeKind.Local).AddTicks(8853));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 31, 21, 59, 55, 480, DateTimeKind.Local).AddTicks(8855));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 31, 21, 59, 55, 480, DateTimeKind.Local).AddTicks(8857));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 31, 21, 59, 55, 480, DateTimeKind.Local).AddTicks(8859));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 31, 21, 59, 55, 480, DateTimeKind.Local).AddTicks(8861));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 31, 21, 59, 55, 480, DateTimeKind.Local).AddTicks(8862));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 31, 21, 59, 55, 480, DateTimeKind.Local).AddTicks(8864));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 31, 21, 59, 55, 480, DateTimeKind.Local).AddTicks(8866));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 31, 21, 59, 55, 480, DateTimeKind.Local).AddTicks(8867));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 31, 21, 59, 55, 480, DateTimeKind.Local).AddTicks(8869));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 31, 21, 59, 55, 480, DateTimeKind.Local).AddTicks(8870));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 31, 21, 59, 55, 480, DateTimeKind.Local).AddTicks(8872));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 31, 21, 59, 55, 480, DateTimeKind.Local).AddTicks(8884));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 31, 21, 59, 55, 480, DateTimeKind.Local).AddTicks(8885));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 31, 21, 59, 55, 480, DateTimeKind.Local).AddTicks(8887));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 31, 21, 59, 55, 480, DateTimeKind.Local).AddTicks(8888));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 31, 21, 59, 55, 480, DateTimeKind.Local).AddTicks(8900));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 31, 21, 59, 55, 480, DateTimeKind.Local).AddTicks(8902));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 31, 21, 59, 55, 480, DateTimeKind.Local).AddTicks(8907));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 31, 21, 59, 55, 480, DateTimeKind.Local).AddTicks(8923));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 31, 21, 59, 55, 480, DateTimeKind.Local).AddTicks(8925));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 31, 21, 59, 55, 480, DateTimeKind.Local).AddTicks(9859));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 31, 21, 59, 55, 480, DateTimeKind.Local).AddTicks(9867));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 31, 21, 59, 55, 480, DateTimeKind.Local).AddTicks(9870));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 31, 21, 59, 55, 480, DateTimeKind.Local).AddTicks(9872));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 31, 21, 59, 55, 480, DateTimeKind.Local).AddTicks(9874));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 31, 21, 59, 55, 480, DateTimeKind.Local).AddTicks(9877));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 31, 21, 59, 55, 480, DateTimeKind.Local).AddTicks(9879));

            migrationBuilder.CreateIndex(
                name: "IX_AnyOtherReportAudits_AnyOtherInformationReportId",
                table: "AnyOtherReportAudits",
                column: "AnyOtherInformationReportId");

            migrationBuilder.CreateIndex(
                name: "IX_GovernanceAudits_GovernanceReportId",
                table: "GovernanceAudits",
                column: "GovernanceReportId");

            migrationBuilder.CreateIndex(
                name: "IX_IncomeReportAudit_IncomeAndExpenditureReportId",
                table: "IncomeReportAudit",
                column: "IncomeAndExpenditureReportId");

            migrationBuilder.CreateIndex(
                name: "IX_IndicatorReportAudits_IndicatorReportId",
                table: "IndicatorReportAudits",
                column: "IndicatorReportId");

            migrationBuilder.CreateIndex(
                name: "IX_PostAudits_PostReportId",
                schema: "dbo",
                table: "PostAudits",
                column: "PostReportId");

            migrationBuilder.CreateIndex(
                name: "IX_SDIPReportAudits_SDIPReportId",
                table: "SDIPReportAudits",
                column: "SDIPReportId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnyOtherReportAudits");

            migrationBuilder.DropTable(
                name: "GovernanceAudits");

            migrationBuilder.DropTable(
                name: "IncomeReportAudit");

            migrationBuilder.DropTable(
                name: "IndicatorReportAudits");

            migrationBuilder.DropTable(
                name: "PostAudits",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "SDIPReportAudits");

            migrationBuilder.DropColumn(
                name: "Comments",
                table: "SDIPReports");

            migrationBuilder.DropColumn(
                name: "Comments",
                schema: "dbo",
                table: "PostReports");

            migrationBuilder.DropColumn(
                name: "Comments",
                schema: "dbo",
                table: "IndicatorReports");

            migrationBuilder.DropColumn(
                name: "Comments",
                schema: "dbo",
                table: "IncomeAndExpenditureReports");

            migrationBuilder.DropColumn(
                name: "ReportComments",
                schema: "dbo",
                table: "GovernanceReports");

            migrationBuilder.DropColumn(
                name: "Comments",
                schema: "dbo",
                table: "AnyOtherInformationReports");

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 28, 23, 46, 56, 104, DateTimeKind.Local).AddTicks(7136));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 28, 23, 46, 56, 104, DateTimeKind.Local).AddTicks(7161));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 28, 23, 46, 56, 104, DateTimeKind.Local).AddTicks(7163));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 28, 23, 46, 56, 104, DateTimeKind.Local).AddTicks(7166));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 28, 23, 46, 56, 104, DateTimeKind.Local).AddTicks(7168));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 28, 23, 46, 56, 104, DateTimeKind.Local).AddTicks(7173));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 28, 23, 46, 56, 104, DateTimeKind.Local).AddTicks(7175));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 28, 23, 46, 56, 104, DateTimeKind.Local).AddTicks(7177));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 28, 23, 46, 56, 104, DateTimeKind.Local).AddTicks(7179));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 28, 23, 46, 56, 104, DateTimeKind.Local).AddTicks(7181));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 28, 23, 46, 56, 104, DateTimeKind.Local).AddTicks(7182));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 28, 23, 46, 56, 104, DateTimeKind.Local).AddTicks(7184));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 28, 23, 46, 56, 104, DateTimeKind.Local).AddTicks(7186));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 28, 23, 46, 56, 104, DateTimeKind.Local).AddTicks(7188));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 28, 23, 46, 56, 104, DateTimeKind.Local).AddTicks(7190));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 28, 23, 46, 56, 104, DateTimeKind.Local).AddTicks(7192));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 28, 23, 46, 56, 104, DateTimeKind.Local).AddTicks(7194));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 28, 23, 46, 56, 104, DateTimeKind.Local).AddTicks(7196));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 28, 23, 46, 56, 104, DateTimeKind.Local).AddTicks(7198));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 28, 23, 46, 56, 104, DateTimeKind.Local).AddTicks(7200));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 28, 23, 46, 56, 104, DateTimeKind.Local).AddTicks(7202));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 28, 23, 46, 56, 104, DateTimeKind.Local).AddTicks(7212));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 28, 23, 46, 56, 104, DateTimeKind.Local).AddTicks(7214));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 28, 23, 46, 56, 104, DateTimeKind.Local).AddTicks(7216));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 28, 23, 46, 56, 104, DateTimeKind.Local).AddTicks(7218));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 28, 23, 46, 56, 104, DateTimeKind.Local).AddTicks(7220));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 28, 23, 46, 56, 104, DateTimeKind.Local).AddTicks(7222));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 28, 23, 46, 56, 104, DateTimeKind.Local).AddTicks(7224));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 28, 23, 46, 56, 104, DateTimeKind.Local).AddTicks(7225));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 28, 23, 46, 56, 104, DateTimeKind.Local).AddTicks(7231));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 28, 23, 46, 56, 104, DateTimeKind.Local).AddTicks(7256));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 28, 23, 46, 56, 104, DateTimeKind.Local).AddTicks(7259));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 28, 23, 46, 56, 104, DateTimeKind.Local).AddTicks(7882));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 28, 23, 46, 56, 104, DateTimeKind.Local).AddTicks(7886));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 28, 23, 46, 56, 104, DateTimeKind.Local).AddTicks(7889));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 28, 23, 46, 56, 104, DateTimeKind.Local).AddTicks(7892));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 28, 23, 46, 56, 104, DateTimeKind.Local).AddTicks(7895));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 28, 23, 46, 56, 104, DateTimeKind.Local).AddTicks(7898));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 28, 23, 46, 56, 104, DateTimeKind.Local).AddTicks(7901));
        }
    }
}
