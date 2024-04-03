using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NPOMS.Repository.Migrations
{
    public partial class AddedTwoNewColumnsInResponsesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MainReviewerCategoryComment",
                schema: "eval",
                table: "Responses",
                type: "nvarchar(MAX)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReviewerCategoryComment",
                schema: "eval",
                table: "Responses",
                type: "nvarchar(MAX)",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 21, 15, 20, 798, DateTimeKind.Local).AddTicks(9416));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 21, 15, 20, 798, DateTimeKind.Local).AddTicks(9418));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 21, 15, 20, 798, DateTimeKind.Local).AddTicks(9420));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 21, 15, 20, 798, DateTimeKind.Local).AddTicks(9421));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 21, 15, 20, 798, DateTimeKind.Local).AddTicks(9422));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 21, 15, 20, 798, DateTimeKind.Local).AddTicks(9423));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 21, 15, 20, 798, DateTimeKind.Local).AddTicks(9424));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 21, 15, 20, 798, DateTimeKind.Local).AddTicks(9425));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 21, 15, 20, 798, DateTimeKind.Local).AddTicks(9425));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 21, 15, 20, 798, DateTimeKind.Local).AddTicks(9427));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 21, 15, 20, 798, DateTimeKind.Local).AddTicks(9428));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 21, 15, 20, 798, DateTimeKind.Local).AddTicks(9428));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 21, 15, 20, 798, DateTimeKind.Local).AddTicks(9429));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 21, 15, 20, 798, DateTimeKind.Local).AddTicks(9431));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 21, 15, 20, 798, DateTimeKind.Local).AddTicks(9431));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 21, 15, 20, 798, DateTimeKind.Local).AddTicks(9433));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 21, 15, 20, 798, DateTimeKind.Local).AddTicks(9434));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 21, 15, 20, 798, DateTimeKind.Local).AddTicks(9438));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 21, 15, 20, 798, DateTimeKind.Local).AddTicks(9439));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 21, 15, 20, 798, DateTimeKind.Local).AddTicks(9440));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 21, 15, 20, 798, DateTimeKind.Local).AddTicks(9441));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 21, 15, 20, 798, DateTimeKind.Local).AddTicks(9442));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 21, 15, 20, 798, DateTimeKind.Local).AddTicks(9446));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 21, 15, 20, 798, DateTimeKind.Local).AddTicks(9463));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 21, 15, 20, 798, DateTimeKind.Local).AddTicks(9464));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 21, 15, 20, 798, DateTimeKind.Local).AddTicks(9465));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 21, 15, 20, 798, DateTimeKind.Local).AddTicks(9466));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 21, 15, 20, 798, DateTimeKind.Local).AddTicks(9467));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 21, 15, 20, 798, DateTimeKind.Local).AddTicks(9468));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 21, 15, 20, 798, DateTimeKind.Local).AddTicks(9469));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 21, 15, 20, 798, DateTimeKind.Local).AddTicks(9472));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 21, 15, 20, 798, DateTimeKind.Local).AddTicks(9474));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 21, 15, 20, 798, DateTimeKind.Local).AddTicks(9332));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 21, 15, 20, 798, DateTimeKind.Local).AddTicks(9348));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 21, 15, 20, 798, DateTimeKind.Local).AddTicks(9349));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 21, 15, 20, 798, DateTimeKind.Local).AddTicks(9351));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 21, 15, 20, 798, DateTimeKind.Local).AddTicks(9352));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 21, 15, 20, 798, DateTimeKind.Local).AddTicks(9353));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 21, 15, 20, 798, DateTimeKind.Local).AddTicks(9355));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MainReviewerCategoryComment",
                schema: "eval",
                table: "Responses");

            migrationBuilder.DropColumn(
                name: "ReviewerCategoryComment",
                schema: "eval",
                table: "Responses");

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 13, 37, 10, 472, DateTimeKind.Local).AddTicks(8376));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 13, 37, 10, 472, DateTimeKind.Local).AddTicks(8377));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 13, 37, 10, 472, DateTimeKind.Local).AddTicks(8379));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 13, 37, 10, 472, DateTimeKind.Local).AddTicks(8380));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 13, 37, 10, 472, DateTimeKind.Local).AddTicks(8381));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 13, 37, 10, 472, DateTimeKind.Local).AddTicks(8382));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 13, 37, 10, 472, DateTimeKind.Local).AddTicks(8383));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 13, 37, 10, 472, DateTimeKind.Local).AddTicks(8384));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 13, 37, 10, 472, DateTimeKind.Local).AddTicks(8385));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 13, 37, 10, 472, DateTimeKind.Local).AddTicks(8386));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 13, 37, 10, 472, DateTimeKind.Local).AddTicks(8387));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 13, 37, 10, 472, DateTimeKind.Local).AddTicks(8388));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 13, 37, 10, 472, DateTimeKind.Local).AddTicks(8389));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 13, 37, 10, 472, DateTimeKind.Local).AddTicks(8389));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 13, 37, 10, 472, DateTimeKind.Local).AddTicks(8390));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 13, 37, 10, 472, DateTimeKind.Local).AddTicks(8391));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 13, 37, 10, 472, DateTimeKind.Local).AddTicks(8392));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 13, 37, 10, 472, DateTimeKind.Local).AddTicks(8397));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 13, 37, 10, 472, DateTimeKind.Local).AddTicks(8399));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 13, 37, 10, 472, DateTimeKind.Local).AddTicks(8400));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 13, 37, 10, 472, DateTimeKind.Local).AddTicks(8401));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 13, 37, 10, 472, DateTimeKind.Local).AddTicks(8402));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 13, 37, 10, 472, DateTimeKind.Local).AddTicks(8408));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 13, 37, 10, 472, DateTimeKind.Local).AddTicks(8423));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 13, 37, 10, 472, DateTimeKind.Local).AddTicks(8424));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 13, 37, 10, 472, DateTimeKind.Local).AddTicks(8425));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 13, 37, 10, 472, DateTimeKind.Local).AddTicks(8426));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 13, 37, 10, 472, DateTimeKind.Local).AddTicks(8427));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 13, 37, 10, 472, DateTimeKind.Local).AddTicks(8428));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 13, 37, 10, 472, DateTimeKind.Local).AddTicks(8429));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 13, 37, 10, 472, DateTimeKind.Local).AddTicks(8430));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 13, 37, 10, 472, DateTimeKind.Local).AddTicks(8431));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 13, 37, 10, 472, DateTimeKind.Local).AddTicks(8295));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 13, 37, 10, 472, DateTimeKind.Local).AddTicks(8311));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 13, 37, 10, 472, DateTimeKind.Local).AddTicks(8313));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 13, 37, 10, 472, DateTimeKind.Local).AddTicks(8314));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 13, 37, 10, 472, DateTimeKind.Local).AddTicks(8316));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 13, 37, 10, 472, DateTimeKind.Local).AddTicks(8317));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 4, 3, 13, 37, 10, 472, DateTimeKind.Local).AddTicks(8318));
        }
    }
}
