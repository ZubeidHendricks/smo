using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NPOMS.Repository.Migrations
{
    public partial class DropdownFillingSDA : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "core",
                table: "DocumentTypes",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "TrainingMaterials",
                keyColumn: "Id",
                keyValue: 14);

            //migrationBuilder.AddColumn<int>(
            //    name: "ExternalId",
            //    schema: "dropdown",
            //    table: "SubPlaces",
            //    type: "int",
            //    nullable: true);

            //migrationBuilder.AddColumn<int>(
            //    name: "ExternalId",
            //    schema: "dropdown",
            //    table: "ServiceDeliveryAreas",
            //    type: "int",
            //    nullable: true);

            //migrationBuilder.AddColumn<string>(
            //    name: "SystemName",
            //    schema: "dropdown",
            //    table: "ServiceDeliveryAreas",
            //    type: "nvarchar(max)",
            //    nullable: true);

            //migrationBuilder.AddColumn<string>(
            //    name: "SystemName",
            //    schema: "dropdown",
            //    table: "Regions",
            //    type: "nvarchar(max)",
            //    nullable: true);

            //migrationBuilder.AddColumn<int>(
            //    name: "ExternalId",
            //    schema: "dropdown",
            //    table: "Places",
            //    type: "int",
            //    nullable: true);

            //migrationBuilder.AddColumn<string>(
            //    name: "SystemName",
            //    schema: "dropdown",
            //    table: "LocalMunicipalities",
            //    type: "nvarchar(max)",
            //    nullable: true);

            migrationBuilder.UpdateData(
                schema: "core",
                table: "DocumentTypes",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Description", "Name" },
                values: new object[] { "NPC/ Trust / PBO Registration Certificate (copies of all applicable)", "Org Registration Certificate" });

            //migrationBuilder.InsertData(
            //    schema: "core",
            //    table: "DocumentTypes",
            //    columns: new[] { "Id", "Description", "IsActive", "Location", "Name", "UpdatedDateTime", "UpdatedUserId" },
            //    values: new object[] { 20, "Signed Declaration of Interest", true, "FundApp", "Signed Declaration of Interest", null, null });

            //migrationBuilder.InsertData(
            //    schema: "core",
            //    table: "Permissions",
            //    columns: new[] { "Id", "CategoryName", "Name", "SystemName", "UpdatedDateTime", "UpdatedUserId" },
            //    values: new object[,]
            //    {
            //        { 96, "Quick Capture", "View Quick Capture", "QC.View", null, null },
            //        { 97, "Quick Capture", "View Quick Capture", "QC.View", null, null },
            //        { 98, "View Application", "View Submitted Application", "WFA.View", null, null },
            //        { 99, "Download Application", "Download Submitted Application", "WFA.Download", null, null },
            //        { 100, "Download Application", "Edit Application", "WFA.Edit", null, null },
            //        { 101, "Delete Application", "Delete Application", "WFA.Delete", null, null }
            //    });

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 7, 12, 31, 35, 580, DateTimeKind.Local).AddTicks(3589));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 7, 12, 31, 35, 580, DateTimeKind.Local).AddTicks(3592));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 7, 12, 31, 35, 580, DateTimeKind.Local).AddTicks(3594));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 7, 12, 31, 35, 580, DateTimeKind.Local).AddTicks(3596));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 7, 12, 31, 35, 580, DateTimeKind.Local).AddTicks(3597));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 7, 12, 31, 35, 580, DateTimeKind.Local).AddTicks(3599));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 7, 12, 31, 35, 580, DateTimeKind.Local).AddTicks(3601));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 7, 12, 31, 35, 580, DateTimeKind.Local).AddTicks(3602));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 7, 12, 31, 35, 580, DateTimeKind.Local).AddTicks(3604));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 7, 12, 31, 35, 580, DateTimeKind.Local).AddTicks(3605));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 7, 12, 31, 35, 580, DateTimeKind.Local).AddTicks(3607));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 7, 12, 31, 35, 580, DateTimeKind.Local).AddTicks(3609));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 7, 12, 31, 35, 580, DateTimeKind.Local).AddTicks(3610));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 7, 12, 31, 35, 580, DateTimeKind.Local).AddTicks(3612));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 7, 12, 31, 35, 580, DateTimeKind.Local).AddTicks(3614));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 7, 12, 31, 35, 580, DateTimeKind.Local).AddTicks(3618));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 7, 12, 31, 35, 580, DateTimeKind.Local).AddTicks(3619));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 7, 12, 31, 35, 580, DateTimeKind.Local).AddTicks(3621));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 7, 12, 31, 35, 580, DateTimeKind.Local).AddTicks(3623));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 7, 12, 31, 35, 580, DateTimeKind.Local).AddTicks(3624));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 7, 12, 31, 35, 580, DateTimeKind.Local).AddTicks(3637));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 7, 12, 31, 35, 580, DateTimeKind.Local).AddTicks(3639));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 7, 12, 31, 35, 580, DateTimeKind.Local).AddTicks(3650));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 7, 12, 31, 35, 580, DateTimeKind.Local).AddTicks(3671));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 7, 12, 31, 35, 580, DateTimeKind.Local).AddTicks(3672));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 7, 12, 31, 35, 580, DateTimeKind.Local).AddTicks(3674));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 7, 12, 31, 35, 580, DateTimeKind.Local).AddTicks(3675));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 7, 12, 31, 35, 580, DateTimeKind.Local).AddTicks(3677));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 7, 12, 31, 35, 580, DateTimeKind.Local).AddTicks(3678));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 7, 12, 31, 35, 580, DateTimeKind.Local).AddTicks(3680));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 7, 12, 31, 35, 580, DateTimeKind.Local).AddTicks(3681));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 7, 12, 31, 35, 580, DateTimeKind.Local).AddTicks(3683));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 7, 12, 31, 35, 580, DateTimeKind.Local).AddTicks(3429));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 7, 12, 31, 35, 580, DateTimeKind.Local).AddTicks(3449));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 7, 12, 31, 35, 580, DateTimeKind.Local).AddTicks(3487));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 7, 12, 31, 35, 580, DateTimeKind.Local).AddTicks(3489));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 7, 12, 31, 35, 580, DateTimeKind.Local).AddTicks(3491));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 7, 12, 31, 35, 580, DateTimeKind.Local).AddTicks(3494));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 7, 12, 31, 35, 580, DateTimeKind.Local).AddTicks(3496));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "core",
                table: "DocumentTypes",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 97);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 98);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 99);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 101);

            //migrationBuilder.DropColumn(
            //    name: "ExternalId",
            //    schema: "dropdown",
            //    table: "SubPlaces");

            //migrationBuilder.DropColumn(
            //    name: "ExternalId",
            //    schema: "dropdown",
            //    table: "ServiceDeliveryAreas");

            //migrationBuilder.DropColumn(
            //    name: "SystemName",
            //    schema: "dropdown",
            //    table: "ServiceDeliveryAreas");

            //migrationBuilder.DropColumn(
            //    name: "SystemName",
            //    schema: "dropdown",
            //    table: "Regions");

            //migrationBuilder.DropColumn(
            //    name: "ExternalId",
            //    schema: "dropdown",
            //    table: "Places");

            //migrationBuilder.DropColumn(
            //    name: "SystemName",
            //    schema: "dropdown",
            //    table: "LocalMunicipalities");

            migrationBuilder.UpdateData(
                schema: "core",
                table: "DocumentTypes",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Signed Declaration of Interest", "Signed Declaration of Interest" });

            migrationBuilder.InsertData(
                schema: "core",
                table: "DocumentTypes",
                columns: new[] { "Id", "CreatedDateTime", "CreatedUserId", "Description", "IsActive", "IsCompulsory", "Location", "Name", "UpdatedDateTime", "UpdatedUserId" },
                values: new object[] { 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "NPC/ Trust / PBO Registration Certificate (copies of all applicable)", true, false, "FundApp", "Org Registration Certificate", null, null });

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 28, 19, 1, 32, 109, DateTimeKind.Local).AddTicks(2347));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 28, 19, 1, 32, 109, DateTimeKind.Local).AddTicks(2349));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 28, 19, 1, 32, 109, DateTimeKind.Local).AddTicks(2350));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 28, 19, 1, 32, 109, DateTimeKind.Local).AddTicks(2351));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 28, 19, 1, 32, 109, DateTimeKind.Local).AddTicks(2352));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 28, 19, 1, 32, 109, DateTimeKind.Local).AddTicks(2353));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 28, 19, 1, 32, 109, DateTimeKind.Local).AddTicks(2354));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 28, 19, 1, 32, 109, DateTimeKind.Local).AddTicks(2355));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 28, 19, 1, 32, 109, DateTimeKind.Local).AddTicks(2356));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 28, 19, 1, 32, 109, DateTimeKind.Local).AddTicks(2357));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 28, 19, 1, 32, 109, DateTimeKind.Local).AddTicks(2359));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 28, 19, 1, 32, 109, DateTimeKind.Local).AddTicks(2360));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 28, 19, 1, 32, 109, DateTimeKind.Local).AddTicks(2361));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 28, 19, 1, 32, 109, DateTimeKind.Local).AddTicks(2362));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 28, 19, 1, 32, 109, DateTimeKind.Local).AddTicks(2363));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 28, 19, 1, 32, 109, DateTimeKind.Local).AddTicks(2364));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 28, 19, 1, 32, 109, DateTimeKind.Local).AddTicks(2365));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 28, 19, 1, 32, 109, DateTimeKind.Local).AddTicks(2366));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 28, 19, 1, 32, 109, DateTimeKind.Local).AddTicks(2367));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 28, 19, 1, 32, 109, DateTimeKind.Local).AddTicks(2368));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 28, 19, 1, 32, 109, DateTimeKind.Local).AddTicks(2375));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 28, 19, 1, 32, 109, DateTimeKind.Local).AddTicks(2376));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 28, 19, 1, 32, 109, DateTimeKind.Local).AddTicks(2383));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 28, 19, 1, 32, 109, DateTimeKind.Local).AddTicks(2399));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 28, 19, 1, 32, 109, DateTimeKind.Local).AddTicks(2400));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 28, 19, 1, 32, 109, DateTimeKind.Local).AddTicks(2401));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 28, 19, 1, 32, 109, DateTimeKind.Local).AddTicks(2402));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 28, 19, 1, 32, 109, DateTimeKind.Local).AddTicks(2403));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 28, 19, 1, 32, 109, DateTimeKind.Local).AddTicks(2404));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 28, 19, 1, 32, 109, DateTimeKind.Local).AddTicks(2405));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 28, 19, 1, 32, 109, DateTimeKind.Local).AddTicks(2407));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 28, 19, 1, 32, 109, DateTimeKind.Local).AddTicks(2408));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 28, 19, 1, 32, 109, DateTimeKind.Local).AddTicks(2250));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 28, 19, 1, 32, 109, DateTimeKind.Local).AddTicks(2272));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 28, 19, 1, 32, 109, DateTimeKind.Local).AddTicks(2274));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 28, 19, 1, 32, 109, DateTimeKind.Local).AddTicks(2275));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 28, 19, 1, 32, 109, DateTimeKind.Local).AddTicks(2276));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 28, 19, 1, 32, 109, DateTimeKind.Local).AddTicks(2278));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 28, 19, 1, 32, 109, DateTimeKind.Local).AddTicks(2279));

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "TrainingMaterials",
                columns: new[] { "Id", "CreatedDateTime", "CreatedUserId", "Description", "IsActive", "Link", "Name", "UpdatedDateTime", "UpdatedUserId" },
                values: new object[] { 14, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "DSD Call For Proposal Frequently Asked Questions", true, "https://www.westerncape.gov.za/assets/departments/social-development/CFP/frequently_asked_questions_-_2023_call_for_proposals.pdf", "Frequently Asked Questions", null, null });
        }
    }
}
