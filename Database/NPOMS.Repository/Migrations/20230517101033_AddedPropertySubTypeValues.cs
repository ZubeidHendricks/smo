using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NPOMS.Repository.Migrations
{
    public partial class AddedPropertySubTypeValues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 17, 12, 10, 27, 759, DateTimeKind.Local).AddTicks(7233));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 17, 12, 10, 27, 759, DateTimeKind.Local).AddTicks(7234));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 17, 12, 10, 27, 759, DateTimeKind.Local).AddTicks(7236));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 17, 12, 10, 27, 759, DateTimeKind.Local).AddTicks(7236));

            migrationBuilder.InsertData(
                schema: "dropdown",
                table: "PropertySubTypes",
                columns: new[] { "Id", "CreatedDateTime", "CreatedUserID", "Frequency", "HaveComment", "IsActive", "IsDeleted", "Name", "PropertyTypeID", "Repeatable", "UpdatedDateTime", "UpdatedUserID" },
                values: new object[,]
                {
                    { 5, new DateTime(2023, 5, 17, 12, 10, 27, 759, DateTimeKind.Local).AddTicks(7237), 3, null, false, false, false, "Social Worker", 2, true, null, null },
                    { 6, new DateTime(2023, 5, 17, 12, 10, 27, 759, DateTimeKind.Local).AddTicks(7238), 3, null, false, true, false, "Social Worker Supervisor", 2, true, null, null },
                    { 7, new DateTime(2023, 5, 17, 12, 10, 27, 759, DateTimeKind.Local).AddTicks(7239), 3, null, false, true, false, "Social Auxiliary Worker", 2, true, null, null },
                    { 8, new DateTime(2023, 5, 17, 12, 10, 27, 759, DateTimeKind.Local).AddTicks(7240), 3, null, false, true, false, "Social Worker Manager", 2, true, null, null },
                    { 9, new DateTime(2023, 5, 17, 12, 10, 27, 759, DateTimeKind.Local).AddTicks(7241), 3, null, false, true, false, "Community Development Practitioner", 2, true, null, null },
                    { 10, new DateTime(2023, 5, 17, 12, 10, 27, 759, DateTimeKind.Local).AddTicks(7242), 3, null, false, true, false, "Community Development Assistant", 2, true, null, null },
                    { 11, new DateTime(2023, 5, 17, 12, 10, 27, 759, DateTimeKind.Local).AddTicks(7243), 3, null, false, true, false, "Facilitator", 4, true, null, null },
                    { 12, new DateTime(2023, 5, 17, 12, 10, 27, 759, DateTimeKind.Local).AddTicks(7243), 3, null, false, true, false, "Catering", 4, true, null, null },
                    { 13, new DateTime(2023, 5, 17, 12, 10, 27, 759, DateTimeKind.Local).AddTicks(7244), 3, null, false, true, false, "Transport", 4, true, null, null },
                    { 14, new DateTime(2023, 5, 17, 12, 10, 27, 759, DateTimeKind.Local).AddTicks(7245), 3, null, false, true, false, "Telephone", 4, true, null, null },
                    { 15, new DateTime(2023, 5, 17, 12, 10, 27, 759, DateTimeKind.Local).AddTicks(7246), 3, null, false, true, false, "Venue Hire", 4, true, null, null },
                    { 16, new DateTime(2023, 5, 17, 12, 10, 27, 759, DateTimeKind.Local).AddTicks(7247), 3, null, false, true, false, "Traveling", 4, true, null, null },
                    { 17, new DateTime(2023, 5, 17, 12, 10, 27, 759, DateTimeKind.Local).AddTicks(7248), 3, null, false, true, false, "Accommodation", 4, true, null, null },
                    { 18, new DateTime(2023, 5, 17, 12, 10, 27, 759, DateTimeKind.Local).AddTicks(7253), 3, null, false, true, false, "Training", 4, true, null, null },
                    { 19, new DateTime(2023, 5, 17, 12, 10, 27, 759, DateTimeKind.Local).AddTicks(7254), 3, null, false, true, false, "Governance Norms and Standards", 4, true, null, null },
                    { 20, new DateTime(2023, 5, 17, 12, 10, 27, 759, DateTimeKind.Local).AddTicks(7255), 3, null, false, true, false, "Management Fee", 4, true, null, null },
                    { 21, new DateTime(2023, 5, 17, 12, 10, 27, 759, DateTimeKind.Local).AddTicks(7256), 3, null, false, false, false, "Other", 4, true, null, null },
                    { 22, new DateTime(2023, 5, 17, 12, 10, 27, 759, DateTimeKind.Local).AddTicks(7256), 3, null, false, true, false, "Admin Fee", 4, true, null, null },
                    { 23, new DateTime(2023, 5, 17, 12, 10, 27, 759, DateTimeKind.Local).AddTicks(7260), 3, null, false, true, false, "UIF & COIDA", 4, true, null, null },
                    { 24, new DateTime(2023, 5, 17, 12, 10, 27, 759, DateTimeKind.Local).AddTicks(7270), 3, null, false, true, false, "Social", 4, true, null, null },
                    { 25, new DateTime(2023, 5, 17, 12, 10, 27, 759, DateTimeKind.Local).AddTicks(7271), 3, null, false, true, false, "AAA", 4, true, null, null },
                    { 26, new DateTime(2023, 5, 17, 12, 10, 27, 759, DateTimeKind.Local).AddTicks(7272), 3, null, false, true, false, "Skill Development", 4, true, null, null },
                    { 27, new DateTime(2023, 5, 17, 12, 10, 27, 759, DateTimeKind.Local).AddTicks(7273), 3, null, false, true, false, "Security Upgrade & OHS Compliance 1", 4, true, null, null },
                    { 28, new DateTime(2023, 5, 17, 12, 10, 27, 759, DateTimeKind.Local).AddTicks(7273), 3, null, false, true, false, "Security Upgrade & OHS Compliance 2", 4, true, null, null },
                    { 29, new DateTime(2023, 5, 17, 12, 10, 27, 759, DateTimeKind.Local).AddTicks(7274), 3, null, false, true, false, "Security Upgrade & OHS Compliance 3", 4, true, null, null },
                    { 30, new DateTime(2023, 5, 17, 12, 10, 27, 759, DateTimeKind.Local).AddTicks(7275), 3, null, false, true, false, "Travel Cost", 4, true, null, null },
                    { 31, new DateTime(2023, 5, 17, 12, 10, 27, 759, DateTimeKind.Local).AddTicks(7276), 3, null, false, true, false, "Specialized services", 4, true, null, null },
                    { 32, new DateTime(2023, 5, 17, 12, 10, 27, 759, DateTimeKind.Local).AddTicks(7277), 3, null, false, true, false, "House Mothers", 4, true, null, null }
                });

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 17, 12, 10, 27, 759, DateTimeKind.Local).AddTicks(7163));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 17, 12, 10, 27, 759, DateTimeKind.Local).AddTicks(7179));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 17, 12, 10, 27, 759, DateTimeKind.Local).AddTicks(7181));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 17, 12, 10, 27, 759, DateTimeKind.Local).AddTicks(7182));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 17, 12, 10, 27, 759, DateTimeKind.Local).AddTicks(7183));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 17, 12, 10, 27, 759, DateTimeKind.Local).AddTicks(7184));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 17, 12, 10, 27, 759, DateTimeKind.Local).AddTicks(7185));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 17, 4, 9, 36, 57, DateTimeKind.Local).AddTicks(8767));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 17, 4, 9, 36, 57, DateTimeKind.Local).AddTicks(8770));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 17, 4, 9, 36, 57, DateTimeKind.Local).AddTicks(8772));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 17, 4, 9, 36, 57, DateTimeKind.Local).AddTicks(8774));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 17, 4, 9, 36, 57, DateTimeKind.Local).AddTicks(8656));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 17, 4, 9, 36, 57, DateTimeKind.Local).AddTicks(8679));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 17, 4, 9, 36, 57, DateTimeKind.Local).AddTicks(8682));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 17, 4, 9, 36, 57, DateTimeKind.Local).AddTicks(8684));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 17, 4, 9, 36, 57, DateTimeKind.Local).AddTicks(8686));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 17, 4, 9, 36, 57, DateTimeKind.Local).AddTicks(8688));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 17, 4, 9, 36, 57, DateTimeKind.Local).AddTicks(8690));
        }
    }
}
