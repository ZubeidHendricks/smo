using AutoMapper;
using NPOMS.Domain.Core;
using NPOMS.Domain.Dropdown;
using NPOMS.Domain.Entities;
using NPOMS.Domain.Mapping;
using NPOMS.Services.Models;
using System.Security.Cryptography;


namespace NPOMS.Services.Mappings
{
	public class MappingConfiguration : Profile
	{
		public MappingConfiguration()
		{
			CreateMap<User, UserViewModel>()
				.ForMember(d => d.Id, op => op.MapFrom(s => s.Id))
				.ForMember(d => d.Email, op => op.MapFrom(s => s.Email))
				.ForMember(d => d.UserName, op => op.MapFrom(s => s.UserName))
				.ForMember(d => d.FirstName, op => op.MapFrom(s => s.FirstName))
				.ForMember(d => d.LastName, op => op.MapFrom(s => s.LastName))
				.ForMember(d => d.FullName, op => op.MapFrom(s => s.FullName))
				.ForMember(d => d.IsActive, op => op.MapFrom(s => s.IsActive))
				.ForMember(d => d.IsB2C, op => op.MapFrom(s => s.IsB2C))
				.ForMember(d => d.CreatedUserId, op => op.MapFrom(s => s.CreatedUserId))
				.ForMember(d => d.CreatedDateTime, op => op.MapFrom(s => s.CreatedDateTime))
				.ForMember(d => d.UpdatedUserId, op => op.MapFrom(s => s.UpdatedUserId))
				.ForMember(d => d.UpdatedDateTime, op => op.MapFrom(s => s.UpdatedDateTime))
				.ForMember(d => d.Roles, op => op.Ignore())
				.ForMember(d => d.Departments, op => op.Ignore())
                .ForMember(d => d.UserPrograms, op => op.Ignore());

            CreateMap<UserViewModel, User>()
				.ForMember(d => d.Id, op => op.MapFrom(s => s.Id))
				.ForMember(d => d.Email, op => op.MapFrom(s => s.Email))
				.ForMember(d => d.UserName, op => op.MapFrom(s => s.UserName))
				.ForMember(d => d.FirstName, op => op.MapFrom(s => s.FirstName))
				.ForMember(d => d.LastName, op => op.MapFrom(s => s.LastName))
				.ForMember(d => d.FullName, op => op.Ignore())
				.ForMember(d => d.IsActive, op => op.MapFrom(s => s.IsActive))
				.ForMember(d => d.IsB2C, op => op.MapFrom(s => s.IsB2C))
				.ForMember(d => d.Roles, op => op.Ignore())
				.ForMember(d => d.Departments, op => op.Ignore())
                .ForMember(d => d.UserPrograms, op => op.Ignore());

            CreateMap<Role, RoleViewModel>()
				.ForMember(d => d.Id, op => op.MapFrom(s => s.Id))
				.ForMember(d => d.Name, op => op.MapFrom(s => s.Name))
				.ForMember(d => d.SystemName, op => op.MapFrom(s => s.SystemName))
				.ForMember(d => d.IsActive, op => op.MapFrom(s => s.IsActive))
                .ForMember(d => d.DepartmentCode, op => op.MapFrom(s => s.DepartmentCode));

			CreateMap<RoleViewModel, Role>()
				.ForMember(d => d.Id, op => op.MapFrom(s => s.Id))
				.ForMember(d => d.Name, op => op.MapFrom(s => s.Name))
				.ForMember(d => d.SystemName, op => op.MapFrom(s => s.SystemName))
				.ForMember(d => d.IsActive, op => op.MapFrom(s => s.IsActive))
                .ForMember(d => d.DepartmentCode, op => op.MapFrom(s => s.DepartmentCode));

			CreateMap<Department, DepartmentViewModel>()
				.ForMember(d => d.Id, op => op.MapFrom(s => s.Id))
				.ForMember(d => d.Name, op => op.MapFrom(s => s.Name))
				.ForMember(d => d.Abbreviation, op => op.MapFrom(s => s.Abbreviation))
				.ForMember(d => d.IsActive, op => op.MapFrom(s => s.IsActive));

			CreateMap<DepartmentViewModel, Department>()
				.ForMember(d => d.Id, op => op.MapFrom(s => s.Id))
				.ForMember(d => d.Name, op => op.MapFrom(s => s.Name))
				.ForMember(d => d.Abbreviation, op => op.MapFrom(s => s.Abbreviation))
				.ForMember(d => d.IsActive, op => op.MapFrom(s => s.IsActive));

            CreateMap<Programme, UserProgramViewModel>()
                .ForMember(d => d.Id, op => op.MapFrom(s => s.Id))
                .ForMember(d => d.Name, op => op.MapFrom(s => s.Name))
              //  .ForMember(d => d.ProgramId, op => op.MapFrom(s => s.p))
                .ForMember(d => d.IsActive, op => op.MapFrom(s => s.IsActive));

            CreateMap<UserProgramViewModel, Programme>()
                .ForMember(d => d.Id, op => op.MapFrom(s => s.Id))
                .ForMember(d => d.Name, op => op.MapFrom(s => s.Name))
               // .ForMember(d => d.Id, op => op.MapFrom(s => s.ProgramId))
                .ForMember(d => d.IsActive, op => op.MapFrom(s => s.IsActive));

            CreateMap<Permission, PermissionViewModel>()
				.ForMember(d => d.Id, op => op.MapFrom(s => s.Id))
				.ForMember(d => d.CategoryName, op => op.MapFrom(s => s.CategoryName))
				.ForMember(d => d.IsActive, op => op.MapFrom(s => s.IsActive))
				.ForMember(d => d.Name, op => op.MapFrom(s => s.Name))
				.ForMember(d => d.Roles, op => op.Ignore())
				.ForMember(d => d.SystemName, op => op.MapFrom(s => s.SystemName));

			CreateMap<UserNpo, UserNpoViewModel>()
				.ForMember(d => d.Id, op => op.MapFrom(s => s.Id))
				.ForMember(d => d.UserId, op => op.MapFrom(s => s.UserId))
				.ForMember(d => d.NpoId, op => op.MapFrom(s => s.NpoId))
				.ForMember(d => d.AccessStatusId, op => op.MapFrom(s => s.AccessStatusId))
				.ForMember(d => d.CreatedUserId, op => op.MapFrom(s => s.CreatedUserId))
				.ForMember(d => d.CreatedDateTime, op => op.MapFrom(s => s.CreatedDateTime))
				.ForMember(d => d.UpdatedUserId, op => op.MapFrom(s => s.UpdatedUserId))
				.ForMember(d => d.UpdatedDateTime, op => op.MapFrom(s => s.UpdatedDateTime));

			CreateMap<UserNpoViewModel, UserNpo>()
				.ForMember(d => d.Id, op => op.MapFrom(s => s.Id))
				.ForMember(d => d.UserId, op => op.MapFrom(s => s.UserId))
				.ForMember(d => d.NpoId, op => op.MapFrom(s => s.NpoId))
				.ForMember(d => d.AccessStatusId, op => op.MapFrom(s => s.AccessStatusId))
				.ForMember(d => d.CreatedUserId, op => op.MapFrom(s => s.CreatedUserId))
				.ForMember(d => d.CreatedDateTime, op => op.MapFrom(s => s.CreatedDateTime))
				.ForMember(d => d.UpdatedUserId, op => op.MapFrom(s => s.UpdatedUserId))
				.ForMember(d => d.UpdatedDateTime, op => op.MapFrom(s => s.UpdatedDateTime));

			CreateMap<EmailTemplate, EmailTemplateViewModel>()
				.ForMember(d => d.Id, op => op.MapFrom(s => s.Id))
				.ForMember(d => d.Body, op => op.MapFrom(s => s.Body))
				.ForMember(d => d.Description, op => op.MapFrom(s => s.Description))
				.ForMember(d => d.EmailAccountId, op => op.MapFrom(s => s.EmailAccountId))
				.ForMember(d => d.IsActive, op => op.MapFrom(s => s.IsActive))
				.ForMember(d => d.Name, op => op.MapFrom(s => s.Name))
				.ForMember(d => d.Subject, op => op.MapFrom(s => s.Subject))
				.ForMember(d => d.EmailAccount, op => op.Ignore());

			CreateMap<EmailAccount, EmailAccountViewModel>()
			   .ForMember(d => d.Id, op => op.MapFrom(s => s.Id))
			   .ForMember(d => d.Description, op => op.MapFrom(s => s.Description))
			   .ForMember(d => d.EnableSSL, op => op.MapFrom(s => s.EnableSSL))
			   .ForMember(d => d.FromDisplayName, op => op.MapFrom(s => s.FromDisplayName))
			   .ForMember(d => d.FromEmail, op => op.MapFrom(s => s.FromEmail))
			   .ForMember(d => d.Host, op => op.MapFrom(s => s.Host))
			   .ForMember(d => d.Password, op => op.MapFrom(s => s.Password))
			   .ForMember(d => d.Port, op => op.MapFrom(s => s.Port))
			   .ForMember(d => d.UserName, op => op.MapFrom(s => s.UserName));

			CreateMap<EmailQueue, EmailQueueViewModel>()
				.ForMember(d => d.Id, op => op.MapFrom(s => s.Id))
				.ForMember(d => d.CreatedDateTime, op => op.MapFrom(s => s.CreatedDateTime))
				.ForMember(d => d.SentDateTime, op => op.MapFrom(s => s.SentDateTime))
				.ForMember(d => d.Message, op => op.MapFrom(s => s.Message))
				.ForMember(d => d.FromEmailAddress, op => op.MapFrom(s => s.FromEmailAddress))
				.ForMember(d => d.FromEmailName, op => op.MapFrom(s => s.FromEmailName))
				.ForMember(d => d.RecipientEmail, op => op.MapFrom(s => s.RecipientEmail))
				.ForMember(d => d.RecipientName, op => op.MapFrom(s => s.RecipientName))
				.ForMember(d => d.Subject, op => op.MapFrom(s => s.Subject));

			CreateMap<DocumentStore, DocumentStoreViewModel>()
				.ForMember(d => d.Id, op => op.MapFrom(s => s.Id))
				.ForMember(d => d.RefNo, op => op.MapFrom(s => s.RefNo))
				.ForMember(d => d.DocumentTypeId, op => op.MapFrom(s => s.DocumentTypeId))
				.ForMember(d => d.EntityTypeId, op => op.MapFrom(s => s.EntityTypeId))
				.ForMember(d => d.EntityId, op => op.MapFrom(s => s.EntityId))
				.ForMember(d => d.Name, op => op.MapFrom(s => s.Name))
				.ForMember(d => d.ResourceId, op => op.MapFrom(s => s.ResourceId))
				.ForMember(d => d.FileSize, op => op.MapFrom(s => s.FileSize))
				.ForMember(d => d.IsActive, op => op.MapFrom(s => s.IsActive))
				.ForMember(d => d.DocumentType, op => op.MapFrom(s => s.DocumentType));

			CreateMap<EmbeddedReport, EmbeddedReportViewModel>()
			 .ForMember(d => d.Id, op => op.MapFrom(s => s.Id))
			 .ForMember(d => d.Name, op => op.MapFrom(s => s.Name))
			 .ForMember(d => d.Description, op => op.MapFrom(s => s.Description))
			 .ForMember(d => d.ReportId, op => op.MapFrom(s => s.ReportId))
			 .ForMember(d => d.WorkspaceId, op => op.MapFrom(s => s.WorkspaceId))
			 .ForMember(d => d.CategoryName, op => op.MapFrom(s => s.CategoryName));

            CreateMap<PropertyTypeViewModel, PropertyType>()
             .ForMember(model => model.Id, op => op.Ignore())
             .ForMember(model => model.Name, op => op.MapFrom(c => c.Name))
             .ForMember(model => model.Code, op => op.MapFrom(c => c.Code))
             .ForMember(model => model.OnGeneralLevel, op => op.MapFrom(c => c.OnGeneralLevel))
             .ForMember(model => model.OnSubsidyLevel, op => op.MapFrom(c => c.OnSubsidyLevel))
             .ForMember(model => model.CanDefineName, op => op.MapFrom(c => c.CanDefineName))
             .ForMember(model => model.ValueOnGeneralLevel, op => op.MapFrom(c => c.ValueOnGeneralLevel))
             .ForMember(model => model.ValueOnSybsidyLevel, op => op.MapFrom(c => c.ValueOnSybsidyLevel))
             .ForMember(model => model.HaveBreakDown, op => op.MapFrom(c => c.HaveBreakDown))
             .ForMember(model => model.HaveRelatedProperty, op => op.MapFrom(c => c.HaveRelatedProperty))
             .ForMember(model => model.IsBusinessRule, op => op.MapFrom(c => c.IsBusinessRule))
             .ForMember(model => model.IsActive, op => op.MapFrom(c => c.IsActive))
             .ForMember(model => model.IsDeleted, op => op.MapFrom(c => c.IsDeleted))
             .ForMember(model => model.CreatedUserID, op => op.MapFrom(c => c.CreatedUserID))
             .ForMember(model => model.UpdatedUserID, op => op.MapFrom(c => c.UpdatedUserID))
             .ForMember(model => model.CreatedDateTime, op => op.MapFrom(c => c.CreatedDateTime))
             .ForMember(model => model.UpdatedDateTime, op => op.MapFrom(c => c.UpdatedDateTime))
             .ForMember(model => model.HaveFrequency, op => op.MapFrom(c => c.HaveFrequency))
             .ForMember(model => model.PropertySubTypes, op => op.MapFrom(c => c.PropertySubTypes));

            CreateMap<PropertyType, PropertyTypeViewModel>()
             .ForMember(model => model.Id, op => op.MapFrom(c => c.Id))
             .ForMember(model => model.Name, op => op.MapFrom(c => c.Name))
             .ForMember(model => model.Code, op => op.MapFrom(c => c.Code))
             .ForMember(model => model.OnGeneralLevel, op => op.MapFrom(c => c.OnGeneralLevel))
             .ForMember(model => model.OnSubsidyLevel, op => op.MapFrom(c => c.OnSubsidyLevel))
             .ForMember(model => model.CanDefineName, op => op.MapFrom(c => c.CanDefineName))
             .ForMember(model => model.ValueOnGeneralLevel, op => op.MapFrom(c => c.ValueOnGeneralLevel))
             .ForMember(model => model.ValueOnSybsidyLevel, op => op.MapFrom(c => c.ValueOnSybsidyLevel))
             .ForMember(model => model.HaveBreakDown, op => op.MapFrom(c => c.HaveBreakDown))
             .ForMember(model => model.HaveRelatedProperty, op => op.MapFrom(c => c.HaveRelatedProperty))
             .ForMember(model => model.IsBusinessRule, op => op.MapFrom(c => c.IsBusinessRule))
             .ForMember(model => model.IsActive, op => op.MapFrom(c => c.IsActive))
             .ForMember(model => model.IsDeleted, op => op.MapFrom(c => c.IsDeleted))
             .ForMember(model => model.CreatedUserID, op => op.MapFrom(c => c.CreatedUserID))
             .ForMember(model => model.UpdatedUserID, op => op.MapFrom(c => c.UpdatedUserID))
             .ForMember(model => model.CreatedDateTime, op => op.MapFrom(c => c.CreatedDateTime))
             .ForMember(model => model.UpdatedDateTime, op => op.MapFrom(c => c.UpdatedDateTime))
             .ForMember(model => model.HaveFrequency, op => op.MapFrom(c => c.HaveFrequency))
             .ForMember(model => model.PropertySubTypes, op => op.MapFrom(c => c.PropertySubTypes));

            /*********************************BID PRofiling*****************************/


            CreateMap<FinancialYear, FinYearViewModel>()
          .ForMember(model => model.ID, op => op.MapFrom(c => c.Id))
          .ForMember(model => model.Name, op => op.MapFrom(c => c.Name))
          .ForMember(model => model.Next, op => op.Ignore());


            CreateMap<FundingApplicationDetail, FundAppDetailViewModel>()
            .ForMember(model => model.Id, op => op.MapFrom(c => c.Id))
            .ForMember(model => model.ApplicationPeriodId, op => op.MapFrom(c => c.ApplicationPeriodId))
            .ForMember(model => model.ApplicationPeriodName, op => op.MapFrom(c => c.ApplicationPeriod.Name))
            .ForMember(model => model.ApplicationDetails, op => op.MapFrom(c => c.ApplicationDetails))
            .ForMember(model => model.ApplicationId, op => op.MapFrom(c => c.ApplicationId)).ReverseMap();

            CreateMap<ProjectInformation, ProjectInformationViewModel>()
            .ForMember(model => model.Id, op => op.MapFrom(c => c.Id))
            //.ForMember(model => model.InitiatedQuestion, op => op.MapFrom(c => c.InitiatedQuestion))
            //.ForMember(model => model.considerQuestion, op => op.MapFrom(c => c.considerQuestion))
            .ForMember(model => model.purposeQuestion, op => op.MapFrom(c => c.purposeQuestion));

            CreateMap<ProjectInformationViewModel, ProjectInformation>()
            .ForMember(model => model.Id, op => op.MapFrom(c => c.Id))
            //.ForMember(model => model.InitiatedQuestion, op => op.MapFrom(c => c.InitiatedQuestion))
           // .ForMember(model => model.considerQuestion, op => op.MapFrom(c => c.considerQuestion))
            .ForMember(model => model.purposeQuestion, op => op.MapFrom(c => c.purposeQuestion));

            CreateMap<MonitoringEvaluation, MonitoringEvaluationViewModel>()
            .ForMember(model => model.Id, op => op.MapFrom(c => c.Id))
            .ForMember(model => model.MonEvalDescription, op => op.MapFrom(c => c.MonEvalDescription));

            CreateMap<MonitoringEvaluationViewModel, MonitoringEvaluation>()
            .ForMember(model => model.Id, op => op.MapFrom(c => c.Id))
           .ForMember(model => model.MonEvalDescription, op => op.MapFrom(c => c.MonEvalDescription));

            CreateMap<ApplicationDetail, ApplicationDetailViewModel>()
            .ForMember(model => model.Id, op => op.MapFrom(c => c.Id))
            .ForMember(model => model.FundAppSDADetailId, op => op.MapFrom(c => c.FundAppSDADetailId))
            .ForMember(model => model.AmountApplyingFor, op => op.MapFrom(c => c.AmountApplyingFor));

            CreateMap<FinancialMattersViewModel, FinancialMatters>()
            .ForMember(model => model.Id, op => op.Ignore())
            //.ForMember(model => model.PropertyId, op => op.MapFrom(c => c.PropertyId))
            .ForMember(model => model.Property, op => op.MapFrom(c => c.Property))
            //.ForMember(model => model.SubPropertyId, op => op.MapFrom(c => c.SubPropertyId))
            //.ForMember(model => model.SubProperty, op => op.MapFrom(c => c.SubProperty))
           // .ForMember(model => model.Type, op => op.MapFrom(c => c.Type))
            .ForMember(model => model.AmountOne, op => op.MapFrom(c => c.AmountOne))
            .ForMember(model => model.AmountTwo, op => op.MapFrom(c => c.AmountTwo))
            .ForMember(model => model.AmountThree, op => op.MapFrom(c => c.AmountThree))
            .ForMember(model => model.TotalFundingAmount, op => op.MapFrom(c => c.TotalFundingAmount))

            .ForMember(model => model.FundingApplicationDetailId, op => op.MapFrom(c => c.FundingApplicationDetailId));

            CreateMap<FinancialMatters, FinancialMattersViewModel>()
            .ForMember(model => model.Id, op => op.MapFrom(c => c.Id))
            //.ForMember(model => model.PropertyId, op => op.MapFrom(c => c.PropertyId))
            .ForMember(model => model.Property, op => op.MapFrom(c => c.Property))
           // .ForMember(model => model.SubPropertyId, op => op.MapFrom(c => c.SubPropertyId))
           // .ForMember(model => model.SubProperty, op => op.MapFrom(c => c.SubProperty))
            //.ForMember(model => model.Type, op => op.MapFrom(c => c.Type))
            .ForMember(model => model.AmountOne, op => op.MapFrom(c => c.AmountOne))
            .ForMember(model => model.AmountTwo, op => op.MapFrom(c => c.AmountTwo))
            .ForMember(model => model.AmountThree, op => op.MapFrom(c => c.AmountThree))
            .ForMember(model => model.TotalFundingAmount, op => op.MapFrom(c => c.TotalFundingAmount))
            .ForMember(model => model.FundingApplicationDetailId, op => op.MapFrom(c => c.FundingApplicationDetailId));

            CreateMap<PropertySubType, PropertySubTypeViewModel>()
            .ForMember(model => model.Id, op => op.MapFrom(c => c.Id))
            .ForMember(model => model.PropertyTypeID, op => op.MapFrom(c => c.PropertyTypeID))
            .ForMember(model => model.Name, op => op.MapFrom(c => c.Name))
            .ForMember(model => model.HaveComment, op => op.MapFrom(c => c.HaveComment))
            .ForMember(model => model.Repeatable, op => op.MapFrom(c => c.Repeatable))
            .ForMember(model => model.Frequency, op => op.MapFrom(c => c.Frequency))
            .ForMember(model => model.IsActive, op => op.MapFrom(c => c.IsActive))
            .ForMember(model => model.IsDeleted, op => op.MapFrom(c => c.IsDeleted))
            .ForMember(model => model.CreatedUserID, op => op.MapFrom(c => c.CreatedUserID))
            .ForMember(model => model.UpdatedUserID, op => op.MapFrom(c => c.UpdatedUserID))
            .ForMember(model => model.CreatedDateTime, op => op.MapFrom(c => c.CreatedDateTime))
            .ForMember(model => model.UpdatedDateTime, op => op.MapFrom(c => c.UpdatedDateTime));


            CreateMap<PropertySubTypeViewModel, PropertySubType>()
            .ForMember(model => model.Id, op => op.Ignore())
            .ForMember(model => model.PropertyTypeID, op => op.MapFrom(c => c.PropertyTypeID))
            .ForMember(model => model.Name, op => op.MapFrom(c => c.Name))
            .ForMember(model => model.HaveComment, op => op.MapFrom(c => c.HaveComment))
            .ForMember(model => model.Repeatable, op => op.MapFrom(c => c.Repeatable))
            .ForMember(model => model.Frequency, op => op.MapFrom(c => c.Frequency))
            .ForMember(model => model.IsActive, op => op.MapFrom(c => c.IsActive))
            .ForMember(model => model.IsDeleted, op => op.MapFrom(c => c.IsDeleted))
            .ForMember(model => model.CreatedUserID, op => op.MapFrom(c => c.CreatedUserID))
            .ForMember(model => model.UpdatedUserID, op => op.MapFrom(c => c.UpdatedUserID))
            .ForMember(model => model.CreatedDateTime, op => op.MapFrom(c => c.CreatedDateTime))
            .ForMember(model => model.UpdatedDateTime, op => op.MapFrom(c => c.UpdatedDateTime));


            CreateMap<PropertyTypeViewModel, PropertyType>()
             .ForMember(model => model.Id, op => op.Ignore())
             .ForMember(model => model.Name, op => op.MapFrom(c => c.Name))
             .ForMember(model => model.Code, op => op.MapFrom(c => c.Code))
             .ForMember(model => model.OnGeneralLevel, op => op.MapFrom(c => c.OnGeneralLevel))
             .ForMember(model => model.OnSubsidyLevel, op => op.MapFrom(c => c.OnSubsidyLevel))
             .ForMember(model => model.CanDefineName, op => op.MapFrom(c => c.CanDefineName))
             .ForMember(model => model.ValueOnGeneralLevel, op => op.MapFrom(c => c.ValueOnGeneralLevel))
             .ForMember(model => model.ValueOnSybsidyLevel, op => op.MapFrom(c => c.ValueOnSybsidyLevel))
             .ForMember(model => model.HaveBreakDown, op => op.MapFrom(c => c.HaveBreakDown))
             .ForMember(model => model.HaveRelatedProperty, op => op.MapFrom(c => c.HaveRelatedProperty))
             .ForMember(model => model.IsBusinessRule, op => op.MapFrom(c => c.IsBusinessRule))
             .ForMember(model => model.IsActive, op => op.MapFrom(c => c.IsActive))
             .ForMember(model => model.IsDeleted, op => op.MapFrom(c => c.IsDeleted))
             .ForMember(model => model.CreatedUserID, op => op.MapFrom(c => c.CreatedUserID))
             .ForMember(model => model.UpdatedUserID, op => op.MapFrom(c => c.UpdatedUserID))
             .ForMember(model => model.CreatedDateTime, op => op.MapFrom(c => c.CreatedDateTime))
             .ForMember(model => model.UpdatedDateTime, op => op.MapFrom(c => c.UpdatedDateTime))
             .ForMember(model => model.HaveFrequency, op => op.MapFrom(c => c.HaveFrequency))
             .ForMember(model => model.PropertySubTypes, op => op.MapFrom(c => c.PropertySubTypes));

            CreateMap<PropertyType, PropertyTypeViewModel>()
             .ForMember(model => model.Id, op => op.MapFrom(c => c.Id))
             .ForMember(model => model.Name, op => op.MapFrom(c => c.Name))
             .ForMember(model => model.Code, op => op.MapFrom(c => c.Code))
             .ForMember(model => model.OnGeneralLevel, op => op.MapFrom(c => c.OnGeneralLevel))
             .ForMember(model => model.OnSubsidyLevel, op => op.MapFrom(c => c.OnSubsidyLevel))
             .ForMember(model => model.CanDefineName, op => op.MapFrom(c => c.CanDefineName))
             .ForMember(model => model.ValueOnGeneralLevel, op => op.MapFrom(c => c.ValueOnGeneralLevel))
             .ForMember(model => model.ValueOnSybsidyLevel, op => op.MapFrom(c => c.ValueOnSybsidyLevel))
             .ForMember(model => model.HaveBreakDown, op => op.MapFrom(c => c.HaveBreakDown))
             .ForMember(model => model.HaveRelatedProperty, op => op.MapFrom(c => c.HaveRelatedProperty))
             .ForMember(model => model.IsBusinessRule, op => op.MapFrom(c => c.IsBusinessRule))
             .ForMember(model => model.IsActive, op => op.MapFrom(c => c.IsActive))
             .ForMember(model => model.IsDeleted, op => op.MapFrom(c => c.IsDeleted))
             .ForMember(model => model.CreatedUserID, op => op.MapFrom(c => c.CreatedUserID))
             .ForMember(model => model.UpdatedUserID, op => op.MapFrom(c => c.UpdatedUserID))
             .ForMember(model => model.CreatedDateTime, op => op.MapFrom(c => c.CreatedDateTime))
             .ForMember(model => model.UpdatedDateTime, op => op.MapFrom(c => c.UpdatedDateTime))
             .ForMember(model => model.HaveFrequency, op => op.MapFrom(c => c.HaveFrequency))
             .ForMember(model => model.PropertySubTypes, op => op.MapFrom(c => c.PropertySubTypes));



            CreateMap<ProjectImplementation, ProjectImplementationViewModel>()
           .ForMember(model => model.ID, op => op.MapFrom(c => c.Id))
           .ForMember(model => model.TimeframeFrom, op => op.MapFrom(c => c.TimeframeFrom))
           .ForMember(model => model.TimeframeTo, op => op.MapFrom(c => c.TimeframeTo))
           .ForMember(model => model.Results, op => op.MapFrom(c => c.Results))
           .ForMember(model => model.Resources, op => op.MapFrom(c => c.Resources))
            .ForMember(model => model.Places, op => op.MapFrom(c => c.ImplementationPlaces))
           .ForMember(model => model.SubPlaces, op => op.MapFrom(c => c.ImplementationSubPlaces))
           .ForMember(model => model.Budget, op => op.MapFrom(c => c.BudgetAmount))
           .ForMember(model => model.FundingApplicationDetailId, op => op.MapFrom(c => c.FundingApplicationDetailId));


            CreateMap<ProjectImplementationViewModel, ProjectImplementation>()
               .ForMember(model => model.Id, op => op.MapFrom(c => c.ID))
               .ForMember(model => model.BudgetAmount, op => op.MapFrom(c => c.Budget))
               .ForMember(model => model.FundingApplicationDetailId, op => op.MapFrom(c => c.FundingApplicationDetailId))
               .ForMember(model => model.TimeframeFrom, op => op.MapFrom(c => c.TimeframeFrom))
               .ForMember(model => model.TimeframeTo, op => op.MapFrom(c => c.TimeframeTo))
               .ForMember(model => model.Results, op => op.MapFrom(c => c.Results))
               .ForMember(model => model.Resources, op => op.MapFrom(c => c.Resources));


            CreateMap<FundAppSDADetail, FundAppSDADetailViewModel>()
            .ForMember(model => model.Id, op => op.MapFrom(c => c.Id))
            .ForMember(model => model.DistrictCouncilId, op => op.MapFrom(c => c.DistrictCouncilId))
           .ForMember(model => model.LocalMunicipalityId, op => op.MapFrom(c => c.LocalMunicipalityId))
           .ForMember(model => model.Regions, op => op.MapFrom(c => c.Regions))
           .ForMember(model => model.ServiceDeliveryAreas, op => op.MapFrom(c => c.ServiceDeliveryAreas));


            CreateMap<FundAppServiceDeliveryArea, ServiceDeliveryAreaViewModel>()
                .ForMember(model => model.ID, op => op.MapFrom(c => c.ServiceDeliveryArea.Id))
                .ForMember(model => model.Name, op => op.MapFrom(c => c.ServiceDeliveryArea.Name))
                .ForMember(model => model.RegionId, op => op.MapFrom(c => c.ServiceDeliveryArea.RegionId));

            CreateMap<FundAppSDADetail_Region, RegionViewModel>()
                .ForMember(model => model.ID, op => op.MapFrom(c => c.Region.Id))
                .ForMember(model => model.Name, op => op.MapFrom(c => c.Region.Name))
                .ForMember(model => model.localMunicipalityId, op => op.MapFrom(c => c.Region.LocalMunicipalityId));

            // create mapping for district council

            CreateMap<DistrictCouncil, DistrictCouncilViewModel>()
                .ForMember(model => model.Id, op => op.MapFrom(c => c.Id))
                .ForMember(model => model.Name, op => op.MapFrom(c => c.Name));

            // create mapping for local municipality

            CreateMap<LocalMunicipality, LocalMunicipalityViewModel>()
                .ForMember(model => model.ID, op => op.MapFrom(c => c.Id))
                .ForMember(model => model.ParentId, op => op.MapFrom(c => c.DistrictCouncilId))
                .ForMember(model => model.Name, op => op.MapFrom(c => c.Name));


            CreateMap<Place, PlaceViewModel>()
              .ForMember(model => model.Id, op => op.MapFrom(c => c.Id))
              .ForMember(model => model.Name, op => op.MapFrom(c => c.Name));

            CreateMap<SubPlace, SubPlaceViewModel>()
          .ForMember(model => model.Id, op => op.MapFrom(c => c.Id))
          .ForMember(model => model.PlaceId, op => op.MapFrom(c => c.PlaceId))
          .ForMember(model => model.Name, op => op.MapFrom(c => c.Name));



            CreateMap<ProjectImplementationPlace, ImplementationPlaceViewModel>()
            .ForMember(model => model.Id, op => op.MapFrom(c => c.PlaceId))
            .ForMember(model => model.ServiceDeliveryAreaId, op => op.MapFrom(c => c.Place.ServiceDeliveryAreaId))
            .ForMember(model => model.ImplementationId, op => op.MapFrom(c => c.Implementation.Id))
            .ForMember(model => model.PlaceId, op => op.MapFrom(c => c.PlaceId));

            CreateMap<ProjectImplementationSubPlace, ImplemetationSubPlaceViewModel>()
               .ForMember(model => model.Id, op => op.MapFrom(c => c.SubPlaceId))
               .ForMember(model => model.ImplementationId, op => op.MapFrom(c => c.Implementation.Id))
               .ForMember(model => model.PlaceId, op => op.MapFrom(op => op.SubPlace.PlaceId))
              .ForMember(model => model.SubPlaceId, op => op.MapFrom(c => c.SubPlaceId));



            /**************************************************END OF BID PROFILE**************************************/
        }
    }
}