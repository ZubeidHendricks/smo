using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NPOMS.Repository.Migrations
{
    public partial class AddNewColumn_RejectionComment_RejectedByUserId_In_Responses_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RejectedByUserId",
                schema: "eval",
                table: "Responses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "RejectionComment",
                schema: "eval",
                table: "Responses",
                type: "nvarchar(MAX)",
                nullable: true);

            migrationBuilder.InsertData(
                schema: "core",
                table: "EmailTemplates",
                columns: new[] { "Id", "Body", "Description", "Name", "Subject" },
                values: new object[] { 25, "<p>Dear {ToUserFullName}</p><p>The Scorecard for <strong>{organisationName}</strong> with reference number <strong>{ApplicationRefNo}</strong> has been rejected.</p><p>To review the rejection, please <a href=\"{url}/#/applications\">click here</a> to access.</p><p>Kind Regards,</p><p>NPO MS Team</p>", null, "RejectedScorecard", "Scorecard Rejected Notification - {NPO}" });

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 3, 12, 10, 31, 3, 116, DateTimeKind.Local).AddTicks(7650));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 3, 12, 10, 31, 3, 116, DateTimeKind.Local).AddTicks(7654));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 3, 12, 10, 31, 3, 116, DateTimeKind.Local).AddTicks(7656));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 3, 12, 10, 31, 3, 116, DateTimeKind.Local).AddTicks(7658));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDateTime",
                value: new DateTime(2024, 3, 12, 10, 31, 3, 116, DateTimeKind.Local).AddTicks(7660));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 3, 12, 10, 31, 3, 116, DateTimeKind.Local).AddTicks(7662));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 3, 12, 10, 31, 3, 116, DateTimeKind.Local).AddTicks(7664));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 3, 12, 10, 31, 3, 116, DateTimeKind.Local).AddTicks(7665));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDateTime",
                value: new DateTime(2024, 3, 12, 10, 31, 3, 116, DateTimeKind.Local).AddTicks(7667));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDateTime",
                value: new DateTime(2024, 3, 12, 10, 31, 3, 116, DateTimeKind.Local).AddTicks(7669));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDateTime",
                value: new DateTime(2024, 3, 12, 10, 31, 3, 116, DateTimeKind.Local).AddTicks(7671));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDateTime",
                value: new DateTime(2024, 3, 12, 10, 31, 3, 116, DateTimeKind.Local).AddTicks(7673));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDateTime",
                value: new DateTime(2024, 3, 12, 10, 31, 3, 116, DateTimeKind.Local).AddTicks(7675));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDateTime",
                value: new DateTime(2024, 3, 12, 10, 31, 3, 116, DateTimeKind.Local).AddTicks(7677));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDateTime",
                value: new DateTime(2024, 3, 12, 10, 31, 3, 116, DateTimeKind.Local).AddTicks(7679));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDateTime",
                value: new DateTime(2024, 3, 12, 10, 31, 3, 116, DateTimeKind.Local).AddTicks(7680));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDateTime",
                value: new DateTime(2024, 3, 12, 10, 31, 3, 116, DateTimeKind.Local).AddTicks(7682));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDateTime",
                value: new DateTime(2024, 3, 12, 10, 31, 3, 116, DateTimeKind.Local).AddTicks(7684));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDateTime",
                value: new DateTime(2024, 3, 12, 10, 31, 3, 116, DateTimeKind.Local).AddTicks(7686));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDateTime",
                value: new DateTime(2024, 3, 12, 10, 31, 3, 116, DateTimeKind.Local).AddTicks(7688));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDateTime",
                value: new DateTime(2024, 3, 12, 10, 31, 3, 116, DateTimeKind.Local).AddTicks(7705));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDateTime",
                value: new DateTime(2024, 3, 12, 10, 31, 3, 116, DateTimeKind.Local).AddTicks(7707));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDateTime",
                value: new DateTime(2024, 3, 12, 10, 31, 3, 116, DateTimeKind.Local).AddTicks(7714));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDateTime",
                value: new DateTime(2024, 3, 12, 10, 31, 3, 116, DateTimeKind.Local).AddTicks(7740));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDateTime",
                value: new DateTime(2024, 3, 12, 10, 31, 3, 116, DateTimeKind.Local).AddTicks(7742));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDateTime",
                value: new DateTime(2024, 3, 12, 10, 31, 3, 116, DateTimeKind.Local).AddTicks(7743));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDateTime",
                value: new DateTime(2024, 3, 12, 10, 31, 3, 117, DateTimeKind.Local).AddTicks(3270));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedDateTime",
                value: new DateTime(2024, 3, 12, 10, 31, 3, 117, DateTimeKind.Local).AddTicks(3273));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedDateTime",
                value: new DateTime(2024, 3, 12, 10, 31, 3, 117, DateTimeKind.Local).AddTicks(3275));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedDateTime",
                value: new DateTime(2024, 3, 12, 10, 31, 3, 117, DateTimeKind.Local).AddTicks(3277));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDateTime",
                value: new DateTime(2024, 3, 12, 10, 31, 3, 117, DateTimeKind.Local).AddTicks(3279));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedDateTime",
                value: new DateTime(2024, 3, 12, 10, 31, 3, 117, DateTimeKind.Local).AddTicks(3281));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 3, 12, 10, 31, 3, 116, DateTimeKind.Local).AddTicks(7451));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 3, 12, 10, 31, 3, 116, DateTimeKind.Local).AddTicks(7476));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 3, 12, 10, 31, 3, 116, DateTimeKind.Local).AddTicks(7478));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 3, 12, 10, 31, 3, 116, DateTimeKind.Local).AddTicks(7481));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 3, 12, 10, 31, 3, 116, DateTimeKind.Local).AddTicks(7483));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 3, 12, 10, 31, 3, 116, DateTimeKind.Local).AddTicks(7486));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 3, 12, 10, 31, 3, 116, DateTimeKind.Local).AddTicks(7488));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "core",
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DropColumn(
                name: "RejectedByUserId",
                schema: "eval",
                table: "Responses");

            migrationBuilder.DropColumn(
                name: "RejectionComment",
                schema: "eval",
                table: "Responses");

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 31, 11, 42, 59, 515, DateTimeKind.Local).AddTicks(5196));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 31, 11, 42, 59, 515, DateTimeKind.Local).AddTicks(5202));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 31, 11, 42, 59, 515, DateTimeKind.Local).AddTicks(5205));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 31, 11, 42, 59, 515, DateTimeKind.Local).AddTicks(5208));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 31, 11, 42, 59, 515, DateTimeKind.Local).AddTicks(5211));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 31, 11, 42, 59, 515, DateTimeKind.Local).AddTicks(5214));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 31, 11, 42, 59, 515, DateTimeKind.Local).AddTicks(5217));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 31, 11, 42, 59, 515, DateTimeKind.Local).AddTicks(5219));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 31, 11, 42, 59, 515, DateTimeKind.Local).AddTicks(5222));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 31, 11, 42, 59, 515, DateTimeKind.Local).AddTicks(5225));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 31, 11, 42, 59, 515, DateTimeKind.Local).AddTicks(5229));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 31, 11, 42, 59, 515, DateTimeKind.Local).AddTicks(5232));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 31, 11, 42, 59, 515, DateTimeKind.Local).AddTicks(5235));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 31, 11, 42, 59, 515, DateTimeKind.Local).AddTicks(5237));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 31, 11, 42, 59, 515, DateTimeKind.Local).AddTicks(5240));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 31, 11, 42, 59, 515, DateTimeKind.Local).AddTicks(5243));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 31, 11, 42, 59, 515, DateTimeKind.Local).AddTicks(5245));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 31, 11, 42, 59, 515, DateTimeKind.Local).AddTicks(5248));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 31, 11, 42, 59, 515, DateTimeKind.Local).AddTicks(5251));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 31, 11, 42, 59, 515, DateTimeKind.Local).AddTicks(5253));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 31, 11, 42, 59, 515, DateTimeKind.Local).AddTicks(5256));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 31, 11, 42, 59, 515, DateTimeKind.Local).AddTicks(5259));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 31, 11, 42, 59, 515, DateTimeKind.Local).AddTicks(5261));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 31, 11, 42, 59, 515, DateTimeKind.Local).AddTicks(5264));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 31, 11, 42, 59, 515, DateTimeKind.Local).AddTicks(5268));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 31, 11, 42, 59, 515, DateTimeKind.Local).AddTicks(5270));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 31, 11, 42, 59, 515, DateTimeKind.Local).AddTicks(5273));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 31, 11, 42, 59, 515, DateTimeKind.Local).AddTicks(5276));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 31, 11, 42, 59, 515, DateTimeKind.Local).AddTicks(5279));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 31, 11, 42, 59, 515, DateTimeKind.Local).AddTicks(5281));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 31, 11, 42, 59, 515, DateTimeKind.Local).AddTicks(5284));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 31, 11, 42, 59, 515, DateTimeKind.Local).AddTicks(5302));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 31, 11, 42, 59, 515, DateTimeKind.Local).AddTicks(4923));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 31, 11, 42, 59, 515, DateTimeKind.Local).AddTicks(4953));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 31, 11, 42, 59, 515, DateTimeKind.Local).AddTicks(4958));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 31, 11, 42, 59, 515, DateTimeKind.Local).AddTicks(4962));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 31, 11, 42, 59, 515, DateTimeKind.Local).AddTicks(4965));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 31, 11, 42, 59, 515, DateTimeKind.Local).AddTicks(4969));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 1, 31, 11, 42, 59, 515, DateTimeKind.Local).AddTicks(4972));
        }
    }
}
