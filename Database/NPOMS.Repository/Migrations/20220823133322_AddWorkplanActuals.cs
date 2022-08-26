using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NPOMS.Repository.Migrations
{
    public partial class AddWorkplanActuals : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FrequencyId",
                schema: "dropdown",
                table: "FrequencyPeriods",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "FrequencyPeriods",
                keyColumn: "Id",
                keyValue: 1,
                column: "FrequencyId",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "FrequencyPeriods",
                keyColumn: "Id",
                keyValue: 2,
                column: "FrequencyId",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "FrequencyPeriods",
                keyColumn: "Id",
                keyValue: 3,
                column: "FrequencyId",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "FrequencyPeriods",
                keyColumn: "Id",
                keyValue: 4,
                column: "FrequencyId",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "FrequencyPeriods",
                keyColumn: "Id",
                keyValue: 5,
                column: "FrequencyId",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "FrequencyPeriods",
                keyColumn: "Id",
                keyValue: 6,
                column: "FrequencyId",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "FrequencyPeriods",
                keyColumn: "Id",
                keyValue: 7,
                column: "FrequencyId",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "FrequencyPeriods",
                keyColumn: "Id",
                keyValue: 8,
                column: "FrequencyId",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "FrequencyPeriods",
                keyColumn: "Id",
                keyValue: 9,
                column: "FrequencyId",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "FrequencyPeriods",
                keyColumn: "Id",
                keyValue: 10,
                column: "FrequencyId",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "FrequencyPeriods",
                keyColumn: "Id",
                keyValue: 11,
                column: "FrequencyId",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "FrequencyPeriods",
                keyColumn: "Id",
                keyValue: 12,
                column: "FrequencyId",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "FrequencyPeriods",
                keyColumn: "Id",
                keyValue: 13,
                column: "FrequencyId",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "FrequencyPeriods",
                keyColumn: "Id",
                keyValue: 14,
                column: "FrequencyId",
                value: 3);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "FrequencyPeriods",
                keyColumn: "Id",
                keyValue: 15,
                column: "FrequencyId",
                value: 3);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "FrequencyPeriods",
                keyColumn: "Id",
                keyValue: 16,
                column: "FrequencyId",
                value: 3);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "FrequencyPeriods",
                keyColumn: "Id",
                keyValue: 17,
                column: "FrequencyId",
                value: 3);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FrequencyId",
                schema: "dropdown",
                table: "FrequencyPeriods");
        }
    }
}
