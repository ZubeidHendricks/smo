using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NPOMS.Repository.Migrations
{
    /// <inheritdoc />
    public partial class ServiceSubProgramme : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ServicesRenderedId",
                schema: "dropdown",
                table: "SubProgrammeTypes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Service_SubProgramme",
                schema: "mapping",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServicesRenderedId = table.Column<int>(type: "int", nullable: false),
                    SubProgrammeId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service_SubProgramme", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Service_SubProgramme_ServicesRendered_ServicesRenderedId",
                        column: x => x.ServicesRenderedId,
                        principalSchema: "dbo",
                        principalTable: "ServicesRendered",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Service_SubProgramme_SubProgrammes_SubProgrammeId",
                        column: x => x.SubProgrammeId,
                        principalSchema: "dropdown",
                        principalTable: "SubProgrammes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 22, 52, 27, 888, DateTimeKind.Local).AddTicks(6976));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 22, 52, 27, 888, DateTimeKind.Local).AddTicks(6980));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 22, 52, 27, 888, DateTimeKind.Local).AddTicks(6981));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 22, 52, 27, 888, DateTimeKind.Local).AddTicks(7006));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 22, 52, 27, 888, DateTimeKind.Local).AddTicks(7008));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 22, 52, 27, 888, DateTimeKind.Local).AddTicks(7009));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 22, 52, 27, 888, DateTimeKind.Local).AddTicks(7011));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 22, 52, 27, 888, DateTimeKind.Local).AddTicks(7013));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 22, 52, 27, 888, DateTimeKind.Local).AddTicks(7015));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 22, 52, 27, 888, DateTimeKind.Local).AddTicks(7017));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 22, 52, 27, 888, DateTimeKind.Local).AddTicks(7019));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 22, 52, 27, 888, DateTimeKind.Local).AddTicks(7021));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 22, 52, 27, 888, DateTimeKind.Local).AddTicks(7022));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 22, 52, 27, 888, DateTimeKind.Local).AddTicks(7024));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 22, 52, 27, 888, DateTimeKind.Local).AddTicks(7026));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 22, 52, 27, 888, DateTimeKind.Local).AddTicks(7027));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 22, 52, 27, 888, DateTimeKind.Local).AddTicks(7029));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 22, 52, 27, 888, DateTimeKind.Local).AddTicks(7031));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 22, 52, 27, 888, DateTimeKind.Local).AddTicks(7032));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 22, 52, 27, 888, DateTimeKind.Local).AddTicks(7034));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 22, 52, 27, 888, DateTimeKind.Local).AddTicks(7036));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 22, 52, 27, 888, DateTimeKind.Local).AddTicks(7037));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 22, 52, 27, 888, DateTimeKind.Local).AddTicks(7060));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 22, 52, 27, 888, DateTimeKind.Local).AddTicks(7067));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 22, 52, 27, 888, DateTimeKind.Local).AddTicks(7069));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 22, 52, 27, 888, DateTimeKind.Local).AddTicks(7070));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 22, 52, 27, 888, DateTimeKind.Local).AddTicks(7072));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 22, 52, 27, 888, DateTimeKind.Local).AddTicks(7074));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 22, 52, 27, 888, DateTimeKind.Local).AddTicks(7075));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 22, 52, 27, 888, DateTimeKind.Local).AddTicks(7077));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 22, 52, 27, 888, DateTimeKind.Local).AddTicks(7079));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 22, 52, 27, 888, DateTimeKind.Local).AddTicks(7080));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 22, 52, 27, 888, DateTimeKind.Local).AddTicks(6852));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 22, 52, 27, 888, DateTimeKind.Local).AddTicks(6859));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 22, 52, 27, 888, DateTimeKind.Local).AddTicks(6862));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 22, 52, 27, 888, DateTimeKind.Local).AddTicks(6864));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 22, 52, 27, 888, DateTimeKind.Local).AddTicks(6867));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 22, 52, 27, 888, DateTimeKind.Local).AddTicks(6869));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 22, 52, 27, 888, DateTimeKind.Local).AddTicks(6871));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammeTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "ServicesRenderedId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammeTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "ServicesRenderedId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammeTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "ServicesRenderedId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammeTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "ServicesRenderedId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammeTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "ServicesRenderedId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammeTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "ServicesRenderedId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammeTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "ServicesRenderedId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammeTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "ServicesRenderedId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammeTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "ServicesRenderedId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammeTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "ServicesRenderedId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammeTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "ServicesRenderedId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammeTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "ServicesRenderedId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammeTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "ServicesRenderedId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammeTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "ServicesRenderedId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammeTypes",
                keyColumn: "Id",
                keyValue: 15,
                column: "ServicesRenderedId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammeTypes",
                keyColumn: "Id",
                keyValue: 16,
                column: "ServicesRenderedId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammeTypes",
                keyColumn: "Id",
                keyValue: 17,
                column: "ServicesRenderedId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammeTypes",
                keyColumn: "Id",
                keyValue: 18,
                column: "ServicesRenderedId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammeTypes",
                keyColumn: "Id",
                keyValue: 19,
                column: "ServicesRenderedId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammeTypes",
                keyColumn: "Id",
                keyValue: 20,
                column: "ServicesRenderedId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammeTypes",
                keyColumn: "Id",
                keyValue: 21,
                column: "ServicesRenderedId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammeTypes",
                keyColumn: "Id",
                keyValue: 22,
                column: "ServicesRenderedId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammeTypes",
                keyColumn: "Id",
                keyValue: 23,
                column: "ServicesRenderedId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammeTypes",
                keyColumn: "Id",
                keyValue: 24,
                column: "ServicesRenderedId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammeTypes",
                keyColumn: "Id",
                keyValue: 25,
                column: "ServicesRenderedId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammeTypes",
                keyColumn: "Id",
                keyValue: 26,
                column: "ServicesRenderedId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammeTypes",
                keyColumn: "Id",
                keyValue: 27,
                column: "ServicesRenderedId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammeTypes",
                keyColumn: "Id",
                keyValue: 28,
                column: "ServicesRenderedId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammeTypes",
                keyColumn: "Id",
                keyValue: 29,
                column: "ServicesRenderedId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammeTypes",
                keyColumn: "Id",
                keyValue: 30,
                column: "ServicesRenderedId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammeTypes",
                keyColumn: "Id",
                keyValue: 31,
                column: "ServicesRenderedId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammeTypes",
                keyColumn: "Id",
                keyValue: 32,
                column: "ServicesRenderedId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammeTypes",
                keyColumn: "Id",
                keyValue: 33,
                column: "ServicesRenderedId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammeTypes",
                keyColumn: "Id",
                keyValue: 34,
                column: "ServicesRenderedId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammeTypes",
                keyColumn: "Id",
                keyValue: 35,
                column: "ServicesRenderedId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammeTypes",
                keyColumn: "Id",
                keyValue: 36,
                column: "ServicesRenderedId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammeTypes",
                keyColumn: "Id",
                keyValue: 37,
                column: "ServicesRenderedId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammeTypes",
                keyColumn: "Id",
                keyValue: 38,
                column: "ServicesRenderedId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammeTypes",
                keyColumn: "Id",
                keyValue: 39,
                column: "ServicesRenderedId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammeTypes",
                keyColumn: "Id",
                keyValue: 40,
                column: "ServicesRenderedId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammeTypes",
                keyColumn: "Id",
                keyValue: 41,
                column: "ServicesRenderedId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammeTypes",
                keyColumn: "Id",
                keyValue: 42,
                column: "ServicesRenderedId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammeTypes",
                keyColumn: "Id",
                keyValue: 43,
                column: "ServicesRenderedId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammeTypes",
                keyColumn: "Id",
                keyValue: 44,
                column: "ServicesRenderedId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammeTypes",
                keyColumn: "Id",
                keyValue: 45,
                column: "ServicesRenderedId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammeTypes",
                keyColumn: "Id",
                keyValue: 46,
                column: "ServicesRenderedId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammeTypes",
                keyColumn: "Id",
                keyValue: 47,
                column: "ServicesRenderedId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammeTypes",
                keyColumn: "Id",
                keyValue: 48,
                column: "ServicesRenderedId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammeTypes",
                keyColumn: "Id",
                keyValue: 49,
                column: "ServicesRenderedId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammeTypes",
                keyColumn: "Id",
                keyValue: 50,
                column: "ServicesRenderedId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammeTypes",
                keyColumn: "Id",
                keyValue: 51,
                column: "ServicesRenderedId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammeTypes",
                keyColumn: "Id",
                keyValue: 52,
                column: "ServicesRenderedId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammeTypes",
                keyColumn: "Id",
                keyValue: 53,
                column: "ServicesRenderedId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammeTypes",
                keyColumn: "Id",
                keyValue: 54,
                column: "ServicesRenderedId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammeTypes",
                keyColumn: "Id",
                keyValue: 55,
                column: "ServicesRenderedId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammeTypes",
                keyColumn: "Id",
                keyValue: 56,
                column: "ServicesRenderedId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammeTypes",
                keyColumn: "Id",
                keyValue: 57,
                column: "ServicesRenderedId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammeTypes",
                keyColumn: "Id",
                keyValue: 58,
                column: "ServicesRenderedId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammeTypes",
                keyColumn: "Id",
                keyValue: 59,
                column: "ServicesRenderedId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammeTypes",
                keyColumn: "Id",
                keyValue: 60,
                column: "ServicesRenderedId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammeTypes",
                keyColumn: "Id",
                keyValue: 61,
                column: "ServicesRenderedId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammeTypes",
                keyColumn: "Id",
                keyValue: 62,
                column: "ServicesRenderedId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammeTypes",
                keyColumn: "Id",
                keyValue: 63,
                column: "ServicesRenderedId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammeTypes",
                keyColumn: "Id",
                keyValue: 64,
                column: "ServicesRenderedId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammeTypes",
                keyColumn: "Id",
                keyValue: 65,
                column: "ServicesRenderedId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammeTypes",
                keyColumn: "Id",
                keyValue: 66,
                column: "ServicesRenderedId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammeTypes",
                keyColumn: "Id",
                keyValue: 67,
                column: "ServicesRenderedId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammeTypes",
                keyColumn: "Id",
                keyValue: 68,
                column: "ServicesRenderedId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammeTypes",
                keyColumn: "Id",
                keyValue: 69,
                column: "ServicesRenderedId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammeTypes",
                keyColumn: "Id",
                keyValue: 70,
                column: "ServicesRenderedId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammeTypes",
                keyColumn: "Id",
                keyValue: 71,
                column: "ServicesRenderedId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_SubProgrammeTypes_ServicesRenderedId",
                schema: "dropdown",
                table: "SubProgrammeTypes",
                column: "ServicesRenderedId");

            migrationBuilder.CreateIndex(
                name: "IX_Service_SubProgramme_ServicesRenderedId",
                schema: "mapping",
                table: "Service_SubProgramme",
                column: "ServicesRenderedId");

            migrationBuilder.CreateIndex(
                name: "IX_Service_SubProgramme_SubProgrammeId",
                schema: "mapping",
                table: "Service_SubProgramme",
                column: "SubProgrammeId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubProgrammeTypes_ServicesRendered_ServicesRenderedId",
                schema: "dropdown",
                table: "SubProgrammeTypes",
                column: "ServicesRenderedId",
                principalSchema: "dbo",
                principalTable: "ServicesRendered",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubProgrammeTypes_ServicesRendered_ServicesRenderedId",
                schema: "dropdown",
                table: "SubProgrammeTypes");

            migrationBuilder.DropTable(
                name: "Service_SubProgramme",
                schema: "mapping");

            migrationBuilder.DropIndex(
                name: "IX_SubProgrammeTypes_ServicesRenderedId",
                schema: "dropdown",
                table: "SubProgrammeTypes");

            migrationBuilder.DropColumn(
                name: "ServicesRenderedId",
                schema: "dropdown",
                table: "SubProgrammeTypes");

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 11, 41, 12, 504, DateTimeKind.Local).AddTicks(4232));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 11, 41, 12, 504, DateTimeKind.Local).AddTicks(4236));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 11, 41, 12, 504, DateTimeKind.Local).AddTicks(4237));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 11, 41, 12, 504, DateTimeKind.Local).AddTicks(4239));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 11, 41, 12, 504, DateTimeKind.Local).AddTicks(4241));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 11, 41, 12, 504, DateTimeKind.Local).AddTicks(4242));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 11, 41, 12, 504, DateTimeKind.Local).AddTicks(4244));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 11, 41, 12, 504, DateTimeKind.Local).AddTicks(4245));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 11, 41, 12, 504, DateTimeKind.Local).AddTicks(4247));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 11, 41, 12, 504, DateTimeKind.Local).AddTicks(4249));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 11, 41, 12, 504, DateTimeKind.Local).AddTicks(4251));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 11, 41, 12, 504, DateTimeKind.Local).AddTicks(4252));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 11, 41, 12, 504, DateTimeKind.Local).AddTicks(4254));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 11, 41, 12, 504, DateTimeKind.Local).AddTicks(4255));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 11, 41, 12, 504, DateTimeKind.Local).AddTicks(4257));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 11, 41, 12, 504, DateTimeKind.Local).AddTicks(4258));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 11, 41, 12, 504, DateTimeKind.Local).AddTicks(4260));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 11, 41, 12, 504, DateTimeKind.Local).AddTicks(4261));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 11, 41, 12, 504, DateTimeKind.Local).AddTicks(4263));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 11, 41, 12, 504, DateTimeKind.Local).AddTicks(4264));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 11, 41, 12, 504, DateTimeKind.Local).AddTicks(4266));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 11, 41, 12, 504, DateTimeKind.Local).AddTicks(4268));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 11, 41, 12, 504, DateTimeKind.Local).AddTicks(4284));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 11, 41, 12, 504, DateTimeKind.Local).AddTicks(4367));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 11, 41, 12, 504, DateTimeKind.Local).AddTicks(4369));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 11, 41, 12, 504, DateTimeKind.Local).AddTicks(4371));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 11, 41, 12, 504, DateTimeKind.Local).AddTicks(4372));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 11, 41, 12, 504, DateTimeKind.Local).AddTicks(4374));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 11, 41, 12, 504, DateTimeKind.Local).AddTicks(4375));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 11, 41, 12, 504, DateTimeKind.Local).AddTicks(4377));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 11, 41, 12, 504, DateTimeKind.Local).AddTicks(4378));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 11, 41, 12, 504, DateTimeKind.Local).AddTicks(4380));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 11, 41, 12, 504, DateTimeKind.Local).AddTicks(3974));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 11, 41, 12, 504, DateTimeKind.Local).AddTicks(3998));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 11, 41, 12, 504, DateTimeKind.Local).AddTicks(4000));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 11, 41, 12, 504, DateTimeKind.Local).AddTicks(4002));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 11, 41, 12, 504, DateTimeKind.Local).AddTicks(4005));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 11, 41, 12, 504, DateTimeKind.Local).AddTicks(4007));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 11, 41, 12, 504, DateTimeKind.Local).AddTicks(4009));
        }
    }
}
