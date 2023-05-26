using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NPOMS.Repository.Migrations
{
    public partial class FundingAppDetailAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FundingApplicationDetails_DistrictCouncils_DistrictCouncilId",
                schema: "fa",
                table: "FundingApplicationDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_FundingApplicationDetails_LocalMunicipalities_localMunicipalityId",
                schema: "fa",
                table: "FundingApplicationDetails");

            migrationBuilder.DropTable(
                name: "ProjectImplementationPlaces",
                schema: "mapping");

            migrationBuilder.DropTable(
                name: "ProjectImplementationSubPlaces",
                schema: "mapping");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectImplementation",
                schema: "fa",
                table: "ProjectImplementation");

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
                name: "AmountApplyingFor",
                schema: "fa",
                table: "FundingApplicationDetails");

            migrationBuilder.DropColumn(
                name: "ChangesRequired",
                schema: "fa",
                table: "FundingApplicationDetails");

            migrationBuilder.DropColumn(
                name: "CreatedDateTime",
                schema: "fa",
                table: "FundingApplicationDetails");

            migrationBuilder.DropColumn(
                name: "CreatedUserId",
                schema: "fa",
                table: "FundingApplicationDetails");

            migrationBuilder.DropColumn(
                name: "IsActive",
                schema: "fa",
                table: "FundingApplicationDetails");

            migrationBuilder.DropColumn(
                name: "IsNew",
                schema: "fa",
                table: "FundingApplicationDetails");

            migrationBuilder.DropColumn(
                name: "UpdatedDateTime",
                schema: "fa",
                table: "FundingApplicationDetails");

            migrationBuilder.DropColumn(
                name: "ApplicationId",
                schema: "fa",
                table: "ProjectImplementation");

            migrationBuilder.DropColumn(
                name: "CreatedDateTime",
                schema: "fa",
                table: "ProjectImplementation");

            migrationBuilder.DropColumn(
                name: "IsActive",
                schema: "fa",
                table: "ProjectImplementation");

            migrationBuilder.DropColumn(
                name: "IsNew",
                schema: "fa",
                table: "ProjectImplementation");

            migrationBuilder.DropColumn(
                name: "UpdatedDateTime",
                schema: "fa",
                table: "ProjectImplementation");

            migrationBuilder.DropColumn(
                name: "UpdatedUserId",
                schema: "fa",
                table: "ProjectImplementation");

            migrationBuilder.RenameTable(
                name: "ProjectImplementation",
                schema: "fa",
                newName: "ProjectImplementations",
                newSchema: "fa");

            migrationBuilder.RenameColumn(
                name: "PurposeQuestion",
                schema: "fa",
                table: "ProjectInformation",
                newName: "purposeQuestion");

            migrationBuilder.RenameColumn(
                name: "ConsiderQuestion",
                schema: "fa",
                table: "ProjectInformation",
                newName: "considerQuestion");

            migrationBuilder.RenameColumn(
                name: "localMunicipalityId",
                schema: "fa",
                table: "FundingApplicationDetails",
                newName: "ApplicationPeriodId");

            migrationBuilder.RenameColumn(
                name: "UpdatedUserId",
                schema: "fa",
                table: "FundingApplicationDetails",
                newName: "ProjectInformationId");

            migrationBuilder.RenameColumn(
                name: "DistrictCouncilId",
                schema: "fa",
                table: "FundingApplicationDetails",
                newName: "ApplicationDetailId");

            migrationBuilder.RenameIndex(
                name: "IX_FundingApplicationDetails_localMunicipalityId",
                schema: "fa",
                table: "FundingApplicationDetails",
                newName: "IX_FundingApplicationDetails_ApplicationPeriodId");

            migrationBuilder.RenameIndex(
                name: "IX_FundingApplicationDetails_DistrictCouncilId",
                schema: "fa",
                table: "FundingApplicationDetails",
                newName: "IX_FundingApplicationDetails_ApplicationDetailId");

            migrationBuilder.RenameColumn(
                name: "CreatedUserId",
                schema: "fa",
                table: "ProjectImplementations",
                newName: "FundingApplicationDetailId");

            migrationBuilder.AddColumn<int>(
                name: "MonitoringEvaluationId",
                schema: "fa",
                table: "FundingApplicationDetails",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectImplementations",
                schema: "fa",
                table: "ProjectImplementations",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "FinancialMatters",
                schema: "fa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PropertyId = table.Column<int>(type: "int", nullable: false),
                    SubPropertyId = table.Column<int>(type: "int", nullable: false),
                    Property = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    SubProperty = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    AmountOne = table.Column<decimal>(type: "numeric(18,6)", nullable: false),
                    AmountTwo = table.Column<decimal>(type: "numeric(18,6)", nullable: false),
                    AmountThree = table.Column<decimal>(type: "numeric(18,6)", nullable: false),
                    FundingApplicationDetailId = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedUserId = table.Column<int>(type: "int", nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ChangesRequired = table.Column<bool>(type: "bit", nullable: true),
                    IsNew = table.Column<bool>(type: "bit", nullable: true),
                    PropertyTypeId = table.Column<int>(type: "int", nullable: true),
                    PropertySubTypeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinancialMatters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FinancialMatters_FundingApplicationDetails_FundingApplicationDetailId",
                        column: x => x.FundingApplicationDetailId,
                        principalSchema: "fa",
                        principalTable: "FundingApplicationDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FinancialMatters_PropertySubTypes_PropertySubTypeId",
                        column: x => x.PropertySubTypeId,
                        principalSchema: "dropdown",
                        principalTable: "PropertySubTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FinancialMatters_PropertyTypes_PropertyTypeId",
                        column: x => x.PropertyTypeId,
                        principalSchema: "dropdown",
                        principalTable: "PropertyTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FundAppSDADetail",
                schema: "fa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegionId = table.Column<int>(type: "int", nullable: true),
                    DistrictCouncilId = table.Column<int>(type: "int", nullable: false),
                    LocalMunicipalityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FundAppSDADetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FundAppSDADetail_DistrictCouncils_DistrictCouncilId",
                        column: x => x.DistrictCouncilId,
                        principalSchema: "dropdown",
                        principalTable: "DistrictCouncils",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FundAppSDADetail_LocalMunicipalities_LocalMunicipalityId",
                        column: x => x.LocalMunicipalityId,
                        principalSchema: "dropdown",
                        principalTable: "LocalMunicipalities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_FundAppSDADetail_Regions_RegionId",
                        column: x => x.RegionId,
                        principalSchema: "dropdown",
                        principalTable: "Regions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Project_Implementation_Places",
                schema: "mapping",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImplementationId = table.Column<int>(type: "int", nullable: false),
                    PlaceId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project_Implementation_Places", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Project_Implementation_Places_Places_PlaceId",
                        column: x => x.PlaceId,
                        principalSchema: "dropdown",
                        principalTable: "Places",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Project_Implementation_Places_ProjectImplementations_ImplementationId",
                        column: x => x.ImplementationId,
                        principalSchema: "fa",
                        principalTable: "ProjectImplementations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Project_Implementation_SubPlaces",
                schema: "mapping",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImplementationId = table.Column<int>(type: "int", nullable: false),
                    SubPlaceId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project_Implementation_SubPlaces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Project_Implementation_SubPlaces_ProjectImplementations_ImplementationId",
                        column: x => x.ImplementationId,
                        principalSchema: "fa",
                        principalTable: "ProjectImplementations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Project_Implementation_SubPlaces_SubPlaces_SubPlaceId",
                        column: x => x.SubPlaceId,
                        principalSchema: "dropdown",
                        principalTable: "SubPlaces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationDetails",
                schema: "fa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FundAppSDADetailId = table.Column<int>(type: "int", nullable: false),
                    AmountApplyingFor = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApplicationDetails_FundAppSDADetail_FundAppSDADetailId",
                        column: x => x.FundAppSDADetailId,
                        principalSchema: "fa",
                        principalTable: "FundAppSDADetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FundAppSDADetail_Regions",
                schema: "mapping",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    FundAppSDADetailId = table.Column<int>(type: "int", nullable: false),
                    RegionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FundAppSDADetail_Regions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FundAppSDADetail_Regions_FundAppSDADetail_FundAppSDADetailId",
                        column: x => x.FundAppSDADetailId,
                        principalSchema: "fa",
                        principalTable: "FundAppSDADetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FundAppSDADetail_Regions_Regions_RegionId",
                        column: x => x.RegionId,
                        principalSchema: "dropdown",
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ServiceDeliveryAreas",
                schema: "mapping",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FundAppSDADetailId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ServiceDeliveryAreaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceDeliveryAreas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceDeliveryAreas_FundAppSDADetail_FundAppSDADetailId",
                        column: x => x.FundAppSDADetailId,
                        principalSchema: "fa",
                        principalTable: "FundAppSDADetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceDeliveryAreas_ServiceDeliveryAreas_ServiceDeliveryAreaId",
                        column: x => x.ServiceDeliveryAreaId,
                        principalSchema: "dropdown",
                        principalTable: "ServiceDeliveryAreas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 26, 11, 6, 49, 453, DateTimeKind.Local).AddTicks(6829));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 26, 11, 6, 49, 453, DateTimeKind.Local).AddTicks(6832));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 26, 11, 6, 49, 453, DateTimeKind.Local).AddTicks(6833));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 26, 11, 6, 49, 453, DateTimeKind.Local).AddTicks(6834));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 26, 11, 6, 49, 453, DateTimeKind.Local).AddTicks(6835));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 26, 11, 6, 49, 453, DateTimeKind.Local).AddTicks(6836));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 26, 11, 6, 49, 453, DateTimeKind.Local).AddTicks(6837));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 26, 11, 6, 49, 453, DateTimeKind.Local).AddTicks(6839));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 26, 11, 6, 49, 453, DateTimeKind.Local).AddTicks(6840));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 26, 11, 6, 49, 453, DateTimeKind.Local).AddTicks(6841));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 26, 11, 6, 49, 453, DateTimeKind.Local).AddTicks(6842));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 26, 11, 6, 49, 453, DateTimeKind.Local).AddTicks(6843));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 26, 11, 6, 49, 453, DateTimeKind.Local).AddTicks(6844));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 26, 11, 6, 49, 453, DateTimeKind.Local).AddTicks(6845));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 26, 11, 6, 49, 453, DateTimeKind.Local).AddTicks(6846));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 26, 11, 6, 49, 453, DateTimeKind.Local).AddTicks(6848));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 26, 11, 6, 49, 453, DateTimeKind.Local).AddTicks(6849));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 26, 11, 6, 49, 453, DateTimeKind.Local).AddTicks(6850));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 26, 11, 6, 49, 453, DateTimeKind.Local).AddTicks(6851));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 26, 11, 6, 49, 453, DateTimeKind.Local).AddTicks(6852));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 26, 11, 6, 49, 453, DateTimeKind.Local).AddTicks(6858));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 26, 11, 6, 49, 453, DateTimeKind.Local).AddTicks(6859));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 26, 11, 6, 49, 453, DateTimeKind.Local).AddTicks(6866));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 26, 11, 6, 49, 453, DateTimeKind.Local).AddTicks(6880));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 26, 11, 6, 49, 453, DateTimeKind.Local).AddTicks(6881));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 26, 11, 6, 49, 453, DateTimeKind.Local).AddTicks(6882));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 26, 11, 6, 49, 453, DateTimeKind.Local).AddTicks(6883));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 26, 11, 6, 49, 453, DateTimeKind.Local).AddTicks(6884));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 26, 11, 6, 49, 453, DateTimeKind.Local).AddTicks(6885));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 26, 11, 6, 49, 453, DateTimeKind.Local).AddTicks(6886));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 26, 11, 6, 49, 453, DateTimeKind.Local).AddTicks(6887));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 26, 11, 6, 49, 453, DateTimeKind.Local).AddTicks(6888));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 26, 11, 6, 49, 453, DateTimeKind.Local).AddTicks(6702));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 26, 11, 6, 49, 453, DateTimeKind.Local).AddTicks(6720));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 26, 11, 6, 49, 453, DateTimeKind.Local).AddTicks(6722));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 26, 11, 6, 49, 453, DateTimeKind.Local).AddTicks(6724));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 26, 11, 6, 49, 453, DateTimeKind.Local).AddTicks(6725));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 26, 11, 6, 49, 453, DateTimeKind.Local).AddTicks(6760));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 26, 11, 6, 49, 453, DateTimeKind.Local).AddTicks(6761));

            migrationBuilder.CreateIndex(
                name: "IX_FundingApplicationDetails_MonitoringEvaluationId",
                schema: "fa",
                table: "FundingApplicationDetails",
                column: "MonitoringEvaluationId");

            migrationBuilder.CreateIndex(
                name: "IX_FundingApplicationDetails_ProjectInformationId",
                schema: "fa",
                table: "FundingApplicationDetails",
                column: "ProjectInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectImplementations_FundingApplicationDetailId",
                schema: "fa",
                table: "ProjectImplementations",
                column: "FundingApplicationDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationDetails_FundAppSDADetailId",
                schema: "fa",
                table: "ApplicationDetails",
                column: "FundAppSDADetailId");

            migrationBuilder.CreateIndex(
                name: "IX_FinancialMatters_FundingApplicationDetailId",
                schema: "fa",
                table: "FinancialMatters",
                column: "FundingApplicationDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_FinancialMatters_PropertySubTypeId",
                schema: "fa",
                table: "FinancialMatters",
                column: "PropertySubTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_FinancialMatters_PropertyTypeId",
                schema: "fa",
                table: "FinancialMatters",
                column: "PropertyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_FundAppSDADetail_DistrictCouncilId",
                schema: "fa",
                table: "FundAppSDADetail",
                column: "DistrictCouncilId");

            migrationBuilder.CreateIndex(
                name: "IX_FundAppSDADetail_LocalMunicipalityId",
                schema: "fa",
                table: "FundAppSDADetail",
                column: "LocalMunicipalityId");

            migrationBuilder.CreateIndex(
                name: "IX_FundAppSDADetail_RegionId",
                schema: "fa",
                table: "FundAppSDADetail",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_FundAppSDADetail_Regions_FundAppSDADetailId",
                schema: "mapping",
                table: "FundAppSDADetail_Regions",
                column: "FundAppSDADetailId");

            migrationBuilder.CreateIndex(
                name: "IX_FundAppSDADetail_Regions_RegionId",
                schema: "mapping",
                table: "FundAppSDADetail_Regions",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_Implementation_Places_ImplementationId",
                schema: "mapping",
                table: "Project_Implementation_Places",
                column: "ImplementationId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_Implementation_Places_PlaceId",
                schema: "mapping",
                table: "Project_Implementation_Places",
                column: "PlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_Implementation_SubPlaces_ImplementationId",
                schema: "mapping",
                table: "Project_Implementation_SubPlaces",
                column: "ImplementationId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_Implementation_SubPlaces_SubPlaceId",
                schema: "mapping",
                table: "Project_Implementation_SubPlaces",
                column: "SubPlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceDeliveryAreas_FundAppSDADetailId",
                schema: "mapping",
                table: "ServiceDeliveryAreas",
                column: "FundAppSDADetailId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceDeliveryAreas_ServiceDeliveryAreaId",
                schema: "mapping",
                table: "ServiceDeliveryAreas",
                column: "ServiceDeliveryAreaId");

            migrationBuilder.AddForeignKey(
                name: "FK_FundingApplicationDetails_ApplicationDetails_ApplicationDetailId",
                schema: "fa",
                table: "FundingApplicationDetails",
                column: "ApplicationDetailId",
                principalSchema: "fa",
                principalTable: "ApplicationDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FundingApplicationDetails_ApplicationPeriods_ApplicationPeriodId",
                schema: "fa",
                table: "FundingApplicationDetails",
                column: "ApplicationPeriodId",
                principalSchema: "dbo",
                principalTable: "ApplicationPeriods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FundingApplicationDetails_MonitoringEvaluation_MonitoringEvaluationId",
                schema: "fa",
                table: "FundingApplicationDetails",
                column: "MonitoringEvaluationId",
                principalSchema: "fa",
                principalTable: "MonitoringEvaluation",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FundingApplicationDetails_ProjectInformation_ProjectInformationId",
                schema: "fa",
                table: "FundingApplicationDetails",
                column: "ProjectInformationId",
                principalSchema: "fa",
                principalTable: "ProjectInformation",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectImplementations_FundingApplicationDetails_FundingApplicationDetailId",
                schema: "fa",
                table: "ProjectImplementations",
                column: "FundingApplicationDetailId",
                principalSchema: "fa",
                principalTable: "FundingApplicationDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FundingApplicationDetails_ApplicationDetails_ApplicationDetailId",
                schema: "fa",
                table: "FundingApplicationDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_FundingApplicationDetails_ApplicationPeriods_ApplicationPeriodId",
                schema: "fa",
                table: "FundingApplicationDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_FundingApplicationDetails_MonitoringEvaluation_MonitoringEvaluationId",
                schema: "fa",
                table: "FundingApplicationDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_FundingApplicationDetails_ProjectInformation_ProjectInformationId",
                schema: "fa",
                table: "FundingApplicationDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectImplementations_FundingApplicationDetails_FundingApplicationDetailId",
                schema: "fa",
                table: "ProjectImplementations");

            migrationBuilder.DropTable(
                name: "ApplicationDetails",
                schema: "fa");

            migrationBuilder.DropTable(
                name: "FinancialMatters",
                schema: "fa");

            migrationBuilder.DropTable(
                name: "FundAppSDADetail_Regions",
                schema: "mapping");

            migrationBuilder.DropTable(
                name: "Project_Implementation_Places",
                schema: "mapping");

            migrationBuilder.DropTable(
                name: "Project_Implementation_SubPlaces",
                schema: "mapping");

            migrationBuilder.DropTable(
                name: "ServiceDeliveryAreas",
                schema: "mapping");

            migrationBuilder.DropTable(
                name: "FundAppSDADetail",
                schema: "fa");

            migrationBuilder.DropIndex(
                name: "IX_FundingApplicationDetails_MonitoringEvaluationId",
                schema: "fa",
                table: "FundingApplicationDetails");

            migrationBuilder.DropIndex(
                name: "IX_FundingApplicationDetails_ProjectInformationId",
                schema: "fa",
                table: "FundingApplicationDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectImplementations",
                schema: "fa",
                table: "ProjectImplementations");

            migrationBuilder.DropIndex(
                name: "IX_ProjectImplementations_FundingApplicationDetailId",
                schema: "fa",
                table: "ProjectImplementations");

            migrationBuilder.DropColumn(
                name: "MonitoringEvaluationId",
                schema: "fa",
                table: "FundingApplicationDetails");

            migrationBuilder.RenameTable(
                name: "ProjectImplementations",
                schema: "fa",
                newName: "ProjectImplementation",
                newSchema: "fa");

            migrationBuilder.RenameColumn(
                name: "purposeQuestion",
                schema: "fa",
                table: "ProjectInformation",
                newName: "PurposeQuestion");

            migrationBuilder.RenameColumn(
                name: "considerQuestion",
                schema: "fa",
                table: "ProjectInformation",
                newName: "ConsiderQuestion");

            migrationBuilder.RenameColumn(
                name: "ProjectInformationId",
                schema: "fa",
                table: "FundingApplicationDetails",
                newName: "UpdatedUserId");

            migrationBuilder.RenameColumn(
                name: "ApplicationPeriodId",
                schema: "fa",
                table: "FundingApplicationDetails",
                newName: "localMunicipalityId");

            migrationBuilder.RenameColumn(
                name: "ApplicationDetailId",
                schema: "fa",
                table: "FundingApplicationDetails",
                newName: "DistrictCouncilId");

            migrationBuilder.RenameIndex(
                name: "IX_FundingApplicationDetails_ApplicationPeriodId",
                schema: "fa",
                table: "FundingApplicationDetails",
                newName: "IX_FundingApplicationDetails_localMunicipalityId");

            migrationBuilder.RenameIndex(
                name: "IX_FundingApplicationDetails_ApplicationDetailId",
                schema: "fa",
                table: "FundingApplicationDetails",
                newName: "IX_FundingApplicationDetails_DistrictCouncilId");

            migrationBuilder.RenameColumn(
                name: "FundingApplicationDetailId",
                schema: "fa",
                table: "ProjectImplementation",
                newName: "CreatedUserId");

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
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CreatedUserId",
                schema: "fa",
                table: "ProjectInformation",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.AddColumn<decimal>(
                name: "AmountApplyingFor",
                schema: "fa",
                table: "FundingApplicationDetails",
                type: "numeric(18,6)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "ChangesRequired",
                schema: "fa",
                table: "FundingApplicationDetails",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDateTime",
                schema: "fa",
                table: "FundingApplicationDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CreatedUserId",
                schema: "fa",
                table: "FundingApplicationDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                schema: "fa",
                table: "FundingApplicationDetails",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsNew",
                schema: "fa",
                table: "FundingApplicationDetails",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDateTime",
                schema: "fa",
                table: "FundingApplicationDetails",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ApplicationId",
                schema: "fa",
                table: "ProjectImplementation",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDateTime",
                schema: "fa",
                table: "ProjectImplementation",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                schema: "fa",
                table: "ProjectImplementation",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsNew",
                schema: "fa",
                table: "ProjectImplementation",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDateTime",
                schema: "fa",
                table: "ProjectImplementation",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpdatedUserId",
                schema: "fa",
                table: "ProjectImplementation",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectImplementation",
                schema: "fa",
                table: "ProjectImplementation",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ProjectImplementationPlaces",
                schema: "mapping",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImplementationId = table.Column<int>(type: "int", nullable: false),
                    PlaceId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ProjectImplementationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectImplementationPlaces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectImplementationPlaces_Places_PlaceId",
                        column: x => x.PlaceId,
                        principalSchema: "dropdown",
                        principalTable: "Places",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectImplementationPlaces_ProjectImplementation_ProjectImplementationId",
                        column: x => x.ProjectImplementationId,
                        principalSchema: "fa",
                        principalTable: "ProjectImplementation",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProjectImplementationPlaces_ProjectImplementationPlaces_ImplementationId",
                        column: x => x.ImplementationId,
                        principalSchema: "mapping",
                        principalTable: "ProjectImplementationPlaces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectImplementationSubPlaces",
                schema: "mapping",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImplementationId = table.Column<int>(type: "int", nullable: false),
                    SubPlaceId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectImplementationSubPlaces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectImplementationSubPlaces_ProjectImplementation_ImplementationId",
                        column: x => x.ImplementationId,
                        principalSchema: "fa",
                        principalTable: "ProjectImplementation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectImplementationSubPlaces_SubPlaces_SubPlaceId",
                        column: x => x.SubPlaceId,
                        principalSchema: "dropdown",
                        principalTable: "SubPlaces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 24, 8, 48, 25, 328, DateTimeKind.Local).AddTicks(8667));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 24, 8, 48, 25, 328, DateTimeKind.Local).AddTicks(8673));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 24, 8, 48, 25, 328, DateTimeKind.Local).AddTicks(8676));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 24, 8, 48, 25, 328, DateTimeKind.Local).AddTicks(8679));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 24, 8, 48, 25, 328, DateTimeKind.Local).AddTicks(8683));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 24, 8, 48, 25, 328, DateTimeKind.Local).AddTicks(8686));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 24, 8, 48, 25, 328, DateTimeKind.Local).AddTicks(8689));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 24, 8, 48, 25, 328, DateTimeKind.Local).AddTicks(8692));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 24, 8, 48, 25, 328, DateTimeKind.Local).AddTicks(8694));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 24, 8, 48, 25, 328, DateTimeKind.Local).AddTicks(8697));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 24, 8, 48, 25, 328, DateTimeKind.Local).AddTicks(8700));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 24, 8, 48, 25, 328, DateTimeKind.Local).AddTicks(8703));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 24, 8, 48, 25, 328, DateTimeKind.Local).AddTicks(8706));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 24, 8, 48, 25, 328, DateTimeKind.Local).AddTicks(8709));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 24, 8, 48, 25, 328, DateTimeKind.Local).AddTicks(8712));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 24, 8, 48, 25, 328, DateTimeKind.Local).AddTicks(8714));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 24, 8, 48, 25, 328, DateTimeKind.Local).AddTicks(8717));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 24, 8, 48, 25, 328, DateTimeKind.Local).AddTicks(8720));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 24, 8, 48, 25, 328, DateTimeKind.Local).AddTicks(8723));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 24, 8, 48, 25, 328, DateTimeKind.Local).AddTicks(8726));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 24, 8, 48, 25, 328, DateTimeKind.Local).AddTicks(8738));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 24, 8, 48, 25, 328, DateTimeKind.Local).AddTicks(8742));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 24, 8, 48, 25, 328, DateTimeKind.Local).AddTicks(8754));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 24, 8, 48, 25, 328, DateTimeKind.Local).AddTicks(8780));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 24, 8, 48, 25, 328, DateTimeKind.Local).AddTicks(8783));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 24, 8, 48, 25, 328, DateTimeKind.Local).AddTicks(8785));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 24, 8, 48, 25, 328, DateTimeKind.Local).AddTicks(8788));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 24, 8, 48, 25, 328, DateTimeKind.Local).AddTicks(8790));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 24, 8, 48, 25, 328, DateTimeKind.Local).AddTicks(8793));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 24, 8, 48, 25, 328, DateTimeKind.Local).AddTicks(8796));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 24, 8, 48, 25, 328, DateTimeKind.Local).AddTicks(8798));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 24, 8, 48, 25, 328, DateTimeKind.Local).AddTicks(8801));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 24, 8, 48, 25, 328, DateTimeKind.Local).AddTicks(8460));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 24, 8, 48, 25, 328, DateTimeKind.Local).AddTicks(8487));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 24, 8, 48, 25, 328, DateTimeKind.Local).AddTicks(8493));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 24, 8, 48, 25, 328, DateTimeKind.Local).AddTicks(8499));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 24, 8, 48, 25, 328, DateTimeKind.Local).AddTicks(8503));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 24, 8, 48, 25, 328, DateTimeKind.Local).AddTicks(8508));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 24, 8, 48, 25, 328, DateTimeKind.Local).AddTicks(8512));

            migrationBuilder.CreateIndex(
                name: "IX_ProjectImplementationPlaces_ImplementationId",
                schema: "mapping",
                table: "ProjectImplementationPlaces",
                column: "ImplementationId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectImplementationPlaces_PlaceId",
                schema: "mapping",
                table: "ProjectImplementationPlaces",
                column: "PlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectImplementationPlaces_ProjectImplementationId",
                schema: "mapping",
                table: "ProjectImplementationPlaces",
                column: "ProjectImplementationId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectImplementationSubPlaces_ImplementationId",
                schema: "mapping",
                table: "ProjectImplementationSubPlaces",
                column: "ImplementationId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectImplementationSubPlaces_SubPlaceId",
                schema: "mapping",
                table: "ProjectImplementationSubPlaces",
                column: "SubPlaceId");

            migrationBuilder.AddForeignKey(
                name: "FK_FundingApplicationDetails_DistrictCouncils_DistrictCouncilId",
                schema: "fa",
                table: "FundingApplicationDetails",
                column: "DistrictCouncilId",
                principalSchema: "dropdown",
                principalTable: "DistrictCouncils",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FundingApplicationDetails_LocalMunicipalities_localMunicipalityId",
                schema: "fa",
                table: "FundingApplicationDetails",
                column: "localMunicipalityId",
                principalSchema: "dropdown",
                principalTable: "LocalMunicipalities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
