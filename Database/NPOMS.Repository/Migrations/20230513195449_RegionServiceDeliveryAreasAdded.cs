using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NPOMS.Repository.Migrations
{
    public partial class RegionServiceDeliveryAreasAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "fa");

            migrationBuilder.CreateTable(
                name: "FundingApplicationDetails",
                schema: "fa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationId = table.Column<int>(type: "int", nullable: false),
                    DistrictCouncilId = table.Column<int>(type: "int", nullable: false),
                    localMunicipalityId = table.Column<int>(type: "int", nullable: false),
                    AmountApplyingFor = table.Column<decimal>(type: "numeric(18,6)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedUserId = table.Column<int>(type: "int", nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ChangesRequired = table.Column<bool>(type: "bit", nullable: true),
                    IsNew = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FundingApplicationDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FundingApplicationDetails_DistrictCouncils_DistrictCouncilId",
                        column: x => x.DistrictCouncilId,
                        principalSchema: "dropdown",
                        principalTable: "DistrictCouncils",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FundingApplicationDetails_LocalMunicipalities_localMunicipalityId",
                        column: x => x.localMunicipalityId,
                        principalSchema: "dropdown",
                        principalTable: "LocalMunicipalities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Regions",
                schema: "dropdown",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocalMunicipalityId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1"),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
                    UpdatedUserId = table.Column<int>(type: "int", nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Regions_LocalMunicipalities_LocalMunicipalityId",
                        column: x => x.LocalMunicipalityId,
                        principalSchema: "dropdown",
                        principalTable: "LocalMunicipalities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceDeliveryAreas",
                schema: "dropdown",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegionId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1"),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
                    UpdatedUserId = table.Column<int>(type: "int", nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceDeliveryAreas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceDeliveryAreas_Regions_RegionId",
                        column: x => x.RegionId,
                        principalSchema: "dropdown",
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "dropdown",
                table: "Regions",
                columns: new[] { "Id", "LocalMunicipalityId", "Name", "UpdatedDateTime", "UpdatedUserId" },
                values: new object[,]
                {
                    { 1, 5, "Cape Winelands", null, null },
                    { 2, 5, "Cross Boundary", null, null },
                    { 3, 5, "Eden Karoo", null, null },
                    { 4, 5, "Metro East", null, null },
                    { 5, 5, "Metro North", null, null },
                    { 6, 5, "Metro South", null, null },
                    { 7, 5, "Winelands Overberg", null, null },
                    { 8, 6, "West Coast", null, null },
                    { 9, 12, "Winelands Overberg", null, null },
                    { 10, 12, "Cape Winelands", null, null },
                    { 11, 3, "Witzenberg", null, null },
                    { 12, 4, "Cape Agulhas", null, null },
                    { 13, 4, "Overstrand", null, null },
                    { 14, 4, "Swellendam", null, null },
                    { 15, 4, "Theewaterskloof", null, null },
                    { 16, 5, "Bitou", null, null },
                    { 17, 5, "George", null, null },
                    { 18, 5, "Hessequa", null, null },
                    { 19, 5, "Kannaland", null, null },
                    { 20, 5, "Knysna", null, null },
                    { 21, 5, "Mossel Bay", null, null },
                    { 22, 5, "Oudtshoorn", null, null },
                    { 23, 6, "Beaufort West", null, null },
                    { 24, 6, "Laingsburg", null, null },
                    { 25, 6, "Prince Albert", null, null }
                });

            migrationBuilder.InsertData(
                schema: "dropdown",
                table: "ServiceDeliveryAreas",
                columns: new[] { "Id", "Name", "RegionId", "UpdatedDateTime", "UpdatedUserId" },
                values: new object[,]
                {
                    { 1, "Mitchells Plain 1", 6, null, null },
                    { 2, "Mitchells Plain 2", 6, null, null },
                    { 3, "Fish Hoek", 6, null, null },
                    { 4, "Athlone", 6, null, null },
                    { 5, "Gugulethu", 6, null, null },
                    { 6, "Retreat", 6, null, null },
                    { 7, "Claremont", 6, null, null },
                    { 8, "Mowbray", 6, null, null },
                    { 9, "Wynberg", 6, null, null },
                    { 10, "Philippi", 6, null, null },
                    { 11, "Rondebosch", 6, null, null },
                    { 12, "Plumstead", 6, null, null },
                    { 13, "Wetton", 6, null, null },
                    { 14, "Khayelitsha", 6, null, null },
                    { 15, "Khayelitsha 1 SDA", 4, null, null },
                    { 16, "Kraaifontein", 4, null, null },
                    { 17, "Khayelitsha 3  SDA", 4, null, null },
                    { 18, "Somerset West", 4, null, null },
                    { 19, "xxEersterivier", 4, null, null },
                    { 20, "Eersteriver", 4, null, null },
                    { 21, "Blackheath", 4, null, null },
                    { 22, "Khayelitsha 2  SDA", 4, null, null },
                    { 23, "Eerste River", 4, null, null },
                    { 24, "Khayelitsha", 4, null, null },
                    { 25, "Eerste Rivier", 4, null, null },
                    { 26, "Parow", 5, null, null },
                    { 27, "Athlone", 5, null, null },
                    { 28, "xxElsies Rivier", 5, null, null },
                    { 29, "Kraaifontein", 5, null, null },
                    { 30, "Durbanville", 5, null, null },
                    { 31, "Goodwood", 5, null, null },
                    { 32, "Metro North", 5, null, null },
                    { 33, "Tygerberg", 5, null, null },
                    { 34, "Milnerton", 5, null, null },
                    { 35, "Delft", 5, null, null },
                    { 36, "Bellville", 5, null, null },
                    { 37, "Atlantis", 5, null, null },
                    { 38, "Langa", 5, null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_FundingApplicationDetails_DistrictCouncilId",
                schema: "fa",
                table: "FundingApplicationDetails",
                column: "DistrictCouncilId");

            migrationBuilder.CreateIndex(
                name: "IX_FundingApplicationDetails_localMunicipalityId",
                schema: "fa",
                table: "FundingApplicationDetails",
                column: "localMunicipalityId");

            migrationBuilder.CreateIndex(
                name: "IX_Regions_LocalMunicipalityId",
                schema: "dropdown",
                table: "Regions",
                column: "LocalMunicipalityId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceDeliveryAreas_RegionId",
                schema: "dropdown",
                table: "ServiceDeliveryAreas",
                column: "RegionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FundingApplicationDetails",
                schema: "fa");

            migrationBuilder.DropTable(
                name: "ServiceDeliveryAreas",
                schema: "dropdown");

            migrationBuilder.DropTable(
                name: "Regions",
                schema: "dropdown");
        }
    }
}
