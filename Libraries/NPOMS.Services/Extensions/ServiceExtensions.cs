using AutoMapper;
using NPOMS.Services.Implementation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using NPOMS.Repository;
using NPOMS.Repository.Implementation.Budget;
using NPOMS.Repository.Implementation.Core;
using NPOMS.Repository.Implementation.Dropdown;
using NPOMS.Repository.Implementation.Entities;
using NPOMS.Repository.Implementation.Evaluation;
using NPOMS.Repository.Implementation.Indicator;
using NPOMS.Repository.Implementation.Lookup;
using NPOMS.Repository.Implementation.Mapping;
using NPOMS.Repository.Interfaces.Budget;
using NPOMS.Repository.Interfaces.Core;
using NPOMS.Repository.Interfaces.Dropdown;
using NPOMS.Repository.Interfaces.Entities;
using NPOMS.Repository.Interfaces.Evaluation;
using NPOMS.Repository.Interfaces.Indicator;
using NPOMS.Repository.Interfaces.Lookup;
using NPOMS.Repository.Interfaces.Mapping;
using NPOMS.Services.DenodoAPI.Implementation;
using NPOMS.Services.DenodoAPI.Interfaces;
using NPOMS.Services.Infrastructure.Implementation;
using NPOMS.Services.Interfaces;
using NPOMS.Services.Mappings;
using NPOMS.Services.PowerBI;
using IProgrammeRepository = NPOMS.Repository.Interfaces.Dropdown.IProgrammeRepository;
using NPOMS.Domain.Enumerations;

