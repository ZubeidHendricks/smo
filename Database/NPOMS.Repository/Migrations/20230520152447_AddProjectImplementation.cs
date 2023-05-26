using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NPOMS.Repository.Migrations
{
    public partial class AddProjectImplementation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "Regions",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "Regions",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "Regions",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "Regions",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "Regions",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "Regions",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "Regions",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "Regions",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "Regions",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "Regions",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "Regions",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "Regions",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "Regions",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "Regions",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "Regions",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "Regions",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "Regions",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.CreateTable(
                name: "Places",
                schema: "dropdown",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SystemName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServiceDeliveryAreaId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedUserId = table.Column<int>(type: "int", nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Places", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Places_ServiceDeliveryAreas_ServiceDeliveryAreaId",
                        column: x => x.ServiceDeliveryAreaId,
                        principalSchema: "dropdown",
                        principalTable: "ServiceDeliveryAreas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectImplementation",
                schema: "fa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectObjective = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Beneficiaries = table.Column<int>(type: "int", nullable: false),
                    TimeframeFrom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeframeTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Results = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Resources = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BudgetAmount = table.Column<int>(type: "int", nullable: false),
                    ApplicationId = table.Column<int>(type: "int", nullable: false),
                    IsNew = table.Column<bool>(type: "bit", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedUserId = table.Column<int>(type: "int", nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectImplementation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubPlaces",
                schema: "dropdown",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SystemName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlaceId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedUserId = table.Column<int>(type: "int", nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubPlaces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubPlaces_Places_PlaceId",
                        column: x => x.PlaceId,
                        principalSchema: "dropdown",
                        principalTable: "Places",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                        onDelete: ReferentialAction.NoAction);
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
                        onDelete: ReferentialAction.NoAction);
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
                value: new DateTime(2023, 5, 20, 17, 24, 39, 970, DateTimeKind.Local).AddTicks(1531));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 20, 17, 24, 39, 970, DateTimeKind.Local).AddTicks(1534));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 20, 17, 24, 39, 970, DateTimeKind.Local).AddTicks(1535));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 20, 17, 24, 39, 970, DateTimeKind.Local).AddTicks(1537));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 20, 17, 24, 39, 970, DateTimeKind.Local).AddTicks(1538));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 20, 17, 24, 39, 970, DateTimeKind.Local).AddTicks(1539));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 20, 17, 24, 39, 970, DateTimeKind.Local).AddTicks(1541));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 20, 17, 24, 39, 970, DateTimeKind.Local).AddTicks(1542));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 20, 17, 24, 39, 970, DateTimeKind.Local).AddTicks(1543));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 20, 17, 24, 39, 970, DateTimeKind.Local).AddTicks(1545));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 20, 17, 24, 39, 970, DateTimeKind.Local).AddTicks(1546));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 20, 17, 24, 39, 970, DateTimeKind.Local).AddTicks(1547));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 20, 17, 24, 39, 970, DateTimeKind.Local).AddTicks(1548));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 20, 17, 24, 39, 970, DateTimeKind.Local).AddTicks(1550));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 20, 17, 24, 39, 970, DateTimeKind.Local).AddTicks(1551));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 20, 17, 24, 39, 970, DateTimeKind.Local).AddTicks(1552));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 20, 17, 24, 39, 970, DateTimeKind.Local).AddTicks(1559));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 20, 17, 24, 39, 970, DateTimeKind.Local).AddTicks(1560));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 20, 17, 24, 39, 970, DateTimeKind.Local).AddTicks(1562));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 20, 17, 24, 39, 970, DateTimeKind.Local).AddTicks(1563));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 20, 17, 24, 39, 970, DateTimeKind.Local).AddTicks(1564));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 20, 17, 24, 39, 970, DateTimeKind.Local).AddTicks(1584));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 20, 17, 24, 39, 970, DateTimeKind.Local).AddTicks(1601));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 20, 17, 24, 39, 970, DateTimeKind.Local).AddTicks(1602));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 20, 17, 24, 39, 970, DateTimeKind.Local).AddTicks(1603));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 20, 17, 24, 39, 970, DateTimeKind.Local).AddTicks(1604));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 20, 17, 24, 39, 970, DateTimeKind.Local).AddTicks(1606));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 20, 17, 24, 39, 970, DateTimeKind.Local).AddTicks(1607));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 20, 17, 24, 39, 970, DateTimeKind.Local).AddTicks(1608));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 20, 17, 24, 39, 970, DateTimeKind.Local).AddTicks(1609));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 20, 17, 24, 39, 970, DateTimeKind.Local).AddTicks(1610));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 20, 17, 24, 39, 970, DateTimeKind.Local).AddTicks(1612));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 20, 17, 24, 39, 970, DateTimeKind.Local).AddTicks(1405));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 20, 17, 24, 39, 970, DateTimeKind.Local).AddTicks(1423));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 20, 17, 24, 39, 970, DateTimeKind.Local).AddTicks(1425));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 20, 17, 24, 39, 970, DateTimeKind.Local).AddTicks(1427));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 20, 17, 24, 39, 970, DateTimeKind.Local).AddTicks(1429));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 20, 17, 24, 39, 970, DateTimeKind.Local).AddTicks(1431));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 20, 17, 24, 39, 970, DateTimeKind.Local).AddTicks(1432));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "Regions",
                keyColumn: "Id",
                keyValue: 1,
                column: "LocalMunicipalityId",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "Regions",
                keyColumn: "Id",
                keyValue: 2,
                column: "LocalMunicipalityId",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "Regions",
                keyColumn: "Id",
                keyValue: 3,
                column: "LocalMunicipalityId",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "Regions",
                keyColumn: "Id",
                keyValue: 4,
                column: "LocalMunicipalityId",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "Regions",
                keyColumn: "Id",
                keyValue: 5,
                column: "LocalMunicipalityId",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "Regions",
                keyColumn: "Id",
                keyValue: 6,
                column: "LocalMunicipalityId",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "Regions",
                keyColumn: "Id",
                keyValue: 7,
                column: "LocalMunicipalityId",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "Regions",
                keyColumn: "Id",
                keyValue: 8,
                column: "LocalMunicipalityId",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "ServiceDeliveryAreas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Name", "RegionId" },
                values: new object[] { "Khayelitsha 1 SDA", 4 });

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "ServiceDeliveryAreas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Name", "RegionId" },
                values: new object[] { "Kraaifontein", 4 });

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "ServiceDeliveryAreas",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Name", "RegionId" },
                values: new object[] { "Khayelitsha 3  SDA", 4 });

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "ServiceDeliveryAreas",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Name", "RegionId" },
                values: new object[] { "Somerset West", 4 });

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "ServiceDeliveryAreas",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Name", "RegionId" },
                values: new object[] { "xxEersterivier", 4 });

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "ServiceDeliveryAreas",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Name", "RegionId" },
                values: new object[] { "Khayelitsha", 4 });

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "ServiceDeliveryAreas",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Name", "RegionId" },
                values: new object[] { "Blackheath", 4 });

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "ServiceDeliveryAreas",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Name", "RegionId" },
                values: new object[] { "Eersteriver", 4 });

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "ServiceDeliveryAreas",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Name", "RegionId" },
                values: new object[] { "Elsies River", 7 });

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "ServiceDeliveryAreas",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Name", "RegionId" },
                values: new object[] { "Milnerton", 7 });

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "ServiceDeliveryAreas",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Name", "RegionId" },
                values: new object[] { "Delft", 7 });

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "ServiceDeliveryAreas",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Name", "RegionId" },
                values: new object[] { "Bellville", 7 });

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "ServiceDeliveryAreas",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Name", "RegionId" },
                values: new object[] { "Atlantis", 7 });

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "ServiceDeliveryAreas",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Name", "RegionId" },
                values: new object[] { "Langa", 7 });

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "ServiceDeliveryAreas",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Name", "RegionId" },
                values: new object[] { "Cape Town", 7 });

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "ServiceDeliveryAreas",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "Name", "RegionId" },
                values: new object[] { "Parow", 7 });

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "ServiceDeliveryAreas",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "Name", "RegionId" },
                values: new object[] { "Athlone", 7 });

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "ServiceDeliveryAreas",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "Name", "RegionId" },
                values: new object[] { "xxElsies Rivier", 7 });

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "ServiceDeliveryAreas",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "Name", "RegionId" },
                values: new object[] { "Kraaifontein", 7 });

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "ServiceDeliveryAreas",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "Name", "RegionId" },
                values: new object[] { "Durbanville", 7 });

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "ServiceDeliveryAreas",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "Name", "RegionId" },
                values: new object[] { "Goodwood", 7 });

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "ServiceDeliveryAreas",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "Name", "RegionId" },
                values: new object[] { "Metro North", 7 });

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "ServiceDeliveryAreas",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "Name", "RegionId" },
                values: new object[] { "Tygerberg", 7 });

            //migrationBuilder.UpdateData(
            //    schema: "dropdown",
            //    table: "ServiceDeliveryAreas",
            //    keyColumn: "Id",
            //    keyValue: 24,
            //    columns: new[] { "Name", "RegionId" },
            //    values: new object[] { "Fish Hoek", 25 });

            //migrationBuilder.UpdateData(
            //    schema: "dropdown",
            //    table: "ServiceDeliveryAreas",
            //    keyColumn: "Id",
            //    keyValue: 25,
            //    columns: new[] { "Name", "RegionId" },
            //    values: new object[] { "Mitchells Plain 1", 25 });

            //migrationBuilder.UpdateData(
            //    schema: "dropdown",
            //    table: "ServiceDeliveryAreas",
            //    keyColumn: "Id",
            //    keyValue: 26,
            //    columns: new[] { "Name", "RegionId" },
            //    values: new object[] { "Mitchells Plain 2", 25 });

            //migrationBuilder.UpdateData(
            //    schema: "dropdown",
            //    table: "ServiceDeliveryAreas",
            //    keyColumn: "Id",
            //    keyValue: 27,
            //    column: "RegionId",
            //    value: 25);

            //migrationBuilder.UpdateData(
            //    schema: "dropdown",
            //    table: "ServiceDeliveryAreas",
            //    keyColumn: "Id",
            //    keyValue: 28,
            //    columns: new[] { "Name", "RegionId" },
            //    values: new object[] { "Gugulethu", 25 });

            //migrationBuilder.UpdateData(
            //    schema: "dropdown",
            //    table: "ServiceDeliveryAreas",
            //    keyColumn: "Id",
            //    keyValue: 29,
            //    columns: new[] { "Name", "RegionId" },
            //    values: new object[] { "Retreat", 25 });

            //migrationBuilder.UpdateData(
            //    schema: "dropdown",
            //    table: "ServiceDeliveryAreas",
            //    keyColumn: "Id",
            //    keyValue: 30,
            //    columns: new[] { "Name", "RegionId" },
            //    values: new object[] { "Philippi", 25 });

            //migrationBuilder.UpdateData(
            //    schema: "dropdown",
            //    table: "ServiceDeliveryAreas",
            //    keyColumn: "Id",
            //    keyValue: 31,
            //    columns: new[] { "Name", "RegionId" },
            //    values: new object[] { "Wynberg", 25 });

            //migrationBuilder.UpdateData(
            //    schema: "dropdown",
            //    table: "ServiceDeliveryAreas",
            //    keyColumn: "Id",
            //    keyValue: 32,
            //    columns: new[] { "Name", "RegionId" },
            //    values: new object[] { "Mowbray", 25 });

            //migrationBuilder.UpdateData(
            //    schema: "dropdown",
            //    table: "ServiceDeliveryAreas",
            //    keyColumn: "Id",
            //    keyValue: 33,
            //    columns: new[] { "Name", "RegionId" },
            //    values: new object[] { "Rondebosch", 25 });

            //migrationBuilder.UpdateData(
            //    schema: "dropdown",
            //    table: "ServiceDeliveryAreas",
            //    keyColumn: "Id",
            //    keyValue: 34,
            //    columns: new[] { "Name", "RegionId" },
            //    values: new object[] { "Plumstead", 25 });

            //migrationBuilder.UpdateData(
            //    schema: "dropdown",
            //    table: "ServiceDeliveryAreas",
            //    keyColumn: "Id",
            //    keyValue: 35,
            //    columns: new[] { "Name", "RegionId" },
            //    values: new object[] { "Wetton", 25 });

            //migrationBuilder.UpdateData(
            //    schema: "dropdown",
            //    table: "ServiceDeliveryAreas",
            //    keyColumn: "Id",
            //    keyValue: 36,
            //    columns: new[] { "Name", "RegionId" },
            //    values: new object[] { "Grassy Park", 25 });

            //migrationBuilder.UpdateData(
            //    schema: "dropdown",
            //    table: "ServiceDeliveryAreas",
            //    keyColumn: "Id",
            //    keyValue: 37,
            //    columns: new[] { "Name", "RegionId" },
            //    values: new object[] { "Mitchell's Plain", 25 });

            //migrationBuilder.UpdateData(
            //    schema: "dropdown",
            //    table: "ServiceDeliveryAreas",
            //    keyColumn: "Id",
            //    keyValue: 38,
            //    columns: new[] { "Name", "RegionId" },
            //    values: new object[] { "Nyanga", 25 });

            migrationBuilder.InsertData(
                schema: "dropdown",
                table: "ServiceDeliveryAreas",
                columns: new[] { "Id", "Name", "RegionId", "UpdatedDateTime", "UpdatedUserId" },
                values: new object[,]
                {
                    //{ 39, "Claremont", 25, null, null },
                    //{ 40, "Hout Bay", 25, null, null },
                    //{ 41, "Khayelitsha", 25, null, null },
                    //{ 42, "Lansdowne", 25, null, null },
                    //{ 43, "Nyanga East", 25, null, null },
                    //{ 44, "Ocean View", 25, null, null },
                    //{ 45, "xxPhillipi", 25, null, null },
                    { 46, "Matzikama", 8, null, null },
                    { 47, "Vredenburg", 8, null, null },
                    { 48, "Vredendal", 8, null, null },
                    { 49, "Malmesbury", 8, null, null },
                    { 50, "Veldrift", 8, null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Places_ServiceDeliveryAreaId",
                schema: "dropdown",
                table: "Places",
                column: "ServiceDeliveryAreaId");

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

            migrationBuilder.CreateIndex(
                name: "IX_SubPlaces_PlaceId",
                schema: "dropdown",
                table: "SubPlaces",
                column: "PlaceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectImplementationPlaces",
                schema: "mapping");

            migrationBuilder.DropTable(
                name: "ProjectImplementationSubPlaces",
                schema: "mapping");

            migrationBuilder.DropTable(
                name: "ProjectImplementation",
                schema: "fa");

            migrationBuilder.DropTable(
                name: "SubPlaces",
                schema: "dropdown");

            migrationBuilder.DropTable(
                name: "Places",
                schema: "dropdown");

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "ServiceDeliveryAreas",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "ServiceDeliveryAreas",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "ServiceDeliveryAreas",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "ServiceDeliveryAreas",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "ServiceDeliveryAreas",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "ServiceDeliveryAreas",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "ServiceDeliveryAreas",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "ServiceDeliveryAreas",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "ServiceDeliveryAreas",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "ServiceDeliveryAreas",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "ServiceDeliveryAreas",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                schema: "dropdown",
                table: "ServiceDeliveryAreas",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 18, 11, 49, 40, 591, DateTimeKind.Local).AddTicks(557));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 18, 11, 49, 40, 591, DateTimeKind.Local).AddTicks(559));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 18, 11, 49, 40, 591, DateTimeKind.Local).AddTicks(560));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 18, 11, 49, 40, 591, DateTimeKind.Local).AddTicks(561));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 18, 11, 49, 40, 591, DateTimeKind.Local).AddTicks(562));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 18, 11, 49, 40, 591, DateTimeKind.Local).AddTicks(563));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 18, 11, 49, 40, 591, DateTimeKind.Local).AddTicks(564));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 18, 11, 49, 40, 591, DateTimeKind.Local).AddTicks(565));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 18, 11, 49, 40, 591, DateTimeKind.Local).AddTicks(566));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 18, 11, 49, 40, 591, DateTimeKind.Local).AddTicks(566));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 18, 11, 49, 40, 591, DateTimeKind.Local).AddTicks(567));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 18, 11, 49, 40, 591, DateTimeKind.Local).AddTicks(568));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 18, 11, 49, 40, 591, DateTimeKind.Local).AddTicks(569));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 18, 11, 49, 40, 591, DateTimeKind.Local).AddTicks(570));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 18, 11, 49, 40, 591, DateTimeKind.Local).AddTicks(571));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 18, 11, 49, 40, 591, DateTimeKind.Local).AddTicks(572));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 18, 11, 49, 40, 591, DateTimeKind.Local).AddTicks(584));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 18, 11, 49, 40, 591, DateTimeKind.Local).AddTicks(585));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 18, 11, 49, 40, 591, DateTimeKind.Local).AddTicks(586));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 18, 11, 49, 40, 591, DateTimeKind.Local).AddTicks(587));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 18, 11, 49, 40, 591, DateTimeKind.Local).AddTicks(588));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 18, 11, 49, 40, 591, DateTimeKind.Local).AddTicks(600));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 18, 11, 49, 40, 591, DateTimeKind.Local).AddTicks(612));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 18, 11, 49, 40, 591, DateTimeKind.Local).AddTicks(613));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 18, 11, 49, 40, 591, DateTimeKind.Local).AddTicks(613));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 18, 11, 49, 40, 591, DateTimeKind.Local).AddTicks(614));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 18, 11, 49, 40, 591, DateTimeKind.Local).AddTicks(615));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 18, 11, 49, 40, 591, DateTimeKind.Local).AddTicks(616));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 18, 11, 49, 40, 591, DateTimeKind.Local).AddTicks(617));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 18, 11, 49, 40, 591, DateTimeKind.Local).AddTicks(617));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 18, 11, 49, 40, 591, DateTimeKind.Local).AddTicks(618));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertySubTypes",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 18, 11, 49, 40, 591, DateTimeKind.Local).AddTicks(619));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 18, 11, 49, 40, 591, DateTimeKind.Local).AddTicks(483));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 18, 11, 49, 40, 591, DateTimeKind.Local).AddTicks(497));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 18, 11, 49, 40, 591, DateTimeKind.Local).AddTicks(499));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 18, 11, 49, 40, 591, DateTimeKind.Local).AddTicks(500));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 18, 11, 49, 40, 591, DateTimeKind.Local).AddTicks(501));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 18, 11, 49, 40, 591, DateTimeKind.Local).AddTicks(502));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDateTime",
                value: new DateTime(2023, 5, 18, 11, 49, 40, 591, DateTimeKind.Local).AddTicks(503));

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "Regions",
                keyColumn: "Id",
                keyValue: 1,
                column: "LocalMunicipalityId",
                value: 5);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "Regions",
                keyColumn: "Id",
                keyValue: 2,
                column: "LocalMunicipalityId",
                value: 5);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "Regions",
                keyColumn: "Id",
                keyValue: 3,
                column: "LocalMunicipalityId",
                value: 5);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "Regions",
                keyColumn: "Id",
                keyValue: 4,
                column: "LocalMunicipalityId",
                value: 5);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "Regions",
                keyColumn: "Id",
                keyValue: 5,
                column: "LocalMunicipalityId",
                value: 5);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "Regions",
                keyColumn: "Id",
                keyValue: 6,
                column: "LocalMunicipalityId",
                value: 5);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "Regions",
                keyColumn: "Id",
                keyValue: 7,
                column: "LocalMunicipalityId",
                value: 5);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "Regions",
                keyColumn: "Id",
                keyValue: 8,
                column: "LocalMunicipalityId",
                value: 6);

            migrationBuilder.InsertData(
                schema: "dropdown",
                table: "Regions",
                columns: new[] { "Id", "CreatedDateTime", "CreatedUserId", "IsActive", "LocalMunicipalityId", "Name", "UpdatedDateTime", "UpdatedUserId" },
                values: new object[,]
                {
                    { 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, false, 12, "Winelands Overberg", null, null },
                    { 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, false, 12, "Cape Winelands", null, null },
                    { 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, false, 3, "Witzenberg", null, null },
                    { 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, false, 4, "Cape Agulhas", null, null },
                    { 13, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, false, 4, "Overstrand", null, null },
                    { 14, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, false, 4, "Swellendam", null, null },
                    { 15, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, false, 4, "Theewaterskloof", null, null },
                    { 16, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, false, 5, "Bitou", null, null },
                    { 17, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, false, 5, "George", null, null },
                    { 18, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, false, 5, "Hessequa", null, null },
                    { 19, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, false, 5, "Kannaland", null, null },
                    { 20, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, false, 5, "Knysna", null, null },
                    { 21, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, false, 5, "Mossel Bay", null, null },
                    { 22, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, false, 5, "Oudtshoorn", null, null },
                    { 23, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, false, 6, "Beaufort West", null, null },
                    { 24, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, false, 6, "Laingsburg", null, null },
                    { 25, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, false, 6, "Prince Albert", null, null }
                });

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "ServiceDeliveryAreas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Name", "RegionId" },
                values: new object[] { "Mitchells Plain 1", 6 });

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "ServiceDeliveryAreas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Name", "RegionId" },
                values: new object[] { "Mitchells Plain 2", 6 });

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "ServiceDeliveryAreas",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Name", "RegionId" },
                values: new object[] { "Fish Hoek", 6 });

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "ServiceDeliveryAreas",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Name", "RegionId" },
                values: new object[] { "Athlone", 6 });

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "ServiceDeliveryAreas",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Name", "RegionId" },
                values: new object[] { "Gugulethu", 6 });

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "ServiceDeliveryAreas",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Name", "RegionId" },
                values: new object[] { "Retreat", 6 });

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "ServiceDeliveryAreas",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Name", "RegionId" },
                values: new object[] { "Claremont", 6 });

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "ServiceDeliveryAreas",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Name", "RegionId" },
                values: new object[] { "Mowbray", 6 });

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "ServiceDeliveryAreas",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Name", "RegionId" },
                values: new object[] { "Wynberg", 6 });

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "ServiceDeliveryAreas",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Name", "RegionId" },
                values: new object[] { "Philippi", 6 });

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "ServiceDeliveryAreas",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Name", "RegionId" },
                values: new object[] { "Rondebosch", 6 });

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "ServiceDeliveryAreas",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Name", "RegionId" },
                values: new object[] { "Plumstead", 6 });

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "ServiceDeliveryAreas",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Name", "RegionId" },
                values: new object[] { "Wetton", 6 });

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "ServiceDeliveryAreas",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Name", "RegionId" },
                values: new object[] { "Khayelitsha", 6 });

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "ServiceDeliveryAreas",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Name", "RegionId" },
                values: new object[] { "Khayelitsha 1 SDA", 4 });

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "ServiceDeliveryAreas",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "Name", "RegionId" },
                values: new object[] { "Kraaifontein", 4 });

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "ServiceDeliveryAreas",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "Name", "RegionId" },
                values: new object[] { "Khayelitsha 3  SDA", 4 });

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "ServiceDeliveryAreas",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "Name", "RegionId" },
                values: new object[] { "Somerset West", 4 });

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "ServiceDeliveryAreas",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "Name", "RegionId" },
                values: new object[] { "xxEersterivier", 4 });

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "ServiceDeliveryAreas",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "Name", "RegionId" },
                values: new object[] { "Eersteriver", 4 });

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "ServiceDeliveryAreas",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "Name", "RegionId" },
                values: new object[] { "Blackheath", 4 });

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "ServiceDeliveryAreas",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "Name", "RegionId" },
                values: new object[] { "Khayelitsha 2  SDA", 4 });

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "ServiceDeliveryAreas",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "Name", "RegionId" },
                values: new object[] { "Eerste River", 4 });

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "ServiceDeliveryAreas",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "Name", "RegionId" },
                values: new object[] { "Khayelitsha", 4 });

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "ServiceDeliveryAreas",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "Name", "RegionId" },
                values: new object[] { "Eerste Rivier", 4 });

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "ServiceDeliveryAreas",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "Name", "RegionId" },
                values: new object[] { "Parow", 5 });

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "ServiceDeliveryAreas",
                keyColumn: "Id",
                keyValue: 27,
                column: "RegionId",
                value: 5);

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "ServiceDeliveryAreas",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "Name", "RegionId" },
                values: new object[] { "xxElsies Rivier", 5 });

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "ServiceDeliveryAreas",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "Name", "RegionId" },
                values: new object[] { "Kraaifontein", 5 });

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "ServiceDeliveryAreas",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "Name", "RegionId" },
                values: new object[] { "Durbanville", 5 });

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "ServiceDeliveryAreas",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "Name", "RegionId" },
                values: new object[] { "Goodwood", 5 });

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "ServiceDeliveryAreas",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "Name", "RegionId" },
                values: new object[] { "Metro North", 5 });

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "ServiceDeliveryAreas",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "Name", "RegionId" },
                values: new object[] { "Tygerberg", 5 });

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "ServiceDeliveryAreas",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "Name", "RegionId" },
                values: new object[] { "Milnerton", 5 });

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "ServiceDeliveryAreas",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "Name", "RegionId" },
                values: new object[] { "Delft", 5 });

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "ServiceDeliveryAreas",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "Name", "RegionId" },
                values: new object[] { "Bellville", 5 });

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "ServiceDeliveryAreas",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "Name", "RegionId" },
                values: new object[] { "Atlantis", 5 });

            migrationBuilder.UpdateData(
                schema: "dropdown",
                table: "ServiceDeliveryAreas",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "Name", "RegionId" },
                values: new object[] { "Langa", 5 });
        }
    }
}
