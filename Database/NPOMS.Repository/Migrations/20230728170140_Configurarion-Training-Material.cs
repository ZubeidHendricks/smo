using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NPOMS.Repository.Migrations
{
    public partial class ConfigurarionTrainingMaterial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_WorkplanActualAudits_Statuses_StatusId",
            //    schema: "indicator",
            //    table: "WorkplanActualAudits");

            //migrationBuilder.DropIndex(
            //    name: "IX_WorkplanActualAudits_StatusId",
            //    schema: "indicator",
            //    table: "WorkplanActualAudits");

            migrationBuilder.EnsureSchema(
                name: "eval");

            migrationBuilder.CreateTable(
                name: "CapturedResponses",
                schema: "eval",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FundingApplicationId = table.Column<int>(type: "int", nullable: false),
                    QuestionCategoryId = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedUserId = table.Column<int>(type: "int", nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CapturedResponses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CapturedResponses_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalSchema: "core",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FundingTemplateTypes",
                schema: "dropdown",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    SystemName = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedUserId = table.Column<int>(type: "int", nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FundingTemplateTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QuestionCategories",
                schema: "eval",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FundingTemplateTypeId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedUserId = table.Column<int>(type: "int", nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ResponseOptions",
                schema: "eval",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResponseTypeId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    SystemName = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedUserId = table.Column<int>(type: "int", nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResponseOptions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ResponseTypes",
                schema: "eval",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedUserId = table.Column<int>(type: "int", nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResponseTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkflowAssessments",
                schema: "eval",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionCategoryId = table.Column<int>(type: "int", nullable: false),
                    NumberOfAssessments = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedUserId = table.Column<int>(type: "int", nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkflowAssessments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QuestionSections",
                schema: "eval",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionCategoryId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    SortOrder = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedUserId = table.Column<int>(type: "int", nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionSections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestionSections_QuestionCategories_QuestionCategoryId",
                        column: x => x.QuestionCategoryId,
                        principalSchema: "eval",
                        principalTable: "QuestionCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResponseHistory",
                schema: "eval",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FundingApplicationId = table.Column<int>(type: "int", nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    ResponseOptionId = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResponseHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResponseHistory_ResponseOptions_ResponseOptionId",
                        column: x => x.ResponseOptionId,
                        principalSchema: "eval",
                        principalTable: "ResponseOptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResponseHistory_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalSchema: "core",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                schema: "eval",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionSectionId = table.Column<int>(type: "int", nullable: false),
                    ResponseTypeId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    SortOrder = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedUserId = table.Column<int>(type: "int", nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questions_QuestionSections_QuestionSectionId",
                        column: x => x.QuestionSectionId,
                        principalSchema: "eval",
                        principalTable: "QuestionSections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Questions_ResponseTypes_ResponseTypeId",
                        column: x => x.ResponseTypeId,
                        principalSchema: "eval",
                        principalTable: "ResponseTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuestionProperties",
                schema: "eval",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    HasComment = table.Column<bool>(type: "bit", nullable: false),
                    CommentRequired = table.Column<bool>(type: "bit", nullable: false),
                    HasDocument = table.Column<bool>(type: "bit", nullable: false),
                    DocumentRequired = table.Column<bool>(type: "bit", nullable: false),
                    Weighting = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionProperties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestionProperties_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalSchema: "eval",
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Responses",
                schema: "eval",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FundingApplicationId = table.Column<int>(type: "int", nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    ResponseOptionId = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedUserId = table.Column<int>(type: "int", nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Responses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Responses_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalSchema: "eval",
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Responses_ResponseOptions_ResponseOptionId",
                        column: x => x.ResponseOptionId,
                        principalSchema: "eval",
                        principalTable: "ResponseOptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "core",
                table: "Permissions",
                columns: new[] { "Id", "CategoryName", "Name", "SystemName", "UpdatedDateTime", "UpdatedUserId" },
                values: new object[,]
                {
                    { 93, "Funding Application", "Pre-evaluate Application", "FA.PreEvaluate", null, null },
                    { 94, "Funding Application", "Evaluate Application", "FA.Evaluate", null, null },
                    { 95, "Funding Application", "Adjudicate Application", "FA.Adjudicate", null, null }
                });

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
                columns: new[] { "Id", "Description", "IsActive", "Link", "Name", "UpdatedDateTime", "UpdatedUserId" },
                values: new object[,]
                {
                    { 3, "DSD Programme Specifications", true, "https://www.westerncape.gov.za/site-page/call-proposals-2024-25-programme-specifications", "Programme Specifications", null, null },
                    { 4, "UFC 2024-25 NPO Circular", true, "https://www.westerncape.gov.za/assets/departments/social-development/CFP/ufc_2024-25_npo_circular.pdf", "NPO Circular", null, null },
                    { 5, "UFC 2024-25 Basic Eligibility Criteria and Conditions ", true, "https://www.westerncape.gov.za/assets/departments/social-development/CFP/ufc_2024-25_basic_eligibility_criteria_and_conditions.pdf", "Basic Eligibility Criteria and Conditions ", null, null },
                    { 6, "DSD NPO Application Form Guide", true, "https://www.westerncape.gov.za/assets/departments/social-development/CFP/dsd_npo_application_form_guide.pdf", "NPO Application Form Guide ", null, null },
                    { 7, "DSD Call for Proposals -  Online Application User Guide", true, "https://www.westerncape.gov.za/assets/departments/social-development/CFP/call_for_proposals_-_online_application_user_guide.pdf", "Online Application User Guide ", null, null },
                    { 8, "DSD NPO Application Form with Annexures (collated)", true, "https://www.westerncape.gov.za/assets/departments/social-development/CFP/dsd_npo_application_form_with_annexures.pdf", "Application Form with Annexures (collated)", null, null },
                    { 9, "DSD NPO Application Form - Declaration of interest", true, "https://www.westerncape.gov.za/assets/departments/social-development/CFP/npo_application_form_-_declaration_of_interest.pdf", "Application Form - Declaration of interest", null, null },
                    { 10, "DSD NPO Application Form - BAS entity bank details form", true, "https://www.westerncape.gov.za/assets/departments/social-development/CFP/npo_application_form_-_dsd_bas_entity_bank_details_form.pdf", "Application Form - BAS entity bank details form", null, null },
                    { 11, "DSD NPO Application Form - Schedule A Enrolment form (After School Care only)", true, "https://www.westerncape.gov.za/assets/departments/social-development/CFP/npo_application_form_-_schedule_a_enrolment_form_-_afterschool_care_only.pdf", "Application Form - Schedule A Enrolment form (After School Care only)", null, null },
                    { 12, "DSD NPO Application Form - Written Assurance", true, "https://www.westerncape.gov.za/assets/departments/social-development/CFP/npo_application_form_-_written_assurance.pdf", "Application Form - Written Assurance", null, null },
                    { 13, "DSD Call For Proposal Frequently Asked Questions", true, "https://www.westerncape.gov.za/assets/departments/social-development/CFP/frequently_asked_questions_-_2023_call_for_proposals.pdf", "Frequently Asked Questions", null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CapturedResponses_CreatedUserId",
                schema: "eval",
                table: "CapturedResponses",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionProperties_QuestionId",
                schema: "eval",
                table: "QuestionProperties",
                column: "QuestionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Questions_QuestionSectionId",
                schema: "eval",
                table: "Questions",
                column: "QuestionSectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_ResponseTypeId",
                schema: "eval",
                table: "Questions",
                column: "ResponseTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionSections_QuestionCategoryId",
                schema: "eval",
                table: "QuestionSections",
                column: "QuestionCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ResponseHistory_CreatedUserId",
                schema: "eval",
                table: "ResponseHistory",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ResponseHistory_ResponseOptionId",
                schema: "eval",
                table: "ResponseHistory",
                column: "ResponseOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Responses_QuestionId",
                schema: "eval",
                table: "Responses",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Responses_ResponseOptionId",
                schema: "eval",
                table: "Responses",
                column: "ResponseOptionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CapturedResponses",
                schema: "eval");

            migrationBuilder.DropTable(
                name: "FundingTemplateTypes",
                schema: "dropdown");

            migrationBuilder.DropTable(
                name: "QuestionProperties",
                schema: "eval");

            migrationBuilder.DropTable(
                name: "ResponseHistory",
                schema: "eval");

            migrationBuilder.DropTable(
                name: "Responses",
                schema: "eval");

            migrationBuilder.DropTable(
                name: "WorkflowAssessments",
                schema: "eval");

            migrationBuilder.DropTable(
                name: "Questions",
                schema: "eval");

            migrationBuilder.DropTable(
                name: "ResponseOptions",
                schema: "eval");

            migrationBuilder.DropTable(
                name: "QuestionSections",
                schema: "eval");

            migrationBuilder.DropTable(
                name: "ResponseTypes",
                schema: "eval");

            migrationBuilder.DropTable(
                name: "QuestionCategories",
                schema: "eval");

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                schema: "core",
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "TrainingMaterials",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "TrainingMaterials",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "TrainingMaterials",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "TrainingMaterials",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "TrainingMaterials",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "TrainingMaterials",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "TrainingMaterials",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "TrainingMaterials",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "TrainingMaterials",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "TrainingMaterials",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "TrainingMaterials",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "TrainingMaterials",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 24, 13, 56, 49, 457, DateTimeKind.Local).AddTicks(2266));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 24, 13, 56, 49, 457, DateTimeKind.Local).AddTicks(2268));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 24, 13, 56, 49, 457, DateTimeKind.Local).AddTicks(2269));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 24, 13, 56, 49, 457, DateTimeKind.Local).AddTicks(2271));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 24, 13, 56, 49, 457, DateTimeKind.Local).AddTicks(2272));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 24, 13, 56, 49, 457, DateTimeKind.Local).AddTicks(2273));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 24, 13, 56, 49, 457, DateTimeKind.Local).AddTicks(2274));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 24, 13, 56, 49, 457, DateTimeKind.Local).AddTicks(2275));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 24, 13, 56, 49, 457, DateTimeKind.Local).AddTicks(2276));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 24, 13, 56, 49, 457, DateTimeKind.Local).AddTicks(2277));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 24, 13, 56, 49, 457, DateTimeKind.Local).AddTicks(2278));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 24, 13, 56, 49, 457, DateTimeKind.Local).AddTicks(2279));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 24, 13, 56, 49, 457, DateTimeKind.Local).AddTicks(2280));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 24, 13, 56, 49, 457, DateTimeKind.Local).AddTicks(2282));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 24, 13, 56, 49, 457, DateTimeKind.Local).AddTicks(2283));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 24, 13, 56, 49, 457, DateTimeKind.Local).AddTicks(2284));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 24, 13, 56, 49, 457, DateTimeKind.Local).AddTicks(2285));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 24, 13, 56, 49, 457, DateTimeKind.Local).AddTicks(2286));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 24, 13, 56, 49, 457, DateTimeKind.Local).AddTicks(2287));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 24, 13, 56, 49, 457, DateTimeKind.Local).AddTicks(2288));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 24, 13, 56, 49, 457, DateTimeKind.Local).AddTicks(2293));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 24, 13, 56, 49, 457, DateTimeKind.Local).AddTicks(2295));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 24, 13, 56, 49, 457, DateTimeKind.Local).AddTicks(2300));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 24, 13, 56, 49, 457, DateTimeKind.Local).AddTicks(2311));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 24, 13, 56, 49, 457, DateTimeKind.Local).AddTicks(2312));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 24, 13, 56, 49, 457, DateTimeKind.Local).AddTicks(2313));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 24, 13, 56, 49, 457, DateTimeKind.Local).AddTicks(2314));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 24, 13, 56, 49, 457, DateTimeKind.Local).AddTicks(2315));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 24, 13, 56, 49, 457, DateTimeKind.Local).AddTicks(2316));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 24, 13, 56, 49, 457, DateTimeKind.Local).AddTicks(2317));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 24, 13, 56, 49, 457, DateTimeKind.Local).AddTicks(2318));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 24, 13, 56, 49, 457, DateTimeKind.Local).AddTicks(2319));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 24, 13, 56, 49, 457, DateTimeKind.Local).AddTicks(2182));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 24, 13, 56, 49, 457, DateTimeKind.Local).AddTicks(2197));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 24, 13, 56, 49, 457, DateTimeKind.Local).AddTicks(2199));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 24, 13, 56, 49, 457, DateTimeKind.Local).AddTicks(2200));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 24, 13, 56, 49, 457, DateTimeKind.Local).AddTicks(2202));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 24, 13, 56, 49, 457, DateTimeKind.Local).AddTicks(2203));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 24, 13, 56, 49, 457, DateTimeKind.Local).AddTicks(2205));

            migrationBuilder.CreateIndex(
                name: "IX_WorkplanActualAudits_StatusId",
                schema: "indicator",
                table: "WorkplanActualAudits",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkplanActualAudits_Statuses_StatusId",
                schema: "indicator",
                table: "WorkplanActualAudits",
                column: "StatusId",
                principalSchema: "dbo",
                principalTable: "Statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
