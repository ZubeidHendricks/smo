using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NPOMS.Repository.Migrations
{
    public partial class AddCompliantCycleRuleConfiguration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                schema: "dbo",
                table: "CompliantCycleRules",
                type: "bit",
                nullable: false,
                defaultValueSql: "1",
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<int>(
                name: "CreatedUserId",
                schema: "dbo",
                table: "CompliantCycleRules",
                type: "int",
                nullable: false,
                defaultValueSql: "1",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDateTime",
                schema: "dbo",
                table: "CompliantCycleRules",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GetDate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "CompliantCycleRules",
                columns: new[] { "Id", "CycleNumber", "UpdatedDateTime", "UpdatedUserId" },
                values: new object[,]
                {
                    { 1, 1, null, null },
                    { 2, 2, null, null },
                    { 3, 3, null, null },
                    { 4, 4, null, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "CompliantCycleRules",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "CompliantCycleRules",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "CompliantCycleRules",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "CompliantCycleRules",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                schema: "dbo",
                table: "CompliantCycleRules",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValueSql: "1");

            migrationBuilder.AlterColumn<int>(
                name: "CreatedUserId",
                schema: "dbo",
                table: "CompliantCycleRules",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValueSql: "1");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDateTime",
                schema: "dbo",
                table: "CompliantCycleRules",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GetDate()");
        }
    }
}
