using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NPOMS.Repository.Migrations
{
    /// <inheritdoc />
    public partial class controlTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Control",
                schema: "dbo",
                columns: table => new
                {
                    ControlID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedUserID = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1"),
                    UpdatedUserID = table.Column<int>(type: "int", nullable: true),
                    CreatedDateTimestamp = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
                    UpdatedDateTimestamp = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    User1Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Control", x => x.ControlID);
                    table.ForeignKey(
                        name: "FK_Control_Users_User1Id",
                        column: x => x.User1Id,
                        principalSchema: "core",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Control_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "core",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 26, 13, 52, 49, 930, DateTimeKind.Local).AddTicks(8291));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 26, 13, 52, 49, 930, DateTimeKind.Local).AddTicks(8312));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 26, 13, 52, 49, 930, DateTimeKind.Local).AddTicks(8314));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 26, 13, 52, 49, 930, DateTimeKind.Local).AddTicks(8315));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 26, 13, 52, 49, 930, DateTimeKind.Local).AddTicks(8317));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 26, 13, 52, 49, 930, DateTimeKind.Local).AddTicks(8318));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 26, 13, 52, 49, 930, DateTimeKind.Local).AddTicks(8320));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 26, 13, 52, 49, 930, DateTimeKind.Local).AddTicks(8321));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 26, 13, 52, 49, 930, DateTimeKind.Local).AddTicks(8323));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 26, 13, 52, 49, 930, DateTimeKind.Local).AddTicks(8324));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 26, 13, 52, 49, 930, DateTimeKind.Local).AddTicks(8326));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 26, 13, 52, 49, 930, DateTimeKind.Local).AddTicks(8327));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 26, 13, 52, 49, 930, DateTimeKind.Local).AddTicks(8328));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 26, 13, 52, 49, 930, DateTimeKind.Local).AddTicks(8330));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 26, 13, 52, 49, 930, DateTimeKind.Local).AddTicks(8331));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 26, 13, 52, 49, 930, DateTimeKind.Local).AddTicks(8333));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 26, 13, 52, 49, 930, DateTimeKind.Local).AddTicks(8334));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 26, 13, 52, 49, 930, DateTimeKind.Local).AddTicks(8336));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 26, 13, 52, 49, 930, DateTimeKind.Local).AddTicks(8337));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 26, 13, 52, 49, 930, DateTimeKind.Local).AddTicks(8338));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 26, 13, 52, 49, 930, DateTimeKind.Local).AddTicks(8340));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 26, 13, 52, 49, 930, DateTimeKind.Local).AddTicks(8341));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 26, 13, 52, 49, 930, DateTimeKind.Local).AddTicks(8342));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 26, 13, 52, 49, 930, DateTimeKind.Local).AddTicks(8344));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 26, 13, 52, 49, 930, DateTimeKind.Local).AddTicks(8345));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 26, 13, 52, 49, 930, DateTimeKind.Local).AddTicks(8347));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 26, 13, 52, 49, 930, DateTimeKind.Local).AddTicks(8353));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 26, 13, 52, 49, 930, DateTimeKind.Local).AddTicks(8360));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 26, 13, 52, 49, 930, DateTimeKind.Local).AddTicks(8362));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 26, 13, 52, 49, 930, DateTimeKind.Local).AddTicks(8368));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 26, 13, 52, 49, 930, DateTimeKind.Local).AddTicks(8382));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 26, 13, 52, 49, 930, DateTimeKind.Local).AddTicks(8384));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 26, 13, 52, 49, 930, DateTimeKind.Local).AddTicks(8857));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 26, 13, 52, 49, 930, DateTimeKind.Local).AddTicks(8860));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 26, 13, 52, 49, 930, DateTimeKind.Local).AddTicks(8862));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 26, 13, 52, 49, 930, DateTimeKind.Local).AddTicks(8864));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 26, 13, 52, 49, 930, DateTimeKind.Local).AddTicks(8866));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 26, 13, 52, 49, 930, DateTimeKind.Local).AddTicks(8868));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 26, 13, 52, 49, 930, DateTimeKind.Local).AddTicks(8869));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "QuestionCategories",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 26, 13, 52, 49, 934, DateTimeKind.Local).AddTicks(4062));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "QuestionSections",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 26, 11, 52, 49, 934, DateTimeKind.Utc).AddTicks(8300));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "QuestionSections",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 26, 11, 52, 49, 934, DateTimeKind.Utc).AddTicks(8301));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "Questions",
                keyColumn: "Id",
                keyValue: 119,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 26, 11, 52, 49, 934, DateTimeKind.Utc).AddTicks(5457));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "Questions",
                keyColumn: "Id",
                keyValue: 120,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 26, 11, 52, 49, 934, DateTimeKind.Utc).AddTicks(5459));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "Questions",
                keyColumn: "Id",
                keyValue: 121,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 26, 11, 52, 49, 934, DateTimeKind.Utc).AddTicks(5460));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "Questions",
                keyColumn: "Id",
                keyValue: 122,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 26, 11, 52, 49, 934, DateTimeKind.Utc).AddTicks(5461));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseOptions",
                keyColumn: "Id",
                keyValue: 97,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 26, 11, 52, 49, 935, DateTimeKind.Utc).AddTicks(1054));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseOptions",
                keyColumn: "Id",
                keyValue: 100,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 26, 11, 52, 49, 935, DateTimeKind.Utc).AddTicks(1057));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseOptions",
                keyColumn: "Id",
                keyValue: 101,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 26, 11, 52, 49, 935, DateTimeKind.Utc).AddTicks(1058));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseOptions",
                keyColumn: "Id",
                keyValue: 102,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 26, 11, 52, 49, 935, DateTimeKind.Utc).AddTicks(1059));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseOptions",
                keyColumn: "Id",
                keyValue: 103,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 26, 11, 52, 49, 935, DateTimeKind.Utc).AddTicks(1067));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 26, 13, 52, 49, 935, DateTimeKind.Local).AddTicks(2640));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 26, 13, 52, 49, 935, DateTimeKind.Local).AddTicks(2647));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 26, 13, 52, 49, 935, DateTimeKind.Local).AddTicks(2648));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 26, 13, 52, 49, 935, DateTimeKind.Local).AddTicks(2649));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 26, 13, 52, 49, 935, DateTimeKind.Local).AddTicks(2650));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseTypes",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 26, 13, 52, 49, 935, DateTimeKind.Local).AddTicks(2651));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseTypes",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 26, 13, 52, 49, 935, DateTimeKind.Local).AddTicks(2652));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseTypes",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 26, 13, 52, 49, 935, DateTimeKind.Local).AddTicks(2653));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseTypes",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 26, 13, 52, 49, 935, DateTimeKind.Local).AddTicks(2654));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseTypes",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 26, 13, 52, 49, 935, DateTimeKind.Local).AddTicks(2655));

            migrationBuilder.CreateIndex(
                name: "IX_Control_User1Id",
                schema: "dbo",
                table: "Control",
                column: "User1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Control_UserId",
                schema: "dbo",
                table: "Control",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Control",
                schema: "dbo");

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 21, 13, 36, 56, 918, DateTimeKind.Local).AddTicks(1066));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 21, 13, 36, 56, 918, DateTimeKind.Local).AddTicks(1087));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 21, 13, 36, 56, 918, DateTimeKind.Local).AddTicks(1089));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 21, 13, 36, 56, 918, DateTimeKind.Local).AddTicks(1091));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 21, 13, 36, 56, 918, DateTimeKind.Local).AddTicks(1093));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 21, 13, 36, 56, 918, DateTimeKind.Local).AddTicks(1100));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 21, 13, 36, 56, 918, DateTimeKind.Local).AddTicks(1102));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 21, 13, 36, 56, 918, DateTimeKind.Local).AddTicks(1104));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 21, 13, 36, 56, 918, DateTimeKind.Local).AddTicks(1106));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 21, 13, 36, 56, 918, DateTimeKind.Local).AddTicks(1108));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 21, 13, 36, 56, 918, DateTimeKind.Local).AddTicks(1110));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 21, 13, 36, 56, 918, DateTimeKind.Local).AddTicks(1112));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 21, 13, 36, 56, 918, DateTimeKind.Local).AddTicks(1114));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 21, 13, 36, 56, 918, DateTimeKind.Local).AddTicks(1115));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 21, 13, 36, 56, 918, DateTimeKind.Local).AddTicks(1117));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 21, 13, 36, 56, 918, DateTimeKind.Local).AddTicks(1119));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 21, 13, 36, 56, 918, DateTimeKind.Local).AddTicks(1121));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 21, 13, 36, 56, 918, DateTimeKind.Local).AddTicks(1123));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 21, 13, 36, 56, 918, DateTimeKind.Local).AddTicks(1124));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 21, 13, 36, 56, 918, DateTimeKind.Local).AddTicks(1126));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 21, 13, 36, 56, 918, DateTimeKind.Local).AddTicks(1128));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 21, 13, 36, 56, 918, DateTimeKind.Local).AddTicks(1130));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 21, 13, 36, 56, 918, DateTimeKind.Local).AddTicks(1131));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 21, 13, 36, 56, 918, DateTimeKind.Local).AddTicks(1133));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 21, 13, 36, 56, 918, DateTimeKind.Local).AddTicks(1135));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 21, 13, 36, 56, 918, DateTimeKind.Local).AddTicks(1137));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 21, 13, 36, 56, 918, DateTimeKind.Local).AddTicks(1139));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 21, 13, 36, 56, 918, DateTimeKind.Local).AddTicks(1153));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 21, 13, 36, 56, 918, DateTimeKind.Local).AddTicks(1155));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 21, 13, 36, 56, 918, DateTimeKind.Local).AddTicks(1160));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 21, 13, 36, 56, 918, DateTimeKind.Local).AddTicks(1177));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 21, 13, 36, 56, 918, DateTimeKind.Local).AddTicks(1178));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 21, 13, 36, 56, 918, DateTimeKind.Local).AddTicks(1754));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 21, 13, 36, 56, 918, DateTimeKind.Local).AddTicks(1758));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 21, 13, 36, 56, 918, DateTimeKind.Local).AddTicks(1761));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 21, 13, 36, 56, 918, DateTimeKind.Local).AddTicks(1764));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 21, 13, 36, 56, 918, DateTimeKind.Local).AddTicks(1767));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 21, 13, 36, 56, 918, DateTimeKind.Local).AddTicks(1769));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 21, 13, 36, 56, 918, DateTimeKind.Local).AddTicks(1772));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "QuestionCategories",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 21, 13, 36, 56, 923, DateTimeKind.Local).AddTicks(2560));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "QuestionSections",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 21, 11, 36, 56, 923, DateTimeKind.Utc).AddTicks(9535));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "QuestionSections",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 21, 11, 36, 56, 923, DateTimeKind.Utc).AddTicks(9537));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "Questions",
                keyColumn: "Id",
                keyValue: 119,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 21, 11, 36, 56, 923, DateTimeKind.Utc).AddTicks(4740));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "Questions",
                keyColumn: "Id",
                keyValue: 120,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 21, 11, 36, 56, 923, DateTimeKind.Utc).AddTicks(4742));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "Questions",
                keyColumn: "Id",
                keyValue: 121,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 21, 11, 36, 56, 923, DateTimeKind.Utc).AddTicks(4743));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "Questions",
                keyColumn: "Id",
                keyValue: 122,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 21, 11, 36, 56, 923, DateTimeKind.Utc).AddTicks(4745));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseOptions",
                keyColumn: "Id",
                keyValue: 97,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 21, 11, 36, 56, 924, DateTimeKind.Utc).AddTicks(3488));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseOptions",
                keyColumn: "Id",
                keyValue: 100,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 21, 11, 36, 56, 924, DateTimeKind.Utc).AddTicks(3492));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseOptions",
                keyColumn: "Id",
                keyValue: 101,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 21, 11, 36, 56, 924, DateTimeKind.Utc).AddTicks(3569));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseOptions",
                keyColumn: "Id",
                keyValue: 102,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 21, 11, 36, 56, 924, DateTimeKind.Utc).AddTicks(3571));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseOptions",
                keyColumn: "Id",
                keyValue: 103,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 21, 11, 36, 56, 924, DateTimeKind.Utc).AddTicks(3572));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 21, 13, 36, 56, 924, DateTimeKind.Local).AddTicks(6214));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 21, 13, 36, 56, 924, DateTimeKind.Local).AddTicks(6230));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 21, 13, 36, 56, 924, DateTimeKind.Local).AddTicks(6231));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 21, 13, 36, 56, 924, DateTimeKind.Local).AddTicks(6233));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 21, 13, 36, 56, 924, DateTimeKind.Local).AddTicks(6234));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseTypes",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 21, 13, 36, 56, 924, DateTimeKind.Local).AddTicks(6236));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseTypes",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 21, 13, 36, 56, 924, DateTimeKind.Local).AddTicks(6237));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseTypes",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 21, 13, 36, 56, 924, DateTimeKind.Local).AddTicks(6239));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseTypes",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 21, 13, 36, 56, 924, DateTimeKind.Local).AddTicks(6240));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseTypes",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDateTime",
                value: new DateTime(2024, 11, 21, 13, 36, 56, 924, DateTimeKind.Local).AddTicks(6241));
        }
    }
}
