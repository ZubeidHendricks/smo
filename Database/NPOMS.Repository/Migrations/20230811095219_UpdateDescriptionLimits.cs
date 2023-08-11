using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NPOMS.Repository.Migrations
{
    public partial class UpdateDescriptionLimits : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "dbo",
                table: "SustainabilityPlans",
                type: "nvarchar(MAX)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(2000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "dbo",
                table: "Resources",
                type: "nvarchar(MAX)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(2000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "dbo",
                table: "Objectives",
                type: "nvarchar(MAX)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "lookup",
                table: "ActivityList",
                type: "nvarchar(MAX)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 11, 11, 52, 9, 706, DateTimeKind.Local).AddTicks(3861));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 11, 11, 52, 9, 706, DateTimeKind.Local).AddTicks(3863));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 11, 11, 52, 9, 706, DateTimeKind.Local).AddTicks(3865));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 11, 11, 52, 9, 706, DateTimeKind.Local).AddTicks(3866));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 11, 11, 52, 9, 706, DateTimeKind.Local).AddTicks(3868));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 11, 11, 52, 9, 706, DateTimeKind.Local).AddTicks(3869));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 11, 11, 52, 9, 706, DateTimeKind.Local).AddTicks(3870));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 11, 11, 52, 9, 706, DateTimeKind.Local).AddTicks(3872));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 11, 11, 52, 9, 706, DateTimeKind.Local).AddTicks(3873));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 11, 11, 52, 9, 706, DateTimeKind.Local).AddTicks(3874));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 11, 11, 52, 9, 706, DateTimeKind.Local).AddTicks(3876));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 11, 11, 52, 9, 706, DateTimeKind.Local).AddTicks(3877));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 11, 11, 52, 9, 706, DateTimeKind.Local).AddTicks(3878));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 11, 11, 52, 9, 706, DateTimeKind.Local).AddTicks(3880));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 11, 11, 52, 9, 706, DateTimeKind.Local).AddTicks(3881));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 11, 11, 52, 9, 706, DateTimeKind.Local).AddTicks(3882));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 11, 11, 52, 9, 706, DateTimeKind.Local).AddTicks(3884));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 11, 11, 52, 9, 706, DateTimeKind.Local).AddTicks(3885));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 11, 11, 52, 9, 706, DateTimeKind.Local).AddTicks(3886));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 11, 11, 52, 9, 706, DateTimeKind.Local).AddTicks(3888));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 11, 11, 52, 9, 706, DateTimeKind.Local).AddTicks(3889));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 11, 11, 52, 9, 706, DateTimeKind.Local).AddTicks(3890));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 11, 11, 52, 9, 706, DateTimeKind.Local).AddTicks(3897));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 11, 11, 52, 9, 706, DateTimeKind.Local).AddTicks(3911));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 11, 11, 52, 9, 706, DateTimeKind.Local).AddTicks(3912));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 11, 11, 52, 9, 706, DateTimeKind.Local).AddTicks(3913));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 11, 11, 52, 9, 706, DateTimeKind.Local).AddTicks(3915));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 11, 11, 52, 9, 706, DateTimeKind.Local).AddTicks(3916));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 11, 11, 52, 9, 706, DateTimeKind.Local).AddTicks(3917));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 11, 11, 52, 9, 706, DateTimeKind.Local).AddTicks(3918));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 11, 11, 52, 9, 706, DateTimeKind.Local).AddTicks(3920));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 11, 11, 52, 9, 706, DateTimeKind.Local).AddTicks(3921));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 11, 11, 52, 9, 706, DateTimeKind.Local).AddTicks(3759));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 11, 11, 52, 9, 706, DateTimeKind.Local).AddTicks(3776));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 11, 11, 52, 9, 706, DateTimeKind.Local).AddTicks(3779));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 11, 11, 52, 9, 706, DateTimeKind.Local).AddTicks(3780));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 11, 11, 52, 9, 706, DateTimeKind.Local).AddTicks(3782));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 11, 11, 52, 9, 706, DateTimeKind.Local).AddTicks(3784));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 11, 11, 52, 9, 706, DateTimeKind.Local).AddTicks(3785));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "dbo",
                table: "SustainabilityPlans",
                type: "nvarchar(2000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(MAX)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "dbo",
                table: "Resources",
                type: "nvarchar(2000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(MAX)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "dbo",
                table: "Objectives",
                type: "nvarchar(1000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(MAX)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "lookup",
                table: "ActivityList",
                type: "nvarchar(1000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(MAX)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 9, 5, 27, 57, 134, DateTimeKind.Local).AddTicks(7855));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 9, 5, 27, 57, 134, DateTimeKind.Local).AddTicks(7858));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 9, 5, 27, 57, 134, DateTimeKind.Local).AddTicks(7861));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 9, 5, 27, 57, 134, DateTimeKind.Local).AddTicks(7863));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 9, 5, 27, 57, 134, DateTimeKind.Local).AddTicks(7865));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 9, 5, 27, 57, 134, DateTimeKind.Local).AddTicks(7868));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 9, 5, 27, 57, 134, DateTimeKind.Local).AddTicks(7870));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 9, 5, 27, 57, 134, DateTimeKind.Local).AddTicks(7872));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 9, 5, 27, 57, 134, DateTimeKind.Local).AddTicks(7874));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 9, 5, 27, 57, 134, DateTimeKind.Local).AddTicks(7876));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 9, 5, 27, 57, 134, DateTimeKind.Local).AddTicks(7878));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 9, 5, 27, 57, 134, DateTimeKind.Local).AddTicks(7880));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 9, 5, 27, 57, 134, DateTimeKind.Local).AddTicks(7882));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 9, 5, 27, 57, 134, DateTimeKind.Local).AddTicks(7884));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 9, 5, 27, 57, 134, DateTimeKind.Local).AddTicks(7886));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 9, 5, 27, 57, 134, DateTimeKind.Local).AddTicks(7889));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 9, 5, 27, 57, 134, DateTimeKind.Local).AddTicks(7891));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 9, 5, 27, 57, 134, DateTimeKind.Local).AddTicks(7893));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 9, 5, 27, 57, 134, DateTimeKind.Local).AddTicks(7895));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 9, 5, 27, 57, 134, DateTimeKind.Local).AddTicks(7897));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 9, 5, 27, 57, 134, DateTimeKind.Local).AddTicks(7905));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 9, 5, 27, 57, 134, DateTimeKind.Local).AddTicks(7908));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 9, 5, 27, 57, 134, DateTimeKind.Local).AddTicks(7915));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 9, 5, 27, 57, 134, DateTimeKind.Local).AddTicks(7933));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 9, 5, 27, 57, 134, DateTimeKind.Local).AddTicks(7935));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 9, 5, 27, 57, 134, DateTimeKind.Local).AddTicks(7937));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 9, 5, 27, 57, 134, DateTimeKind.Local).AddTicks(7939));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 9, 5, 27, 57, 134, DateTimeKind.Local).AddTicks(7941));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 9, 5, 27, 57, 134, DateTimeKind.Local).AddTicks(7943));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 9, 5, 27, 57, 134, DateTimeKind.Local).AddTicks(7945));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 9, 5, 27, 57, 134, DateTimeKind.Local).AddTicks(7947));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 9, 5, 27, 57, 134, DateTimeKind.Local).AddTicks(7949));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 9, 5, 27, 57, 134, DateTimeKind.Local).AddTicks(7696));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 9, 5, 27, 57, 134, DateTimeKind.Local).AddTicks(7718));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 9, 5, 27, 57, 134, DateTimeKind.Local).AddTicks(7722));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 9, 5, 27, 57, 134, DateTimeKind.Local).AddTicks(7725));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 9, 5, 27, 57, 134, DateTimeKind.Local).AddTicks(7728));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 9, 5, 27, 57, 134, DateTimeKind.Local).AddTicks(7731));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 9, 5, 27, 57, 134, DateTimeKind.Local).AddTicks(7733));
        }
    }
}
