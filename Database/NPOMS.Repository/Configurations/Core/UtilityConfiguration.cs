using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NPOMS.Domain.Core;

namespace NPOMS.Repository.Configurations.Core
{
	public class UtilityConfiguration : IEntityTypeConfiguration<Utility>
	{
		public void Configure(EntityTypeBuilder<Utility> builder)
		{
			builder.Property("IsActive").HasDefaultValueSql("1");
			builder.Property("CreatedUserId").HasDefaultValueSql("1");
			builder.Property("CreatedDateTime").HasDefaultValueSql("GetDate()");

			builder.HasData(
				new Utility
				{
					Id = 1,
					Name = "Department",
					Description = "Add and/or Update departments",
					AngularRedirectUrl = "utilities/department",
					SystemAdminUtility = true
				},
				new Utility
				{
					Id = 2,
					Name = "Document Type",
					Description = "Add and/or Update document types",
					AngularRedirectUrl = "utilities/document-type",
					SystemAdminUtility = false
				},
				new Utility
				{
					Id = 3,
					Name = "Email Account",
					Description = "Add and/or Update email accounts",
					AngularRedirectUrl = "utilities/email-account",
					SystemAdminUtility = true
				},
				new Utility
				{
					Id = 4,
					Name = "Financial Year",
					Description = "Add and/or Update financial years",
					AngularRedirectUrl = "utilities/financial-year",
					SystemAdminUtility = true
				},
				new Utility
				{
					Id = 5,
					Name = "Role",
					Description = "Add and/or Update roles",
					AngularRedirectUrl = "utilities/role",
					SystemAdminUtility = true
				},
				new Utility
				{
					Id = 6,
					Name = "Access Status",
					Description = "Add and/or Update access statuses",
					AngularRedirectUrl = "utilities/access-status",
					SystemAdminUtility = true
				},
				new Utility
				{
					Id = 7,
					Name = "Status",
					Description = "Add and/or Update statuses",
					AngularRedirectUrl = "utilities/status",
					SystemAdminUtility = true
				},
				new Utility
				{
					Id = 8,
					Name = "Activity Type",
					Description = "Add and/or Update activity types",
					AngularRedirectUrl = "utilities/activity-type",
					SystemAdminUtility = false
				},
				new Utility
				{
					Id = 9,
					Name = "Allocation Type",
					Description = "Add and/or Update allocation types",
					AngularRedirectUrl = "utilities/allocation-type",
					SystemAdminUtility = false
				},
				new Utility
				{
					Id = 10,
					Name = "Application Type",
					Description = "Add and/or Update application types",
					AngularRedirectUrl = "utilities/application-type",
					SystemAdminUtility = true
				},
				new Utility
				{
					Id = 11,
					Name = "Facility Class",
					Description = "Add and/or Update facility classes",
					AngularRedirectUrl = "utilities/facility-class",
					SystemAdminUtility = false
				},
				new Utility
				{
					Id = 12,
					Name = "Facility District",
					Description = "Add and/or Update facility districts",
					AngularRedirectUrl = "utilities/facility-district",
					SystemAdminUtility = false
				},
				new Utility
				{
					Id = 13,
					Name = "Facility Sub-District",
					Description = "Add and/or Update facility sub-districts",
					AngularRedirectUrl = "utilities/facility-sub-district",
					SystemAdminUtility = false
				},
				new Utility
				{
					Id = 14,
					Name = "Facility Type",
					Description = "Add and/or Update facility types",
					AngularRedirectUrl = "utilities/facility-type",
					SystemAdminUtility = true
				},
				new Utility
				{
					Id = 15,
					Name = "Organisation Type",
					Description = "Add and/or Update organisation types",
					AngularRedirectUrl = "utilities/organisation-type",
					SystemAdminUtility = false
				},
				new Utility
				{
					Id = 16,
					Name = "Position",
					Description = "Add and/or Update positions",
					AngularRedirectUrl = "utilities/position",
					SystemAdminUtility = false
				},
				new Utility
				{
					Id = 17,
					Name = "Programme",
					Description = "Add and/or Update programmes",
					AngularRedirectUrl = "utilities/programme",
					SystemAdminUtility = false
				},
				new Utility
				{
					Id = 18,
					Name = "Provision Type",
					Description = "Add and/or Update provision types",
					AngularRedirectUrl = "utilities/provision-type",
					SystemAdminUtility = false
				},
				new Utility
				{
					Id = 19,
					Name = "Recipient Type",
					Description = "Add and/or Update recipient types",
					AngularRedirectUrl = "utilities/recipient-type",
					SystemAdminUtility = false
				},
				new Utility
				{
					Id = 20,
					Name = "Resource Type",
					Description = "Add and/or Update resource types",
					AngularRedirectUrl = "utilities/resource-type",
					SystemAdminUtility = false
				},
				new Utility
				{
					Id = 21,
					Name = "Service Type",
					Description = "Add and/or Update service types",
					AngularRedirectUrl = "utilities/service-type",
					SystemAdminUtility = false
				},
				new Utility
				{
					Id = 22,
					Name = "Sub-Programme",
					Description = "Add and/or Update sub-programmes",
					AngularRedirectUrl = "utilities/sub-programme",
					SystemAdminUtility = false
				},
				new Utility
				{
					Id = 23,
					Name = "Title",
					Description = "Add and/or Update titles",
					AngularRedirectUrl = "utilities/title",
					SystemAdminUtility = false
				},
				new Utility
				{
					Id = 24,
					Name = "Utility Management",
					Description = "Add and/or Update utility management",
					AngularRedirectUrl = "utilities/management",
					SystemAdminUtility = true
				},
				new Utility
				{
					Id = 25,
					Name = "Sub-Programme Type",
					Description = "Add and/or Update sub-programme types",
					AngularRedirectUrl = "utilities/sub-programme-type",
					SystemAdminUtility = false
				},
				new Utility
				{
					Id = 65,
					Name = "Directorate",
					Description = "Add and/or Update directorates",
					AngularRedirectUrl = "utilities/directorate",
					SystemAdminUtility = false
				}
			);
		}
	}
}
