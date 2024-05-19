using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NPOMS.Repository.Migrations
{
    public partial class Add_UserProgram_And_UserProgramMapping_Tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserProgram",
                schema: "core",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedUserId = table.Column<int>(type: "int", nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProgram", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserProgramMapping",
                schema: "mapping",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ProgramId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    UserProgramId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProgramMapping", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserProgramMapping_UserProgram_UserProgramId",
                        column: x => x.UserProgramId,
                        principalSchema: "core",
                        principalTable: "UserProgram",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserProgramMapping_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "core",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 5, 17, 13, 23, 50, 444, DateTimeKind.Local).AddTicks(388));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 5, 17, 13, 23, 50, 444, DateTimeKind.Local).AddTicks(391));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 5, 17, 13, 23, 50, 444, DateTimeKind.Local).AddTicks(392));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 5, 17, 13, 23, 50, 444, DateTimeKind.Local).AddTicks(394));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDateTime",
                value: new DateTime(2024, 5, 17, 13, 23, 50, 444, DateTimeKind.Local).AddTicks(395));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 5, 17, 13, 23, 50, 444, DateTimeKind.Local).AddTicks(397));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 5, 17, 13, 23, 50, 444, DateTimeKind.Local).AddTicks(399));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 5, 17, 13, 23, 50, 444, DateTimeKind.Local).AddTicks(400));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDateTime",
                value: new DateTime(2024, 5, 17, 13, 23, 50, 444, DateTimeKind.Local).AddTicks(402));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDateTime",
                value: new DateTime(2024, 5, 17, 13, 23, 50, 444, DateTimeKind.Local).AddTicks(403));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDateTime",
                value: new DateTime(2024, 5, 17, 13, 23, 50, 444, DateTimeKind.Local).AddTicks(406));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDateTime",
                value: new DateTime(2024, 5, 17, 13, 23, 50, 444, DateTimeKind.Local).AddTicks(407));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDateTime",
                value: new DateTime(2024, 5, 17, 13, 23, 50, 444, DateTimeKind.Local).AddTicks(409));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDateTime",
                value: new DateTime(2024, 5, 17, 13, 23, 50, 444, DateTimeKind.Local).AddTicks(411));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDateTime",
                value: new DateTime(2024, 5, 17, 13, 23, 50, 444, DateTimeKind.Local).AddTicks(412));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDateTime",
                value: new DateTime(2024, 5, 17, 13, 23, 50, 444, DateTimeKind.Local).AddTicks(413));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDateTime",
                value: new DateTime(2024, 5, 17, 13, 23, 50, 444, DateTimeKind.Local).AddTicks(415));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDateTime",
                value: new DateTime(2024, 5, 17, 13, 23, 50, 444, DateTimeKind.Local).AddTicks(416));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDateTime",
                value: new DateTime(2024, 5, 17, 13, 23, 50, 444, DateTimeKind.Local).AddTicks(417));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDateTime",
                value: new DateTime(2024, 5, 17, 13, 23, 50, 444, DateTimeKind.Local).AddTicks(419));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDateTime",
                value: new DateTime(2024, 5, 17, 13, 23, 50, 444, DateTimeKind.Local).AddTicks(420));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDateTime",
                value: new DateTime(2024, 5, 17, 13, 23, 50, 444, DateTimeKind.Local).AddTicks(436));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDateTime",
                value: new DateTime(2024, 5, 17, 13, 23, 50, 444, DateTimeKind.Local).AddTicks(450));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDateTime",
                value: new DateTime(2024, 5, 17, 13, 23, 50, 444, DateTimeKind.Local).AddTicks(451));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDateTime",
                value: new DateTime(2024, 5, 17, 13, 23, 50, 444, DateTimeKind.Local).AddTicks(453));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDateTime",
                value: new DateTime(2024, 5, 17, 13, 23, 50, 444, DateTimeKind.Local).AddTicks(454));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDateTime",
                value: new DateTime(2024, 5, 17, 13, 23, 50, 444, DateTimeKind.Local).AddTicks(455));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedDateTime",
                value: new DateTime(2024, 5, 17, 13, 23, 50, 444, DateTimeKind.Local).AddTicks(457));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedDateTime",
                value: new DateTime(2024, 5, 17, 13, 23, 50, 444, DateTimeKind.Local).AddTicks(458));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedDateTime",
                value: new DateTime(2024, 5, 17, 13, 23, 50, 444, DateTimeKind.Local).AddTicks(459));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDateTime",
                value: new DateTime(2024, 5, 17, 13, 23, 50, 444, DateTimeKind.Local).AddTicks(461));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedDateTime",
                value: new DateTime(2024, 5, 17, 13, 23, 50, 444, DateTimeKind.Local).AddTicks(462));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 5, 17, 13, 23, 50, 444, DateTimeKind.Local).AddTicks(223));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 5, 17, 13, 23, 50, 444, DateTimeKind.Local).AddTicks(267));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 5, 17, 13, 23, 50, 444, DateTimeKind.Local).AddTicks(269));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 5, 17, 13, 23, 50, 444, DateTimeKind.Local).AddTicks(271));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 5, 17, 13, 23, 50, 444, DateTimeKind.Local).AddTicks(273));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 5, 17, 13, 23, 50, 444, DateTimeKind.Local).AddTicks(275));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 5, 17, 13, 23, 50, 444, DateTimeKind.Local).AddTicks(277));

            migrationBuilder.InsertData(
                schema: "core",
                table: "UserProgram",
                columns: new[] { "Id", "CreatedDateTime", "CreatedUserId", "DepartmentId", "IsActive", "Name", "UpdatedDateTime", "UpdatedUserId" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 7, true, "All", null, null },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 7, true, "Care and Services to Older Persons", null, null },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 7, true, "Care And Support to Families", null, null }
                });

            migrationBuilder.InsertData(
                schema: "core",
                table: "UserProgram",
                columns: new[] { "Id", "CreatedDateTime", "CreatedUserId", "DepartmentId", "IsActive", "Name", "UpdatedDateTime", "UpdatedUserId" },
                values: new object[,]
                {
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 7, true, "Child Care and Protection Services", null, null },
                    { 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 7, true, "Crime Prevention", null, null },
                    { 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 7, true, "EPWP", null, null },
                    { 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 7, true, "Services to persons with Disabilities", null, null },
                    { 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 7, true, "Substance Abuse", null, null },
                    { 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 7, true, "Sustainable Livelihood", null, null },
                    { 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 7, true, "Youth Development", null, null },
                    { 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 7, true, "Facility Management", null, null },
                    { 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 7, true, "Victim Empowerment", null, null },
                    { 13, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 7, true, "Facility Management", null, null },
                    { 14, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 7, true, "ECD & Partial Care", null, null },
                    { 15, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 7, true, "ECD Conditional Grant", null, null },
                    { 16, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 7, true, "Not Available", null, null },
                    { 17, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 7, true, "None", null, null }
                });

            migrationBuilder.InsertData(
                schema: "mapping",
                table: "UserProgramMapping",
                columns: new[] { "Id", "IsActive", "ProgramId", "UserId", "UserProgramId" },
                values: new object[,]
                {
                    { 1, false, 1, 1, null },
                    { 2, false, 1, 2, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserProgramMapping_UserId",
                schema: "mapping",
                table: "UserProgramMapping",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProgramMapping_UserProgramId",
                schema: "mapping",
                table: "UserProgramMapping",
                column: "UserProgramId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserProgramMapping",
                schema: "mapping");

            migrationBuilder.DropTable(
                name: "UserProgram",
                schema: "core");

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 4, 1, 41, 20, 353, DateTimeKind.Local).AddTicks(5934));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 4, 1, 41, 20, 353, DateTimeKind.Local).AddTicks(5937));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 4, 1, 41, 20, 353, DateTimeKind.Local).AddTicks(5938));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 4, 1, 41, 20, 353, DateTimeKind.Local).AddTicks(5939));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 4, 1, 41, 20, 353, DateTimeKind.Local).AddTicks(5940));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 4, 1, 41, 20, 353, DateTimeKind.Local).AddTicks(5941));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 4, 1, 41, 20, 353, DateTimeKind.Local).AddTicks(5942));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 4, 1, 41, 20, 353, DateTimeKind.Local).AddTicks(5943));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 4, 1, 41, 20, 353, DateTimeKind.Local).AddTicks(5944));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 4, 1, 41, 20, 353, DateTimeKind.Local).AddTicks(5945));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 4, 1, 41, 20, 353, DateTimeKind.Local).AddTicks(5946));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 4, 1, 41, 20, 353, DateTimeKind.Local).AddTicks(5947));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 4, 1, 41, 20, 353, DateTimeKind.Local).AddTicks(5948));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 4, 1, 41, 20, 353, DateTimeKind.Local).AddTicks(5949));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 4, 1, 41, 20, 353, DateTimeKind.Local).AddTicks(5950));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 4, 1, 41, 20, 353, DateTimeKind.Local).AddTicks(5950));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 4, 1, 41, 20, 353, DateTimeKind.Local).AddTicks(5951));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 4, 1, 41, 20, 353, DateTimeKind.Local).AddTicks(5952));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 4, 1, 41, 20, 353, DateTimeKind.Local).AddTicks(5953));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 4, 1, 41, 20, 353, DateTimeKind.Local).AddTicks(5954));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 4, 1, 41, 20, 353, DateTimeKind.Local).AddTicks(5961));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 4, 1, 41, 20, 353, DateTimeKind.Local).AddTicks(5963));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 4, 1, 41, 20, 353, DateTimeKind.Local).AddTicks(5967));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 4, 1, 41, 20, 353, DateTimeKind.Local).AddTicks(5979));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 4, 1, 41, 20, 353, DateTimeKind.Local).AddTicks(5980));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 4, 1, 41, 20, 353, DateTimeKind.Local).AddTicks(5981));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 4, 1, 41, 20, 353, DateTimeKind.Local).AddTicks(5982));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 4, 1, 41, 20, 353, DateTimeKind.Local).AddTicks(5983));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 4, 1, 41, 20, 353, DateTimeKind.Local).AddTicks(5984));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 4, 1, 41, 20, 353, DateTimeKind.Local).AddTicks(5985));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 4, 1, 41, 20, 353, DateTimeKind.Local).AddTicks(5987));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 4, 1, 41, 20, 353, DateTimeKind.Local).AddTicks(5988));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 4, 1, 41, 20, 353, DateTimeKind.Local).AddTicks(5832));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 4, 1, 41, 20, 353, DateTimeKind.Local).AddTicks(5847));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 4, 1, 41, 20, 353, DateTimeKind.Local).AddTicks(5849));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 4, 1, 41, 20, 353, DateTimeKind.Local).AddTicks(5850));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 4, 1, 41, 20, 353, DateTimeKind.Local).AddTicks(5873));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 4, 1, 41, 20, 353, DateTimeKind.Local).AddTicks(5874));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 4, 1, 41, 20, 353, DateTimeKind.Local).AddTicks(5876));
        }
    }
}
