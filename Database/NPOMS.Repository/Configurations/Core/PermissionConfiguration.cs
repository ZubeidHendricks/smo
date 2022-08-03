using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NPOMS.Domain.Core;

namespace NPOMS.Repository.Configurations.Core
{
	public class PermissionConfiguration : IEntityTypeConfiguration<Permission>
	{
		public void Configure(EntityTypeBuilder<Permission> builder)
		{
			builder.Property("IsActive").HasDefaultValueSql("1");
			builder.Property("CreatedUserId").HasDefaultValueSql("1");
			builder.Property("CreatedDateTime").HasDefaultValueSql("GetDate()");

			builder.HasData(
				new Permission
				{
					Id = 1,
					Name = "Add Users",
					SystemName = "UA.AU",
					CategoryName = "User Administration"
				},
				new Permission
				{
					Id = 2,
					Name = "View List of Users",
					SystemName = "UA.VU",
					CategoryName = "User Administration"
				},
				new Permission
				{
					Id = 3,
					Name = "Edit Users",
					SystemName = "UA.EU",
					CategoryName = "User Administration"
				},
				new Permission
				{
					Id = 4,
					Name = "Add Utilities",
					SystemName = "UM.AU",
					CategoryName = "Utilities Management"
				},
				new Permission
				{
					Id = 5,
					Name = "View List of Utilities",
					SystemName = "UM.VU",
					CategoryName = "Utilities Management"
				},
				new Permission
				{
					Id = 6,
					Name = "Edit Utilities",
					SystemName = "UM.EU",
					CategoryName = "Utilities Management"
				},
				new Permission
				{
					Id = 7,
					Name = "View List of Permissions",
					SystemName = "PM.VP",
					CategoryName = "Permission Management"
				},
				new Permission
				{
					Id = 8,
					Name = "Edit Permissions",
					SystemName = "PM.EP",
					CategoryName = "Permission Management"
				},
				new Permission
				{
					Id = 9,
					Name = "View Admin Menu",
					SystemName = "TN.VAM",
					CategoryName = "Top Navigation"
				},
				new Permission
				{
					Id = 10,
					Name = "View Organisation Profile Menu",
					SystemName = "TN.VPM",
					CategoryName = "Top Navigation"
				},
				new Permission
				{
					Id = 11,
					Name = "Add Organisation Profile",
					SystemName = "NP.ANP",
					CategoryName = "Organisation Profile"
				},
				new Permission
				{
					Id = 12,
					Name = "Edit Organisation Profile",
					SystemName = "NP.ENP",
					CategoryName = "Organisation Profile"
				},
				new Permission
				{
					Id = 13,
					Name = "View List of Organisation Profiles",
					SystemName = "NP.VNP",
					CategoryName = "Organisation Profile"
				},
				new Permission
				{
					Id = 14,
					Name = "Show Organisation Profile Action Buttons",
					SystemName = "NP.SPA",
					CategoryName = "Organisation Profile"
				},
				new Permission
				{
					Id = 15,
					Name = "Show User Administration Action Buttons",
					SystemName = "UA.SUA",
					CategoryName = "User Administration"
				},
				new Permission
				{
					Id = 16,
					Name = "View Apply For Access Menu",
					SystemName = "TN.VAAM",
					CategoryName = "Top Navigation"
				},
				new Permission
				{
					Id = 17,
					Name = "View Access Review Menu",
					SystemName = "TN.VARM",
					CategoryName = "Top Navigation"
				},
				new Permission
				{
					Id = 18,
					Name = "Add User Requests - Apply for access",
					SystemName = "UAM.AUR",
					CategoryName = "User Access Management"
				},
				new Permission
				{
					Id = 19,
					Name = "Edit User Requests - Review access requests",
					SystemName = "UAM.EUR",
					CategoryName = "User Access Management"
				},
				new Permission
				{
					Id = 20,
					Name = "View List of User Requests",
					SystemName = "UAM.VUR",
					CategoryName = "User Access Management"
				},
				new Permission
				{
					Id = 21,
					Name = "View Organisations Menu",
					SystemName = "TN.VNM",
					CategoryName = "Top Navigation"
				},
				new Permission
				{
					Id = 22,
					Name = "Add Organisation",
					SystemName = "NPO.Add",
					CategoryName = "Organisation"
				},
				new Permission
				{
					Id = 23,
					Name = "Edit Organisation",
					SystemName = "NPO.Edit",
					CategoryName = "Organisation"
				},
				new Permission
				{
					Id = 24,
					Name = "View List of Organisations",
					SystemName = "NPO.View",
					CategoryName = "Organisation"
				},
				new Permission
				{
					Id = 25,
					Name = "Show Organisation Action Buttons",
					SystemName = "NPO.SNA",
					CategoryName = "Organisation"
				},
				new Permission
				{
					Id = 26,
					Name = "View Application Period (Programme Selection) Menu",
					SystemName = "TN.VAPM",
					CategoryName = "Top Navigation"
				},
				new Permission
				{
					Id = 27,
					Name = "Add Application Period (Programme Selection)",
					SystemName = "AP.Add",
					CategoryName = "Application Period (Programme Selection)"
				},
				new Permission
				{
					Id = 28,
					Name = "Edit Application Period (Programme Selection)",
					SystemName = "AP.Edit",
					CategoryName = "Application Period (Programme Selection)"
				},
				new Permission
				{
					Id = 29,
					Name = "View List of Application Periods (Programme Selection)",
					SystemName = "AP.View",
					CategoryName = "Application Period (Programme Selection)"
				},
				new Permission
				{
					Id = 30,
					Name = "Show Application Period (Programme Selection) Action Buttons",
					SystemName = "AP.SAPA",
					CategoryName = "Application Period (Programme Selection)"
				},
				new Permission
				{
					Id = 31,
					Name = "View Captured Applications Menu",
					SystemName = "TN.VAppM",
					CategoryName = "Top Navigation"
				},
				new Permission
				{
					Id = 32,
					Name = "Add Application",
					SystemName = "App.Add",
					CategoryName = "Application"
				},
				new Permission
				{
					Id = 33,
					Name = "Edit Application",
					SystemName = "App.Edit",
					CategoryName = "Application"
				},
				new Permission
				{
					Id = 34,
					Name = "View List of Applications",
					SystemName = "App.View",
					CategoryName = "Application"
				},
				new Permission
				{
					Id = 35,
					Name = "Show Application Action Buttons",
					SystemName = "App.SAA",
					CategoryName = "Application"
				},
				new Permission
				{
					Id = 36,
					Name = "View Organisation Approval Menu",
					SystemName = "TN.VNA",
					CategoryName = "Top Navigation"
				},
				new Permission
				{
					Id = 37,
					Name = "Edit Organisation Approval",
					SystemName = "NAM.ENR",
					CategoryName = "Organisation Approval Management"
				},
				new Permission
				{
					Id = 38,
					Name = "View List of Organisations for approval requests",
					SystemName = "NAM.VNR",
					CategoryName = "Organisation Approval Management"
				},
				new Permission
				{
					Id = 39,
					Name = "Review Application",
					SystemName = "App.Review",
					CategoryName = "Application"
				},
				new Permission
				{
					Id = 40,
					Name = "Approve Application",
					SystemName = "App.Approve",
					CategoryName = "Application"
				},
				new Permission
				{
					Id = 41,
					Name = "Upload SLA Document",
					SystemName = "App.Upload",
					CategoryName = "Application"
				},
				new Permission
				{
					Id = 42,
					Name = "View Accepted SLA Application",
					SystemName = "App.VAA",
					CategoryName = "Application"
				},
				new Permission
				{
					Id = 43,
					Name = "Show Utilities Action Buttons",
					SystemName = "UM.SUA",
					CategoryName = "Utilities Management"
				},
				new Permission
				{
					Id = 44,
					Name = "View Dashboard Menu",
					SystemName = "TN.VDM",
					CategoryName = "Top Navigation"
				},
				new Permission
				{
					Id = 45,
					Name = "View PowerBI Dashboard",
					SystemName = "PBI.VD",
					CategoryName = "PowerBI Dashboard"
				},
				new Permission
				{
					Id = 46,
					Name = "View Training Menu",
					SystemName = "TN.VTM",
					CategoryName = "Top Navigation"
				},
				new Permission
				{
					Id = 47,
					Name = "View List of Training Materials",
					SystemName = "TM.VTM",
					CategoryName = "Training Material"
				}
			);
		}
	}
}
