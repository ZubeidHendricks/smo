using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NPOMS.Repository.Migrations
{
    /// <inheritdoc />
    public partial class AddadditionalResponseTypes7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "QuestionCategories",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 20, 11, 7, 508, DateTimeKind.Local).AddTicks(8348));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "QuestionSections",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 20, 11, 7, 509, DateTimeKind.Local).AddTicks(9409));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "QuestionSections",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 20, 11, 7, 509, DateTimeKind.Local).AddTicks(9433));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "QuestionSections",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 20, 11, 7, 509, DateTimeKind.Local).AddTicks(9436));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "Questions",
                keyColumn: "Id",
                keyValue: 100,
                column: "ResponseTypeId",
                value: 12);

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "Questions",
                keyColumn: "Id",
                keyValue: 101,
                column: "ResponseTypeId",
                value: 13);

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "Questions",
                keyColumn: "Id",
                keyValue: 102,
                column: "ResponseTypeId",
                value: 18);

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "Questions",
                keyColumn: "Id",
                keyValue: 103,
                column: "ResponseTypeId",
                value: 10);

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "Questions",
                keyColumn: "Id",
                keyValue: 104,
                column: "ResponseTypeId",
                value: 18);

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "Questions",
                keyColumn: "Id",
                keyValue: 106,
                column: "ResponseTypeId",
                value: 14);

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "Questions",
                keyColumn: "Id",
                keyValue: 107,
                column: "ResponseTypeId",
                value: 18);

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "Questions",
                keyColumn: "Id",
                keyValue: 108,
                column: "ResponseTypeId",
                value: 11);

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "Questions",
                keyColumn: "Id",
                keyValue: 109,
                column: "ResponseTypeId",
                value: 18);

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "Questions",
                keyColumn: "Id",
                keyValue: 110,
                column: "ResponseTypeId",
                value: 15);

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "Questions",
                keyColumn: "Id",
                keyValue: 111,
                column: "ResponseTypeId",
                value: 16);

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "Questions",
                keyColumn: "Id",
                keyValue: 112,
                column: "ResponseTypeId",
                value: 17);

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "Questions",
                keyColumn: "Id",
                keyValue: 113,
                column: "ResponseTypeId",
                value: 18);

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "Questions",
                keyColumn: "Id",
                keyValue: 114,
                column: "ResponseTypeId",
                value: 11);

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "Questions",
                keyColumn: "Id",
                keyValue: 115,
                column: "ResponseTypeId",
                value: 18);

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "Questions",
                keyColumn: "Id",
                keyValue: 116,
                column: "ResponseTypeId",
                value: 18);

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "Questions",
                keyColumn: "Id",
                keyValue: 117,
                column: "ResponseTypeId",
                value: 18);

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "Questions",
                keyColumn: "Id",
                keyValue: 118,
                column: "ResponseTypeId",
                value: 18);

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 20, 11, 7, 511, DateTimeKind.Local).AddTicks(1108));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 20, 11, 7, 511, DateTimeKind.Local).AddTicks(1129));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 20, 11, 7, 511, DateTimeKind.Local).AddTicks(1132));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 20, 11, 7, 511, DateTimeKind.Local).AddTicks(1135));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 20, 11, 7, 511, DateTimeKind.Local).AddTicks(1138));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseTypes",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 20, 11, 7, 511, DateTimeKind.Local).AddTicks(1141));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseTypes",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 20, 11, 7, 511, DateTimeKind.Local).AddTicks(1144));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseTypes",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 20, 11, 7, 511, DateTimeKind.Local).AddTicks(1146));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseTypes",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 20, 11, 7, 511, DateTimeKind.Local).AddTicks(1151));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 20, 7, 58, 823, DateTimeKind.Local).AddTicks(6439));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 20, 7, 58, 823, DateTimeKind.Local).AddTicks(6461));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 20, 7, 58, 823, DateTimeKind.Local).AddTicks(6462));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 20, 7, 58, 823, DateTimeKind.Local).AddTicks(6464));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 20, 7, 58, 823, DateTimeKind.Local).AddTicks(6466));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 20, 7, 58, 823, DateTimeKind.Local).AddTicks(6467));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 20, 7, 58, 823, DateTimeKind.Local).AddTicks(6472));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 20, 7, 58, 823, DateTimeKind.Local).AddTicks(6474));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 20, 7, 58, 823, DateTimeKind.Local).AddTicks(6505));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 20, 7, 58, 823, DateTimeKind.Local).AddTicks(6507));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 20, 7, 58, 823, DateTimeKind.Local).AddTicks(6508));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 20, 7, 58, 823, DateTimeKind.Local).AddTicks(6513));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 20, 7, 58, 823, DateTimeKind.Local).AddTicks(6514));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 20, 7, 58, 823, DateTimeKind.Local).AddTicks(6516));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 20, 7, 58, 823, DateTimeKind.Local).AddTicks(6517));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 20, 7, 58, 823, DateTimeKind.Local).AddTicks(6519));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 20, 7, 58, 823, DateTimeKind.Local).AddTicks(6520));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 20, 7, 58, 823, DateTimeKind.Local).AddTicks(6522));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 20, 7, 58, 823, DateTimeKind.Local).AddTicks(6523));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 20, 7, 58, 823, DateTimeKind.Local).AddTicks(6525));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 20, 7, 58, 823, DateTimeKind.Local).AddTicks(6526));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 20, 7, 58, 823, DateTimeKind.Local).AddTicks(6536));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 20, 7, 58, 823, DateTimeKind.Local).AddTicks(6537));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 20, 7, 58, 823, DateTimeKind.Local).AddTicks(6539));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 20, 7, 58, 823, DateTimeKind.Local).AddTicks(6541));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 20, 7, 58, 823, DateTimeKind.Local).AddTicks(6542));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 20, 7, 58, 823, DateTimeKind.Local).AddTicks(6544));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 20, 7, 58, 823, DateTimeKind.Local).AddTicks(6545));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 20, 7, 58, 823, DateTimeKind.Local).AddTicks(6551));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 20, 7, 58, 823, DateTimeKind.Local).AddTicks(6556));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 20, 7, 58, 823, DateTimeKind.Local).AddTicks(6571));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 20, 7, 58, 823, DateTimeKind.Local).AddTicks(6572));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 20, 7, 58, 823, DateTimeKind.Local).AddTicks(7314));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 20, 7, 58, 823, DateTimeKind.Local).AddTicks(7320));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 20, 7, 58, 823, DateTimeKind.Local).AddTicks(7322));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 20, 7, 58, 823, DateTimeKind.Local).AddTicks(7324));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 20, 7, 58, 823, DateTimeKind.Local).AddTicks(7326));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 20, 7, 58, 823, DateTimeKind.Local).AddTicks(7328));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 20, 7, 58, 823, DateTimeKind.Local).AddTicks(7334));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "QuestionCategories",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 20, 7, 58, 829, DateTimeKind.Local).AddTicks(7637));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "QuestionSections",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 20, 7, 58, 830, DateTimeKind.Local).AddTicks(3995));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "QuestionSections",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 20, 7, 58, 830, DateTimeKind.Local).AddTicks(4008));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "QuestionSections",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 20, 7, 58, 830, DateTimeKind.Local).AddTicks(4009));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "Questions",
                keyColumn: "Id",
                keyValue: 100,
                column: "ResponseTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "Questions",
                keyColumn: "Id",
                keyValue: 101,
                column: "ResponseTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "Questions",
                keyColumn: "Id",
                keyValue: 102,
                column: "ResponseTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "Questions",
                keyColumn: "Id",
                keyValue: 103,
                column: "ResponseTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "Questions",
                keyColumn: "Id",
                keyValue: 104,
                column: "ResponseTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "Questions",
                keyColumn: "Id",
                keyValue: 106,
                column: "ResponseTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "Questions",
                keyColumn: "Id",
                keyValue: 107,
                column: "ResponseTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "Questions",
                keyColumn: "Id",
                keyValue: 108,
                column: "ResponseTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "Questions",
                keyColumn: "Id",
                keyValue: 109,
                column: "ResponseTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "Questions",
                keyColumn: "Id",
                keyValue: 110,
                column: "ResponseTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "Questions",
                keyColumn: "Id",
                keyValue: 111,
                column: "ResponseTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "Questions",
                keyColumn: "Id",
                keyValue: 112,
                column: "ResponseTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "Questions",
                keyColumn: "Id",
                keyValue: 113,
                column: "ResponseTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "Questions",
                keyColumn: "Id",
                keyValue: 114,
                column: "ResponseTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "Questions",
                keyColumn: "Id",
                keyValue: 115,
                column: "ResponseTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "Questions",
                keyColumn: "Id",
                keyValue: 116,
                column: "ResponseTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "Questions",
                keyColumn: "Id",
                keyValue: 117,
                column: "ResponseTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "Questions",
                keyColumn: "Id",
                keyValue: 118,
                column: "ResponseTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 20, 7, 58, 831, DateTimeKind.Local).AddTicks(3183));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 20, 7, 58, 831, DateTimeKind.Local).AddTicks(3195));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 20, 7, 58, 831, DateTimeKind.Local).AddTicks(3197));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 20, 7, 58, 831, DateTimeKind.Local).AddTicks(3198));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 20, 7, 58, 831, DateTimeKind.Local).AddTicks(3200));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseTypes",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 20, 7, 58, 831, DateTimeKind.Local).AddTicks(3201));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseTypes",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 20, 7, 58, 831, DateTimeKind.Local).AddTicks(3207));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseTypes",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 20, 7, 58, 831, DateTimeKind.Local).AddTicks(3209));

            migrationBuilder.UpdateData(
                schema: "eval",
                table: "ResponseTypes",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDateTime",
                value: new DateTime(2024, 10, 27, 20, 7, 58, 831, DateTimeKind.Local).AddTicks(3210));
        }
    }
}
