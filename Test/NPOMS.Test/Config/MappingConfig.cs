using AutoMapper;
using NPOMS.Domain.Core;
using NPOMS.Domain.Mapping;
using NPOMS.Services.Models;

namespace NPOMS.Tests.Config
{
	public class MappingConfig : Profile
    {
        public MappingConfig()
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
				.ForMember(d => d.Departments, op => op.Ignore());

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
				.ForMember(d => d.Departments, op => op.Ignore());

			CreateMap<Role, RoleViewModel>()
				.ForMember(d => d.Id, op => op.MapFrom(s => s.Id))
				.ForMember(d => d.Name, op => op.MapFrom(s => s.Name))
				.ForMember(d => d.SystemName, op => op.MapFrom(s => s.SystemName))
				.ForMember(d => d.IsActive, op => op.MapFrom(s => s.IsActive));

			CreateMap<RoleViewModel, Role>()
				.ForMember(d => d.Id, op => op.MapFrom(s => s.Id))
				.ForMember(d => d.Name, op => op.MapFrom(s => s.Name))
				.ForMember(d => d.SystemName, op => op.MapFrom(s => s.SystemName))
				.ForMember(d => d.IsActive, op => op.MapFrom(s => s.IsActive));

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
		}
    }

    public static class MapperConfig
    {
        public static IMapper GetMapper()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<MappingConfig>());
            return config.CreateMapper();
        }
    }
}
