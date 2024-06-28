using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NPOMS.Repository.Migrations
{
    /// <inheritdoc />
    public partial class SubProgrammeTypeUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubProgrammeTypes_ServicesRendered_ServicesRenderedId",
                schema: "dropdown",
                table: "SubProgrammeTypes");

            migrationBuilder.DropIndex(
                name: "IX_SubProgrammeTypes_ServicesRenderedId",
                schema: "dropdown",
                table: "SubProgrammeTypes");

            migrationBuilder.DropColumn(
                name: "ServicesRenderedId",
                schema: "dropdown",
                table: "SubProgrammeTypes");

            migrationBuilder.CreateTable(
                name: "Service_ProgrammeType",
                schema: "mapping",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServicesRenderedId = table.Column<int>(type: "int", nullable: false),
                    SubProgrammeTypeId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service_ProgrammeType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Service_ProgrammeType_ServicesRendered_ServicesRenderedId",
                        column: x => x.ServicesRenderedId,
                        principalSchema: "dbo",
                        principalTable: "ServicesRendered",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Service_ProgrammeType_SubProgrammeTypes_SubProgrammeTypeId",
                        column: x => x.SubProgrammeTypeId,
                        principalSchema: "dropdown",
                        principalTable: "SubProgrammeTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 23, 32, 15, 858, DateTimeKind.Local).AddTicks(4196));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 23, 32, 15, 858, DateTimeKind.Local).AddTicks(4198));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 23, 32, 15, 858, DateTimeKind.Local).AddTicks(4200));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 23, 32, 15, 858, DateTimeKind.Local).AddTicks(4202));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 23, 32, 15, 858, DateTimeKind.Local).AddTicks(4204));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 23, 32, 15, 858, DateTimeKind.Local).AddTicks(4206));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 23, 32, 15, 858, DateTimeKind.Local).AddTicks(4207));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 23, 32, 15, 858, DateTimeKind.Local).AddTicks(4209));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 23, 32, 15, 858, DateTimeKind.Local).AddTicks(4211));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 23, 32, 15, 858, DateTimeKind.Local).AddTicks(4213));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 23, 32, 15, 858, DateTimeKind.Local).AddTicks(4214));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 23, 32, 15, 858, DateTimeKind.Local).AddTicks(4216));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 23, 32, 15, 858, DateTimeKind.Local).AddTicks(4218));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 23, 32, 15, 858, DateTimeKind.Local).AddTicks(4220));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 23, 32, 15, 858, DateTimeKind.Local).AddTicks(4221));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 23, 32, 15, 858, DateTimeKind.Local).AddTicks(4223));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 23, 32, 15, 858, DateTimeKind.Local).AddTicks(4225));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 23, 32, 15, 858, DateTimeKind.Local).AddTicks(4227));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 23, 32, 15, 858, DateTimeKind.Local).AddTicks(4228));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 23, 32, 15, 858, DateTimeKind.Local).AddTicks(4230));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 23, 32, 15, 858, DateTimeKind.Local).AddTicks(4232));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 23, 32, 15, 858, DateTimeKind.Local).AddTicks(4233));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 23, 32, 15, 858, DateTimeKind.Local).AddTicks(4251));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 23, 32, 15, 858, DateTimeKind.Local).AddTicks(4259));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 23, 32, 15, 858, DateTimeKind.Local).AddTicks(4260));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 23, 32, 15, 858, DateTimeKind.Local).AddTicks(4262));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 23, 32, 15, 858, DateTimeKind.Local).AddTicks(4264));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 23, 32, 15, 858, DateTimeKind.Local).AddTicks(4266));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 23, 32, 15, 858, DateTimeKind.Local).AddTicks(4267));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 23, 32, 15, 858, DateTimeKind.Local).AddTicks(4269));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 23, 32, 15, 858, DateTimeKind.Local).AddTicks(4271));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 23, 32, 15, 858, DateTimeKind.Local).AddTicks(4272));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 23, 32, 15, 858, DateTimeKind.Local).AddTicks(3992));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 23, 32, 15, 858, DateTimeKind.Local).AddTicks(4001));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 23, 32, 15, 858, DateTimeKind.Local).AddTicks(4004));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 23, 32, 15, 858, DateTimeKind.Local).AddTicks(4006));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 23, 32, 15, 858, DateTimeKind.Local).AddTicks(4009));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 23, 32, 15, 858, DateTimeKind.Local).AddTicks(4011));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 23, 32, 15, 858, DateTimeKind.Local).AddTicks(4014));

            migrationBuilder.CreateIndex(
                name: "IX_Service_ProgrammeType_ServicesRenderedId",
                schema: "mapping",
                table: "Service_ProgrammeType",
                column: "ServicesRenderedId");

            migrationBuilder.CreateIndex(
                name: "IX_Service_ProgrammeType_SubProgrammeTypeId",
                schema: "mapping",
                table: "Service_ProgrammeType",
                column: "SubProgrammeTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Service_ProgrammeType",
                schema: "mapping");

            migrationBuilder.AddColumn<int>(
                name: "ServicesRenderedId",
                schema: "dropdown",
                table: "SubProgrammeTypes",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 23, 11, 15, 129, DateTimeKind.Local).AddTicks(2366));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 23, 11, 15, 129, DateTimeKind.Local).AddTicks(2368));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 23, 11, 15, 129, DateTimeKind.Local).AddTicks(2370));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 23, 11, 15, 129, DateTimeKind.Local).AddTicks(2372));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 23, 11, 15, 129, DateTimeKind.Local).AddTicks(2373));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 23, 11, 15, 129, DateTimeKind.Local).AddTicks(2374));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 23, 11, 15, 129, DateTimeKind.Local).AddTicks(2376));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 23, 11, 15, 129, DateTimeKind.Local).AddTicks(2377));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 23, 11, 15, 129, DateTimeKind.Local).AddTicks(2378));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 23, 11, 15, 129, DateTimeKind.Local).AddTicks(2382));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 23, 11, 15, 129, DateTimeKind.Local).AddTicks(2383));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 23, 11, 15, 129, DateTimeKind.Local).AddTicks(2384));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 23, 11, 15, 129, DateTimeKind.Local).AddTicks(2386));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 23, 11, 15, 129, DateTimeKind.Local).AddTicks(2387));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 23, 11, 15, 129, DateTimeKind.Local).AddTicks(2388));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 23, 11, 15, 129, DateTimeKind.Local).AddTicks(2390));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 23, 11, 15, 129, DateTimeKind.Local).AddTicks(2391));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 23, 11, 15, 129, DateTimeKind.Local).AddTicks(2392));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 23, 11, 15, 129, DateTimeKind.Local).AddTicks(2394));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 23, 11, 15, 129, DateTimeKind.Local).AddTicks(2395));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 23, 11, 15, 129, DateTimeKind.Local).AddTicks(2397));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 23, 11, 15, 129, DateTimeKind.Local).AddTicks(2398));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 23, 11, 15, 129, DateTimeKind.Local).AddTicks(2405));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 23, 11, 15, 129, DateTimeKind.Local).AddTicks(2412));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 23, 11, 15, 129, DateTimeKind.Local).AddTicks(2413));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 23, 11, 15, 129, DateTimeKind.Local).AddTicks(2415));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 23, 11, 15, 129, DateTimeKind.Local).AddTicks(2416));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 23, 11, 15, 129, DateTimeKind.Local).AddTicks(2417));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 23, 11, 15, 129, DateTimeKind.Local).AddTicks(2419));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 23, 11, 15, 129, DateTimeKind.Local).AddTicks(2420));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 23, 11, 15, 129, DateTimeKind.Local).AddTicks(2422));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 23, 11, 15, 129, DateTimeKind.Local).AddTicks(2423));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 23, 11, 15, 129, DateTimeKind.Local).AddTicks(2204));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 23, 11, 15, 129, DateTimeKind.Local).AddTicks(2244));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 23, 11, 15, 129, DateTimeKind.Local).AddTicks(2247));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 23, 11, 15, 129, DateTimeKind.Local).AddTicks(2249));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 23, 11, 15, 129, DateTimeKind.Local).AddTicks(2251));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 23, 11, 15, 129, DateTimeKind.Local).AddTicks(2253));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 6, 13, 23, 11, 15, 129, DateTimeKind.Local).AddTicks(2254));

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

            migrationBuilder.AddForeignKey(
                name: "FK_SubProgrammeTypes_ServicesRendered_ServicesRenderedId",
                schema: "dropdown",
                table: "SubProgrammeTypes",
                column: "ServicesRenderedId",
                principalSchema: "dbo",
                principalTable: "ServicesRendered",
                principalColumn: "Id");
        }
    }
}
