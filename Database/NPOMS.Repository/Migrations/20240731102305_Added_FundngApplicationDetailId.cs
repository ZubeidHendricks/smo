using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NPOMS.Repository.Migrations
{
    /// <inheritdoc />
    public partial class Added_FundngApplicationDetailId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectImplementations_FundingApplicationDetails_FundingApplicationDetailId",
                schema: "fa",
                table: "ProjectImplementations");

            migrationBuilder.AlterColumn<int>(
                name: "FundingApplicationDetailId",
                schema: "fa",
                table: "ProjectImplementations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 31, 12, 22, 51, 698, DateTimeKind.Local).AddTicks(7272));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 31, 12, 22, 51, 698, DateTimeKind.Local).AddTicks(7287));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 31, 12, 22, 51, 698, DateTimeKind.Local).AddTicks(7289));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 31, 12, 22, 51, 698, DateTimeKind.Local).AddTicks(7290));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 31, 12, 22, 51, 698, DateTimeKind.Local).AddTicks(7292));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 31, 12, 22, 51, 698, DateTimeKind.Local).AddTicks(7294));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 31, 12, 22, 51, 698, DateTimeKind.Local).AddTicks(7295));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 31, 12, 22, 51, 698, DateTimeKind.Local).AddTicks(7297));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 31, 12, 22, 51, 698, DateTimeKind.Local).AddTicks(7299));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 31, 12, 22, 51, 698, DateTimeKind.Local).AddTicks(7300));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 31, 12, 22, 51, 698, DateTimeKind.Local).AddTicks(7302));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 31, 12, 22, 51, 698, DateTimeKind.Local).AddTicks(7304));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 31, 12, 22, 51, 698, DateTimeKind.Local).AddTicks(7306));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 31, 12, 22, 51, 698, DateTimeKind.Local).AddTicks(7307));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 31, 12, 22, 51, 698, DateTimeKind.Local).AddTicks(7308));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 31, 12, 22, 51, 698, DateTimeKind.Local).AddTicks(7310));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 31, 12, 22, 51, 698, DateTimeKind.Local).AddTicks(7311));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 31, 12, 22, 51, 698, DateTimeKind.Local).AddTicks(7313));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 31, 12, 22, 51, 698, DateTimeKind.Local).AddTicks(7314));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 31, 12, 22, 51, 698, DateTimeKind.Local).AddTicks(7316));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 31, 12, 22, 51, 698, DateTimeKind.Local).AddTicks(7317));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 31, 12, 22, 51, 698, DateTimeKind.Local).AddTicks(7319));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 31, 12, 22, 51, 698, DateTimeKind.Local).AddTicks(7320));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 31, 12, 22, 51, 698, DateTimeKind.Local).AddTicks(7322));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 31, 12, 22, 51, 698, DateTimeKind.Local).AddTicks(7323));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 31, 12, 22, 51, 698, DateTimeKind.Local).AddTicks(7325));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 31, 12, 22, 51, 698, DateTimeKind.Local).AddTicks(7326));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 31, 12, 22, 51, 698, DateTimeKind.Local).AddTicks(7337));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 31, 12, 22, 51, 698, DateTimeKind.Local).AddTicks(7338));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 31, 12, 22, 51, 698, DateTimeKind.Local).AddTicks(7343));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 31, 12, 22, 51, 698, DateTimeKind.Local).AddTicks(7355));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 31, 12, 22, 51, 698, DateTimeKind.Local).AddTicks(7356));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 31, 12, 22, 51, 698, DateTimeKind.Local).AddTicks(7905));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 31, 12, 22, 51, 698, DateTimeKind.Local).AddTicks(7909));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 31, 12, 22, 51, 698, DateTimeKind.Local).AddTicks(7912));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 31, 12, 22, 51, 698, DateTimeKind.Local).AddTicks(7914));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 31, 12, 22, 51, 698, DateTimeKind.Local).AddTicks(7916));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 31, 12, 22, 51, 698, DateTimeKind.Local).AddTicks(7918));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 31, 12, 22, 51, 698, DateTimeKind.Local).AddTicks(7948));

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectImplementations_FundingApplicationDetails_FundingApplicationDetailId",
                schema: "fa",
                table: "ProjectImplementations",
                column: "FundingApplicationDetailId",
                principalSchema: "fa",
                principalTable: "FundingApplicationDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectImplementations_FundingApplicationDetails_FundingApplicationDetailId",
                schema: "fa",
                table: "ProjectImplementations");

            migrationBuilder.AlterColumn<int>(
                name: "FundingApplicationDetailId",
                schema: "fa",
                table: "ProjectImplementations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 31, 8, 1, 59, 244, DateTimeKind.Local).AddTicks(4745));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 31, 8, 1, 59, 244, DateTimeKind.Local).AddTicks(4765));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 31, 8, 1, 59, 244, DateTimeKind.Local).AddTicks(4767));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 31, 8, 1, 59, 244, DateTimeKind.Local).AddTicks(4770));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 31, 8, 1, 59, 244, DateTimeKind.Local).AddTicks(4772));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 31, 8, 1, 59, 244, DateTimeKind.Local).AddTicks(4774));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 31, 8, 1, 59, 244, DateTimeKind.Local).AddTicks(4776));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 31, 8, 1, 59, 244, DateTimeKind.Local).AddTicks(4778));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 31, 8, 1, 59, 244, DateTimeKind.Local).AddTicks(4780));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 31, 8, 1, 59, 244, DateTimeKind.Local).AddTicks(4782));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 31, 8, 1, 59, 244, DateTimeKind.Local).AddTicks(4784));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 31, 8, 1, 59, 244, DateTimeKind.Local).AddTicks(4786));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 31, 8, 1, 59, 244, DateTimeKind.Local).AddTicks(4790));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 31, 8, 1, 59, 244, DateTimeKind.Local).AddTicks(4792));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 31, 8, 1, 59, 244, DateTimeKind.Local).AddTicks(4794));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 31, 8, 1, 59, 244, DateTimeKind.Local).AddTicks(4796));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 31, 8, 1, 59, 244, DateTimeKind.Local).AddTicks(4798));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 31, 8, 1, 59, 244, DateTimeKind.Local).AddTicks(4800));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 31, 8, 1, 59, 244, DateTimeKind.Local).AddTicks(4802));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 31, 8, 1, 59, 244, DateTimeKind.Local).AddTicks(4804));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 31, 8, 1, 59, 244, DateTimeKind.Local).AddTicks(4806));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 31, 8, 1, 59, 244, DateTimeKind.Local).AddTicks(4813));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 31, 8, 1, 59, 244, DateTimeKind.Local).AddTicks(4815));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 31, 8, 1, 59, 244, DateTimeKind.Local).AddTicks(4817));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 31, 8, 1, 59, 244, DateTimeKind.Local).AddTicks(4819));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 31, 8, 1, 59, 244, DateTimeKind.Local).AddTicks(4821));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 31, 8, 1, 59, 244, DateTimeKind.Local).AddTicks(4823));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 31, 8, 1, 59, 244, DateTimeKind.Local).AddTicks(4825));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 31, 8, 1, 59, 244, DateTimeKind.Local).AddTicks(4827));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 31, 8, 1, 59, 244, DateTimeKind.Local).AddTicks(4832));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 31, 8, 1, 59, 244, DateTimeKind.Local).AddTicks(4856));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 31, 8, 1, 59, 244, DateTimeKind.Local).AddTicks(4858));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 31, 8, 1, 59, 244, DateTimeKind.Local).AddTicks(5604));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 31, 8, 1, 59, 244, DateTimeKind.Local).AddTicks(5609));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 31, 8, 1, 59, 244, DateTimeKind.Local).AddTicks(5612));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 31, 8, 1, 59, 244, DateTimeKind.Local).AddTicks(5615));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 31, 8, 1, 59, 244, DateTimeKind.Local).AddTicks(5618));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 31, 8, 1, 59, 244, DateTimeKind.Local).AddTicks(5621));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 31, 8, 1, 59, 244, DateTimeKind.Local).AddTicks(5624));

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectImplementations_FundingApplicationDetails_FundingApplicationDetailId",
                schema: "fa",
                table: "ProjectImplementations",
                column: "FundingApplicationDetailId",
                principalSchema: "fa",
                principalTable: "FundingApplicationDetails",
                principalColumn: "Id");
        }
    }
}
