using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NPOMS.Repository.Migrations
{
    public partial class createnewevaluationtables : Migration
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

            //migrationBuilder.CreateTable(
            //    name: "CapturedResponses",
            //    schema: "eval",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        FundingApplicationId = table.Column<int>(type: "int", nullable: false),
            //        QuestionCategoryId = table.Column<int>(type: "int", nullable: false),
            //        StatusId = table.Column<int>(type: "int", nullable: false),
            //        Comments = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
            //        IsActive = table.Column<bool>(type: "bit", nullable: false),
            //        CreatedUserId = table.Column<int>(type: "int", nullable: false),
            //        CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        UpdatedUserId = table.Column<int>(type: "int", nullable: true),
            //        UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_CapturedResponses", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_CapturedResponses_Users_CreatedUserId",
            //            column: x => x.CreatedUserId,
            //            principalSchema: "core",
            //            principalTable: "Users",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "QuestionCategories",
            //    schema: "eval",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        FundingTemplateTypeId = table.Column<int>(type: "int", nullable: false),
            //        Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
            //        IsActive = table.Column<bool>(type: "bit", nullable: false),
            //        CreatedUserId = table.Column<int>(type: "int", nullable: false),
            //        CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        UpdatedUserId = table.Column<int>(type: "int", nullable: true),
            //        UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_QuestionCategories", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "ResponseOptions",
            //    schema: "eval",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        ResponseTypeId = table.Column<int>(type: "int", nullable: false),
            //        Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
            //        SystemName = table.Column<string>(type: "nvarchar(255)", nullable: true),
            //        IsActive = table.Column<bool>(type: "bit", nullable: false),
            //        CreatedUserId = table.Column<int>(type: "int", nullable: false),
            //        CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        UpdatedUserId = table.Column<int>(type: "int", nullable: true),
            //        UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_ResponseOptions", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "ResponseTypes",
            //    schema: "eval",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
            //        Description = table.Column<string>(type: "nvarchar(1000)", nullable: true),
            //        IsActive = table.Column<bool>(type: "bit", nullable: false),
            //        CreatedUserId = table.Column<int>(type: "int", nullable: false),
            //        CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        UpdatedUserId = table.Column<int>(type: "int", nullable: true),
            //        UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_ResponseTypes", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "WorkflowAssessments",
            //    schema: "eval",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        QuestionCategoryId = table.Column<int>(type: "int", nullable: false),
            //        NumberOfAssessments = table.Column<int>(type: "int", nullable: false),
            //        IsActive = table.Column<bool>(type: "bit", nullable: false),
            //        CreatedUserId = table.Column<int>(type: "int", nullable: false),
            //        CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        UpdatedUserId = table.Column<int>(type: "int", nullable: true),
            //        UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_WorkflowAssessments", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "QuestionSections",
            //    schema: "eval",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        QuestionCategoryId = table.Column<int>(type: "int", nullable: false),
            //        Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
            //        SortOrder = table.Column<int>(type: "int", nullable: false),
            //        IsActive = table.Column<bool>(type: "bit", nullable: false),
            //        CreatedUserId = table.Column<int>(type: "int", nullable: false),
            //        CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        UpdatedUserId = table.Column<int>(type: "int", nullable: true),
            //        UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_QuestionSections", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_QuestionSections_QuestionCategories_QuestionCategoryId",
            //            column: x => x.QuestionCategoryId,
            //            principalSchema: "eval",
            //            principalTable: "QuestionCategories",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "ResponseHistory",
            //    schema: "eval",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        FundingApplicationId = table.Column<int>(type: "int", nullable: false),
            //        QuestionId = table.Column<int>(type: "int", nullable: false),
            //        ResponseOptionId = table.Column<int>(type: "int", nullable: false),
            //        Comment = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
            //        CreatedUserId = table.Column<int>(type: "int", nullable: false),
            //        CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_ResponseHistory", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_ResponseHistory_ResponseOptions_ResponseOptionId",
            //            column: x => x.ResponseOptionId,
            //            principalSchema: "eval",
            //            principalTable: "ResponseOptions",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_ResponseHistory_Users_CreatedUserId",
            //            column: x => x.CreatedUserId,
            //            principalSchema: "core",
            //            principalTable: "Users",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Questions",
            //    schema: "eval",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        QuestionSectionId = table.Column<int>(type: "int", nullable: false),
            //        ResponseTypeId = table.Column<int>(type: "int", nullable: false),
            //        Name = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
            //        SortOrder = table.Column<int>(type: "int", nullable: false),
            //        IsActive = table.Column<bool>(type: "bit", nullable: false),
            //        CreatedUserId = table.Column<int>(type: "int", nullable: false),
            //        CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        UpdatedUserId = table.Column<int>(type: "int", nullable: true),
            //        UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Questions", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_Questions_QuestionSections_QuestionSectionId",
            //            column: x => x.QuestionSectionId,
            //            principalSchema: "eval",
            //            principalTable: "QuestionSections",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_Questions_ResponseTypes_ResponseTypeId",
            //            column: x => x.ResponseTypeId,
            //            principalSchema: "eval",
            //            principalTable: "ResponseTypes",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "QuestionProperties",
            //    schema: "eval",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        QuestionId = table.Column<int>(type: "int", nullable: false),
            //        HasComment = table.Column<bool>(type: "bit", nullable: false),
            //        CommentRequired = table.Column<bool>(type: "bit", nullable: false),
            //        HasDocument = table.Column<bool>(type: "bit", nullable: false),
            //        DocumentRequired = table.Column<bool>(type: "bit", nullable: false),
            //        Weighting = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_QuestionProperties", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_QuestionProperties_Questions_QuestionId",
            //            column: x => x.QuestionId,
            //            principalSchema: "eval",
            //            principalTable: "Questions",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Responses",
            //    schema: "eval",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        FundingApplicationId = table.Column<int>(type: "int", nullable: false),
            //        QuestionId = table.Column<int>(type: "int", nullable: false),
            //        ResponseOptionId = table.Column<int>(type: "int", nullable: false),
            //        Comment = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
            //        CreatedUserId = table.Column<int>(type: "int", nullable: false),
            //        CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        UpdatedUserId = table.Column<int>(type: "int", nullable: true),
            //        UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Responses", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_Responses_Questions_QuestionId",
            //            column: x => x.QuestionId,
            //            principalSchema: "eval",
            //            principalTable: "Questions",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_Responses_ResponseOptions_ResponseOptionId",
            //            column: x => x.ResponseOptionId,
            //            principalSchema: "eval",
            //            principalTable: "ResponseOptions",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 17, 17, 48, 37, 708, DateTimeKind.Local).AddTicks(366));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 17, 17, 48, 37, 708, DateTimeKind.Local).AddTicks(368));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 17, 17, 48, 37, 708, DateTimeKind.Local).AddTicks(370));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 17, 17, 48, 37, 708, DateTimeKind.Local).AddTicks(371));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 17, 17, 48, 37, 708, DateTimeKind.Local).AddTicks(372));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 17, 17, 48, 37, 708, DateTimeKind.Local).AddTicks(373));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 17, 17, 48, 37, 708, DateTimeKind.Local).AddTicks(375));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 17, 17, 48, 37, 708, DateTimeKind.Local).AddTicks(376));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 17, 17, 48, 37, 708, DateTimeKind.Local).AddTicks(377));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 17, 17, 48, 37, 708, DateTimeKind.Local).AddTicks(378));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 17, 17, 48, 37, 708, DateTimeKind.Local).AddTicks(379));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 17, 17, 48, 37, 708, DateTimeKind.Local).AddTicks(380));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 17, 17, 48, 37, 708, DateTimeKind.Local).AddTicks(381));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 17, 17, 48, 37, 708, DateTimeKind.Local).AddTicks(438));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 17, 17, 48, 37, 708, DateTimeKind.Local).AddTicks(441));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 17, 17, 48, 37, 708, DateTimeKind.Local).AddTicks(442));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 17, 17, 48, 37, 708, DateTimeKind.Local).AddTicks(452));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 17, 17, 48, 37, 708, DateTimeKind.Local).AddTicks(454));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 17, 17, 48, 37, 708, DateTimeKind.Local).AddTicks(455));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 17, 17, 48, 37, 708, DateTimeKind.Local).AddTicks(456));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 17, 17, 48, 37, 708, DateTimeKind.Local).AddTicks(457));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 17, 17, 48, 37, 708, DateTimeKind.Local).AddTicks(469));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 17, 17, 48, 37, 708, DateTimeKind.Local).AddTicks(479));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 17, 17, 48, 37, 708, DateTimeKind.Local).AddTicks(480));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 17, 17, 48, 37, 708, DateTimeKind.Local).AddTicks(481));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 17, 17, 48, 37, 708, DateTimeKind.Local).AddTicks(482));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 17, 17, 48, 37, 708, DateTimeKind.Local).AddTicks(484));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 17, 17, 48, 37, 708, DateTimeKind.Local).AddTicks(485));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 17, 17, 48, 37, 708, DateTimeKind.Local).AddTicks(486));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 17, 17, 48, 37, 708, DateTimeKind.Local).AddTicks(487));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 17, 17, 48, 37, 708, DateTimeKind.Local).AddTicks(488));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 17, 17, 48, 37, 708, DateTimeKind.Local).AddTicks(489));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 17, 17, 48, 37, 708, DateTimeKind.Local).AddTicks(241));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 17, 17, 48, 37, 708, DateTimeKind.Local).AddTicks(260));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 17, 17, 48, 37, 708, DateTimeKind.Local).AddTicks(262));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 17, 17, 48, 37, 708, DateTimeKind.Local).AddTicks(264));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 17, 17, 48, 37, 708, DateTimeKind.Local).AddTicks(266));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 17, 17, 48, 37, 708, DateTimeKind.Local).AddTicks(267));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 17, 17, 48, 37, 708, DateTimeKind.Local).AddTicks(269));

            //migrationBuilder.CreateIndex(
            //    name: "IX_CapturedResponses_CreatedUserId",
            //    schema: "eval",
            //    table: "CapturedResponses",
            //    column: "CreatedUserId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_QuestionProperties_QuestionId",
            //    schema: "eval",
            //    table: "QuestionProperties",
            //    column: "QuestionId",
            //    unique: true);

            //migrationBuilder.CreateIndex(
            //    name: "IX_Questions_QuestionSectionId",
            //    schema: "eval",
            //    table: "Questions",
            //    column: "QuestionSectionId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Questions_ResponseTypeId",
            //    schema: "eval",
            //    table: "Questions",
            //    column: "ResponseTypeId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_QuestionSections_QuestionCategoryId",
            //    schema: "eval",
            //    table: "QuestionSections",
            //    column: "QuestionCategoryId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_ResponseHistory_CreatedUserId",
            //    schema: "eval",
            //    table: "ResponseHistory",
            //    column: "CreatedUserId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_ResponseHistory_ResponseOptionId",
            //    schema: "eval",
            //    table: "ResponseHistory",
            //    column: "ResponseOptionId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Responses_QuestionId",
            //    schema: "eval",
            //    table: "Responses",
            //    column: "QuestionId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Responses_ResponseOptionId",
            //    schema: "eval",
            //    table: "Responses",
            //    column: "ResponseOptionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CapturedResponses",
                schema: "eval");

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

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 10, 2, 26, 2, 141, DateTimeKind.Local).AddTicks(6531));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 10, 2, 26, 2, 141, DateTimeKind.Local).AddTicks(6534));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 10, 2, 26, 2, 141, DateTimeKind.Local).AddTicks(6535));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 10, 2, 26, 2, 141, DateTimeKind.Local).AddTicks(6536));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 10, 2, 26, 2, 141, DateTimeKind.Local).AddTicks(6538));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 10, 2, 26, 2, 141, DateTimeKind.Local).AddTicks(6539));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 10, 2, 26, 2, 141, DateTimeKind.Local).AddTicks(6540));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 10, 2, 26, 2, 141, DateTimeKind.Local).AddTicks(6542));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 10, 2, 26, 2, 141, DateTimeKind.Local).AddTicks(6543));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 10, 2, 26, 2, 141, DateTimeKind.Local).AddTicks(6544));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 10, 2, 26, 2, 141, DateTimeKind.Local).AddTicks(6546));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 10, 2, 26, 2, 141, DateTimeKind.Local).AddTicks(6547));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 10, 2, 26, 2, 141, DateTimeKind.Local).AddTicks(6548));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 10, 2, 26, 2, 141, DateTimeKind.Local).AddTicks(6549));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 10, 2, 26, 2, 141, DateTimeKind.Local).AddTicks(6551));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 10, 2, 26, 2, 141, DateTimeKind.Local).AddTicks(6552));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 10, 2, 26, 2, 141, DateTimeKind.Local).AddTicks(6553));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 10, 2, 26, 2, 141, DateTimeKind.Local).AddTicks(6554));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 10, 2, 26, 2, 141, DateTimeKind.Local).AddTicks(6556));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 10, 2, 26, 2, 141, DateTimeKind.Local).AddTicks(6557));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 10, 2, 26, 2, 141, DateTimeKind.Local).AddTicks(6558));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 10, 2, 26, 2, 141, DateTimeKind.Local).AddTicks(6575));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 10, 2, 26, 2, 141, DateTimeKind.Local).AddTicks(6587));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 10, 2, 26, 2, 141, DateTimeKind.Local).AddTicks(6588));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 10, 2, 26, 2, 141, DateTimeKind.Local).AddTicks(6589));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 10, 2, 26, 2, 141, DateTimeKind.Local).AddTicks(6591));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 10, 2, 26, 2, 141, DateTimeKind.Local).AddTicks(6592));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 10, 2, 26, 2, 141, DateTimeKind.Local).AddTicks(6593));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 10, 2, 26, 2, 141, DateTimeKind.Local).AddTicks(6594));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 10, 2, 26, 2, 141, DateTimeKind.Local).AddTicks(6625));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 10, 2, 26, 2, 141, DateTimeKind.Local).AddTicks(6627));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 10, 2, 26, 2, 141, DateTimeKind.Local).AddTicks(6628));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 10, 2, 26, 2, 141, DateTimeKind.Local).AddTicks(6396));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 10, 2, 26, 2, 141, DateTimeKind.Local).AddTicks(6416));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 10, 2, 26, 2, 141, DateTimeKind.Local).AddTicks(6419));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 10, 2, 26, 2, 141, DateTimeKind.Local).AddTicks(6421));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 10, 2, 26, 2, 141, DateTimeKind.Local).AddTicks(6423));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 10, 2, 26, 2, 141, DateTimeKind.Local).AddTicks(6424));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2023, 7, 10, 2, 26, 2, 141, DateTimeKind.Local).AddTicks(6426));

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
