using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NPOMS.Repository.Migrations
{
    public partial class DocumentTypeConfigUpdates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "core",
                table: "DocumentTypes",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 9, 4, 17, 25, 344, DateTimeKind.Local).AddTicks(6565));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 9, 4, 17, 25, 344, DateTimeKind.Local).AddTicks(6567));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 9, 4, 17, 25, 344, DateTimeKind.Local).AddTicks(6569));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 9, 4, 17, 25, 344, DateTimeKind.Local).AddTicks(6570));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 9, 4, 17, 25, 344, DateTimeKind.Local).AddTicks(6572));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 9, 4, 17, 25, 344, DateTimeKind.Local).AddTicks(6573));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 9, 4, 17, 25, 344, DateTimeKind.Local).AddTicks(6574));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 9, 4, 17, 25, 344, DateTimeKind.Local).AddTicks(6576));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 9, 4, 17, 25, 344, DateTimeKind.Local).AddTicks(6577));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 9, 4, 17, 25, 344, DateTimeKind.Local).AddTicks(6578));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 9, 4, 17, 25, 344, DateTimeKind.Local).AddTicks(6579));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 9, 4, 17, 25, 344, DateTimeKind.Local).AddTicks(6581));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 9, 4, 17, 25, 344, DateTimeKind.Local).AddTicks(6582));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 9, 4, 17, 25, 344, DateTimeKind.Local).AddTicks(6583));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 9, 4, 17, 25, 344, DateTimeKind.Local).AddTicks(6584));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 9, 4, 17, 25, 344, DateTimeKind.Local).AddTicks(6585));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 9, 4, 17, 25, 344, DateTimeKind.Local).AddTicks(6586));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 9, 4, 17, 25, 344, DateTimeKind.Local).AddTicks(6627));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 9, 4, 17, 25, 344, DateTimeKind.Local).AddTicks(6629));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 9, 4, 17, 25, 344, DateTimeKind.Local).AddTicks(6630));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 9, 4, 17, 25, 344, DateTimeKind.Local).AddTicks(6646));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 9, 4, 17, 25, 344, DateTimeKind.Local).AddTicks(6647));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 9, 4, 17, 25, 344, DateTimeKind.Local).AddTicks(6654));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 9, 4, 17, 25, 344, DateTimeKind.Local).AddTicks(6676));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 9, 4, 17, 25, 344, DateTimeKind.Local).AddTicks(6677));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 9, 4, 17, 25, 344, DateTimeKind.Local).AddTicks(6679));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 9, 4, 17, 25, 344, DateTimeKind.Local).AddTicks(6680));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 9, 4, 17, 25, 344, DateTimeKind.Local).AddTicks(6681));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 9, 4, 17, 25, 344, DateTimeKind.Local).AddTicks(6682));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 9, 4, 17, 25, 344, DateTimeKind.Local).AddTicks(6683));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 9, 4, 17, 25, 344, DateTimeKind.Local).AddTicks(6684));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 9, 4, 17, 25, 344, DateTimeKind.Local).AddTicks(6685));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 9, 4, 17, 25, 344, DateTimeKind.Local).AddTicks(6441));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 9, 4, 17, 25, 344, DateTimeKind.Local).AddTicks(6462));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 9, 4, 17, 25, 344, DateTimeKind.Local).AddTicks(6465));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 9, 4, 17, 25, 344, DateTimeKind.Local).AddTicks(6467));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 9, 4, 17, 25, 344, DateTimeKind.Local).AddTicks(6468));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 9, 4, 17, 25, 344, DateTimeKind.Local).AddTicks(6470));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2023, 8, 9, 4, 17, 25, 344, DateTimeKind.Local).AddTicks(6471));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TrainingMaterials",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Description", "Link", "Name" },
                values: new object[] { "DSD NPO Application Form with Annexures (collated)", "https://www.westerncape.gov.za/assets/departments/social-development/CFP/dsd_npo_application_form.pdf", "DSD NPO Application Form" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TrainingMaterials",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Description", "Link", "Name" },
                values: new object[] { "DSD NPO Application Form - Declaration of interest", "https://www.westerncape.gov.za/assets/departments/social-development/CFP/npo_application_form_-_declaration_of_interest.pdf", "Application Form - Declaration of interest" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TrainingMaterials",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Description", "Link", "Name" },
                values: new object[] { "DSD NPO Application Form - BAS entity bank details form", "https://www.westerncape.gov.za/assets/departments/social-development/CFP/npo_application_form_-_dsd_bas_entity_bank_details_form.pdf", "Application Form - BAS entity bank details form" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TrainingMaterials",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Description", "Link", "Name" },
                values: new object[] { "DSD NPO Application Form - Schedule A Enrolment form (After School Care only)", "https://www.westerncape.gov.za/assets/departments/social-development/CFP/npo_application_form_-_schedule_a_enrolment_form_-_afterschool_care_only.pdf", "Application Form - Schedule A Enrolment form (After School Care only)" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TrainingMaterials",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Description", "Link", "Name" },
                values: new object[] { "DSD NPO Application Form - Written Assurance", "https://www.westerncape.gov.za/assets/departments/social-development/CFP/npo_application_form_-_written_assurance.pdf", "Application Form - Written Assurance" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "TrainingMaterials",
                columns: new[] { "Id", "Description", "IsActive", "Link", "Name", "UpdatedDateTime", "UpdatedUserId" },
                values: new object[,]
                {
                    { 14, "DSD NPO Application Declaration - Online Applications only", true, "https://www.westerncape.gov.za/assets/departments/social-development/dsd_npo_application_declaration_-_online_applications_only.pdf", "Application Declaration - Online Applications only", null, null },
                    { 15, "DSD Call For Proposal Frequently Asked Questions", true, "https://www.westerncape.gov.za/assets/departments/social-development/CFP/frequently_asked_questions_-_2023_call_for_proposals.pdf", "Frequently Asked Questions", null, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "TrainingMaterials",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "TrainingMaterials",
                keyColumn: "Id",
                keyValue: 15);

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

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TrainingMaterials",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Description", "Link", "Name" },
                values: new object[] { "DSD NPO Application Form - Declaration of interest", "https://www.westerncape.gov.za/assets/departments/social-development/CFP/npo_application_form_-_declaration_of_interest.pdf", "Application Form - Declaration of interest" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TrainingMaterials",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Description", "Link", "Name" },
                values: new object[] { "DSD NPO Application Form - BAS entity bank details form", "https://www.westerncape.gov.za/assets/departments/social-development/CFP/npo_application_form_-_dsd_bas_entity_bank_details_form.pdf", "Application Form - BAS entity bank details form" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TrainingMaterials",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Description", "Link", "Name" },
                values: new object[] { "DSD NPO Application Form - Schedule A Enrolment form (After School Care only)", "https://www.westerncape.gov.za/assets/departments/social-development/CFP/npo_application_form_-_schedule_a_enrolment_form_-_afterschool_care_only.pdf", "Application Form - Schedule A Enrolment form (After School Care only)" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TrainingMaterials",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Description", "Link", "Name" },
                values: new object[] { "DSD NPO Application Form - Written Assurance", "https://www.westerncape.gov.za/assets/departments/social-development/CFP/npo_application_form_-_written_assurance.pdf", "Application Form - Written Assurance" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TrainingMaterials",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Description", "Link", "Name" },
                values: new object[] { "DSD Call For Proposal Frequently Asked Questions", "https://www.westerncape.gov.za/assets/departments/social-development/CFP/frequently_asked_questions_-_2023_call_for_proposals.pdf", "Frequently Asked Questions" });
        }
    }
}
