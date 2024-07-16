using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NPOMS.Repository.Migrations
{
    /// <inheritdoc />
    public partial class addnewcheckpoint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
        //    migrationBuilder.EnsureSchema(
        //        name: "dbo");

        //    migrationBuilder.EnsureSchema(
        //        name: "dropdown");

        //    migrationBuilder.EnsureSchema(
        //        name: "mapping");

        //    migrationBuilder.EnsureSchema(
        //        name: "lookup");

        //    migrationBuilder.EnsureSchema(
        //        name: "fa");

        //    migrationBuilder.EnsureSchema(
        //        name: "budget");

        //    migrationBuilder.EnsureSchema(
        //        name: "eval");

        //    migrationBuilder.EnsureSchema(
        //        name: "core");

        //    migrationBuilder.EnsureSchema(
        //        name: "indicator");

        //    migrationBuilder.CreateTable(
        //        name: "AccessStatuses",
        //        schema: "dbo",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
        //            SystemName = table.Column<string>(type: "nvarchar(255)", nullable: false),
        //            IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
        //            CreatedUserId = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1"),
        //            CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
        //            UpdatedUserId = table.Column<int>(type: "int", nullable: true),
        //            UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_AccessStatuses", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "AccountTypes",
        //        schema: "dropdown",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
        //            SystemName = table.Column<string>(type: "nvarchar(1000)", nullable: true),
        //            IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
        //            CreatedUserId = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1"),
        //            CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
        //            UpdatedUserId = table.Column<int>(type: "int", nullable: true),
        //            UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_AccountTypes", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "ActivityList",
        //        schema: "lookup",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
        //            Description = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
        //            IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
        //            CreatedUserId = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1"),
        //            CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
        //            UpdatedUserId = table.Column<int>(type: "int", nullable: true),
        //            UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_ActivityList", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "ActivityTypes",
        //        schema: "dropdown",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
        //            SystemName = table.Column<string>(type: "nvarchar(255)", nullable: false),
        //            IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
        //            CreatedUserId = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1"),
        //            CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
        //            UpdatedUserId = table.Column<int>(type: "int", nullable: true),
        //            UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_ActivityTypes", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "AffiliatedOrganisationInformation",
        //        schema: "dbo",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            npoProfileId = table.Column<int>(type: "int", nullable: true),
        //            NameOfOrganisation = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            ContactPerson = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            TelephoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            Website = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            CreatedUserId = table.Column<int>(type: "int", nullable: false),
        //            CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
        //            UpdatedUserId = table.Column<int>(type: "int", nullable: true),
        //            UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_AffiliatedOrganisationInformation", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "AllocationTypes",
        //        schema: "dropdown",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
        //            SystemName = table.Column<string>(type: "nvarchar(255)", nullable: false),
        //            IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
        //            CreatedUserId = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1"),
        //            CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
        //            UpdatedUserId = table.Column<int>(type: "int", nullable: true),
        //            UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_AllocationTypes", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "ApplicationTypes",
        //        schema: "dropdown",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
        //            SystemName = table.Column<string>(type: "nvarchar(255)", nullable: false),
        //            IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
        //            CreatedUserId = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1"),
        //            CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
        //            UpdatedUserId = table.Column<int>(type: "int", nullable: true),
        //            UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_ApplicationTypes", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "AuditLogs",
        //        schema: "dbo",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            TableName = table.Column<string>(type: "nvarchar(255)", nullable: true),
        //            TablePrimaryKey = table.Column<int>(type: "int", nullable: false),
        //            AuditType = table.Column<string>(type: "nvarchar(255)", nullable: true),
        //            AffectedColumns = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
        //            OldValue = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
        //            NewValue = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
        //            CreatedUserId = table.Column<int>(type: "int", nullable: false),
        //            CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_AuditLogs", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "AuditorOrAffiliations",
        //        schema: "dbo",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            EntityId = table.Column<int>(type: "int", nullable: false),
        //            EntityName = table.Column<string>(type: "nvarchar(50)", nullable: true),
        //            EntityType = table.Column<string>(type: "nvarchar(50)", nullable: false),
        //            OrganisationName = table.Column<string>(type: "nvarchar(1000)", nullable: true),
        //            RegistrationNumber = table.Column<string>(type: "nvarchar(255)", nullable: true),
        //            Address = table.Column<string>(type: "nvarchar(1000)", nullable: true),
        //            ContactPerson = table.Column<string>(type: "nvarchar(255)", nullable: true),
        //            EmailAddress = table.Column<string>(type: "nvarchar(255)", nullable: true),
        //            TelephoneNumber = table.Column<string>(type: "nvarchar(10)", nullable: true),
        //            Website = table.Column<string>(type: "nvarchar(255)", nullable: true),
        //            IsActive = table.Column<bool>(type: "bit", nullable: false),
        //            CreatedUserId = table.Column<int>(type: "int", nullable: false),
        //            CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
        //            UpdatedUserId = table.Column<int>(type: "int", nullable: true),
        //            UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_AuditorOrAffiliations", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "BankDetails",
        //        schema: "dbo",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            NpoProfileId = table.Column<int>(type: "int", nullable: false),
        //            BankId = table.Column<int>(type: "int", nullable: false),
        //            BranchId = table.Column<int>(type: "int", nullable: false),
        //            AccountTypeId = table.Column<int>(type: "int", nullable: false),
        //            AccountNumber = table.Column<string>(type: "nvarchar(255)", nullable: true),
        //            IsActive = table.Column<bool>(type: "bit", nullable: false),
        //            CreatedUserId = table.Column<int>(type: "int", nullable: false),
        //            CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
        //            UpdatedUserId = table.Column<int>(type: "int", nullable: true),
        //            UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_BankDetails", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "Banks",
        //        schema: "dropdown",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
        //            Code = table.Column<string>(type: "nvarchar(255)", nullable: true),
        //            IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
        //            CreatedUserId = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1"),
        //            CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
        //            UpdatedUserId = table.Column<int>(type: "int", nullable: true),
        //            UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Banks", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "Branches",
        //        schema: "dropdown",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
        //            BranchCode = table.Column<string>(type: "nvarchar(255)", nullable: true),
        //            BankId = table.Column<int>(type: "int", nullable: false),
        //            IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
        //            CreatedUserId = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1"),
        //            CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
        //            UpdatedUserId = table.Column<int>(type: "int", nullable: true),
        //            UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Branches", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "CompliantCycleRules",
        //        schema: "dbo",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            CycleNumber = table.Column<int>(type: "int", nullable: false),
        //            IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
        //            CreatedUserId = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1"),
        //            CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
        //            UpdatedUserId = table.Column<int>(type: "int", nullable: true),
        //            UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_CompliantCycleRules", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "CompliantCycles",
        //        schema: "dbo",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            CompliantCycleRuleId = table.Column<int>(type: "int", nullable: false),
        //            DepartmentId = table.Column<int>(type: "int", nullable: false),
        //            FinancialYearId = table.Column<int>(type: "int", nullable: false),
        //            StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
        //            EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
        //            HasSignedTPA = table.Column<bool>(type: "bit", nullable: false),
        //            HasProgressReport = table.Column<bool>(type: "bit", nullable: false),
        //            HasFinancialStatement = table.Column<bool>(type: "bit", nullable: false),
        //            IsActive = table.Column<bool>(type: "bit", nullable: false),
        //            CreatedUserId = table.Column<int>(type: "int", nullable: false),
        //            CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
        //            UpdatedUserId = table.Column<int>(type: "int", nullable: true),
        //            UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_CompliantCycles", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "DepartmentBudgets",
        //        schema: "budget",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            DepartmentId = table.Column<int>(type: "int", nullable: false),
        //            FinancialYearId = table.Column<int>(type: "int", nullable: false),
        //            Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
        //            IsActive = table.Column<bool>(type: "bit", nullable: false),
        //            CreatedUserId = table.Column<int>(type: "int", nullable: false),
        //            CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
        //            UpdatedUserId = table.Column<int>(type: "int", nullable: true),
        //            UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_DepartmentBudgets", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "Departments",
        //        schema: "core",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
        //            Abbreviation = table.Column<string>(type: "nvarchar(50)", nullable: false),
        //            DenodoDepartmentName = table.Column<string>(type: "nvarchar(255)", nullable: false, defaultValue: "Not Applicable"),
        //            IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
        //            CreatedUserId = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1"),
        //            CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
        //            UpdatedUserId = table.Column<int>(type: "int", nullable: true),
        //            UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Departments", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "DirectorateBudgets",
        //        schema: "budget",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            DepartmentId = table.Column<int>(type: "int", nullable: false),
        //            FinancialYearId = table.Column<int>(type: "int", nullable: false),
        //            DepartmentBudgetId = table.Column<int>(type: "int", nullable: false),
        //            DirectorateId = table.Column<int>(type: "int", nullable: false),
        //            Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
        //            Description = table.Column<string>(type: "nvarchar(2000)", nullable: true),
        //            IsActive = table.Column<bool>(type: "bit", nullable: false),
        //            CreatedUserId = table.Column<int>(type: "int", nullable: false),
        //            CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
        //            UpdatedUserId = table.Column<int>(type: "int", nullable: true),
        //            UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_DirectorateBudgets", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "Directorates",
        //        schema: "dropdown",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
        //            Description = table.Column<string>(type: "nvarchar(1000)", nullable: true),
        //            IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
        //            CreatedUserId = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1"),
        //            CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
        //            UpdatedUserId = table.Column<int>(type: "int", nullable: true),
        //            UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Directorates", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "DistrictCouncils",
        //        schema: "dropdown",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
        //            IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
        //            CreatedUserId = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1"),
        //            CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
        //            UpdatedUserId = table.Column<int>(type: "int", nullable: true),
        //            UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_DistrictCouncils", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "DocumentTypes",
        //        schema: "core",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
        //            Description = table.Column<string>(type: "nvarchar(1000)", nullable: true),
        //            IsCompulsory = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
        //            IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
        //            Location = table.Column<string>(type: "nvarchar(255)", nullable: false),
        //            CreatedUserId = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1"),
        //            CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
        //            UpdatedUserId = table.Column<int>(type: "int", nullable: true),
        //            UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_DocumentTypes", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "EmailAccounts",
        //        schema: "core",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            Description = table.Column<string>(type: "nvarchar(2000)", nullable: true),
        //            FromDisplayName = table.Column<string>(type: "nvarchar(255)", nullable: false),
        //            FromEmail = table.Column<string>(type: "nvarchar(255)", nullable: false),
        //            Host = table.Column<string>(type: "nvarchar(255)", nullable: false),
        //            Port = table.Column<int>(type: "int", nullable: false),
        //            UserName = table.Column<string>(type: "nvarchar(255)", nullable: true),
        //            Password = table.Column<string>(type: "nvarchar(255)", nullable: true),
        //            EnableSSL = table.Column<bool>(type: "bit", nullable: false),
        //            CreatedUserId = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1"),
        //            CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
        //            UpdatedUserId = table.Column<int>(type: "int", nullable: true),
        //            UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_EmailAccounts", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "EmbeddedReports",
        //        schema: "core",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            Name = table.Column<string>(type: "varchar(255)", nullable: false),
        //            Description = table.Column<string>(type: "varchar(2000)", nullable: true),
        //            ReportId = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            WorkspaceId = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            CategoryName = table.Column<string>(type: "varchar(255)", nullable: true),
        //            IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
        //            CreatedUserId = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1"),
        //            CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
        //            UpdatedUserId = table.Column<int>(type: "int", nullable: true),
        //            UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_EmbeddedReports", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "EntityTypes",
        //        schema: "core",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
        //            SystemName = table.Column<string>(type: "nvarchar(255)", nullable: false),
        //            CreatedUserId = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1"),
        //            CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
        //            UpdatedUserId = table.Column<int>(type: "int", nullable: true),
        //            UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_EntityTypes", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "FacilityClasses",
        //        schema: "dropdown",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
        //            IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
        //            CreatedUserId = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1"),
        //            CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
        //            UpdatedUserId = table.Column<int>(type: "int", nullable: true),
        //            UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_FacilityClasses", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "FacilityDistricts",
        //        schema: "dropdown",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
        //            IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
        //            CreatedUserId = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1"),
        //            CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
        //            UpdatedUserId = table.Column<int>(type: "int", nullable: true),
        //            UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_FacilityDistricts", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "FacilityTypes",
        //        schema: "dropdown",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
        //            IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
        //            CreatedUserId = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1"),
        //            CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
        //            UpdatedUserId = table.Column<int>(type: "int", nullable: true),
        //            UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_FacilityTypes", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "FinancialYears",
        //        schema: "core",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
        //            Year = table.Column<int>(type: "int", nullable: false),
        //            StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
        //            EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
        //            IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
        //            CreatedUserId = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1"),
        //            CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
        //            UpdatedUserId = table.Column<int>(type: "int", nullable: true),
        //            UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_FinancialYears", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "Frequencies",
        //        schema: "dropdown",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
        //            SystemName = table.Column<string>(type: "nvarchar(255)", nullable: false),
        //            IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
        //            CreatedUserId = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1"),
        //            CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
        //            UpdatedUserId = table.Column<int>(type: "int", nullable: true),
        //            UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Frequencies", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "FrequencyPeriods",
        //        schema: "dropdown",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            FrequencyId = table.Column<int>(type: "int", nullable: false),
        //            Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
        //            SystemName = table.Column<string>(type: "nvarchar(255)", nullable: false),
        //            IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
        //            CreatedUserId = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1"),
        //            CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
        //            UpdatedUserId = table.Column<int>(type: "int", nullable: true),
        //            UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_FrequencyPeriods", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "FundAppDocuments",
        //        schema: "fa",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            ID = table.Column<int>(type: "int", nullable: false),
        //            npoProfileId = table.Column<int>(type: "int", nullable: true),
        //            FundingApplicationDetailId = table.Column<int>(type: "int", nullable: true),
        //            Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            DocumentType = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            CreatedBy = table.Column<int>(type: "int", nullable: true),
        //            DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
        //            IsActive = table.Column<bool>(type: "bit", nullable: true),
        //            FileSize = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            Description = table.Column<string>(type: "nvarchar(1000)", nullable: true),
        //            IsCompulsory = table.Column<bool>(type: "bit", nullable: true),
        //            Location = table.Column<string>(type: "nvarchar(255)", nullable: false),
        //            CreatedUserId = table.Column<int>(type: "int", nullable: true),
        //            CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
        //            UpdatedUserId = table.Column<int>(type: "int", nullable: true),
        //            UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_FundAppDocuments", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "FundingTemplateTypes",
        //        schema: "dropdown",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
        //            SystemName = table.Column<string>(type: "nvarchar(255)", nullable: true),
        //            IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
        //            CreatedUserId = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1"),
        //            CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
        //            UpdatedUserId = table.Column<int>(type: "int", nullable: true),
        //            UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_FundingTemplateTypes", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "Gender",
        //        schema: "dropdown",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
        //            IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
        //            CreatedUserId = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1"),
        //            CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
        //            UpdatedUserId = table.Column<int>(type: "int", nullable: true),
        //            UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Gender", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "ImportBudgets",
        //        schema: "budget",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            FinancialYearId = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            DepartmentId = table.Column<int>(type: "int", nullable: false),
        //            DepartmentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            ProgrammeId = table.Column<int>(type: "int", nullable: false),
        //            ProgrammeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            SubProgrammeId = table.Column<int>(type: "int", nullable: false),
        //            SubProgrammeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            SubProgrammeTypeId = table.Column<int>(type: "int", nullable: false),
        //            SubProgrammeTypeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            OriginalBudgetAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
        //            AdjustedBudgetAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
        //            ResponsibilityCode = table.Column<int>(type: "int", nullable: false),
        //            ObjectiveCode = table.Column<int>(type: "int", nullable: false),
        //            IsActive = table.Column<bool>(type: "bit", nullable: false),
        //            CreatedUserId = table.Column<int>(type: "int", nullable: true),
        //            CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
        //            UpdatedUserId = table.Column<int>(type: "int", nullable: true),
        //            UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_ImportBudgets", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "Languages",
        //        schema: "dropdown",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
        //            IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
        //            CreatedUserId = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1"),
        //            CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
        //            UpdatedUserId = table.Column<int>(type: "int", nullable: true),
        //            UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Languages", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "MonitoringEvaluation",
        //        schema: "fa",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            ApplicationId = table.Column<int>(type: "int", nullable: false),
        //            IsNew = table.Column<bool>(type: "bit", nullable: true),
        //            IsActive = table.Column<bool>(type: "bit", nullable: false),
        //            MonEvalDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            CreatedUserId = table.Column<int>(type: "int", nullable: false),
        //            CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
        //            UpdatedUserId = table.Column<int>(type: "int", nullable: true),
        //            UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_MonitoringEvaluation", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "OrganisationTypes",
        //        schema: "dropdown",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
        //            Description = table.Column<string>(type: "nvarchar(1000)", nullable: true),
        //            IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
        //            CreatedUserId = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1"),
        //            CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
        //            UpdatedUserId = table.Column<int>(type: "int", nullable: true),
        //            UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_OrganisationTypes", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "Permissions",
        //        schema: "core",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
        //            SystemName = table.Column<string>(type: "nvarchar(255)", nullable: false),
        //            CategoryName = table.Column<string>(type: "nvarchar(255)", nullable: false),
        //            IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
        //            CreatedUserId = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1"),
        //            CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
        //            UpdatedUserId = table.Column<int>(type: "int", nullable: true),
        //            UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Permissions", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "Positions",
        //        schema: "dropdown",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
        //            IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
        //            CreatedUserId = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1"),
        //            CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
        //            UpdatedUserId = table.Column<int>(type: "int", nullable: true),
        //            UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Positions", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "PreviousYearFinance",
        //        schema: "dbo",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            npoProfileId = table.Column<int>(type: "int", nullable: false),
        //            IncomeDescription = table.Column<string>(type: "nvarchar(255)", nullable: true),
        //            IncomeAmount = table.Column<int>(type: "int", nullable: true),
        //            ExpenditureDescription = table.Column<string>(type: "nvarchar(255)", nullable: true),
        //            ExpenditureAmount = table.Column<int>(type: "int", nullable: true),
        //            IsActive = table.Column<bool>(type: "bit", nullable: false),
        //            CreatedUserId = table.Column<int>(type: "int", nullable: false),
        //            CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
        //            UpdatedUserId = table.Column<int>(type: "int", nullable: true),
        //            UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_PreviousYearFinance", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "ProgrammeBudgets",
        //        schema: "budget",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            FinancialYearId = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            DepartmentId = table.Column<int>(type: "int", nullable: false),
        //            DepartmentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            ProgrammeId = table.Column<int>(type: "int", nullable: false),
        //            ProgrammeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            SubProgrammeId = table.Column<int>(type: "int", nullable: false),
        //            SubProgrammeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            SubProgrammeTypeId = table.Column<int>(type: "int", nullable: false),
        //            SubProgrammeTypeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            ProvisionalBudgetAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
        //            OriginalBudgetAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
        //            AdjustedBudgetAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
        //            ResponsibilityCode = table.Column<int>(type: "int", nullable: false),
        //            ObjectiveCode = table.Column<int>(type: "int", nullable: false),
        //            IsActive = table.Column<bool>(type: "bit", nullable: false),
        //            CreatedUserId = table.Column<int>(type: "int", nullable: false),
        //            CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
        //            UpdatedUserId = table.Column<int>(type: "int", nullable: true),
        //            UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_ProgrammeBudgets", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "Programmes",
        //        schema: "dropdown",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
        //            Description = table.Column<string>(type: "nvarchar(1000)", nullable: false),
        //            DepartmentId = table.Column<int>(type: "int", nullable: false),
        //            DirectorateId = table.Column<int>(type: "int", nullable: true),
        //            Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
        //            CreatedUserId = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1"),
        //            CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
        //            UpdatedUserId = table.Column<int>(type: "int", nullable: true),
        //            UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Programmes", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "ProjectInformation",
        //        schema: "fa",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            purposeQuestion = table.Column<string>(type: "nvarchar(max)", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_ProjectInformation", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "PropertyTypes",
        //        schema: "dropdown",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            OnGeneralLevel = table.Column<bool>(type: "bit", nullable: false),
        //            OnSubsidyLevel = table.Column<bool>(type: "bit", nullable: false),
        //            CanDefineName = table.Column<bool>(type: "bit", nullable: false),
        //            ValueOnGeneralLevel = table.Column<bool>(type: "bit", nullable: false),
        //            ValueOnSybsidyLevel = table.Column<bool>(type: "bit", nullable: false),
        //            HaveBreakDown = table.Column<bool>(type: "bit", nullable: false),
        //            HaveRelatedProperty = table.Column<bool>(type: "bit", nullable: false),
        //            IsBusinessRule = table.Column<bool>(type: "bit", nullable: false),
        //            IsActive = table.Column<bool>(type: "bit", nullable: false),
        //            IsDeleted = table.Column<bool>(type: "bit", nullable: false),
        //            CreatedUserID = table.Column<int>(type: "int", nullable: false),
        //            UpdatedUserID = table.Column<int>(type: "int", nullable: true),
        //            CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
        //            UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
        //            HaveFrequency = table.Column<bool>(type: "bit", nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_PropertyTypes", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "ProvisionTypes",
        //        schema: "dropdown",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
        //            SystemName = table.Column<string>(type: "nvarchar(255)", nullable: false),
        //            IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
        //            CreatedUserId = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1"),
        //            CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
        //            UpdatedUserId = table.Column<int>(type: "int", nullable: true),
        //            UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_ProvisionTypes", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "QuarterlyPeriod",
        //        schema: "core",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            Abbreviation = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //            Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
        //            IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
        //            CreatedUserId = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1"),
        //            CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
        //            UpdatedUserId = table.Column<int>(type: "int", nullable: true),
        //            UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_QuarterlyPeriod", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "QuestionCategories",
        //        schema: "eval",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            FundingTemplateTypeId = table.Column<int>(type: "int", nullable: false),
        //            Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
        //            IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
        //            CreatedUserId = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1"),
        //            CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
        //            UpdatedUserId = table.Column<int>(type: "int", nullable: true),
        //            UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_QuestionCategories", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "Races",
        //        schema: "dropdown",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
        //            IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
        //            CreatedUserId = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1"),
        //            CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
        //            UpdatedUserId = table.Column<int>(type: "int", nullable: true),
        //            UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Races", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "RecipientTypes",
        //        schema: "dropdown",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
        //            SystemName = table.Column<string>(type: "nvarchar(255)", nullable: false),
        //            IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
        //            CreatedUserId = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1"),
        //            CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
        //            UpdatedUserId = table.Column<int>(type: "int", nullable: true),
        //            UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_RecipientTypes", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "RegistrationStatuses",
        //        schema: "dropdown",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
        //            SystemName = table.Column<string>(type: "nvarchar(255)", nullable: false),
        //            IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
        //            CreatedUserId = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1"),
        //            CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
        //            UpdatedUserId = table.Column<int>(type: "int", nullable: true),
        //            UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_RegistrationStatuses", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "ResourceList",
        //        schema: "lookup",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
        //            Description = table.Column<string>(type: "nvarchar(1000)", nullable: true),
        //            ResourceTypeId = table.Column<int>(type: "int", nullable: false),
        //            IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
        //            CreatedUserId = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1"),
        //            CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
        //            UpdatedUserId = table.Column<int>(type: "int", nullable: true),
        //            UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_ResourceList", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "ResourceTypes",
        //        schema: "dropdown",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
        //            SystemName = table.Column<string>(type: "nvarchar(255)", nullable: false),
        //            IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
        //            CreatedUserId = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1"),
        //            CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
        //            UpdatedUserId = table.Column<int>(type: "int", nullable: true),
        //            UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_ResourceTypes", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "ResponseOptions",
        //        schema: "eval",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            ResponseTypeId = table.Column<int>(type: "int", nullable: false),
        //            Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
        //            SystemName = table.Column<string>(type: "nvarchar(255)", nullable: true),
        //            IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
        //            CreatedUserId = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1"),
        //            CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
        //            UpdatedUserId = table.Column<int>(type: "int", nullable: true),
        //            UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_ResponseOptions", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "ResponseTypes",
        //        schema: "eval",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
        //            Description = table.Column<string>(type: "nvarchar(1000)", nullable: true),
        //            IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
        //            CreatedUserId = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1"),
        //            CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
        //            UpdatedUserId = table.Column<int>(type: "int", nullable: true),
        //            UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_ResponseTypes", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "Roles",
        //        schema: "core",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
        //            SystemName = table.Column<string>(type: "nvarchar(255)", nullable: false),
        //            IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
        //            CreatedUserId = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1"),
        //            CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
        //            UpdatedUserId = table.Column<int>(type: "int", nullable: true),
        //            UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Roles", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "ServicesRendered",
        //        schema: "dbo",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            NpoProfileId = table.Column<int>(type: "int", nullable: false),
        //            ProgrammeId = table.Column<int>(type: "int", nullable: false),
        //            SubProgrammeId = table.Column<int>(type: "int", nullable: false),
        //            SubProgrammeTypeId = table.Column<int>(type: "int", nullable: false),
        //            IsActive = table.Column<bool>(type: "bit", nullable: false),
        //            CreatedUserId = table.Column<int>(type: "int", nullable: false),
        //            CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
        //            UpdatedUserId = table.Column<int>(type: "int", nullable: true),
        //            UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
        //            EntityTypeNumber = table.Column<int>(type: "int", nullable: false),
        //            EntitySystemNumber = table.Column<int>(type: "int", nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_ServicesRendered", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "ServiceTypes",
        //        schema: "dropdown",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
        //            SystemName = table.Column<string>(type: "nvarchar(255)", nullable: false),
        //            IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
        //            CreatedUserId = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1"),
        //            CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
        //            UpdatedUserId = table.Column<int>(type: "int", nullable: true),
        //            UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_ServiceTypes", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "SourceOfInformation",
        //        schema: "dbo",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            NpoProfileId = table.Column<int>(type: "int", nullable: true),
        //            SelectedSourceValue = table.Column<int>(type: "int", nullable: true),
        //            AdditionalSourceInformation = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            CreatedUserId = table.Column<int>(type: "int", nullable: false),
        //            CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
        //            UpdatedUserId = table.Column<int>(type: "int", nullable: true),
        //            UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_SourceOfInformation", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "StaffCategories",
        //        schema: "dropdown",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
        //            SystemName = table.Column<string>(type: "nvarchar(255)", nullable: true),
        //            IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
        //            CreatedUserId = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1"),
        //            CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
        //            UpdatedUserId = table.Column<int>(type: "int", nullable: true),
        //            UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_StaffCategories", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "StaffMemberProfiles",
        //        schema: "dbo",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            NpoProfileId = table.Column<int>(type: "int", nullable: false),
        //            StaffCategoryId = table.Column<int>(type: "int", nullable: false),
        //            VacantPosts = table.Column<int>(type: "int", nullable: false),
        //            FilledPosts = table.Column<int>(type: "int", nullable: false),
        //            ConsultantsAppointed = table.Column<int>(type: "int", nullable: false),
        //            StaffWithDisabilities = table.Column<int>(type: "int", nullable: false),
        //            AfricanMale = table.Column<int>(type: "int", nullable: false),
        //            AfricanFemale = table.Column<int>(type: "int", nullable: false),
        //            IndianMale = table.Column<int>(type: "int", nullable: false),
        //            IndianFemale = table.Column<int>(type: "int", nullable: false),
        //            ColouredMale = table.Column<int>(type: "int", nullable: false),
        //            ColouredFemale = table.Column<int>(type: "int", nullable: false),
        //            WhiteMale = table.Column<int>(type: "int", nullable: false),
        //            WhiteFemale = table.Column<int>(type: "int", nullable: false),
        //            OtherSpecify = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            CreatedUserId = table.Column<int>(type: "int", nullable: false),
        //            CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
        //            UpdatedUserId = table.Column<int>(type: "int", nullable: true),
        //            UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_StaffMemberProfiles", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "Statuses",
        //        schema: "dbo",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
        //            SystemName = table.Column<string>(type: "nvarchar(255)", nullable: false),
        //            IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
        //            CreatedUserId = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1"),
        //            CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
        //            UpdatedUserId = table.Column<int>(type: "int", nullable: true),
        //            UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Statuses", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "SubProgrammes",
        //        schema: "dropdown",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
        //            Description = table.Column<string>(type: "nvarchar(1000)", nullable: false),
        //            ProgrammeId = table.Column<int>(type: "int", nullable: false),
        //            IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
        //            CreatedUserId = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1"),
        //            CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
        //            UpdatedUserId = table.Column<int>(type: "int", nullable: true),
        //            UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_SubProgrammes", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "SubProgrammeTypes",
        //        schema: "dropdown",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
        //            Description = table.Column<string>(type: "nvarchar(1000)", nullable: false),
        //            SubProgrammeId = table.Column<int>(type: "int", nullable: false),
        //            IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
        //            Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            CreatedUserId = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1"),
        //            CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
        //            UpdatedUserId = table.Column<int>(type: "int", nullable: true),
        //            UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_SubProgrammeTypes", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "Titles",
        //        schema: "dropdown",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
        //            IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
        //            CreatedUserId = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1"),
        //            CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
        //            UpdatedUserId = table.Column<int>(type: "int", nullable: true),
        //            UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Titles", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "TrainingMaterials",
        //        schema: "dbo",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
        //            Description = table.Column<string>(type: "nvarchar(1000)", nullable: true),
        //            Link = table.Column<string>(type: "nvarchar(2000)", nullable: false),
        //            IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
        //            CreatedUserId = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1"),
        //            CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
        //            UpdatedUserId = table.Column<int>(type: "int", nullable: true),
        //            UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_TrainingMaterials", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "UserProgram",
        //        schema: "core",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
        //            DepartmentId = table.Column<int>(type: "int", nullable: false),
        //            IsActive = table.Column<bool>(type: "bit", nullable: false),
        //            CreatedUserId = table.Column<int>(type: "int", nullable: false),
        //            CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
        //            UpdatedUserId = table.Column<int>(type: "int", nullable: true),
        //            UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_UserProgram", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "Users",
        //        schema: "core",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            Email = table.Column<string>(type: "nvarchar(255)", nullable: false),
        //            UserName = table.Column<string>(type: "nvarchar(255)", nullable: false),
        //            FirstName = table.Column<string>(type: "nvarchar(255)", nullable: false),
        //            LastName = table.Column<string>(type: "nvarchar(255)", nullable: false),
        //            IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
        //            IsB2C = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "0"),
        //            CreatedUserId = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1"),
        //            CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
        //            UpdatedUserId = table.Column<int>(type: "int", nullable: true),
        //            UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Users", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "Utilities",
        //        schema: "core",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
        //            Description = table.Column<string>(type: "nvarchar(1000)", nullable: false),
        //            AngularRedirectUrl = table.Column<string>(type: "nvarchar(255)", nullable: false),
        //            SystemAdminUtility = table.Column<bool>(type: "bit", nullable: false),
        //            IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
        //            CreatedUserId = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1"),
        //            CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
        //            UpdatedUserId = table.Column<int>(type: "int", nullable: true),
        //            UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Utilities", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "WorkflowAssessments",
        //        schema: "eval",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            QuestionCategoryId = table.Column<int>(type: "int", nullable: false),
        //            NumberOfAssessments = table.Column<int>(type: "int", nullable: false),
        //            IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
        //            CreatedUserId = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1"),
        //            CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
        //            UpdatedUserId = table.Column<int>(type: "int", nullable: true),
        //            UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_WorkflowAssessments", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "ProgramBankDetails",
        //        schema: "dbo",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            ProgramId = table.Column<int>(type: "int", nullable: false),
        //            NpoProfileId = table.Column<int>(type: "int", nullable: false),
        //            BankId = table.Column<int>(type: "int", nullable: false),
        //            BranchId = table.Column<int>(type: "int", nullable: false),
        //            AccountTypeId = table.Column<int>(type: "int", nullable: false),
        //            AccountNumber = table.Column<string>(type: "nvarchar(255)", nullable: true),
        //            IsActive = table.Column<bool>(type: "bit", nullable: false),
        //            CreatedUserId = table.Column<int>(type: "int", nullable: false),
        //            CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
        //            UpdatedUserId = table.Column<int>(type: "int", nullable: true),
        //            UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
        //            ApprovalStatusId = table.Column<int>(type: "int", nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_ProgramBankDetails", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_ProgramBankDetails_AccessStatuses_ApprovalStatusId",
        //                column: x => x.ApprovalStatusId,
        //                principalSchema: "dbo",
        //                principalTable: "AccessStatuses",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "PaymentSchedules",
        //        schema: "dbo",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            CompliantCycleId = table.Column<int>(type: "int", nullable: false),
        //            StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
        //            ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
        //            PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
        //            IsActive = table.Column<bool>(type: "bit", nullable: false),
        //            CreatedUserId = table.Column<int>(type: "int", nullable: false),
        //            CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
        //            UpdatedUserId = table.Column<int>(type: "int", nullable: true),
        //            UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_PaymentSchedules", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_PaymentSchedules_CompliantCycles_CompliantCycleId",
        //                column: x => x.CompliantCycleId,
        //                principalSchema: "dbo",
        //                principalTable: "CompliantCycles",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "LocalMunicipalities",
        //        schema: "dropdown",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            DistrictCouncilId = table.Column<int>(type: "int", nullable: false),
        //            Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
        //            SystemName = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
        //            CreatedUserId = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1"),
        //            CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
        //            UpdatedUserId = table.Column<int>(type: "int", nullable: true),
        //            UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_LocalMunicipalities", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_LocalMunicipalities_DistrictCouncils_DistrictCouncilId",
        //                column: x => x.DistrictCouncilId,
        //                principalSchema: "dropdown",
        //                principalTable: "DistrictCouncils",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "DocumentStores",
        //        schema: "core",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            RefNo = table.Column<string>(type: "char(15)", nullable: false),
        //            DocumentTypeId = table.Column<int>(type: "int", nullable: true),
        //            EntityTypeId = table.Column<int>(type: "int", nullable: false),
        //            EntityId = table.Column<int>(type: "int", nullable: false),
        //            Entity = table.Column<string>(type: "nvarchar(50)", nullable: false),
        //            Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
        //            ResourceId = table.Column<string>(type: "nvarchar(80)", nullable: false),
        //            FileSize = table.Column<string>(type: "nvarchar(50)", nullable: false),
        //            IsActive = table.Column<bool>(type: "bit", nullable: false),
        //            CreatedUserId = table.Column<int>(type: "int", nullable: false),
        //            CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
        //            UpdatedUserId = table.Column<int>(type: "int", nullable: true),
        //            UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_DocumentStores", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_DocumentStores_DocumentTypes_DocumentTypeId",
        //                column: x => x.DocumentTypeId,
        //                principalSchema: "core",
        //                principalTable: "DocumentTypes",
        //                principalColumn: "Id");
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "EmailTemplates",
        //        schema: "core",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            EmailAccountId = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1"),
        //            Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
        //            Body = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
        //            Subject = table.Column<string>(type: "nvarchar(255)", nullable: false),
        //            Description = table.Column<string>(type: "nvarchar(2000)", nullable: true),
        //            IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1")
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_EmailTemplates", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_EmailTemplates_EmailAccounts_EmailAccountId",
        //                column: x => x.EmailAccountId,
        //                principalSchema: "core",
        //                principalTable: "EmailAccounts",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "FacilitySubDistricts",
        //        schema: "dropdown",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            FacilityDistrictId = table.Column<int>(type: "int", nullable: false),
        //            Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
        //            IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
        //            CreatedUserId = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1"),
        //            CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
        //            UpdatedUserId = table.Column<int>(type: "int", nullable: true),
        //            UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_FacilitySubDistricts", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_FacilitySubDistricts_FacilityDistricts_FacilityDistrictId",
        //                column: x => x.FacilityDistrictId,
        //                principalSchema: "dropdown",
        //                principalTable: "FacilityDistricts",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "WorkplanTargets",
        //        schema: "indicator",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            ActivityId = table.Column<int>(type: "int", nullable: false),
        //            FinancialYearId = table.Column<int>(type: "int", nullable: false),
        //            FrequencyId = table.Column<int>(type: "int", nullable: false),
        //            Annual = table.Column<int>(type: "int", nullable: true),
        //            Apr = table.Column<int>(type: "int", nullable: true),
        //            May = table.Column<int>(type: "int", nullable: true),
        //            Jun = table.Column<int>(type: "int", nullable: true),
        //            Jul = table.Column<int>(type: "int", nullable: true),
        //            Aug = table.Column<int>(type: "int", nullable: true),
        //            Sep = table.Column<int>(type: "int", nullable: true),
        //            Oct = table.Column<int>(type: "int", nullable: true),
        //            Nov = table.Column<int>(type: "int", nullable: true),
        //            Dec = table.Column<int>(type: "int", nullable: true),
        //            Jan = table.Column<int>(type: "int", nullable: true),
        //            Feb = table.Column<int>(type: "int", nullable: true),
        //            Mar = table.Column<int>(type: "int", nullable: true),
        //            Quarter1 = table.Column<int>(type: "int", nullable: true),
        //            Quarter2 = table.Column<int>(type: "int", nullable: true),
        //            Quarter3 = table.Column<int>(type: "int", nullable: true),
        //            Quarter4 = table.Column<int>(type: "int", nullable: true),
        //            CreatedUserId = table.Column<int>(type: "int", nullable: false),
        //            CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
        //            UpdatedUserId = table.Column<int>(type: "int", nullable: true),
        //            UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_WorkplanTargets", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_WorkplanTargets_FinancialYears_FinancialYearId",
        //                column: x => x.FinancialYearId,
        //                principalSchema: "core",
        //                principalTable: "FinancialYears",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //            table.ForeignKey(
        //                name: "FK_WorkplanTargets_Frequencies_FrequencyId",
        //                column: x => x.FrequencyId,
        //                principalSchema: "dropdown",
        //                principalTable: "Frequencies",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "WorkplanActuals",
        //        schema: "indicator",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            ActivityId = table.Column<int>(type: "int", nullable: false),
        //            FinancialYearId = table.Column<int>(type: "int", nullable: false),
        //            FrequencyPeriodId = table.Column<int>(type: "int", nullable: false),
        //            StatusId = table.Column<int>(type: "int", nullable: false),
        //            Actual = table.Column<int>(type: "int", nullable: true),
        //            Statement = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            DeviationReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            Action = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            CreatedUserId = table.Column<int>(type: "int", nullable: false),
        //            CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
        //            UpdatedUserId = table.Column<int>(type: "int", nullable: true),
        //            UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
        //            WorkplanTargetId = table.Column<int>(type: "int", nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_WorkplanActuals", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_WorkplanActuals_FrequencyPeriods_FrequencyPeriodId",
        //                column: x => x.FrequencyPeriodId,
        //                principalSchema: "dropdown",
        //                principalTable: "FrequencyPeriods",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "PropertySubTypes",
        //        schema: "dropdown",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            PropertyTypeID = table.Column<int>(type: "int", nullable: false),
        //            Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            HaveComment = table.Column<bool>(type: "bit", nullable: false),
        //            Repeatable = table.Column<bool>(type: "bit", nullable: false),
        //            Frequency = table.Column<int>(type: "int", nullable: true),
        //            IsActive = table.Column<bool>(type: "bit", nullable: false),
        //            IsDeleted = table.Column<bool>(type: "bit", nullable: false),
        //            CreatedUserID = table.Column<int>(type: "int", nullable: false),
        //            UpdatedUserID = table.Column<int>(type: "int", nullable: true),
        //            CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
        //            UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_PropertySubTypes", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_PropertySubTypes_PropertyTypes_PropertyTypeID",
        //                column: x => x.PropertyTypeID,
        //                principalSchema: "dropdown",
        //                principalTable: "PropertyTypes",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "QuestionSections",
        //        schema: "eval",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            QuestionCategoryId = table.Column<int>(type: "int", nullable: false),
        //            Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
        //            SortOrder = table.Column<int>(type: "int", nullable: false),
        //            IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
        //            CreatedUserId = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1"),
        //            CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
        //            UpdatedUserId = table.Column<int>(type: "int", nullable: true),
        //            UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_QuestionSections", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_QuestionSections_QuestionCategories_QuestionCategoryId",
        //                column: x => x.QuestionCategoryId,
        //                principalSchema: "eval",
        //                principalTable: "QuestionCategories",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "Objectives",
        //        schema: "dbo",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            ApplicationId = table.Column<int>(type: "int", nullable: false),
        //            Name = table.Column<string>(type: "nvarchar(50)", nullable: true),
        //            Description = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
        //            FundingSource = table.Column<string>(type: "nvarchar(255)", nullable: true),
        //            FinancialYear = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            Quarter = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            FundingPeriodStartDate = table.Column<string>(type: "nvarchar(50)", nullable: true),
        //            FundingPeriodEndDate = table.Column<string>(type: "nvarchar(50)", nullable: true),
        //            RecipientTypeId = table.Column<int>(type: "int", nullable: false),
        //            Budget = table.Column<decimal>(type: "numeric(18,6)", nullable: false),
        //            IsActive = table.Column<bool>(type: "bit", nullable: false),
        //            CreatedUserId = table.Column<int>(type: "int", nullable: false),
        //            CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
        //            UpdatedUserId = table.Column<int>(type: "int", nullable: true),
        //            UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
        //            ChangesRequired = table.Column<bool>(type: "bit", nullable: true),
        //            IsNew = table.Column<bool>(type: "bit", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Objectives", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_Objectives_RecipientTypes_RecipientTypeId",
        //                column: x => x.RecipientTypeId,
        //                principalSchema: "dropdown",
        //                principalTable: "RecipientTypes",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "Departments_Roles",
        //        schema: "mapping",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            RoleId = table.Column<int>(type: "int", nullable: false),
        //            DepartmentId = table.Column<int>(type: "int", nullable: false),
        //            IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Departments_Roles", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_Departments_Roles_Departments_DepartmentId",
        //                column: x => x.DepartmentId,
        //                principalSchema: "core",
        //                principalTable: "Departments",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //            table.ForeignKey(
        //                name: "FK_Departments_Roles_Roles_RoleId",
        //                column: x => x.RoleId,
        //                principalSchema: "core",
        //                principalTable: "Roles",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "Roles_Permissions",
        //        schema: "mapping",
        //        columns: table => new
        //        {
        //            RoleId = table.Column<int>(type: "int", nullable: false),
        //            PermissionId = table.Column<int>(type: "int", nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Roles_Permissions", x => new { x.RoleId, x.PermissionId });
        //            table.ForeignKey(
        //                name: "FK_Roles_Permissions_Permissions_PermissionId",
        //                column: x => x.PermissionId,
        //                principalSchema: "core",
        //                principalTable: "Permissions",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //            table.ForeignKey(
        //                name: "FK_Roles_Permissions_Roles_RoleId",
        //                column: x => x.RoleId,
        //                principalSchema: "core",
        //                principalTable: "Roles",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "ApplicationPeriods",
        //        schema: "dbo",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            RefNo = table.Column<string>(type: "char(15)", nullable: true),
        //            DepartmentId = table.Column<int>(type: "int", nullable: false),
        //            ProgrammeId = table.Column<int>(type: "int", nullable: false),
        //            SubProgrammeId = table.Column<int>(type: "int", nullable: false),
        //            ApplicationTypeId = table.Column<int>(type: "int", nullable: false),
        //            Name = table.Column<string>(type: "nvarchar(255)", nullable: true),
        //            Description = table.Column<string>(type: "nvarchar(500)", nullable: true),
        //            FinancialYearId = table.Column<int>(type: "int", nullable: false),
        //            OpeningDate = table.Column<DateTime>(type: "datetime2", nullable: false),
        //            ClosingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
        //            CreatedUserId = table.Column<int>(type: "int", nullable: false),
        //            CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
        //            UpdatedUserId = table.Column<int>(type: "int", nullable: true),
        //            UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_ApplicationPeriods", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_ApplicationPeriods_ApplicationTypes_ApplicationTypeId",
        //                column: x => x.ApplicationTypeId,
        //                principalSchema: "dropdown",
        //                principalTable: "ApplicationTypes",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //            table.ForeignKey(
        //                name: "FK_ApplicationPeriods_Departments_DepartmentId",
        //                column: x => x.DepartmentId,
        //                principalSchema: "core",
        //                principalTable: "Departments",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //            table.ForeignKey(
        //                name: "FK_ApplicationPeriods_FinancialYears_FinancialYearId",
        //                column: x => x.FinancialYearId,
        //                principalSchema: "core",
        //                principalTable: "FinancialYears",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //            table.ForeignKey(
        //                name: "FK_ApplicationPeriods_Programmes_ProgrammeId",
        //                column: x => x.ProgrammeId,
        //                principalSchema: "dropdown",
        //                principalTable: "Programmes",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //            table.ForeignKey(
        //                name: "FK_ApplicationPeriods_SubProgrammes_SubProgrammeId",
        //                column: x => x.SubProgrammeId,
        //                principalSchema: "dropdown",
        //                principalTable: "SubProgrammes",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "BudgetAdjustment",
        //        schema: "budget",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            ProgrammeId = table.Column<int>(type: "int", nullable: false),
        //            ResponsibilityCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            SubProgrammeTypeId = table.Column<int>(type: "int", nullable: false),
        //            ObjectiveCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_BudgetAdjustment", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_BudgetAdjustment_Programmes_ProgrammeId",
        //                column: x => x.ProgrammeId,
        //                principalSchema: "dropdown",
        //                principalTable: "Programmes",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //            table.ForeignKey(
        //                name: "FK_BudgetAdjustment_SubProgrammeTypes_SubProgrammeTypeId",
        //                column: x => x.SubProgrammeTypeId,
        //                principalSchema: "dropdown",
        //                principalTable: "SubProgrammeTypes",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "Segment_Code",
        //        schema: "mapping",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            ProgrammeId = table.Column<int>(type: "int", nullable: false),
        //            ResponsibilityCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            SubProgrammeTypeId = table.Column<int>(type: "int", nullable: false),
        //            ObjectiveCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            SubProgramId = table.Column<int>(type: "int", nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Segment_Code", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_Segment_Code_Programmes_ProgrammeId",
        //                column: x => x.ProgrammeId,
        //                principalSchema: "dropdown",
        //                principalTable: "Programmes",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //            table.ForeignKey(
        //                name: "FK_Segment_Code_SubProgrammeTypes_SubProgrammeTypeId",
        //                column: x => x.SubProgrammeTypeId,
        //                principalSchema: "dropdown",
        //                principalTable: "SubProgrammeTypes",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "ProgramContactInformation",
        //        schema: "dbo",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            ProgrammeId = table.Column<int>(type: "int", nullable: false),
        //            NpoProfileId = table.Column<int>(type: "int", nullable: false),
        //            TitleId = table.Column<int>(type: "int", nullable: false),
        //            FirstName = table.Column<string>(type: "nvarchar(255)", nullable: true),
        //            LastName = table.Column<string>(type: "nvarchar(255)", nullable: true),
        //            RSAIdNumber = table.Column<bool>(type: "bit", nullable: false),
        //            IdNumber = table.Column<string>(type: "nvarchar(13)", nullable: true),
        //            PassportNumber = table.Column<string>(type: "nvarchar(50)", nullable: true),
        //            EmailAddress = table.Column<string>(type: "nvarchar(255)", nullable: true),
        //            Telephone = table.Column<string>(type: "nvarchar(50)", nullable: true),
        //            Cellphone = table.Column<string>(type: "nvarchar(50)", nullable: true),
        //            PositionId = table.Column<int>(type: "int", nullable: true),
        //            Comments = table.Column<string>(type: "nvarchar(1000)", nullable: true),
        //            IsPrimaryContact = table.Column<bool>(type: "bit", nullable: true),
        //            IsDisabled = table.Column<bool>(type: "bit", nullable: true),
        //            IsBoardMember = table.Column<bool>(type: "bit", nullable: true),
        //            IsSignatory = table.Column<bool>(type: "bit", nullable: true),
        //            IsWrittenAgreementSignatory = table.Column<bool>(type: "bit", nullable: true),
        //            YearsOfExperience = table.Column<int>(type: "int", nullable: true),
        //            RaceId = table.Column<int>(type: "int", nullable: true),
        //            GenderId = table.Column<int>(type: "int", nullable: true),
        //            LanguageId = table.Column<int>(type: "int", nullable: true),
        //            DateOfEmployment = table.Column<DateTime>(type: "datetime2", nullable: true),
        //            Qualifications = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            AddressInformation = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            IsActive = table.Column<bool>(type: "bit", nullable: false),
        //            CreatedUserId = table.Column<int>(type: "int", nullable: false),
        //            CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
        //            UpdatedUserId = table.Column<int>(type: "int", nullable: true),
        //            UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
        //            ApprovalStatusId = table.Column<int>(type: "int", nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_ProgramContactInformation", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_ProgramContactInformation_AccessStatuses_ApprovalStatusId",
        //                column: x => x.ApprovalStatusId,
        //                principalSchema: "dbo",
        //                principalTable: "AccessStatuses",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //            table.ForeignKey(
        //                name: "FK_ProgramContactInformation_Gender_GenderId",
        //                column: x => x.GenderId,
        //                principalSchema: "dropdown",
        //                principalTable: "Gender",
        //                principalColumn: "Id");
        //            table.ForeignKey(
        //                name: "FK_ProgramContactInformation_Languages_LanguageId",
        //                column: x => x.LanguageId,
        //                principalSchema: "dropdown",
        //                principalTable: "Languages",
        //                principalColumn: "Id");
        //            table.ForeignKey(
        //                name: "FK_ProgramContactInformation_Positions_PositionId",
        //                column: x => x.PositionId,
        //                principalSchema: "dropdown",
        //                principalTable: "Positions",
        //                principalColumn: "Id");
        //            table.ForeignKey(
        //                name: "FK_ProgramContactInformation_Races_RaceId",
        //                column: x => x.RaceId,
        //                principalSchema: "dropdown",
        //                principalTable: "Races",
        //                principalColumn: "Id");
        //            table.ForeignKey(
        //                name: "FK_ProgramContactInformation_Titles_TitleId",
        //                column: x => x.TitleId,
        //                principalSchema: "dropdown",
        //                principalTable: "Titles",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "ApplicationApprovals",
        //        schema: "dbo",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            ApplicationId = table.Column<int>(type: "int", nullable: false),
        //            StatusId = table.Column<int>(type: "int", nullable: false),
        //            ApprovedFrom = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            isActive = table.Column<bool>(type: "bit", nullable: false),
        //            CreatedUserId = table.Column<int>(type: "int", nullable: false),
        //            CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_ApplicationApprovals", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_ApplicationApprovals_Users_CreatedUserId",
        //                column: x => x.CreatedUserId,
        //                principalSchema: "core",
        //                principalTable: "Users",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "ApplicationAudits",
        //        schema: "dbo",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            ApplicationId = table.Column<int>(type: "int", nullable: false),
        //            StatusId = table.Column<int>(type: "int", nullable: false),
        //            CreatedUserId = table.Column<int>(type: "int", nullable: false),
        //            CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_ApplicationAudits", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_ApplicationAudits_Statuses_StatusId",
        //                column: x => x.StatusId,
        //                principalSchema: "dbo",
        //                principalTable: "Statuses",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //            table.ForeignKey(
        //                name: "FK_ApplicationAudits_Users_CreatedUserId",
        //                column: x => x.CreatedUserId,
        //                principalSchema: "core",
        //                principalTable: "Users",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "ApplicationComments",
        //        schema: "dbo",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            ApplicationId = table.Column<int>(type: "int", nullable: false),
        //            ServiceProvisionStepId = table.Column<int>(type: "int", nullable: false),
        //            EntityId = table.Column<int>(type: "int", nullable: false),
        //            Comment = table.Column<string>(type: "nvarchar(2000)", nullable: false),
        //            CreatedUserId = table.Column<int>(type: "int", nullable: false),
        //            CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_ApplicationComments", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_ApplicationComments_Users_CreatedUserId",
        //                column: x => x.CreatedUserId,
        //                principalSchema: "core",
        //                principalTable: "Users",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "ApplicationReviewerSatisfactions",
        //        schema: "dbo",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            ApplicationId = table.Column<int>(type: "int", nullable: false),
        //            ServiceProvisionStepId = table.Column<int>(type: "int", nullable: false),
        //            EntityId = table.Column<int>(type: "int", nullable: false),
        //            IsSatisfied = table.Column<bool>(type: "bit", nullable: false),
        //            CreatedUserId = table.Column<int>(type: "int", nullable: false),
        //            CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_ApplicationReviewerSatisfactions", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_ApplicationReviewerSatisfactions_Users_CreatedUserId",
        //                column: x => x.CreatedUserId,
        //                principalSchema: "core",
        //                principalTable: "Users",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "CapturedResponses",
        //        schema: "eval",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            FundingApplicationId = table.Column<int>(type: "int", nullable: false),
        //            QuestionCategoryId = table.Column<int>(type: "int", nullable: false),
        //            StatusId = table.Column<int>(type: "int", nullable: false),
        //            Comments = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
        //            ReviewerComment = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
        //            ReviewerUserId = table.Column<int>(type: "int", nullable: false),
        //            IsActive = table.Column<bool>(type: "bit", nullable: false),
        //            IsSignedOff = table.Column<bool>(type: "bit", nullable: false),
        //            isDeclarationAccepted = table.Column<bool>(type: "bit", nullable: false),
        //            selectedStatus = table.Column<int>(type: "int", nullable: true),
        //            disableFlag = table.Column<int>(type: "int", nullable: true),
        //            CreatedUserId = table.Column<int>(type: "int", nullable: false),
        //            CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
        //            UpdatedUserId = table.Column<int>(type: "int", nullable: true),
        //            UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
        //            ReviewerUpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_CapturedResponses", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_CapturedResponses_Users_CreatedUserId",
        //                column: x => x.CreatedUserId,
        //                principalSchema: "core",
        //                principalTable: "Users",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "MyContentLinks",
        //        schema: "fa",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            ApplicationId = table.Column<int>(type: "int", nullable: false),
        //            DocumentTypeId = table.Column<int>(type: "int", nullable: false),
        //            Url = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
        //            IsActive = table.Column<bool>(type: "bit", nullable: false),
        //            CreatedUserId = table.Column<int>(type: "int", nullable: false),
        //            CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
        //            UpdatedUserId = table.Column<int>(type: "int", nullable: true),
        //            UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_MyContentLinks", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_MyContentLinks_Users_CreatedUserId",
        //                column: x => x.CreatedUserId,
        //                principalSchema: "core",
        //                principalTable: "Users",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "Npos",
        //        schema: "dbo",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            RefNo = table.Column<string>(type: "char(15)", nullable: true),
        //            Name = table.Column<string>(type: "nvarchar(255)", nullable: true),
        //            OrganisationTypeId = table.Column<int>(type: "int", nullable: false),
        //            RegistrationNumber = table.Column<string>(type: "nvarchar(50)", nullable: true),
        //            YearRegistered = table.Column<string>(type: "nvarchar(10)", nullable: true),
        //            Website = table.Column<string>(type: "nvarchar(255)", nullable: true),
        //            IsNew = table.Column<bool>(type: "bit", nullable: false),
        //            IsActive = table.Column<bool>(type: "bit", nullable: false),
        //            RegistrationStatusId = table.Column<int>(type: "int", nullable: true),
        //            PBONumber = table.Column<string>(type: "nvarchar(50)", nullable: true),
        //            Section18Receipts = table.Column<bool>(type: "bit", nullable: false),
        //            CCode = table.Column<string>(type: "nvarchar(255)", nullable: true),
        //            CreatedUserId = table.Column<int>(type: "int", nullable: false),
        //            CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
        //            UpdatedUserId = table.Column<int>(type: "int", nullable: true),
        //            UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
        //            ApprovalStatusId = table.Column<int>(type: "int", nullable: false),
        //            ApprovalUserId = table.Column<int>(type: "int", nullable: true),
        //            ApprovalDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Npos", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_Npos_AccessStatuses_ApprovalStatusId",
        //                column: x => x.ApprovalStatusId,
        //                principalSchema: "dbo",
        //                principalTable: "AccessStatuses",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //            table.ForeignKey(
        //                name: "FK_Npos_OrganisationTypes_OrganisationTypeId",
        //                column: x => x.OrganisationTypeId,
        //                principalSchema: "dropdown",
        //                principalTable: "OrganisationTypes",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //            table.ForeignKey(
        //                name: "FK_Npos_RegistrationStatuses_RegistrationStatusId",
        //                column: x => x.RegistrationStatusId,
        //                principalSchema: "dropdown",
        //                principalTable: "RegistrationStatuses",
        //                principalColumn: "Id");
        //            table.ForeignKey(
        //                name: "FK_Npos_Users_ApprovalUserId",
        //                column: x => x.ApprovalUserId,
        //                principalSchema: "core",
        //                principalTable: "Users",
        //                principalColumn: "Id");
        //            table.ForeignKey(
        //                name: "FK_Npos_Users_CreatedUserId",
        //                column: x => x.CreatedUserId,
        //                principalSchema: "core",
        //                principalTable: "Users",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "ResponseHistory",
        //        schema: "eval",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            FundingApplicationId = table.Column<int>(type: "int", nullable: false),
        //            QuestionId = table.Column<int>(type: "int", nullable: false),
        //            ResponseOptionId = table.Column<int>(type: "int", nullable: false),
        //            Comment = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
        //            CreatedUserId = table.Column<int>(type: "int", nullable: false),
        //            CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_ResponseHistory", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_ResponseHistory_ResponseOptions_ResponseOptionId",
        //                column: x => x.ResponseOptionId,
        //                principalSchema: "eval",
        //                principalTable: "ResponseOptions",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //            table.ForeignKey(
        //                name: "FK_ResponseHistory_Users_CreatedUserId",
        //                column: x => x.CreatedUserId,
        //                principalSchema: "core",
        //                principalTable: "Users",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "UserProgramMapping",
        //        schema: "mapping",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            UserId = table.Column<int>(type: "int", nullable: false),
        //            ProgramId = table.Column<int>(type: "int", nullable: false),
        //            IsActive = table.Column<bool>(type: "bit", nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_UserProgramMapping", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_UserProgramMapping_Programmes_ProgramId",
        //                column: x => x.ProgramId,
        //                principalSchema: "dropdown",
        //                principalTable: "Programmes",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //            table.ForeignKey(
        //                name: "FK_UserProgramMapping_Users_UserId",
        //                column: x => x.UserId,
        //                principalSchema: "core",
        //                principalTable: "Users",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "Users_Departments",
        //        schema: "mapping",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            UserId = table.Column<int>(type: "int", nullable: false),
        //            DepartmentId = table.Column<int>(type: "int", nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Users_Departments", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_Users_Departments_Departments_DepartmentId",
        //                column: x => x.DepartmentId,
        //                principalSchema: "core",
        //                principalTable: "Departments",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //            table.ForeignKey(
        //                name: "FK_Users_Departments_Users_UserId",
        //                column: x => x.UserId,
        //                principalSchema: "core",
        //                principalTable: "Users",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "Users_Roles",
        //        schema: "mapping",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            UserId = table.Column<int>(type: "int", nullable: false),
        //            RoleId = table.Column<int>(type: "int", nullable: false),
        //            IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1")
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Users_Roles", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_Users_Roles_Roles_RoleId",
        //                column: x => x.RoleId,
        //                principalSchema: "core",
        //                principalTable: "Roles",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //            table.ForeignKey(
        //                name: "FK_Users_Roles_Users_UserId",
        //                column: x => x.UserId,
        //                principalSchema: "core",
        //                principalTable: "Users",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "WorkplanActualAudits",
        //        schema: "indicator",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            WorkplanActualId = table.Column<int>(type: "int", nullable: false),
        //            StatusId = table.Column<int>(type: "int", nullable: false),
        //            CreatedUserId = table.Column<int>(type: "int", nullable: false),
        //            CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_WorkplanActualAudits", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_WorkplanActualAudits_Users_CreatedUserId",
        //                column: x => x.CreatedUserId,
        //                principalSchema: "core",
        //                principalTable: "Users",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "WorkplanComments",
        //        schema: "indicator",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            WorkplanActualId = table.Column<int>(type: "int", nullable: false),
        //            Comment = table.Column<string>(type: "nvarchar(2000)", nullable: false),
        //            CreatedUserId = table.Column<int>(type: "int", nullable: false),
        //            CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_WorkplanComments", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_WorkplanComments_Users_CreatedUserId",
        //                column: x => x.CreatedUserId,
        //                principalSchema: "core",
        //                principalTable: "Users",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "ProgrammeServiceDelivery",
        //        schema: "dbo",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            ApprovalStatusId = table.Column<int>(type: "int", nullable: false),
        //            ProgramId = table.Column<int>(type: "int", nullable: false),
        //            NpoProfileId = table.Column<int>(type: "int", nullable: false),
        //            IsActive = table.Column<bool>(type: "bit", nullable: false),
        //            CreatedUserId = table.Column<int>(type: "int", nullable: false),
        //            CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
        //            UpdatedUserId = table.Column<int>(type: "int", nullable: true),
        //            UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
        //            DistrictCouncilId = table.Column<int>(type: "int", nullable: true),
        //            LocalMunicipalityId = table.Column<int>(type: "int", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_ProgrammeServiceDelivery", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_ProgrammeServiceDelivery_AccessStatuses_ApprovalStatusId",
        //                column: x => x.ApprovalStatusId,
        //                principalSchema: "dbo",
        //                principalTable: "AccessStatuses",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //            table.ForeignKey(
        //                name: "FK_ProgrammeServiceDelivery_DistrictCouncils_DistrictCouncilId",
        //                column: x => x.DistrictCouncilId,
        //                principalSchema: "dropdown",
        //                principalTable: "DistrictCouncils",
        //                principalColumn: "Id");
        //            table.ForeignKey(
        //                name: "FK_ProgrammeServiceDelivery_LocalMunicipalities_LocalMunicipalityId",
        //                column: x => x.LocalMunicipalityId,
        //                principalSchema: "dropdown",
        //                principalTable: "LocalMunicipalities",
        //                principalColumn: "Id");
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "Regions",
        //        schema: "dropdown",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            LocalMunicipalityId = table.Column<int>(type: "int", nullable: false),
        //            Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
        //            SystemName = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
        //            CreatedUserId = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1"),
        //            CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
        //            UpdatedUserId = table.Column<int>(type: "int", nullable: true),
        //            UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Regions", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_Regions_LocalMunicipalities_LocalMunicipalityId",
        //                column: x => x.LocalMunicipalityId,
        //                principalSchema: "dropdown",
        //                principalTable: "LocalMunicipalities",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "EmailQueues",
        //        schema: "core",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            EmailTemplateId = table.Column<int>(type: "int", nullable: false),
        //            FromEmailName = table.Column<string>(type: "nvarchar(255)", nullable: false),
        //            FromEmailAddress = table.Column<string>(type: "nvarchar(255)", nullable: false),
        //            Message = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
        //            Subject = table.Column<string>(type: "nvarchar(255)", nullable: false),
        //            RecipientName = table.Column<string>(type: "nvarchar(255)", nullable: false),
        //            RecipientEmail = table.Column<string>(type: "nvarchar(255)", nullable: false),
        //            CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
        //            SentDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_EmailQueues", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_EmailQueues_EmailTemplates_EmailTemplateId",
        //                column: x => x.EmailTemplateId,
        //                principalSchema: "core",
        //                principalTable: "EmailTemplates",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "FacilityList",
        //        schema: "lookup",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            FacilityTypeId = table.Column<int>(type: "int", nullable: false),
        //            FacilitySubDistrictId = table.Column<int>(type: "int", nullable: false),
        //            Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
        //            FacilityClassId = table.Column<int>(type: "int", nullable: false),
        //            Latitude = table.Column<string>(type: "nvarchar(50)", nullable: true),
        //            Longitude = table.Column<string>(type: "nvarchar(50)", nullable: true),
        //            Address = table.Column<string>(type: "nvarchar(255)", nullable: true),
        //            IsNew = table.Column<bool>(type: "bit", nullable: false),
        //            IsActive = table.Column<bool>(type: "bit", nullable: false),
        //            CreatedUserId = table.Column<int>(type: "int", nullable: false),
        //            CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
        //            UpdatedUserId = table.Column<int>(type: "int", nullable: true),
        //            UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_FacilityList", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_FacilityList_FacilityClasses_FacilityClassId",
        //                column: x => x.FacilityClassId,
        //                principalSchema: "dropdown",
        //                principalTable: "FacilityClasses",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //            table.ForeignKey(
        //                name: "FK_FacilityList_FacilitySubDistricts_FacilitySubDistrictId",
        //                column: x => x.FacilitySubDistrictId,
        //                principalSchema: "dropdown",
        //                principalTable: "FacilitySubDistricts",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //            table.ForeignKey(
        //                name: "FK_FacilityList_FacilityTypes_FacilityTypeId",
        //                column: x => x.FacilityTypeId,
        //                principalSchema: "dropdown",
        //                principalTable: "FacilityTypes",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "Questions",
        //        schema: "eval",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            QuestionSectionId = table.Column<int>(type: "int", nullable: false),
        //            ResponseTypeId = table.Column<int>(type: "int", nullable: false),
        //            Name = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
        //            SortOrder = table.Column<int>(type: "int", nullable: false),
        //            IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
        //            CreatedUserId = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1"),
        //            CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
        //            UpdatedUserId = table.Column<int>(type: "int", nullable: true),
        //            UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Questions", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_Questions_QuestionSections_QuestionSectionId",
        //                column: x => x.QuestionSectionId,
        //                principalSchema: "eval",
        //                principalTable: "QuestionSections",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //            table.ForeignKey(
        //                name: "FK_Questions_ResponseTypes_ResponseTypeId",
        //                column: x => x.ResponseTypeId,
        //                principalSchema: "eval",
        //                principalTable: "ResponseTypes",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "Activities",
        //        schema: "dbo",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            ApplicationId = table.Column<int>(type: "int", nullable: false),
        //            ObjectiveId = table.Column<int>(type: "int", nullable: false),
        //            ActivityListId = table.Column<int>(type: "int", nullable: false),
        //            ActivityTypeId = table.Column<int>(type: "int", nullable: false),
        //            TimelineStartDate = table.Column<string>(type: "nvarchar(50)", nullable: true),
        //            TimelineEndDate = table.Column<string>(type: "nvarchar(50)", nullable: true),
        //            Target = table.Column<int>(type: "int", nullable: false),
        //            SuccessIndicator = table.Column<string>(type: "nvarchar(255)", nullable: true),
        //            FinancialYear = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            Quarter = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            IsActive = table.Column<bool>(type: "bit", nullable: false),
        //            CreatedUserId = table.Column<int>(type: "int", nullable: false),
        //            CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
        //            UpdatedUserId = table.Column<int>(type: "int", nullable: true),
        //            UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
        //            ChangesRequired = table.Column<bool>(type: "bit", nullable: true),
        //            IsNew = table.Column<bool>(type: "bit", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Activities", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_Activities_ActivityList_ActivityListId",
        //                column: x => x.ActivityListId,
        //                principalSchema: "lookup",
        //                principalTable: "ActivityList",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //            table.ForeignKey(
        //                name: "FK_Activities_ActivityTypes_ActivityTypeId",
        //                column: x => x.ActivityTypeId,
        //                principalSchema: "dropdown",
        //                principalTable: "ActivityTypes",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //            table.ForeignKey(
        //                name: "FK_Activities_Objectives_ObjectiveId",
        //                column: x => x.ObjectiveId,
        //                principalSchema: "dbo",
        //                principalTable: "Objectives",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "Objectives_Programmes",
        //        schema: "mapping",
        //        columns: table => new
        //        {
        //            ObjectiveId = table.Column<int>(type: "int", nullable: false),
        //            ProgrammeId = table.Column<int>(type: "int", nullable: false),
        //            SubProgrammeId = table.Column<int>(type: "int", nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Objectives_Programmes", x => new { x.ObjectiveId, x.ProgrammeId, x.SubProgrammeId });
        //            table.ForeignKey(
        //                name: "FK_Objectives_Programmes_Objectives_ObjectiveId",
        //                column: x => x.ObjectiveId,
        //                principalSchema: "dbo",
        //                principalTable: "Objectives",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //            table.ForeignKey(
        //                name: "FK_Objectives_Programmes_Programmes_ProgrammeId",
        //                column: x => x.ProgrammeId,
        //                principalSchema: "dropdown",
        //                principalTable: "Programmes",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //            table.ForeignKey(
        //                name: "FK_Objectives_Programmes_SubProgrammes_SubProgrammeId",
        //                column: x => x.SubProgrammeId,
        //                principalSchema: "dropdown",
        //                principalTable: "SubProgrammes",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "SubRecipients",
        //        schema: "dbo",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            ObjectiveId = table.Column<int>(type: "int", nullable: false),
        //            OrganisationName = table.Column<string>(type: "nvarchar(255)", nullable: true),
        //            FundingPeriodStartDate = table.Column<string>(type: "nvarchar(50)", nullable: true),
        //            FundingPeriodEndDate = table.Column<string>(type: "nvarchar(50)", nullable: true),
        //            Budget = table.Column<decimal>(type: "numeric(18,6)", nullable: false),
        //            RecipientTypeId = table.Column<int>(type: "int", nullable: false),
        //            IsActive = table.Column<bool>(type: "bit", nullable: false),
        //            CreatedUserId = table.Column<int>(type: "int", nullable: false),
        //            CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
        //            UpdatedUserId = table.Column<int>(type: "int", nullable: true),
        //            UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_SubRecipients", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_SubRecipients_Objectives_ObjectiveId",
        //                column: x => x.ObjectiveId,
        //                principalSchema: "dbo",
        //                principalTable: "Objectives",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "Applications",
        //        schema: "dbo",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            RefNo = table.Column<string>(type: "char(15)", nullable: true),
        //            NpoId = table.Column<int>(type: "int", nullable: false),
        //            ApplicationPeriodId = table.Column<int>(type: "int", nullable: false),
        //            StatusId = table.Column<int>(type: "int", nullable: false),
        //            IsActive = table.Column<bool>(type: "bit", nullable: false),
        //            CreatedUserId = table.Column<int>(type: "int", nullable: false),
        //            CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
        //            UpdatedUserId = table.Column<int>(type: "int", nullable: true),
        //            UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
        //            IsCloned = table.Column<bool>(type: "bit", nullable: false),
        //            IsQuickCapture = table.Column<bool>(type: "bit", nullable: false),
        //            Step = table.Column<int>(type: "int", nullable: false),
        //            InitiateScorecard = table.Column<int>(type: "int", nullable: false),
        //            CloseScorecard = table.Column<int>(type: "int", nullable: false),
        //            ScorecardCount = table.Column<int>(type: "int", nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Applications", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_Applications_ApplicationPeriods_ApplicationPeriodId",
        //                column: x => x.ApplicationPeriodId,
        //                principalSchema: "dbo",
        //                principalTable: "ApplicationPeriods",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //            table.ForeignKey(
        //                name: "FK_Applications_Npos_NpoId",
        //                column: x => x.NpoId,
        //                principalSchema: "dbo",
        //                principalTable: "Npos",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //            table.ForeignKey(
        //                name: "FK_Applications_Statuses_StatusId",
        //                column: x => x.StatusId,
        //                principalSchema: "dbo",
        //                principalTable: "Statuses",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "ContactInformation",
        //        schema: "dbo",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            NpoId = table.Column<int>(type: "int", nullable: false),
        //            TitleId = table.Column<int>(type: "int", nullable: false),
        //            FirstName = table.Column<string>(type: "nvarchar(255)", nullable: true),
        //            LastName = table.Column<string>(type: "nvarchar(255)", nullable: true),
        //            RSAIdNumber = table.Column<bool>(type: "bit", nullable: false),
        //            IdNumber = table.Column<string>(type: "nvarchar(13)", nullable: true),
        //            PassportNumber = table.Column<string>(type: "nvarchar(50)", nullable: true),
        //            EmailAddress = table.Column<string>(type: "nvarchar(255)", nullable: true),
        //            Telephone = table.Column<string>(type: "nvarchar(50)", nullable: true),
        //            Cellphone = table.Column<string>(type: "nvarchar(50)", nullable: true),
        //            PositionId = table.Column<int>(type: "int", nullable: false),
        //            Comments = table.Column<string>(type: "nvarchar(1000)", nullable: true),
        //            IsPrimaryContact = table.Column<bool>(type: "bit", nullable: true),
        //            IsDisabled = table.Column<bool>(type: "bit", nullable: true),
        //            IsBoardMember = table.Column<bool>(type: "bit", nullable: true),
        //            IsSignatory = table.Column<bool>(type: "bit", nullable: true),
        //            IsWrittenAgreementSignatory = table.Column<bool>(type: "bit", nullable: true),
        //            YearsOfExperience = table.Column<int>(type: "int", nullable: true),
        //            RaceId = table.Column<int>(type: "int", nullable: true),
        //            GenderId = table.Column<int>(type: "int", nullable: true),
        //            LanguageId = table.Column<int>(type: "int", nullable: true),
        //            DateOfEmployment = table.Column<DateTime>(type: "datetime2", nullable: true),
        //            Qualifications = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            AddressInformation = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            IsActive = table.Column<bool>(type: "bit", nullable: false),
        //            CreatedUserId = table.Column<int>(type: "int", nullable: false),
        //            CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
        //            UpdatedUserId = table.Column<int>(type: "int", nullable: true),
        //            UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_ContactInformation", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_ContactInformation_Gender_GenderId",
        //                column: x => x.GenderId,
        //                principalSchema: "dropdown",
        //                principalTable: "Gender",
        //                principalColumn: "Id");
        //            table.ForeignKey(
        //                name: "FK_ContactInformation_Languages_LanguageId",
        //                column: x => x.LanguageId,
        //                principalSchema: "dropdown",
        //                principalTable: "Languages",
        //                principalColumn: "Id");
        //            table.ForeignKey(
        //                name: "FK_ContactInformation_Npos_NpoId",
        //                column: x => x.NpoId,
        //                principalSchema: "dbo",
        //                principalTable: "Npos",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //            table.ForeignKey(
        //                name: "FK_ContactInformation_Positions_PositionId",
        //                column: x => x.PositionId,
        //                principalSchema: "dropdown",
        //                principalTable: "Positions",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //            table.ForeignKey(
        //                name: "FK_ContactInformation_Races_RaceId",
        //                column: x => x.RaceId,
        //                principalSchema: "dropdown",
        //                principalTable: "Races",
        //                principalColumn: "Id");
        //            table.ForeignKey(
        //                name: "FK_ContactInformation_Titles_TitleId",
        //                column: x => x.TitleId,
        //                principalSchema: "dropdown",
        //                principalTable: "Titles",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "NpoProfiles",
        //        schema: "dbo",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            NpoId = table.Column<int>(type: "int", nullable: false),
        //            RefNo = table.Column<string>(type: "char(15)", nullable: true),
        //            IsActive = table.Column<bool>(type: "bit", nullable: false),
        //            CreatedUserId = table.Column<int>(type: "int", nullable: false),
        //            CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
        //            UpdatedUserId = table.Column<int>(type: "int", nullable: true),
        //            UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
        //            AccessStatusId = table.Column<int>(type: "int", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_NpoProfiles", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_NpoProfiles_AccessStatuses_AccessStatusId",
        //                column: x => x.AccessStatusId,
        //                principalSchema: "dbo",
        //                principalTable: "AccessStatuses",
        //                principalColumn: "Id");
        //            table.ForeignKey(
        //                name: "FK_NpoProfiles_Npos_NpoId",
        //                column: x => x.NpoId,
        //                principalSchema: "dbo",
        //                principalTable: "Npos",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "Users_Npos",
        //        schema: "mapping",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            UserId = table.Column<int>(type: "int", nullable: false),
        //            NpoId = table.Column<int>(type: "int", nullable: false),
        //            AccessStatusId = table.Column<int>(type: "int", nullable: false),
        //            CreatedUserId = table.Column<int>(type: "int", nullable: false),
        //            CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
        //            UpdatedUserId = table.Column<int>(type: "int", nullable: true),
        //            UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Users_Npos", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_Users_Npos_AccessStatuses_AccessStatusId",
        //                column: x => x.AccessStatusId,
        //                principalSchema: "dbo",
        //                principalTable: "AccessStatuses",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //            table.ForeignKey(
        //                name: "FK_Users_Npos_Npos_NpoId",
        //                column: x => x.NpoId,
        //                principalSchema: "dbo",
        //                principalTable: "Npos",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //            table.ForeignKey(
        //                name: "FK_Users_Npos_Users_CreatedUserId",
        //                column: x => x.CreatedUserId,
        //                principalSchema: "core",
        //                principalTable: "Users",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //            table.ForeignKey(
        //                name: "FK_Users_Npos_Users_UpdatedUserId",
        //                column: x => x.UpdatedUserId,
        //                principalSchema: "core",
        //                principalTable: "Users",
        //                principalColumn: "Id");
        //            table.ForeignKey(
        //                name: "FK_Users_Npos_Users_UserId",
        //                column: x => x.UserId,
        //                principalSchema: "core",
        //                principalTable: "Users",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "FundAppSDADetail",
        //        schema: "fa",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            RegionId = table.Column<int>(type: "int", nullable: true),
        //            DistrictCouncilId = table.Column<int>(type: "int", nullable: false),
        //            LocalMunicipalityId = table.Column<int>(type: "int", nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_FundAppSDADetail", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_FundAppSDADetail_DistrictCouncils_DistrictCouncilId",
        //                column: x => x.DistrictCouncilId,
        //                principalSchema: "dropdown",
        //                principalTable: "DistrictCouncils",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //            table.ForeignKey(
        //                name: "FK_FundAppSDADetail_LocalMunicipalities_LocalMunicipalityId",
        //                column: x => x.LocalMunicipalityId,
        //                principalSchema: "dropdown",
        //                principalTable: "LocalMunicipalities",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //            table.ForeignKey(
        //                name: "FK_FundAppSDADetail_Regions_RegionId",
        //                column: x => x.RegionId,
        //                principalSchema: "dropdown",
        //                principalTable: "Regions",
        //                principalColumn: "Id");
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "ProgrammeSDADetail_Regions",
        //        schema: "mapping",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            IsActive = table.Column<bool>(type: "bit", nullable: false),
        //            ProgrameServiceDeliveryId = table.Column<int>(type: "int", nullable: false),
        //            RegionId = table.Column<int>(type: "int", nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_ProgrammeSDADetail_Regions", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_ProgrammeSDADetail_Regions_ProgrammeServiceDelivery_ProgrameServiceDeliveryId",
        //                column: x => x.ProgrameServiceDeliveryId,
        //                principalSchema: "dbo",
        //                principalTable: "ProgrammeServiceDelivery",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //            table.ForeignKey(
        //                name: "FK_ProgrammeSDADetail_Regions_Regions_RegionId",
        //                column: x => x.RegionId,
        //                principalSchema: "dropdown",
        //                principalTable: "Regions",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "ServiceDeliveryAreas",
        //        schema: "dropdown",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            RegionId = table.Column<int>(type: "int", nullable: false),
        //            Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
        //            SystemName = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
        //            CreatedUserId = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1"),
        //            CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
        //            UpdatedUserId = table.Column<int>(type: "int", nullable: true),
        //            UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
        //            ExternalId = table.Column<int>(type: "int", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_ServiceDeliveryAreas", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_ServiceDeliveryAreas_Regions_RegionId",
        //                column: x => x.RegionId,
        //                principalSchema: "dropdown",
        //                principalTable: "Regions",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "NpoProfiles_FacilityLists",
        //        schema: "mapping",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            NpoProfileId = table.Column<int>(type: "int", nullable: false),
        //            FacilityListId = table.Column<int>(type: "int", nullable: false),
        //            IsActive = table.Column<bool>(type: "bit", nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_NpoProfiles_FacilityLists", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_NpoProfiles_FacilityLists_FacilityList_FacilityListId",
        //                column: x => x.FacilityListId,
        //                principalSchema: "lookup",
        //                principalTable: "FacilityList",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "QuestionProperties",
        //        schema: "eval",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            QuestionId = table.Column<int>(type: "int", nullable: false),
        //            HasComment = table.Column<bool>(type: "bit", nullable: false),
        //            CommentRequired = table.Column<bool>(type: "bit", nullable: false),
        //            HasDocument = table.Column<bool>(type: "bit", nullable: false),
        //            DocumentRequired = table.Column<bool>(type: "bit", nullable: false),
        //            Weighting = table.Column<int>(type: "int", nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_QuestionProperties", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_QuestionProperties_Questions_QuestionId",
        //                column: x => x.QuestionId,
        //                principalSchema: "eval",
        //                principalTable: "Questions",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "Responses",
        //        schema: "eval",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            FundingApplicationId = table.Column<int>(type: "int", nullable: false),
        //            QuestionId = table.Column<int>(type: "int", nullable: false),
        //            ResponseOptionId = table.Column<int>(type: "int", nullable: false),
        //            Comment = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
        //            RejectionComment = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
        //            RejectionFlag = table.Column<int>(type: "int", nullable: false),
        //            RejectedByUserId = table.Column<int>(type: "int", nullable: false),
        //            ReviewerCategoryComment = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
        //            MainReviewerCategoryComment = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
        //            CreatedUserId = table.Column<int>(type: "int", nullable: false),
        //            CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
        //            UpdatedUserId = table.Column<int>(type: "int", nullable: true),
        //            UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Responses", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_Responses_Questions_QuestionId",
        //                column: x => x.QuestionId,
        //                principalSchema: "eval",
        //                principalTable: "Questions",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //            table.ForeignKey(
        //                name: "FK_Responses_ResponseOptions_ResponseOptionId",
        //                column: x => x.ResponseOptionId,
        //                principalSchema: "eval",
        //                principalTable: "ResponseOptions",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //            table.ForeignKey(
        //                name: "FK_Responses_Users_CreatedUserId",
        //                column: x => x.CreatedUserId,
        //                principalSchema: "core",
        //                principalTable: "Users",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "Activities_FacilityLists",
        //        schema: "mapping",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            ActivityId = table.Column<int>(type: "int", nullable: false),
        //            FacilityListId = table.Column<int>(type: "int", nullable: false),
        //            IsActive = table.Column<bool>(type: "bit", nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Activities_FacilityLists", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_Activities_FacilityLists_Activities_ActivityId",
        //                column: x => x.ActivityId,
        //                principalSchema: "dbo",
        //                principalTable: "Activities",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //            table.ForeignKey(
        //                name: "FK_Activities_FacilityLists_FacilityList_FacilityListId",
        //                column: x => x.FacilityListId,
        //                principalSchema: "lookup",
        //                principalTable: "FacilityList",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "Activities_Recipients",
        //        schema: "mapping",
        //        columns: table => new
        //        {
        //            ActivityId = table.Column<int>(type: "int", nullable: false),
        //            RecipientTypeId = table.Column<int>(type: "int", nullable: false),
        //            EntityId = table.Column<int>(type: "int", nullable: false),
        //            Entity = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            RecipientName = table.Column<string>(type: "nvarchar(max)", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Activities_Recipients", x => new { x.ActivityId, x.EntityId, x.RecipientTypeId });
        //            table.ForeignKey(
        //                name: "FK_Activities_Recipients_Activities_ActivityId",
        //                column: x => x.ActivityId,
        //                principalSchema: "dbo",
        //                principalTable: "Activities",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "Activities_SubProgrammes",
        //        schema: "mapping",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            ActivityId = table.Column<int>(type: "int", nullable: false),
        //            SubProgrammeId = table.Column<int>(type: "int", nullable: false),
        //            IsActive = table.Column<bool>(type: "bit", nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Activities_SubProgrammes", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_Activities_SubProgrammes_Activities_ActivityId",
        //                column: x => x.ActivityId,
        //                principalSchema: "dbo",
        //                principalTable: "Activities",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //            table.ForeignKey(
        //                name: "FK_Activities_SubProgrammes_SubProgrammes_SubProgrammeId",
        //                column: x => x.SubProgrammeId,
        //                principalSchema: "dropdown",
        //                principalTable: "SubProgrammes",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "Resources",
        //        schema: "dbo",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            ApplicationId = table.Column<int>(type: "int", nullable: false),
        //            ActivityId = table.Column<int>(type: "int", nullable: false),
        //            ResourceTypeId = table.Column<int>(type: "int", nullable: false),
        //            ServiceTypeId = table.Column<int>(type: "int", nullable: false),
        //            AllocationTypeId = table.Column<int>(type: "int", nullable: false),
        //            Description = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
        //            ProvisionTypeId = table.Column<int>(type: "int", nullable: false),
        //            ResourceListId = table.Column<int>(type: "int", nullable: false),
        //            NumberOfResources = table.Column<int>(type: "int", nullable: false),
        //            IsActive = table.Column<bool>(type: "bit", nullable: false),
        //            CreatedUserId = table.Column<int>(type: "int", nullable: false),
        //            CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
        //            UpdatedUserId = table.Column<int>(type: "int", nullable: true),
        //            UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
        //            ChangesRequired = table.Column<bool>(type: "bit", nullable: true),
        //            IsNew = table.Column<bool>(type: "bit", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Resources", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_Resources_Activities_ActivityId",
        //                column: x => x.ActivityId,
        //                principalSchema: "dbo",
        //                principalTable: "Activities",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //            table.ForeignKey(
        //                name: "FK_Resources_AllocationTypes_AllocationTypeId",
        //                column: x => x.AllocationTypeId,
        //                principalSchema: "dropdown",
        //                principalTable: "AllocationTypes",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //            table.ForeignKey(
        //                name: "FK_Resources_ProvisionTypes_ProvisionTypeId",
        //                column: x => x.ProvisionTypeId,
        //                principalSchema: "dropdown",
        //                principalTable: "ProvisionTypes",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //            table.ForeignKey(
        //                name: "FK_Resources_ResourceList_ResourceListId",
        //                column: x => x.ResourceListId,
        //                principalSchema: "lookup",
        //                principalTable: "ResourceList",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //            table.ForeignKey(
        //                name: "FK_Resources_ResourceTypes_ResourceTypeId",
        //                column: x => x.ResourceTypeId,
        //                principalSchema: "dropdown",
        //                principalTable: "ResourceTypes",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //            table.ForeignKey(
        //                name: "FK_Resources_ServiceTypes_ServiceTypeId",
        //                column: x => x.ServiceTypeId,
        //                principalSchema: "dropdown",
        //                principalTable: "ServiceTypes",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "SustainabilityPlans",
        //        schema: "dbo",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            ApplicationId = table.Column<int>(type: "int", nullable: false),
        //            ActivityId = table.Column<int>(type: "int", nullable: false),
        //            Description = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
        //            Risk = table.Column<string>(type: "nvarchar(1000)", nullable: true),
        //            Mitigation = table.Column<string>(type: "nvarchar(1000)", nullable: true),
        //            IsActive = table.Column<bool>(type: "bit", nullable: false),
        //            CreatedUserId = table.Column<int>(type: "int", nullable: false),
        //            CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
        //            UpdatedUserId = table.Column<int>(type: "int", nullable: true),
        //            UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
        //            ChangesRequired = table.Column<bool>(type: "bit", nullable: true),
        //            IsNew = table.Column<bool>(type: "bit", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_SustainabilityPlans", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_SustainabilityPlans_Activities_ActivityId",
        //                column: x => x.ActivityId,
        //                principalSchema: "dbo",
        //                principalTable: "Activities",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "SubSubRecipients",
        //        schema: "dbo",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            SubRecipientId = table.Column<int>(type: "int", nullable: false),
        //            OrganisationName = table.Column<string>(type: "nvarchar(255)", nullable: true),
        //            FundingPeriodStartDate = table.Column<string>(type: "nvarchar(50)", nullable: true),
        //            FundingPeriodEndDate = table.Column<string>(type: "nvarchar(50)", nullable: true),
        //            Budget = table.Column<decimal>(type: "numeric(18,6)", nullable: false),
        //            RecipientTypeId = table.Column<int>(type: "int", nullable: false),
        //            IsActive = table.Column<bool>(type: "bit", nullable: false),
        //            CreatedUserId = table.Column<int>(type: "int", nullable: false),
        //            CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
        //            UpdatedUserId = table.Column<int>(type: "int", nullable: true),
        //            UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_SubSubRecipients", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_SubSubRecipients_SubRecipients_SubRecipientId",
        //                column: x => x.SubRecipientId,
        //                principalSchema: "dbo",
        //                principalTable: "SubRecipients",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "NpoUserTrackings",
        //        schema: "dbo",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            ApplicationId = table.Column<int>(type: "int", nullable: false),
        //            UserId = table.Column<int>(type: "int", nullable: false),
        //            SentDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_NpoUserTrackings", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_NpoUserTrackings_Applications_ApplicationId",
        //                column: x => x.ApplicationId,
        //                principalSchema: "dbo",
        //                principalTable: "Applications",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "AddressInformation",
        //        schema: "dbo",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            NpoProfileId = table.Column<int>(type: "int", nullable: false),
        //            PhysicalAddress = table.Column<string>(type: "nvarchar(255)", nullable: true),
        //            PostalSameAsPhysical = table.Column<bool>(type: "bit", nullable: true),
        //            PostalAddress = table.Column<string>(type: "nvarchar(255)", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_AddressInformation", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_AddressInformation_NpoProfiles_NpoProfileId",
        //                column: x => x.NpoProfileId,
        //                principalSchema: "dbo",
        //                principalTable: "NpoProfiles",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "ApplicationDetails",
        //        schema: "fa",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            FundAppSDADetailId = table.Column<int>(type: "int", nullable: false),
        //            AmountApplyingFor = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_ApplicationDetails", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_ApplicationDetails_FundAppSDADetail_FundAppSDADetailId",
        //                column: x => x.FundAppSDADetailId,
        //                principalSchema: "fa",
        //                principalTable: "FundAppSDADetail",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "FundAppSDADetail_Regions",
        //        schema: "mapping",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            IsActive = table.Column<bool>(type: "bit", nullable: false),
        //            FundAppSDADetailId = table.Column<int>(type: "int", nullable: false),
        //            RegionId = table.Column<int>(type: "int", nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_FundAppSDADetail_Regions", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_FundAppSDADetail_Regions_FundAppSDADetail_FundAppSDADetailId",
        //                column: x => x.FundAppSDADetailId,
        //                principalSchema: "fa",
        //                principalTable: "FundAppSDADetail",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //            table.ForeignKey(
        //                name: "FK_FundAppSDADetail_Regions_Regions_RegionId",
        //                column: x => x.RegionId,
        //                principalSchema: "dropdown",
        //                principalTable: "Regions",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "Places",
        //        schema: "dropdown",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            SystemName = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            ServiceDeliveryAreaId = table.Column<int>(type: "int", nullable: false),
        //            IsActive = table.Column<bool>(type: "bit", nullable: false),
        //            CreatedUserId = table.Column<int>(type: "int", nullable: false),
        //            CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
        //            UpdatedUserId = table.Column<int>(type: "int", nullable: true),
        //            ExternalId = table.Column<int>(type: "int", nullable: true),
        //            UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Places", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_Places_ServiceDeliveryAreas_ServiceDeliveryAreaId",
        //                column: x => x.ServiceDeliveryAreaId,
        //                principalSchema: "dropdown",
        //                principalTable: "ServiceDeliveryAreas",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "ProgrameServiceDeliveryAreas",
        //        schema: "mapping",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            IsActive = table.Column<bool>(type: "bit", nullable: false),
        //            ProgrameServiceDeliveryId = table.Column<int>(type: "int", nullable: false),
        //            ServiceDeliveryAreaId = table.Column<int>(type: "int", nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_ProgrameServiceDeliveryAreas", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_ProgrameServiceDeliveryAreas_ProgrammeServiceDelivery_ProgrameServiceDeliveryId",
        //                column: x => x.ProgrameServiceDeliveryId,
        //                principalSchema: "dbo",
        //                principalTable: "ProgrammeServiceDelivery",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //            table.ForeignKey(
        //                name: "FK_ProgrameServiceDeliveryAreas_ServiceDeliveryAreas_ServiceDeliveryAreaId",
        //                column: x => x.ServiceDeliveryAreaId,
        //                principalSchema: "dropdown",
        //                principalTable: "ServiceDeliveryAreas",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "ServiceDeliveryAreas",
        //        schema: "mapping",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            FundAppSDADetailId = table.Column<int>(type: "int", nullable: false),
        //            IsActive = table.Column<bool>(type: "bit", nullable: false),
        //            ServiceDeliveryAreaId = table.Column<int>(type: "int", nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_ServiceDeliveryAreas", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_ServiceDeliveryAreas_FundAppSDADetail_FundAppSDADetailId",
        //                column: x => x.FundAppSDADetailId,
        //                principalSchema: "fa",
        //                principalTable: "FundAppSDADetail",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //            table.ForeignKey(
        //                name: "FK_ServiceDeliveryAreas_ServiceDeliveryAreas_ServiceDeliveryAreaId",
        //                column: x => x.ServiceDeliveryAreaId,
        //                principalSchema: "dropdown",
        //                principalTable: "ServiceDeliveryAreas",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "FundingApplicationDetails",
        //        schema: "fa",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            ApplicationPeriodId = table.Column<int>(type: "int", nullable: false),
        //            ProjectInformationId = table.Column<int>(type: "int", nullable: true),
        //            ApplicationId = table.Column<int>(type: "int", nullable: false),
        //            MonitoringEvaluationId = table.Column<int>(type: "int", nullable: true),
        //            ApplicationDetailId = table.Column<int>(type: "int", nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_FundingApplicationDetails", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_FundingApplicationDetails_ApplicationDetails_ApplicationDetailId",
        //                column: x => x.ApplicationDetailId,
        //                principalSchema: "fa",
        //                principalTable: "ApplicationDetails",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //            table.ForeignKey(
        //                name: "FK_FundingApplicationDetails_ApplicationPeriods_ApplicationPeriodId",
        //                column: x => x.ApplicationPeriodId,
        //                principalSchema: "dbo",
        //                principalTable: "ApplicationPeriods",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //            table.ForeignKey(
        //                name: "FK_FundingApplicationDetails_MonitoringEvaluation_MonitoringEvaluationId",
        //                column: x => x.MonitoringEvaluationId,
        //                principalSchema: "fa",
        //                principalTable: "MonitoringEvaluation",
        //                principalColumn: "Id");
        //            table.ForeignKey(
        //                name: "FK_FundingApplicationDetails_ProjectInformation_ProjectInformationId",
        //                column: x => x.ProjectInformationId,
        //                principalSchema: "fa",
        //                principalTable: "ProjectInformation",
        //                principalColumn: "Id");
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "SubPlaces",
        //        schema: "dropdown",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            SystemName = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            PlaceId = table.Column<int>(type: "int", nullable: false),
        //            IsActive = table.Column<bool>(type: "bit", nullable: false),
        //            CreatedUserId = table.Column<int>(type: "int", nullable: false),
        //            CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
        //            UpdatedUserId = table.Column<int>(type: "int", nullable: true),
        //            ExternalId = table.Column<int>(type: "int", nullable: true),
        //            UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_SubPlaces", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_SubPlaces_Places_PlaceId",
        //                column: x => x.PlaceId,
        //                principalSchema: "dropdown",
        //                principalTable: "Places",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "FinancialMatters",
        //        schema: "fa",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            Property = table.Column<string>(type: "nvarchar(50)", nullable: true),
        //            AmountOne = table.Column<decimal>(type: "numeric(18,6)", nullable: false),
        //            AmountTwo = table.Column<decimal>(type: "numeric(18,6)", nullable: false),
        //            AmountThree = table.Column<decimal>(type: "numeric(18,6)", nullable: false),
        //            TotalFundingAmount = table.Column<int>(type: "int", nullable: false),
        //            FundingApplicationDetailId = table.Column<int>(type: "int", nullable: true),
        //            IsActive = table.Column<bool>(type: "bit", nullable: true),
        //            CreatedUserId = table.Column<int>(type: "int", nullable: true),
        //            CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
        //            UpdatedUserId = table.Column<int>(type: "int", nullable: true),
        //            UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
        //            ChangesRequired = table.Column<bool>(type: "bit", nullable: true),
        //            IsNew = table.Column<bool>(type: "bit", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_FinancialMatters", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_FinancialMatters_FundingApplicationDetails_FundingApplicationDetailId",
        //                column: x => x.FundingApplicationDetailId,
        //                principalSchema: "fa",
        //                principalTable: "FundingApplicationDetails",
        //                principalColumn: "Id");
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "FinancialMattersExpenditure",
        //        schema: "fa",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            npoProfileId = table.Column<int>(type: "int", nullable: false),
        //            ExpenditureDescription = table.Column<string>(type: "nvarchar(255)", nullable: true),
        //            AmountOneE = table.Column<decimal>(type: "numeric(18,6)", nullable: false),
        //            AmountTwoE = table.Column<decimal>(type: "numeric(18,6)", nullable: false),
        //            AmountThreeE = table.Column<decimal>(type: "numeric(18,6)", nullable: false),
        //            TotalFundingAmountE = table.Column<int>(type: "int", nullable: false),
        //            FundingApplicationDetailId = table.Column<int>(type: "int", nullable: true),
        //            Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            IsActive = table.Column<bool>(type: "bit", nullable: false),
        //            CreatedUserId = table.Column<int>(type: "int", nullable: false),
        //            CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
        //            UpdatedUserId = table.Column<int>(type: "int", nullable: true),
        //            UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_FinancialMattersExpenditure", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_FinancialMattersExpenditure_FundingApplicationDetails_FundingApplicationDetailId",
        //                column: x => x.FundingApplicationDetailId,
        //                principalSchema: "fa",
        //                principalTable: "FundingApplicationDetails",
        //                principalColumn: "Id");
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "FinancialMattersIncome",
        //        schema: "fa",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            npoProfileId = table.Column<int>(type: "int", nullable: false),
        //            IncomeDescription = table.Column<string>(type: "nvarchar(50)", nullable: true),
        //            AmountOneI = table.Column<decimal>(type: "numeric(18,6)", nullable: false),
        //            AmountTwoI = table.Column<decimal>(type: "numeric(18,6)", nullable: false),
        //            AmountThreeI = table.Column<decimal>(type: "numeric(18,6)", nullable: false),
        //            TotalFundingAmountI = table.Column<int>(type: "int", nullable: false),
        //            FundingApplicationDetailId = table.Column<int>(type: "int", nullable: true),
        //            Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            IsActive = table.Column<bool>(type: "bit", nullable: false),
        //            CreatedUserId = table.Column<int>(type: "int", nullable: false),
        //            CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
        //            UpdatedUserId = table.Column<int>(type: "int", nullable: true),
        //            UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_FinancialMattersIncome", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_FinancialMattersIncome_FundingApplicationDetails_FundingApplicationDetailId",
        //                column: x => x.FundingApplicationDetailId,
        //                principalSchema: "fa",
        //                principalTable: "FundingApplicationDetails",
        //                principalColumn: "Id");
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "FinancialMattersOthers",
        //        schema: "fa",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            npoProfileId = table.Column<int>(type: "int", nullable: false),
        //            OtherDescription = table.Column<string>(type: "nvarchar(255)", nullable: true),
        //            AmountOneO = table.Column<decimal>(type: "numeric(18,6)", nullable: false),
        //            AmountTwoO = table.Column<decimal>(type: "numeric(18,6)", nullable: false),
        //            AmountThreeO = table.Column<decimal>(type: "numeric(18,6)", nullable: false),
        //            TotalFundingAmountO = table.Column<int>(type: "int", nullable: false),
        //            FundingApplicationDetailId = table.Column<int>(type: "int", nullable: true),
        //            Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            IsActive = table.Column<bool>(type: "bit", nullable: false),
        //            CreatedUserId = table.Column<int>(type: "int", nullable: false),
        //            CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
        //            UpdatedUserId = table.Column<int>(type: "int", nullable: true),
        //            UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_FinancialMattersOthers", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_FinancialMattersOthers_FundingApplicationDetails_FundingApplicationDetailId",
        //                column: x => x.FundingApplicationDetailId,
        //                principalSchema: "fa",
        //                principalTable: "FundingApplicationDetails",
        //                principalColumn: "Id");
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "ProjectImplementations",
        //        schema: "fa",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            NpoProfileId = table.Column<int>(type: "int", nullable: false),
        //            Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            ProjectObjective = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            Beneficiaries = table.Column<int>(type: "int", nullable: false),
        //            TimeframeFrom = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            TimeframeTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            Results = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            Resources = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            BudgetAmount = table.Column<int>(type: "int", nullable: false),
        //            FundingApplicationDetailId = table.Column<int>(type: "int", nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_ProjectImplementations", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_ProjectImplementations_FundingApplicationDetails_FundingApplicationDetailId",
        //                column: x => x.FundingApplicationDetailId,
        //                principalSchema: "fa",
        //                principalTable: "FundingApplicationDetails",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "Project_Implementation_Places",
        //        schema: "mapping",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            ImplementationId = table.Column<int>(type: "int", nullable: false),
        //            PlaceId = table.Column<int>(type: "int", nullable: false),
        //            IsActive = table.Column<bool>(type: "bit", nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Project_Implementation_Places", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_Project_Implementation_Places_Places_PlaceId",
        //                column: x => x.PlaceId,
        //                principalSchema: "dropdown",
        //                principalTable: "Places",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //            table.ForeignKey(
        //                name: "FK_Project_Implementation_Places_ProjectImplementations_ImplementationId",
        //                column: x => x.ImplementationId,
        //                principalSchema: "fa",
        //                principalTable: "ProjectImplementations",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "Project_Implementation_SubPlaces",
        //        schema: "mapping",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            ImplementationId = table.Column<int>(type: "int", nullable: false),
        //            SubPlaceId = table.Column<int>(type: "int", nullable: false),
        //            IsActive = table.Column<bool>(type: "bit", nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Project_Implementation_SubPlaces", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_Project_Implementation_SubPlaces_ProjectImplementations_ImplementationId",
        //                column: x => x.ImplementationId,
        //                principalSchema: "fa",
        //                principalTable: "ProjectImplementations",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //            table.ForeignKey(
        //                name: "FK_Project_Implementation_SubPlaces_SubPlaces_SubPlaceId",
        //                column: x => x.SubPlaceId,
        //                principalSchema: "dropdown",
        //                principalTable: "SubPlaces",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.InsertData(
        //        schema: "dbo",
        //        table: "AccessStatuses",
        //        columns: new[] { "Id", "Name", "SystemName", "UpdatedDateTime", "UpdatedUserId" },
        //        values: new object[,]
        //        {
        //            { 1, "Pending", "Pending", null, null },
        //            { 2, "Approved", "Approved", null, null },
        //            { 3, "Rejected", "Rejected", null, null },
        //            { 4, "New", "New", null, null }
        //        });

        //    migrationBuilder.InsertData(
        //        schema: "dropdown",
        //        table: "AccountTypes",
        //        columns: new[] { "Id", "Name", "SystemName", "UpdatedDateTime", "UpdatedUserId" },
        //        values: new object[,]
        //        {
        //            { 1, "SAVINGS", null, null, null },
        //            { 2, "CURRENT", null, null, null },
        //            { 3, "TRANSMISSION", null, null, null },
        //            { 4, "Subscription Share", null, null, null },
        //            { 5, "BOND", null, null, null }
        //        });

        //    migrationBuilder.InsertData(
        //        schema: "lookup",
        //        table: "ActivityList",
        //        columns: new[] { "Id", "Description", "Name", "UpdatedDateTime", "UpdatedUserId" },
        //        values: new object[,]
        //        {
        //            { 1, "Quarterly reports", "Quarterly reports", null, null },
        //            { 2, "Quarterly stakeholder engagements", "Quarterly stakeholder engagements", null, null },
        //            { 3, "Provision of resources", "Provision of resources", null, null },
        //            { 4, "Capacity Development", "Capacity Development", null, null },
        //            { 5, "Monitoring and Evaluation", "Monitoring and Evaluation", null, null },
        //            { 6, "Quality Improvement", "Quality Improvement", null, null },
        //            { 7, "Implementation of Human Rights activities", "Implementation of Human Rights activities", null, null },
        //            { 8, "Advocacy", "Advocacy", null, null },
        //            { 9, "GP referrals", "GP referrals", null, null },
        //            { 10, "Engagement with taxi industry", "Engagement with taxi industry", null, null },
        //            { 11, "Awareness campaigns", "Awareness campaigns", null, null },
        //            { 12, "HIV Testing", "HIV Testing", null, null },
        //            { 13, "Health Screening", "Health Screening", null, null },
        //            { 14, "Introduction of self-screening", "Introduction of self-screening", null, null },
        //            { 15, "Reduce Stima & Discrimination", "Reduce Stima & Discrimination", null, null },
        //            { 16, "Provide Legal Support", "Provide Legal Support", null, null },
        //            { 17, "Distribution of posters, leaflets and pamphlets", "Distribution of posters, leaflets and pamphlets", null, null },
        //            { 18, "Advocacy for People Who use and inject Drugs (PWID)", "Advocacy for PWID", null, null },
        //            { 19, "Decriminalisation of Sex Work ", "Decriminalisation of Sex Work ", null, null },
        //            { 20, "Sesitization engagements", "Sesitization engagements", null, null },
        //            { 21, "Mapping", "Mapping", null, null },
        //            { 22, "Providing CBM toolkits", "Providing CBM toolkits", null, null },
        //            { 23, "Distribute IEC material", "Distribute IEC material", null, null },
        //            { 24, "Training", "Training", null, null },
        //            { 25, "Demand creation", "Demand creation", null, null },
        //            { 26, "Score card development and monitoring", "Score card development and monitoring", null, null },
        //            { 27, "Skills development", "Skills development", null, null },
        //            { 28, "Obtain facility start-up kits from NDOH", "Obtain facility start-up kits from NDOH", null, null },
        //            { 29, "Facility and site assessments", "Facility and site assessments", null, null },
        //            { 30, "Develop assessment tools", "Develop assessment tools", null, null },
        //            { 31, "SOP development", "SOP development", null, null },
        //            { 32, "Deploy NDOH tools", "Deploy NDOH tools", null, null },
        //            { 33, "Deploy NDOH tools and Tier.net module to all identified sites", "Deploy NDOH tools and Tier.net modules", null, null },
        //            { 34, "Update PrEP finder on NDOH website to include facilities", "Update PrEP finder on NDOH website", null, null },
        //            { 35, "Data quality assessment", "Data quality assessment", null, null },
        //            { 36, "Facility-level data review", "Facility-level data review", null, null },
        //            { 37, "Conduct  performance management activities", "Conduct  performance management activities", null, null },
        //            { 38, "Distribution of MINA collateral, posters an IEC to facilities.", "Distribution of MINA collateral, posters and IEC", null, null },
        //            { 39, "Facilitate the branding in facilities", "Facilitate the branding in facilities", null, null },
        //            { 40, "Identification of MINA champion /facility in conjunction with facility manager", "Identification of MINA champion", null, null },
        //            { 41, "Advocacy for mesn health", "Advocacy for mesn health", null, null },
        //            { 42, "HiV prevention", "HiV prevention", null, null },
        //            { 43, "HTS", "HTS", null, null },
        //            { 44, "Care", "Care", null, null },
        //            { 45, "Treatment/FP Services", "Treatment/FP Services", null, null },
        //            { 46, "DREAMS stakeholder engagement", "DREAMS stakeholder engagement", null, null },
        //            { 47, "DREAMS Ambassador development", "DREAMS Ambassador development", null, null },
        //            { 48, "Support the establishment of facility and sub-district Adolescent and Youth Friendly Services (AYFS)", "Support the establishment of AYFS", null, null },
        //            { 49, "Promote provision of integrated HTS/HIV Prevention/FP/SRH services to AGYW at FP units or youth care corners", "Promote provision of integrated services to AGYW", null, null },
        //            { 50, "Guideline development", "Guideline development", null, null },
        //            { 51, "LIVES Training", "LIVES Training", null, null },
        //            { 52, "Avial adolescent clinics and youth corners", "Avial adolescent clinics and youth corners", null, null },
        //            { 53, "Mentorship on client engagement", "Mentorship on client engagement", null, null },
        //            { 54, "Implement PrEP services", "Implement PrEP services", null, null },
        //            { 55, "Welcome back campaign", "Welcome back campaign", null, null },
        //            { 56, "Stakeholder enagement", "Stakeholder enagement", null, null },
        //            { 57, "Site visits and assesssments", "Site visits and assesssments", null, null },
        //            { 58, "Support policy development", "Support policy development", null, null },
        //            { 59, "Ensure that 90 % of pregnant women are started same day    ", "Ensure pregnant women are started same day    ", null, null },
        //            { 60, "IQC of HIV Test kits", "IQC of HIV Test kits", null, null },
        //            { 61, "Rapid test quality improvements", "Rapid test quality improvements", null, null },
        //            { 62, "Support and Conduct 6 monthly SPI -RT assessments in all facilities", "Conduct 6 monthly SPI -RT assessments", null, null },
        //            { 63, "Quality Assessments", "Quality Assessments", null, null },
        //            { 64, "Conduct monthly TB register audits to identify gaps in HIV testing", "Conduct monthly TB register audits", null, null },
        //            { 65, "Review presumptive TB register to indentify confirmed Tb + clients not initiated on ART and fasttrack for initiation", "Review presumptive TB register", null, null },
        //            { 66, "Analyse IPT Data to improve initiation and completion of IPT", "Analyse IPT Data to improve completion of IPT", null, null },
        //            { 67, "Conduct monthly PMTCT register reviews", "Conduct monthly PMTCT register reviews", null, null },
        //            { 68, "Funder prescribed assessments", "Funder prescribed assessments", null, null },
        //            { 69, "Conduct routine clinical chart and register reviews to identify gaps in HTS/HIV/TB services", "Conduct routine clinical chart and register review", null, null },
        //            { 70, "Develop facility QIPs in conjunction with facility team  according to the gaps identified", "Develop facility QIPs", null, null },
        //            { 71, "Monitor implementation of facility QIPs", "Monitor implementation of facility QIPs", null, null },
        //            { 72, "Provide coaching  and upskilling in implementation and monitoring of improvement activities (FIP's and QIP's) to facility staff", "Provide coaching and upskilling", null, null },
        //            { 73, "Support the implementation of TB screening for all ART clients at every visit and actioning for TPT or TB testing in supported facilities", "Support the implementation of TB screening", null, null },
        //            { 74, "Monthly reviews of facility TB screening practices among ART clients flagging for low TPT uptake and <90% screening of all visiting ART clients", "Monthly reviews of TB screening practices", null, null },
        //            { 75, "Monthly review of Presumptive  register to ensure all Presumptive clients have an HIV and or ART status, clients not initiated on ART and fast track  for initiation.", "Monthly review of Presumptive register", null, null },
        //            { 76, "Assist with training staff on HTS and ART for Presumptive TB", "Assist with training staff on HTS", null, null },
        //            { 77, "Assist with training of staff  on TPT guidelines and management of TPT in ART clients", "Assist with training of staff on TPT", null, null },
        //            { 78, "Monthly review of facility TPT to ART initiation rates to ensure above 85%", "Monthly review of facility TPT to ART", null, null },
        //            { 79, "Monthly review of facility missed opportunities to initiate TPT in TX_NEW 3 months prior and flag for reassessment of TPT eligibility and TPT initiation", "Monthly review of facility missed opportunities", null, null },
        //            { 80, "Monthly review of facility TPT outcomes of clients initiated 12 months prior flagging all patients with outstanding TPT outcomes, ensure outcomes are completed.", "Monthly review of facility TPT outcomes", null, null },
        //            { 81, "Strengthening of results management", "Strengthening of results management", null, null },
        //            { 82, "Monthly review of specimen rejection rates for   CD4/VL/PCR/TB GenxPert and implement corrective measures    on rejections caused by pre-analytical errors.", "Monthly review of specimen rejection rates", null, null },
        //            { 83, "Support with the roll out and implementation of Post Natal Clubs", "Support with implementation of Post Natal Clubs", null, null },
        //            { 84, "Provide oversight support on Post Natal Clubs(coaching of PNC Nurses)", "Provide support on Post Natal Clubs", null, null },
        //            { 85, "Conduct PMTCT register review to monitor", "Conduct PMTCT register review to monitor", null, null },
        //            { 86, "Coaching on correct completion of registers", "Coaching on correct completion of registers", null, null },
        //            { 87, "Participate in PMTCT forums and PNC Forums ", "Participate in PMTCT forums and PNC Forums ", null, null },
        //            { 88, "Active participation in all Data Management platforms", "Active participation in Data Management platforms", null, null },
        //            { 89, "TA support: training and support of DOH staff in facilities. strengtening current data systems and structures in facilities.", "TA support", null, null },
        //            { 90, "Conduct adherence club audits and initiate QIP based on findings", "Conduct adherence club audits and initiate QIP", null, null },
        //            { 91, "Provide DSD to improve same day initiations", "Provide DSD to improve same day initiations", null, null },
        //            { 92, "Integrate Case mangement tool with Facility systems and processes.", "Integrate Case mangement tool", null, null },
        //            { 93, "Support PHDC: with Human Resources,Improve Linkage and retention,comprehensive patient Care; Cross Referencing of data and generation of reports.", "Support PHDC", null, null },
        //            { 94, "Improvement of Facility level Data-consolidate multiple entries into a unique ID (HPRN)", "Improve data-consolidate multiple entries", null, null },
        //            { 95, "Provide ongoing support on coaching and mentoring of DOH / CCT NIMART nurses to scale up same day initiations", "Provide support on coaching and mentoring", null, null },
        //            { 96, "Support the re-authorization of NIMART nurses", "Support the re-authorization of NIMART nurses", null, null },
        //            { 97, "Support DoH and CCT Mentors to complete NIMART training  for  professional nurses  according to Western Cape guidelines/criteria", "Support Mentors to complete NIMART training", null, null },
        //            { 98, "Identify gaps at Facilities as per program operations requirement. Support facilities in reaching set targets(both facility & DSP targets) by linking DSD staff to identified sites.", "Identify gaps per program operations requirement", null, null },
        //            { 99, "Build  capacity of facility data/admin staff to support best practices/national /provincial guidelines on patient record keeping/ filing,archiving, registry hygiene", "Build data/admin staff to support best practices", null, null },
        //            { 100, "Provide DSD to improve patient  experience and flow through facilities. Increased number of patient medication pick-up points", "Provide DSD to improve patient experience", null, null },
        //            { 101, "Support decanting strategy to improve pharmacy waiting times.", "Improve pharmacy waiting times.", null, null },
        //            { 102, "Strenthgthening appointment system in all Facilities.", "Strenthgthening appointment system", null, null },
        //            { 103, "Introduce and support pre-retrieval of folders in all Facilities.", "Introduce and support pre-retrieval of folders", null, null },
        //            { 104, "Provide support to DoH  /CCT on roll out services during extended working hours at identified facilities ", "Provide support to on roll out services", null, null },
        //            { 105, "Support critical posts within the HAST Directorate", "Support critical posts within the HAST Directorate", null, null },
        //            { 106, "Regular and on-going feedback with sub structures and facilities on progress towards targets", "Regular and ongoing feedback with sub structures", null, null },
        //            { 107, "Cultivate a culture of accountability towards facilities, colleagues and clients.", "Cultivate a culture of accountability", null, null },
        //            { 108, "Individual performance mornitoring and feedback done for all staff ", "Individual performance mornitoring and feedback", null, null },
        //            { 109, "Provision of value clubs", "Provision of value clubs", null, null },
        //            { 110, "Support registering of value clubs (both facility and community) at supported facilities.", "Support registering of value clubs", null, null },
        //            { 111, "Tracing patient adherence through the other DMOC modalities.", "Tracing patient adherence", null, null },
        //            { 112, "Working with facility DOH staff to ensure that newly decanted stable patients are added to existing and/or new clubs at supported facilities.", "Ensure newly decanted patients are added to clubs", null, null },
        //            { 113, "Generation of  Risk of treatment failure client lists to identify gaps and to guide program on resource deployment.", "Generate Risk of treatment failure client lists", null, null },
        //            { 114, "Weekly Tracking and recall of clients  with virologic failure using Facility Information Systems ", "Weekly Tracking and recall of clients", null, null },
        //            { 115, "Suport Facilities with  Telephonic tracing and recalls of  for Viral loads(VL) due; missed VLs and  unsuppressed VL's", "Suport with Telephonic tracing and recalls VL", null, null },
        //            { 116, "Improve clinical management  by providing on site facility training and mentoring of clinical staff", "Improve clinical management", null, null },
        //            { 117, "Support Facilities with Folder Audits to maintain good quality of clinical care and improve VL uptake at Faclity level", "Support Facilities with Folder Audits", null, null },
        //            { 118, "Support Specialised services by providing Advanced clinical care  ( ROTF, pharmacovigilance) ", "Support with providing Advanced clinical care", null, null },
        //            { 119, "Track VL done on ALL new patients tthough implementation and monitoring of the 100 day Case Management at Siyenza Facilities", "Track VL done on ALL new patients", null, null },
        //            { 120, "Strengthen viral load monitoring, and capturing  by providing techinal assistance.", "Strengthen viral load monitoring and capturing", null, null },
        //            { 121, "Mobilize individuals with virologic failure using TIER.net and NHLS and PHCD(Viral load for action reports)", "Mobilize individuals with virologic failure", null, null },
        //            { 122, "Support Specialised services by providing Advanced clinical care for  v  ( ROTF, pharmacovigilance and other co-morbidities)", "Support by providing Advanced clinical care", null, null },
        //            { 123, "Support retention in care through telephonic tracing", "Support care rentention - telephonic tracing", null, null },
        //            { 124, "Support rentention in care through trace and track", "Support care rentention - trace and track", null, null },
        //            { 125, "Support rentention in care by imprving VL uptake and monitoring", "Support care rentention - improve VL uptake", null, null },
        //            { 126, "Support rententions in care through welcome back campaigns", "Support care rentention - welcome back campaigns", null, null },
        //            { 127, "Support retention in care through effective used of pharmacy collection data", "Support care retention - pharmacy collection data", null, null },
        //            { 128, "Support retention in care by supporting facilities in decanting strategies", "Support care retention - decanting strategies", null, null },
        //            { 129, "Support rentention in care by supporting facilities with scripting, planning  and improving adherence clubs", "Support care rentention - scripting, planning, etc", null, null },
        //            { 130, "Provide appropriate number of clinicians to facilities to initiate Clients on ART", "Provide appropriate number of clinicians on ART", null, null },
        //            { 131, "Provide cross reference between data sytems to track ART initiations", "Provide cross reference to track ART initiations", null, null },
        //            { 132, "Build capacity of DoH/CCT staff by supporting NIMART mentoring", "Build capacity of staff with NIMART mentoring", null, null },
        //            { 133, "Support DoH/ CCT policy on same day initiations", "Support DoH/ CCT policy on same day initiations", null, null },
        //            { 134, "Support TLD transition ", "Support TLD transition ", null, null },
        //            { 135, "Provide capacity to sustain medication dispensing to support same day initiation / ART enrolment", "Provide capacity to sustain medication dispensing", null, null },
        //            { 136, "Identify ART initiation backlogs per facility trough weekly data evaluation meetings for identification of gaps at facility level through DSD", "Identify ART initiation backlogs", null, null },
        //            { 137, "Provide case managers to ensure effective linkage and retention in care.", "Provide case managers", null, null },
        //            { 138, "Increase access to care by expanding pharmacy services into quick pick up points", "Increase access to care", null, null },
        //            { 139, "Support to people who are at risk of lost to follow up ", "Support people at risk of lost to follow up", null, null },
        //            { 140, "Support the DOH Welcome Back Campaign", "Support the DOH Welcome Back Campaign", null, null },
        //            { 141, "Develop IT support for for tracking of ARV clients for reporting to funders", "Develop IT support for tracking of ARV clients", null, null },
        //            { 142, "Provide  NIMART trained nurses ", "Provide  NIMART trained nurses ", null, null },
        //            { 143, "Provide  Advanced Clinical Care by Medical Officers", "Provide Advanced Clinical Care by Medical Officers", null, null },
        //            { 144, "Support facilities to reach HAST program", "Support facilities to reach HAST program", null, null },
        //            { 145, "Provide NIMART mentoring support", "Provide NIMART mentoring support", null, null },
        //            { 146, "Training on clinical guideline ", "Training on clinical guideline ", null, null },
        //            { 147, "Support Facilities in sustained improvement of the HAST core program indicators ( ICT,SDI, TLD, TPT, Decanting) through regular update and review of Facility Improvement Plans", "Support with improvement of the HAST core programs", null, null },
        //            { 148, "Support Facilities with Weekly tracking and Recall of Waiting on ART to improve linkage to care and number of ART initiations.", "Support with tracking & Recall of Waiting on ART", null, null },
        //            { 149, "Improve retention in care at supported Facilitied through daily and weekly tracking of missed appointments and uLTFU", "Improve retention in care at supported Facilities", null, null },
        //            { 150, "Facilitate Weekly Data reviews as supported Siyenza Facilities to identify ART initiation and retention gaps.", "Facilitate Weekly Data reviews", null, null },
        //            { 151, "Facilitate linkage to care", "Facilitate linkage to care", null, null },
        //            { 152, "Offering targeted HIV testing", "Offering targeted HIV testing", null, null },
        //            { 153, "Provide counsellors", "Provide counsellors", null, null },
        //            { 154, "Targeted HIV testing at ANC, TB,PNC,FP,STI points", "Targeted HIV testing at ANC, TB,PNC,FP,STI points", null, null },
        //            { 155, "Conduct HIV and TB screening as part of infacility health screening", "Conduct HIV and TB screening", null, null },
        //            { 156, "Facilitate Index Case Finding of sexual partners and biological children for all HIV positive clients through facility and community", "Facilitate Index Case Finding of sexual partners", null, null },
        //            { 157, "Support the Provincial Department of Health's roll out of HIV Self Screening and Index Case Testing ", "Support DoH's roll out of HIV Self Screening", null, null },
        //            { 158, "Support RTCQI training to ALL counsellors and nurses", "Support RTCQI training to counsellors and nurses", null, null },
        //            { 159, "Conduct 6 monthly internal SPI-RT assessments", "Conduct 6 monthly internal SPI-RT assessments", null, null },
        //            { 160, "Support weekly independent QC and 6 monthly proficiency testing", "Support weekly QC and 6 monthly testing", null, null },
        //            { 161, "Digitizing and analysing of HTS capturing on current data systems", "Digitizing and analysing of HTS capturing", null, null },
        //            { 162, "Identify with Province and City skills shortage, M&E gaps for reporting and capturing and assist with temporary workforce relief", "Identify with Province and City skills shortage", null, null },
        //            { 163, "Provide and distribute HTS support equipment to enable Counsellors and HTS Testers in testing functions ", "Provide and distribute HTS support equipment", null, null },
        //            { 164, "Provide HTS in ER, triage settings in identified District hospitals.", "Provide HTS in ER, triage settings", null, null },
        //            { 165, "Provide track and tracing for HIV positive clients in District hospitals for in-patients.", "Provide track and tracing for HIV positive clients", null, null },
        //            { 166, "Strenghthen ICT support through NIMART nurse involvement", "Strenghthen ICT support", null, null },
        //            { 167, "Support Implementation and upscaling  of Run Charts as a Quality assurance and Quality improvement tool for HTS,HTS Pos and ICT", "Support Implementation and upscaling of Run Charts", null, null },
        //            { 168, "Violence screening", "Violence screening", null, null },
        //            { 169, "Men Workplace Testing HIV Testing ", "Men Workplace Testing HIV Testing ", null, null },
        //            { 170, "Finding Youth TVET Testing: In partnership with HEAIDS, Anova will continue testing at TVETs colleges in the Cape Metro. STI and TB screening will also be offered.", "Finding Youth TVET Testing", null, null },
        //            { 171, "Targeting Male Dominated Community HIV  Testing", "Targeting Male Dominated Community HIV  Testing", null, null },
        //            { 172, "Defaulter Tracking ICT ", "Defaulter Tracking ICT ", null, null },
        //            { 173, "Targeted Wellness Outreaches in Partnership with other community NPOs", "Targeted Wellness Outreaches", null, null },
        //            { 174, "Following all pregnant women in high burden areas", "Following all pregnant women in high burden areas", null, null },
        //            { 175, "BCI - Behaviour Change Interventions", "BCI - Behaviour Change Interventions", null, null },
        //            { 176, "Condom distribution", "Condom distribution", null, null },
        //            { 177, "Needle and syringe distribution", "Needle and syringe distribution", null, null },
        //            { 178, "Opioid Substitution Treatment (OST)", "Opioid Substitution Treatment (OST)", null, null },
        //            { 179, "STI screening", "STI screening", null, null },
        //            { 180, "TB screening", "TB screening", null, null },
        //            { 181, "Family Planning", "Family Planning", null, null },
        //            { 182, "ART", "ART", null, null },
        //            { 183, "Pregnancy testing", "Pregnancy testing", null, null },
        //            { 184, "non communable disease screening", "non communable disease screening", null, null },
        //            { 185, "Referrals to DOH/COCT facilities", "Referrals to DOH/COCT facilities", null, null },
        //            { 186, "TB testing", "TB testing", null, null },
        //            { 187, "Human Rights violations screening", "Human Rights violations screening", null, null },
        //            { 188, "Overdose management / awareness", "Overdose management / awareness", null, null },
        //            { 189, "Hepatitis C sceening, diagnosis and treatment ", "Hepatitis C sceening, diagnosis and treatment ", null, null },
        //            { 190, "Hepatitis B testing and vaccination", "Hepatitis B testing and vaccination", null, null },
        //            { 191, "Sensitisation training", "Sensitisation training", null, null },
        //            { 192, "Health: HIV Testing", "Health: HIV Testing", null, null },
        //            { 193, "Health: HIV Self Screening", "Health: HIV Self Screening", null, null },
        //            { 194, "Health: Male/Female Condom and Lube Distribution", "Health: Male/Female Condom and Lube Distribution", null, null },
        //            { 195, "Health: STI screening and Investigation", "Health: STI screening and Investigation", null, null },
        //            { 196, "Health: TB Screening and TB Sputum testing", "Health: TB Screening and TB Sputum testing", null, null },
        //            { 197, "Health: Pregnancy Testing", "Health: Pregnancy Testing", null, null },
        //            { 198, "Health: SRH", "Health: SRH", null, null },
        //            { 199, "Health: ART", "Health: ART", null, null },
        //            { 200, "Health: PrEP related lab costs", "Health: PrEP related lab costs", null, null },
        //            { 201, "Health: Emergency Contraception", "Health: Emergency Contraception", null, null },
        //            { 202, "Behaviour Change: Peer Education", "Behaviour Change: Peer Education", null, null },
        //            { 203, "Behaviour Change:Comprehensive Sexuality Education", "Behaviour Change:Comprehensive Sexuality Education", null, null },
        //            { 204, "Behaviour Change: Individual Psycho Social Support", "Behaviour Change: Individual Psycho Social Support", null, null },
        //            { 205, "Behaviour Change: PrEP Demand Creation", "Behaviour Change: PrEP Demand Creation", null, null },
        //            { 206, "Behaviour Change: Teen Parenting/Parenting", "Behaviour Change: Teen Parenting/Parenting", null, null },
        //            { 207, "Behaviour Change: Teen & Caregiver Comunication", "Behaviour Change: Teen & Caregiver Comunication", null, null },
        //            { 208, "Behaviour Change: SRH Knowledge and behaviour", "Behaviour Change: SRH Knowledge and behaviour", null, null },
        //            { 209, "Behaviour Change: GBV Prevention", "Behaviour Change: GBV Prevention", null, null },
        //            { 210, "Behaviour Change: Adherence Support (Mental Health Support)", "Behaviour Change: Adherence Support", null, null },
        //            { 211, "Behaviour Change: Physical activity", "Behaviour Change: Physical activity", null, null },
        //            { 212, "Structural: Support to Access Grants", "Structural: Support to Access Grants", null, null },
        //            { 213, "Structural: Dignity Packs", "Structural: Dignity Packs", null, null },
        //            { 214, "Structural: Academic Support and Career Guidance", "Structural: Academic Support and Career Guidance", null, null },
        //            { 215, "Structural: Return to School Support", "Structural: Return to School Support", null, null },
        //            { 216, "Structural: ECD Vouchers", "Structural: ECD Vouchers", null, null },
        //            { 217, "Structural: GBV Awareness and Self-Defence", "Structural: GBV Awareness and Self-Defence", null, null },
        //            { 218, "Structural: Economic Strengthening", "Structural: Economic Strengthening", null, null },
        //            { 219, "Trauma containment", "Trauma containment", null, null },
        //            { 220, "Risk assessment & referral; ", "Risk assessment & referral; ", null, null },
        //            { 221, "Follow-up psychosocial support", "Follow-up psychosocial support", null, null },
        //            { 222, "PEP adherence suppor", "PEP adherence suppor", null, null },
        //            { 223, "Role out of HIV SS", "Role out of HIV SS", null, null },
        //            { 224, "Referral for other social support services", "Referral for other social support services", null, null },
        //            { 225, "Court preparation & support", "Court preparation & support", null, null },
        //            { 226, "GBV awareness & community outreach", "GBV awareness & community outreach", null, null },
        //            { 227, "PrEP Demand Creation and referrals to PrEP Clinics", "PrEP Demand Creation and referrals to PrEP Clinics", null, null },
        //            { 228, "Delivery of Chronic Medication", "Delivery of Chronic Medication", null, null },
        //            { 229, "COVID response", "COVID response", null, null },
        //            { 230, "COVID testing", "COVID testing", null, null },
        //            { 231, "COVID vaccination", "COVID vaccination", null, null },
        //            { 232, "COVID vaccine demand creation", "COVID vaccine demand creation", null, null },
        //            { 233, "COVID tracking and tracing", "COVID tracking and tracing", null, null },
        //            { 234, "Establish peer groups for Mental Health", "Establish peer groups for Mental Health", null, null },
        //            { 235, "Patient transport support", "Patient transport support", null, null },
        //            { 236, "Telehealth support", "Telehealth support", null, null }
        //        });

        //    migrationBuilder.InsertData(
        //        schema: "dropdown",
        //        table: "ActivityTypes",
        //        columns: new[] { "Id", "Name", "SystemName", "UpdatedDateTime", "UpdatedUserId" },
        //        values: new object[,]
        //        {
        //            { 1, "New", "New", null, null },
        //            { 2, "Ongoing", "Ongoing", null, null }
        //        });

        //    migrationBuilder.InsertData(
        //        schema: "dropdown",
        //        table: "AllocationTypes",
        //        columns: new[] { "Id", "Name", "SystemName", "UpdatedDateTime", "UpdatedUserId" },
        //        values: new object[,]
        //        {
        //            { 1, "Province", "Province", null, null },
        //            { 2, "City of Cape Town", "CoCT", null, null }
        //        });

        //    migrationBuilder.InsertData(
        //        schema: "dropdown",
        //        table: "ApplicationTypes",
        //        columns: new[] { "Id", "Name", "SystemName", "UpdatedDateTime", "UpdatedUserId" },
        //        values: new object[,]
        //        {
        //            { 1, "Funding Application", "FA", null, null },
        //            { 2, "Service Provision", "SP", null, null },
        //            { 3, "Quick Capture", "QC", null, null },
        //            { 4, "Business Plan", "BP", null, null }
        //        });

        //    migrationBuilder.InsertData(
        //        schema: "dropdown",
        //        table: "Banks",
        //        columns: new[] { "Id", "Code", "Name", "UpdatedDateTime", "UpdatedUserId" },
        //        values: new object[,]
        //        {
        //            { 1, "632005", "ABSA Bank", null, null },
        //            { 2, "470010", "Capitec Bank", null, null },
        //            { 3, "250655", "First National Bank", null, null },
        //            { 4, "198675", "NedBank", null, null },
        //            { 5, "051001", "Standard Bank", null, null },
        //            { 6, null, "International Bank", null, null },
        //            { 7, "580105", "Investec Bank", null, null },
        //            { 8, "460005", "Post Bank", null, null },
        //            { 9, "000000", "Default", null, null },
        //            { 10, null, "Bidvest", null, null }
        //        });

        //    migrationBuilder.InsertData(
        //        schema: "dropdown",
        //        table: "Branches",
        //        columns: new[] { "Id", "BankId", "BranchCode", "Name", "UpdatedDateTime", "UpdatedUserId" },
        //        values: new object[,]
        //        {
        //            { 1, 1, null, "All Branches", null, null },
        //            { 2, 1, null, "Barrydale", null, null },
        //            { 3, 1, null, "Beaufort West", null, null },
        //            { 4, 1, null, "Bellville", null, null },
        //            { 5, 1, null, "Bonnievale", null, null },
        //            { 6, 1, null, "Brackenfell", null, null },
        //            { 7, 1, null, "Bredasdorp", null, null },
        //            { 8, 1, null, "Caledon", null, null },
        //            { 9, 1, null, "Cape Gate", null, null },
        //            { 10, 1, null, "Centurion", null, null },
        //            { 11, 1, null, "Century City", null, null },
        //            { 12, 1, null, "Ceres", null, null },
        //            { 13, 1, null, "Citrusdal", null, null },
        //            { 14, 1, null, "Clanwilliam", null, null },
        //            { 15, 1, null, "Claremont", null, null },
        //            { 16, 1, null, "De Doorns", null, null },
        //            { 17, 1, null, "Durbanville", null, null },
        //            { 18, 1, null, "George", null, null },
        //            { 19, 1, null, "Helderberg", null, null },
        //            { 20, 1, null, "Hermanus", null, null },
        //            { 21, 1, null, "Kenilworth", null, null },
        //            { 22, 1, null, "Kraaifontein", null, null },
        //            { 23, 1, null, "Kuilsriver", null, null },
        //            { 24, 1, null, "Malmesbury", null, null },
        //            { 25, 1, null, "Montagu", null, null },
        //            { 26, 1, null, "Mossel Bay", null, null },
        //            { 27, 1, null, "Mountain Mill", null, null },
        //            { 28, 1, null, "Mowbray", null, null },
        //            { 29, 1, null, "Oudtshoorn", null, null },
        //            { 30, 1, null, "Paarl", null, null },
        //            { 31, 1, null, "Parow", null, null },
        //            { 32, 1, null, "Phillipi", null, null },
        //            { 33, 1, null, "Plein Street", null, null },
        //            { 34, 1, null, "Plettenberg Bay", null, null },
        //            { 35, 1, null, "Porterville", null, null },
        //            { 36, 1, null, "Promenade", null, null },
        //            { 37, 1, null, "Riebeek Road", null, null },
        //            { 38, 1, null, "Riviersonderend", null, null },
        //            { 39, 1, null, "Robertson", null, null },
        //            { 40, 1, null, "Santyger", null, null },
        //            { 41, 1, null, "Somerset mall", null, null },
        //            { 42, 1, null, "Stellenbosch", null, null },
        //            { 43, 1, null, "Strand", null, null },
        //            { 44, 1, null, "Swellendam", null, null },
        //            { 45, 1, null, "Tulbagh", null, null },
        //            { 46, 1, null, "Tyger Manor", null, null },
        //            { 47, 1, null, "Uniondale", null, null },
        //            { 48, 1, null, "Villiersdorp", null, null },
        //            { 49, 1, null, "Vredendal", null, null },
        //            { 50, 1, null, "Wellington", null, null },
        //            { 51, 1, null, "Worcester", null, null },
        //            { 52, 1, null, "Wynberg", null, null },
        //            { 53, 1, null, "Zevenwacht", null, null },
        //            { 54, 1, "631309", "Athlone", null, null },
        //            { 55, 1, "505210", "Boston Street", null, null },
        //            { 56, 1, "630126", "Durban City", null, null },
        //            { 57, 1, "334708", "Prince Albert", null, null },
        //            { 58, 1, "421109", "Rondebosch", null, null },
        //            { 59, 1, "503107", "Stockenstroom Street", null, null },
        //            { 60, 1, "334507", "Wolseley", null, null },
        //            { 61, 1, null, "Knysna", null, null },
        //            { 62, 1, null, "Cape Town Adderley Street", null, null },
        //            { 63, 1, null, "KUILSRIVIER", null, null },
        //            { 64, 1, null, "McTyre Street, Parow", null, null },
        //            { 65, 1, null, "plettenburg", null, null },
        //            { 66, 1, null, "RIEBEECKWEG KUILSRIVIER", null, null },
        //            { 67, 1, null, "SOMERSET WEST", null, null },
        //            { 68, 1, null, "TYGER MALL", null, null },
        //            { 69, 1, null, "ZEVENWACHT MALL", null, null },
        //            { 70, 1, "632005", "Riversdal", null, null },
        //            { 71, 1, "000000", "Default", null, null },
        //            { 72, 2, null, "Bellville", null, null },
        //            { 73, 2, null, "Khayelitsha KBD", null, null },
        //            { 74, 2, "200712", "Villiersdorp", null, null },
        //            { 75, 2, null, "All Branches", null, null },
        //            { 76, 3, null, "Beaufort West", null, null },
        //            { 77, 3, null, "Khayelitsha", null, null },
        //            { 78, 3, null, "Langeberg Mall", null, null },
        //            { 79, 3, null, "Lansdowne", null, null },
        //            { 80, 3, null, "Mossel Bay", null, null },
        //            { 81, 3, null, "N1 City", null, null },
        //            { 82, 3, null, "Paarl", null, null },
        //            { 83, 3, null, "Plumstead", null, null },
        //            { 84, 3, null, "Promenade", null, null },
        //            { 85, 3, null, "Symphony Walk", null, null },
        //            { 86, 3, null, "Vangate Mall", null, null },
        //            { 87, 3, null, "Vineyard", null, null },
        //            { 88, 3, null, "Wellington", null, null },
        //            { 89, 3, "200206", "Clanwilliam", null, null },
        //            { 90, 3, "210554", "Commercial Account Services", null, null },
        //            { 91, 3, "200406", "Garies", null, null },
        //            { 92, 3, "201409", "Gugulethu", null, null },
        //            { 93, 3, "260557", "Gugulethu Mall", null, null },
        //            { 94, 3, "260557", "Gugulethu Square", null, null },
        //            { 95, 3, "200809", "Heerengracth", null, null },
        //            { 96, 3, "200113", "Heidelberg", null, null },
        //            { 97, 3, "271344", "Helderberg", null, null },
        //            { 98, 3, "200109", "Kenilworth", null, null },
        //            { 99, 3, "200512", "MAIN STREET", null, null },
        //            { 100, 3, "200209", "Maitland", null, null },
        //            { 101, 3, "200507", "Malmesbury", null, null },
        //            { 102, 3, "250040", "Mitchell Plain", null, null },
        //            { 103, 3, "204709", "Montagu", null, null },
        //            { 104, 3, "200111", "Moorreesburg", null, null },
        //            { 105, 3, "250937", "Neelsie", null, null },
        //            { 106, 3, "260209", "Pinelands", null, null },
        //            { 107, 3, "261251", "Sandton Square", null, null },
        //            { 108, 3, "201809", "Sea Point", null, null },
        //            { 109, 3, "210229", "Sedgefield", null, null },
        //            { 110, 3, "202309", "Simons Town", null, null },
        //            { 111, 3, "202509", "Thibault Sqaure", null, null },
        //            { 112, 3, "201410", "Tygerberg", null, null },
        //            { 113, 3, "210655", "Willowbridge", null, null },
        //            { 114, 3, "210114", "York Street", null, null },
        //            { 115, 3, "201409", "Adderley Street", null, null },
        //            { 116, 3, null, "All Branches", null, null },
        //            { 117, 3, "202409", "Athlone", null, null },
        //            { 118, 3, "200409", "Blue Route", null, null },
        //            { 119, 3, "200212", "Caledon", null, null },
        //            { 120, 3, "201409", "Cape Town", null, null },
        //            { 121, 3, "200107", "Ceres", null, null },
        //            { 122, 3, "200109", "Claremont", null, null },
        //            { 123, 3, "200207", "De Doorns", null, null },
        //            { 124, 3, "200810", "Epping", null, null },
        //            { 125, 3, "202309", "Fish Hoek", null, null },
        //            { 126, 3, "210114", "george", null, null },
        //            { 127, 3, "200312", "Grabouw", null, null },
        //            { 128, 3, "203109", "Grassy Park", null, null },
        //            { 129, 3, "200412", "Hermanus", null, null },
        //            { 130, 3, "204009", "Hout Bay", null, null },
        //            { 131, 3, null, "Klawer", null, null },
        //            { 132, 3, "210214", "knysna", null, null },
        //            { 133, 3, "201110", "Kuilsriver", null, null },
        //            { 134, 3, "200213", "Ladismith", null, null },
        //            { 135, 3, "210754", "Makhaza", null, null },
        //            { 136, 3, "203309", "Milnerton", null, null },
        //            { 137, 3, "204709", "Montague Gardens", null, null },
        //            { 138, 3, "200309", "Mowbray", null, null },
        //            { 139, 3, "202709", "Newlands", null, null },
        //            { 140, 3, "210414", "Oudtshoorn", null, null },
        //            { 141, 3, "200510", "Parow", null, null },
        //            { 142, 3, "200211", "Piketberg", null, null },
        //            { 143, 3, "210514", "Plettenberg Bay", null, null },
        //            { 144, 3, "200413", "Robertson", null, null },
        //            { 145, 3, "201509", "Rondebosch", null, null },
        //            { 146, 3, "200411", "Saldanha", null, null },
        //            { 147, 3, "200912", "Somerset mall", null, null },
        //            { 148, 3, "200610", "Stellenbosch", null, null },
        //            { 149, 3, "200612", "Strand", null, null },
        //            { 150, 3, "200513", "Swellendam", null, null },
        //            { 151, 3, "203809", "Table View", null, null },
        //            { 152, 3, "202509", "Thibault Square", null, null },
        //            { 153, 3, "200409", "Tokai", null, null },
        //            { 154, 3, "250040", "Town Centre Mitchell's Plain", null, null },
        //            { 155, 3, "200307", "Tulbagh", null, null },
        //            { 156, 3, "220323", "Tygervalley", null, null },
        //            { 157, 3, "200712", "Villiersdorp", null, null },
        //            { 158, 3, "200311", "Vredenburg", null, null },
        //            { 159, 3, "200406", "Vredendal", null, null },
        //            { 160, 3, "201909", "Woodstock", null, null },
        //            { 161, 3, "200407", "Worcester", null, null },
        //            { 162, 3, "202209", "Wynberg", null, null },
        //            { 163, 3, "260214", "Zevenwacht", null, null },
        //            { 164, 3, null, "Town Centre", null, null },
        //            { 165, 3, null, "Durbanville", null, null },
        //            { 166, 3, null, "250555", null, null },
        //            { 167, 3, null, "Adderley Str. Cape Town", null, null },
        //            { 168, 3, null, "Adderley Street Cape Town", null, null },
        //            { 169, 3, null, "Adderley Street, Cape Town", null, null },
        //            { 170, 3, null, "Adderley Street,Cape Town", null, null },
        //            { 171, 3, null, "ADDERLY STREET", null, null },
        //            { 172, 3, null, "BLUE ROUTE MALL", null, null },
        //            { 173, 3, null, "BLUE ROUTE TOKAI", null, null },
        //            { 174, 3, null, "EPPINDUST", null, null },
        //            { 175, 3, null, "EPPINGDUST", null, null },
        //            { 176, 3, null, "Eppingindust", null, null },
        //            { 177, 3, null, "GRASSY PARK CAPE TOWN", null, null },
        //            { 178, 3, null, "Grassy Park, Cape Town", null, null },
        //            { 179, 3, null, "KLAWER SERVICE BRANCHE", null, null },
        //            { 180, 3, null, "Kuilsrivier", null, null },
        //            { 181, 3, null, "ladiesmith", null, null },
        //            { 182, 3, null, "Makhaza Shopping Centre", null, null },
        //            { 183, 3, null, "Mlnerton", null, null },
        //            { 184, 3, null, "Mobray", null, null },
        //            { 185, 3, null, "montague", null, null },
        //            { 186, 3, null, "Mosselbay", null, null },
        //            { 187, 3, null, "PAROW 002", null, null },
        //            { 188, 3, null, "SALDAHNA", null, null },
        //            { 189, 3, null, "SANDTON", null, null },
        //            { 190, 3, null, "SANDTON SQUARE CRAIGHALL", null, null },
        //            { 191, 3, null, "SOMERSET WEST", null, null },
        //            { 192, 3, null, "Somerset West Mall", null, null },
        //            { 193, 3, null, "Stellenbosch C.P", null, null },
        //            { 194, 3, null, "Symphony", null, null },
        //            { 195, 3, null, "TYGERVALIE", null, null },
        //            { 196, 3, null, "VANGATE", null, null },
        //            { 197, 3, null, "Vangate Mall Athlone", null, null },
        //            { 198, 3, null, "VILLIERSDORD", null, null },
        //            { 199, 3, null, "villierssdorp", null, null },
        //            { 200, 3, null, "Zevenwacht Mall", null, null },
        //            { 201, 4, null, "Ceres", null, null },
        //            { 202, 4, "198765", "Avonwood", null, null },
        //            { 203, 4, "198765", "Beaufort West", null, null },
        //            { 204, 4, "103210", "Bellville East", null, null },
        //            { 205, 4, "103310", "Brackenfell", null, null },
        //            { 206, 4, "149821", "BUSINESS WINELANDS", null, null },
        //            { 207, 4, "441010", "Cape Commercial", null, null },
        //            { 208, 4, "145209", "Cavendish Square", null, null },
        //            { 209, 4, "167005", "Franschhoek", null, null },
        //            { 210, 4, "101009", "Gardens", null, null },
        //            { 211, 4, "100909", "Gardens Centre", null, null },
        //            { 212, 4, "122005", "GRAHAMSTOWN", null, null },
        //            { 213, 4, "103109", "Heerengracht", null, null },
        //            { 214, 4, "441012", "Helderberg Commercial", null, null },
        //            { 215, 4, "198765", "Inland Garden Route Paarl", null, null },
        //            { 216, 4, "198760", "Kenilworth", null, null },
        //            { 217, 4, "172305", "Khayaelitsha Mall", null, null },
        //            { 218, 4, "155405", "Makhaza", null, null },
        //            { 219, 4, "198765", "Mbekweni", null, null },
        //            { 220, 4, "107909", "Mitchell Plain", null, null },
        //            { 221, 4, "198765", "Montague Gardens", null, null },
        //            { 222, 4, "128505", "Moorreesburg", null, null },
        //            { 223, 4, "198765", "Nomzamo", null, null },
        //            { 224, 4, "118602", "Northern Peninsula", null, null },
        //            { 225, 4, "198765", "Paarl Mall", null, null },
        //            { 226, 4, "115909", "Peoples Athlone", null, null },
        //            { 227, 4, "107909", "Promenade", null, null },
        //            { 228, 4, "198765", "Robertson", null, null },
        //            { 229, 4, "106909", "Sea Point", null, null },
        //            { 230, 4, "123209", "Southern Peninsula", null, null },
        //            { 231, 4, "184705", "Stilbaai", null, null },
        //            { 232, 4, "128505", "Swartland", null, null },
        //            { 233, 4, "118602", "The Bridge", null, null },
        //            { 234, 4, "198765", "Tokai", null, null },
        //            { 235, 4, "103910", "Tygervalley", null, null },
        //            { 236, 4, "128505", "Vredenburg", null, null },
        //            { 237, 4, "198765", "Vredendal", null, null },
        //            { 238, 4, "102905", "Wellington", null, null },
        //            { 239, 4, null, "All Branches", null, null },
        //            { 240, 4, "193765", "Atlantis", null, null },
        //            { 241, 4, "120405", "Belhar", null, null },
        //            { 242, 4, "108110", "Bellville", null, null },
        //            { 243, 4, "125142", "Bredasdorp", null, null },
        //            { 244, 4, "196005", "Caledon", null, null },
        //            { 245, 4, "100909", "Cape Town", null, null },
        //            { 246, 4, "100989", "Cape Town Station", null, null },
        //            { 247, 4, "153305", "Clanwilliam", null, null },
        //            { 248, 4, "104609", "Claremont", null, null },
        //            { 249, 4, "101109", "Constantia", null, null },
        //            { 250, 4, "103710", "Durbanville", null, null },
        //            { 251, 4, "153614", "Garden Route", null, null },
        //            { 252, 4, "198765", "Garden Route Mall", null, null },
        //            { 253, 4, "109114", "George", null, null },
        //            { 254, 4, "134512", "Hermanus", null, null },
        //            { 255, 4, "187505", "Inland Garden Route", null, null },
        //            { 256, 4, "172305", "Khayelitsha", null, null },
        //            { 257, 4, "172305", "Khayelitsha Mall", null, null },
        //            { 258, 4, "108914", "Knysna", null, null },
        //            { 259, 4, "112305", "Kraaifontein", null, null },
        //            { 260, 4, "115310", "Kuilsriver", null, null },
        //            { 261, 4, "154605", "Malmesbury", null, null },
        //            { 262, 4, "144905", "Mitchells Plain", null, null },
        //            { 263, 4, "144905", "Mitchell's Plain", null, null },
        //            { 264, 4, "168905", "Mossel Bay", null, null },
        //            { 265, 4, "110634", "Nonqubela", null, null },
        //            { 266, 4, "175205", "Oudtshoorn", null, null },
        //            { 267, 4, "102210", "Paarl", null, null },
        //            { 268, 4, "114810", "Paarl Lady Grey St", null, null },
        //            { 269, 4, "102510", "Parow", null, null },
        //            { 270, 4, "107510", "Phillipi", null, null },
        //            { 271, 4, "104709", "Pinelands", null, null },
        //            { 272, 4, "107909", "Promenade Mall", null, null },
        //            { 273, 4, "162645", "Riversdal", null, null },
        //            { 274, 4, "104809", "Rondebosch", null, null },
        //            { 275, 4, "114145", "Somerset mall", null, null },
        //            { 276, 4, "107110", "Stellenbosch", null, null },
        //            { 277, 4, "132105", "Swellendam", null, null },
        //            { 278, 4, "144905", "Town Centre", null, null },
        //            { 279, 4, "118602", "Tygerberg", null, null },
        //            { 280, 4, "149821", "Winelands Stellenbosch", null, null },
        //            { 281, 4, "101507", "Worcester", null, null },
        //            { 282, 4, "109114", "York Street", null, null },
        //            { 283, 4, "147005", "Zomelust Estate Paarl", null, null },
        //            { 284, 4, null, "147005", null, null },
        //            { 285, 4, null, "ANTIANTIC", null, null },
        //            { 286, 4, null, "ANTLANTIS", null, null },
        //            { 287, 4, null, "Beaufort - West", null, null },
        //            { 288, 4, null, "Bellville CBD", null, null },
        //            { 289, 4, null, "BELLVILLE CDB", null, null },
        //            { 290, 4, null, "caldeon", null, null },
        //            { 291, 4, null, "CAVENDISH", null, null },
        //            { 292, 4, null, "CHURCH SQUARE  KUILS RIVIER", null, null },
        //            { 293, 4, null, "HELDERBERG KOMMERSIELE", null, null },
        //            { 294, 4, null, "KAAP KOMMERSIEEL", null, null },
        //            { 295, 4, null, "KUILSRIVIER", null, null },
        //            { 296, 4, null, "Mitchells Plain Town Centre", null, null },
        //            { 297, 4, null, "Mitchell's Plain, Promenade Mall", null, null },
        //            { 298, 4, null, "Montaque Gardens", null, null },
        //            { 299, 4, null, "Mosselbay", null, null },
        //            { 300, 4, null, "PROMINADE", null, null },
        //            { 301, 4, null, "Seapoint", null, null },
        //            { 302, 4, null, "Somerset", null, null },
        //            { 303, 4, null, "Somerset Wesr", null, null },
        //            { 304, 4, null, "SOMERSET WEST", null, null },
        //            { 305, 4, null, "TYGERBERG WINELANDS", null, null },
        //            { 306, 4, null, "Winelands", null, null },
        //            { 307, 4, "50212", "grabouw", null, null },
        //            { 308, 5, "26609", "Athlone", null, null },
        //            { 309, 5, "51001", "Bayside", null, null },
        //            { 310, 5, "4805", "Braamfontein", null, null },
        //            { 311, 5, "30310", "Brackenfell", null, null },
        //            { 312, 5, "50011", "Citrusdal", null, null },
        //            { 313, 5, "50106", "Clanwilliam", null, null },
        //            { 314, 5, "31010", "Goodwood", null, null },
        //            { 315, 5, "51108", "Lainsburg", null, null },
        //            { 316, 5, "51001", "LYNNWOOD RIDGE", null, null },
        //            { 317, 5, "6105", "Mellville", null, null },
        //            { 318, 5, "6305", "Northcliff", null, null },
        //            { 319, 5, "51001", "Parow West", null, null },
        //            { 320, 5, "25309", "Plumstead", null, null },
        //            { 321, 5, "25009", "Rondeboch", null, null },
        //            { 322, 5, "24109", "Sea Point", null, null },
        //            { 323, 5, "33112", "Strand", null, null },
        //            { 324, 5, "51001", "Thembalethu George", null, null },
        //            { 325, 5, "20909", "Thibault Sqaure", null, null },
        //            { 326, 5, "50307", "Tulbagh", null, null },
        //            { 327, 5, null, "All Branches", null, null },
        //            { 328, 5, "50008", "Beaufort West", null, null },
        //            { 329, 5, "51001", "Bellville", null, null },
        //            { 330, 5, "25609", "Blue Route", null, null },
        //            { 331, 5, "50112", "Caledon", null, null },
        //            { 332, 5, "50014", "Calitzdorp", null, null },
        //            { 333, 5, "23910", "Cape Gate", null, null },
        //            { 334, 5, "20009", "Cape Town", null, null },
        //            { 335, 5, "50007", "Ceres", null, null },
        //            { 336, 5, "25109", "Claremont", null, null },
        //            { 337, 5, "25309", "Constantia", null, null },
        //            { 338, 5, "50111", "Darling", null, null },
        //            { 339, 5, "50107", "De Doorns", null, null },
        //            { 340, 5, "50114", "De rust", null, null },
        //            { 341, 5, "36009", "Fish Hoek", null, null },
        //            { 342, 5, "25909", "Gatesville", null, null },
        //            { 343, 5, "50214", "George", null, null },
        //            { 344, 5, "50212", "Grabouw", null, null },
        //            { 345, 5, "33012", "Helderberg", null, null },
        //            { 346, 5, "50312", "Hermanus", null, null },
        //            { 347, 5, "25909", "Khayelitsha", null, null },
        //            { 348, 5, "50314", "Knysna", null, null },
        //            { 349, 5, "26209", "Kromboom", null, null },
        //            { 350, 5, "50611", "Laaiplek", null, null },
        //            { 351, 5, "50113", "Ladismith", null, null },
        //            { 352, 5, "50206", "Lamberts Bay", null, null },
        //            { 353, 5, "50507", "Malmesbury", null, null },
        //            { 354, 5, "26509", "Milnerton", null, null },
        //            { 355, 5, "50213", "Montagu", null, null },
        //            { 356, 5, "50414", "Mossel Bay", null, null },
        //            { 357, 5, "24909", "Mowbray", null, null },
        //            { 358, 5, "50514", "Oudtshoorn", null, null },
        //            { 359, 5, "50210", "Paarl", null, null },
        //            { 360, 5, "31110", "Parow", null, null },
        //            { 361, 5, "50411", "Piketberg", null, null },
        //            { 362, 5, "36309", "Pinelands", null, null },
        //            { 363, 5, "50714", "Plettenberg Bay", null, null },
        //            { 364, 5, "50207", "Porterville", null, null },
        //            { 365, 5, "26609", "Promenade", null, null },
        //            { 366, 5, "50413", "Robertson", null, null },
        //            { 367, 5, "25009", "Rondebosch", null, null },
        //            { 368, 5, "33012", "Somerset mall", null, null },
        //            { 369, 5, "50610", "Stellenbosch", null, null },
        //            { 370, 5, "50513", "Swellendam", null, null },
        //            { 371, 5, "102510", "Thibault Square", null, null },
        //            { 372, 5, "50410", "Tyger Manor", null, null },
        //            { 373, 5, "50215", "Uniondale", null, null },
        //            { 374, 5, "25909", "Vangate Mall", null, null },
        //            { 375, 5, "50511", "Vredenburg", null, null },
        //            { 376, 5, "50706", "Vredendal", null, null },
        //            { 377, 5, "50710", "Wellington", null, null },
        //            { 378, 5, "50407", "Worcester", null, null },
        //            { 379, 5, "25309", "Wynberg", null, null },
        //            { 380, 5, null, "Beaufort- West", null, null },
        //            { 381, 5, null, "Blue Route Centre", null, null },
        //            { 382, 5, null, "BLUE ROUTE MALL, TOKAI", null, null },
        //            { 383, 5, null, "Hyde Park", null, null },
        //            { 384, 5, null, "Johannesburg", null, null },
        //            { 385, 5, null, "Kroomboom", null, null },
        //            { 386, 5, null, "LAMBERSBAAI", null, null },
        //            { 387, 5, null, "LAMBERTSBAAI", null, null },
        //            { 388, 5, null, "Lambertsbay", null, null },
        //            { 389, 5, null, "MISGUND", null, null },
        //            { 390, 5, null, "Mobray", null, null },
        //            { 391, 5, null, "Mosselbaai", null, null },
        //            { 392, 5, null, "Mosselbay", null, null },
        //            { 393, 5, null, "Mowbray Cape Town", null, null },
        //            { 394, 5, null, "Parow centre", null, null },
        //            { 395, 5, null, "PORTVILLE", null, null },
        //            { 396, 5, null, "Promenade 1", null, null },
        //            { 397, 5, null, "Prominade", null, null },
        //            { 398, 5, null, "PROMINADE 1", null, null },
        //            { 399, 5, null, "Somerset West", null, null },
        //            { 400, 5, null, "Thibaullt Square", null, null },
        //            { 401, 5, null, "Tygar Manor", null, null },
        //            { 402, 5, null, "TYGER MINOR", null, null },
        //            { 403, 5, null, "tyger minor duplicate", null, null },
        //            { 404, 5, null, "TYGERMINOR", null, null },
        //            { 405, 5, null, "TYGOR MINOR", null, null },
        //            { 406, 5, null, "Universal Code", null, null },
        //            { 407, 5, null, "Van Rhynsdorp", null, null },
        //            { 408, 5, null, "VANGATE", null, null },
        //            { 409, 6, null, "Walvis Bay", null, null },
        //            { 410, 6, null, "All Branches", null, null },
        //            { 411, 7, "450109", "Cape Town", null, null },
        //            { 412, 7, "198765", "Oudtshoorn", null, null },
        //            { 413, 7, null, "All Branches", null, null },
        //            { 414, 8, null, "Bloemfontein", null, null },
        //            { 415, 8, null, "LANGA", null, null },
        //            { 416, 8, null, "Phillipi Post Office", null, null },
        //            { 417, 8, "26209", "Kromboom", null, null },
        //            { 418, 8, "51001", "Oudtshoorn", null, null },
        //            { 419, 8, null, "All Branches", null, null },
        //            { 420, 8, null, "Kroomboom", null, null },
        //            { 421, 9, "000000", "Default", null, null }
        //        });

        //    migrationBuilder.InsertData(
        //        schema: "dbo",
        //        table: "CompliantCycleRules",
        //        columns: new[] { "Id", "CycleNumber", "UpdatedDateTime", "UpdatedUserId" },
        //        values: new object[,]
        //        {
        //            { 1, 1, null, null },
        //            { 2, 2, null, null },
        //            { 3, 3, null, null },
        //            { 4, 4, null, null }
        //        });

        //    migrationBuilder.InsertData(
        //        schema: "core",
        //        table: "Departments",
        //        columns: new[] { "Id", "Abbreviation", "DenodoDepartmentName", "IsActive", "Name", "UpdatedDateTime", "UpdatedUserId" },
        //        values: new object[] { 1, "ALL", "Not Applicable", true, "All Departments", null, null });

        //    migrationBuilder.InsertData(
        //        schema: "core",
        //        table: "Departments",
        //        columns: new[] { "Id", "Abbreviation", "DenodoDepartmentName", "Name", "UpdatedDateTime", "UpdatedUserId" },
        //        values: new object[,]
        //        {
        //            { 2, "DEDAT", "Western Cape Economic Development And Tourism", "Economic Development and Tourism", null, null },
        //            { 3, "WCMD", "Western Cape Mobility", "Mobility", null, null },
        //            { 4, "WCED", "Western Cape Education", "Education", null, null },
        //            { 5, "DOTP", "Western Cape Premier", "Premier", null, null },
        //            { 6, "PT", "Western Cape Treasury", "Provincial Treasury", null, null },
        //            { 7, "DSD", "Western Cape Social Development", "Social Development", null, null },
        //            { 8, "DOA", "Western Cape Agriculture", "Agriculture", null, null },
        //            { 9, "DOCS", "Western Cape Police Oversight and Community Safety", "Police Oversight and Community Safety", null, null },
        //            { 10, "DCAS", "Western Cape Cultural Affairs And Sport", "Cultural Affairs and Sport", null, null }
        //        });

        //    migrationBuilder.InsertData(
        //        schema: "core",
        //        table: "Departments",
        //        columns: new[] { "Id", "Abbreviation", "DenodoDepartmentName", "IsActive", "Name", "UpdatedDateTime", "UpdatedUserId" },
        //        values: new object[] { 11, "DOH", "Western Cape Government: Health and Wellness", true, "Health and Wellness", null, null });

        //    migrationBuilder.InsertData(
        //        schema: "core",
        //        table: "Departments",
        //        columns: new[] { "Id", "Abbreviation", "DenodoDepartmentName", "Name", "UpdatedDateTime", "UpdatedUserId" },
        //        values: new object[,]
        //        {
        //            { 12, "DOI", "Western Cape Infrastructure", "Infrastructure", null, null },
        //            { 13, "DLG", "Western Cape Local Government", "Local Government", null, null },
        //            { 14, "WCPP", "Not Applicable", "Provincial Parliament", null, null },
        //            { 15, "DEA&DP", "Western Cape Environmental Affairs Development Planning", "Environmental Affairs and Development Planning", null, null }
        //        });

        //    migrationBuilder.InsertData(
        //        schema: "core",
        //        table: "Departments",
        //        columns: new[] { "Id", "Abbreviation", "DenodoDepartmentName", "IsActive", "Name", "UpdatedDateTime", "UpdatedUserId" },
        //        values: new object[] { 16, "NONE", "Not Applicable", true, "None", null, null });

        //    migrationBuilder.InsertData(
        //        schema: "dropdown",
        //        table: "Directorates",
        //        columns: new[] { "Id", "Description", "Name", "UpdatedDateTime", "UpdatedUserId" },
        //        values: new object[,]
        //        {
        //            { 1, "", "Children and Families", null, null },
        //            { 2, "", "Community Development", null, null },
        //            { 3, "", "ECD & Partial Care", null, null },
        //            { 4, "", "Facility Management", null, null },
        //            { 5, "", "Partnership Development", null, null },
        //            { 6, "Restorative Services new 2021 VEP, CP, SA", "Restorative Services", null, null },
        //            { 7, "", "Social Crime Prevention", null, null },
        //            { 8, "", "Special Programmes", null, null }
        //        });

        //    migrationBuilder.InsertData(
        //        schema: "dropdown",
        //        table: "DistrictCouncils",
        //        columns: new[] { "Id", "Name", "UpdatedDateTime", "UpdatedUserId" },
        //        values: new object[,]
        //        {
        //            { 7, "Cape Winelands", null, null },
        //            { 8, "Central Karoo", null, null },
        //            { 9, "City of Cape Town", null, null },
        //            { 10, "Eden", null, null },
        //            { 11, "Overberg", null, null },
        //            { 12, "West Coast", null, null }
        //        });

        //    migrationBuilder.InsertData(
        //        schema: "core",
        //        table: "DocumentTypes",
        //        columns: new[] { "Id", "Description", "Location", "Name", "UpdatedDateTime", "UpdatedUserId" },
        //        values: new object[,]
        //        {
        //            { 1, null, "Workplan", "SLA", null, null },
        //            { 2, null, "Workplan", "Signed SLA", null, null }
        //        });

        //    migrationBuilder.InsertData(
        //        schema: "core",
        //        table: "DocumentTypes",
        //        columns: new[] { "Id", "Description", "IsActive", "Location", "Name", "UpdatedDateTime", "UpdatedUserId" },
        //        values: new object[,]
        //        {
        //            { 8, "NPO Registration Certificate (copy)", true, "FundApp", "NPO Reg Cert", null, null },
        //            { 10, "Organisation Constitution (most recent copy)", true, "FundApp", "Constitution", null, null },
        //            { 11, "Statutory Registration Certificates (copies of all applicable)", true, "FundApp", "Supporting", null, null },
        //            { 12, "Bank details confirmation letter (New applicants only)", true, "FundApp", "Bank Letter", null, null },
        //            { 13, "A copy of the Organisations’ most recent", true, "FundApp", "Audited Annual Financial Statement", null, null },
        //            { 14, "A copy of the Organisations’ most recent Certified Financial Statements by a registered accountant, if income is less than R600 000.00 per annum", true, "FundApp", "Certified Financial Statement", null, null },
        //            { 15, "Written assurance in terms of Section 38 of the PFMA", true, "FundApp", "PFMA", null, null },
        //            { 16, "Organisations last 3 month’s Bank Statements \r\n\r\n(Only applicable for organisations not funded in 2023/24 applying for less than R600 000.00 funding) ", true, "FundApp", "Bank Statements", null, null },
        //            { 17, "BAS Entity Form (NPOs funded in 2023/24 only)", true, "FundApp", "BAS Entity Form", null, null },
        //            { 18, "Application Declaration", true, "FundApp", "Application Declaration", null, null },
        //            { 19, "Schedule A: Enrolment Form", true, "FundApp", "Enrolment Form", null, null },
        //            { 20, "Signed Declaration of Interest", true, "FundApp", "Signed Declaration of Interest", null, null },
        //            { 21, "NPO Supporting Documents", true, "QuickCapture", "NPO Supporting Documents", null, null },
        //            { 22, "Declaration of Interest", true, "FundedNpo", "Declaration of Interest", null, null },
        //            { 23, "Declaration of Bidder Interest", true, "FundedNpo", "Declaration of Bidder Interest", null, null },
        //            { 24, "Duly Authorized Representative Signature", true, "FundedNpo", "Duly Authorized Representative Signature", null, null },
        //            { 25, "Testimonials", true, "FundedNpo", "Testimonials", null, null },
        //            { 26, "Others", true, "FundedNpo", "Others", null, null },
        //            { 27, "Business Plan", true, "FundedNpo", "BusinessPlan", null, null }
        //        });

        //    migrationBuilder.InsertData(
        //        schema: "core",
        //        table: "EmailAccounts",
        //        columns: new[] { "Id", "Description", "EnableSSL", "FromDisplayName", "FromEmail", "Host", "Password", "Port", "UpdatedDateTime", "UpdatedUserId", "UserName" },
        //        values: new object[] { 1, "default account", false, "NPO Management System", "no-reply@westerncape.gov.za", "https://wa-taps-smtp-nonprod-zan.azurewebsites.net/api/user/EmailSend", null, 25, null, null, null });

        //    migrationBuilder.InsertData(
        //        schema: "core",
        //        table: "EmailTemplates",
        //        columns: new[] { "Id", "Body", "Description", "Name", "Subject" },
        //        values: new object[,]
        //        {
        //            { 1, "<p>Dear {ToUserFullName},</p><p>Access to <span style=\"font-weight: bold;\">{NpoName}</span> has been sent to be reviewed.</p><p>Please <a href=\"{url}\">click here</a> to access the NPO MS application.</p><p>Kind Regards,<br>NPO MS Team</p>", null, "NewAccessRequest", "Access Request Created" },
        //            { 2, "<p>Dear {ToUserFullName},</p><p>Please review access for <span style=\"font-weight: bold;\">{UserAccessFullName}</span> to the following Organisation: <span style=\"font-weight: bold;\">{NpoName}</span>.</p><p>Please <a href=\"{url}/#/access-review\">click here</a> to access the NPO MS application.</p><p>Kind Regards,<br>NPO MS Team</p>", null, "AccessRequestPending", "Access Request Submitted" },
        //            { 3, "<p>Dear {ToUserFullName},</p><p>Access to <span style=\"font-weight: bold;\">{NpoName}</span> has been approved.</p><p>Please <a href=\"{url}\">click here</a> to access the NPO MS application.</p><p>Kind Regards,<br>NPO MS Team</p>", null, "AccessRequestApproved", "Access Request Approved" },
        //            { 4, "<p>Dear {ToUserFullName},</p><p>Access to <span style=\"font-weight: bold;\">{NpoName}</span> has been rejected.</p><p>Please <a href=\"{url}\">click here</a> to access the NPO MS application.</p><p>Kind Regards,<br>NPO MS Team</p>", null, "AccessRequestRejected", "Access Request Rejected" },
        //            { 5, "<p>Dear {ToUserFullName},</p><p>The application for <span style=\"font-weight: bold;\">{NPO}</span> has been sent to be reviewed. The Reference Number is <span style=\"font-weight: bold;\">{ApplicationRefNo}</span>.</p><p>Please <a href=\"{url}/#/applications\">click here</a> to access the NPO MS application.</p><p>Kind Regards,<br>NPO MS Team</p>", null, "NewApplication", "Application Submitted - {NPO}" },
        //            { 6, "<p>Dear {ToUserFullName},</p><p>The application with Reference Number <span style=\"font-weight: bold;\">{ApplicationRefNo}</span> has been submitted for you to review.</p><p>Please <a href=\"{url}/#/applications\">click here</a> to access the NPO MS application.</p><p>Kind Regards,<br>NPO MS Team</p>", null, "StatusChangedPendingReview", "Application Pending Review - {NPO}" },
        //            { 7, "<p>Dear {ToUserFullName},</p><p>There are changes required to the application with Reference Number <span style=\"font-weight: bold;\">{ApplicationRefNo}</span>.</p><p>Please <a href=\"{url}/#/applications\">click here</a> to access the NPO MS application.</p><p>Kind Regards,<br>NPO MS Team</p>", null, "StatusChangedAmendmentsRequired", "Amendments Required - {NPO}" },
        //            { 8, "<p>Dear {ToUserFullName},</p><p>The application with Reference Number <span style=\"font-weight: bold;\">{ApplicationRefNo}</span> has been sent for you to approve.</p><p>Please <a href=\"{url}/#/applications\">click here</a> to access the NPO MS application.</p><p>Kind Regards,<br>NPO MS Team</p>", null, "StatusChangedPendingApproval", "Application Pending Approval - {NPO}" },
        //            { 9, "<p>Dear {ToUserFullName},</p><p>The application with Reference Number <span style=\"font-weight: bold;\">{ApplicationRefNo}</span> has been rejected.</p><p>Please <a href=\"{url}/#/applications\">click here</a> to access the NPO MS application.</p><p>Kind Regards,<br>NPO MS Team</p>", null, "StatusChangedRejected", "Application Rejected - {NPO}" },
        //            { 10, "<p>Dear {ToUserFullName},</p><p>The application with Reference Number <span style=\"font-weight: bold;\">{ApplicationRefNo}</span> has been approved.</p><p>Please upload the SLA document.</p><p>Please <a href=\"{url}/#/applications\">click here</a> to access the NPO MS application.</p><p>Kind Regards,<br>NPO MS Team</p>", null, "StatusChangedPendingSLA", "Application Pending SLA - {NPO}" },
        //            { 11, "<p>Dear {ToUserFullName},</p><p>The application with Reference Number <span style=\"font-weight: bold;\">{ApplicationRefNo}</span> has been approved.</p><p>Please download the SLA document that requires your signature and upload the signed SLA document.</p><p>Please <a href=\"{url}/#/applications\">click here</a> to access the NPO MS application.</p><p>Kind Regards,<br>NPO MS Team</p>", null, "StatusChangedPendingSignedSLA", "Application Pending Signed SLA - {NPO}" },
        //            { 12, "<p>Dear {ToUserFullName},</p><p>The signed SLA document has been uploaded for application with Reference Number <span style=\"font-weight: bold;\">{ApplicationRefNo}</span>.</p><p>Please <a href=\"{url}/#/applications\">click here</a> to access the NPO MS application.</p><p>Kind Regards,<br>NPO MS Team</p>", null, "StatusChangedAcceptedSLA", "Application Accepted SLA - {NPO}" },
        //            { 13, "<p>Dear {ToUserFullName},</p><p>Please review the comments regarding the SLA document for application with Reference Number <span style=\"font-weight: bold;\">{ApplicationRefNo}</span>.</p><p>Please <a href=\"{url}/#/applications\">click here</a> to access the NPO MS application.</p><p>Kind Regards,<br>NPO MS Team</p>", null, "StatusChangedDeptComments", "Review SLA Comments by Department - {NPO}" },
        //            { 14, "<p>Dear {ToUserFullName},</p><p>Please review the comments regarding the SLA document for application with Reference Number <span style=\"font-weight: bold;\">{ApplicationRefNo}</span>.</p><p>Please <a href=\"{url}/#/applications\">click here</a> to access the NPO MS application.</p><p>Kind Regards,<br>NPO MS Team</p>", null, "StatusChangedOrgComments", "Review SLA Comments by Organisation - {NPO}" },
        //            { 15, "<p>Dear {ToUserFullName},</p><p>Organisation Profile for <span style=\"font-weight: bold;\">{NpoName}</span> has been updated and sent to be reviewed.</p><p>Please <a href=\"{url}\">click here</a> to access the NPO MS application.</p><p>Kind Regards,<br>NPO MS Team</p>", null, "NewOrganisationApproval", "Organisation Profile Updated - {NpoName}" },
        //            { 16, "<p>Dear {ToUserFullName},</p><p>Please review the following Organisation: <span style=\"font-weight: bold;\">{NpoName}</span>.</p><p>Please <a href=\"{url}/#/npo-approval\">click here</a> to access the NPO MS application.</p><p>Kind Regards,<br>NPO MS Team</p>", null, "PendingOrganisationApproval", "Pending Organisation Approval - {NpoName}" },
        //            { 17, "<p>Dear {ToUserFullName},</p><p>The following Organisation: <span style=\"font-weight: bold;\">{NpoName}</span> has been approved.</p><p>Please <a href=\"{url}\">click here</a> to access the NPO MS application.</p><p>Kind Regards,<br>NPO MS Team</p>", null, "ApprovedOrganisationApproval", "Organisation Approved - {NpoName}" },
        //            { 18, "<p>Dear {ToUserFullName},</p><p>The following Organisation: <span style=\"font-weight: bold;\">{NpoName}</span> has been rejected.</p><p>Please <a href=\"{url}\">click here</a> to access the NPO MS application.</p><p>Kind Regards,<br>NPO MS Team</p>", null, "RejectedOrganisationApproval", "Organisation Rejected - {NpoName}" },
        //            { 19, "<p>Dear {ToUserFullName},</p><p>The indicator actuals for application with Reference Number <span style=\"font-weight: bold;\">{ApplicationRefNo}</span> has been updated with a status of <span style=\"font-weight: bold;\">{status}</span>.</p><p>The financial year and month is <span style=\"font-weight: bold;\">{financialYear}</span> and <span style=\"font-weight: bold;\">{frequencyPeriod}</span> respectively.</p><p>Please <a href=\"{url}/#/workplan-indicator/manage/{npoId}\">click here</a> to access the NPO MS application.</p><p>Kind Regards,<br>NPO MS Team</p>", null, "WorkplanActualStatusChanged", "Indicator Actuals {status} - {NPO}" },
        //            { 20, "<p>Dear {ToUserFullName},</p><p>The indicator actuals for application with Reference Number <span style=\"font-weight: bold;\">{ApplicationRefNo}</span> has been submitted for you to review.</p><p>The financial year and month is <span style=\"font-weight: bold;\">{financialYear}</span> and <span style=\"font-weight: bold;\">{frequencyPeriod}</span> respectively.</p><p>Please <a href=\"{url}/#/workplan-indicator/manage/{npoId}\">click here</a> to access the NPO MS application.</p><p>Kind Regards,<br>NPO MS Team</p>", null, "WorkplanActualPendingReview", "Indicator Actuals Pending Review - {NPO}" },
        //            { 21, "<p>Dear {ToUserFullName},</p><p>The indicator actuals for application with Reference Number <span style=\"font-weight: bold;\">{ApplicationRefNo}</span> has been sent for you to approve.</p><p>The financial year and month is <span style=\"font-weight: bold;\">{financialYear}</span> and <span style=\"font-weight: bold;\">{frequencyPeriod}</span> respectively.</p><p>Please <a href=\"{url}/#/workplan-indicator/manage/{npoId}\">click here</a> to access the NPO MS application.</p><p>Kind Regards,<br>NPO MS Team</p>", null, "WorkplanActualPendingApproval", "Indicator Actuals Pending Approval - {NPO}" },
        //            { 22, "<p>Dear {ToUserFullName},</p><p>The application with Reference Number <span style=\"font-weight: bold;\">{ApplicationRefNo}</span> has been sent to you to indicate your reviewer satisfaction.</p><p>Please ignore this email if you have indicated your reviewer satisfaction.</p><p>Please <a href=\"{url}/#/applications\">click here</a> to access the NPO MS application.</p><p>Kind Regards,<br>NPO MS Team</p>", null, "StatusChangedPendingReviewerSatisfaction", "Application Pending Reviewer Satisfaction - {NPO}" },
        //            { 23, "<p>Dear {ToUserFullName}</p><p>The Scorecard for application with reference number</p><p><strong>{ApplicationRefNo}</strong> for financial year<strong> {financialYear} </strong> has been completed.</p><p>To view the scorecard summary please&nbsp;</p><p><a href=\"{url}/#/reviewScorecard/{npoId}(print:print/{npoId}/2)\">click here</a> to download a printable version.</p><p>Kind Regards,</p><p>NPO MS Team</p>", null, "ScorecardSummary", "Scorecard Summary Review - {NPO}" },
        //            { 24, "<p>Dear {ToUserFullName}</p><p>The Scorecard for <strong>{organisationName}</strong> with reference number <strong>{ApplicationRefNo}</strong> is now available for rating.</p><p>Please <a href=\"{url}/#/scorecard/{ApplicationId}\">click here</a> to access this scorecard.</p><p>Kind Regards,</p><p>NPO MS Team</p>", null, "InitiateScorecard", "Scorecard Initiated Notification - {NPO}" },
        //            { 25, "<p>Dear {ToUserFullName}</p><p>The Scorecard for <strong>{organisationName}</strong> with reference number <strong>{ApplicationRefNo}</strong> requires amendments.</p><p>To make the amendments, please <a href=\"{url}/#/scorecard/{ApplicationId}\">click here</a> to access.</p><p>Kind Regards,</p><p>NPO MS Team</p>", null, "RejectedScorecard", "Scorecard Amendment Notification - {NPO}" },
        //            { 26, "<p>Dear {ToUserFullName}</p><p>The Scorecard for <strong>{organisationName}</strong> with reference number <strong>{ApplicationRefNo}</strong> has been resubmitted.</p><p>To review the amended scorecard, please <a href=\"{url}/#/reviewScorecard/{ApplicationId}\">click here</a> to access.</p><p>Kind Regards,</p><p>NPO MS Team</p>", null, "AmendedScorecard", "Amended Scorecard Notification - {NPO}" }
        //        });

        //    migrationBuilder.InsertData(
        //        schema: "core",
        //        table: "EmbeddedReports",
        //        columns: new[] { "Id", "CategoryName", "Description", "Name", "ReportId", "UpdatedDateTime", "UpdatedUserId", "WorkspaceId" },
        //        values: new object[] { 1, "Dashboard", "Dashboard view everything on the system", "Dashboard", "270ec198-88c7-4e9b-b429-b6b99ace164f", null, null, "38cbb1ed-23d8-4c7d-830a-4f7a39086eca" });

        //    migrationBuilder.InsertData(
        //        schema: "core",
        //        table: "EntityTypes",
        //        columns: new[] { "Id", "Name", "SystemName", "UpdatedDateTime", "UpdatedUserId" },
        //        values: new object[,]
        //        {
        //            { 1, "Supporting Documents", "SupportingDocuments", null, null },
        //            { 2, "SLA", "SLA", null, null },
        //            { 3, "Workplan Actuals", "WorkplanActuals", null, null }
        //        });

        //    migrationBuilder.InsertData(
        //        schema: "dropdown",
        //        table: "FacilityClasses",
        //        columns: new[] { "Id", "Name", "UpdatedDateTime", "UpdatedUserId" },
        //        values: new object[,]
        //        {
        //            { 1, "Mobile Service", null, null },
        //            { 2, "Health Post", null, null },
        //            { 3, "Special School", null, null },
        //            { 4, "Non-medical Site", null, null },
        //            { 5, "Reproductive Health Centre", null, null },
        //            { 6, "Primary School", null, null },
        //            { 7, "Community Day Centre", null, null },
        //            { 8, "Intermediate Care", null, null },
        //            { 9, "Private Pharmacy", null, null },
        //            { 10, "Occupational Health Centre", null, null },
        //            { 11, "Clinic", null, null },
        //            { 12, "Independent Cons Rooms - General Practitioner", null, null },
        //            { 13, "Private Hospital", null, null },
        //            { 14, "Independent Cons Rooms - Registered Practitioner", null, null },
        //            { 15, "Community Health Centre", null, null },
        //            { 16, "Private Clinic", null, null },
        //            { 17, "Community Health Centre (After hours)", null, null },
        //            { 18, "Dental Clinic", null, null },
        //            { 19, "Day Care Centre", null, null },
        //            { 20, "Home Based Care", null, null },
        //            { 21, "Correctional Centre", null, null },
        //            { 22, "Hospice unit", null, null },
        //            { 23, "Satellite Clinic", null, null },
        //            { 24, "Specialised Rehabilitation Unit", null, null },
        //            { 25, "Specialised TB Hospital", null, null },
        //            { 26, "Community Health Centre / Clinic", null, null },
        //            { 27, "District Hospital", null, null },
        //            { 28, "Sickbay", null, null },
        //            { 29, "Pharmacy Depot", null, null },
        //            { 30, "Step Down Facility", null, null },
        //            { 31, "Environmental Health Office", null, null },
        //            { 32, "Health Promotion Service", null, null },
        //            { 33, "Special Clinic", null, null },
        //            { 34, "EMS Station", null, null },
        //            { 35, "Frail Care Centre", null, null },
        //            { 36, "Specialised Oral Health Centre", null, null },
        //            { 37, "Regional Hospital", null, null },
        //            { 38, "Medical Centre", null, null },
        //            { 39, "Forensic Pathology Service", null, null },
        //            { 40, "Specialised Hospital", null, null },
        //            { 41, "Midwife Obstetrics Unit", null, null },
        //            { 42, "Independent Cons Rooms - Specialist", null, null },
        //            { 43, "National Central Hospital", null, null },
        //            { 44, "Engineering services", null, null },
        //            { 45, "School Health Services Unit", null, null },
        //            { 46, "Early Childhood Development Centre", null, null },
        //            { 47, "Educare Centre", null, null },
        //            { 48, "Pre-primary School", null, null },
        //            { 49, "Creche", null, null },
        //            { 50, "Secondary School", null, null },
        //            { 51, "Combined School", null, null },
        //            { 52, "Intermediate School", null, null },
        //            { 53, "Preparatory School", null, null },
        //            { 54, "Military Hospital", null, null },
        //            { 55, "Specialised Psychiatric Hospital", null, null },
        //            { 56, "Tertiary Hospital", null, null },
        //            { 57, "Laundry Service", null, null },
        //            { 58, "Organisational unit", null, null },
        //            { 59, "Primary Distribution Site", null, null },
        //            { 60, "Records Repository", null, null }
        //        });

        //    migrationBuilder.InsertData(
        //        schema: "dropdown",
        //        table: "FacilityDistricts",
        //        columns: new[] { "Id", "Name", "UpdatedDateTime", "UpdatedUserId" },
        //        values: new object[,]
        //        {
        //            { 1, "Cape Winelands District Municipality", null, null },
        //            { 2, "City of Cape Town Metropolitan Municipality", null, null },
        //            { 3, "West Coast District Municipality", null, null },
        //            { 4, "Overberg District Municipality", null, null },
        //            { 5, "Garden Route District Municipality", null, null },
        //            { 6, "Central Karoo District Municipality", null, null }
        //        });

        //    migrationBuilder.InsertData(
        //        schema: "dropdown",
        //        table: "FacilityTypes",
        //        columns: new[] { "Id", "Name", "UpdatedDateTime", "UpdatedUserId" },
        //        values: new object[,]
        //        {
        //            { 1, "Facility", null, null },
        //            { 2, "Community Place", null, null }
        //        });

        //    migrationBuilder.InsertData(
        //        schema: "core",
        //        table: "FinancialYears",
        //        columns: new[] { "Id", "EndDate", "Name", "StartDate", "UpdatedDateTime", "UpdatedUserId", "Year" },
        //        values: new object[,]
        //        {
        //            { 1, new DateTime(2022, 3, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), "2021/22", new DateTime(2021, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 2021 },
        //            { 2, new DateTime(2023, 3, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), "2022/23", new DateTime(2022, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 2022 },
        //            { 3, new DateTime(2024, 3, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), "2023/24", new DateTime(2023, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 2023 },
        //            { 4, new DateTime(2025, 3, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), "2024/25", new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 2024 },
        //            { 5, new DateTime(2026, 3, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), "2025/26", new DateTime(2025, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 2025 },
        //            { 6, new DateTime(2027, 3, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), "2026/27", new DateTime(2026, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 2026 },
        //            { 7, new DateTime(2028, 3, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), "2027/28", new DateTime(2027, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 2027 },
        //            { 8, new DateTime(2029, 3, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), "2028/29", new DateTime(2028, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 2028 }
        //        });

        //    migrationBuilder.InsertData(
        //        schema: "dropdown",
        //        table: "Frequencies",
        //        columns: new[] { "Id", "Name", "SystemName", "UpdatedDateTime", "UpdatedUserId" },
        //        values: new object[,]
        //        {
        //            { 1, "Annually", "Annually", null, null },
        //            { 2, "Monthly", "Monthly", null, null },
        //            { 3, "Quarterly", "Quarterly", null, null },
        //            { 4, "Adhoc", "Adhoc", null, null }
        //        });

        //    migrationBuilder.InsertData(
        //        schema: "dropdown",
        //        table: "FrequencyPeriods",
        //        columns: new[] { "Id", "FrequencyId", "Name", "SystemName", "UpdatedDateTime", "UpdatedUserId" },
        //        values: new object[,]
        //        {
        //            { 1, 1, "Annual", "Annual", null, null },
        //            { 2, 2, "April", "Apr", null, null },
        //            { 3, 2, "May", "May", null, null },
        //            { 4, 2, "June", "Jun", null, null },
        //            { 5, 2, "July", "Jul", null, null },
        //            { 6, 2, "August", "Aug", null, null },
        //            { 7, 2, "September", "Sep", null, null },
        //            { 8, 2, "October", "Oct", null, null },
        //            { 9, 2, "November", "Nov", null, null },
        //            { 10, 2, "December", "Dec", null, null },
        //            { 11, 2, "January", "Jan", null, null },
        //            { 12, 2, "February", "Feb", null, null },
        //            { 13, 2, "March", "Mar", null, null },
        //            { 14, 3, "Quarter1", "Q1", null, null },
        //            { 15, 3, "Quarter2", "Q2", null, null },
        //            { 16, 3, "Quarter3", "Q3", null, null },
        //            { 17, 3, "Quarter4", "Q4", null, null }
        //        });

        //    migrationBuilder.InsertData(
        //        schema: "dropdown",
        //        table: "FundingTemplateTypes",
        //        columns: new[] { "Id", "IsActive", "Name", "SystemName", "UpdatedDateTime", "UpdatedUserId" },
        //        values: new object[,]
        //        {
        //            { 1, true, "Funding Application Template", "FundingApplicationTemplate", null, null },
        //            { 2, true, "Score Card Template", "ScoreCardTemplate", null, null },
        //            { 3, true, "Business Plan Template", "BusinessPlanTemplate", null, null }
        //        });

        //    migrationBuilder.InsertData(
        //        schema: "dropdown",
        //        table: "Gender",
        //        columns: new[] { "Id", "Name", "UpdatedDateTime", "UpdatedUserId" },
        //        values: new object[,]
        //        {
        //            { 1, "Female", null, null },
        //            { 2, "Male", null, null },
        //            { 3, "Other", null, null }
        //        });

        //    migrationBuilder.InsertData(
        //        schema: "dropdown",
        //        table: "Languages",
        //        columns: new[] { "Id", "Name", "UpdatedDateTime", "UpdatedUserId" },
        //        values: new object[,]
        //        {
        //            { 1, "Afrikaans", null, null },
        //            { 2, "English", null, null },
        //            { 3, "isiXhosha", null, null }
        //        });

        //    migrationBuilder.InsertData(
        //        schema: "dropdown",
        //        table: "OrganisationTypes",
        //        columns: new[] { "Id", "Description", "Name", "UpdatedDateTime", "UpdatedUserId" },
        //        values: new object[,]
        //        {
        //            { 1, "Non Profit Organisation", "NPO", null, null },
        //            { 2, "Non Profit Company registered as NPO", "NPO/NPC", null, null },
        //            { 3, "Trust registered as NPO", "NPO/Trust", null, null },
        //            { 4, "Voluntary organization registered as NPO", "NPO/VA", null, null },
        //            { 5, "Other Description", "Others", null, null },
        //            { 6, "Section 21 Company", "Section 21 Company", null, null },
        //            { 7, "Sport Description", "Sport", null, null },
        //            { 8, "Trust Description", "Trust", null, null },
        //            { 9, "Pty Ltd", "Pty Ltd", null, null },
        //            { 10, "Close Corporation", "CC", null, null },
        //            { 11, "In Process of ECD Registration", "Reg-ECD", null, null },
        //            { 12, "In Progress of Older Person Registration", "Reg-Old Person", null, null },
        //            { 13, "Non Governmental Organisation", "NGO", null, null }
        //        });

        //    migrationBuilder.InsertData(
        //        schema: "core",
        //        table: "Permissions",
        //        columns: new[] { "Id", "CategoryName", "Name", "SystemName", "UpdatedDateTime", "UpdatedUserId" },
        //        values: new object[,]
        //        {
        //            { 1, "User Administration", "Add Users", "UA.AU", null, null },
        //            { 2, "User Administration", "View List of Users", "UA.VU", null, null },
        //            { 3, "User Administration", "Edit Users", "UA.EU", null, null },
        //            { 4, "Utilities Management", "Add Utilities", "UM.AU", null, null },
        //            { 5, "Utilities Management", "View List of Utilities", "UM.VU", null, null },
        //            { 6, "Utilities Management", "Edit Utilities", "UM.EU", null, null },
        //            { 7, "Permission Management", "View List of Permissions", "PM.VP", null, null },
        //            { 8, "Permission Management", "Edit Permissions", "PM.EP", null, null },
        //            { 9, "Top Navigation", "View Admin Menu", "TN.VAM", null, null },
        //            { 10, "Top Navigation", "View Organisation Profile Menu", "TN.VPM", null, null },
        //            { 11, "Organisation Profile", "Add Organisation Profile", "NP.ANP", null, null },
        //            { 12, "Organisation Profile", "Edit Organisation Profile", "NP.ENP", null, null },
        //            { 13, "Organisation Profile", "View List of Organisation Profiles", "NP.VNP", null, null },
        //            { 14, "Organisation Profile", "Show Organisation Profile Action Buttons", "NP.SPA", null, null },
        //            { 15, "User Administration", "Show User Administration Action Buttons", "UA.SUA", null, null },
        //            { 16, "Top Navigation", "View Apply For Access Menu", "TN.VAAM", null, null },
        //            { 17, "Top Navigation", "View Access Review Menu", "TN.VARM", null, null },
        //            { 18, "User Access Management", "Add User Requests - Apply for access", "UAM.AUR", null, null },
        //            { 19, "User Access Management", "Edit User Requests - Review access requests", "UAM.EUR", null, null },
        //            { 20, "User Access Management", "View List of User Requests", "UAM.VUR", null, null },
        //            { 21, "Top Navigation", "View Organisations Menu", "TN.VNM", null, null },
        //            { 22, "Organisation", "Add Organisation", "NPO.Add", null, null },
        //            { 23, "Organisation", "Edit Organisation", "NPO.Edit", null, null },
        //            { 24, "Organisation", "View List of Organisations", "NPO.View", null, null },
        //            { 25, "Organisation", "Show Organisation Action Buttons", "NPO.SNA", null, null },
        //            { 26, "Top Navigation", "View Application Period (Programme Selection) Menu", "TN.VAPM", null, null },
        //            { 27, "Application Period (Programme Selection)", "Add Application Period (Programme Selection)", "AP.Add", null, null },
        //            { 28, "Application Period (Programme Selection)", "Edit Application Period (Programme Selection)", "AP.Edit", null, null },
        //            { 29, "Application Period (Programme Selection)", "View List of Application Periods (Programme Selection)", "AP.View", null, null },
        //            { 30, "Application Period (Programme Selection)", "Show Application Period (Programme Selection) Action Buttons", "AP.SAPA", null, null },
        //            { 31, "Top Navigation", "View Captured Applications Menu", "TN.VAppM", null, null },
        //            { 32, "Application", "Add Application", "App.Add", null, null },
        //            { 33, "Application", "Edit Application", "App.Edit", null, null },
        //            { 34, "Application", "View List of Applications", "App.View", null, null },
        //            { 35, "Application", "Show Application Action Buttons", "App.SAA", null, null },
        //            { 36, "Top Navigation", "View Organisation Approval Menu", "TN.VNA", null, null },
        //            { 37, "Organisation Approval Management", "Edit Organisation Approval", "NAM.ENR", null, null },
        //            { 38, "Organisation Approval Management", "View List of Organisations for approval requests", "NAM.VNR", null, null },
        //            { 39, "Application", "Review Application", "App.Review", null, null },
        //            { 40, "Application", "Approve Application", "App.Approve", null, null },
        //            { 41, "Application", "Upload SLA Document", "App.Upload", null, null },
        //            { 42, "Application", "View Accepted SLA Application", "App.VAA", null, null },
        //            { 43, "Utilities Management", "Show Utilities Action Buttons", "UM.SUA", null, null },
        //            { 44, "Top Navigation", "View Dashboard Menu", "TN.VDM", null, null },
        //            { 45, "PowerBI Dashboard", "View PowerBI Dashboard", "PBI.VD", null, null },
        //            { 46, "Top Navigation", "View Training Menu", "TN.VTM", null, null },
        //            { 47, "Training Material", "View List of Training Materials", "TM.VTM", null, null },
        //            { 48, "Budgets", "Add Department Budget", "Bud.Add", null, null },
        //            { 49, "Budgets", "Edit Department Budget", "Bud.Edit", null, null },
        //            { 50, "Budgets", "View List of Department Budgets", "Bud.View", null, null },
        //            { 51, "Budgets", "Add Directorate Budget", "Bud.ADB", null, null },
        //            { 52, "Budgets", "Edit Directorate Budget", "Bud.EDB", null, null },
        //            { 53, "Budgets", "View List of Directorate Budgets", "Bud.VDB", null, null },
        //            { 54, "Budgets", "Add Programme Budget", "Bud.APB", null, null },
        //            { 55, "Budgets", "Edit Programme Budget", "Bud.EPB", null, null },
        //            { 56, "Budgets", "View List of Programme Budgets", "Bud.VPB", null, null },
        //            { 57, "Administration - Side Navigation", "View Security Side Menu", "SN.Security", null, null },
        //            { 58, "Administration - Side Navigation", "View Users Side Menu", "SN.Users", null, null },
        //            { 59, "Administration - Side Navigation", "View Permissions Side Menu", "SN.Permissions", null, null },
        //            { 60, "Administration - Side Navigation", "View Settings Side Menu", "SN.Settings", null, null },
        //            { 61, "Administration - Side Navigation", "View Utilities Sub Menu", "SN.Utilities", null, null },
        //            { 62, "Administration - Side Navigation", "View Budgets Sub Menu", "SN.Budgets", null, null },
        //            { 63, "Administration - Side Navigation", "View Department Budget Sub Menu", "SN.DeptBudget", null, null },
        //            { 64, "Administration - Side Navigation", "View Directorate Budget Sub Menu", "SN.DirectorateBudget", null, null },
        //            { 65, "Administration - Side Navigation", "View Programme Budget Sub Menu", "SN.ProgBudget", null, null },
        //            { 66, "Top Navigation", "View Funding Menu", "TN.VFM", null, null },
        //            { 67, "Funding", "Add NPO/Organisation Funding", "Fund.ANF", null, null },
        //            { 68, "Funding", "Edit NPO/Organisation Funding", "Fund.ENF", null, null },
        //            { 69, "Funding", "View NPO/Organisation Funding", "Fund.VNF", null, null },
        //            { 70, "Funding", "Delete NPO/Organisation Funding", "Fund.DNF", null, null },
        //            { 71, "Funding", "View Payment Schedule", "Fund.VPS", null, null },
        //            { 72, "Funding", "View Compliance Check", "Fund.CC", null, null },
        //            { 73, "Funding", "Show NPO/Organisation Funding Action Buttons", "Fund.SNFA", null, null },
        //            { 74, "Administration - Side Navigation", "View Compliant Cycle Sub Menu", "SN.CompliantCycle", null, null },
        //            { 75, "Administration - Side Navigation", "View Payment Schedule Sub Menu", "SN.PaymentSchedule", null, null },
        //            { 76, "Compliant Cycle", "Add Compliant Cycle", "CC.Add", null, null },
        //            { 77, "Compliant Cycle", "View Compliant Cycle", "CC.View", null, null },
        //            { 78, "Compliant Cycle", "Edit Compliant Cycle", "CC.Edit", null, null },
        //            { 79, "Compliant Cycle", "Delete Compliant Cycle", "CC.Delete", null, null },
        //            { 80, "Payment Schedule", "Add Payment Schedule", "PS.Add", null, null },
        //            { 81, "Payment Schedule", "View Payment Schedule", "PS.View", null, null },
        //            { 82, "Payment Schedule", "Edit Payment Schedule", "PS.Edit", null, null },
        //            { 83, "Payment Schedule", "Delete Payment Schedule", "PS.Delete", null, null },
        //            { 84, "Workplan Indicators", "View Workplan Indicator Options", "Indicators.Options", null, null },
        //            { 85, "Workplan Indicators", "View Manage Indicators Option", "Indicators.Manage", null, null },
        //            { 86, "Workplan Indicators", "Capture Workplan Target", "Indicators.CaptureTarget", null, null },
        //            { 87, "Workplan Indicators", "Show Workplan Target Action Buttons", "Indicators.SWTA", null, null },
        //            { 88, "Workplan Indicators", "Capture Workplan Actual", "Indicators.CaptureActual", null, null },
        //            { 89, "Workplan Indicators", "Review or Verify Workplan Actual", "Indicators.ReviewActual", null, null },
        //            { 90, "Workplan Indicators", "Approve Workplan Actual", "Indicators.ApproveActual", null, null },
        //            { 91, "Workplan Indicators", "View Summary Option", "Indicators.Summary", null, null },
        //            { 92, "Workplan Indicators", "Export Summary", "Indicators.ExportSummary", null, null },
        //            { 93, "Funding Application", "Pre-evaluate Application", "FA.PreEvaluate", null, null },
        //            { 94, "Funding Application", "Evaluate Application", "FA.Evaluate", null, null },
        //            { 95, "Funding Application", "Adjudicate Application", "FA.Adjudicate", null, null },
        //            { 96, "Quick Capture", "View Quick Capture", "QC.View", null, null },
        //            { 97, "Quick Capture", "Edit Quick Capture", "QC.Edit", null, null },
        //            { 98, "View Application", "View Submitted Application", "WFA.View", null, null },
        //            { 99, "Download Application", "Download Submitted Application", "WFA.Download", null, null },
        //            { 100, "Download Application", "Edit Application", "WFA.Edit", null, null },
        //            { 101, "Delete Application", "Delete Application", "WFA.Delete", null, null },
        //            { 102, "Pre Evaluate", "Pre Evaluate", "WFA.PreEvaluate", null, null },
        //            { 104, "Pending PreEvaluation", "Pending PreEvaluation", "WFA.PendingPreEvaluation", null, null },
        //            { 105, "Pending Adjudication", "Pending Adjudication", "WFA.PendingAdjudication", null, null },
        //            { 106, "Adjudicate", "Adjudicate", "WFA.Adjudicate", null, null },
        //            { 107, "Pending Evaluation", "Pending Evaluation", "WFA.PendingEvaluation", null, null },
        //            { 108, "Evaluate", "Evaluate", "WFA.Evaluate", null, null },
        //            { 109, "Pending Approval", "Pending Approval", "WFA.PendingApproval", null, null },
        //            { 110, "Approve", "Approve", "WFA.Approve", null, null },
        //            { 111, "Application", "Update Programme Selection on Funding Applications", "App.UAP", null, null },
        //            { 112, "AddScorecard", "Add Score card", "WFA.AddScorecard", null, null },
        //            { 113, "ReviewScorecard", "Review Score card", "WFA.ReviewScorecard", null, null },
        //            { 114, "ViewScorecard", "View Score card", "WFA.ViewScorecard", null, null },
        //            { 115, "InitiateScorecard", "Initiate Score card", "WFA.InitiateScorecard", null, null },
        //            { 116, "CloseScorecard", "Close Score card", "WFA.CloseScorecard", null, null },
        //            { 117, "AdjudicateFundedNpo", "Adjudicate Funded Npo", "WFA.AdjudicateFundedNpo", null, null },
        //            { 118, "ReviewAdjudicatedFundedNpo", "Review Adjudicated FundedNpo", "WFA.ReviewAdjudicatedFundedNpo", null, null },
        //            { 119, "DownloadAssessment", "Download Assessment", "WFA.DownloadAssessment", null, null },
        //            { 120, "Administration - Side Navigation", "View Budget Summary Sub Menu", "SN.BudgetSummary", null, null },
        //            { 121, "Budgets", "View Budget Summary", "Bud.VBS", null, null },
        //            { 122, "Budgets", "Upload Budget", "Bud.UB", null, null },
        //            { 123, "Programme", "Edit capability", "Programme.Edit", null, null },
        //            { 124, "Programme", "Approve Programme", "Programme.Approve", null, null },
        //            { 125, "Programme", "Programme Viewer", "Programme.Viewer", null, null }
        //        });

        //    migrationBuilder.InsertData(
        //        schema: "dropdown",
        //        table: "Positions",
        //        columns: new[] { "Id", "Name", "UpdatedDateTime", "UpdatedUserId" },
        //        values: new object[,]
        //        {
        //            { 1, "Admin Assistant", null, null },
        //            { 2, "Administrative Manager", null, null },
        //            { 3, "Board Member", null, null },
        //            { 4, "CEO", null, null },
        //            { 5, "COO", null, null },
        //            { 6, "Director", null, null },
        //            { 7, "Finance Officer", null, null },
        //            { 8, "Fundraising Officer", null, null },
        //            { 9, "Grants Manager", null, null },
        //            { 10, "Manager", null, null },
        //            { 11, "Operations Director", null, null },
        //            { 12, "Supervisor", null, null },
        //            { 13, "Other", null, null },
        //            { 14, "Principal", null, null },
        //            { 15, "ECD Learner", null, null },
        //            { 16, "Chairperson", null, null },
        //            { 17, "Deputy Chairperson", null, null },
        //            { 18, "Secretary", null, null },
        //            { 19, "Treasurer", null, null },
        //            { 20, "Additional Member", null, null },
        //            { 21, "Social Service Clerk", null, null },
        //            { 22, "Project Manager", null, null },
        //            { 23, "Programme Manager", null, null }
        //        });

        //    migrationBuilder.InsertData(
        //        schema: "dropdown",
        //        table: "Programmes",
        //        columns: new[] { "Id", "Code", "DepartmentId", "Description", "DirectorateId", "Name", "UpdatedDateTime", "UpdatedUserId" },
        //        values: new object[,]
        //        {
        //            { 1, null, 1, "All Programmes", null, "All Programmes", null, null },
        //            { 2, null, 11, "Chronic Diseases and Non-Communicable Diseases", null, "Chronic Diseases and Non-Communicable Diseases", null, null },
        //            { 3, null, 11, "HIV/AIDS, TB, STI", null, "HIV/AIDS, TB, STI", null, null },
        //            { 4, null, 11, "Maternal, Women and Child Health", null, "Maternal, Women and Child Health", null, null },
        //            { 5, null, 11, "Theatre, Surgery and Aneasthetics", null, "Theatre, Surgery and Aneasthetics", null, null },
        //            { 6, null, 11, "Mental Health", null, "Mental Health", null, null },
        //            { 7, null, 11, "Emergency Centre Presures", null, "Emergency Centre Presures", null, null },
        //            { 8, null, 7, "Care and Support to Families", 1, "Care and Support to Families", null, null },
        //            { 9, null, 7, "Child Care and Protection Services", 1, "Child Care and Protection Services", null, null },
        //            { 10, null, 7, "Crime Prevention", 7, "Crime Prevention", null, null },
        //            { 11, null, 7, "ECD & Partial Care", 3, "ECD & Partial Care", null, null },
        //            { 12, null, 7, "EPWP", 2, "EPWP", null, null },
        //            { 13, null, 7, "Facility Managment", 4, "Facility Managment", null, null },
        //            { 14, null, 7, "Institutional Capacity Building", 5, "Institutional Capacity Building", null, null },
        //            { 15, null, 7, "Care and Services to Older Persons", 8, "Care and Services to Older Persons", null, null },
        //            { 16, null, 7, "Services to persons with Disabilities", 8, "Services to persons with Disabilities", null, null },
        //            { 17, null, 7, "Substance Abuse", 8, "Substance Abuse", null, null },
        //            { 18, null, 7, "Sustainable Livelihood", 2, "Sustainable Livelihood", null, null },
        //            { 19, null, 7, "Victim Empowerment", 7, "Victim Empowerment", null, null },
        //            { 20, null, 7, "Youth Development", 2, "Youth Development", null, null },
        //            { 21, null, 7, "Child and Youth Care Centres", 4, "Child and Youth Care Centres", null, null },
        //            { 22, null, 7, "ECD Conditional Grant", 3, "ECD Conditional Grant", null, null },
        //            { 25, null, 11, "All Programmes", null, "All Programmes", null, null }
        //        });

        //    migrationBuilder.InsertData(
        //        schema: "dropdown",
        //        table: "PropertyTypes",
        //        columns: new[] { "Id", "CanDefineName", "Code", "CreatedDateTime", "CreatedUserID", "HaveBreakDown", "HaveFrequency", "HaveRelatedProperty", "IsActive", "IsBusinessRule", "IsDeleted", "Name", "OnGeneralLevel", "OnSubsidyLevel", "UpdatedDateTime", "UpdatedUserID", "ValueOnGeneralLevel", "ValueOnSybsidyLevel" },
        //        values: new object[,]
        //        {
        //            { 1, false, "AdministrationFee", new DateTime(2024, 7, 14, 12, 31, 4, 777, DateTimeKind.Local).AddTicks(7701), 3, false, false, false, true, false, false, "Administration Fee (%)", true, false, null, null, false, true },
        //            { 2, false, "PostItem", new DateTime(2024, 7, 14, 12, 31, 4, 777, DateTimeKind.Local).AddTicks(7706), 3, true, false, false, true, false, false, "Post Cost", true, true, null, null, true, false },
        //            { 3, true, "UnitItem", new DateTime(2024, 7, 14, 12, 31, 4, 777, DateTimeKind.Local).AddTicks(7709), 3, true, true, false, true, false, false, "Unit Cost", false, true, null, null, false, true },
        //            { 4, false, "OperationalItem", new DateTime(2024, 7, 14, 12, 31, 4, 777, DateTimeKind.Local).AddTicks(7712), 3, true, false, true, true, false, false, "Operational Cost (With Break Down)", false, true, null, null, false, false },
        //            { 6, false, "RuleForSocialWorkers", new DateTime(2024, 7, 14, 12, 31, 4, 777, DateTimeKind.Local).AddTicks(7714), 3, false, false, true, true, true, false, "Rule For Social Workers", false, true, null, null, false, false },
        //            { 7, false, "UIFFee", new DateTime(2024, 7, 14, 12, 31, 4, 777, DateTimeKind.Local).AddTicks(7716), 3, false, false, false, true, false, false, "UIF Fee (%)", true, true, null, null, true, false },
        //            { 8, false, "COIDAFee", new DateTime(2024, 7, 14, 12, 31, 4, 777, DateTimeKind.Local).AddTicks(7718), 3, false, false, false, true, false, false, "COIDA Fee (%)", true, false, null, null, true, false }
        //        });

        //    migrationBuilder.InsertData(
        //        schema: "dropdown",
        //        table: "ProvisionTypes",
        //        columns: new[] { "Id", "Name", "SystemName", "UpdatedDateTime", "UpdatedUserId" },
        //        values: new object[,]
        //        {
        //            { 1, "Provided", "Provided", null, null },
        //            { 2, "Required", "Required", null, null }
        //        });

        //    migrationBuilder.InsertData(
        //        schema: "core",
        //        table: "QuarterlyPeriod",
        //        columns: new[] { "Id", "Abbreviation", "Name", "UpdatedDateTime", "UpdatedUserId" },
        //        values: new object[,]
        //        {
        //            { 1, "Q1", "Quarter1", null, null },
        //            { 2, "Q2", "Quarter2", null, null },
        //            { 3, "Q3", "Quarter3", null, null },
        //            { 4, "Q4", "Quarter4", null, null }
        //        });

        //    migrationBuilder.InsertData(
        //        schema: "eval",
        //        table: "QuestionCategories",
        //        columns: new[] { "Id", "FundingTemplateTypeId", "Name", "UpdatedDateTime", "UpdatedUserId" },
        //        values: new object[,]
        //        {
        //            { 1, 1, "Pre-evaluation", null, null },
        //            { 2, 1, "Evaluation", null, null },
        //            { 3, 1, "Adjudication", null, null }
        //        });

        //    migrationBuilder.InsertData(
        //        schema: "dropdown",
        //        table: "Races",
        //        columns: new[] { "Id", "Name", "UpdatedDateTime", "UpdatedUserId" },
        //        values: new object[,]
        //        {
        //            { 1, " Black African", null, null },
        //            { 2, "Indian", null, null },
        //            { 3, "Coloured", null, null },
        //            { 4, "White", null, null },
        //            { 5, "Other", null, null }
        //        });

        //    migrationBuilder.InsertData(
        //        schema: "dropdown",
        //        table: "RecipientTypes",
        //        columns: new[] { "Id", "Name", "SystemName", "UpdatedDateTime", "UpdatedUserId" },
        //        values: new object[,]
        //        {
        //            { 1, "Primary", "Primary", null, null },
        //            { 2, "Sub-Recipient", "SubRecipient", null, null },
        //            { 3, "Sub-SubRecipient", "SubSubRecipient", null, null }
        //        });

        //    migrationBuilder.InsertData(
        //        schema: "dropdown",
        //        table: "RegistrationStatuses",
        //        columns: new[] { "Id", "Name", "SystemName", "UpdatedDateTime", "UpdatedUserId" },
        //        values: new object[,]
        //        {
        //            { 1, "Registered", "Registered", null, null },
        //            { 2, "Not Registered", "NotRegistered", null, null },
        //            { 3, "In Progress", "InProgress", null, null }
        //        });

        //    migrationBuilder.InsertData(
        //        schema: "lookup",
        //        table: "ResourceList",
        //        columns: new[] { "Id", "Description", "Name", "ResourceTypeId", "UpdatedDateTime", "UpdatedUserId" },
        //        values: new object[,]
        //        {
        //            { 1, null, "Project Manager", 1, null, null },
        //            { 2, null, "Project Coordinator", 1, null, null },
        //            { 3, null, "Professional Nurse", 1, null, null },
        //            { 4, null, "Staff Nurse", 1, null, null },
        //            { 5, null, "Register Nurse", 1, null, null },
        //            { 6, null, "Nursing Assistant", 1, null, null },
        //            { 7, null, "Medical Doctor", 1, null, null },
        //            { 8, null, "Research", 1, null, null },
        //            { 9, null, "Facilitator", 1, null, null },
        //            { 10, null, "Councillor", 1, null, null },
        //            { 11, null, "Coordinator", 1, null, null },
        //            { 12, null, "Social Mobilizer", 1, null, null },
        //            { 13, null, "Programme Manager", 1, null, null },
        //            { 14, null, "Support Officer", 1, null, null },
        //            { 15, null, "Field Worker", 1, null, null },
        //            { 16, null, "HR Manager", 1, null, null },
        //            { 17, null, "Finance Manager", 1, null, null },
        //            { 18, null, "Youth Care Worker", 1, null, null },
        //            { 19, null, "Mentor", 1, null, null },
        //            { 20, null, "Mentor Supervisor", 1, null, null },
        //            { 21, null, "Site Administrator", 1, null, null },
        //            { 22, null, "Senior Mentor", 1, null, null },
        //            { 23, null, "Community Health Worker", 1, null, null },
        //            { 24, null, "Pharmacy Manager", 1, null, null },
        //            { 25, null, "Area Manager", 1, null, null }
        //        });

        //    migrationBuilder.InsertData(
        //        schema: "dropdown",
        //        table: "ResourceTypes",
        //        columns: new[] { "Id", "Name", "SystemName", "UpdatedDateTime", "UpdatedUserId" },
        //        values: new object[,]
        //        {
        //            { 1, "HR", "HR", null, null },
        //            { 2, "Other than HR", "Other", null, null }
        //        });

        //    migrationBuilder.InsertData(
        //        schema: "eval",
        //        table: "ResponseOptions",
        //        columns: new[] { "Id", "Name", "ResponseTypeId", "SystemName", "UpdatedDateTime", "UpdatedUserId" },
        //        values: new object[,]
        //        {
        //            { 1, "Yes", 1, "Yes", null, null },
        //            { 2, "No", 1, "No", null, null },
        //            { 3, "Not Applicable", 1, "N/A", null, null },
        //            { 4, "1", 2, "1", null, null },
        //            { 5, "2", 2, "2", null, null },
        //            { 6, "3", 2, "3", null, null },
        //            { 7, "4", 2, "4", null, null },
        //            { 8, "5", 2, "5", null, null }
        //        });

        //    migrationBuilder.InsertData(
        //        schema: "eval",
        //        table: "ResponseTypes",
        //        columns: new[] { "Id", "Description", "Name", "UpdatedDateTime", "UpdatedUserId" },
        //        values: new object[,]
        //        {
        //            { 1, "Yes, No and Not Applicable", "Close Ended", null, null },
        //            { 2, "1, 2, 3, 4 and 5", "Score", null, null }
        //        });

        //    migrationBuilder.InsertData(
        //        schema: "core",
        //        table: "Roles",
        //        columns: new[] { "Id", "Name", "SystemName", "UpdatedDateTime", "UpdatedUserId" },
        //        values: new object[,]
        //        {
        //            { 1, "System Administrator", "SystemAdmin", null, null },
        //            { 2, "Administrator", "Admin", null, null },
        //            { 3, "Applicant", "Applicant", null, null },
        //            { 4, "Reviewer", "Reviewer", null, null },
        //            { 5, "Main Reviewer", "MainReviewer", null, null },
        //            { 6, "PreEvaluator", "PreEvaluator", null, null },
        //            { 7, "Evaluator", "Evaluator", null, null },
        //            { 8, "Adjudicator", "Adjudicator", null, null },
        //            { 9, "Approver", "Approver", null, null },
        //            { 10, "View Only", "ViewOnly", null, null },
        //            { 11, "Programme Capturer", "ProgrammeCapturer", null, null },
        //            { 12, "Programme Approver", "ProgrammeApprover", null, null },
        //            { 13, "Programme viewer", "ProgrammeViewOnly", null, null }
        //        });

        //    migrationBuilder.InsertData(
        //        schema: "dropdown",
        //        table: "ServiceTypes",
        //        columns: new[] { "Id", "Name", "SystemName", "UpdatedDateTime", "UpdatedUserId" },
        //        values: new object[,]
        //        {
        //            { 1, "Direct Service Delivery", "Direct", null, null },
        //            { 2, "Non-Direct Service Delivery", "Non-Direct", null, null }
        //        });

        //    migrationBuilder.InsertData(
        //        schema: "dropdown",
        //        table: "StaffCategories",
        //        columns: new[] { "Id", "Name", "SystemName", "UpdatedDateTime", "UpdatedUserId" },
        //        values: new object[,]
        //        {
        //            { 1, "Managers", "Managers", null, null },
        //            { 2, "Professional staff", "ProfessionalStaff", null, null },
        //            { 3, "Admin support", "AdminSupport", null, null },
        //            { 4, "Part-time staff", "PartTimeStaff", null, null },
        //            { 5, "Volunteers", "Volunteers", null, null },
        //            { 6, "Other", "Other", null, null }
        //        });

        //    migrationBuilder.InsertData(
        //        schema: "dbo",
        //        table: "Statuses",
        //        columns: new[] { "Id", "Name", "SystemName", "UpdatedDateTime", "UpdatedUserId" },
        //        values: new object[,]
        //        {
        //            { 1, "New", "New", null, null },
        //            { 2, "Saved", "Saved", null, null },
        //            { 3, "Submitted – Pending Review", "PendingReview", null, null },
        //            { 4, "Amendments Required", "AmendmentsRequired", null, null },
        //            { 5, "Pending Approval", "PendingApproval", null, null },
        //            { 6, "Declined", "Declined", null, null },
        //            { 7, "Pending SLA", "PendingSLA", null, null },
        //            { 8, "Pending Signed SLA", "PendingSignedSLA", null, null },
        //            { 9, "Accepted SLA", "AcceptedSLA", null, null },
        //            { 10, "Approval In Progress", "ApprovalInProgress", null, null },
        //            { 11, "SLA: Comments Submitted (Dept)", "DeptComments", null, null },
        //            { 12, "SLA: Comments Submitted (Org)", "OrgComments", null, null },
        //            { 13, "Approved", "Approved", null, null },
        //            { 14, "Verified", "Verified", null, null },
        //            { 15, "Evaluated", "Evaluated", null, null },
        //            { 16, "EvaluationInProgress", "EvaluationInProgress", null, null },
        //            { 17, "AdjudicationInProgress", "AdjudicationInProgress", null, null },
        //            { 18, "Adjudicated", "Adjudicated", null, null },
        //            { 19, "Submitted", "Submitted", null, null },
        //            { 20, "Recommended", "Recommended", null, null },
        //            { 21, "StronglyRecommended", "Strongly Recommended", null, null },
        //            { 22, "NonCompliance", "Non Compliance", null, null },
        //            { 23, "Pending Reviewer Satisfaction", "PendingReviewerSatisfaction", null, null }
        //        });

        //    migrationBuilder.InsertData(
        //        schema: "dropdown",
        //        table: "SubProgrammeTypes",
        //        columns: new[] { "Id", "Code", "Description", "Name", "SubProgrammeId", "UpdatedDateTime", "UpdatedUserId" },
        //        values: new object[,]
        //        {
        //            { 1, null, "All Sub-Programme Types", "All Sub-Programme Types", 1, null, null },
        //            { 2, null, "Chronic Diseases", "Chronic Diseases", 2, null, null },
        //            { 3, null, "NCDs", "NCDs", 3, null, null },
        //            { 4, null, "HIV/AIDS", "HIV/AIDS", 4, null, null },
        //            { 5, null, "TB", "TB", 5, null, null },
        //            { 6, null, "STI", "STI", 6, null, null },
        //            { 7, null, "Maternal Health", "Maternal Health", 7, null, null },
        //            { 8, null, "Women's Health", "Women's Health", 8, null, null },
        //            { 9, null, "Child and Adolescent Health", "Child and Adolescent Health", 9, null, null },
        //            { 10, null, "Theatre", "Theatre", 10, null, null },
        //            { 11, null, "Surgery", "Surgery", 11, null, null },
        //            { 12, null, "Anaethetics", "Anaethetics", 12, null, null },
        //            { 13, null, "Mental Health", "Mental Health", 13, null, null },
        //            { 14, null, "Emerency Centre Pressures", "Emerency Centre Pressures", 14, null, null },
        //            { 15, null, "Shelter For Adults", "Shelter For Adults", 16, null, null },
        //            { 16, null, "Social Service Organisation", "Social Service Organisation", 17, null, null },
        //            { 17, null, "HIV", "HIV", 20, null, null },
        //            { 18, null, "Social Service Organisation", "Social Service Organisation", 20, null, null },
        //            { 19, null, "Childrens Homes", "Childrens Homes", 21, null, null },
        //            { 20, null, "Drop In Centre", "Drop In Centre", 21, null, null },
        //            { 21, null, "Organisation", "Organisation", 21, null, null },
        //            { 22, null, "Shelter for Children", "Shelter for Children", 21, null, null },
        //            { 23, null, "Organisations", "Organisations", 22, null, null },
        //            { 24, null, "Projects", "Projects", 24, null, null },
        //            { 25, null, "Social Service Organisation", "Social Service Organisation", 24, null, null },
        //            { 26, null, "After School Centres", "After School Centres", 25, null, null },
        //            { 27, null, "Creches", "Creches", 26, null, null },
        //            { 28, null, "Social Service Organisation", "Social Service Organisation", 28, null, null },
        //            { 29, null, "Social Service Organisation", "Social Service Organisation", 29, null, null },
        //            { 30, null, "EPWP", "EPWP", 30, null, null },
        //            { 31, null, "Social Service Organisation", "Social Service Organisation", 31, null, null },
        //            { 32, null, "Social Service Organisation", "Social Service Organisation", 36, null, null },
        //            { 33, null, "Assisted Living", "Assisted Living", 38, null, null },
        //            { 34, null, "Independant Living", "Independant Living", 38, null, null },
        //            { 35, null, "Residential Facilities", "Residential Facilities", 38, null, null },
        //            { 36, null, "Social Service Organisation", "Social Service Organisation", 40, null, null },
        //            { 37, null, "Service Centre", "Service Centre", 41, null, null },
        //            { 38, null, "Home Based Care Services", "Home Based Care Services", 43, null, null },
        //            { 39, null, "Service Centre", "Service Centre", 43, null, null },
        //            { 40, null, "Residential Facilities", "Residential Facilities", 44, null, null },
        //            { 41, null, "Protective Workshop", "Protective Workshop", 46, null, null },
        //            { 42, null, "Day Care Centre", "Day Care Centre", 47, null, null },
        //            { 43, null, "Social Service Organisation", "Social Service Organisation", 47, null, null },
        //            { 44, null, "Special Day Care Centre", "Special Day Care Centre", 47, null, null },
        //            { 45, null, "Special Day Care Centres", "Special Day Care Centres", 48, null, null },
        //            { 46, null, "Day Care Centre", "Day Care Centre", 49, null, null },
        //            { 47, null, "Residential Facilities", "Residential Facilities", 50, null, null },
        //            { 48, null, "Projects", "Projects", 55, null, null },
        //            { 49, null, "Aftercare", "Aftercare", 56, null, null },
        //            { 50, null, "Awareness & Prevention", "Awareness & Prevention", 56, null, null },
        //            { 51, null, "Community based treatment", "Community based treatment", 56, null, null },
        //            { 52, null, "Early Intervention", "Early Intervention", 56, null, null },
        //            { 53, null, "Social Service Organisation", "Social Service Organisation", 56, null, null },
        //            { 54, null, "Youth Programmes", "Youth Programmes", 56, null, null },
        //            { 55, null, "Community based treatment", "Community based treatment", 57, null, null },
        //            { 56, null, "In patient", "In patient", 57, null, null },
        //            { 57, null, "Out Patient", "Out Patient", 57, null, null },
        //            { 58, null, "Earmarked Funding", "Earmarked Funding", 58, null, null },
        //            { 59, null, "Equitable Share", "Equitable Share", 58, null, null },
        //            { 60, null, "Social Service Organisation", "Social Service Organisation", 58, null, null },
        //            { 61, null, "SRD", "SRD", 58, null, null },
        //            { 62, null, "Targetted Feeding", "Targetted Feeding", 58, null, null },
        //            { 63, null, "Programme focus", "Programme focus", 59, null, null },
        //            { 64, null, "Shelter for Women and Children", "Shelter for Women and Children", 60, null, null },
        //            { 65, null, "Victims of Crime/Violence/Fam members/significant", "Victims of Crime/Violence/Fam members/significant", 60, null, null },
        //            { 66, null, "Service Provider", "Service Provider", 61, null, null },
        //            { 67, null, "Social Service Organisation", "Social Service Organisation", 61, null, null },
        //            { 68, null, "Projects", "Projects", 62, null, null },
        //            { 69, null, "Social Service Organisation", "Social Service Organisation", 63, null, null },
        //            { 70, null, "Youth Cafe", "Youth Cafe", 63, null, null },
        //            { 71, null, "Childrens Homes", "Childrens Homes", 65, null, null }
        //        });

        //    migrationBuilder.InsertData(
        //        schema: "dropdown",
        //        table: "SubProgrammes",
        //        columns: new[] { "Id", "Description", "Name", "ProgrammeId", "UpdatedDateTime", "UpdatedUserId" },
        //        values: new object[,]
        //        {
        //            { 1, "All Sub-Programmes", "All Sub-Programmes", 1, null, null },
        //            { 2, "Chronic Diseases", "Chronic Diseases", 2, null, null },
        //            { 3, "NCDs", "NCDs", 2, null, null },
        //            { 4, "HIV/AIDS", "HIV/AIDS", 3, null, null },
        //            { 5, "TB", "TB", 3, null, null },
        //            { 6, "STI", "STI", 3, null, null },
        //            { 7, "Maternal Health", "Maternal Health", 4, null, null },
        //            { 8, "Women's Health", "Women's Health", 4, null, null },
        //            { 9, "Child and Adolescent Health", "Child and Adolescent Health", 4, null, null },
        //            { 10, "Theatre", "Theatre", 5, null, null },
        //            { 11, "Surgery", "Surgery", 5, null, null },
        //            { 12, "Anaethetics", "Anaethetics", 5, null, null },
        //            { 13, "Mental Health", "Mental Health", 6, null, null },
        //            { 14, "Emerency Centre Pressures", "Emerency Centre Pressures", 7, null, null },
        //            { 15, "Projects", "Projects", 8, null, null },
        //            { 16, "Shelter For Adults", "Shelter For Adults", 8, null, null },
        //            { 17, "Social Service Organisation", "Social Service Organisation", 8, null, null },
        //            { 18, "Drop In Centres", "Drop In Centres", 9, null, null },
        //            { 19, "Projects", "Projects", 9, null, null },
        //            { 20, "Social Service Organisation", "Social Service Organisation", 9, null, null },
        //            { 21, "Shelter for Children", "Shelter for Children", 9, null, null },
        //            { 22, "HIV - Aids", "HIV - Aids", 9, null, null },
        //            { 23, "Projects", "Projects", 10, null, null },
        //            { 24, "Social Service Organisation", "Social Service Organisation", 10, null, null },
        //            { 25, "After School Centres", "After School Centres", 11, null, null },
        //            { 26, "Creches", "Creches", 11, null, null },
        //            { 27, "Projects", "Projects", 11, null, null },
        //            { 28, "Social Service Organisation", "Social Service Organisation", 11, null, null },
        //            { 29, "Projects", "Projects", 12, null, null },
        //            { 30, "EPWP - Conditional Grant", "EPWP - Conditional Grant", 12, null, null },
        //            { 31, "Social Service Organisation", "Social Service Organisation", 12, null, null },
        //            { 32, "Child and Youth Care Centres", "Child and Youth Care Centres", 13, null, null },
        //            { 33, "Projects", "Projects", 13, null, null },
        //            { 34, "Shelter for Childen", "Shelter for Childen", 13, null, null },
        //            { 35, "Projects", "Projects", 14, null, null },
        //            { 36, "Social Service Organisation", "Social Service Organisation", 14, null, null },
        //            { 37, "Assisted Living", "Assisted Living", 15, null, null },
        //            { 38, "Homes for the Aged", "Homes for the Aged", 15, null, null },
        //            { 39, "Projects", "Projects", 15, null, null },
        //            { 40, "Social Service Organisation", "Social Service Organisation", 15, null, null },
        //            { 41, "Service Centres", "Service Centres", 15, null, null },
        //            { 42, "Independent Living", "Independent Living", 15, null, null },
        //            { 43, "Community Based Care and Support Services", "Community Based Care and Support Services", 15, null, null },
        //            { 44, "Homes for the Disabled", "Homes for the Disabled", 16, null, null },
        //            { 45, "Projects", "Projects", 16, null, null },
        //            { 46, "Protective Workshops", "Protective Workshops", 16, null, null },
        //            { 47, "Social Service Organisation", "Social Service Organisation", 16, null, null },
        //            { 48, "Special Day Care Centres", "Special Day Care Centres", 16, null, null },
        //            { 49, "Day Care Centre", "Day Care Centre", 16, null, null },
        //            { 50, "Homes for the Aged", "Homes for the Aged", 16, null, null },
        //            { 51, "Aftercare", "Aftercare", 17, null, null },
        //            { 52, "Awareness", "Awareness", 17, null, null },
        //            { 53, "Community Based Treatment", "Community Based Treatment", 17, null, null },
        //            { 54, "Early Intervention", "Early Intervention", 17, null, null },
        //            { 55, "Projects", "Projects", 17, null, null },
        //            { 56, "Social Service Organisation", "Social Service Organisation", 17, null, null },
        //            { 57, "Treatment Centres", "Treatment Centres", 17, null, null },
        //            { 58, "Social Service Organisation", "Social Service Organisation", 18, null, null },
        //            { 59, "Projects", "Projects", 19, null, null },
        //            { 60, "Shelter For Victims of Violence", "Shelter For Victims of Violence", 19, null, null },
        //            { 61, "Social Service Organisation", "Social Service Organisation", 19, null, null },
        //            { 62, "Projects", "Projects", 20, null, null },
        //            { 63, "Social Service Organisation", "Social Service Organisation", 20, null, null },
        //            { 64, "Youth Cafe", "Youth Cafe", 20, null, null },
        //            { 65, "Childrens Homes", "Childrens Homes", 21, null, null }
        //        });

        //    migrationBuilder.InsertData(
        //        schema: "dropdown",
        //        table: "Titles",
        //        columns: new[] { "Id", "Name", "UpdatedDateTime", "UpdatedUserId" },
        //        values: new object[,]
        //        {
        //            { 1, "Mr", null, null },
        //            { 2, "Mrs", null, null },
        //            { 3, "Miss", null, null },
        //            { 4, "Dr", null, null },
        //            { 5, "Prof", null, null },
        //            { 6, "Ms", null, null },
        //            { 7, "Other", null, null }
        //        });

        //    migrationBuilder.InsertData(
        //        schema: "dbo",
        //        table: "TrainingMaterials",
        //        columns: new[] { "Id", "Description", "IsActive", "Link", "Name", "UpdatedDateTime", "UpdatedUserId" },
        //        values: new object[,]
        //        {
        //            { 3, "DSD Programme Specifications", true, "https://www.westerncape.gov.za/site-page/call-proposals-2024-25-programme-specifications", "Programme Specifications", null, null },
        //            { 4, "UFC 2024-25 NPO Circular", true, "https://www.westerncape.gov.za/assets/departments/social-development/CFP/ufc_2024-25_npo_circular.pdf", "NPO Circular", null, null },
        //            { 5, "UFC 2024-25 Basic Eligibility Criteria and Conditions ", true, "https://www.westerncape.gov.za/assets/departments/social-development/CFP/ufc_2024-25_basic_eligibility_criteria_and_conditions.pdf", "Basic Eligibility Criteria and Conditions ", null, null },
        //            { 6, "DSD NPO Application Form Guide", true, "https://www.westerncape.gov.za/assets/departments/social-development/CFP/dsd_npo_application_form_guide.pdf", "NPO Application Form Guide ", null, null },
        //            { 7, "DSD Call for Proposals -  Online Application User Guide", true, "https://www.westerncape.gov.za/assets/departments/social-development/CFP/call_for_proposals_-_online_application_user_guide.pdf", "Online Application User Guide ", null, null },
        //            { 8, "DSD NPO Application Form with Annexures (collated)", true, "https://www.westerncape.gov.za/assets/departments/social-development/CFP/dsd_npo_application_form_with_annexures.pdf", "Application Form with Annexures (collated)", null, null },
        //            { 9, "DSD NPO Application Form with Annexures (collated)", true, "https://www.westerncape.gov.za/assets/departments/social-development/CFP/dsd_npo_application_form.pdf", "DSD NPO Application Form", null, null },
        //            { 10, "DSD NPO Application Form - Declaration of interest", true, "https://www.westerncape.gov.za/assets/departments/social-development/CFP/npo_application_form_-_declaration_of_interest.pdf", "Application Form - Declaration of interest", null, null },
        //            { 11, "DSD NPO Application Form - BAS entity bank details form", true, "https://www.westerncape.gov.za/assets/departments/social-development/CFP/npo_application_form_-_dsd_bas_entity_bank_details_form.pdf", "Application Form - BAS entity bank details form", null, null },
        //            { 12, "DSD NPO Application Form - Schedule A Enrolment form (After School Care only)", true, "https://www.westerncape.gov.za/assets/departments/social-development/CFP/npo_application_form_-_schedule_a_enrolment_form_-_afterschool_care_only.pdf", "Application Form - Schedule A Enrolment form (After School Care only)", null, null },
        //            { 13, "DSD NPO Application Form - Written Assurance", true, "https://www.westerncape.gov.za/assets/departments/social-development/CFP/npo_application_form_-_written_assurance.pdf", "Application Form - Written Assurance", null, null },
        //            { 14, "DSD NPO Application Declaration - Online Applications only", true, "https://www.westerncape.gov.za/assets/departments/social-development/dsd_npo_application_declaration_-_online_applications_only.pdf", "Application Declaration - Online Applications only", null, null },
        //            { 15, "DSD Call For Proposal Frequently Asked Questions", true, "https://www.westerncape.gov.za/assets/departments/social-development/CFP/frequently_asked_questions_-_2023_call_for_proposals.pdf", "Frequently Asked Questions", null, null }
        //        });

        //    migrationBuilder.InsertData(
        //        schema: "core",
        //        table: "UserProgram",
        //        columns: new[] { "Id", "CreatedDateTime", "CreatedUserId", "DepartmentId", "IsActive", "Name", "UpdatedDateTime", "UpdatedUserId" },
        //        values: new object[,]
        //        {
        //            { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 7, true, "All", null, null },
        //            { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 7, true, "Care and Services to Older Persons", null, null },
        //            { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 7, true, "Care And Support to Families", null, null },
        //            { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 7, true, "Child Care and Protection Services", null, null },
        //            { 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 7, true, "Crime Prevention", null, null },
        //            { 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 7, true, "EPWP", null, null },
        //            { 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 7, true, "Services to persons with Disabilities", null, null },
        //            { 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 7, true, "Substance Abuse", null, null },
        //            { 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 7, true, "Sustainable Livelihood", null, null },
        //            { 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 7, true, "Youth Development", null, null },
        //            { 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 7, true, "Facility Management", null, null },
        //            { 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 7, true, "Victim Empowerment", null, null },
        //            { 13, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 7, true, "Facility Management", null, null },
        //            { 14, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 7, true, "ECD & Partial Care", null, null },
        //            { 15, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 7, true, "ECD Conditional Grant", null, null },
        //            { 16, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 7, true, "Not Available", null, null },
        //            { 17, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 7, true, "None", null, null }
        //        });

        //    migrationBuilder.InsertData(
        //        schema: "core",
        //        table: "Users",
        //        columns: new[] { "Id", "Email", "FirstName", "LastName", "UpdatedDateTime", "UpdatedUserId", "UserName" },
        //        values: new object[,]
        //        {
        //            { 1, "npoms.admin@westerncape.gov.za", "System", "User", null, null, "npoms.admin@westerncape.gov.za" },
        //            { 2, "Taariq.Kamaar@westerncape.gov.za", "Taariq", "Kamaar", null, null, "Taariq.Kamaar@westerncape.gov.za" }
        //        });

        //    migrationBuilder.InsertData(
        //        schema: "core",
        //        table: "Utilities",
        //        columns: new[] { "Id", "AngularRedirectUrl", "Description", "Name", "SystemAdminUtility", "UpdatedDateTime", "UpdatedUserId" },
        //        values: new object[,]
        //        {
        //            { 1, "utilities/department", "Add and/or Update departments", "Department", true, null, null },
        //            { 2, "utilities/document-type", "Add and/or Update document types", "Document Type", false, null, null },
        //            { 3, "utilities/email-account", "Add and/or Update email accounts", "Email Account", true, null, null },
        //            { 4, "utilities/financial-year", "Add and/or Update financial years", "Financial Year", true, null, null },
        //            { 5, "utilities/role", "Add and/or Update roles", "Role", true, null, null },
        //            { 6, "utilities/access-status", "Add and/or Update access statuses", "Access Status", true, null, null },
        //            { 7, "utilities/status", "Add and/or Update statuses", "Status", true, null, null },
        //            { 8, "utilities/activity-type", "Add and/or Update activity types", "Activity Type", false, null, null },
        //            { 9, "utilities/allocation-type", "Add and/or Update allocation types", "Allocation Type", false, null, null },
        //            { 10, "utilities/application-type", "Add and/or Update application types", "Application Type", true, null, null },
        //            { 11, "utilities/facility-class", "Add and/or Update facility classes", "Facility Class", false, null, null },
        //            { 12, "utilities/facility-district", "Add and/or Update facility districts", "Facility District", false, null, null },
        //            { 13, "utilities/facility-sub-district", "Add and/or Update facility sub-districts", "Facility Sub-District", false, null, null },
        //            { 14, "utilities/facility-type", "Add and/or Update facility types", "Facility Type", true, null, null },
        //            { 15, "utilities/organisation-type", "Add and/or Update organisation types", "Organisation Type", false, null, null },
        //            { 16, "utilities/position", "Add and/or Update positions", "Position", false, null, null },
        //            { 17, "utilities/programme", "Add and/or Update programmes", "Programme", false, null, null },
        //            { 18, "utilities/provision-type", "Add and/or Update provision types", "Provision Type", false, null, null },
        //            { 19, "utilities/recipient-type", "Add and/or Update recipient types", "Recipient Type", false, null, null },
        //            { 20, "utilities/resource-type", "Add and/or Update resource types", "Resource Type", false, null, null },
        //            { 21, "utilities/service-type", "Add and/or Update service types", "Service Type", false, null, null },
        //            { 22, "utilities/sub-programme", "Add and/or Update sub-programmes", "Sub-Programme", false, null, null },
        //            { 23, "utilities/title", "Add and/or Update titles", "Title", false, null, null },
        //            { 24, "utilities/management", "Add and/or Update utility management", "Utility Management", true, null, null },
        //            { 25, "utilities/sub-programme-type", "Add and/or Update sub-programme types", "Sub-Programme Type", false, null, null },
        //            { 26, "utilities/directorate", "Add and/or Update directorates", "Directorate", false, null, null },
        //            { 27, "utilities/bank", "Add and/or Update banks", "Bank", false, null, null },
        //            { 28, "utilities/branch", "Add and/or Update branches", "Branch", false, null, null },
        //            { 29, "utilities/account-type", "Add and/or Update account types", "Account Type", false, null, null }
        //        });

        //    migrationBuilder.InsertData(
        //        schema: "eval",
        //        table: "WorkflowAssessments",
        //        columns: new[] { "Id", "NumberOfAssessments", "QuestionCategoryId", "UpdatedDateTime", "UpdatedUserId" },
        //        values: new object[,]
        //        {
        //            { 1, 1, 1, null, null },
        //            { 2, 4, 2, null, null },
        //            { 3, 4, 3, null, null }
        //        });

        //    migrationBuilder.InsertData(
        //        schema: "mapping",
        //        table: "Departments_Roles",
        //        columns: new[] { "Id", "DepartmentId", "RoleId" },
        //        values: new object[,]
        //        {
        //            { 1, 11, 2 },
        //            { 2, 11, 4 },
        //            { 3, 11, 5 },
        //            { 4, 11, 10 },
        //            { 5, 7, 2 },
        //            { 6, 7, 6 },
        //            { 7, 7, 7 },
        //            { 8, 7, 8 },
        //            { 9, 7, 9 },
        //            { 10, 1, 1 },
        //            { 11, 16, 3 },
        //            { 12, 11, 3 },
        //            { 13, 7, 3 }
        //        });

        //    migrationBuilder.InsertData(
        //        schema: "dropdown",
        //        table: "FacilitySubDistricts",
        //        columns: new[] { "Id", "FacilityDistrictId", "Name", "UpdatedDateTime", "UpdatedUserId" },
        //        values: new object[,]
        //        {
        //            { 1, 1, "Breede Valley Local Municipality", null, null },
        //            { 2, 1, "Stellenbosch Local Municipality", null, null },
        //            { 3, 1, "Drakenstein Local Municipality", null, null },
        //            { 4, 1, "Witzenberg Local Municipality", null, null },
        //            { 5, 1, "Langeberg Local Municipality", null, null },
        //            { 6, 2, "Khayelitsha Health sub-District", null, null },
        //            { 7, 2, "Cape Town Eastern Health sub-District", null, null },
        //            { 8, 2, "Cape Town Southern Health sub-District", null, null },
        //            { 9, 2, "Cape Town Northern Health sub-District", null, null },
        //            { 10, 2, "Klipfontein Health sub-District", null, null },
        //            { 11, 2, "Cape Town Western Health sub-District", null, null },
        //            { 12, 2, "Tygerberg Health sub-District", null, null },
        //            { 13, 2, "Mitchells Plain Health sub-District", null, null },
        //            { 14, 3, "Matzikama Local Municipality", null, null },
        //            { 15, 3, "Saldanha Bay Local Municipality", null, null },
        //            { 16, 3, "Cederberg Local Municipality", null, null },
        //            { 17, 3, "Bergrivier Local Municipality", null, null },
        //            { 18, 3, "Swartland Local Municipality", null, null },
        //            { 19, 4, "Overstrand Local Municipality", null, null },
        //            { 20, 4, "Theewaterskloof Local Municipality", null, null },
        //            { 21, 4, "Cape Agulhas Local Municipality", null, null },
        //            { 22, 4, "Swellendam Local Municipality", null, null },
        //            { 23, 5, "Bitou Local Municipality", null, null },
        //            { 24, 5, "Mossel Bay Local Municipality", null, null },
        //            { 25, 5, "Knysna Local Municipality", null, null },
        //            { 26, 5, "George Local Municipality", null, null },
        //            { 27, 5, "Hessequa Local Municipality", null, null },
        //            { 28, 5, "Kannaland Local Municipality", null, null },
        //            { 29, 5, "Oudtshoorn Local Municipality", null, null },
        //            { 30, 6, "Beaufort West Local Municipality", null, null },
        //            { 31, 6, "Laingsburg Local Municipality", null, null },
        //            { 32, 6, "Prince Albert Local Municipality", null, null }
        //        });

        //    migrationBuilder.InsertData(
        //        schema: "dropdown",
        //        table: "LocalMunicipalities",
        //        columns: new[] { "Id", "DistrictCouncilId", "Name", "SystemName", "UpdatedDateTime", "UpdatedUserId" },
        //        values: new object[,]
        //        {
        //            { 26, 8, "Beaufort West", null, null, null },
        //            { 27, 12, "Bergrivier", null, null, null },
        //            { 28, 10, "Bitou", null, null, null },
        //            { 29, 7, "Breede Valley", null, null, null },
        //            { 30, 11, "Cape Agulhas", null, null, null },
        //            { 31, 12, "Cederberg", null, null, null },
        //            { 32, 9, "City of Cape Town", null, null, null },
        //            { 33, 7, "Drakenstein", null, null, null },
        //            { 34, 10, "George ", null, null, null },
        //            { 35, 10, "Hessequa", null, null, null },
        //            { 36, 10, "Kannaland", null, null, null },
        //            { 37, 10, "Knysna", null, null, null },
        //            { 38, 8, "Laingsburg", null, null, null },
        //            { 39, 7, "Langeberg", null, null, null },
        //            { 40, 12, "Matzikama", null, null, null },
        //            { 41, 10, "Mossel Bay", null, null, null },
        //            { 42, 10, "Oudtshoorn", null, null, null },
        //            { 43, 11, "Overstrand", null, null, null },
        //            { 44, 8, "Prince Albert", null, null, null },
        //            { 45, 12, "Saldanha Bay", null, null, null },
        //            { 46, 7, "Stellenbosch", null, null, null },
        //            { 47, 12, "Swartland", null, null, null },
        //            { 48, 11, "Swellendam", null, null, null },
        //            { 49, 11, "Theewaterskloof", null, null, null },
        //            { 50, 7, "Witzenberg", null, null, null }
        //        });

        //    migrationBuilder.InsertData(
        //        schema: "dropdown",
        //        table: "PropertySubTypes",
        //        columns: new[] { "Id", "CreatedDateTime", "CreatedUserID", "Frequency", "HaveComment", "IsActive", "IsDeleted", "Name", "PropertyTypeID", "Repeatable", "UpdatedDateTime", "UpdatedUserID" },
        //        values: new object[,]
        //        {
        //            { 1, new DateTime(2024, 7, 14, 12, 31, 4, 777, DateTimeKind.Local).AddTicks(6760), 3, 12, false, true, false, "Monthly", 3, true, null, null },
        //            { 2, new DateTime(2024, 7, 14, 12, 31, 4, 777, DateTimeKind.Local).AddTicks(6800), 3, 1, false, true, false, "Annually", 3, true, null, null },
        //            { 3, new DateTime(2024, 7, 14, 12, 31, 4, 777, DateTimeKind.Local).AddTicks(6802), 3, 264, false, true, false, "264 Days", 3, true, null, null },
        //            { 4, new DateTime(2024, 7, 14, 12, 31, 4, 777, DateTimeKind.Local).AddTicks(6803), 3, 240, false, true, false, "240 Days", 3, true, null, null },
        //            { 5, new DateTime(2024, 7, 14, 12, 31, 4, 777, DateTimeKind.Local).AddTicks(6805), 3, null, false, false, false, "Social Worker", 2, true, null, null },
        //            { 6, new DateTime(2024, 7, 14, 12, 31, 4, 777, DateTimeKind.Local).AddTicks(6806), 3, null, false, true, false, "Social Worker Supervisor", 2, true, null, null },
        //            { 7, new DateTime(2024, 7, 14, 12, 31, 4, 777, DateTimeKind.Local).AddTicks(6808), 3, null, false, true, false, "Social Auxiliary Worker", 2, true, null, null },
        //            { 8, new DateTime(2024, 7, 14, 12, 31, 4, 777, DateTimeKind.Local).AddTicks(6809), 3, null, false, true, false, "Social Worker Manager", 2, true, null, null },
        //            { 9, new DateTime(2024, 7, 14, 12, 31, 4, 777, DateTimeKind.Local).AddTicks(6848), 3, null, false, true, false, "Community Development Practitioner", 2, true, null, null },
        //            { 10, new DateTime(2024, 7, 14, 12, 31, 4, 777, DateTimeKind.Local).AddTicks(6849), 3, null, false, true, false, "Community Development Assistant", 2, true, null, null },
        //            { 11, new DateTime(2024, 7, 14, 12, 31, 4, 777, DateTimeKind.Local).AddTicks(6851), 3, null, false, true, false, "Facilitator", 4, true, null, null },
        //            { 12, new DateTime(2024, 7, 14, 12, 31, 4, 777, DateTimeKind.Local).AddTicks(6853), 3, null, false, true, false, "Catering", 4, true, null, null },
        //            { 13, new DateTime(2024, 7, 14, 12, 31, 4, 777, DateTimeKind.Local).AddTicks(6854), 3, null, false, true, false, "Transport", 4, true, null, null },
        //            { 14, new DateTime(2024, 7, 14, 12, 31, 4, 777, DateTimeKind.Local).AddTicks(6856), 3, null, false, true, false, "Telephone", 4, true, null, null },
        //            { 15, new DateTime(2024, 7, 14, 12, 31, 4, 777, DateTimeKind.Local).AddTicks(6857), 3, null, false, true, false, "Venue Hire", 4, true, null, null },
        //            { 16, new DateTime(2024, 7, 14, 12, 31, 4, 777, DateTimeKind.Local).AddTicks(6859), 3, null, false, true, false, "Traveling", 4, true, null, null },
        //            { 17, new DateTime(2024, 7, 14, 12, 31, 4, 777, DateTimeKind.Local).AddTicks(6860), 3, null, false, true, false, "Accommodation", 4, true, null, null },
        //            { 18, new DateTime(2024, 7, 14, 12, 31, 4, 777, DateTimeKind.Local).AddTicks(6862), 3, null, false, true, false, "Training", 4, true, null, null },
        //            { 19, new DateTime(2024, 7, 14, 12, 31, 4, 777, DateTimeKind.Local).AddTicks(6863), 3, null, false, true, false, "Governance Norms and Standards", 4, true, null, null },
        //            { 20, new DateTime(2024, 7, 14, 12, 31, 4, 777, DateTimeKind.Local).AddTicks(6865), 3, null, false, true, false, "Management Fee", 4, true, null, null },
        //            { 21, new DateTime(2024, 7, 14, 12, 31, 4, 777, DateTimeKind.Local).AddTicks(6866), 3, null, false, false, false, "Other", 4, true, null, null },
        //            { 22, new DateTime(2024, 7, 14, 12, 31, 4, 777, DateTimeKind.Local).AddTicks(6880), 3, null, false, true, false, "Admin Fee", 4, true, null, null },
        //            { 23, new DateTime(2024, 7, 14, 12, 31, 4, 777, DateTimeKind.Local).AddTicks(6882), 3, null, false, true, false, "UIF & COIDA", 4, true, null, null },
        //            { 24, new DateTime(2024, 7, 14, 12, 31, 4, 777, DateTimeKind.Local).AddTicks(6883), 3, null, false, true, false, "Social", 4, true, null, null },
        //            { 25, new DateTime(2024, 7, 14, 12, 31, 4, 777, DateTimeKind.Local).AddTicks(6885), 3, null, false, true, false, "AAA", 4, true, null, null },
        //            { 26, new DateTime(2024, 7, 14, 12, 31, 4, 777, DateTimeKind.Local).AddTicks(6886), 3, null, false, true, false, "Skill Development", 4, true, null, null },
        //            { 27, new DateTime(2024, 7, 14, 12, 31, 4, 777, DateTimeKind.Local).AddTicks(6888), 3, null, false, true, false, "Security Upgrade & OHS Compliance 1", 4, true, null, null },
        //            { 28, new DateTime(2024, 7, 14, 12, 31, 4, 777, DateTimeKind.Local).AddTicks(6889), 3, null, false, true, false, "Security Upgrade & OHS Compliance 2", 4, true, null, null },
        //            { 29, new DateTime(2024, 7, 14, 12, 31, 4, 777, DateTimeKind.Local).AddTicks(6891), 3, null, false, true, false, "Security Upgrade & OHS Compliance 3", 4, true, null, null },
        //            { 30, new DateTime(2024, 7, 14, 12, 31, 4, 777, DateTimeKind.Local).AddTicks(6896), 3, null, false, true, false, "Travel Cost", 4, true, null, null },
        //            { 31, new DateTime(2024, 7, 14, 12, 31, 4, 777, DateTimeKind.Local).AddTicks(6921), 3, null, false, true, false, "Specialized services", 4, true, null, null },
        //            { 32, new DateTime(2024, 7, 14, 12, 31, 4, 777, DateTimeKind.Local).AddTicks(6923), 3, null, false, true, false, "House Mothers", 4, true, null, null }
        //        });

        //    migrationBuilder.InsertData(
        //        schema: "eval",
        //        table: "QuestionSections",
        //        columns: new[] { "Id", "Name", "QuestionCategoryId", "SortOrder", "UpdatedDateTime", "UpdatedUserId" },
        //        values: new object[,]
        //        {
        //            { 1, "Pre-evaluation", 1, 1, null, null },
        //            { 2, "Alignment of the proposal to the Fund objectives", 2, 1, null, null },
        //            { 3, "Experience and ability (success)", 2, 2, null, null },
        //            { 4, "Level of co-funding", 2, 3, null, null },
        //            { 5, "Impact on business sustainability and/or expansion", 2, 4, null, null },
        //            { 6, "Monitoring and Evaluation", 2, 5, null, null },
        //            { 7, "Financial sustainability of the organisation", 2, 6, null, null },
        //            { 8, "Adjudication", 3, 1, null, null }
        //        });

        //    migrationBuilder.InsertData(
        //        schema: "mapping",
        //        table: "Roles_Permissions",
        //        columns: new[] { "PermissionId", "RoleId" },
        //        values: new object[,]
        //        {
        //            { 1, 1 },
        //            { 2, 1 },
        //            { 3, 1 },
        //            { 4, 1 },
        //            { 5, 1 },
        //            { 6, 1 },
        //            { 7, 1 },
        //            { 8, 1 },
        //            { 9, 1 },
        //            { 10, 1 },
        //            { 11, 1 },
        //            { 12, 1 },
        //            { 13, 1 },
        //            { 14, 1 },
        //            { 15, 1 },
        //            { 16, 1 },
        //            { 17, 1 },
        //            { 18, 1 },
        //            { 19, 1 },
        //            { 20, 1 },
        //            { 21, 1 },
        //            { 22, 1 },
        //            { 23, 1 },
        //            { 24, 1 },
        //            { 25, 1 },
        //            { 26, 1 },
        //            { 27, 1 },
        //            { 28, 1 },
        //            { 29, 1 },
        //            { 30, 1 },
        //            { 31, 1 },
        //            { 32, 1 },
        //            { 33, 1 },
        //            { 34, 1 },
        //            { 35, 1 },
        //            { 36, 1 },
        //            { 37, 1 },
        //            { 38, 1 },
        //            { 39, 1 },
        //            { 40, 1 },
        //            { 41, 1 },
        //            { 42, 1 },
        //            { 43, 1 },
        //            { 44, 1 },
        //            { 45, 1 },
        //            { 46, 1 },
        //            { 47, 1 },
        //            { 48, 1 },
        //            { 49, 1 },
        //            { 50, 1 },
        //            { 51, 1 },
        //            { 52, 1 },
        //            { 53, 1 },
        //            { 54, 1 },
        //            { 55, 1 },
        //            { 56, 1 },
        //            { 57, 1 },
        //            { 58, 1 },
        //            { 59, 1 },
        //            { 60, 1 },
        //            { 61, 1 },
        //            { 62, 1 },
        //            { 63, 1 },
        //            { 64, 1 },
        //            { 65, 1 },
        //            { 66, 1 },
        //            { 67, 1 },
        //            { 68, 1 },
        //            { 69, 1 },
        //            { 70, 1 },
        //            { 71, 1 },
        //            { 72, 1 },
        //            { 73, 1 },
        //            { 74, 1 },
        //            { 75, 1 },
        //            { 76, 1 },
        //            { 77, 1 },
        //            { 78, 1 },
        //            { 79, 1 },
        //            { 80, 1 },
        //            { 81, 1 },
        //            { 82, 1 },
        //            { 83, 1 },
        //            { 84, 1 },
        //            { 85, 1 },
        //            { 86, 1 },
        //            { 87, 1 },
        //            { 88, 1 },
        //            { 89, 1 },
        //            { 90, 1 },
        //            { 91, 1 },
        //            { 92, 1 },
        //            { 111, 1 },
        //            { 120, 1 },
        //            { 121, 1 }
        //        });

        //    migrationBuilder.InsertData(
        //        schema: "mapping",
        //        table: "Segment_Code",
        //        columns: new[] { "Id", "ObjectiveCode", "ProgrammeId", "ResponsibilityCode", "SubProgramId", "SubProgrammeTypeId" },
        //        values: new object[,]
        //        {
        //            { 1, "30024059", 8, "30075059", 16, 15 },
        //            { 2, "30023059", 8, "30075059", 17, 16 },
        //            { 3, "30028059", 9, "30074059", 20, 18 },
        //            { 4, "30040059", 10, "30070059", 24, 25 },
        //            { 5, "30064059", 11, "30081059", 25, 26 },
        //            { 6, "30011059", 15, "30078059", 38, 33 },
        //            { 7, "30007059", 15, "30078059", 38, 35 },
        //            { 8, "30009059", 15, "30078059", 40, 36 },
        //            { 9, "30008059", 15, "30078059", 41, 37 },
        //            { 10, "30015059", 16, "30077059", 44, 40 },
        //            { 11, "30017059", 16, "30077059", 46, 41 },
        //            { 12, "30018059", 16, "30077059", 47, 43 },
        //            { 13, "30016059", 16, "30077059", 48, 45 },
        //            { 14, "30049059", 17, "30079059", 55, 48 },
        //            { 15, "30047059", 17, "30079059", 56, 49 },
        //            { 16, "30048059", 17, "30079059", 56, 50 },
        //            { 17, "30053059", 17, "30079059", 56, 51 },
        //            { 18, "30046059", 17, "30079059", 56, 52 },
        //            { 19, "30050059", 17, "30079059", 57, 56 },
        //            { 20, "30059059", 18, "30064059", 58, 62 },
        //            { 21, "30044059", 19, "30069059", 60, 64 },
        //            { 22, "30062059", 20, "30062059", 63, 70 },
        //            { 23, "30037059", 21, "30074059", 65, 71 },
        //            { 24, "30049059", 17, "3059", 55, 48 }
        //        });

        //    migrationBuilder.InsertData(
        //        schema: "mapping",
        //        table: "UserProgramMapping",
        //        columns: new[] { "Id", "IsActive", "ProgramId", "UserId" },
        //        values: new object[,]
        //        {
        //            { 1, false, 1, 1 },
        //            { 2, false, 1, 2 }
        //        });

        //    migrationBuilder.InsertData(
        //        schema: "mapping",
        //        table: "Users_Departments",
        //        columns: new[] { "Id", "DepartmentId", "UserId" },
        //        values: new object[,]
        //        {
        //            { 1, 1, 1 },
        //            { 2, 1, 2 }
        //        });

        //    migrationBuilder.InsertData(
        //        schema: "mapping",
        //        table: "Users_Roles",
        //        columns: new[] { "Id", "RoleId", "UserId" },
        //        values: new object[,]
        //        {
        //            { 1, 1, 1 },
        //            { 2, 1, 2 }
        //        });

        //    migrationBuilder.InsertData(
        //        schema: "eval",
        //        table: "Questions",
        //        columns: new[] { "Id", "Name", "QuestionSectionId", "ResponseTypeId", "SortOrder", "UpdatedDateTime", "UpdatedUserId" },
        //        values: new object[,]
        //        {
        //            { 1, "% Own Funding Contribution to Funding Requested", 1, 1, 1, null, null },
        //            { 2, "The organisation applying for support must be formally registered or incorporated. Company registration documents or documents of incorporation (NPO/NPC registration certificate, partnership agreements, sole proprietor tax certificate etc.) clearly identifying the director(s) of the company or organisation must be submitted. CFP 4.1", 1, 1, 2, null, null },
        //            { 3, "The organisation applying for support must be operational (still trading) and must have been in operation for a minimum of three financial years. Management accounts for the two months preceding the application closing date must be submitted. CFP 4.2", 1, 1, 3, null, null },
        //            { 4, "Signed annual financial statements for the three most recent financial years (the annual financial statements for the latest financial year must be audited and must be submitted. CFP 4.2", 1, 1, 4, null, null },
        //            { 5, "A tax compliant status (TCS) letter with a valid (not expired) tax pin must be submitted. The tax pin must be valid for a period of 60 days after the closing date for applications. CFP 4.3", 1, 1, 5, null, null },
        //            { 6, "The organisation must have obtained an unqualified audit opinion during its latest financial period. Signed audited annual financial statements (AFS) for the latest financial year must be submitted. It is important that the AFS are signed off. CFP 4.4", 1, 1, 6, null, null },
        //            { 7, "A valid BBBEE certificate / affidavit for the applicant organisation. CFP 4.5", 1, 1, 7, null, null },
        //            { 8, "The value of funding requested from the Department must not be less than R500 000, 00 and the maximum value of funding requested must not exceed R2 million. CFP 4.6", 1, 1, 8, null, null },
        //            { 9, "The organisation must demonstrate an own funding (including third party funding if any) contribution of 50% or more of the requested amount. CFP 4.7", 1, 1, 9, null, null },
        //            { 10, "A signed letter by the Chief Executive Officer (CEO) / Chief Financial Officer (CFO) or similar executive authority confirming the value of own funding committed must be submitted. CFP 4.7", 1, 1, 10, null, null },
        //            { 11, "The identity document of the signatory to the agreement must be provided. CFP 4.8", 1, 1, 11, null, null },
        //            { 12, "The proposed intervention(s) qualifies in terms of what the Booster Fund aims to achieve i.e., enhancing and/or expanding interventions that supports SMMEs.", 2, 2, 1, null, null },
        //            { 13, "The project implementation plan demonstrates that the project has commenced or will commence within two months of signing the agreement with the Department.", 2, 2, 2, null, null },
        //            { 14, "The utilisation of the funds is in line with what the SMME Booster Fund aims to achieve i.e.; interventions that provide direct support to SMMEs.", 2, 2, 3, null, null },
        //            { 15, "The spatial and designated group impact of the proposed intervention is in line with what the SMME Booster Fund sets out to achieve i.e., beneficiaries are township/rural based and are women, youth or persons living with a disability.", 2, 2, 4, null, null },
        //            { 16, "The organisation requesting support for the qualifying intervention has adequate and relevant experience.", 3, 2, 1, null, null },
        //            { 17, "The organisation has in the proposal, demonstrated success either relating to the intervention they are seeking assistance for or relevant work done by the organisation.", 3, 2, 2, null, null },
        //            { 18, "The co-funding / own contribution is of a substantial nature.", 4, 2, 1, null, null },
        //            { 19, "The impact of the proposed intervention supports the primary objective of the SMME Booster Fund i.e., the propensity of job creation and/or job retention.", 5, 2, 1, null, null },
        //            { 20, "The average cost of creating the projected number of jobs is tolerable.", 5, 2, 2, null, null },
        //            { 21, "The average cost of supporting an individual SMME is tolerable", 5, 2, 3, null, null },
        //            { 22, "The organisation in the proposal has demonstrated an intention to implement a monitoring and evaluation framework in line with what the Department requires.", 6, 2, 1, null, null },
        //            { 23, "The AFS submitted by the organisation indicates that the 	organisation is in a good financial position", 7, 2, 1, null, null },
        //            { 24, "Risk: The level of risk associated with the organisation and the implementation of the project is tolerable", 8, 2, 1, null, null },
        //            { 25, "Impact: The impact of the intervention in terms of the following areas:", 8, 2, 2, null, null },
        //            { 26, "The proposal has a propensity to create or sustain employment", 8, 2, 3, null, null },
        //            { 27, "DEDAT funding will contribute to the development of SMMEs or enhance the ecosystem", 8, 2, 4, null, null }
        //        });

        //    migrationBuilder.InsertData(
        //        schema: "dropdown",
        //        table: "Regions",
        //        columns: new[] { "Id", "LocalMunicipalityId", "Name", "SystemName", "UpdatedDateTime", "UpdatedUserId" },
        //        values: new object[,]
        //        {
        //            { 49, 32, "Metro East", null, null, null },
        //            { 50, 32, "Metro North", null, null, null },
        //            { 51, 32, "Metro South", null, null, null }
        //        });

        //    migrationBuilder.InsertData(
        //        schema: "eval",
        //        table: "QuestionProperties",
        //        columns: new[] { "Id", "CommentRequired", "DocumentRequired", "HasComment", "HasDocument", "QuestionId", "Weighting" },
        //        values: new object[,]
        //        {
        //            { 1, true, false, true, false, 1, 0 },
        //            { 2, true, false, true, false, 2, 0 },
        //            { 3, true, false, true, false, 3, 0 },
        //            { 4, true, false, true, false, 4, 0 },
        //            { 5, true, false, true, false, 5, 0 },
        //            { 6, true, false, true, false, 6, 0 },
        //            { 7, true, false, true, false, 7, 0 },
        //            { 8, true, false, true, false, 8, 0 },
        //            { 9, true, false, true, false, 9, 0 },
        //            { 10, true, false, true, false, 10, 0 },
        //            { 11, true, false, true, false, 11, 0 },
        //            { 12, true, false, true, false, 12, 10 },
        //            { 13, true, false, true, false, 13, 5 },
        //            { 14, true, false, true, false, 14, 10 },
        //            { 15, true, false, true, false, 15, 5 },
        //            { 16, true, false, true, false, 16, 5 },
        //            { 17, true, false, true, false, 17, 10 },
        //            { 18, true, false, true, false, 18, 10 },
        //            { 19, true, false, true, false, 19, 10 },
        //            { 20, true, false, true, false, 20, 15 },
        //            { 21, true, false, true, false, 21, 10 },
        //            { 22, true, false, true, false, 22, 5 },
        //            { 23, true, false, true, false, 23, 5 },
        //            { 24, true, false, true, false, 24, 25 },
        //            { 25, true, false, true, false, 25, 25 },
        //            { 26, true, false, true, false, 26, 25 },
        //            { 27, true, false, true, false, 27, 25 }
        //        });

        //    migrationBuilder.InsertData(
        //        schema: "dropdown",
        //        table: "ServiceDeliveryAreas",
        //        columns: new[] { "Id", "ExternalId", "Name", "RegionId", "SystemName", "UpdatedDateTime", "UpdatedUserId" },
        //        values: new object[,]
        //        {
        //            { 175, null, "Athlone", 51, null, null, null },
        //            { 176, null, "Atlantis", 50, null, null, null },
        //            { 178, null, "Bellville", 50, null, null, null },
        //            { 183, null, "Cape Town", 50, null, null, null },
        //            { 185, null, "Delft", 50, null, null, null },
        //            { 187, null, "Eersterivier", 49, null, null, null },
        //            { 188, null, "Elsies Rivier", 50, null, null, null },
        //            { 189, null, "Fish Hoek", 51, null, null, null },
        //            { 190, null, "Gugulethu", 51, null, null, null },
        //            { 191, null, "Khayelitsha", 49, null, null, null },
        //            { 192, null, "Khayelitsha 2", 49, null, null, null },
        //            { 193, null, "Khayelitsha 3", 49, null, null, null },
        //            { 194, null, "Kraaifontein", 49, null, null, null },
        //            { 195, null, "Langa", 50, null, null, null },
        //            { 196, null, "Milnerton", 50, null, null, null },
        //            { 197, null, "Mitchell's Plain 1", 51, null, null, null },
        //            { 198, null, "Mitchell's Plain 2", 51, null, null, null },
        //            { 199, null, "Philippi", 51, null, null, null },
        //            { 200, null, "Retreat", 51, null, null, null },
        //            { 201, null, "Somerset West", 49, null, null, null },
        //            { 202, null, "Wynberg", 51, null, null, null }
        //        });

        //    migrationBuilder.InsertData(
        //        schema: "dropdown",
        //        table: "Places",
        //        columns: new[] { "Id", "CreatedDateTime", "CreatedUserId", "ExternalId", "IsActive", "Name", "ServiceDeliveryAreaId", "SystemName", "UpdatedDateTime", "UpdatedUserId" },
        //        values: new object[,]
        //        {
        //            { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, false, "Athlone", 175, "PL9", null, null },
        //            { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, false, "Atlantis", 176, "PL12", null, null },
        //            { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, false, "Belhar", 178, "PL19", null, null },
        //            { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, false, "Bellville", 178, "PL21", null, null },
        //            { 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, false, "Cape Farms", 176, "PL51", null, null },
        //            { 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, false, "Cape Metro", 176, "PL52", null, null },
        //            { 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, false, "Cape Metro", 178, "PL53", null, null },
        //            { 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, false, "Cape Town", 175, "PL54", null, null }
        //        });

        //    migrationBuilder.InsertData(
        //        schema: "dropdown",
        //        table: "SubPlaces",
        //        columns: new[] { "Id", "CreatedDateTime", "CreatedUserId", "ExternalId", "IsActive", "Name", "PlaceId", "SystemName", "UpdatedDateTime", "UpdatedUserId" },
        //        values: new object[,]
        //        {
        //            { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, false, "Athlone SP", 1, "SP28", null, null },
        //            { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, false, "Belgravia(Athlone)", 1, "SP66", null, null },
        //            { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, false, "Atlantis Industrial", 2, "SP29", null, null },
        //            { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, false, "Avondale SP1", 2, "SP36", null, null },
        //            { 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, false, "Belhar 1", 3, "SP68", null, null },
        //            { 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, false, "Belhar 10", 3, "SP69", null, null },
        //            { 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, false, "Bellville Central", 4, "SP95", null, null },
        //            { 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, false, "Bellville Lot 1", 4, "SP96", null, null },
        //            { 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, false, "Papekuil Outspan", 5, "SP1040", null, null },
        //            { 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, false, "Cape Metro NU1", 6, "SP239", null, null },
        //            { 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, false, "Cape Metro NU2", 6, "SP240", null, null },
        //            { 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, false, "Cape Metro NU3", 7, "SP241", null, null },
        //            { 13, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, false, "Buckingham", 8, "SP226", null, null },
        //            { 14, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, false, "Crawford", 8, "SP289", null, null }
        //        });

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Activities_ActivityListId",
        //        schema: "dbo",
        //        table: "Activities",
        //        column: "ActivityListId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Activities_ActivityTypeId",
        //        schema: "dbo",
        //        table: "Activities",
        //        column: "ActivityTypeId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Activities_ObjectiveId",
        //        schema: "dbo",
        //        table: "Activities",
        //        column: "ObjectiveId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Activities_FacilityLists_ActivityId",
        //        schema: "mapping",
        //        table: "Activities_FacilityLists",
        //        column: "ActivityId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Activities_FacilityLists_FacilityListId",
        //        schema: "mapping",
        //        table: "Activities_FacilityLists",
        //        column: "FacilityListId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Activities_SubProgrammes_ActivityId",
        //        schema: "mapping",
        //        table: "Activities_SubProgrammes",
        //        column: "ActivityId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Activities_SubProgrammes_SubProgrammeId",
        //        schema: "mapping",
        //        table: "Activities_SubProgrammes",
        //        column: "SubProgrammeId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_AddressInformation_NpoProfileId",
        //        schema: "dbo",
        //        table: "AddressInformation",
        //        column: "NpoProfileId",
        //        unique: true);

        //    migrationBuilder.CreateIndex(
        //        name: "IX_ApplicationApprovals_CreatedUserId",
        //        schema: "dbo",
        //        table: "ApplicationApprovals",
        //        column: "CreatedUserId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_ApplicationAudits_CreatedUserId",
        //        schema: "dbo",
        //        table: "ApplicationAudits",
        //        column: "CreatedUserId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_ApplicationAudits_StatusId",
        //        schema: "dbo",
        //        table: "ApplicationAudits",
        //        column: "StatusId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_ApplicationComments_CreatedUserId",
        //        schema: "dbo",
        //        table: "ApplicationComments",
        //        column: "CreatedUserId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_ApplicationDetails_FundAppSDADetailId",
        //        schema: "fa",
        //        table: "ApplicationDetails",
        //        column: "FundAppSDADetailId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_ApplicationPeriods_ApplicationTypeId",
        //        schema: "dbo",
        //        table: "ApplicationPeriods",
        //        column: "ApplicationTypeId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_ApplicationPeriods_DepartmentId",
        //        schema: "dbo",
        //        table: "ApplicationPeriods",
        //        column: "DepartmentId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_ApplicationPeriods_FinancialYearId",
        //        schema: "dbo",
        //        table: "ApplicationPeriods",
        //        column: "FinancialYearId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_ApplicationPeriods_ProgrammeId",
        //        schema: "dbo",
        //        table: "ApplicationPeriods",
        //        column: "ProgrammeId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_ApplicationPeriods_SubProgrammeId",
        //        schema: "dbo",
        //        table: "ApplicationPeriods",
        //        column: "SubProgrammeId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_ApplicationReviewerSatisfactions_CreatedUserId",
        //        schema: "dbo",
        //        table: "ApplicationReviewerSatisfactions",
        //        column: "CreatedUserId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Applications_ApplicationPeriodId",
        //        schema: "dbo",
        //        table: "Applications",
        //        column: "ApplicationPeriodId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Applications_NpoId",
        //        schema: "dbo",
        //        table: "Applications",
        //        column: "NpoId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Applications_StatusId",
        //        schema: "dbo",
        //        table: "Applications",
        //        column: "StatusId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_BudgetAdjustment_ProgrammeId",
        //        schema: "budget",
        //        table: "BudgetAdjustment",
        //        column: "ProgrammeId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_BudgetAdjustment_SubProgrammeTypeId",
        //        schema: "budget",
        //        table: "BudgetAdjustment",
        //        column: "SubProgrammeTypeId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_CapturedResponses_CreatedUserId",
        //        schema: "eval",
        //        table: "CapturedResponses",
        //        column: "CreatedUserId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_ContactInformation_GenderId",
        //        schema: "dbo",
        //        table: "ContactInformation",
        //        column: "GenderId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_ContactInformation_LanguageId",
        //        schema: "dbo",
        //        table: "ContactInformation",
        //        column: "LanguageId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_ContactInformation_NpoId",
        //        schema: "dbo",
        //        table: "ContactInformation",
        //        column: "NpoId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_ContactInformation_PositionId",
        //        schema: "dbo",
        //        table: "ContactInformation",
        //        column: "PositionId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_ContactInformation_RaceId",
        //        schema: "dbo",
        //        table: "ContactInformation",
        //        column: "RaceId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_ContactInformation_TitleId",
        //        schema: "dbo",
        //        table: "ContactInformation",
        //        column: "TitleId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Departments_Roles_DepartmentId",
        //        schema: "mapping",
        //        table: "Departments_Roles",
        //        column: "DepartmentId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Departments_Roles_RoleId",
        //        schema: "mapping",
        //        table: "Departments_Roles",
        //        column: "RoleId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_DocumentStores_DocumentTypeId",
        //        schema: "core",
        //        table: "DocumentStores",
        //        column: "DocumentTypeId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_EmailQueues_EmailTemplateId",
        //        schema: "core",
        //        table: "EmailQueues",
        //        column: "EmailTemplateId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_EmailTemplates_EmailAccountId",
        //        schema: "core",
        //        table: "EmailTemplates",
        //        column: "EmailAccountId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_FacilityList_FacilityClassId",
        //        schema: "lookup",
        //        table: "FacilityList",
        //        column: "FacilityClassId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_FacilityList_FacilitySubDistrictId",
        //        schema: "lookup",
        //        table: "FacilityList",
        //        column: "FacilitySubDistrictId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_FacilityList_FacilityTypeId",
        //        schema: "lookup",
        //        table: "FacilityList",
        //        column: "FacilityTypeId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_FacilitySubDistricts_FacilityDistrictId",
        //        schema: "dropdown",
        //        table: "FacilitySubDistricts",
        //        column: "FacilityDistrictId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_FinancialMatters_FundingApplicationDetailId",
        //        schema: "fa",
        //        table: "FinancialMatters",
        //        column: "FundingApplicationDetailId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_FinancialMattersExpenditure_FundingApplicationDetailId",
        //        schema: "fa",
        //        table: "FinancialMattersExpenditure",
        //        column: "FundingApplicationDetailId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_FinancialMattersIncome_FundingApplicationDetailId",
        //        schema: "fa",
        //        table: "FinancialMattersIncome",
        //        column: "FundingApplicationDetailId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_FinancialMattersOthers_FundingApplicationDetailId",
        //        schema: "fa",
        //        table: "FinancialMattersOthers",
        //        column: "FundingApplicationDetailId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_FundAppSDADetail_DistrictCouncilId",
        //        schema: "fa",
        //        table: "FundAppSDADetail",
        //        column: "DistrictCouncilId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_FundAppSDADetail_LocalMunicipalityId",
        //        schema: "fa",
        //        table: "FundAppSDADetail",
        //        column: "LocalMunicipalityId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_FundAppSDADetail_RegionId",
        //        schema: "fa",
        //        table: "FundAppSDADetail",
        //        column: "RegionId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_FundAppSDADetail_Regions_FundAppSDADetailId",
        //        schema: "mapping",
        //        table: "FundAppSDADetail_Regions",
        //        column: "FundAppSDADetailId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_FundAppSDADetail_Regions_RegionId",
        //        schema: "mapping",
        //        table: "FundAppSDADetail_Regions",
        //        column: "RegionId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_FundingApplicationDetails_ApplicationDetailId",
        //        schema: "fa",
        //        table: "FundingApplicationDetails",
        //        column: "ApplicationDetailId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_FundingApplicationDetails_ApplicationPeriodId",
        //        schema: "fa",
        //        table: "FundingApplicationDetails",
        //        column: "ApplicationPeriodId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_FundingApplicationDetails_MonitoringEvaluationId",
        //        schema: "fa",
        //        table: "FundingApplicationDetails",
        //        column: "MonitoringEvaluationId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_FundingApplicationDetails_ProjectInformationId",
        //        schema: "fa",
        //        table: "FundingApplicationDetails",
        //        column: "ProjectInformationId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_LocalMunicipalities_DistrictCouncilId",
        //        schema: "dropdown",
        //        table: "LocalMunicipalities",
        //        column: "DistrictCouncilId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_MyContentLinks_CreatedUserId",
        //        schema: "fa",
        //        table: "MyContentLinks",
        //        column: "CreatedUserId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_NpoProfiles_AccessStatusId",
        //        schema: "dbo",
        //        table: "NpoProfiles",
        //        column: "AccessStatusId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_NpoProfiles_NpoId",
        //        schema: "dbo",
        //        table: "NpoProfiles",
        //        column: "NpoId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_NpoProfiles_FacilityLists_FacilityListId",
        //        schema: "mapping",
        //        table: "NpoProfiles_FacilityLists",
        //        column: "FacilityListId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Npos_ApprovalStatusId",
        //        schema: "dbo",
        //        table: "Npos",
        //        column: "ApprovalStatusId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Npos_ApprovalUserId",
        //        schema: "dbo",
        //        table: "Npos",
        //        column: "ApprovalUserId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Npos_CreatedUserId",
        //        schema: "dbo",
        //        table: "Npos",
        //        column: "CreatedUserId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Npos_OrganisationTypeId",
        //        schema: "dbo",
        //        table: "Npos",
        //        column: "OrganisationTypeId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Npos_RegistrationStatusId",
        //        schema: "dbo",
        //        table: "Npos",
        //        column: "RegistrationStatusId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_NpoUserTrackings_ApplicationId",
        //        schema: "dbo",
        //        table: "NpoUserTrackings",
        //        column: "ApplicationId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Objectives_RecipientTypeId",
        //        schema: "dbo",
        //        table: "Objectives",
        //        column: "RecipientTypeId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Objectives_Programmes_ProgrammeId",
        //        schema: "mapping",
        //        table: "Objectives_Programmes",
        //        column: "ProgrammeId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Objectives_Programmes_SubProgrammeId",
        //        schema: "mapping",
        //        table: "Objectives_Programmes",
        //        column: "SubProgrammeId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_PaymentSchedules_CompliantCycleId",
        //        schema: "dbo",
        //        table: "PaymentSchedules",
        //        column: "CompliantCycleId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Places_ServiceDeliveryAreaId",
        //        schema: "dropdown",
        //        table: "Places",
        //        column: "ServiceDeliveryAreaId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_ProgramBankDetails_ApprovalStatusId",
        //        schema: "dbo",
        //        table: "ProgramBankDetails",
        //        column: "ApprovalStatusId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_ProgramContactInformation_ApprovalStatusId",
        //        schema: "dbo",
        //        table: "ProgramContactInformation",
        //        column: "ApprovalStatusId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_ProgramContactInformation_GenderId",
        //        schema: "dbo",
        //        table: "ProgramContactInformation",
        //        column: "GenderId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_ProgramContactInformation_LanguageId",
        //        schema: "dbo",
        //        table: "ProgramContactInformation",
        //        column: "LanguageId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_ProgramContactInformation_PositionId",
        //        schema: "dbo",
        //        table: "ProgramContactInformation",
        //        column: "PositionId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_ProgramContactInformation_RaceId",
        //        schema: "dbo",
        //        table: "ProgramContactInformation",
        //        column: "RaceId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_ProgramContactInformation_TitleId",
        //        schema: "dbo",
        //        table: "ProgramContactInformation",
        //        column: "TitleId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_ProgrameServiceDeliveryAreas_ProgrameServiceDeliveryId",
        //        schema: "mapping",
        //        table: "ProgrameServiceDeliveryAreas",
        //        column: "ProgrameServiceDeliveryId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_ProgrameServiceDeliveryAreas_ServiceDeliveryAreaId",
        //        schema: "mapping",
        //        table: "ProgrameServiceDeliveryAreas",
        //        column: "ServiceDeliveryAreaId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_ProgrammeSDADetail_Regions_ProgrameServiceDeliveryId",
        //        schema: "mapping",
        //        table: "ProgrammeSDADetail_Regions",
        //        column: "ProgrameServiceDeliveryId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_ProgrammeSDADetail_Regions_RegionId",
        //        schema: "mapping",
        //        table: "ProgrammeSDADetail_Regions",
        //        column: "RegionId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_ProgrammeServiceDelivery_ApprovalStatusId",
        //        schema: "dbo",
        //        table: "ProgrammeServiceDelivery",
        //        column: "ApprovalStatusId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_ProgrammeServiceDelivery_DistrictCouncilId",
        //        schema: "dbo",
        //        table: "ProgrammeServiceDelivery",
        //        column: "DistrictCouncilId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_ProgrammeServiceDelivery_LocalMunicipalityId",
        //        schema: "dbo",
        //        table: "ProgrammeServiceDelivery",
        //        column: "LocalMunicipalityId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Project_Implementation_Places_ImplementationId",
        //        schema: "mapping",
        //        table: "Project_Implementation_Places",
        //        column: "ImplementationId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Project_Implementation_Places_PlaceId",
        //        schema: "mapping",
        //        table: "Project_Implementation_Places",
        //        column: "PlaceId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Project_Implementation_SubPlaces_ImplementationId",
        //        schema: "mapping",
        //        table: "Project_Implementation_SubPlaces",
        //        column: "ImplementationId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Project_Implementation_SubPlaces_SubPlaceId",
        //        schema: "mapping",
        //        table: "Project_Implementation_SubPlaces",
        //        column: "SubPlaceId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_ProjectImplementations_FundingApplicationDetailId",
        //        schema: "fa",
        //        table: "ProjectImplementations",
        //        column: "FundingApplicationDetailId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_PropertySubTypes_PropertyTypeID",
        //        schema: "dropdown",
        //        table: "PropertySubTypes",
        //        column: "PropertyTypeID");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_QuestionCategories_FundingTemplateTypeId_Name",
        //        schema: "eval",
        //        table: "QuestionCategories",
        //        columns: new[] { "FundingTemplateTypeId", "Name" },
        //        unique: true);

        //    migrationBuilder.CreateIndex(
        //        name: "IX_QuestionProperties_QuestionId",
        //        schema: "eval",
        //        table: "QuestionProperties",
        //        column: "QuestionId",
        //        unique: true);

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Questions_QuestionSectionId",
        //        schema: "eval",
        //        table: "Questions",
        //        column: "QuestionSectionId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Questions_ResponseTypeId",
        //        schema: "eval",
        //        table: "Questions",
        //        column: "ResponseTypeId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_QuestionSections_QuestionCategoryId_Name",
        //        schema: "eval",
        //        table: "QuestionSections",
        //        columns: new[] { "QuestionCategoryId", "Name" },
        //        unique: true);

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Regions_LocalMunicipalityId",
        //        schema: "dropdown",
        //        table: "Regions",
        //        column: "LocalMunicipalityId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Resources_ActivityId",
        //        schema: "dbo",
        //        table: "Resources",
        //        column: "ActivityId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Resources_AllocationTypeId",
        //        schema: "dbo",
        //        table: "Resources",
        //        column: "AllocationTypeId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Resources_ProvisionTypeId",
        //        schema: "dbo",
        //        table: "Resources",
        //        column: "ProvisionTypeId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Resources_ResourceListId",
        //        schema: "dbo",
        //        table: "Resources",
        //        column: "ResourceListId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Resources_ResourceTypeId",
        //        schema: "dbo",
        //        table: "Resources",
        //        column: "ResourceTypeId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Resources_ServiceTypeId",
        //        schema: "dbo",
        //        table: "Resources",
        //        column: "ServiceTypeId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_ResponseHistory_CreatedUserId",
        //        schema: "eval",
        //        table: "ResponseHistory",
        //        column: "CreatedUserId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_ResponseHistory_ResponseOptionId",
        //        schema: "eval",
        //        table: "ResponseHistory",
        //        column: "ResponseOptionId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_ResponseOptions_Name",
        //        schema: "eval",
        //        table: "ResponseOptions",
        //        column: "Name",
        //        unique: true);

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Responses_CreatedUserId",
        //        schema: "eval",
        //        table: "Responses",
        //        column: "CreatedUserId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Responses_QuestionId",
        //        schema: "eval",
        //        table: "Responses",
        //        column: "QuestionId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Responses_ResponseOptionId",
        //        schema: "eval",
        //        table: "Responses",
        //        column: "ResponseOptionId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_ResponseTypes_Name",
        //        schema: "eval",
        //        table: "ResponseTypes",
        //        column: "Name",
        //        unique: true);

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Roles_Permissions_PermissionId",
        //        schema: "mapping",
        //        table: "Roles_Permissions",
        //        column: "PermissionId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Segment_Code_ProgrammeId",
        //        schema: "mapping",
        //        table: "Segment_Code",
        //        column: "ProgrammeId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Segment_Code_SubProgrammeTypeId",
        //        schema: "mapping",
        //        table: "Segment_Code",
        //        column: "SubProgrammeTypeId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_ServiceDeliveryAreas_RegionId",
        //        schema: "dropdown",
        //        table: "ServiceDeliveryAreas",
        //        column: "RegionId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_ServiceDeliveryAreas_FundAppSDADetailId",
        //        schema: "mapping",
        //        table: "ServiceDeliveryAreas",
        //        column: "FundAppSDADetailId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_ServiceDeliveryAreas_ServiceDeliveryAreaId",
        //        schema: "mapping",
        //        table: "ServiceDeliveryAreas",
        //        column: "ServiceDeliveryAreaId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_SubPlaces_PlaceId",
        //        schema: "dropdown",
        //        table: "SubPlaces",
        //        column: "PlaceId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_SubRecipients_ObjectiveId",
        //        schema: "dbo",
        //        table: "SubRecipients",
        //        column: "ObjectiveId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_SubSubRecipients_SubRecipientId",
        //        schema: "dbo",
        //        table: "SubSubRecipients",
        //        column: "SubRecipientId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_SustainabilityPlans_ActivityId",
        //        schema: "dbo",
        //        table: "SustainabilityPlans",
        //        column: "ActivityId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_TrainingMaterials_Name",
        //        schema: "dbo",
        //        table: "TrainingMaterials",
        //        column: "Name",
        //        unique: true);

        //    migrationBuilder.CreateIndex(
        //        name: "IX_UserProgramMapping_ProgramId",
        //        schema: "mapping",
        //        table: "UserProgramMapping",
        //        column: "ProgramId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_UserProgramMapping_UserId",
        //        schema: "mapping",
        //        table: "UserProgramMapping",
        //        column: "UserId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Users_Departments_DepartmentId",
        //        schema: "mapping",
        //        table: "Users_Departments",
        //        column: "DepartmentId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Users_Departments_UserId",
        //        schema: "mapping",
        //        table: "Users_Departments",
        //        column: "UserId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Users_Npos_AccessStatusId",
        //        schema: "mapping",
        //        table: "Users_Npos",
        //        column: "AccessStatusId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Users_Npos_CreatedUserId",
        //        schema: "mapping",
        //        table: "Users_Npos",
        //        column: "CreatedUserId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Users_Npos_NpoId",
        //        schema: "mapping",
        //        table: "Users_Npos",
        //        column: "NpoId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Users_Npos_UpdatedUserId",
        //        schema: "mapping",
        //        table: "Users_Npos",
        //        column: "UpdatedUserId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Users_Npos_UserId",
        //        schema: "mapping",
        //        table: "Users_Npos",
        //        column: "UserId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Users_Roles_RoleId",
        //        schema: "mapping",
        //        table: "Users_Roles",
        //        column: "RoleId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Users_Roles_UserId",
        //        schema: "mapping",
        //        table: "Users_Roles",
        //        column: "UserId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_WorkflowAssessments_QuestionCategoryId",
        //        schema: "eval",
        //        table: "WorkflowAssessments",
        //        column: "QuestionCategoryId",
        //        unique: true);

        //    migrationBuilder.CreateIndex(
        //        name: "IX_WorkplanActualAudits_CreatedUserId",
        //        schema: "indicator",
        //        table: "WorkplanActualAudits",
        //        column: "CreatedUserId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_WorkplanActuals_FrequencyPeriodId",
        //        schema: "indicator",
        //        table: "WorkplanActuals",
        //        column: "FrequencyPeriodId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_WorkplanComments_CreatedUserId",
        //        schema: "indicator",
        //        table: "WorkplanComments",
        //        column: "CreatedUserId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_WorkplanTargets_FinancialYearId",
        //        schema: "indicator",
        //        table: "WorkplanTargets",
        //        column: "FinancialYearId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_WorkplanTargets_FrequencyId",
        //        schema: "indicator",
        //        table: "WorkplanTargets",
        //        column: "FrequencyId");
        //}

        ///// <inheritdoc />
        //protected override void Down(MigrationBuilder migrationBuilder)
        //{
        //    migrationBuilder.DropTable(
        //        name: "AccountTypes",
        //        schema: "dropdown");

        //    migrationBuilder.DropTable(
        //        name: "Activities_FacilityLists",
        //        schema: "mapping");

        //    migrationBuilder.DropTable(
        //        name: "Activities_Recipients",
        //        schema: "mapping");

        //    migrationBuilder.DropTable(
        //        name: "Activities_SubProgrammes",
        //        schema: "mapping");

        //    migrationBuilder.DropTable(
        //        name: "AddressInformation",
        //        schema: "dbo");

        //    migrationBuilder.DropTable(
        //        name: "AffiliatedOrganisationInformation",
        //        schema: "dbo");

        //    migrationBuilder.DropTable(
        //        name: "ApplicationApprovals",
        //        schema: "dbo");

        //    migrationBuilder.DropTable(
        //        name: "ApplicationAudits",
        //        schema: "dbo");

        //    migrationBuilder.DropTable(
        //        name: "ApplicationComments",
        //        schema: "dbo");

        //    migrationBuilder.DropTable(
        //        name: "ApplicationReviewerSatisfactions",
        //        schema: "dbo");

        //    migrationBuilder.DropTable(
        //        name: "AuditLogs",
        //        schema: "dbo");

        //    migrationBuilder.DropTable(
        //        name: "AuditorOrAffiliations",
        //        schema: "dbo");

        //    migrationBuilder.DropTable(
        //        name: "BankDetails",
        //        schema: "dbo");

        //    migrationBuilder.DropTable(
        //        name: "Banks",
        //        schema: "dropdown");

        //    migrationBuilder.DropTable(
        //        name: "Branches",
        //        schema: "dropdown");

        //    migrationBuilder.DropTable(
        //        name: "BudgetAdjustment",
        //        schema: "budget");

        //    migrationBuilder.DropTable(
        //        name: "CapturedResponses",
        //        schema: "eval");

        //    migrationBuilder.DropTable(
        //        name: "CompliantCycleRules",
        //        schema: "dbo");

        //    migrationBuilder.DropTable(
        //        name: "ContactInformation",
        //        schema: "dbo");

        //    migrationBuilder.DropTable(
        //        name: "DepartmentBudgets",
        //        schema: "budget");

        //    migrationBuilder.DropTable(
        //        name: "Departments_Roles",
        //        schema: "mapping");

        //    migrationBuilder.DropTable(
        //        name: "DirectorateBudgets",
        //        schema: "budget");

        //    migrationBuilder.DropTable(
        //        name: "Directorates",
        //        schema: "dropdown");

        //    migrationBuilder.DropTable(
        //        name: "DocumentStores",
        //        schema: "core");

        //    migrationBuilder.DropTable(
        //        name: "EmailQueues",
        //        schema: "core");

        //    migrationBuilder.DropTable(
        //        name: "EmbeddedReports",
        //        schema: "core");

        //    migrationBuilder.DropTable(
        //        name: "EntityTypes",
        //        schema: "core");

        //    migrationBuilder.DropTable(
        //        name: "FinancialMatters",
        //        schema: "fa");

        //    migrationBuilder.DropTable(
        //        name: "FinancialMattersExpenditure",
        //        schema: "fa");

        //    migrationBuilder.DropTable(
        //        name: "FinancialMattersIncome",
        //        schema: "fa");

        //    migrationBuilder.DropTable(
        //        name: "FinancialMattersOthers",
        //        schema: "fa");

        //    migrationBuilder.DropTable(
        //        name: "FundAppDocuments",
        //        schema: "fa");

        //    migrationBuilder.DropTable(
        //        name: "FundAppSDADetail_Regions",
        //        schema: "mapping");

        //    migrationBuilder.DropTable(
        //        name: "FundingTemplateTypes",
        //        schema: "dropdown");

        //    migrationBuilder.DropTable(
        //        name: "ImportBudgets",
        //        schema: "budget");

        //    migrationBuilder.DropTable(
        //        name: "MyContentLinks",
        //        schema: "fa");

        //    migrationBuilder.DropTable(
        //        name: "NpoProfiles_FacilityLists",
        //        schema: "mapping");

        //    migrationBuilder.DropTable(
        //        name: "NpoUserTrackings",
        //        schema: "dbo");

        //    migrationBuilder.DropTable(
        //        name: "Objectives_Programmes",
        //        schema: "mapping");

        //    migrationBuilder.DropTable(
        //        name: "PaymentSchedules",
        //        schema: "dbo");

        //    migrationBuilder.DropTable(
        //        name: "PreviousYearFinance",
        //        schema: "dbo");

        //    migrationBuilder.DropTable(
        //        name: "ProgramBankDetails",
        //        schema: "dbo");

        //    migrationBuilder.DropTable(
        //        name: "ProgramContactInformation",
        //        schema: "dbo");

        //    migrationBuilder.DropTable(
        //        name: "ProgrameServiceDeliveryAreas",
        //        schema: "mapping");

        //    migrationBuilder.DropTable(
        //        name: "ProgrammeBudgets",
        //        schema: "budget");

        //    migrationBuilder.DropTable(
        //        name: "ProgrammeSDADetail_Regions",
        //        schema: "mapping");

        //    migrationBuilder.DropTable(
        //        name: "Project_Implementation_Places",
        //        schema: "mapping");

        //    migrationBuilder.DropTable(
        //        name: "Project_Implementation_SubPlaces",
        //        schema: "mapping");

        //    migrationBuilder.DropTable(
        //        name: "PropertySubTypes",
        //        schema: "dropdown");

        //    migrationBuilder.DropTable(
        //        name: "QuarterlyPeriod",
        //        schema: "core");

        //    migrationBuilder.DropTable(
        //        name: "QuestionProperties",
        //        schema: "eval");

        //    migrationBuilder.DropTable(
        //        name: "Resources",
        //        schema: "dbo");

        //    migrationBuilder.DropTable(
        //        name: "ResponseHistory",
        //        schema: "eval");

        //    migrationBuilder.DropTable(
        //        name: "Responses",
        //        schema: "eval");

        //    migrationBuilder.DropTable(
        //        name: "Roles_Permissions",
        //        schema: "mapping");

        //    migrationBuilder.DropTable(
        //        name: "Segment_Code",
        //        schema: "mapping");

        //    migrationBuilder.DropTable(
        //        name: "ServiceDeliveryAreas",
        //        schema: "mapping");

        //    migrationBuilder.DropTable(
        //        name: "ServicesRendered",
        //        schema: "dbo");

        //    migrationBuilder.DropTable(
        //        name: "SourceOfInformation",
        //        schema: "dbo");

        //    migrationBuilder.DropTable(
        //        name: "StaffCategories",
        //        schema: "dropdown");

        //    migrationBuilder.DropTable(
        //        name: "StaffMemberProfiles",
        //        schema: "dbo");

        //    migrationBuilder.DropTable(
        //        name: "SubSubRecipients",
        //        schema: "dbo");

        //    migrationBuilder.DropTable(
        //        name: "SustainabilityPlans",
        //        schema: "dbo");

        //    migrationBuilder.DropTable(
        //        name: "TrainingMaterials",
        //        schema: "dbo");

        //    migrationBuilder.DropTable(
        //        name: "UserProgram",
        //        schema: "core");

        //    migrationBuilder.DropTable(
        //        name: "UserProgramMapping",
        //        schema: "mapping");

        //    migrationBuilder.DropTable(
        //        name: "Users_Departments",
        //        schema: "mapping");

        //    migrationBuilder.DropTable(
        //        name: "Users_Npos",
        //        schema: "mapping");

        //    migrationBuilder.DropTable(
        //        name: "Users_Roles",
        //        schema: "mapping");

        //    migrationBuilder.DropTable(
        //        name: "Utilities",
        //        schema: "core");

        //    migrationBuilder.DropTable(
        //        name: "WorkflowAssessments",
        //        schema: "eval");

        //    migrationBuilder.DropTable(
        //        name: "WorkplanActualAudits",
        //        schema: "indicator");

        //    migrationBuilder.DropTable(
        //        name: "WorkplanActuals",
        //        schema: "indicator");

        //    migrationBuilder.DropTable(
        //        name: "WorkplanComments",
        //        schema: "indicator");

        //    migrationBuilder.DropTable(
        //        name: "WorkplanTargets",
        //        schema: "indicator");

        //    migrationBuilder.DropTable(
        //        name: "NpoProfiles",
        //        schema: "dbo");

        //    migrationBuilder.DropTable(
        //        name: "DocumentTypes",
        //        schema: "core");

        //    migrationBuilder.DropTable(
        //        name: "EmailTemplates",
        //        schema: "core");

        //    migrationBuilder.DropTable(
        //        name: "FacilityList",
        //        schema: "lookup");

        //    migrationBuilder.DropTable(
        //        name: "Applications",
        //        schema: "dbo");

        //    migrationBuilder.DropTable(
        //        name: "CompliantCycles",
        //        schema: "dbo");

        //    migrationBuilder.DropTable(
        //        name: "Gender",
        //        schema: "dropdown");

        //    migrationBuilder.DropTable(
        //        name: "Languages",
        //        schema: "dropdown");

        //    migrationBuilder.DropTable(
        //        name: "Positions",
        //        schema: "dropdown");

        //    migrationBuilder.DropTable(
        //        name: "Races",
        //        schema: "dropdown");

        //    migrationBuilder.DropTable(
        //        name: "Titles",
        //        schema: "dropdown");

        //    migrationBuilder.DropTable(
        //        name: "ProgrammeServiceDelivery",
        //        schema: "dbo");

        //    migrationBuilder.DropTable(
        //        name: "ProjectImplementations",
        //        schema: "fa");

        //    migrationBuilder.DropTable(
        //        name: "SubPlaces",
        //        schema: "dropdown");

        //    migrationBuilder.DropTable(
        //        name: "PropertyTypes",
        //        schema: "dropdown");

        //    migrationBuilder.DropTable(
        //        name: "AllocationTypes",
        //        schema: "dropdown");

        //    migrationBuilder.DropTable(
        //        name: "ProvisionTypes",
        //        schema: "dropdown");

        //    migrationBuilder.DropTable(
        //        name: "ResourceList",
        //        schema: "lookup");

        //    migrationBuilder.DropTable(
        //        name: "ResourceTypes",
        //        schema: "dropdown");

        //    migrationBuilder.DropTable(
        //        name: "ServiceTypes",
        //        schema: "dropdown");

        //    migrationBuilder.DropTable(
        //        name: "Questions",
        //        schema: "eval");

        //    migrationBuilder.DropTable(
        //        name: "ResponseOptions",
        //        schema: "eval");

        //    migrationBuilder.DropTable(
        //        name: "Permissions",
        //        schema: "core");

        //    migrationBuilder.DropTable(
        //        name: "SubProgrammeTypes",
        //        schema: "dropdown");

        //    migrationBuilder.DropTable(
        //        name: "SubRecipients",
        //        schema: "dbo");

        //    migrationBuilder.DropTable(
        //        name: "Activities",
        //        schema: "dbo");

        //    migrationBuilder.DropTable(
        //        name: "Roles",
        //        schema: "core");

        //    migrationBuilder.DropTable(
        //        name: "FrequencyPeriods",
        //        schema: "dropdown");

        //    migrationBuilder.DropTable(
        //        name: "Frequencies",
        //        schema: "dropdown");

        //    migrationBuilder.DropTable(
        //        name: "EmailAccounts",
        //        schema: "core");

        //    migrationBuilder.DropTable(
        //        name: "FacilityClasses",
        //        schema: "dropdown");

        //    migrationBuilder.DropTable(
        //        name: "FacilitySubDistricts",
        //        schema: "dropdown");

        //    migrationBuilder.DropTable(
        //        name: "FacilityTypes",
        //        schema: "dropdown");

        //    migrationBuilder.DropTable(
        //        name: "Npos",
        //        schema: "dbo");

        //    migrationBuilder.DropTable(
        //        name: "Statuses",
        //        schema: "dbo");

        //    migrationBuilder.DropTable(
        //        name: "FundingApplicationDetails",
        //        schema: "fa");

        //    migrationBuilder.DropTable(
        //        name: "Places",
        //        schema: "dropdown");

        //    migrationBuilder.DropTable(
        //        name: "QuestionSections",
        //        schema: "eval");

        //    migrationBuilder.DropTable(
        //        name: "ResponseTypes",
        //        schema: "eval");

        //    migrationBuilder.DropTable(
        //        name: "ActivityList",
        //        schema: "lookup");

        //    migrationBuilder.DropTable(
        //        name: "ActivityTypes",
        //        schema: "dropdown");

        //    migrationBuilder.DropTable(
        //        name: "Objectives",
        //        schema: "dbo");

        //    migrationBuilder.DropTable(
        //        name: "FacilityDistricts",
        //        schema: "dropdown");

        //    migrationBuilder.DropTable(
        //        name: "AccessStatuses",
        //        schema: "dbo");

        //    migrationBuilder.DropTable(
        //        name: "OrganisationTypes",
        //        schema: "dropdown");

        //    migrationBuilder.DropTable(
        //        name: "RegistrationStatuses",
        //        schema: "dropdown");

        //    migrationBuilder.DropTable(
        //        name: "Users",
        //        schema: "core");

        //    migrationBuilder.DropTable(
        //        name: "ApplicationDetails",
        //        schema: "fa");

        //    migrationBuilder.DropTable(
        //        name: "ApplicationPeriods",
        //        schema: "dbo");

        //    migrationBuilder.DropTable(
        //        name: "MonitoringEvaluation",
        //        schema: "fa");

        //    migrationBuilder.DropTable(
        //        name: "ProjectInformation",
        //        schema: "fa");

        //    migrationBuilder.DropTable(
        //        name: "ServiceDeliveryAreas",
        //        schema: "dropdown");

        //    migrationBuilder.DropTable(
        //        name: "QuestionCategories",
        //        schema: "eval");

        //    migrationBuilder.DropTable(
        //        name: "RecipientTypes",
        //        schema: "dropdown");

        //    migrationBuilder.DropTable(
        //        name: "FundAppSDADetail",
        //        schema: "fa");

        //    migrationBuilder.DropTable(
        //        name: "ApplicationTypes",
        //        schema: "dropdown");

        //    migrationBuilder.DropTable(
        //        name: "Departments",
        //        schema: "core");

        //    migrationBuilder.DropTable(
        //        name: "FinancialYears",
        //        schema: "core");

        //    migrationBuilder.DropTable(
        //        name: "Programmes",
        //        schema: "dropdown");

        //    migrationBuilder.DropTable(
        //        name: "SubProgrammes",
        //        schema: "dropdown");

        //    migrationBuilder.DropTable(
        //        name: "Regions",
        //        schema: "dropdown");

        //    migrationBuilder.DropTable(
        //        name: "LocalMunicipalities",
        //        schema: "dropdown");

        //    migrationBuilder.DropTable(
        //        name: "DistrictCouncils",
        //        schema: "dropdown");
        }
    }
}