namespace NPOMS.Services.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureIISIntegration(this IServiceCollection services)
        {
            services.Configure<IISOptions>(options =>
            {

            });
        }

        public static void ConfigureRepositoryWrapper(this IServiceCollection services, WebApplicationBuilder builder)
        {
            // Take note of the IDBAuthTokenService service. This is how we provide support Managed Identity in app services
            services.AddDbContext<RepositoryContext>();
            services.AddTransient<IDBAuthTokenService, AzureSqlAuthTokenService>();

            /* AutoMapper */
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingConfiguration());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            #region  Repositories 

            /* Core */
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
          //  services.AddScoped<IUserProgramRepository, UserProgramRepository>();
            services.AddScoped<IDocumentStoreRepository, DocumentStoreRepository>();
            services.AddScoped<IDocumentTypeRepository, DocumentTypeRepository>();
            services.AddScoped<IEmailAccountRepository, EmailAccountRepository>();
            services.AddScoped<IEmailQueueRepository, EmailQueueRepository>();
            services.AddScoped<IEmailTemplateRepository, EmailTemplateRepository>();
            services.AddScoped<IFinancialYearRepository, FinancialYearRepository>();
            services.AddScoped<IQuarterlyPeriodRepository, QuarterlyPeriodRepository>();
            services.AddScoped<IPermissionRepository, PermissionRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUtilityRepository, UtilityRepository>();
            services.AddScoped<IEmbeddedReportRepository, EmbeddedReportRepository>();

            /* Dropdown */
            services.AddScoped<IFundingTemplateTypeRepository, FundingTemplateTypeRepository>();
            services.AddScoped<IActivityTypeRepository, ActivityTypeRepository>();
            services.AddScoped<IAllocationTypeRepository, AllocationTypeRepository>();
            services.AddScoped<IApplicationTypeRepository, ApplicationTypeRepository>();
            services.AddScoped<IFacilityClassRepository, FacilityClassRepository>();
            services.AddScoped<IFacilityDistrictRepository, FacilityDistrictRepository>();
            services.AddScoped<IFacilitySubDistrictRepository, FacilitySubDistrictRepository>();
            services.AddScoped<IFacilityTypeRepository, FacilityTypeRepository>();
            services.AddScoped<IOrganisationTypeRepository, OrganisationTypeRepository>();
            services.AddScoped<IPositionRepository, PositionRepository>();
            services.AddScoped<IProgrammeRepository, ProgrammeRepository>();
            services.AddScoped<IProvisionTypeRepository, ProvisionTypeRepository>();
            services.AddScoped<IRecipientTypeRepository, RecipientTypeRepository>();
            services.AddScoped<IResourceTypeRepository, ResourceTypeRepository>();
            services.AddScoped<IServiceTypeRepository, ServiceTypeRepository>();
            services.AddScoped<ISubProgrammeRepository, SubProgrammeRepository>();
            services.AddScoped<ITitleRepository, TitleRepository>();
            services.AddScoped<IFrequencyRepository, FrequencyRepository>();
            services.AddScoped<IFrequencyPeriodRepository, FrequencyPeriodRepository>();
            services.AddScoped<ISubProgrammeTypeRepository, SubProgrammeTypeRepository>();
            services.AddScoped<IDirectorateRepository, DirectorateRepository>();
            services.AddScoped<IBankRepository, BankRepository>();
            services.AddScoped<IBranchRepository, BranchRepository>();
            services.AddScoped<IAccountTypeRepository, AccountTypeRepository>();
            services.AddScoped<IDistrictCouncilRepository, DistrictCouncilRepository>();
            services.AddScoped<ILocalMunicipalityRepository, LocalMunicipalityRepository>();
            services.AddScoped<IRegionRepository, RegionRepository>();
            services.AddScoped<IServiceDeliveryAreaRepository, ServiceDeliveryAreaRepository>();
            services.AddScoped<IPropertyTypeRepository, PropertyTypeRepository>();
            services.AddScoped<IPropertySubTypeRepository, PropertySubTypeRepository>();
            services.AddScoped<IPlaceRepository, PlaceRepository>();
            services.AddScoped<ISubPlaceRepository, SubPlaceRepositoy>();
            services.AddScoped<IRaceRepository, RaceRepository>();
            services.AddScoped<IGenderRepository, GenderRepository>();
            services.AddScoped<ILanguageRepository, LanguageRepository>();
            services.AddScoped<IRegistrationStatusRepository, RegistrationStatusRepository>();
            services.AddScoped<IStaffCategoryRepository, StaffCategoryRepository>();

            /* Entities */
            services.AddScoped<IAccessStatusRepository, AccessStatusRepository>();
            services.AddScoped<IActivityRepository, ActivityRepository>();
            services.AddScoped<IApplicationRepository, ApplicationRepository>();
            services.AddScoped<IApplicationApprovalRepository, ApplicationApprovalRepository>();
            services.AddScoped<IApplicationAuditRepository, ApplicationAuditRepository>();
            services.AddScoped<IApplicationCommentRepository, ApplicationCommentRepository>();
            services.AddScoped<IApplicationPeriodRepository, ApplicationPeriodRepository>();
            services.AddScoped<IApplicationReviewerSatisfactionRepository, ApplicationReviewerSatisfactionRepository>();
            services.AddScoped<IContactInformationRepository, ContactInformationRepository>();
            services.AddScoped<INpoRepository, NpoRepository>();
            services.AddScoped<INpoProfileRepository, NpoProfileRepository>();
            services.AddScoped<IObjectiveRepository, ObjectiveRepository>();
            services.AddScoped<IResourceRepository, ResourceRepository>();
            services.AddScoped<IStatusRepository, StatusRepository>();
            services.AddScoped<ISustainabilityPlanRepository, SustainabilityPlanRepository>();
            services.AddScoped<ITrainingMaterialRepository, TrainingMaterialRepository>();
            services.AddScoped<IServicesRenderedRepository, ServicesRenderedRepository>();
            services.AddScoped<IBankDetailRepository, BankDetailRepository>();
            services.AddScoped<ICompliantCycleRuleRepository, CompliantCycleRuleRepository>();
            services.AddScoped<ICompliantCycleRepository, CompliantCycleRepository>();
            services.AddScoped<IPaymentScheduleRepository, PaymentScheduleRepository>();
            services.AddScoped<IFundingApplicationDetailsRepository, FundingApplicationDetailsRepository>();
            //services.AddScoped<IFinancialDetailRepository, FinancialDetailRepository>();
            services.AddScoped<IProjectInformationRepository, ProjectInformationRepository>();
            services.AddScoped<IMonitoringEvaluationRepository, MonitoringEvaluationRepository>();
            services.AddScoped<IProjectImplementationRepository, ProjectImplementationRepository>();
            services.AddScoped<IFundAppSDADetailRepository, FundAppSDADetailRepository>();
            services.AddScoped<IFundAppRegionRepository, FundAppRegionRepository>();
            services.AddScoped<IServiceDeliveryAreaRepository, ServiceDeliveryAreaRepository>();
            services.AddScoped<IFundAppServiceDeliveryAreaRepository, FundAppServiceDeliveryAreaRepository>();
            services.AddScoped<IProjectInformationRepository, ProjectInformationRepository>();
            services.AddScoped<IMonitoringEvaluationRepository, MonitoringEvaluationRepository>();
            services.AddScoped<IProjectImplementationRepository, ProjectImplementationRepository>();
            services.AddScoped<IFundAppSDADetailRepository, FundAppSDADetailRepository>();
            services.AddScoped<IPreviousYearFinanceRepository, PreviousYearFinanceRepository>();
            services.AddScoped<ISubRecipientRepository, SubRecipientRepository>();
			services.AddScoped<ISubSubRecipientRepository, SubSubRecipientRepository>();

			services.AddScoped<IFinancialMattersIncomeRepository, FinancialMattersIncomeRepository>();
            services.AddScoped<IFinancialMattersExpenditureRepository, FinancialMattersExpenditureRepository>();
            services.AddScoped<IFinancialMattersOthersRepository, FinancialMattersOthersRepository>();
           // services.AddScoped<IFundingApplicationRepository, FundingApplicationRepository>();



            services.AddScoped<IAffiliatedOrganisationInformationRepository, AffiliatedOrganisationInformationRepository>();
            services.AddScoped<ISourceOfInformationRepository, SourceOfInformationRepository>();
            services.AddScoped<IFundAppRegionRepository, FundAppRegionRepository>();
            services.AddScoped<IServiceDeliveryAreaRepository, ServiceDeliveryAreaRepository>();

            services.AddScoped<IFundAppServiceDeliveryAreaRepository, FundAppServiceDeliveryAreaRepository>();
            services.AddScoped<IFinancialMattersRepository, FinancialMattersRepository>();
            services.AddScoped<IApplicationDetailsRepository, ApplicationDetailsRepository>();
            services.AddScoped<IBidRepository, BidRepository>();
            services.AddScoped<IAuditorOrAffiliationRepository, AuditorOrAffiliationRepository>();
            services.AddScoped<IStaffMemberProfileRepository, StaffMemberProfileRepository>();
            services.AddScoped<IFinancialMattersIncomeRepository, FinancialMattersIncomeRepository>();
            services.AddScoped<IFinancialMattersExpenditureRepository, FinancialMattersExpenditureRepository>();
            services.AddScoped<IFinancialMattersOthersRepository, FinancialMattersOthersRepository>();

            services.AddScoped<IMyContentLinkRepository, MyContentLinkRepository>();


            /* Lookup */
            services.AddScoped<IActivityListRepository, ActivityListRepository>();
            services.AddScoped<IFacilityListRepository, FacilityListRepository>();
            services.AddScoped<IResourceListRepository, ResourceListRepository>();

            /* Mapping */
            services.AddScoped<IActivitySubProgrammeRepository, ActivitySubProgrammeRepository>();
            services.AddScoped<INpoProfileFacilityListRepository, NpoProfileFacilityListRepository>();
            services.AddScoped<IObjectiveProgrammeRepository, ObjectiveProgrammeRepository>();
            services.AddScoped<IDepartmentRoleRepository, DepartmentRoleRepository>();
            services.AddScoped<IRolePermissionRepository, RolePermissionRepository>();
            services.AddScoped<IUserNpoRepository, UserNpoRepository>();
            services.AddScoped<IUserRoleRepository, UserRoleRepository>();
            services.AddScoped<IUserProgramMappingRepository, UserProgramMappingRepository>();
            services.AddScoped<IActivityFacilityListRepository, ActivityFacilityListRepository>();
            services.AddScoped<IActivityRecipientRepository, ActivityRecipientRepository>();

            services.AddScoped<IProjectImplementationPlaceRepository, ProjectImplementationPlaceRepository>();
            services.AddScoped<IProjectImplementationSubPlaceRepository, ProjectImplementationSubPlaceRepository>();
            services.AddScoped<IFundAppDocumentRepository, FundAppDocumentsRepository>();

            /* Indicator */
            services.AddScoped<IWorkplanTargetRepository, WorkplanTargetRepository>();
            services.AddScoped<IWorkplanActualRepository, WorkplanActualRepository>();
            services.AddScoped<IWorkplanCommentRepository, WorkplanCommentRepository>();
            services.AddScoped<IWorkplanActualAuditRepository, WorkplanActualAuditRepository>();

            /* Budget */
            services.AddScoped<IDepartmentBudgetRepository, DepartmentBudgetRepository>();
            services.AddScoped<IDirectorateBudgetRepository, DirectorateBudgetRepository>();
            services.AddScoped<IProgrammeBudgetRepository, ProgrammeBudgetRepository>();

            /* Evaluation */
            services.AddScoped<IQuestionRepository, QuestionRepository>();
            services.AddScoped<IQuestionSectionRepository, QuestionSectionRepository>();
            services.AddScoped<IQuestionCategoryRepository, QuestionCategoryRepository>();
            services.AddScoped<IResponseOptionRepository, ResponseOptionRepository>();
            services.AddScoped<IResponseTypeRepository, ResponseTypeRepository>();
            services.AddScoped<IWorkflowAssessmentRepository, WorkflowAssessmentRepository>();
            services.AddScoped<IResponseRepository, ResponseRepository>();
            services.AddScoped<IResponseHistoryRepository, ResponseHistoryRepository>();
            services.AddScoped<ICapturedResponseRepository, CapturedResponseRepository>();

            services.AddScoped<IProgrameBankDetailRepository, ProgrameBankDetailRepository>();
            services.AddScoped<IProgrameContactDetailRepository, ProgrameContactDetailRepository>();
            services.AddScoped<IProgrameDeliveryRepository, ProgrameDeliveryRepository>();


            #endregion

            #region Services

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRolePermissionService, RolePermissionService>();
            services.AddScoped<IEmailQueueService, EmailQueueService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IEmailTemplateService, EmailTemplateService>();
            services.AddScoped<IDropdownService, DropdownService>();
            services.AddScoped<INpoProfileService, NpoProfileService>();
            services.AddScoped<INpoService, NpoService>();
            services.AddScoped<IUserNpoService, UserNpoService>();
            services.AddScoped<IApplicationPeriodService, ApplicationPeriodService>();
            services.AddScoped<IApplicationService, ApplicationService>();
            services.AddScoped<IDenodoService, DenodoService>();
            services.AddScoped<IDocumentStoreService, DocumentStoreService>();
            services.AddScoped<IFundAppDocumentService, FundAppDocumentService>();
            services.AddScoped<IIndicatorService, IndicatorService>();
            services.AddScoped<IBudgetService, BudgetService>();
            services.AddScoped<IAdminService, AdminService>();
            services.AddScoped<IBidService, BidService>();
            services.AddScoped<IEvaluationService, EvaluationService>();

            services.AddScoped<IBankService, BankService>();
            services.AddScoped<IContactService, ContactService>();
            services.AddScoped<IProgrammeService, ProgrammeService>();
            services.AddScoped<IProgrameDeliveryService, ProgrameDeliveryService>();

            services.AddConfiguration<dtoBlobConfig>(builder.Configuration, "BlobStorageSettings");


            //PowerBI
            services.AddScoped(typeof(AadService))
                    .AddScoped(typeof(PbiEmbedService));
            services.AddScoped<IEmbeddedReportService, EmbeddedReportService>();

            #endregion

            var engine = EngineContext.Create();
            engine.ConfigureServices(services, builder.Configuration);



            //#if !DEBUG
            //	            builder.Services.Configure<dtoBlobConfig>(blobConfig =>
            //	            {
            //		            blobConfig.Storage01 = Environment.GetEnvironmentVariable("APPSETTING_Storage01");
            //	                blobConfig.FolderPath01 = Environment.GetEnvironmentVariable("APPSETTING_FolderPath01");
            //	            });
            //#endif

        }
    }
}
