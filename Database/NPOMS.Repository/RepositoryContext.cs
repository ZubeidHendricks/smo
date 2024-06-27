using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Configuration;
using NPOMS.Domain.Budget;
using NPOMS.Domain.Core;
using NPOMS.Domain.Dropdown;
using NPOMS.Domain.Entities;
using NPOMS.Domain.Enumerations;
using NPOMS.Domain.Evaluation;
using NPOMS.Domain.Indicator;
using NPOMS.Domain.Lookup;
using NPOMS.Domain.Mapping;
using NPOMS.Repository.Configurations.Core;
using NPOMS.Repository.Configurations.Dropdown;
using NPOMS.Repository.Configurations.Entities;
using NPOMS.Repository.Configurations.Lookup;
using NPOMS.Repository.Configurations.Mapping;
using NPOMS.Repository.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NPOMS.Repository
{
    public class RepositoryContext : DbContext
    {
        private IConfiguration _configuration;
        private IDBAuthTokenService _authTokenService;

        public RepositoryContext(DbContextOptions options)
            : base(options)
        {

        }

        public RepositoryContext(
                IConfiguration configuration,
                IDBAuthTokenService tokenService,
                DbContextOptions options
            )
            : base(options)
        {
            _configuration = configuration;
            _authTokenService = tokenService;
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = Environment.GetEnvironmentVariable("SQLAZURECONNSTR_Conn01");

            #if DEBUG
            connection.ConnectionString = _configuration.GetConnectionString("SQLAZURECONNSTR_Conn01");
            #endif

            if (connection.ConnectionString.Contains("database.windows.net"))
            {
                connection.AccessToken = _authTokenService.GetToken().Result;
            }

            optionsBuilder.UseSqlServer(connection, s => s.MigrationsAssembly("NPOMS.Repository"));
            optionsBuilder.EnableSensitiveDataLogging();

		}

        /* Core */
        public DbSet<Department> Departments { get; set; }
       // public DbSet<UserProgram> UserProgram { get; set; }
        public DbSet<DocumentStore> DocumentStores { get; set; }
        public DbSet<FundAppDocuments> FundAppDocuments { get; set; }

        public DbSet<DocumentType> DocumentTypes { get; set; }
        public DbSet<EmailAccount> EmailAccounts { get; set; }
        public DbSet<EmailQueue> EmailQueues { get; set; }
        public DbSet<EmailTemplate> EmailTemplates { get; set; }
        public DbSet<EntityType> EntityTypes { get; set; }
        public DbSet<FinancialYear> FinancialYears { get; set; }
        public DbSet<QuarterlyPeriod> QuarterlyPeriod { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Utility> Utilities { get; set; }
        public DbSet<EmbeddedReport> EmbeddedReports { get; set; }

        /* Dropdown */
        public DbSet<Programme> programmes { get; set; }
        public DbSet<ActivityType> ActivityTypes { get; set; }
        public DbSet<ApplicationType> AllocationTypes { get; set; }
        public DbSet<ApplicationType> ApplicationTypes { get; set; }
        public DbSet<FacilityClass> FacilityClasses { get; set; }
        public DbSet<FacilityDistrict> FacilityDistricts { get; set; }
        public DbSet<FacilitySubDistrict> FacilitySubDistricts { get; set; }
        public DbSet<FacilityType> FacilityTypes { get; set; }
        public DbSet<OrganisationType> OrganisationTypes { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Race> Races { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<FundingTemplateType> FundingTemplateType { get; set; }
        public DbSet<ProvisionType> ProvisionTypes { get; set; }
        public DbSet<RecipientType> RecipientTypes { get; set; }
        public DbSet<ResourceType> ResourceTypes { get; set; }
        public DbSet<ServiceType> ServiceTypes { get; set; }
        public DbSet<SubProgramme> SubProgrammes { get; set; }
        public DbSet<Title> Titles { get; set; }
        public DbSet<Frequency> Frequencies { get; set; }
        public DbSet<FrequencyPeriod> FrequencyPeriods { get; set; }
        public DbSet<SubProgrammeType> SubProgrammeTypes { get; set; }
        public DbSet<Directorate> Directorates { get; set; }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<BankDetail> BankDetail { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<AccountType> AccountTypes { get; set; }
        public DbSet<RegistrationStatus> RegistrationStatuses { get; set; }
        public DbSet<DistrictCouncil> DistrictCouncils { get; set; }
        public DbSet<LocalMunicipality> LocalMunicipalities { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<ServiceDeliveryArea> ServiceDeliveryAreas { get; set; }
        public DbSet<PropertyType> PropertyTypes { get; set; }
        public DbSet<PropertySubType> PropertySubTypes { get; set; }
        public DbSet<StaffCategory> StaffCategories { get; set; }

        /* Entities */
        public DbSet<AccessStatus> AccessStatuses { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<AddressInformation> AddressInformation { get; set; }
        public DbSet<Application> Applications { get; set; }
        public DbSet<ApplicationApproval> ApplicationApprovals { get; set; }
        public DbSet<ApplicationAudit> ApplicationAudits { get; set; }
        public DbSet<ApplicationComment> ApplicationComments { get; set; }
        public DbSet<ApplicationPeriod> ApplicationPeriods { get; set; }
        public DbSet<ApplicationReviewerSatisfaction> ApplicationReviewerSatisfactions { get; set; }
        public DbSet<ContactInformation> ContactInformation { get; set; }
        public DbSet<Npo> Npos { get; set; }
        public DbSet<NpoProfile> NpoProfiles { get; set; }
        public DbSet<Objective> Objectives { get; set; }
        public DbSet<FundingApplicationDetail> FundingApplicationDetails { get; set; }
        //public DbSet<FinancialDetail> FinancialDetails { get; set; }
        public DbSet<ProjectInformation> ProjectInformations { get; set; }
        public DbSet<MonitoringEvaluation> MonitoringEvaluations { get; set; }
        public DbSet<ProjectImplementation> ProjectImplementations { get; set; }

        public DbSet<FinancialMattersIncome> FinancialMattersIncomes { get; set; }
        public DbSet<FinancialMattersExpenditure> FinancialMattersExpenditures { get; set; }
        public DbSet<FinancialMattersOthers> FinancialMattersOthers { get; set; }

        public DbSet<FundAppSDADetail> FundAppSDADetails { get; set; }
        public DbSet<Resource> Resources { get; set; }
        //public DbSet<Status> Statuses { get; set; }
        public DbSet<SustainabilityPlan> SustainabilityPlans { get; set; }
        public DbSet<ServicesRendered> ServicesRendered { get; set; }
        public DbSet<BankDetail> BankDetails { get; set; }
        public DbSet<CompliantCycleRule> CompliantCycleRules { get; set; }
        public DbSet<CompliantCycle> CompliantCycles { get; set; }
        public DbSet<PaymentSchedule> PaymentSchedules { get; set; }
        public DbSet<AuditLog> AuditLogs { get; set; }
        public DbSet<AuditorOrAffiliation> AuditorOrAffiliations { get; set; }
        public DbSet<StaffMemberProfile> StaffMemberProfiles { get; set; }
        public DbSet<SourceOfInformation> SourceOfInformation { get; set; }
        public DbSet<AffiliatedOrganisationInformation> AffiliatedOrganisationInformation { get; set; }
        public DbSet<MyContentLink> MyContentLinks { get; set; }
        public DbSet<SubRecipient> SubRecipients { get; set; }
        public DbSet<SubSubRecipient> SubSubRecipients { get; set; }

        /* Lookup */
        public DbSet<FacilityList> ActivityList { get; set; }
        public DbSet<FacilityList> FacilityList { get; set; }
        public DbSet<ResourceList> ResourceList { get; set; }

        /* Evaluation */
        public DbSet<FundingTemplateType> FundingTemplateTypes { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<QuestionCategory> QuestionCategories { get; set; }
        public DbSet<QuestionProperty> QuestionProperties { get; set; }
        public DbSet<QuestionSection> QuestionSections { get; set; }
        public DbSet<Response> Responses { get; set; }
        public DbSet<ResponseHistory> ResponseHistory { get; set; }
        public DbSet<ResponseOption> ResponseOptions { get; set; }
        public DbSet<ResponseType> ResponseTypes { get; set; }
        public DbSet<WorkflowAssessment> WorkflowAssessments { get; set; }
        public DbSet<CapturedResponse> CapturedResponses { get; set; }

        /* Mapping */
        public DbSet<ActivitySubProgramme> ActivitySubProgrammes { get; set; }
        public DbSet<NpoProfileFacilityList> NpoProfileFacilityLists { get; set; }
        public DbSet<ObjectiveProgramme> ObjectiveProgrammes { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        public DbSet<UserDepartment> UserDepartments { get; set; }
        public DbSet<UserNpo> UserNpos { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<DepartmentRoleMapping> DepartmentRoleMappings { get; set; }
        public DbSet<UserProgramMapping> UserProgramMappings { get; set; }
        public DbSet<ActivityFacilityList> ActivityFacilityLists { get; set; }
        public DbSet<ActivityRecipient> ActivityRecipients { get; set; }
        public DbSet<SegmentCode> SegmentCodes { get; set; }

        /* Indicator */
        public DbSet<WorkplanTarget> WorkplanTargets { get; set; }
        public DbSet<WorkplanActual> WorkplanActuals { get; set; }
        public DbSet<WorkplanComment> WorkplanComments { get; set; }
        public DbSet<WorkplanActualAudit> WorkplanActualAudits { get; set; }

        /* Budget */
        public DbSet<DepartmentBudget> DepartmentBudgets { get; set; }
        public DbSet<DirectorateBudget> DirectorateBudgets { get; set; }
        public DbSet<ProgrammeBudget> ProgrammeBudgets { get; set; }   
        public DbSet<BudgetAdjustment> BudgetAdjustment { get; set; }
        public DbSet<ImportBudget> ImportBudget { get; set; }

        /* Program */

        public DbSet<ProgramBankDetails> ProgramBankDetails { get; set; }
        public DbSet<ProgramContactInformation> ProgramContactInformation { get; set; }
        public DbSet<ProgrammeServiceDelivery> ProgrammeServiceDelivery { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<RolePermission>().HasKey(x => new { x.RoleId, x.PermissionId });
            modelBuilder.Entity<ObjectiveProgramme>().HasKey(x => new { x.ObjectiveId, x.ProgrammeId, x.SubProgrammeId });
            modelBuilder.Entity<ActivityRecipient>().HasKey(x => new { x.ActivityId, x.EntityId, x.RecipientTypeId });

            modelBuilder.Entity<RolePermission>()
                .HasOne(x => x.Role)
                .WithMany(x => x.Permissions)
                .HasForeignKey(x => x.RoleId);

            modelBuilder.Entity<RolePermission>()
                .HasOne(x => x.Permission)
                .WithMany(x => x.Roles)
                .HasForeignKey(x => x.PermissionId);

            //modelBuilder.Entity<ObjectiveProgramme>()
            //	.HasOne(x => x.Programme)
            //	.WithMany(x => x.SubProgrammes)
            //	.HasForeignKey(x => x.ProgrammeId);

            modelBuilder.Entity<ObjectiveProgramme>()
                .HasOne(x => x.SubProgramme)
                .WithMany(x => x.Programmes)
                .HasForeignKey(x => x.SubProgrammeId);

            /* Core */
            modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
          //  modelBuilder.ApplyConfiguration(new UserProgramConfiguration());
            modelBuilder.ApplyConfiguration(new DocumentTypeConfiguration());
            modelBuilder.ApplyConfiguration(new EmailAccountConfiguration());
            modelBuilder.ApplyConfiguration(new EmailTemplateConfiguration());
            modelBuilder.ApplyConfiguration(new EntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new FinancialYearConfiguration());
            modelBuilder.ApplyConfiguration(new QuarterlyPeriodConfiguration());
            modelBuilder.ApplyConfiguration(new PermissionConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UtilityConfiguration());
            modelBuilder.ApplyConfiguration(new EmbeddedReportConfiguration());

            /* Dropdown */
            modelBuilder.ApplyConfiguration(new ActivityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new AllocationTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ApplicationTypeConfiguration());
            modelBuilder.ApplyConfiguration(new FacilityClassConfiguration());
            modelBuilder.ApplyConfiguration(new FacilityDistrictConfiguration());
            modelBuilder.ApplyConfiguration(new FacilitySubDistrictConfiguration());
            modelBuilder.ApplyConfiguration(new FacilityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new OrganisationTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PositionConfiguration());
            modelBuilder.ApplyConfiguration(new ProgrammeConfiguration());
            modelBuilder.ApplyConfiguration(new ProvisionTypeConfiguration());
            modelBuilder.ApplyConfiguration(new RecipientTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ResourceTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ServiceTypeConfiguration());
            modelBuilder.ApplyConfiguration(new SubProgrammeConfiguration());
            modelBuilder.ApplyConfiguration(new TitleConfiguration());
            modelBuilder.ApplyConfiguration(new FrequencyConfiguration());
            modelBuilder.ApplyConfiguration(new FrequencyPeriodConfiguration());
            modelBuilder.ApplyConfiguration(new SubProgrammeTypeConfiguration());
            modelBuilder.ApplyConfiguration(new DirectorateConfiguration());
            modelBuilder.ApplyConfiguration(new BankConfiguration());
            modelBuilder.ApplyConfiguration(new BranchConfiguration());
            modelBuilder.ApplyConfiguration(new AccountTypeConfiguration());
            modelBuilder.ApplyConfiguration(new DistrictCouncilConfiguration());
            modelBuilder.ApplyConfiguration(new LocalMunicipalityConfiguration());
            modelBuilder.ApplyConfiguration(new RegionConfiguration());
            modelBuilder.ApplyConfiguration(new ServiceDeliveryAreaConfiguration());
            modelBuilder.ApplyConfiguration(new PropertyTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PropertySubTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PlaceConfiguration());
            modelBuilder.ApplyConfiguration(new SubPlaceConfiguration());
            modelBuilder.ApplyConfiguration(new GenderConfiguration());
            modelBuilder.ApplyConfiguration(new RaceConfiguration());
            modelBuilder.ApplyConfiguration(new LanguageConfiguration());
            modelBuilder.ApplyConfiguration(new RegistrationStatusConfiguration());
            modelBuilder.ApplyConfiguration(new StaffCategoryConfiguration());

            /* Entities */
            modelBuilder.ApplyConfiguration(new AccessStatusConfiguration());
            modelBuilder.ApplyConfiguration(new StatusConfiguration());
            modelBuilder.ApplyConfiguration(new TrainingMaterialConfiguration());
            modelBuilder.ApplyConfiguration(new CompliantCycleRuleConfiguration());
            modelBuilder.ApplyConfiguration(new PreviousYearFinanceConfiguration());
            modelBuilder.ApplyConfiguration(new FundingTemplateTypeConfiguration());
            //modelBuilder.ApplyConfiguration(new AffiliatedOrganisationInformationConfiguration());
            //modelBuilder.ApplyConfiguration(new SourceOfInformationConfiguration());
            /* Lookup */
            modelBuilder.ApplyConfiguration(new ActivityListConfiguration());
            modelBuilder.ApplyConfiguration(new ResourceListConfiguration());

            /* Mapping */
            modelBuilder.ApplyConfiguration(new RolePermissionConfiguration());
            modelBuilder.ApplyConfiguration(new DepartmentRoleConfiguration());  
            modelBuilder.ApplyConfiguration(new UserDepartmentConfiguration());
            modelBuilder.ApplyConfiguration(new UserRoleConfiguration());
            modelBuilder.ApplyConfiguration(new UserProgramMppingConfiguration());
            modelBuilder.ApplyConfiguration(new SegmentCodeConfiguration());

        }

        /// <summary>
        /// Add all changes to AuditLog table in database
        /// Found at https://codewithmukesh.com/blog/audit-trail-implementation-in-aspnet-core/ and https://www.meziantou.net/entity-framework-core-history-audit-table.htm
        /// </summary>
        /// <param name="currentUserId"></param>
        /// <returns></returns>
        public virtual async Task<int> SaveChangesAsync(int currentUserId)
        {
            var auditEntries = OnBeforeSaveChanges(currentUserId);
            var result = await base.SaveChangesAsync();
            await OnAfterSaveChanges(auditEntries);
            return result;
        }

        private List<AuditLogDTO> OnBeforeSaveChanges(int currentUserId)
        {
            ChangeTracker.DetectChanges();
            var auditEntries = new List<AuditLogDTO>();

            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.Entity is AuditLog || entry.State == EntityState.Detached || entry.State == EntityState.Unchanged)
                    continue;

                var auditEntry = new AuditLogDTO(entry);
                auditEntry.TableName = String.Format("[{0}].[{1}]", entry.Metadata.GetSchema(), entry.Metadata.GetTableName());
                auditEntry.CreatedUserId = currentUserId;
                auditEntries.Add(auditEntry);

                foreach (var property in entry.Properties)
                {
                    if (property.IsTemporary)
                    {
                        // value will be generated by the database, get the value after saving
                        auditEntry.TemporaryProperties.Add(property);
                        continue;
                    }

                    string propertyName = property.Metadata.Name;
                    if (property.Metadata.IsPrimaryKey())
                    {
                        auditEntry.TablePrimaryKey = Convert.ToInt32(property.CurrentValue);
                        continue;
                    }

                    switch (entry.State)
                    {
                        case EntityState.Added:
                            auditEntry.AuditType = AuditTypeEnum.Create;
                            auditEntry.NewValue[propertyName] = property.CurrentValue;
                            break;

                        case EntityState.Deleted:
                            auditEntry.AuditType = AuditTypeEnum.Delete;
                            auditEntry.OldValue[propertyName] = property.OriginalValue;
                            break;

                        case EntityState.Modified:
                            if (property.IsModified)
                            {
                                auditEntry.AffectedColumns.Add(propertyName);
                                auditEntry.AuditType = AuditTypeEnum.Update;
                                auditEntry.OldValue[propertyName] = property.OriginalValue;
                                auditEntry.NewValue[propertyName] = property.CurrentValue;
                            }
                            break;
                    }
                }
            }

            // Save audit entities that have all the modifications
            foreach (var auditEntry in auditEntries.Where(_ => !_.HasTemporaryProperties))
            {
                AuditLogs.Add(auditEntry.ToAudit());
            }

            // keep a list of entries where the value of some properties are unknown at this step
            return auditEntries.Where(_ => _.HasTemporaryProperties).ToList();
        }

        private Task OnAfterSaveChanges(List<AuditLogDTO> auditEntries)
        {
            if (auditEntries == null || auditEntries.Count == 0)
                return Task.CompletedTask;

            foreach (var auditEntry in auditEntries)
            {
                // Get the final value of the temporary properties
                foreach (var prop in auditEntry.TemporaryProperties)
                {
                    if (prop.Metadata.IsPrimaryKey())
                        auditEntry.TablePrimaryKey = Convert.ToInt32(prop.CurrentValue);
                    else
                        auditEntry.TablePrimaryKey = Convert.ToInt32(prop.CurrentValue);
                }

                // Save the Audit entry
                AuditLogs.Add(auditEntry.ToAudit());
            }

            return SaveChangesAsync();
        }
    }
}
