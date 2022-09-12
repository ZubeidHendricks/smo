using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NPOMS.Repository.Migrations
{
    public partial class AddSubProgrammeTypeDropdown : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SystemName",
                schema: "dropdown",
                table: "SubProgrammes");

            migrationBuilder.DropColumn(
                name: "SystemName",
                schema: "dropdown",
                table: "Programmes");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                schema: "dropdown",
                table: "SubProgrammes",
                type: "nvarchar(1000)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                schema: "dropdown",
                table: "Programmes",
                type: "nvarchar(1000)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "SubProgrammeTypes",
                schema: "dropdown",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", nullable: false),
                    SubProgrammeId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1"),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
                    UpdatedUserId = table.Column<int>(type: "int", nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubProgrammeTypes", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "core",
                table: "EntityTypes",
                columns: new[] { "Id", "Name", "SystemName", "UpdatedDateTime", "UpdatedUserId" },
                values: new object[] { 3, "Workplan Actuals", "WorkplanActuals", null, null });

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "Programmes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "All Programmes");

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "Programmes",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "Chronic Diseases and Non-Communicable Diseases");

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "Programmes",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: "HIV/AIDS, TB, STI");

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "Programmes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Maternal, Women and Child Health", "Maternal, Women and Child Health" });

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "Programmes",
                keyColumn: "Id",
                keyValue: 5,
                column: "Description",
                value: "Theatre, Surgery and Aneasthetics");

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "Programmes",
                keyColumn: "Id",
                keyValue: 6,
                column: "Description",
                value: "Mental Health");

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "Programmes",
                keyColumn: "Id",
                keyValue: 7,
                column: "Description",
                value: "Emergency Centre Presures");

            migrationBuilder.InsertData(
                schema: "dropdown",
                table: "Programmes",
                columns: new[] { "Id", "DepartmentId", "Description", "Name", "UpdatedDateTime", "UpdatedUserId" },
                values: new object[,]
                {
                    { 8, 7, "Care and Support to Families", "Care and Support to Families", null, null },
                    { 9, 7, "Child Care and Protection Services", "Child Care and Protection Services", null, null },
                    { 10, 7, "Crime Prevention", "Crime Prevention", null, null },
                    { 11, 7, "ECD & Partial Care", "ECD & Partial Care", null, null },
                    { 12, 7, "EPWP", "EPWP", null, null },
                    { 13, 7, "Facility Managment", "Facility Managment", null, null },
                    { 14, 7, "Institutional Capacity Building", "Institutional Capacity Building", null, null },
                    { 15, 7, "Care and Services to Older Persons", "Care and Services to Older Persons", null, null },
                    { 16, 7, "Services to persons with Disabilities", "Services to persons with Disabilities", null, null },
                    { 17, 7, "Substance Abuse", "Substance Abuse", null, null },
                    { 18, 7, "Sustainable Livelihood", "Sustainable Livelihood", null, null },
                    { 19, 7, "Victim Empowerment", "Victim Empowerment", null, null },
                    { 20, 7, "Youth Development", "Youth Development", null, null },
                    { 21, 7, "Child and Youth Care Centres", "Child and Youth Care Centres", null, null },
                    { 22, 7, "ECD Conditional Grant", "ECD Conditional Grant", null, null }
                });

            migrationBuilder.InsertData(
                schema: "dropdown",
                table: "SubProgrammeTypes",
                columns: new[] { "Id", "Description", "Name", "SubProgrammeId", "UpdatedDateTime", "UpdatedUserId" },
                values: new object[,]
                {
                    { 1, "All Sub-Programme Types", "All Sub-Programme Types", 1, null, null },
                    { 2, "Chronic Diseases", "Chronic Diseases", 2, null, null },
                    { 3, "NCDs", "NCDs", 3, null, null },
                    { 4, "HIV/AIDS", "HIV/AIDS", 4, null, null },
                    { 5, "TB", "TB", 5, null, null },
                    { 6, "STI", "STI", 6, null, null },
                    { 7, "Maternal Health", "Maternal Health", 7, null, null },
                    { 8, "Women's Health", "Women's Health", 8, null, null },
                    { 9, "Child and Adolescent Health", "Child and Adolescent Health", 9, null, null },
                    { 10, "Theatre", "Theatre", 10, null, null },
                    { 11, "Surgery", "Surgery", 11, null, null },
                    { 12, "Anaethetics", "Anaethetics", 12, null, null },
                    { 13, "Mental Health", "Mental Health", 13, null, null },
                    { 14, "Emerency Centre Pressures", "Emerency Centre Pressures", 14, null, null },
                    { 15, "Shelter For Adults", "Shelter For Adults", 16, null, null },
                    { 16, "Social Service Organisation", "Social Service Organisation", 17, null, null },
                    { 17, "HIV", "HIV", 20, null, null },
                    { 18, "Social Service Organisation", "Social Service Organisation", 20, null, null },
                    { 19, "Childrens Homes", "Childrens Homes", 21, null, null }
                });

            migrationBuilder.InsertData(
                schema: "dropdown",
                table: "SubProgrammeTypes",
                columns: new[] { "Id", "Description", "Name", "SubProgrammeId", "UpdatedDateTime", "UpdatedUserId" },
                values: new object[,]
                {
                    { 20, "Drop In Centre", "Drop In Centre", 21, null, null },
                    { 21, "Organisation", "Organisation", 21, null, null },
                    { 22, "Shelter for Children", "Shelter for Children", 21, null, null },
                    { 23, "Organisations", "Organisations", 22, null, null },
                    { 24, "Projects", "Projects", 24, null, null },
                    { 25, "Social Service Organisation", "Social Service Organisation", 24, null, null },
                    { 26, "After School Centres", "After School Centres", 25, null, null },
                    { 27, "Creches", "Creches", 26, null, null },
                    { 28, "Social Service Organisation", "Social Service Organisation", 28, null, null },
                    { 29, "Social Service Organisation", "Social Service Organisation", 29, null, null },
                    { 30, "EPWP", "EPWP", 30, null, null },
                    { 31, "Social Service Organisation", "Social Service Organisation", 31, null, null },
                    { 32, "Social Service Organisation", "Social Service Organisation", 36, null, null },
                    { 33, "Assisted Living", "Assisted Living", 38, null, null },
                    { 34, "Independant Living", "Independant Living", 38, null, null },
                    { 35, "Residential Facilities", "Residential Facilities", 38, null, null },
                    { 36, "Social Service Organisation", "Social Service Organisation", 40, null, null },
                    { 37, "Service Centre", "Service Centre", 41, null, null },
                    { 38, "Home Based Care Services", "Home Based Care Services", 43, null, null },
                    { 39, "Service Centre", "Service Centre", 43, null, null },
                    { 40, "Residential Facilities", "Residential Facilities", 44, null, null },
                    { 41, "Protective Workshop", "Protective Workshop", 46, null, null },
                    { 42, "Day Care Centre", "Day Care Centre", 47, null, null },
                    { 43, "Social Service Organisation", "Social Service Organisation", 47, null, null },
                    { 44, "Special Day Care Centre", "Special Day Care Centre", 47, null, null },
                    { 45, "Special Day Care Centres", "Special Day Care Centres", 48, null, null },
                    { 46, "Day Care Centre", "Day Care Centre", 49, null, null },
                    { 47, "Residential Facilities", "Residential Facilities", 50, null, null },
                    { 48, "Projects", "Projects", 55, null, null },
                    { 49, "Aftercare", "Aftercare", 56, null, null },
                    { 50, "Awareness & Prevention", "Awareness & Prevention", 56, null, null },
                    { 51, "Community based treatment", "Community based treatment", 56, null, null },
                    { 52, "Early Intervention", "Early Intervention", 56, null, null },
                    { 53, "Social Service Organisation", "Social Service Organisation", 56, null, null },
                    { 54, "Youth Programmes", "Youth Programmes", 56, null, null },
                    { 55, "Community based treatment", "Community based treatment", 57, null, null },
                    { 56, "In patient", "In patient", 57, null, null },
                    { 57, "Out Patient", "Out Patient", 57, null, null },
                    { 58, "Earmarked Funding", "Earmarked Funding", 58, null, null },
                    { 59, "Equitable Share", "Equitable Share", 58, null, null },
                    { 60, "Social Service Organisation", "Social Service Organisation", 58, null, null },
                    { 61, "SRD", "SRD", 58, null, null }
                });

            migrationBuilder.InsertData(
                schema: "dropdown",
                table: "SubProgrammeTypes",
                columns: new[] { "Id", "Description", "Name", "SubProgrammeId", "UpdatedDateTime", "UpdatedUserId" },
                values: new object[,]
                {
                    { 62, "Targetted Feeding", "Targetted Feeding", 58, null, null },
                    { 63, "Programme focus", "Programme focus", 59, null, null },
                    { 64, "Shelter for Women and Children", "Shelter for Women and Children", 60, null, null },
                    { 65, "Victims of Crime/Violence/Fam members/significant", "Victims of Crime/Violence/Fam members/significant", 60, null, null },
                    { 66, "Service Provider", "Service Provider", 61, null, null },
                    { 67, "Social Service Organisation", "Social Service Organisation", 61, null, null },
                    { 68, "Projects", "Projects", 62, null, null },
                    { 69, "Social Service Organisation", "Social Service Organisation", 63, null, null },
                    { 70, "Youth Cafe", "Youth Cafe", 63, null, null },
                    { 71, "Childrens Homes", "Childrens Homes", 65, null, null }
                });

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "All Sub-Programmes");

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammes",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "Chronic Diseases");

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammes",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: "NCDs");

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammes",
                keyColumn: "Id",
                keyValue: 4,
                column: "Description",
                value: "HIV/AIDS");

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammes",
                keyColumn: "Id",
                keyValue: 5,
                column: "Description",
                value: "TB");

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammes",
                keyColumn: "Id",
                keyValue: 6,
                column: "Description",
                value: "STI");

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammes",
                keyColumn: "Id",
                keyValue: 7,
                column: "Description",
                value: "Maternal Health");

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammes",
                keyColumn: "Id",
                keyValue: 8,
                column: "Description",
                value: "Women's Health");

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammes",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Child and Adolescent Health", "Child and Adolescent Health" });

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammes",
                keyColumn: "Id",
                keyValue: 10,
                column: "Description",
                value: "Theatre");

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammes",
                keyColumn: "Id",
                keyValue: 11,
                column: "Description",
                value: "Surgery");

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammes",
                keyColumn: "Id",
                keyValue: 12,
                column: "Description",
                value: "Anaethetics");

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammes",
                keyColumn: "Id",
                keyValue: 13,
                column: "Description",
                value: "Mental Health");

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammes",
                keyColumn: "Id",
                keyValue: 14,
                column: "Description",
                value: "Emerency Centre Pressures");

            migrationBuilder.InsertData(
                schema: "dropdown",
                table: "SubProgrammes",
                columns: new[] { "Id", "Description", "Name", "ProgrammeId", "UpdatedDateTime", "UpdatedUserId" },
                values: new object[,]
                {
                    { 15, "Projects", "Projects", 8, null, null },
                    { 16, "Shelter For Adults", "Shelter For Adults", 8, null, null },
                    { 17, "Social Service Organisation", "Social Service Organisation", 8, null, null },
                    { 18, "Drop In Centres", "Drop In Centres", 9, null, null },
                    { 19, "Projects", "Projects", 9, null, null },
                    { 20, "Social Service Organisation", "Social Service Organisation", 9, null, null },
                    { 21, "Shelter for Children", "Shelter for Children", 9, null, null },
                    { 22, "HIV - Aids", "HIV - Aids", 9, null, null },
                    { 23, "Projects", "Projects", 10, null, null },
                    { 24, "Social Service Organisation", "Social Service Organisation", 10, null, null },
                    { 25, "After School Centres", "After School Centres", 11, null, null },
                    { 26, "Creches", "Creches", 11, null, null },
                    { 27, "Projects", "Projects", 11, null, null },
                    { 28, "Social Service Organisation", "Social Service Organisation", 11, null, null },
                    { 29, "Projects", "Projects", 12, null, null },
                    { 30, "EPWP - Conditional Grant", "EPWP - Conditional Grant", 12, null, null },
                    { 31, "Social Service Organisation", "Social Service Organisation", 12, null, null },
                    { 32, "Child and Youth Care Centres", "Child and Youth Care Centres", 13, null, null }
                });

            migrationBuilder.InsertData(
                schema: "dropdown",
                table: "SubProgrammes",
                columns: new[] { "Id", "Description", "Name", "ProgrammeId", "UpdatedDateTime", "UpdatedUserId" },
                values: new object[,]
                {
                    { 33, "Projects", "Projects", 13, null, null },
                    { 34, "Shelter for Childen", "Shelter for Childen", 13, null, null },
                    { 35, "Projects", "Projects", 14, null, null },
                    { 36, "Social Service Organisation", "Social Service Organisation", 14, null, null },
                    { 37, "Assisted Living", "Assisted Living", 15, null, null },
                    { 38, "Homes for the Aged", "Homes for the Aged", 15, null, null },
                    { 39, "Projects", "Projects", 15, null, null },
                    { 40, "Social Service Organisation", "Social Service Organisation", 15, null, null },
                    { 41, "Service Centres", "Service Centres", 15, null, null },
                    { 42, "Independent Living", "Independent Living", 15, null, null },
                    { 43, "Community Based Care and Support Services", "Community Based Care and Support Services", 15, null, null },
                    { 44, "Homes for the Disabled", "Homes for the Disabled", 16, null, null },
                    { 45, "Projects", "Projects", 16, null, null },
                    { 46, "Protective Workshops", "Protective Workshops", 16, null, null },
                    { 47, "Social Service Organisation", "Social Service Organisation", 16, null, null },
                    { 48, "Special Day Care Centres", "Special Day Care Centres", 16, null, null },
                    { 49, "Day Care Centre", "Day Care Centre", 16, null, null },
                    { 50, "Homes for the Aged", "Homes for the Aged", 16, null, null },
                    { 51, "Aftercare", "Aftercare", 17, null, null },
                    { 52, "Awareness", "Awareness", 17, null, null },
                    { 53, "Community Based Treatment", "Community Based Treatment", 17, null, null },
                    { 54, "Early Intervention", "Early Intervention", 17, null, null },
                    { 55, "Projects", "Projects", 17, null, null },
                    { 56, "Social Service Organisation", "Social Service Organisation", 17, null, null },
                    { 57, "Treatment Centres", "Treatment Centres", 17, null, null },
                    { 58, "Social Service Organisation", "Social Service Organisation", 18, null, null },
                    { 59, "Projects", "Projects", 19, null, null },
                    { 60, "Shelter For Victims of Violence", "Shelter For Victims of Violence", 19, null, null },
                    { 61, "Social Service Organisation", "Social Service Organisation", 19, null, null },
                    { 62, "Projects", "Projects", 20, null, null },
                    { 63, "Social Service Organisation", "Social Service Organisation", 20, null, null },
                    { 64, "Youth Cafe", "Youth Cafe", 20, null, null },
                    { 65, "Childrens Homes", "Childrens Homes", 21, null, null }
                });

            migrationBuilder.InsertData(
                schema: "core",
                table: "Utilities",
                columns: new[] { "Id", "AngularRedirectUrl", "Description", "Name", "SystemAdminUtility", "UpdatedDateTime", "UpdatedUserId" },
                values: new object[] { 25, "utilities/sub-programme-type", "Add and/or Update sub-programme types", "Sub-Programme Type", false, null, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubProgrammeTypes",
                schema: "dropdown");

            migrationBuilder.DeleteData(
                schema: "core",
                table: "EntityTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "Programmes",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "Programmes",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "Programmes",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "Programmes",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "Programmes",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "Programmes",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "Programmes",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "Programmes",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "Programmes",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "Programmes",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "Programmes",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "Programmes",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "Programmes",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "Programmes",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "Programmes",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "SubProgrammes",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "SubProgrammes",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "SubProgrammes",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "SubProgrammes",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "SubProgrammes",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "SubProgrammes",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "SubProgrammes",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "SubProgrammes",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "SubProgrammes",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "SubProgrammes",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "SubProgrammes",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "SubProgrammes",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "SubProgrammes",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "SubProgrammes",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "SubProgrammes",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "SubProgrammes",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "SubProgrammes",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "SubProgrammes",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "SubProgrammes",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "SubProgrammes",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "SubProgrammes",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "SubProgrammes",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "SubProgrammes",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "SubProgrammes",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "SubProgrammes",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "SubProgrammes",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "SubProgrammes",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "SubProgrammes",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "SubProgrammes",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "SubProgrammes",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "SubProgrammes",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "SubProgrammes",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "SubProgrammes",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "SubProgrammes",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "SubProgrammes",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "SubProgrammes",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "SubProgrammes",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "SubProgrammes",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "SubProgrammes",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "SubProgrammes",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "SubProgrammes",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "SubProgrammes",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "SubProgrammes",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "SubProgrammes",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "SubProgrammes",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "SubProgrammes",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "SubProgrammes",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "SubProgrammes",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "SubProgrammes",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "SubProgrammes",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "SubProgrammes",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Utilities",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DropColumn(
                name: "Description",
                schema: "dropdown",
                table: "SubProgrammes");

            migrationBuilder.DropColumn(
                name: "Description",
                schema: "dropdown",
                table: "Programmes");

            migrationBuilder.AddColumn<string>(
                name: "SystemName",
                schema: "dropdown",
                table: "SubProgrammes",
                type: "nvarchar(255)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SystemName",
                schema: "dropdown",
                table: "Programmes",
                type: "nvarchar(255)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "Programmes",
                keyColumn: "Id",
                keyValue: 1,
                column: "SystemName",
                value: "All");

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "Programmes",
                keyColumn: "Id",
                keyValue: 2,
                column: "SystemName",
                value: "CNCD");

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "Programmes",
                keyColumn: "Id",
                keyValue: 3,
                column: "SystemName",
                value: "HTS");

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "Programmes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Name", "SystemName" },
                values: new object[] { "Maternal,Women and Child Health", "MWCH" });

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "Programmes",
                keyColumn: "Id",
                keyValue: 5,
                column: "SystemName",
                value: "TSA");

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "Programmes",
                keyColumn: "Id",
                keyValue: 6,
                column: "SystemName",
                value: "MH");

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "Programmes",
                keyColumn: "Id",
                keyValue: 7,
                column: "SystemName",
                value: "ECP");

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammes",
                keyColumn: "Id",
                keyValue: 1,
                column: "SystemName",
                value: "ALL");

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammes",
                keyColumn: "Id",
                keyValue: 2,
                column: "SystemName",
                value: "CD");

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammes",
                keyColumn: "Id",
                keyValue: 3,
                column: "SystemName",
                value: "NCDs");

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammes",
                keyColumn: "Id",
                keyValue: 4,
                column: "SystemName",
                value: "HIV");

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammes",
                keyColumn: "Id",
                keyValue: 5,
                column: "SystemName",
                value: "TB");

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammes",
                keyColumn: "Id",
                keyValue: 6,
                column: "SystemName",
                value: "STI");

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammes",
                keyColumn: "Id",
                keyValue: 7,
                column: "SystemName",
                value: "MH");

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammes",
                keyColumn: "Id",
                keyValue: 8,
                column: "SystemName",
                value: "WH");

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammes",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Name", "SystemName" },
                values: new object[] { "Child and Adolescent Helath", "CAH" });

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammes",
                keyColumn: "Id",
                keyValue: 10,
                column: "SystemName",
                value: "Theatre");

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammes",
                keyColumn: "Id",
                keyValue: 11,
                column: "SystemName",
                value: "Surgery");

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammes",
                keyColumn: "Id",
                keyValue: 12,
                column: "SystemName",
                value: "Anaethetics");

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammes",
                keyColumn: "Id",
                keyValue: 13,
                column: "SystemName",
                value: "MH");

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "SubProgrammes",
                keyColumn: "Id",
                keyValue: 14,
                column: "SystemName",
                value: "ECP");
        }
    }
}
