using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NPOMS.Repository.Migrations
{
    /// <inheritdoc />
    public partial class AddedNewColumnsIn_Applications_ProjectInformation_MonitoringEvaluation_Programm_Bank_Contact_ServiceDelivery_Tables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ApplicationId",
                schema: "fa",
                table: "ProjectInformation",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDateTime",
                schema: "fa",
                table: "ProjectInformation",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedUserId",
                schema: "fa",
                table: "ProjectInformation",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                schema: "fa",
                table: "ProjectInformation",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsNew",
                schema: "fa",
                table: "ProjectInformation",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDateTime",
                schema: "fa",
                table: "ProjectInformation",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpdatedUserId",
                schema: "fa",
                table: "ProjectInformation",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDateTime",
                schema: "fa",
                table: "ProjectImplementations",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedUserId",
                schema: "fa",
                table: "ProjectImplementations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDateTime",
                schema: "fa",
                table: "ProjectImplementations",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpdatedUserId",
                schema: "fa",
                table: "ProjectImplementations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsSubmitted",
                schema: "dbo",
                table: "ProgrammeServiceDelivery",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "SubProgrammeId",
                schema: "dbo",
                table: "ProgrammeServiceDelivery",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SubProgrammeTypeId",
                schema: "dbo",
                table: "ProgrammeServiceDelivery",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsSubmitted",
                schema: "dbo",
                table: "ProgramContactInformation",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "SubProgrammeId",
                schema: "dbo",
                table: "ProgramContactInformation",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SubProgrammeTypeId",
                schema: "dbo",
                table: "ProgramContactInformation",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsSubmitted",
                schema: "dbo",
                table: "ProgramBankDetails",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "SubProgrammeId",
                schema: "dbo",
                table: "ProgramBankDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SubProgrammeTypeId",
                schema: "dbo",
                table: "ProgramBankDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProgrammeId",
                schema: "dbo",
                table: "Applications",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SubProgrammeId",
                schema: "dbo",
                table: "Applications",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SubProgrammeTypeId",
                schema: "dbo",
                table: "Applications",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                schema: "core",
                table: "EmailTemplates",
                columns: new[] { "Id", "Body", "Description", "Name", "Subject" },
                values: new object[] { 27, "<p>Dear Applicant - {OrganizationName}</p><p>We acknowledge receipt of your submitted application with ref no: <strong>{ApplicationRefNo}.</strong></p><p>This application will now undergo review, and the outcome will be communicated in due course.</p>Kind Regards,</p><p>NPO MS Team</p>", null, "DSDFundingApplicationSubmitted", "DSD Funding Application Acknowledgement Confirmation – (Submitted Pending Review Status)" });

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 29, 15, 13, 22, 49, DateTimeKind.Local).AddTicks(4409));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 29, 15, 13, 22, 49, DateTimeKind.Local).AddTicks(4437));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 29, 15, 13, 22, 49, DateTimeKind.Local).AddTicks(4440));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 29, 15, 13, 22, 49, DateTimeKind.Local).AddTicks(4443));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 29, 15, 13, 22, 49, DateTimeKind.Local).AddTicks(4446));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 29, 15, 13, 22, 49, DateTimeKind.Local).AddTicks(4448));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 29, 15, 13, 22, 49, DateTimeKind.Local).AddTicks(4451));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 29, 15, 13, 22, 49, DateTimeKind.Local).AddTicks(4454));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 29, 15, 13, 22, 49, DateTimeKind.Local).AddTicks(4457));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 29, 15, 13, 22, 49, DateTimeKind.Local).AddTicks(4459));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 29, 15, 13, 22, 49, DateTimeKind.Local).AddTicks(4462));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 29, 15, 13, 22, 49, DateTimeKind.Local).AddTicks(4464));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 29, 15, 13, 22, 49, DateTimeKind.Local).AddTicks(4467));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 29, 15, 13, 22, 49, DateTimeKind.Local).AddTicks(4469));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 29, 15, 13, 22, 49, DateTimeKind.Local).AddTicks(4472));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 29, 15, 13, 22, 49, DateTimeKind.Local).AddTicks(4475));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 29, 15, 13, 22, 49, DateTimeKind.Local).AddTicks(4478));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 29, 15, 13, 22, 49, DateTimeKind.Local).AddTicks(4481));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 29, 15, 13, 22, 49, DateTimeKind.Local).AddTicks(4483));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 29, 15, 13, 22, 49, DateTimeKind.Local).AddTicks(4486));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 29, 15, 13, 22, 49, DateTimeKind.Local).AddTicks(4488));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 29, 15, 13, 22, 49, DateTimeKind.Local).AddTicks(4506));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 29, 15, 13, 22, 49, DateTimeKind.Local).AddTicks(4508));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 29, 15, 13, 22, 49, DateTimeKind.Local).AddTicks(4511));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 29, 15, 13, 22, 49, DateTimeKind.Local).AddTicks(4513));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 29, 15, 13, 22, 49, DateTimeKind.Local).AddTicks(4516));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 29, 15, 13, 22, 49, DateTimeKind.Local).AddTicks(4518));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 29, 15, 13, 22, 49, DateTimeKind.Local).AddTicks(4521));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 29, 15, 13, 22, 49, DateTimeKind.Local).AddTicks(4523));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 29, 15, 13, 22, 49, DateTimeKind.Local).AddTicks(4529));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 29, 15, 13, 22, 49, DateTimeKind.Local).AddTicks(4548));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 29, 15, 13, 22, 49, DateTimeKind.Local).AddTicks(4551));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 29, 15, 13, 22, 49, DateTimeKind.Local).AddTicks(5461));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 29, 15, 13, 22, 49, DateTimeKind.Local).AddTicks(5467));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 29, 15, 13, 22, 49, DateTimeKind.Local).AddTicks(5471));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 29, 15, 13, 22, 49, DateTimeKind.Local).AddTicks(5524));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 29, 15, 13, 22, 49, DateTimeKind.Local).AddTicks(5528));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 29, 15, 13, 22, 49, DateTimeKind.Local).AddTicks(5532));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 29, 15, 13, 22, 49, DateTimeKind.Local).AddTicks(5535));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "core",
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DropColumn(
                name: "ApplicationId",
                schema: "fa",
                table: "ProjectInformation");

            migrationBuilder.DropColumn(
                name: "CreatedDateTime",
                schema: "fa",
                table: "ProjectInformation");

            migrationBuilder.DropColumn(
                name: "CreatedUserId",
                schema: "fa",
                table: "ProjectInformation");

            migrationBuilder.DropColumn(
                name: "IsActive",
                schema: "fa",
                table: "ProjectInformation");

            migrationBuilder.DropColumn(
                name: "IsNew",
                schema: "fa",
                table: "ProjectInformation");

            migrationBuilder.DropColumn(
                name: "UpdatedDateTime",
                schema: "fa",
                table: "ProjectInformation");

            migrationBuilder.DropColumn(
                name: "UpdatedUserId",
                schema: "fa",
                table: "ProjectInformation");

            migrationBuilder.DropColumn(
                name: "CreatedDateTime",
                schema: "fa",
                table: "ProjectImplementations");

            migrationBuilder.DropColumn(
                name: "CreatedUserId",
                schema: "fa",
                table: "ProjectImplementations");

            migrationBuilder.DropColumn(
                name: "UpdatedDateTime",
                schema: "fa",
                table: "ProjectImplementations");

            migrationBuilder.DropColumn(
                name: "UpdatedUserId",
                schema: "fa",
                table: "ProjectImplementations");

            migrationBuilder.DropColumn(
                name: "IsSubmitted",
                schema: "dbo",
                table: "ProgrammeServiceDelivery");

            migrationBuilder.DropColumn(
                name: "SubProgrammeId",
                schema: "dbo",
                table: "ProgrammeServiceDelivery");

            migrationBuilder.DropColumn(
                name: "SubProgrammeTypeId",
                schema: "dbo",
                table: "ProgrammeServiceDelivery");

            migrationBuilder.DropColumn(
                name: "IsSubmitted",
                schema: "dbo",
                table: "ProgramContactInformation");

            migrationBuilder.DropColumn(
                name: "SubProgrammeId",
                schema: "dbo",
                table: "ProgramContactInformation");

            migrationBuilder.DropColumn(
                name: "SubProgrammeTypeId",
                schema: "dbo",
                table: "ProgramContactInformation");

            migrationBuilder.DropColumn(
                name: "IsSubmitted",
                schema: "dbo",
                table: "ProgramBankDetails");

            migrationBuilder.DropColumn(
                name: "SubProgrammeId",
                schema: "dbo",
                table: "ProgramBankDetails");

            migrationBuilder.DropColumn(
                name: "SubProgrammeTypeId",
                schema: "dbo",
                table: "ProgramBankDetails");

            migrationBuilder.DropColumn(
                name: "ProgrammeId",
                schema: "dbo",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "SubProgrammeId",
                schema: "dbo",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "SubProgrammeTypeId",
                schema: "dbo",
                table: "Applications");

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 24, 13, 54, 49, 826, DateTimeKind.Local).AddTicks(387));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 24, 13, 54, 49, 826, DateTimeKind.Local).AddTicks(401));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 24, 13, 54, 49, 826, DateTimeKind.Local).AddTicks(402));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 24, 13, 54, 49, 826, DateTimeKind.Local).AddTicks(404));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 24, 13, 54, 49, 826, DateTimeKind.Local).AddTicks(405));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 24, 13, 54, 49, 826, DateTimeKind.Local).AddTicks(406));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 24, 13, 54, 49, 826, DateTimeKind.Local).AddTicks(408));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 24, 13, 54, 49, 826, DateTimeKind.Local).AddTicks(409));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 24, 13, 54, 49, 826, DateTimeKind.Local).AddTicks(411));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 24, 13, 54, 49, 826, DateTimeKind.Local).AddTicks(412));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 24, 13, 54, 49, 826, DateTimeKind.Local).AddTicks(413));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 24, 13, 54, 49, 826, DateTimeKind.Local).AddTicks(415));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 24, 13, 54, 49, 826, DateTimeKind.Local).AddTicks(416));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 24, 13, 54, 49, 826, DateTimeKind.Local).AddTicks(417));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 24, 13, 54, 49, 826, DateTimeKind.Local).AddTicks(419));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 24, 13, 54, 49, 826, DateTimeKind.Local).AddTicks(420));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 24, 13, 54, 49, 826, DateTimeKind.Local).AddTicks(421));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 24, 13, 54, 49, 826, DateTimeKind.Local).AddTicks(423));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 24, 13, 54, 49, 826, DateTimeKind.Local).AddTicks(424));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 24, 13, 54, 49, 826, DateTimeKind.Local).AddTicks(425));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 24, 13, 54, 49, 826, DateTimeKind.Local).AddTicks(426));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 24, 13, 54, 49, 826, DateTimeKind.Local).AddTicks(428));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 24, 13, 54, 49, 826, DateTimeKind.Local).AddTicks(429));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 24, 13, 54, 49, 826, DateTimeKind.Local).AddTicks(431));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 24, 13, 54, 49, 826, DateTimeKind.Local).AddTicks(432));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 24, 13, 54, 49, 826, DateTimeKind.Local).AddTicks(433));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 24, 13, 54, 49, 826, DateTimeKind.Local).AddTicks(434));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 24, 13, 54, 49, 826, DateTimeKind.Local).AddTicks(436));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 24, 13, 54, 49, 826, DateTimeKind.Local).AddTicks(437));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 24, 13, 54, 49, 826, DateTimeKind.Local).AddTicks(438));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 24, 13, 54, 49, 826, DateTimeKind.Local).AddTicks(440));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 24, 13, 54, 49, 826, DateTimeKind.Local).AddTicks(441));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 24, 13, 54, 49, 826, DateTimeKind.Local).AddTicks(950));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 24, 13, 54, 49, 826, DateTimeKind.Local).AddTicks(954));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 24, 13, 54, 49, 826, DateTimeKind.Local).AddTicks(956));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 24, 13, 54, 49, 826, DateTimeKind.Local).AddTicks(958));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 24, 13, 54, 49, 826, DateTimeKind.Local).AddTicks(960));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 24, 13, 54, 49, 826, DateTimeKind.Local).AddTicks(962));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 24, 13, 54, 49, 826, DateTimeKind.Local).AddTicks(963));
        }
    }
}
