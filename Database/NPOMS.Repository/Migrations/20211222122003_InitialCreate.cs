using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NPOMS.Repository.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.EnsureSchema(
                name: "mapping");

            migrationBuilder.EnsureSchema(
                name: "lookup");

            migrationBuilder.EnsureSchema(
                name: "dropdown");

            migrationBuilder.EnsureSchema(
                name: "core");

            migrationBuilder.CreateTable(
                name: "AccessStatuses",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    SystemName = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1"),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
                    UpdatedUserId = table.Column<int>(type: "int", nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ActivityList",
                schema: "lookup",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1"),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
                    UpdatedUserId = table.Column<int>(type: "int", nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ActivityTypes",
                schema: "dropdown",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    SystemName = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1"),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
                    UpdatedUserId = table.Column<int>(type: "int", nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AllocationTypes",
                schema: "dropdown",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    SystemName = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1"),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
                    UpdatedUserId = table.Column<int>(type: "int", nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllocationTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationTypes",
                schema: "dropdown",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    SystemName = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1"),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
                    UpdatedUserId = table.Column<int>(type: "int", nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                schema: "core",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    Abbreviation = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1"),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
                    UpdatedUserId = table.Column<int>(type: "int", nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DocumentTypes",
                schema: "core",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", nullable: true),
                    IsCompulsory = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1"),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
                    UpdatedUserId = table.Column<int>(type: "int", nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmailAccounts",
                schema: "core",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(2000)", nullable: true),
                    FromDisplayName = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    FromEmail = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    Host = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    Port = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    EnableSSL = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1"),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
                    UpdatedUserId = table.Column<int>(type: "int", nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailAccounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EntityTypes",
                schema: "core",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    SystemName = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1"),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
                    UpdatedUserId = table.Column<int>(type: "int", nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FacilityClasses",
                schema: "dropdown",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1"),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
                    UpdatedUserId = table.Column<int>(type: "int", nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacilityClasses", x => x.Id);
                });
            //migrationBuilder.CreateTable(
            //   name: "FundingTemplateTypes",
            //   schema: "dropdown",
            //   columns: table => new
            //   {
            //       Id = table.Column<int>(type: "int", nullable: false)
            //           .Annotation("SqlServer:Identity", "1, 1"),
            //       Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
            //       SystemName = table.Column<string>(type: "nvarchar(255)", nullable: true),
            //       IsActive = table.Column<bool>(type: "bit", nullable: false),
            //       CreatedUserId = table.Column<int>(type: "int", nullable: false),
            //       CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
            //       UpdatedUserId = table.Column<int>(type: "int", nullable: true),
            //       UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
            //   },
            //   constraints: table =>
            //   {
            //       table.PrimaryKey("PK_FundingTemplateTypes", x => x.Id);
            //   });

            migrationBuilder.CreateTable(
                name: "FacilityDistricts",
                schema: "dropdown",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1"),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
                    UpdatedUserId = table.Column<int>(type: "int", nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacilityDistricts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FacilityTypes",
                schema: "dropdown",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1"),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
                    UpdatedUserId = table.Column<int>(type: "int", nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacilityTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FinancialYears",
                schema: "core",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1"),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
                    UpdatedUserId = table.Column<int>(type: "int", nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinancialYears", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrganisationTypes",
                schema: "dropdown",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1"),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
                    UpdatedUserId = table.Column<int>(type: "int", nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganisationTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Permissions",
                schema: "core",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    SystemName = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1"),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
                    UpdatedUserId = table.Column<int>(type: "int", nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Positions",
                schema: "dropdown",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1"),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
                    UpdatedUserId = table.Column<int>(type: "int", nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Programmes",
                schema: "dropdown",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    SystemName = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1"),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
                    UpdatedUserId = table.Column<int>(type: "int", nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Programmes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProvisionTypes",
                schema: "dropdown",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    SystemName = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1"),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
                    UpdatedUserId = table.Column<int>(type: "int", nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProvisionTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RecipientTypes",
                schema: "dropdown",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    SystemName = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1"),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
                    UpdatedUserId = table.Column<int>(type: "int", nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipientTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ResourceList",
                schema: "lookup",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", nullable: true),
                    ResourceTypeId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1"),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
                    UpdatedUserId = table.Column<int>(type: "int", nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ResourceTypes",
                schema: "dropdown",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    SystemName = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1"),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
                    UpdatedUserId = table.Column<int>(type: "int", nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                schema: "core",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    SystemName = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1"),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
                    UpdatedUserId = table.Column<int>(type: "int", nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServiceTypes",
                schema: "dropdown",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    SystemName = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1"),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
                    UpdatedUserId = table.Column<int>(type: "int", nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Statuses",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    SystemName = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1"),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
                    UpdatedUserId = table.Column<int>(type: "int", nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubProgrammes",
                schema: "dropdown",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    SystemName = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    ProgrammeId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1"),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
                    UpdatedUserId = table.Column<int>(type: "int", nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubProgrammes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Titles",
                schema: "dropdown",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1"),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
                    UpdatedUserId = table.Column<int>(type: "int", nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Titles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "core",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
                    IsB2C = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "0"),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1"),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
                    UpdatedUserId = table.Column<int>(type: "int", nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DocumentStores",
                schema: "core",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RefNo = table.Column<string>(type: "char(15)", nullable: false),
                    DocumentTypeId = table.Column<int>(type: "int", nullable: true),
                    EntityTypeId = table.Column<int>(type: "int", nullable: false),
                    EntityId = table.Column<int>(type: "int", nullable: false),
                    Entity = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    ResourceId = table.Column<string>(type: "nvarchar(80)", nullable: false),
                    FileSize = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedUserId = table.Column<int>(type: "int", nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentStores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocumentStores_DocumentTypes_DocumentTypeId",
                        column: x => x.DocumentTypeId,
                        principalSchema: "core",
                        principalTable: "DocumentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmailTemplates",
                schema: "core",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmailAccountId = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1"),
                    Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    Body = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2000)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailTemplates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmailTemplates_EmailAccounts_EmailAccountId",
                        column: x => x.EmailAccountId,
                        principalSchema: "core",
                        principalTable: "EmailAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FacilitySubDistricts",
                schema: "dropdown",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FacilityDistrictId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1"),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
                    UpdatedUserId = table.Column<int>(type: "int", nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacilitySubDistricts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FacilitySubDistricts_FacilityDistricts_FacilityDistrictId",
                        column: x => x.FacilityDistrictId,
                        principalSchema: "dropdown",
                        principalTable: "FacilityDistricts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Objectives",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1000)", nullable: true),
                    FundingSource = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    FundingPeriodStartDate = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    FundingPeriodEndDate = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    RecipientTypeId = table.Column<int>(type: "int", nullable: false),
                    Budget = table.Column<decimal>(type: "numeric(18,6)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedUserId = table.Column<int>(type: "int", nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ChangesRequired = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Objectives", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Objectives_RecipientTypes_RecipientTypeId",
                        column: x => x.RecipientTypeId,
                        principalSchema: "dropdown",
                        principalTable: "RecipientTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Roles_Permissions",
                schema: "mapping",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    PermissionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles_Permissions", x => new { x.RoleId, x.PermissionId });
                    table.ForeignKey(
                        name: "FK_Roles_Permissions_Permissions_PermissionId",
                        column: x => x.PermissionId,
                        principalSchema: "core",
                        principalTable: "Permissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Roles_Permissions_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "core",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationPeriods",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RefNo = table.Column<string>(type: "char(15)", nullable: true),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    ProgrammeId = table.Column<int>(type: "int", nullable: false),
                    SubProgrammeId = table.Column<int>(type: "int", nullable: false),
                    ApplicationTypeId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(500)", nullable: true),
                    FinancialYearId = table.Column<int>(type: "int", nullable: false),
                    OpeningDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClosingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedUserId = table.Column<int>(type: "int", nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationPeriods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApplicationPeriods_ApplicationTypes_ApplicationTypeId",
                        column: x => x.ApplicationTypeId,
                        principalSchema: "dropdown",
                        principalTable: "ApplicationTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationPeriods_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalSchema: "core",
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationPeriods_FinancialYears_FinancialYearId",
                        column: x => x.FinancialYearId,
                        principalSchema: "core",
                        principalTable: "FinancialYears",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationPeriods_Programmes_ProgrammeId",
                        column: x => x.ProgrammeId,
                        principalSchema: "dropdown",
                        principalTable: "Programmes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationPeriods_SubProgrammes_SubProgrammeId",
                        column: x => x.SubProgrammeId,
                        principalSchema: "dropdown",
                        principalTable: "SubProgrammes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationApprovals",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationId = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    ApprovedFrom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationApprovals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApplicationApprovals_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalSchema: "core",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationAudits",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationId = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationAudits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApplicationAudits_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalSchema: "dbo",
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationAudits_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalSchema: "core",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationComments",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationId = table.Column<int>(type: "int", nullable: false),
                    ServiceProvisionStepId = table.Column<int>(type: "int", nullable: false),
                    EntityId = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(2000)", nullable: false),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApplicationComments_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalSchema: "core",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Npos",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RefNo = table.Column<string>(type: "char(15)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    OrganisationTypeId = table.Column<int>(type: "int", nullable: false),
                    RegistrationNumber = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    YearRegistered = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    Website = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    IsNew = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedUserId = table.Column<int>(type: "int", nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ApprovalStatusId = table.Column<int>(type: "int", nullable: false),
                    ApprovalUserId = table.Column<int>(type: "int", nullable: true),
                    ApprovalDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Npos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Npos_AccessStatuses_ApprovalStatusId",
                        column: x => x.ApprovalStatusId,
                        principalSchema: "dbo",
                        principalTable: "AccessStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Npos_OrganisationTypes_OrganisationTypeId",
                        column: x => x.OrganisationTypeId,
                        principalSchema: "dropdown",
                        principalTable: "OrganisationTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Npos_Users_ApprovalUserId",
                        column: x => x.ApprovalUserId,
                        principalSchema: "core",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Npos_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalSchema: "core",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users_Departments",
                schema: "mapping",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users_Departments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Departments_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalSchema: "core",
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_Departments_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "core",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users_Roles",
                schema: "mapping",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users_Roles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "core",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_Roles_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "core",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmailQueues",
                schema: "core",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmailTemplateId = table.Column<int>(type: "int", nullable: false),
                    FromEmailName = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    FromEmailAddress = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    RecipientName = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    RecipientEmail = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SentDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailQueues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmailQueues_EmailTemplates_EmailTemplateId",
                        column: x => x.EmailTemplateId,
                        principalSchema: "core",
                        principalTable: "EmailTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FacilityList",
                schema: "lookup",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FacilityTypeId = table.Column<int>(type: "int", nullable: false),
                    FacilitySubDistrictId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    FacilityClassId = table.Column<int>(type: "int", nullable: false),
                    Latitude = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Longitude = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    IsNew = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedUserId = table.Column<int>(type: "int", nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacilityList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FacilityList_FacilityClasses_FacilityClassId",
                        column: x => x.FacilityClassId,
                        principalSchema: "dropdown",
                        principalTable: "FacilityClasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FacilityList_FacilitySubDistricts_FacilitySubDistrictId",
                        column: x => x.FacilitySubDistrictId,
                        principalSchema: "dropdown",
                        principalTable: "FacilitySubDistricts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FacilityList_FacilityTypes_FacilityTypeId",
                        column: x => x.FacilityTypeId,
                        principalSchema: "dropdown",
                        principalTable: "FacilityTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Objectives_Programmes",
                schema: "mapping",
                columns: table => new
                {
                    ObjectiveId = table.Column<int>(type: "int", nullable: false),
                    ProgrammeId = table.Column<int>(type: "int", nullable: false),
                    SubProgrammeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Objectives_Programmes", x => new { x.ObjectiveId, x.ProgrammeId, x.SubProgrammeId });
                    table.ForeignKey(
                        name: "FK_Objectives_Programmes_Objectives_ObjectiveId",
                        column: x => x.ObjectiveId,
                        principalSchema: "dbo",
                        principalTable: "Objectives",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Objectives_Programmes_Programmes_ProgrammeId",
                        column: x => x.ProgrammeId,
                        principalSchema: "dropdown",
                        principalTable: "Programmes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Objectives_Programmes_SubProgrammes_SubProgrammeId",
                        column: x => x.SubProgrammeId,
                        principalSchema: "dropdown",
                        principalTable: "SubProgrammes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Applications",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RefNo = table.Column<string>(type: "char(15)", nullable: true),
                    NpoId = table.Column<int>(type: "int", nullable: false),
                    ApplicationPeriodId = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedUserId = table.Column<int>(type: "int", nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Applications_ApplicationPeriods_ApplicationPeriodId",
                        column: x => x.ApplicationPeriodId,
                        principalSchema: "dbo",
                        principalTable: "ApplicationPeriods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Applications_Npos_NpoId",
                        column: x => x.NpoId,
                        principalSchema: "dbo",
                        principalTable: "Npos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Applications_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalSchema: "dbo",
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContactInformation",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NpoId = table.Column<int>(type: "int", nullable: false),
                    TitleId = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    RSAIdNumber = table.Column<bool>(type: "bit", nullable: false),
                    IdNumber = table.Column<string>(type: "nvarchar(13)", nullable: true),
                    PassportNumber = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    EmailAddress = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    Telephone = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Cellphone = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    PositionId = table.Column<int>(type: "int", nullable: false),
                    IsPrimaryContact = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedUserId = table.Column<int>(type: "int", nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactInformation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContactInformation_Npos_NpoId",
                        column: x => x.NpoId,
                        principalSchema: "dbo",
                        principalTable: "Npos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContactInformation_Positions_PositionId",
                        column: x => x.PositionId,
                        principalSchema: "dropdown",
                        principalTable: "Positions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContactInformation_Titles_TitleId",
                        column: x => x.TitleId,
                        principalSchema: "dropdown",
                        principalTable: "Titles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NpoProfiles",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NpoId = table.Column<int>(type: "int", nullable: false),
                    RefNo = table.Column<string>(type: "char(15)", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedUserId = table.Column<int>(type: "int", nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NpoProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NpoProfiles_Npos_NpoId",
                        column: x => x.NpoId,
                        principalSchema: "dbo",
                        principalTable: "Npos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users_Npos",
                schema: "mapping",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    NpoId = table.Column<int>(type: "int", nullable: false),
                    AccessStatusId = table.Column<int>(type: "int", nullable: false),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedUserId = table.Column<int>(type: "int", nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users_Npos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Npos_AccessStatuses_AccessStatusId",
                        column: x => x.AccessStatusId,
                        principalSchema: "dbo",
                        principalTable: "AccessStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_Npos_Npos_NpoId",
                        column: x => x.NpoId,
                        principalSchema: "dbo",
                        principalTable: "Npos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Users_Npos_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalSchema: "core",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_Npos_Users_UpdatedUserId",
                        column: x => x.UpdatedUserId,
                        principalSchema: "core",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_Npos_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "core",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Activities",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationId = table.Column<int>(type: "int", nullable: false),
                    ObjectiveId = table.Column<int>(type: "int", nullable: false),
                    ActivityListId = table.Column<int>(type: "int", nullable: false),
                    ActivityTypeId = table.Column<int>(type: "int", nullable: false),
                    TimelineStartDate = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    TimelineEndDate = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Target = table.Column<int>(type: "int", nullable: false),
                    SuccessIndicator = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    FacilityListId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedUserId = table.Column<int>(type: "int", nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ChangesRequired = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Activities_ActivityList_ActivityListId",
                        column: x => x.ActivityListId,
                        principalSchema: "lookup",
                        principalTable: "ActivityList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Activities_ActivityTypes_ActivityTypeId",
                        column: x => x.ActivityTypeId,
                        principalSchema: "dropdown",
                        principalTable: "ActivityTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Activities_FacilityList_FacilityListId",
                        column: x => x.FacilityListId,
                        principalSchema: "lookup",
                        principalTable: "FacilityList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Activities_Objectives_ObjectiveId",
                        column: x => x.ObjectiveId,
                        principalSchema: "dbo",
                        principalTable: "Objectives",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AddressInformation",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NpoProfileId = table.Column<int>(type: "int", nullable: false),
                    PhysicalAddress = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    PostalSameAsPhysical = table.Column<bool>(type: "bit", nullable: true),
                    PostalAddress = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedUserId = table.Column<int>(type: "int", nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressInformation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AddressInformation_NpoProfiles_NpoProfileId",
                        column: x => x.NpoProfileId,
                        principalSchema: "dbo",
                        principalTable: "NpoProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NpoProfiles_FacilityLists",
                schema: "mapping",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NpoProfileId = table.Column<int>(type: "int", nullable: false),
                    FacilityListId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NpoProfiles_FacilityLists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NpoProfiles_FacilityLists_FacilityList_FacilityListId",
                        column: x => x.FacilityListId,
                        principalSchema: "lookup",
                        principalTable: "FacilityList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NpoProfiles_FacilityLists_NpoProfiles_NpoProfileId",
                        column: x => x.NpoProfileId,
                        principalSchema: "dbo",
                        principalTable: "NpoProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Activities_SubProgrammes",
                schema: "mapping",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActivityId = table.Column<int>(type: "int", nullable: false),
                    SubProgrammeId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities_SubProgrammes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Activities_SubProgrammes_Activities_ActivityId",
                        column: x => x.ActivityId,
                        principalSchema: "dbo",
                        principalTable: "Activities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Activities_SubProgrammes_SubProgrammes_SubProgrammeId",
                        column: x => x.SubProgrammeId,
                        principalSchema: "dropdown",
                        principalTable: "SubProgrammes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Resources",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationId = table.Column<int>(type: "int", nullable: false),
                    ActivityId = table.Column<int>(type: "int", nullable: false),
                    ResourceTypeId = table.Column<int>(type: "int", nullable: false),
                    ServiceTypeId = table.Column<int>(type: "int", nullable: false),
                    AllocationTypeId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2000)", nullable: true),
                    ProvisionTypeId = table.Column<int>(type: "int", nullable: false),
                    ResourceListId = table.Column<int>(type: "int", nullable: false),
                    NumberOfResources = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedUserId = table.Column<int>(type: "int", nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ChangesRequired = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resources", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Resources_Activities_ActivityId",
                        column: x => x.ActivityId,
                        principalSchema: "dbo",
                        principalTable: "Activities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Resources_AllocationTypes_AllocationTypeId",
                        column: x => x.AllocationTypeId,
                        principalSchema: "dropdown",
                        principalTable: "AllocationTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Resources_ProvisionTypes_ProvisionTypeId",
                        column: x => x.ProvisionTypeId,
                        principalSchema: "dropdown",
                        principalTable: "ProvisionTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Resources_ResourceList_ResourceListId",
                        column: x => x.ResourceListId,
                        principalSchema: "lookup",
                        principalTable: "ResourceList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Resources_ResourceTypes_ResourceTypeId",
                        column: x => x.ResourceTypeId,
                        principalSchema: "dropdown",
                        principalTable: "ResourceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Resources_ServiceTypes_ServiceTypeId",
                        column: x => x.ServiceTypeId,
                        principalSchema: "dropdown",
                        principalTable: "ServiceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SustainabilityPlans",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationId = table.Column<int>(type: "int", nullable: false),
                    ActivityId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2000)", nullable: true),
                    Risk = table.Column<string>(type: "nvarchar(1000)", nullable: true),
                    Mitigation = table.Column<string>(type: "nvarchar(1000)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedUserId = table.Column<int>(type: "int", nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ChangesRequired = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SustainabilityPlans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SustainabilityPlans_Activities_ActivityId",
                        column: x => x.ActivityId,
                        principalSchema: "dbo",
                        principalTable: "Activities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "core",
                table: "Departments",
                columns: new[] { "Id", "Abbreviation", "IsActive", "Name", "UpdatedDateTime", "UpdatedUserId" },
                values: new object[,]
                {
                    { 1, "ALL", true, "All Departments", null, null },
                    { 16, "NONE", true, "None", null, null }
                });

            migrationBuilder.InsertData(
                schema: "core",
                table: "Departments",
                columns: new[] { "Id", "Abbreviation", "Name", "UpdatedDateTime", "UpdatedUserId" },
                values: new object[,]
                {
                    { 15, "DEA&DP", "Environmental Affairs and Development Planning", null, null },
                    { 14, "WCPP", "Provincial Parliament", null, null },
                    { 13, "DLG", "Local Government", null, null }
                });

            migrationBuilder.InsertData(
                schema: "core",
                table: "Departments",
                columns: new[] { "Id", "Abbreviation", "IsActive", "Name", "UpdatedDateTime", "UpdatedUserId" },
                values: new object[] { 11, "DoH", true, "Health", null, null });

            migrationBuilder.InsertData(
                schema: "core",
                table: "Departments",
                columns: new[] { "Id", "Abbreviation", "Name", "UpdatedDateTime", "UpdatedUserId" },
                values: new object[,]
                {
                    { 10, "DCAS", "Cultural Affairs and Sport", null, null },
                    { 9, "DCS", "Community Safety", null, null },
                    { 12, "DHS", "Human Settlements", null, null },
                    { 7, "DSD", "Social Development", null, null },
                    { 6, "PT", "Provincial Treasury", null, null },
                    { 5, "DotP", "Premier", null, null },
                    { 4, "WCED", "Education", null, null },
                    { 3, "DTPW", "Transport and Public Works", null, null },
                    { 2, "DEDAT", "Economic Development and Tourism", null, null },
                    { 8, "DoA", "Agriculture", null, null }
                });

            migrationBuilder.InsertData(
                schema: "core",
                table: "DocumentTypes",
                columns: new[] { "Id", "Description", "Name", "UpdatedDateTime", "UpdatedUserId" },
                values: new object[,]
                {
                    { 1, null, "SLA", null, null },
                    { 2, null, "Signed SLA", null, null }
                });

            migrationBuilder.InsertData(
                schema: "core",
                table: "EmailAccounts",
                columns: new[] { "Id", "Description", "EnableSSL", "FromDisplayName", "FromEmail", "Host", "Password", "Port", "UpdatedDateTime", "UpdatedUserId", "UserName" },
                values: new object[] { 1, "default account", false, "npoms-no-reply", "npoms.no-reply@westerncape.gov.za", "https://wa-taps-smtp-nonprod-zan.azurewebsites.net/api/user/EmailSend", null, 25, null, null, null });

            migrationBuilder.InsertData(
                schema: "core",
                table: "EmailTemplates",
                columns: new[] { "Id", "Body", "Description", "Name", "Subject" },
                values: new object[,]
                {
                    { 8, "<p>Dear {ToUserFullName},</p><p>The application with Reference Number <span style=\"font-weight: bold;\">{ApplicationRefNo}</span> has been sent for you to approve.</p><p>Please <a href=\"{url}/applications\">click here</a> to access the NPO MS application.</p><p>Kind Regards,<br>NPO MS Team</p>", null, "StatusChangedPendingApproval", "testing*** Application Pending Approval - {NPO}" },
                    { 11, "<p>Dear {ToUserFullName},</p><p>The application with Reference Number <span style=\"font-weight: bold;\">{ApplicationRefNo}</span> has been approved.</p><p>Please download the SLA document that requires your signature and upload the signed SLA document.</p><p>Please <a href=\"{url}/applications\">click here</a> to access the NPO MS application.</p><p>Kind Regards,<br>NPO MS Team</p>", null, "StatusChangedPendingSignedSLA", "testing*** Application Pending Signed SLA - {NPO}" },
                    { 10, "<p>Dear {ToUserFullName},</p><p>The application with Reference Number <span style=\"font-weight: bold;\">{ApplicationRefNo}</span> has been approved.</p><p>Please upload the SLA document.</p><p>Please <a href=\"{url}/applications\">click here</a> to access the NPO MS application.</p><p>Kind Regards,<br>NPO MS Team</p>", null, "StatusChangedPendingSLA", "testing*** Application Pending SLA - {NPO}" },
                    { 9, "<p>Dear {ToUserFullName},</p><p>The application with Reference Number <span style=\"font-weight: bold;\">{ApplicationRefNo}</span> has been rejected.</p><p>Please <a href=\"{url}/applications\">click here</a> to access the NPO MS application.</p><p>Kind Regards,<br>NPO MS Team</p>", null, "StatusChangedRejected", "testing*** Application Rejected - {NPO}" },
                    { 7, "<p>Dear {ToUserFullName},</p><p>There are changes required to the application with Reference Number <span style=\"font-weight: bold;\">{ApplicationRefNo}</span>.</p><p>Please <a href=\"{url}/applications\">click here</a> to access the NPO MS application.</p><p>Kind Regards,<br>NPO MS Team</p>", null, "StatusChangedAmendmentsRequired", "testing*** Amendments Required - {NPO}" },
                    { 12, "<p>Dear {ToUserFullName},</p><p>The signed SLA document has been uploaded for application with Reference Number <span style=\"font-weight: bold;\">{ApplicationRefNo}</span>.</p><p>Please <a href=\"{url}/applications\">click here</a> to access the NPO MS application.</p><p>Kind Regards,<br>NPO MS Team</p>", null, "StatusChangedAcceptedSLA", "testing*** Application Accepted SLA - {NPO}" },
                    { 5, "<p>Dear {ToUserFullName},</p><p>The application for <span style=\"font-weight: bold;\">{NPO}</span> has been sent to be reviewed. The Reference Number is <span style=\"font-weight: bold;\">{ApplicationRefNo}</span>.</p><p>Please <a href=\"{url}/applications\">click here</a> to access the NPO MS application.</p><p>Kind Regards,<br>NPO MS Team</p>", null, "NewApplication", "testing*** Application Submitted - {NPO}" },
                    { 4, "<p>Dear {ToUserFullName},</p><p>Access to <span style=\"font-weight: bold;\">{NpoName}</span> has been rejected.</p><p>Please <a href=\"{url}\">click here</a> to access the NPO MS application.</p><p>Kind Regards,<br>NPO MS Team</p>", null, "AccessRequestRejected", "testing*** Access Request Rejected" },
                    { 3, "<p>Dear {ToUserFullName},</p><p>Access to <span style=\"font-weight: bold;\">{NpoName}</span> has been approved.</p><p>Please <a href=\"{url}\">click here</a> to access the NPO MS application.</p><p>Kind Regards,<br>NPO MS Team</p>", null, "AccessRequestApproved", "testing*** Access Request Approved" },
                    { 2, "<p>Dear {ToUserFullName},</p><p>Please review access for <span style=\"font-weight: bold;\">{UserAccessFullName}</span> to the following Organisation: <span style=\"font-weight: bold;\">{NpoName}</span>.</p><p>Please <a href=\"{url}/access-review\">click here</a> to access the NPO MS application.</p><p>Kind Regards,<br>NPO MS Team</p>", null, "AccessRequestPending", "testing*** Access Request Submitted" },
                    { 1, "<p>Dear {ToUserFullName},</p><p>Access to <span style=\"font-weight: bold;\">{NpoName}</span> has been sent to be reviewed.</p><p>Please <a href=\"{url}\">click here</a> to access the NPO MS application.</p><p>Kind Regards,<br>NPO MS Team</p>", null, "NewAccessRequest", "testing*** Access Request Created" },
                    { 6, "<p>Dear {ToUserFullName},</p><p>The application with Reference Number <span style=\"font-weight: bold;\">{ApplicationRefNo}</span> has been submitted for you to review.</p><p>Please <a href=\"{url}/applications\">click here</a> to access the NPO MS application.</p><p>Kind Regards,<br>NPO MS Team</p>", null, "StatusChangedPendingReview", "testing*** Application Pending Review - {NPO}" }
                });

            migrationBuilder.InsertData(
                schema: "core",
                table: "EntityTypes",
                columns: new[] { "Id", "Name", "SystemName", "UpdatedDateTime", "UpdatedUserId" },
                values: new object[,]
                {
                    { 1, "Supporting Documents", "SupportingDocuments", null, null },
                    { 2, "SLA", "SLA", null, null }
                });

            migrationBuilder.InsertData(
                schema: "core",
                table: "FinancialYears",
                columns: new[] { "Id", "EndDate", "Name", "StartDate", "UpdatedDateTime", "UpdatedUserId", "Year" },
                values: new object[,]
                {
                    { 8, new DateTime(2029, 3, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), "2028/29", new DateTime(2028, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 2028 },
                    { 7, new DateTime(2028, 3, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), "2027/28", new DateTime(2027, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 2027 },
                    { 6, new DateTime(2027, 3, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), "2026/27", new DateTime(2026, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 2026 },
                    { 5, new DateTime(2026, 3, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), "2025/26", new DateTime(2025, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 2025 },
                    { 3, new DateTime(2024, 3, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), "2023/24", new DateTime(2023, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 2023 },
                    { 2, new DateTime(2023, 3, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), "2022/23", new DateTime(2022, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 2022 },
                    { 1, new DateTime(2022, 3, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), "2021/22", new DateTime(2021, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 2021 },
                    { 4, new DateTime(2025, 3, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), "2024/25", new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 2024 }
                });

            migrationBuilder.InsertData(
                schema: "core",
                table: "Permissions",
                columns: new[] { "Id", "CategoryName", "Name", "SystemName", "UpdatedDateTime", "UpdatedUserId" },
                values: new object[] { 31, "Top Navigation", "View Captured Applications Menu", "TN.VAppM", null, null });

            migrationBuilder.InsertData(
                schema: "core",
                table: "Permissions",
                columns: new[] { "Id", "CategoryName", "Name", "SystemName", "UpdatedDateTime", "UpdatedUserId" },
                values: new object[,]
                {
                    { 25, "Organisation", "Show Organisation Action Buttons", "NPO.SNA", null, null },
                    { 26, "Top Navigation", "View Application Period (Programme Selection) Menu", "TN.VAPM", null, null },
                    { 24, "Organisation", "View List of Organisations", "NPO.View", null, null },
                    { 27, "Application Period (Programme Selection)", "Add Application Period (Programme Selection)", "AP.Add", null, null },
                    { 28, "Application Period (Programme Selection)", "Edit Application Period (Programme Selection)", "AP.Edit", null, null },
                    { 29, "Application Period (Programme Selection)", "View List of Application Periods (Programme Selection)", "AP.View", null, null },
                    { 30, "Application Period (Programme Selection)", "Show Application Period (Programme Selection) Action Buttons", "AP.SAPA", null, null },
                    { 32, "Application", "Add Application", "App.Add", null, null },
                    { 40, "Application", "Approve Application", "App.Approve", null, null },
                    { 34, "Application", "View List of Applications", "App.View", null, null },
                    { 35, "Application", "Show Application Action Buttons", "App.SAA", null, null },
                    { 36, "Top Navigation", "View Organisation Approval Menu", "TN.VNA", null, null },
                    { 37, "Organisation Approval Management", "Edit Organisation Approval", "NAM.ENR", null, null },
                    { 38, "NPO Organisation Management", "View List of Organisations for approval requests", "NAM.VNR", null, null },
                    { 39, "Application", "Review Application", "App.Review", null, null },
                    { 41, "Application", "Upload SLA Document", "App.Upload", null, null },
                    { 42, "Application", "View Accepted SLA Application", "App.VAA", null, null },
                    { 23, "Organisation", "Edit Organisation", "NPO.Edit", null, null },
                    { 33, "Application", "Edit Application", "App.Edit", null, null },
                    { 22, "Organisation", "Add Organisation", "NPO.Add", null, null },
                    { 14, "Organisation Profile", "Show Organisation Profile Actions", "NP.SPA", null, null },
                    { 20, "User Access Management", "View List of User Requests", "UAM.VUR", null, null },
                    { 1, "User Administration", "Add Users", "UA.AU", null, null },
                    { 2, "User Administration", "View List of Users", "UA.VU", null, null },
                    { 3, "User Administration", "Edit Users", "UA.EU", null, null },
                    { 4, "Utilities Management", "Add Utilities", "UM.AU", null, null },
                    { 5, "Utilities Management", "View List of Utilities", "UM.VU", null, null },
                    { 6, "Utilities Management", "Edit Utilities", "UM.EU", null, null },
                    { 7, "Permission Management", "View List of Permissions", "PM.VP", null, null },
                    { 8, "Permission Management", "Edit Permissions", "PM.EP", null, null },
                    { 10, "Top Navigation", "View Organisation Profile Menu", "TN.VPM", null, null },
                    { 9, "Top Navigation", "View Admin Menu", "TN.VAM", null, null },
                    { 12, "Organisation Profile", "Edit Organisation Profile", "NP.ENP", null, null },
                    { 13, "Organisation Profile", "View List of Organisation Profiles", "NP.VNP", null, null },
                    { 15, "User Administration", "Show User Administration Action Buttons", "UA.SUA", null, null },
                    { 16, "Top Navigation", "View Apply For Access Menu", "TN.VAAM", null, null },
                    { 17, "Top Navigation", "View Access Review Menu", "TN.VARM", null, null },
                    { 18, "User Access Management", "Add User Requests - Apply for access", "UAM.AUR", null, null },
                    { 19, "User Access Management", "Edit User Requests - Review access requests", "UAM.EUR", null, null },
                    { 11, "Organisation Profile", "Add Organisation Profile", "NP.ANP", null, null },
                    { 21, "Top Navigation", "View Organisations Menu", "TN.VNM", null, null }
                });

            migrationBuilder.InsertData(
                schema: "core",
                table: "Roles",
                columns: new[] { "Id", "Name", "SystemName", "UpdatedDateTime", "UpdatedUserId" },
                values: new object[] { 4, "Reviewer", "Reviewer", null, null });

            migrationBuilder.InsertData(
                schema: "core",
                table: "Roles",
                columns: new[] { "Id", "Name", "SystemName", "UpdatedDateTime", "UpdatedUserId" },
                values: new object[,]
                {
                    { 6, "Approver", "Approver", null, null },
                    { 5, "Main Reviewer", "MainReviewer", null, null },
                    { 3, "Applicant", "Applicant", null, null },
                    { 1, "System Administrator", "SystemAdmin", null, null },
                    { 2, "Administrator", "Admin", null, null }
                });

            migrationBuilder.InsertData(
                schema: "core",
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "UpdatedDateTime", "UpdatedUserId", "UserName" },
                values: new object[,]
                {
                    { 1, "npoms.admin@westerncape.gov.za", "System", "User", null, null, "npoms.admin@westerncape.gov.za" },
                    { 2, "Taariq.Kamaar@westerncape.gov.za", "Taariq", "Kamaar", null, null, "Taariq.Kamaar@westerncape.gov.za" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "AccessStatuses",
                columns: new[] { "Id", "Name", "SystemName", "UpdatedDateTime", "UpdatedUserId" },
                values: new object[,]
                {
                    { 4, "New", "New", null, null },
                    { 2, "Approved", "Approved", null, null },
                    { 1, "Pending", "Pending", null, null },
                    { 3, "Rejected", "Rejected", null, null }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Statuses",
                columns: new[] { "Id", "Name", "SystemName", "UpdatedDateTime", "UpdatedUserId" },
                values: new object[,]
                {
                    { 9, "Accepted SLA", "AcceptedSLA", null, null },
                    { 1, "New", "New", null, null },
                    { 2, "Saved", "Saved", null, null },
                    { 3, "Pending Review", "PendingReview", null, null },
                    { 4, "Amendments Required", "AmendmentsRequired", null, null },
                    { 5, "Pending Approval", "PendingApproval", null, null },
                    { 6, "Rejected", "Rejected", null, null },
                    { 7, "Pending SLA", "PendingSLA", null, null },
                    { 8, "Pending Signed SLA", "PendingSignedSLA", null, null },
                    { 10, "Approval In Progress", "ApprovalInProgress", null, null }
                });

            migrationBuilder.InsertData(
                schema: "dropdown",
                table: "ActivityTypes",
                columns: new[] { "Id", "Name", "SystemName", "UpdatedDateTime", "UpdatedUserId" },
                values: new object[,]
                {
                    { 2, "Ongoing", "Ongoing", null, null },
                    { 1, "New", "New", null, null }
                });

            migrationBuilder.InsertData(
                schema: "dropdown",
                table: "AllocationTypes",
                columns: new[] { "Id", "Name", "SystemName", "UpdatedDateTime", "UpdatedUserId" },
                values: new object[,]
                {
                    { 1, "Province", "Province", null, null },
                    { 2, "City of Cape Town", "CoCT", null, null }
                });

            migrationBuilder.InsertData(
                schema: "dropdown",
                table: "ApplicationTypes",
                columns: new[] { "Id", "Name", "SystemName", "UpdatedDateTime", "UpdatedUserId" },
                values: new object[,]
                {
                    { 2, "Service Provision", "SP", null, null },
                    { 1, "Funding Application", "FA", null, null }
                });

            migrationBuilder.InsertData(
                schema: "dropdown",
                table: "FacilityClasses",
                columns: new[] { "Id", "Name", "UpdatedDateTime", "UpdatedUserId" },
                values: new object[,]
                {
                    { 14, "Independent Cons Rooms - Registered Practitioner", null, null },
                    { 47, "Educare Centre", null, null },
                    { 48, "Pre-primary School", null, null },
                    { 49, "Creche", null, null },
                    { 50, "Secondary School", null, null },
                    { 51, "Combined School", null, null },
                    { 52, "Intermediate School", null, null },
                    { 53, "Preparatory School", null, null },
                    { 54, "Military Hospital", null, null },
                    { 13, "Private Hospital", null, null },
                    { 56, "Tertiary Hospital", null, null },
                    { 57, "Laundry Service", null, null },
                    { 58, "Organisational unit", null, null },
                    { 59, "Primary Distribution Site", null, null },
                    { 60, "Records Repository", null, null }
                });

            migrationBuilder.InsertData(
                schema: "dropdown",
                table: "FacilityClasses",
                columns: new[] { "Id", "Name", "UpdatedDateTime", "UpdatedUserId" },
                values: new object[,]
                {
                    { 12, "Independent Cons Rooms - General Practitioner", null, null },
                    { 11, "Clinic", null, null },
                    { 10, "Occupational Health Centre", null, null },
                    { 9, "Private Pharmacy", null, null },
                    { 8, "Intermediate Care", null, null },
                    { 7, "Community Day Centre", null, null },
                    { 6, "Primary School", null, null },
                    { 5, "Reproductive Health Centre", null, null },
                    { 4, "Non-medical Site", null, null },
                    { 3, "Special School", null, null },
                    { 2, "Health Post", null, null },
                    { 1, "Mobile Service", null, null },
                    { 46, "Early Childhood Development Centre", null, null },
                    { 45, "School Health Services Unit", null, null },
                    { 55, "Specialised Psychiatric Hospital", null, null },
                    { 43, "National Central Hospital", null, null },
                    { 25, "Specialised TB Hospital", null, null },
                    { 24, "Specialised Rehabilitation Unit", null, null },
                    { 23, "Satellite Clinic", null, null },
                    { 22, "Hospice unit", null, null },
                    { 21, "Correctional Centre", null, null },
                    { 20, "Home Based Care", null, null },
                    { 19, "Day Care Centre", null, null },
                    { 18, "Dental Clinic", null, null },
                    { 17, "Community Health Centre (After hours)", null, null },
                    { 44, "Engineering services", null, null },
                    { 16, "Private Clinic", null, null },
                    { 15, "Community Health Centre", null, null },
                    { 27, "District Hospital", null, null },
                    { 28, "Sickbay", null, null },
                    { 26, "Community Health Centre / Clinic", null, null },
                    { 33, "Special Clinic", null, null },
                    { 42, "Independent Cons Rooms - Specialist", null, null },
                    { 30, "Step Down Facility", null, null },
                    { 41, "Midwife Obstetrics Unit", null, null },
                    { 40, "Specialised Hospital", null, null },
                    { 39, "Forensic Pathology Service", null, null },
                    { 38, "Medical Centre", null, null },
                    { 37, "Regional Hospital", null, null },
                    { 31, "Environmental Health Office", null, null },
                    { 32, "Health Promotion Service", null, null },
                    { 29, "Pharmacy Depot", null, null }
                });

            migrationBuilder.InsertData(
                schema: "dropdown",
                table: "FacilityClasses",
                columns: new[] { "Id", "Name", "UpdatedDateTime", "UpdatedUserId" },
                values: new object[,]
                {
                    { 34, "EMS Station", null, null },
                    { 35, "Frail Care Centre", null, null },
                    { 36, "Specialised Oral Health Centre", null, null }
                });

            migrationBuilder.InsertData(
                schema: "dropdown",
                table: "FacilityDistricts",
                columns: new[] { "Id", "Name", "UpdatedDateTime", "UpdatedUserId" },
                values: new object[,]
                {
                    { 1, "Cape Winelands District Municipality", null, null },
                    { 6, "Central Karoo District Municipality", null, null },
                    { 5, "Garden Route District Municipality", null, null },
                    { 4, "Overberg District Municipality", null, null },
                    { 2, "City of Cape Town Metropolitan Municipality", null, null },
                    { 3, "West Coast District Municipality", null, null }
                });

            migrationBuilder.InsertData(
                schema: "dropdown",
                table: "FacilityTypes",
                columns: new[] { "Id", "Name", "UpdatedDateTime", "UpdatedUserId" },
                values: new object[,]
                {
                    { 1, "Facility", null, null },
                    { 2, "Community Place", null, null }
                });

            migrationBuilder.InsertData(
                schema: "dropdown",
                table: "OrganisationTypes",
                columns: new[] { "Id", "Description", "Name", "UpdatedDateTime", "UpdatedUserId" },
                values: new object[,]
                {
                    { 3, "Trust registered as NPO", "NPO/Trust", null, null },
                    { 11, "In Process of ECD Registration", "Reg-ECD", null, null },
                    { 10, "Close Corporation", "CC", null, null },
                    { 9, "Pty Ltd", "Pty Ltd", null, null },
                    { 8, "Trust Description", "Trust", null, null },
                    { 7, "Sport Description", "Sport", null, null },
                    { 6, "Section 21 Company", "Section 21 Company", null, null },
                    { 5, "Other Description", "Others", null, null },
                    { 4, "Voluntary organization registered as NPO", "NPO/VA", null, null },
                    { 2, "Non Profit Company registered as NPO", "NPO/NPC", null, null },
                    { 1, "Non Profit Organisation", "NPO", null, null },
                    { 12, "In Progress of Older Person Registration", "Reg-Old Person", null, null }
                });

            migrationBuilder.InsertData(
                schema: "dropdown",
                table: "Positions",
                columns: new[] { "Id", "Name", "UpdatedDateTime", "UpdatedUserId" },
                values: new object[,]
                {
                    { 20, "Additional Member", null, null },
                    { 21, "Social Service Clerk", null, null },
                    { 19, "Treasurer", null, null },
                    { 5, "COO", null, null },
                    { 17, "Deputy Chairperson", null, null },
                    { 18, "Secretary", null, null },
                    { 1, "Admin Assistant", null, null },
                    { 2, "Administrative Manager", null, null },
                    { 3, "Board Member", null, null },
                    { 4, "CEO", null, null },
                    { 6, "Director", null, null },
                    { 7, "Finance Officer", null, null },
                    { 8, "Fundraising Officer", null, null },
                    { 9, "Grants Manager", null, null },
                    { 10, "Manager", null, null },
                    { 11, "Operations Director", null, null },
                    { 12, "Supervisor", null, null },
                    { 14, "Principal", null, null },
                    { 13, "Other", null, null }
                });

            migrationBuilder.InsertData(
                schema: "dropdown",
                table: "Positions",
                columns: new[] { "Id", "Name", "UpdatedDateTime", "UpdatedUserId" },
                values: new object[,]
                {
                    { 15, "ECD Learner", null, null },
                    { 16, "Chairperson", null, null }
                });

            migrationBuilder.InsertData(
                schema: "dropdown",
                table: "Programmes",
                columns: new[] { "Id", "DepartmentId", "Name", "SystemName", "UpdatedDateTime", "UpdatedUserId" },
                values: new object[,]
                {
                    { 4, 11, "Maternal,Women and Child Health", "MWCH", null, null },
                    { 6, 11, "Mental Health", "MH", null, null },
                    { 7, 11, "Emergency Centre Presures", "ECP", null, null },
                    { 3, 11, "HIV/AIDS, TB, STI", "HTS", null, null },
                    { 2, 11, "Chronic Diseases and Non-Communicable Diseases", "CNCD", null, null },
                    { 1, 1, "All Programmes", "All", null, null },
                    { 5, 11, "Theatre, Surgery and Aneasthetics", "TSA", null, null }
                });

            migrationBuilder.InsertData(
                schema: "dropdown",
                table: "ProvisionTypes",
                columns: new[] { "Id", "Name", "SystemName", "UpdatedDateTime", "UpdatedUserId" },
                values: new object[,]
                {
                    { 1, "Provided", "Provided", null, null },
                    { 2, "Required", "Required", null, null }
                });

            migrationBuilder.InsertData(
                schema: "dropdown",
                table: "RecipientTypes",
                columns: new[] { "Id", "Name", "SystemName", "UpdatedDateTime", "UpdatedUserId" },
                values: new object[,]
                {
                    { 1, "Primary", "Primary", null, null },
                    { 2, "Sub-Recipient", "SubRecipient", null, null }
                });

            migrationBuilder.InsertData(
                schema: "dropdown",
                table: "ResourceTypes",
                columns: new[] { "Id", "Name", "SystemName", "UpdatedDateTime", "UpdatedUserId" },
                values: new object[,]
                {
                    { 1, "HR", "HR", null, null },
                    { 2, "Other than HR", "Other", null, null }
                });

            migrationBuilder.InsertData(
                schema: "dropdown",
                table: "ServiceTypes",
                columns: new[] { "Id", "Name", "SystemName", "UpdatedDateTime", "UpdatedUserId" },
                values: new object[,]
                {
                    { 2, "Non-Direct Service Delivery", "Non-Direct", null, null },
                    { 1, "Direct Service Delivery", "Direct", null, null }
                });

            migrationBuilder.InsertData(
                schema: "dropdown",
                table: "SubProgrammes",
                columns: new[] { "Id", "Name", "ProgrammeId", "SystemName", "UpdatedDateTime", "UpdatedUserId" },
                values: new object[,]
                {
                    { 11, "Surgery", 5, "Surgery", null, null },
                    { 14, "Emerency Centre Pressures", 7, "ECP", null, null },
                    { 10, "Theatre", 5, "Theatre", null, null },
                    { 9, "Child and Adolescent Helath", 4, "CAH", null, null },
                    { 8, "Women's Health", 4, "WH", null, null },
                    { 7, "Maternal Health", 4, "MH", null, null },
                    { 6, "STI", 3, "STI", null, null },
                    { 5, "TB", 3, "TB", null, null },
                    { 4, "HIV/AIDS", 3, "HIV", null, null },
                    { 3, "NCDs", 2, "NCDs", null, null },
                    { 2, "Chronic Diseases", 2, "CD", null, null },
                    { 1, "All Sub-Programmes", 1, "ALL", null, null },
                    { 12, "Anaethetics", 5, "Anaethetics", null, null },
                    { 13, "Mental Health", 6, "MH", null, null }
                });

            migrationBuilder.InsertData(
                schema: "dropdown",
                table: "Titles",
                columns: new[] { "Id", "Name", "UpdatedDateTime", "UpdatedUserId" },
                values: new object[,]
                {
                    { 4, "Dr", null, null },
                    { 5, "Prof", null, null },
                    { 3, "Miss", null, null },
                    { 2, "Mrs", null, null },
                    { 1, "Mr", null, null }
                });

            migrationBuilder.InsertData(
                schema: "lookup",
                table: "ActivityList",
                columns: new[] { "Id", "Description", "Name", "UpdatedDateTime", "UpdatedUserId" },
                values: new object[,]
                {
                    { 158, "Support RTCQI training to ALL counsellors and nurses", "Support RTCQI training to counsellors and nurses", null, null },
                    { 160, "Support weekly independent QC and 6 monthly proficiency testing", "Support weekly QC and 6 monthly testing", null, null },
                    { 159, "Conduct 6 monthly internal SPI-RT assessments", "Conduct 6 monthly internal SPI-RT assessments", null, null },
                    { 161, "Digitizing and analysing of HTS capturing on current data systems", "Digitizing and analysing of HTS capturing", null, null },
                    { 157, "Support the Provincial Department of Health's roll out of HIV Self Screening and Index Case Testing ", "Support DoH's roll out of HIV Self Screening", null, null },
                    { 152, "Offering targeted HIV testing", "Offering targeted HIV testing", null, null }
                });

            migrationBuilder.InsertData(
                schema: "lookup",
                table: "ActivityList",
                columns: new[] { "Id", "Description", "Name", "UpdatedDateTime", "UpdatedUserId" },
                values: new object[,]
                {
                    { 155, "Conduct HIV and TB screening as part of infacility health screening", "Conduct HIV and TB screening", null, null },
                    { 154, "Targeted HIV testing at ANC, TB,PNC,FP,STI points", "Targeted HIV testing at ANC, TB,PNC,FP,STI points", null, null },
                    { 153, "Provide counsellors", "Provide counsellors", null, null },
                    { 162, "Identify with Province and City skills shortage, M&E gaps for reporting and capturing and assist with temporary workforce relief", "Identify with Province and City skills shortage", null, null },
                    { 156, "Facilitate Index Case Finding of sexual partners and biological children for all HIV positive clients through facility and community", "Facilitate Index Case Finding of sexual partners", null, null },
                    { 163, "Provide and distribute HTS support equipment to enable Counsellors and HTS Testers in testing functions ", "Provide and distribute HTS support equipment", null, null },
                    { 176, "Condom distribution", "Condom distribution", null, null },
                    { 165, "Provide track and tracing for HIV positive clients in District hospitals for in-patients.", "Provide track and tracing for HIV positive clients", null, null },
                    { 166, "Strenghthen ICT support through NIMART nurse involvement", "Strenghthen ICT support", null, null },
                    { 167, "Support Implementation and upscaling  of Run Charts as a Quality assurance and Quality improvement tool for HTS,HTS Pos and ICT", "Support Implementation and upscaling of Run Charts", null, null },
                    { 168, "Violence screening", "Violence screening", null, null },
                    { 169, "Men Workplace Testing HIV Testing ", "Men Workplace Testing HIV Testing ", null, null },
                    { 170, "Finding Youth TVET Testing: In partnership with HEAIDS, Anova will continue testing at TVETs colleges in the Cape Metro. STI and TB screening will also be offered.", "Finding Youth TVET Testing", null, null },
                    { 171, "Targeting Male Dominated Community HIV  Testing", "Targeting Male Dominated Community HIV  Testing", null, null },
                    { 172, "Defaulter Tracking ICT ", "Defaulter Tracking ICT ", null, null },
                    { 173, "Targeted Wellness Outreaches in Partnership with other community NPOs", "Targeted Wellness Outreaches", null, null },
                    { 174, "Following all pregnant women in high burden areas", "Following all pregnant women in high burden areas", null, null },
                    { 175, "BCI - Behaviour Change Interventions", "BCI - Behaviour Change Interventions", null, null },
                    { 151, "Facilitate linkage to care", "Facilitate linkage to care", null, null },
                    { 164, "Provide HTS in ER, triage settings in identified District hospitals.", "Provide HTS in ER, triage settings", null, null },
                    { 150, "Facilitate Weekly Data reviews as supported Siyenza Facilities to identify ART initiation and retention gaps.", "Facilitate Weekly Data reviews", null, null },
                    { 125, "Support rentention in care by imprving VL uptake and monitoring", "Support care rentention - improve VL uptake", null, null },
                    { 148, "Support Facilities with Weekly tracking and Recall of Waiting on ART to improve linkage to care and number of ART initiations.", "Support with tracking & Recall of Waiting on ART", null, null },
                    { 121, "Mobilize individuals with virologic failure using TIER.net and NHLS and PHCD(Viral load for action reports)", "Mobilize individuals with virologic failure", null, null },
                    { 122, "Support Specialised services by providing Advanced clinical care for  v  ( ROTF, pharmacovigilance and other co-morbidities)", "Support by providing Advanced clinical care", null, null },
                    { 123, "Support retention in care through telephonic tracing", "Support care rentention - telephonic tracing", null, null },
                    { 124, "Support rentention in care through trace and track", "Support care rentention - trace and track", null, null },
                    { 177, "Needle and syringe distribution", "Needle and syringe distribution", null, null },
                    { 126, "Support rententions in care through welcome back campaigns", "Support care rentention - welcome back campaigns", null, null },
                    { 127, "Support retention in care through effective used of pharmacy collection data", "Support care retention - pharmacy collection data", null, null },
                    { 128, "Support retention in care by supporting facilities in decanting strategies", "Support care retention - decanting strategies", null, null },
                    { 129, "Support rentention in care by supporting facilities with scripting, planning  and improving adherence clubs", "Support care rentention - scripting, planning, etc", null, null },
                    { 130, "Provide appropriate number of clinicians to facilities to initiate Clients on ART", "Provide appropriate number of clinicians on ART", null, null },
                    { 131, "Provide cross reference between data sytems to track ART initiations", "Provide cross reference to track ART initiations", null, null },
                    { 132, "Build capacity of DoH/CCT staff by supporting NIMART mentoring", "Build capacity of staff with NIMART mentoring", null, null },
                    { 133, "Support DoH/ CCT policy on same day initiations", "Support DoH/ CCT policy on same day initiations", null, null },
                    { 134, "Support TLD transition ", "Support TLD transition ", null, null },
                    { 135, "Provide capacity to sustain medication dispensing to support same day initiation / ART enrolment", "Provide capacity to sustain medication dispensing", null, null },
                    { 136, "Identify ART initiation backlogs per facility trough weekly data evaluation meetings for identification of gaps at facility level through DSD", "Identify ART initiation backlogs", null, null },
                    { 137, "Provide case managers to ensure effective linkage and retention in care.", "Provide case managers", null, null },
                    { 138, "Increase access to care by expanding pharmacy services into quick pick up points", "Increase access to care", null, null },
                    { 139, "Support to people who are at risk of lost to follow up ", "Support people at risk of lost to follow up", null, null }
                });

            migrationBuilder.InsertData(
                schema: "lookup",
                table: "ActivityList",
                columns: new[] { "Id", "Description", "Name", "UpdatedDateTime", "UpdatedUserId" },
                values: new object[,]
                {
                    { 140, "Support the DOH Welcome Back Campaign", "Support the DOH Welcome Back Campaign", null, null },
                    { 141, "Develop IT support for for tracking of ARV clients for reporting to funders", "Develop IT support for tracking of ARV clients", null, null },
                    { 142, "Provide  NIMART trained nurses ", "Provide  NIMART trained nurses ", null, null },
                    { 143, "Provide  Advanced Clinical Care by Medical Officers", "Provide Advanced Clinical Care by Medical Officers", null, null },
                    { 144, "Support facilities to reach HAST program", "Support facilities to reach HAST program", null, null },
                    { 145, "Provide NIMART mentoring support", "Provide NIMART mentoring support", null, null },
                    { 146, "Training on clinical guideline ", "Training on clinical guideline ", null, null },
                    { 147, "Support Facilities in sustained improvement of the HAST core program indicators ( ICT,SDI, TLD, TPT, Decanting) through regular update and review of Facility Improvement Plans", "Support with improvement of the HAST core programs", null, null },
                    { 149, "Improve retention in care at supported Facilitied through daily and weekly tracking of missed appointments and uLTFU", "Improve retention in care at supported Facilities", null, null },
                    { 178, "Opioid Substitution Treatment (OST)", "Opioid Substitution Treatment (OST)", null, null },
                    { 203, "Behaviour Change:Comprehensive Sexuality Education", "Behaviour Change:Comprehensive Sexuality Education", null, null },
                    { 180, "TB screening", "TB screening", null, null },
                    { 212, "Structural: Support to Access Grants", "Structural: Support to Access Grants", null, null },
                    { 213, "Structural: Dignity Packs", "Structural: Dignity Packs", null, null },
                    { 214, "Structural: Academic Support and Career Guidance", "Structural: Academic Support and Career Guidance", null, null },
                    { 215, "Structural: Return to School Support", "Structural: Return to School Support", null, null },
                    { 216, "Structural: ECD Vouchers", "Structural: ECD Vouchers", null, null },
                    { 217, "Structural: GBV Awareness and Self-Defence", "Structural: GBV Awareness and Self-Defence", null, null },
                    { 218, "Structural: Economic Strengthening", "Structural: Economic Strengthening", null, null },
                    { 219, "Trauma containment", "Trauma containment", null, null },
                    { 220, "Risk assessment & referral; ", "Risk assessment & referral; ", null, null },
                    { 221, "Follow-up psychosocial support", "Follow-up psychosocial support", null, null },
                    { 222, "PEP adherence suppor", "PEP adherence suppor", null, null },
                    { 223, "Role out of HIV SS", "Role out of HIV SS", null, null },
                    { 211, "Behaviour Change: Physical activity", "Behaviour Change: Physical activity", null, null },
                    { 224, "Referral for other social support services", "Referral for other social support services", null, null },
                    { 226, "GBV awareness & community outreach", "GBV awareness & community outreach", null, null },
                    { 227, "PrEP Demand Creation and referrals to PrEP Clinics", "PrEP Demand Creation and referrals to PrEP Clinics", null, null },
                    { 228, "Delivery of Chronic Medication", "Delivery of Chronic Medication", null, null },
                    { 229, "COVID response", "COVID response", null, null },
                    { 230, "COVID testing", "COVID testing", null, null },
                    { 231, "COVID vaccination", "COVID vaccination", null, null },
                    { 232, "COVID vaccine demand creation", "COVID vaccine demand creation", null, null },
                    { 233, "COVID tracking and tracing", "COVID tracking and tracing", null, null },
                    { 234, "Establish peer groups for Mental Health", "Establish peer groups for Mental Health", null, null },
                    { 235, "Patient transport support", "Patient transport support", null, null },
                    { 236, "Telehealth support", "Telehealth support", null, null },
                    { 120, "Strengthen viral load monitoring, and capturing  by providing techinal assistance.", "Strengthen viral load monitoring and capturing", null, null },
                    { 225, "Court preparation & support", "Court preparation & support", null, null },
                    { 179, "STI screening", "STI screening", null, null },
                    { 210, "Behaviour Change: Adherence Support (Mental Health Support)", "Behaviour Change: Adherence Support", null, null },
                    { 208, "Behaviour Change: SRH Knowledge and behaviour", "Behaviour Change: SRH Knowledge and behaviour", null, null }
                });

            migrationBuilder.InsertData(
                schema: "lookup",
                table: "ActivityList",
                columns: new[] { "Id", "Description", "Name", "UpdatedDateTime", "UpdatedUserId" },
                values: new object[,]
                {
                    { 181, "Family Planning", "Family Planning", null, null },
                    { 182, "ART", "ART", null, null },
                    { 183, "Pregnancy testing", "Pregnancy testing", null, null },
                    { 184, "non communable disease screening", "non communable disease screening", null, null },
                    { 185, "Referrals to DOH/COCT facilities", "Referrals to DOH/COCT facilities", null, null },
                    { 186, "TB testing", "TB testing", null, null },
                    { 187, "Human Rights violations screening", "Human Rights violations screening", null, null },
                    { 188, "Overdose management / awareness", "Overdose management / awareness", null, null },
                    { 189, "Hepatitis C sceening, diagnosis and treatment ", "Hepatitis C sceening, diagnosis and treatment ", null, null },
                    { 190, "Hepatitis B testing and vaccination", "Hepatitis B testing and vaccination", null, null },
                    { 191, "Sensitisation training", "Sensitisation training", null, null },
                    { 192, "Health: HIV Testing", "Health: HIV Testing", null, null },
                    { 209, "Behaviour Change: GBV Prevention", "Behaviour Change: GBV Prevention", null, null },
                    { 193, "Health: HIV Self Screening", "Health: HIV Self Screening", null, null },
                    { 195, "Health: STI screening and Investigation", "Health: STI screening and Investigation", null, null },
                    { 196, "Health: TB Screening and TB Sputum testing", "Health: TB Screening and TB Sputum testing", null, null },
                    { 197, "Health: Pregnancy Testing", "Health: Pregnancy Testing", null, null },
                    { 198, "Health: SRH", "Health: SRH", null, null },
                    { 199, "Health: ART", "Health: ART", null, null },
                    { 200, "Health: PrEP related lab costs", "Health: PrEP related lab costs", null, null },
                    { 201, "Health: Emergency Contraception", "Health: Emergency Contraception", null, null },
                    { 202, "Behaviour Change: Peer Education", "Behaviour Change: Peer Education", null, null },
                    { 204, "Behaviour Change: Individual Psycho Social Support", "Behaviour Change: Individual Psycho Social Support", null, null },
                    { 205, "Behaviour Change: PrEP Demand Creation", "Behaviour Change: PrEP Demand Creation", null, null },
                    { 206, "Behaviour Change: Teen Parenting/Parenting", "Behaviour Change: Teen Parenting/Parenting", null, null },
                    { 207, "Behaviour Change: Teen & Caregiver Comunication", "Behaviour Change: Teen & Caregiver Comunication", null, null },
                    { 194, "Health: Male/Female Condom and Lube Distribution", "Health: Male/Female Condom and Lube Distribution", null, null },
                    { 119, "Track VL done on ALL new patients tthough implementation and monitoring of the 100 day Case Management at Siyenza Facilities", "Track VL done on ALL new patients", null, null },
                    { 8, "Advocacy", "Advocacy", null, null },
                    { 117, "Support Facilities with Folder Audits to maintain good quality of clinical care and improve VL uptake at Faclity level", "Support Facilities with Folder Audits", null, null },
                    { 32, "Deploy NDOH tools", "Deploy NDOH tools", null, null },
                    { 33, "Deploy NDOH tools and Tier.net module to all identified sites", "Deploy NDOH tools and Tier.net modules", null, null },
                    { 34, "Update PrEP finder on NDOH website to include facilities", "Update PrEP finder on NDOH website", null, null },
                    { 35, "Data quality assessment", "Data quality assessment", null, null },
                    { 36, "Facility-level data review", "Facility-level data review", null, null },
                    { 37, "Conduct  performance management activities", "Conduct  performance management activities", null, null },
                    { 38, "Distribution of MINA collateral, posters an IEC to facilities.", "Distribution of MINA collateral, posters and IEC", null, null },
                    { 39, "Facilitate the branding in facilities", "Facilitate the branding in facilities", null, null },
                    { 40, "Identification of MINA champion /facility in conjunction with facility manager", "Identification of MINA champion", null, null },
                    { 41, "Advocacy for mesn health", "Advocacy for mesn health", null, null },
                    { 42, "HiV prevention", "HiV prevention", null, null },
                    { 43, "HTS", "HTS", null, null }
                });

            migrationBuilder.InsertData(
                schema: "lookup",
                table: "ActivityList",
                columns: new[] { "Id", "Description", "Name", "UpdatedDateTime", "UpdatedUserId" },
                values: new object[,]
                {
                    { 44, "Care", "Care", null, null },
                    { 45, "Treatment/FP Services", "Treatment/FP Services", null, null },
                    { 46, "DREAMS stakeholder engagement", "DREAMS stakeholder engagement", null, null },
                    { 118, "Support Specialised services by providing Advanced clinical care  ( ROTF, pharmacovigilance) ", "Support with providing Advanced clinical care", null, null },
                    { 48, "Support the establishment of facility and sub-district Adolescent and Youth Friendly Services (AYFS)", "Support the establishment of AYFS", null, null },
                    { 49, "Promote provision of integrated HTS/HIV Prevention/FP/SRH services to AGYW at FP units or youth care corners", "Promote provision of integrated services to AGYW", null, null },
                    { 50, "Guideline development", "Guideline development", null, null },
                    { 51, "LIVES Training", "LIVES Training", null, null },
                    { 52, "Avial adolescent clinics and youth corners", "Avial adolescent clinics and youth corners", null, null },
                    { 53, "Mentorship on client engagement", "Mentorship on client engagement", null, null },
                    { 54, "Implement PrEP services", "Implement PrEP services", null, null },
                    { 55, "Welcome back campaign", "Welcome back campaign", null, null },
                    { 56, "Stakeholder enagement", "Stakeholder enagement", null, null },
                    { 31, "SOP development", "SOP development", null, null },
                    { 30, "Develop assessment tools", "Develop assessment tools", null, null },
                    { 29, "Facility and site assessments", "Facility and site assessments", null, null },
                    { 28, "Obtain facility start-up kits from NDOH", "Obtain facility start-up kits from NDOH", null, null },
                    { 1, "Quarterly reports", "Quarterly reports", null, null },
                    { 2, "Quarterly stakeholder engagements", "Quarterly stakeholder engagements", null, null },
                    { 3, "Provision of resources", "Provision of resources", null, null },
                    { 4, "Capacity Development", "Capacity Development", null, null },
                    { 5, "Monitoring and Evaluation", "Monitoring and Evaluation", null, null },
                    { 6, "Quality Improvement", "Quality Improvement", null, null },
                    { 7, "Implementation of Human Rights activities", "Implementation of Human Rights activities", null, null },
                    { 9, "GP referrals", "GP referrals", null, null },
                    { 10, "Engagement with taxi industry", "Engagement with taxi industry", null, null },
                    { 11, "Awareness campaigns", "Awareness campaigns", null, null },
                    { 12, "HIV Testing", "HIV Testing", null, null },
                    { 13, "Health Screening", "Health Screening", null, null },
                    { 57, "Site visits and assesssments", "Site visits and assesssments", null, null },
                    { 14, "Introduction of self-screening", "Introduction of self-screening", null, null },
                    { 16, "Provide Legal Support", "Provide Legal Support", null, null },
                    { 17, "Distribution of posters, leaflets and pamphlets", "Distribution of posters, leaflets and pamphlets", null, null },
                    { 18, "Advocacy for People Who use and inject Drugs (PWID)", "Advocacy for PWID", null, null },
                    { 19, "Decriminalisation of Sex Work ", "Decriminalisation of Sex Work ", null, null },
                    { 20, "Sesitization engagements", "Sesitization engagements", null, null },
                    { 21, "Mapping", "Mapping", null, null },
                    { 22, "Providing CBM toolkits", "Providing CBM toolkits", null, null },
                    { 23, "Distribute IEC material", "Distribute IEC material", null, null },
                    { 24, "Training", "Training", null, null },
                    { 25, "Demand creation", "Demand creation", null, null },
                    { 26, "Score card development and monitoring", "Score card development and monitoring", null, null }
                });

            migrationBuilder.InsertData(
                schema: "lookup",
                table: "ActivityList",
                columns: new[] { "Id", "Description", "Name", "UpdatedDateTime", "UpdatedUserId" },
                values: new object[,]
                {
                    { 27, "Skills development", "Skills development", null, null },
                    { 15, "Reduce Stima & Discrimination", "Reduce Stima & Discrimination", null, null },
                    { 58, "Support policy development", "Support policy development", null, null },
                    { 47, "DREAMS Ambassador development", "DREAMS Ambassador development", null, null },
                    { 60, "IQC of HIV Test kits", "IQC of HIV Test kits", null, null },
                    { 91, "Provide DSD to improve same day initiations", "Provide DSD to improve same day initiations", null, null },
                    { 92, "Integrate Case mangement tool with Facility systems and processes.", "Integrate Case mangement tool", null, null },
                    { 93, "Support PHDC: with Human Resources,Improve Linkage and retention,comprehensive patient Care; Cross Referencing of data and generation of reports.", "Support PHDC", null, null },
                    { 94, "Improvement of Facility level Data-consolidate multiple entries into a unique ID (HPRN)", "Improve data-consolidate multiple entries", null, null },
                    { 95, "Provide ongoing support on coaching and mentoring of DOH / CCT NIMART nurses to scale up same day initiations", "Provide support on coaching and mentoring", null, null },
                    { 96, "Support the re-authorization of NIMART nurses", "Support the re-authorization of NIMART nurses", null, null },
                    { 97, "Support DoH and CCT Mentors to complete NIMART training  for  professional nurses  according to Western Cape guidelines/criteria", "Support Mentors to complete NIMART training", null, null },
                    { 98, "Identify gaps at Facilities as per program operations requirement. Support facilities in reaching set targets(both facility & DSP targets) by linking DSD staff to identified sites.", "Identify gaps per program operations requirement", null, null },
                    { 99, "Build  capacity of facility data/admin staff to support best practices/national /provincial guidelines on patient record keeping/ filing,archiving, registry hygiene", "Build data/admin staff to support best practices", null, null },
                    { 100, "Provide DSD to improve patient  experience and flow through facilities. Increased number of patient medication pick-up points", "Provide DSD to improve patient experience", null, null },
                    { 59, "Ensure that 90 % of pregnant women are started same day    ", "Ensure pregnant women are started same day    ", null, null },
                    { 102, "Strenthgthening appointment system in all Facilities.", "Strenthgthening appointment system", null, null },
                    { 90, "Conduct adherence club audits and initiate QIP based on findings", "Conduct adherence club audits and initiate QIP", null, null },
                    { 103, "Introduce and support pre-retrieval of folders in all Facilities.", "Introduce and support pre-retrieval of folders", null, null },
                    { 105, "Support critical posts within the HAST Directorate", "Support critical posts within the HAST Directorate", null, null },
                    { 106, "Regular and on-going feedback with sub structures and facilities on progress towards targets", "Regular and ongoing feedback with sub structures", null, null },
                    { 107, "Cultivate a culture of accountability towards facilities, colleagues and clients.", "Cultivate a culture of accountability", null, null },
                    { 108, "Individual performance mornitoring and feedback done for all staff ", "Individual performance mornitoring and feedback", null, null },
                    { 109, "Provision of value clubs", "Provision of value clubs", null, null },
                    { 110, "Support registering of value clubs (both facility and community) at supported facilities.", "Support registering of value clubs", null, null },
                    { 111, "Tracing patient adherence through the other DMOC modalities.", "Tracing patient adherence", null, null },
                    { 112, "Working with facility DOH staff to ensure that newly decanted stable patients are added to existing and/or new clubs at supported facilities.", "Ensure newly decanted patients are added to clubs", null, null },
                    { 113, "Generation of  Risk of treatment failure client lists to identify gaps and to guide program on resource deployment.", "Generate Risk of treatment failure client lists", null, null },
                    { 114, "Weekly Tracking and recall of clients  with virologic failure using Facility Information Systems ", "Weekly Tracking and recall of clients", null, null },
                    { 115, "Suport Facilities with  Telephonic tracing and recalls of  for Viral loads(VL) due; missed VLs and  unsuppressed VL's", "Suport with Telephonic tracing and recalls VL", null, null },
                    { 116, "Improve clinical management  by providing on site facility training and mentoring of clinical staff", "Improve clinical management", null, null },
                    { 104, "Provide support to DoH  /CCT on roll out services during extended working hours at identified facilities ", "Provide support to on roll out services", null, null },
                    { 89, "TA support: training and support of DOH staff in facilities. strengtening current data systems and structures in facilities.", "TA support", null, null },
                    { 101, "Support decanting strategy to improve pharmacy waiting times.", "Improve pharmacy waiting times.", null, null },
                    { 87, "Participate in PMTCT forums and PNC Forums ", "Participate in PMTCT forums and PNC Forums ", null, null },
                    { 61, "Rapid test quality improvements", "Rapid test quality improvements", null, null },
                    { 88, "Active participation in all Data Management platforms", "Active participation in Data Management platforms", null, null },
                    { 63, "Quality Assessments", "Quality Assessments", null, null },
                    { 64, "Conduct monthly TB register audits to identify gaps in HIV testing", "Conduct monthly TB register audits", null, null },
                    { 65, "Review presumptive TB register to indentify confirmed Tb + clients not initiated on ART and fasttrack for initiation", "Review presumptive TB register", null, null },
                    { 66, "Analyse IPT Data to improve initiation and completion of IPT", "Analyse IPT Data to improve completion of IPT", null, null },
                    { 67, "Conduct monthly PMTCT register reviews", "Conduct monthly PMTCT register reviews", null, null }
                });

            migrationBuilder.InsertData(
                schema: "lookup",
                table: "ActivityList",
                columns: new[] { "Id", "Description", "Name", "UpdatedDateTime", "UpdatedUserId" },
                values: new object[,]
                {
                    { 68, "Funder prescribed assessments", "Funder prescribed assessments", null, null },
                    { 69, "Conduct routine clinical chart and register reviews to identify gaps in HTS/HIV/TB services", "Conduct routine clinical chart and register review", null, null },
                    { 70, "Develop facility QIPs in conjunction with facility team  according to the gaps identified", "Develop facility QIPs", null, null },
                    { 71, "Monitor implementation of facility QIPs", "Monitor implementation of facility QIPs", null, null },
                    { 72, "Provide coaching  and upskilling in implementation and monitoring of improvement activities (FIP's and QIP's) to facility staff", "Provide coaching and upskilling", null, null },
                    { 73, "Support the implementation of TB screening for all ART clients at every visit and actioning for TPT or TB testing in supported facilities", "Support the implementation of TB screening", null, null },
                    { 62, "Support and Conduct 6 monthly SPI -RT assessments in all facilities", "Conduct 6 monthly SPI -RT assessments", null, null },
                    { 75, "Monthly review of Presumptive  register to ensure all Presumptive clients have an HIV and or ART status, clients not initiated on ART and fast track  for initiation.", "Monthly review of Presumptive register", null, null },
                    { 74, "Monthly reviews of facility TB screening practices among ART clients flagging for low TPT uptake and <90% screening of all visiting ART clients", "Monthly reviews of TB screening practices", null, null },
                    { 86, "Coaching on correct completion of registers", "Coaching on correct completion of registers", null, null },
                    { 84, "Provide oversight support on Post Natal Clubs(coaching of PNC Nurses)", "Provide support on Post Natal Clubs", null, null },
                    { 83, "Support with the roll out and implementation of Post Natal Clubs", "Support with implementation of Post Natal Clubs", null, null },
                    { 82, "Monthly review of specimen rejection rates for   CD4/VL/PCR/TB GenxPert and implement corrective measures    on rejections caused by pre-analytical errors.", "Monthly review of specimen rejection rates", null, null },
                    { 81, "Strengthening of results management", "Strengthening of results management", null, null },
                    { 85, "Conduct PMTCT register review to monitor", "Conduct PMTCT register review to monitor", null, null },
                    { 79, "Monthly review of facility missed opportunities to initiate TPT in TX_NEW 3 months prior and flag for reassessment of TPT eligibility and TPT initiation", "Monthly review of facility missed opportunities", null, null },
                    { 78, "Monthly review of facility TPT to ART initiation rates to ensure above 85%", "Monthly review of facility TPT to ART", null, null },
                    { 77, "Assist with training of staff  on TPT guidelines and management of TPT in ART clients", "Assist with training of staff on TPT", null, null },
                    { 76, "Assist with training staff on HTS and ART for Presumptive TB", "Assist with training staff on HTS", null, null },
                    { 80, "Monthly review of facility TPT outcomes of clients initiated 12 months prior flagging all patients with outstanding TPT outcomes, ensure outcomes are completed.", "Monthly review of facility TPT outcomes", null, null }
                });

            migrationBuilder.InsertData(
                schema: "lookup",
                table: "ResourceList",
                columns: new[] { "Id", "Description", "Name", "ResourceTypeId", "UpdatedDateTime", "UpdatedUserId" },
                values: new object[,]
                {
                    { 23, null, "Community Health Worker", 1, null, null },
                    { 14, null, "Support Officer", 1, null, null },
                    { 22, null, "Senior Mentor", 1, null, null },
                    { 21, null, "Site Administrator", 1, null, null },
                    { 20, null, "Mentor Supervisor", 1, null, null },
                    { 19, null, "Mentor", 1, null, null },
                    { 18, null, "Youth Care Worker", 1, null, null },
                    { 17, null, "Finance Manager", 1, null, null },
                    { 16, null, "HR Manager", 1, null, null },
                    { 15, null, "Field Worker", 1, null, null },
                    { 13, null, "Programme Manager", 1, null, null },
                    { 6, null, "Nursing Assistant", 1, null, null },
                    { 11, null, "Coordinator", 1, null, null },
                    { 10, null, "Councillor", 1, null, null },
                    { 9, null, "Facilitator", 1, null, null },
                    { 8, null, "Research", 1, null, null },
                    { 7, null, "Medical Doctor", 1, null, null },
                    { 5, null, "Register Nurse", 1, null, null },
                    { 4, null, "Staff Nurse", 1, null, null },
                    { 3, null, "Professional Nurse", 1, null, null },
                    { 2, null, "Project Coordinator", 1, null, null },
                    { 1, null, "Project Manager", 1, null, null }
                });

            migrationBuilder.InsertData(
                schema: "lookup",
                table: "ResourceList",
                columns: new[] { "Id", "Description", "Name", "ResourceTypeId", "UpdatedDateTime", "UpdatedUserId" },
                values: new object[] { 24, null, "Pharmacy Manager", 1, null, null });

            migrationBuilder.InsertData(
                schema: "lookup",
                table: "ResourceList",
                columns: new[] { "Id", "Description", "Name", "ResourceTypeId", "UpdatedDateTime", "UpdatedUserId" },
                values: new object[] { 12, null, "Social Mobilizer", 1, null, null });

            migrationBuilder.InsertData(
                schema: "lookup",
                table: "ResourceList",
                columns: new[] { "Id", "Description", "Name", "ResourceTypeId", "UpdatedDateTime", "UpdatedUserId" },
                values: new object[] { 25, null, "Area Manager", 1, null, null });

            migrationBuilder.InsertData(
                schema: "dropdown",
                table: "FacilitySubDistricts",
                columns: new[] { "Id", "FacilityDistrictId", "Name", "UpdatedDateTime", "UpdatedUserId" },
                values: new object[,]
                {
                    { 32, 6, "Prince Albert Local Municipality", null, null },
                    { 1, 1, "Breede Valley Local Municipality", null, null },
                    { 2, 1, "Stellenbosch Local Municipality", null, null },
                    { 3, 1, "Drakenstein Local Municipality", null, null },
                    { 4, 1, "Witzenberg Local Municipality", null, null },
                    { 5, 1, "Langeberg Local Municipality", null, null },
                    { 6, 2, "Khayelitsha Health sub-District", null, null },
                    { 7, 2, "Cape Town Eastern Health sub-District", null, null },
                    { 8, 2, "Cape Town Southern Health sub-District", null, null },
                    { 9, 2, "Cape Town Northern Health sub-District", null, null },
                    { 10, 2, "Klipfontein Health sub-District", null, null },
                    { 11, 2, "Cape Town Western Health sub-District", null, null },
                    { 12, 2, "Tygerberg Health sub-District", null, null },
                    { 13, 2, "Mitchells Plain Health sub-District", null, null },
                    { 31, 6, "Laingsburg Local Municipality", null, null },
                    { 15, 3, "Saldanha Bay Local Municipality", null, null },
                    { 14, 3, "Matzikama Local Municipality", null, null },
                    { 17, 3, "Bergrivier Local Municipality", null, null },
                    { 30, 6, "Beaufort West Local Municipality", null, null },
                    { 29, 5, "Oudtshoorn Local Municipality", null, null },
                    { 28, 5, "Kannaland Local Municipality", null, null },
                    { 27, 5, "Hessequa Local Municipality", null, null },
                    { 16, 3, "Cederberg Local Municipality", null, null },
                    { 25, 5, "Knysna Local Municipality", null, null },
                    { 26, 5, "George Local Municipality", null, null },
                    { 23, 5, "Bitou Local Municipality", null, null },
                    { 22, 4, "Swellendam Local Municipality", null, null },
                    { 21, 4, "Cape Agulhas Local Municipality", null, null },
                    { 20, 4, "Theewaterskloof Local Municipality", null, null },
                    { 19, 4, "Overstrand Local Municipality", null, null },
                    { 18, 3, "Swartland Local Municipality", null, null },
                    { 24, 5, "Mossel Bay Local Municipality", null, null }
                });

            migrationBuilder.InsertData(
                schema: "mapping",
                table: "Roles_Permissions",
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { 42, 1 },
                    { 41, 1 },
                    { 40, 1 },
                    { 38, 1 },
                    { 39, 1 },
                    { 36, 1 },
                    { 18, 1 },
                    { 17, 1 },
                    { 16, 1 },
                    { 15, 1 }
                });

            migrationBuilder.InsertData(
                schema: "mapping",
                table: "Roles_Permissions",
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { 14, 1 },
                    { 13, 1 },
                    { 12, 1 },
                    { 11, 1 },
                    { 10, 1 },
                    { 9, 1 },
                    { 8, 1 },
                    { 7, 1 },
                    { 6, 1 },
                    { 5, 1 },
                    { 4, 1 },
                    { 3, 1 },
                    { 2, 1 },
                    { 19, 1 },
                    { 37, 1 },
                    { 20, 1 },
                    { 22, 1 },
                    { 35, 1 },
                    { 34, 1 },
                    { 33, 1 },
                    { 32, 1 },
                    { 21, 1 },
                    { 30, 1 },
                    { 31, 1 },
                    { 28, 1 },
                    { 27, 1 },
                    { 26, 1 },
                    { 25, 1 },
                    { 24, 1 },
                    { 23, 1 },
                    { 29, 1 },
                    { 1, 1 }
                });

            migrationBuilder.InsertData(
                schema: "mapping",
                table: "Users_Departments",
                columns: new[] { "Id", "DepartmentId", "UserId" },
                values: new object[,]
                {
                    { 2, 1, 2 },
                    { 1, 1, 1 }
                });

            migrationBuilder.InsertData(
                schema: "mapping",
                table: "Users_Roles",
                columns: new[] { "Id", "RoleId", "UserId" },
                values: new object[,]
                {
                    { 2, 1, 2 },
                    { 1, 1, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activities_ActivityListId",
                schema: "dbo",
                table: "Activities",
                column: "ActivityListId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_ActivityTypeId",
                schema: "dbo",
                table: "Activities",
                column: "ActivityTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_FacilityListId",
                schema: "dbo",
                table: "Activities",
                column: "FacilityListId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_ObjectiveId",
                schema: "dbo",
                table: "Activities",
                column: "ObjectiveId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_SubProgrammes_ActivityId",
                schema: "mapping",
                table: "Activities_SubProgrammes",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_SubProgrammes_SubProgrammeId",
                schema: "mapping",
                table: "Activities_SubProgrammes",
                column: "SubProgrammeId");

            migrationBuilder.CreateIndex(
                name: "IX_AddressInformation_NpoProfileId",
                schema: "dbo",
                table: "AddressInformation",
                column: "NpoProfileId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationApprovals_CreatedUserId",
                schema: "dbo",
                table: "ApplicationApprovals",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationAudits_CreatedUserId",
                schema: "dbo",
                table: "ApplicationAudits",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationAudits_StatusId",
                schema: "dbo",
                table: "ApplicationAudits",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationComments_CreatedUserId",
                schema: "dbo",
                table: "ApplicationComments",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationPeriods_ApplicationTypeId",
                schema: "dbo",
                table: "ApplicationPeriods",
                column: "ApplicationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationPeriods_DepartmentId",
                schema: "dbo",
                table: "ApplicationPeriods",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationPeriods_FinancialYearId",
                schema: "dbo",
                table: "ApplicationPeriods",
                column: "FinancialYearId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationPeriods_ProgrammeId",
                schema: "dbo",
                table: "ApplicationPeriods",
                column: "ProgrammeId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationPeriods_SubProgrammeId",
                schema: "dbo",
                table: "ApplicationPeriods",
                column: "SubProgrammeId");

            migrationBuilder.CreateIndex(
                name: "IX_Applications_ApplicationPeriodId",
                schema: "dbo",
                table: "Applications",
                column: "ApplicationPeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_Applications_NpoId",
                schema: "dbo",
                table: "Applications",
                column: "NpoId");

            migrationBuilder.CreateIndex(
                name: "IX_Applications_StatusId",
                schema: "dbo",
                table: "Applications",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactInformation_NpoId",
                schema: "dbo",
                table: "ContactInformation",
                column: "NpoId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactInformation_PositionId",
                schema: "dbo",
                table: "ContactInformation",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactInformation_TitleId",
                schema: "dbo",
                table: "ContactInformation",
                column: "TitleId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentStores_DocumentTypeId",
                schema: "core",
                table: "DocumentStores",
                column: "DocumentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmailQueues_EmailTemplateId",
                schema: "core",
                table: "EmailQueues",
                column: "EmailTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_EmailTemplates_EmailAccountId",
                schema: "core",
                table: "EmailTemplates",
                column: "EmailAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_FacilityList_FacilityClassId",
                schema: "lookup",
                table: "FacilityList",
                column: "FacilityClassId");

            migrationBuilder.CreateIndex(
                name: "IX_FacilityList_FacilitySubDistrictId",
                schema: "lookup",
                table: "FacilityList",
                column: "FacilitySubDistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_FacilityList_FacilityTypeId",
                schema: "lookup",
                table: "FacilityList",
                column: "FacilityTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_FacilitySubDistricts_FacilityDistrictId",
                schema: "dropdown",
                table: "FacilitySubDistricts",
                column: "FacilityDistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_NpoProfiles_NpoId",
                schema: "dbo",
                table: "NpoProfiles",
                column: "NpoId");

            migrationBuilder.CreateIndex(
                name: "IX_NpoProfiles_FacilityLists_FacilityListId",
                schema: "mapping",
                table: "NpoProfiles_FacilityLists",
                column: "FacilityListId");

            migrationBuilder.CreateIndex(
                name: "IX_NpoProfiles_FacilityLists_NpoProfileId",
                schema: "mapping",
                table: "NpoProfiles_FacilityLists",
                column: "NpoProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Npos_ApprovalStatusId",
                schema: "dbo",
                table: "Npos",
                column: "ApprovalStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Npos_ApprovalUserId",
                schema: "dbo",
                table: "Npos",
                column: "ApprovalUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Npos_CreatedUserId",
                schema: "dbo",
                table: "Npos",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Npos_OrganisationTypeId",
                schema: "dbo",
                table: "Npos",
                column: "OrganisationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Objectives_RecipientTypeId",
                schema: "dbo",
                table: "Objectives",
                column: "RecipientTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Objectives_Programmes_ProgrammeId",
                schema: "mapping",
                table: "Objectives_Programmes",
                column: "ProgrammeId");

            migrationBuilder.CreateIndex(
                name: "IX_Objectives_Programmes_SubProgrammeId",
                schema: "mapping",
                table: "Objectives_Programmes",
                column: "SubProgrammeId");

            migrationBuilder.CreateIndex(
                name: "IX_Resources_ActivityId",
                schema: "dbo",
                table: "Resources",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_Resources_AllocationTypeId",
                schema: "dbo",
                table: "Resources",
                column: "AllocationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Resources_ProvisionTypeId",
                schema: "dbo",
                table: "Resources",
                column: "ProvisionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Resources_ResourceListId",
                schema: "dbo",
                table: "Resources",
                column: "ResourceListId");

            migrationBuilder.CreateIndex(
                name: "IX_Resources_ResourceTypeId",
                schema: "dbo",
                table: "Resources",
                column: "ResourceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Resources_ServiceTypeId",
                schema: "dbo",
                table: "Resources",
                column: "ServiceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_Permissions_PermissionId",
                schema: "mapping",
                table: "Roles_Permissions",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_SustainabilityPlans_ActivityId",
                schema: "dbo",
                table: "SustainabilityPlans",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Departments_DepartmentId",
                schema: "mapping",
                table: "Users_Departments",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Departments_UserId",
                schema: "mapping",
                table: "Users_Departments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Npos_AccessStatusId",
                schema: "mapping",
                table: "Users_Npos",
                column: "AccessStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Npos_CreatedUserId",
                schema: "mapping",
                table: "Users_Npos",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Npos_NpoId",
                schema: "mapping",
                table: "Users_Npos",
                column: "NpoId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Npos_UpdatedUserId",
                schema: "mapping",
                table: "Users_Npos",
                column: "UpdatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Npos_UserId",
                schema: "mapping",
                table: "Users_Npos",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Roles_RoleId",
                schema: "mapping",
                table: "Users_Roles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Roles_UserId",
                schema: "mapping",
                table: "Users_Roles",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Activities_SubProgrammes",
                schema: "mapping");

            migrationBuilder.DropTable(
                name: "AddressInformation",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ApplicationApprovals",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ApplicationAudits",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ApplicationComments",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Applications",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ContactInformation",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "DocumentStores",
                schema: "core");

            migrationBuilder.DropTable(
                name: "EmailQueues",
                schema: "core");

            migrationBuilder.DropTable(
                name: "EntityTypes",
                schema: "core");

            migrationBuilder.DropTable(
                name: "NpoProfiles_FacilityLists",
                schema: "mapping");

            migrationBuilder.DropTable(
                name: "Objectives_Programmes",
                schema: "mapping");

            migrationBuilder.DropTable(
                name: "Resources",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Roles_Permissions",
                schema: "mapping");

            migrationBuilder.DropTable(
                name: "SustainabilityPlans",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Users_Departments",
                schema: "mapping");

            migrationBuilder.DropTable(
                name: "Users_Npos",
                schema: "mapping");

            migrationBuilder.DropTable(
                name: "Users_Roles",
                schema: "mapping");

            migrationBuilder.DropTable(
                name: "ApplicationPeriods",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Statuses",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Positions",
                schema: "dropdown");

            migrationBuilder.DropTable(
                name: "Titles",
                schema: "dropdown");

            migrationBuilder.DropTable(
                name: "DocumentTypes",
                schema: "core");

            migrationBuilder.DropTable(
                name: "EmailTemplates",
                schema: "core");

            migrationBuilder.DropTable(
                name: "NpoProfiles",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AllocationTypes",
                schema: "dropdown");

            migrationBuilder.DropTable(
                name: "ProvisionTypes",
                schema: "dropdown");

            migrationBuilder.DropTable(
                name: "ResourceList",
                schema: "lookup");

            migrationBuilder.DropTable(
                name: "ResourceTypes",
                schema: "dropdown");

            migrationBuilder.DropTable(
                name: "ServiceTypes",
                schema: "dropdown");

            migrationBuilder.DropTable(
                name: "Permissions",
                schema: "core");

            migrationBuilder.DropTable(
                name: "Activities",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Roles",
                schema: "core");

            migrationBuilder.DropTable(
                name: "ApplicationTypes",
                schema: "dropdown");

            migrationBuilder.DropTable(
                name: "Departments",
                schema: "core");

            migrationBuilder.DropTable(
                name: "FinancialYears",
                schema: "core");

            migrationBuilder.DropTable(
                name: "Programmes",
                schema: "dropdown");

            migrationBuilder.DropTable(
                name: "SubProgrammes",
                schema: "dropdown");

            migrationBuilder.DropTable(
                name: "EmailAccounts",
                schema: "core");

            migrationBuilder.DropTable(
                name: "Npos",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ActivityList",
                schema: "lookup");

            migrationBuilder.DropTable(
                name: "ActivityTypes",
                schema: "dropdown");

            migrationBuilder.DropTable(
                name: "FacilityList",
                schema: "lookup");

            migrationBuilder.DropTable(
                name: "Objectives",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AccessStatuses",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "OrganisationTypes",
                schema: "dropdown");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "core");

            migrationBuilder.DropTable(
                name: "FacilityClasses",
                schema: "dropdown");

            //migrationBuilder.DropTable(
            //   name: "FundingTemplateTypes",
            //   schema: "dropdown");

            migrationBuilder.DropTable(
                name: "FacilitySubDistricts",
                schema: "dropdown");

            migrationBuilder.DropTable(
                name: "FacilityTypes",
                schema: "dropdown");

            migrationBuilder.DropTable(
                name: "RecipientTypes",
                schema: "dropdown");

            migrationBuilder.DropTable(
                name: "FacilityDistricts",
                schema: "dropdown");
        }
    }
}
