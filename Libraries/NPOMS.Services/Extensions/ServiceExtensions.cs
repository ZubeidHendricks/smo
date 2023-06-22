using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using NPOMS.Repository;
using NPOMS.Repository.Implementation.Budget;
using NPOMS.Repository.Implementation.Core;
using NPOMS.Repository.Implementation.Dropdown;
using NPOMS.Repository.Implementation.Entities;
using NPOMS.Repository.Implementation.Indicator;
using NPOMS.Repository.Implementation.Lookup;
using NPOMS.Repository.Implementation.Mapping;
using NPOMS.Repository.Interfaces.Budget;
using NPOMS.Repository.Interfaces.Core;
using NPOMS.Repository.Interfaces.Dropdown;
using NPOMS.Repository.Interfaces.Entities;
using NPOMS.Repository.Interfaces.Indicator;
using NPOMS.Repository.Interfaces.Lookup;
using NPOMS.Repository.Interfaces.Mapping;
using NPOMS.Services.DenodoAPI.Implementation;
using NPOMS.Services.DenodoAPI.Interfaces;
using NPOMS.Services.Implementation;
using NPOMS.Services.Infrastructure.Implementation;
using NPOMS.Services.Interfaces;
using NPOMS.Services.Mappings;
using NPOMS.Services.PowerBI;

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
			services.AddScoped<IDocumentStoreRepository, DocumentStoreRepository>();
			services.AddScoped<IDocumentTypeRepository, DocumentTypeRepository>();
			services.AddScoped<IEmailAccountRepository, EmailAccountRepository>();
			services.AddScoped<IEmailQueueRepository, EmailQueueRepository>();
			services.AddScoped<IEmailTemplateRepository, EmailTemplateRepository>();
			services.AddScoped<IFinancialYearRepository, FinancialYearRepository>();
			services.AddScoped<IPermissionRepository, PermissionRepository>();
			services.AddScoped<IRoleRepository, RoleRepository>();
			services.AddScoped<IUserRepository, UserRepository>();
			services.AddScoped<IUtilityRepository, UtilityRepository>();
			services.AddScoped<IEmbeddedReportRepository, EmbeddedReportRepository>();

			/* Dropdown */
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
            services.AddScoped<IPreviousYearFinanceRepository, PreviousYearFinanceRepository>();
            
			services.AddScoped<IFinancialMattersIncomeRepository, FinancialMattersIncomeRepository>();
            services.AddScoped<IFinancialMattersExpenditureRepository, FinancialMattersExpenditureRepository>();
            services.AddScoped<IFinancialMattersOthersRepository, FinancialMattersOthersRepository>();




			services.AddScoped<IAffiliatedOrganisationInformationRepository, AffiliatedOrganisationInformationRepository>();
			services.AddScoped<ISourceOfInformationRepository, SourceOfInformationRepository>();	
            services.AddScoped<IFundAppRegionRepository, FundAppRegionRepository>();
            services.AddScoped<IServiceDeliveryAreaRepository, ServiceDeliveryAreaRepository>();

            services.AddScoped<IFundAppServiceDeliveryAreaRepository, FundAppServiceDeliveryAreaRepository>();
			services.AddScoped<IFinancialMattersRepository, FinancialMattersRepository>();
			services.AddScoped<IApplicationDetailsRepository,ApplicationDetailsRepository>();
			services.AddScoped<IBidRepository,BidRepository>();


			services.AddScoped<IAuditorOrAffiliationRepository, AuditorOrAffiliationRepository>();

            /* Lookup */
            services.AddScoped<IActivityListRepository, ActivityListRepository>();
			services.AddScoped<IFacilityListRepository, FacilityListRepository>();
			services.AddScoped<IResourceListRepository, ResourceListRepository>();

			/* Mapping */
			services.AddScoped<IActivitySubProgrammeRepository, ActivitySubProgrammeRepository>();
			services.AddScoped<INpoProfileFacilityListRepository, NpoProfileFacilityListRepository>();
			services.AddScoped<IObjectiveProgrammeRepository, ObjectiveProgrammeRepository>();
			services.AddScoped<IRolePermissionRepository, RolePermissionRepository>();
			services.AddScoped<IUserNpoRepository, UserNpoRepository>();
			services.AddScoped<IUserRoleRepository, UserRoleRepository>();
			services.AddScoped<IActivityFacilityListRepository, ActivityFacilityListRepository>();

            services.AddScoped<IProjectImplementationPlaceRepository, ProjectImplementationPlaceRepository>();
            services.AddScoped<IProjectImplementationSubPlaceRepository, ProjectImplementationSubPlaceRepository>();



            /* Indicator */
            services.AddScoped<IWorkplanTargetRepository, WorkplanTargetRepository>();
			services.AddScoped<IWorkplanActualRepository, WorkplanActualRepository>();
			services.AddScoped<IWorkplanCommentRepository, WorkplanCommentRepository>();
			services.AddScoped<IWorkplanActualAuditRepository, WorkplanActualAuditRepository>();

			/* Budget */
			services.AddScoped<IDepartmentBudgetRepository, DepartmentBudgetRepository>();
			services.AddScoped<IDirectorateBudgetRepository, DirectorateBudgetRepository>();
			services.AddScoped<IProgrammeBudgetRepository, ProgrammeBudgetRepository>();

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
			services.AddScoped<IIndicatorService, IndicatorService>();
			services.AddScoped<IBudgetService, BudgetService>();
			services.AddScoped<IAdminService, AdminService>();
            services.AddScoped<IBidService, BidService>();


            //PowerBI
            services.AddScoped(typeof(AadService))
					.AddScoped(typeof(PbiEmbedService));
			services.AddScoped<IEmbeddedReportService, EmbeddedReportService>();

			#endregion

			var engine = EngineContext.Create();
			engine.ConfigureServices(services, builder.Configuration);
		}
	}
}
