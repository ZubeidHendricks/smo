using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NPOMS.Repository.Migrations
{
    public partial class changeselectedStatusdatatype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "selectedStatus",
                schema: "eval",
                table: "CapturedResponses",
                type: "int",
                defaultValue: 0,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 6, 15, 4, 34, 866, DateTimeKind.Local).AddTicks(5258));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 6, 15, 4, 34, 866, DateTimeKind.Local).AddTicks(5264));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 6, 15, 4, 34, 866, DateTimeKind.Local).AddTicks(5266));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 6, 15, 4, 34, 866, DateTimeKind.Local).AddTicks(5269));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 6, 15, 4, 34, 866, DateTimeKind.Local).AddTicks(5271));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 6, 15, 4, 34, 866, DateTimeKind.Local).AddTicks(5273));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 6, 15, 4, 34, 866, DateTimeKind.Local).AddTicks(5275));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 6, 15, 4, 34, 866, DateTimeKind.Local).AddTicks(5277));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 6, 15, 4, 34, 866, DateTimeKind.Local).AddTicks(5280));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 6, 15, 4, 34, 866, DateTimeKind.Local).AddTicks(5282));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 6, 15, 4, 34, 866, DateTimeKind.Local).AddTicks(5284));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 6, 15, 4, 34, 866, DateTimeKind.Local).AddTicks(5286));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 6, 15, 4, 34, 866, DateTimeKind.Local).AddTicks(5288));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 6, 15, 4, 34, 866, DateTimeKind.Local).AddTicks(5290));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 6, 15, 4, 34, 866, DateTimeKind.Local).AddTicks(5293));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 6, 15, 4, 34, 866, DateTimeKind.Local).AddTicks(5295));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 6, 15, 4, 34, 866, DateTimeKind.Local).AddTicks(5297));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 6, 15, 4, 34, 866, DateTimeKind.Local).AddTicks(5299));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 6, 15, 4, 34, 866, DateTimeKind.Local).AddTicks(5301));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 6, 15, 4, 34, 866, DateTimeKind.Local).AddTicks(5303));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 6, 15, 4, 34, 866, DateTimeKind.Local).AddTicks(5305));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 6, 15, 4, 34, 866, DateTimeKind.Local).AddTicks(5307));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 6, 15, 4, 34, 866, DateTimeKind.Local).AddTicks(5324));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 6, 15, 4, 34, 866, DateTimeKind.Local).AddTicks(5352));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 6, 15, 4, 34, 866, DateTimeKind.Local).AddTicks(5354));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 6, 15, 4, 34, 866, DateTimeKind.Local).AddTicks(5356));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 6, 15, 4, 34, 866, DateTimeKind.Local).AddTicks(5358));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 6, 15, 4, 34, 866, DateTimeKind.Local).AddTicks(5360));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 6, 15, 4, 34, 866, DateTimeKind.Local).AddTicks(5362));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 6, 15, 4, 34, 866, DateTimeKind.Local).AddTicks(5364));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 6, 15, 4, 34, 866, DateTimeKind.Local).AddTicks(5366));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 6, 15, 4, 34, 866, DateTimeKind.Local).AddTicks(5368));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 6, 15, 4, 34, 866, DateTimeKind.Local).AddTicks(4916));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 6, 15, 4, 34, 866, DateTimeKind.Local).AddTicks(4949));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 6, 15, 4, 34, 866, DateTimeKind.Local).AddTicks(4953));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 6, 15, 4, 34, 866, DateTimeKind.Local).AddTicks(4956));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 6, 15, 4, 34, 866, DateTimeKind.Local).AddTicks(4959));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 6, 15, 4, 34, 866, DateTimeKind.Local).AddTicks(4962));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 6, 15, 4, 34, 866, DateTimeKind.Local).AddTicks(4964));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "selectedStatus",
                schema: "eval",
                table: "CapturedResponses",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: false);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 6, 15, 1, 5, 146, DateTimeKind.Local).AddTicks(6955));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 6, 15, 1, 5, 146, DateTimeKind.Local).AddTicks(6957));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 6, 15, 1, 5, 146, DateTimeKind.Local).AddTicks(6958));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 6, 15, 1, 5, 146, DateTimeKind.Local).AddTicks(6959));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 6, 15, 1, 5, 146, DateTimeKind.Local).AddTicks(6960));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 6, 15, 1, 5, 146, DateTimeKind.Local).AddTicks(6961));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 6, 15, 1, 5, 146, DateTimeKind.Local).AddTicks(6962));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 6, 15, 1, 5, 146, DateTimeKind.Local).AddTicks(6963));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 6, 15, 1, 5, 146, DateTimeKind.Local).AddTicks(6964));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 6, 15, 1, 5, 146, DateTimeKind.Local).AddTicks(6965));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 6, 15, 1, 5, 146, DateTimeKind.Local).AddTicks(6966));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 6, 15, 1, 5, 146, DateTimeKind.Local).AddTicks(6966));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 6, 15, 1, 5, 146, DateTimeKind.Local).AddTicks(6967));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 6, 15, 1, 5, 146, DateTimeKind.Local).AddTicks(6968));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 6, 15, 1, 5, 146, DateTimeKind.Local).AddTicks(6969));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 6, 15, 1, 5, 146, DateTimeKind.Local).AddTicks(6970));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 6, 15, 1, 5, 146, DateTimeKind.Local).AddTicks(6971));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 6, 15, 1, 5, 146, DateTimeKind.Local).AddTicks(6972));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 6, 15, 1, 5, 146, DateTimeKind.Local).AddTicks(6973));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 6, 15, 1, 5, 146, DateTimeKind.Local).AddTicks(6974));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 6, 15, 1, 5, 146, DateTimeKind.Local).AddTicks(6975));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 6, 15, 1, 5, 146, DateTimeKind.Local).AddTicks(6983));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 6, 15, 1, 5, 146, DateTimeKind.Local).AddTicks(6994));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 6, 15, 1, 5, 146, DateTimeKind.Local).AddTicks(6995));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 6, 15, 1, 5, 146, DateTimeKind.Local).AddTicks(6995));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 6, 15, 1, 5, 146, DateTimeKind.Local).AddTicks(6996));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 6, 15, 1, 5, 146, DateTimeKind.Local).AddTicks(6997));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 6, 15, 1, 5, 146, DateTimeKind.Local).AddTicks(6998));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 6, 15, 1, 5, 146, DateTimeKind.Local).AddTicks(6999));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 6, 15, 1, 5, 146, DateTimeKind.Local).AddTicks(7000));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 6, 15, 1, 5, 146, DateTimeKind.Local).AddTicks(7001));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 6, 15, 1, 5, 146, DateTimeKind.Local).AddTicks(7002));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 6, 15, 1, 5, 146, DateTimeKind.Local).AddTicks(6853));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 6, 15, 1, 5, 146, DateTimeKind.Local).AddTicks(6870));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 6, 15, 1, 5, 146, DateTimeKind.Local).AddTicks(6872));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 6, 15, 1, 5, 146, DateTimeKind.Local).AddTicks(6873));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 6, 15, 1, 5, 146, DateTimeKind.Local).AddTicks(6874));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 6, 15, 1, 5, 146, DateTimeKind.Local).AddTicks(6876));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 6, 15, 1, 5, 146, DateTimeKind.Local).AddTicks(6877));
        }
    }
}
