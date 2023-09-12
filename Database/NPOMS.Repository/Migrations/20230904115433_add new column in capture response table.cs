using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NPOMS.Repository.Migrations
{
    public partial class addnewcolumnincaptureresponsetable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isDeclarationAccepted",
                schema: "eval",
                table: "CapturedResponses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "selectedStatus",
                schema: "eval",
                table: "CapturedResponses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 4, 13, 54, 22, 792, DateTimeKind.Local).AddTicks(5665));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 4, 13, 54, 22, 792, DateTimeKind.Local).AddTicks(5670));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 4, 13, 54, 22, 792, DateTimeKind.Local).AddTicks(5673));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 4, 13, 54, 22, 792, DateTimeKind.Local).AddTicks(5676));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 4, 13, 54, 22, 792, DateTimeKind.Local).AddTicks(5679));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 4, 13, 54, 22, 792, DateTimeKind.Local).AddTicks(5682));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 4, 13, 54, 22, 792, DateTimeKind.Local).AddTicks(5685));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 4, 13, 54, 22, 792, DateTimeKind.Local).AddTicks(5688));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 4, 13, 54, 22, 792, DateTimeKind.Local).AddTicks(5691));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 4, 13, 54, 22, 792, DateTimeKind.Local).AddTicks(5694));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 4, 13, 54, 22, 792, DateTimeKind.Local).AddTicks(5696));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 4, 13, 54, 22, 792, DateTimeKind.Local).AddTicks(5699));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 4, 13, 54, 22, 792, DateTimeKind.Local).AddTicks(5702));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 4, 13, 54, 22, 792, DateTimeKind.Local).AddTicks(5705));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 4, 13, 54, 22, 792, DateTimeKind.Local).AddTicks(5708));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 4, 13, 54, 22, 792, DateTimeKind.Local).AddTicks(5710));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 4, 13, 54, 22, 792, DateTimeKind.Local).AddTicks(5713));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 4, 13, 54, 22, 792, DateTimeKind.Local).AddTicks(5716));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 4, 13, 54, 22, 792, DateTimeKind.Local).AddTicks(5718));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 4, 13, 54, 22, 792, DateTimeKind.Local).AddTicks(5721));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 4, 13, 54, 22, 792, DateTimeKind.Local).AddTicks(5724));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 4, 13, 54, 22, 792, DateTimeKind.Local).AddTicks(5727));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 4, 13, 54, 22, 792, DateTimeKind.Local).AddTicks(5750));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 4, 13, 54, 22, 792, DateTimeKind.Local).AddTicks(5832));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 4, 13, 54, 22, 792, DateTimeKind.Local).AddTicks(5835));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 4, 13, 54, 22, 792, DateTimeKind.Local).AddTicks(5838));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 4, 13, 54, 22, 792, DateTimeKind.Local).AddTicks(5840));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 4, 13, 54, 22, 792, DateTimeKind.Local).AddTicks(5843));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 4, 13, 54, 22, 792, DateTimeKind.Local).AddTicks(5846));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 4, 13, 54, 22, 792, DateTimeKind.Local).AddTicks(5848));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 4, 13, 54, 22, 792, DateTimeKind.Local).AddTicks(5851));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 4, 13, 54, 22, 792, DateTimeKind.Local).AddTicks(5854));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 4, 13, 54, 22, 792, DateTimeKind.Local).AddTicks(5451));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 4, 13, 54, 22, 792, DateTimeKind.Local).AddTicks(5490));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 4, 13, 54, 22, 792, DateTimeKind.Local).AddTicks(5495));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 4, 13, 54, 22, 792, DateTimeKind.Local).AddTicks(5498));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 4, 13, 54, 22, 792, DateTimeKind.Local).AddTicks(5502));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 4, 13, 54, 22, 792, DateTimeKind.Local).AddTicks(5506));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 4, 13, 54, 22, 792, DateTimeKind.Local).AddTicks(5509));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isDeclarationAccepted",
                schema: "eval",
                table: "CapturedResponses");

            migrationBuilder.DropColumn(
                name: "selectedStatus",
                schema: "eval",
                table: "CapturedResponses");

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 4, 9, 45, 5, 753, DateTimeKind.Local).AddTicks(6548));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 4, 9, 45, 5, 753, DateTimeKind.Local).AddTicks(6549));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 4, 9, 45, 5, 753, DateTimeKind.Local).AddTicks(6553));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 4, 9, 45, 5, 753, DateTimeKind.Local).AddTicks(6554));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 4, 9, 45, 5, 753, DateTimeKind.Local).AddTicks(6555));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 4, 9, 45, 5, 753, DateTimeKind.Local).AddTicks(6556));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 4, 9, 45, 5, 753, DateTimeKind.Local).AddTicks(6556));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 4, 9, 45, 5, 753, DateTimeKind.Local).AddTicks(6557));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 4, 9, 45, 5, 753, DateTimeKind.Local).AddTicks(6558));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 4, 9, 45, 5, 753, DateTimeKind.Local).AddTicks(6559));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 4, 9, 45, 5, 753, DateTimeKind.Local).AddTicks(6560));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 4, 9, 45, 5, 753, DateTimeKind.Local).AddTicks(6561));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 4, 9, 45, 5, 753, DateTimeKind.Local).AddTicks(6561));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 4, 9, 45, 5, 753, DateTimeKind.Local).AddTicks(6562));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 4, 9, 45, 5, 753, DateTimeKind.Local).AddTicks(6563));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 4, 9, 45, 5, 753, DateTimeKind.Local).AddTicks(6564));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 4, 9, 45, 5, 753, DateTimeKind.Local).AddTicks(6583));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 4, 9, 45, 5, 753, DateTimeKind.Local).AddTicks(6584));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 4, 9, 45, 5, 753, DateTimeKind.Local).AddTicks(6585));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 4, 9, 45, 5, 753, DateTimeKind.Local).AddTicks(6586));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 4, 9, 45, 5, 753, DateTimeKind.Local).AddTicks(6591));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 4, 9, 45, 5, 753, DateTimeKind.Local).AddTicks(6592));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 4, 9, 45, 5, 753, DateTimeKind.Local).AddTicks(6598));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 4, 9, 45, 5, 753, DateTimeKind.Local).AddTicks(6609));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 4, 9, 45, 5, 753, DateTimeKind.Local).AddTicks(6610));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 4, 9, 45, 5, 753, DateTimeKind.Local).AddTicks(6610));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 4, 9, 45, 5, 753, DateTimeKind.Local).AddTicks(6611));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 4, 9, 45, 5, 753, DateTimeKind.Local).AddTicks(6612));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 4, 9, 45, 5, 753, DateTimeKind.Local).AddTicks(6613));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 4, 9, 45, 5, 753, DateTimeKind.Local).AddTicks(6614));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 4, 9, 45, 5, 753, DateTimeKind.Local).AddTicks(6614));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 4, 9, 45, 5, 753, DateTimeKind.Local).AddTicks(6615));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 4, 9, 45, 5, 753, DateTimeKind.Local).AddTicks(6479));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 4, 9, 45, 5, 753, DateTimeKind.Local).AddTicks(6493));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 4, 9, 45, 5, 753, DateTimeKind.Local).AddTicks(6494));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 4, 9, 45, 5, 753, DateTimeKind.Local).AddTicks(6495));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 4, 9, 45, 5, 753, DateTimeKind.Local).AddTicks(6496));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 4, 9, 45, 5, 753, DateTimeKind.Local).AddTicks(6498));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2023, 9, 4, 9, 45, 5, 753, DateTimeKind.Local).AddTicks(6499));
        }
    }
}
