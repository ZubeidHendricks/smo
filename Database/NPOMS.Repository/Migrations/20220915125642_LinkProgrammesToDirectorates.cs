using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NPOMS.Repository.Migrations
{
    public partial class LinkProgrammesToDirectorates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "Programmes",
                keyColumn: "Id",
                keyValue: 8,
                column: "DirectorateId",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "Programmes",
                keyColumn: "Id",
                keyValue: 9,
                column: "DirectorateId",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "Programmes",
                keyColumn: "Id",
                keyValue: 10,
                column: "DirectorateId",
                value: 7);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "Programmes",
                keyColumn: "Id",
                keyValue: 11,
                column: "DirectorateId",
                value: 3);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "Programmes",
                keyColumn: "Id",
                keyValue: 12,
                column: "DirectorateId",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "Programmes",
                keyColumn: "Id",
                keyValue: 13,
                column: "DirectorateId",
                value: 4);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "Programmes",
                keyColumn: "Id",
                keyValue: 14,
                column: "DirectorateId",
                value: 5);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "Programmes",
                keyColumn: "Id",
                keyValue: 15,
                column: "DirectorateId",
                value: 8);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "Programmes",
                keyColumn: "Id",
                keyValue: 16,
                column: "DirectorateId",
                value: 8);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "Programmes",
                keyColumn: "Id",
                keyValue: 17,
                column: "DirectorateId",
                value: 8);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "Programmes",
                keyColumn: "Id",
                keyValue: 18,
                column: "DirectorateId",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "Programmes",
                keyColumn: "Id",
                keyValue: 19,
                column: "DirectorateId",
                value: 7);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "Programmes",
                keyColumn: "Id",
                keyValue: 20,
                column: "DirectorateId",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "Programmes",
                keyColumn: "Id",
                keyValue: 21,
                column: "DirectorateId",
                value: 4);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "Programmes",
                keyColumn: "Id",
                keyValue: 22,
                column: "DirectorateId",
                value: 3);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "Programmes",
                keyColumn: "Id",
                keyValue: 8,
                column: "DirectorateId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "Programmes",
                keyColumn: "Id",
                keyValue: 9,
                column: "DirectorateId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "Programmes",
                keyColumn: "Id",
                keyValue: 10,
                column: "DirectorateId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "Programmes",
                keyColumn: "Id",
                keyValue: 11,
                column: "DirectorateId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "Programmes",
                keyColumn: "Id",
                keyValue: 12,
                column: "DirectorateId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "Programmes",
                keyColumn: "Id",
                keyValue: 13,
                column: "DirectorateId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "Programmes",
                keyColumn: "Id",
                keyValue: 14,
                column: "DirectorateId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "Programmes",
                keyColumn: "Id",
                keyValue: 15,
                column: "DirectorateId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "Programmes",
                keyColumn: "Id",
                keyValue: 16,
                column: "DirectorateId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "Programmes",
                keyColumn: "Id",
                keyValue: 17,
                column: "DirectorateId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "Programmes",
                keyColumn: "Id",
                keyValue: 18,
                column: "DirectorateId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "Programmes",
                keyColumn: "Id",
                keyValue: 19,
                column: "DirectorateId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "Programmes",
                keyColumn: "Id",
                keyValue: 20,
                column: "DirectorateId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "Programmes",
                keyColumn: "Id",
                keyValue: 21,
                column: "DirectorateId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "Programmes",
                keyColumn: "Id",
                keyValue: 22,
                column: "DirectorateId",
                value: null);
        }
    }
}
