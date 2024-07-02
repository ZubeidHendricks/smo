using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NPOMS.Repository.Migrations
{
    /// <inheritdoc />
    public partial class Roles_filter_Service_Rendered : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "core",
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: 24,
                column: "Body",
                value: "<p>Dear {ToUserFullName}</p><p>The Scorecard for <strong>{organisationName}</strong> with reference number <strong>{ApplicationRefNo}</strong> is now available for rating.</p><p>Please <a href=\"{url}/#/scorecard/{ApplicationId}\">click here</a> to access this scorecard.</p><p>Kind Regards,</p><p>NPO MS Team</p>");

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 2, 16, 20, 41, 246, DateTimeKind.Local).AddTicks(3292));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 2, 16, 20, 41, 246, DateTimeKind.Local).AddTicks(3296));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 2, 16, 20, 41, 246, DateTimeKind.Local).AddTicks(3299));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 2, 16, 20, 41, 246, DateTimeKind.Local).AddTicks(3301));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 2, 16, 20, 41, 246, DateTimeKind.Local).AddTicks(3304));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 2, 16, 20, 41, 246, DateTimeKind.Local).AddTicks(3306));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 2, 16, 20, 41, 246, DateTimeKind.Local).AddTicks(3309));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 2, 16, 20, 41, 246, DateTimeKind.Local).AddTicks(3311));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 2, 16, 20, 41, 246, DateTimeKind.Local).AddTicks(3314));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 2, 16, 20, 41, 246, DateTimeKind.Local).AddTicks(3316));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 2, 16, 20, 41, 246, DateTimeKind.Local).AddTicks(3319));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 2, 16, 20, 41, 246, DateTimeKind.Local).AddTicks(3322));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 2, 16, 20, 41, 246, DateTimeKind.Local).AddTicks(3324));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 2, 16, 20, 41, 246, DateTimeKind.Local).AddTicks(3327));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 2, 16, 20, 41, 246, DateTimeKind.Local).AddTicks(3330));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 2, 16, 20, 41, 246, DateTimeKind.Local).AddTicks(3332));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 2, 16, 20, 41, 246, DateTimeKind.Local).AddTicks(3334));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 2, 16, 20, 41, 246, DateTimeKind.Local).AddTicks(3337));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 2, 16, 20, 41, 246, DateTimeKind.Local).AddTicks(3340));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 2, 16, 20, 41, 246, DateTimeKind.Local).AddTicks(3342));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 2, 16, 20, 41, 246, DateTimeKind.Local).AddTicks(3345));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 2, 16, 20, 41, 246, DateTimeKind.Local).AddTicks(3347));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 2, 16, 20, 41, 246, DateTimeKind.Local).AddTicks(3366));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 2, 16, 20, 41, 246, DateTimeKind.Local).AddTicks(3376));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 2, 16, 20, 41, 246, DateTimeKind.Local).AddTicks(3379));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 2, 16, 20, 41, 246, DateTimeKind.Local).AddTicks(3381));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 2, 16, 20, 41, 246, DateTimeKind.Local).AddTicks(3384));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 2, 16, 20, 41, 246, DateTimeKind.Local).AddTicks(3386));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 2, 16, 20, 41, 246, DateTimeKind.Local).AddTicks(3388));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 2, 16, 20, 41, 246, DateTimeKind.Local).AddTicks(3391));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 2, 16, 20, 41, 246, DateTimeKind.Local).AddTicks(3394));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 2, 16, 20, 41, 246, DateTimeKind.Local).AddTicks(3396));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 2, 16, 20, 41, 246, DateTimeKind.Local).AddTicks(3105));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 2, 16, 20, 41, 246, DateTimeKind.Local).AddTicks(3117));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 2, 16, 20, 41, 246, DateTimeKind.Local).AddTicks(3121));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 2, 16, 20, 41, 246, DateTimeKind.Local).AddTicks(3124));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 2, 16, 20, 41, 246, DateTimeKind.Local).AddTicks(3128));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 2, 16, 20, 41, 246, DateTimeKind.Local).AddTicks(3132));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 2, 16, 20, 41, 246, DateTimeKind.Local).AddTicks(3135));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "core",
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: 24,
                column: "Body",
                value: "<p>Dear {ToUserFullName}</p><p>The Scorecard for <strong>{organisationName}</strong> with reference number <strong>{ApplicationRefNo}</strong> is now available for rating.</p><p>Please <a href=\"{url}/#/scorecard/{ApplicationId}\">click here</a> to access this workplan.</p><p>Kind Regards,</p><p>NPO MS Team</p>");

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 1, 20, 36, 40, 383, DateTimeKind.Local).AddTicks(2974));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 1, 20, 36, 40, 383, DateTimeKind.Local).AddTicks(2976));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 1, 20, 36, 40, 383, DateTimeKind.Local).AddTicks(2978));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 1, 20, 36, 40, 383, DateTimeKind.Local).AddTicks(2980));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 1, 20, 36, 40, 383, DateTimeKind.Local).AddTicks(2981));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 1, 20, 36, 40, 383, DateTimeKind.Local).AddTicks(2983));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 1, 20, 36, 40, 383, DateTimeKind.Local).AddTicks(2984));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 1, 20, 36, 40, 383, DateTimeKind.Local).AddTicks(2986));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 1, 20, 36, 40, 383, DateTimeKind.Local).AddTicks(2987));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 1, 20, 36, 40, 383, DateTimeKind.Local).AddTicks(2989));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 1, 20, 36, 40, 383, DateTimeKind.Local).AddTicks(2991));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 1, 20, 36, 40, 383, DateTimeKind.Local).AddTicks(2992));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 1, 20, 36, 40, 383, DateTimeKind.Local).AddTicks(2994));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 1, 20, 36, 40, 383, DateTimeKind.Local).AddTicks(2995));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 1, 20, 36, 40, 383, DateTimeKind.Local).AddTicks(2997));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 1, 20, 36, 40, 383, DateTimeKind.Local).AddTicks(2998));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 1, 20, 36, 40, 383, DateTimeKind.Local).AddTicks(3000));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 1, 20, 36, 40, 383, DateTimeKind.Local).AddTicks(3001));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 1, 20, 36, 40, 383, DateTimeKind.Local).AddTicks(3003));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 1, 20, 36, 40, 383, DateTimeKind.Local).AddTicks(3004));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 1, 20, 36, 40, 383, DateTimeKind.Local).AddTicks(3006));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 1, 20, 36, 40, 383, DateTimeKind.Local).AddTicks(3007));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 1, 20, 36, 40, 383, DateTimeKind.Local).AddTicks(3016));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 1, 20, 36, 40, 383, DateTimeKind.Local).AddTicks(3025));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 1, 20, 36, 40, 383, DateTimeKind.Local).AddTicks(3033));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 1, 20, 36, 40, 383, DateTimeKind.Local).AddTicks(3035));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 1, 20, 36, 40, 383, DateTimeKind.Local).AddTicks(3036));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 1, 20, 36, 40, 383, DateTimeKind.Local).AddTicks(3038));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 1, 20, 36, 40, 383, DateTimeKind.Local).AddTicks(3039));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 1, 20, 36, 40, 383, DateTimeKind.Local).AddTicks(3041));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 1, 20, 36, 40, 383, DateTimeKind.Local).AddTicks(3042));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 1, 20, 36, 40, 383, DateTimeKind.Local).AddTicks(3044));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 1, 20, 36, 40, 383, DateTimeKind.Local).AddTicks(2857));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 1, 20, 36, 40, 383, DateTimeKind.Local).AddTicks(2867));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 1, 20, 36, 40, 383, DateTimeKind.Local).AddTicks(2870));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 1, 20, 36, 40, 383, DateTimeKind.Local).AddTicks(2872));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 1, 20, 36, 40, 383, DateTimeKind.Local).AddTicks(2874));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 1, 20, 36, 40, 383, DateTimeKind.Local).AddTicks(2877));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 1, 20, 36, 40, 383, DateTimeKind.Local).AddTicks(2879));
        }
    }
}
