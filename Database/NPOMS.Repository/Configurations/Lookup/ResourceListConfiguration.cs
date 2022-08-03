using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NPOMS.Domain.Lookup;

namespace NPOMS.Repository.Configurations.Lookup
{
	public class ResourceListConfiguration : IEntityTypeConfiguration<ResourceList>
	{
		public void Configure(EntityTypeBuilder<ResourceList> builder)
		{
			builder.Property("IsActive").HasDefaultValueSql("1");
			builder.Property("CreatedUserId").HasDefaultValueSql("1");
			builder.Property("CreatedDateTime").HasDefaultValueSql("GetDate()");

			builder.HasData(
				new ResourceList
				{
					Id = 1,
					Name = "Project Manager",
					ResourceTypeId = 1
				},
				new ResourceList
				{
					Id = 2,
					Name = "Project Coordinator",
					ResourceTypeId = 1
				},
				new ResourceList
				{
					Id = 3,
					Name = "Professional Nurse",
					ResourceTypeId = 1
				},
				new ResourceList
				{
					Id = 4,
					Name = "Staff Nurse",
					ResourceTypeId = 1
				},
				new ResourceList
				{
					Id = 5,
					Name = "Register Nurse",
					ResourceTypeId = 1
				},
				new ResourceList
				{
					Id = 6,
					Name = "Nursing Assistant",
					ResourceTypeId = 1
				},
				new ResourceList
				{
					Id = 7,
					Name = "Medical Doctor",
					ResourceTypeId = 1
				},
				new ResourceList
				{
					Id = 8,
					Name = "Research",
					ResourceTypeId = 1
				},
				new ResourceList
				{
					Id = 9,
					Name = "Facilitator",
					ResourceTypeId = 1
				},
				new ResourceList
				{
					Id = 10,
					Name = "Councillor",
					ResourceTypeId = 1
				},
				new ResourceList
				{
					Id = 11,
					Name = "Coordinator",
					ResourceTypeId = 1
				},
				new ResourceList
				{
					Id = 12,
					Name = "Social Mobilizer",
					ResourceTypeId = 1
				},
				new ResourceList
				{
					Id = 13,
					Name = "Programme Manager",
					ResourceTypeId = 1
				},
				new ResourceList
				{
					Id = 14,
					Name = "Support Officer",
					ResourceTypeId = 1
				},
				new ResourceList
				{
					Id = 15,
					Name = "Field Worker",
					ResourceTypeId = 1
				},
				new ResourceList
				{
					Id = 16,
					Name = "HR Manager",
					ResourceTypeId = 1
				},
				new ResourceList
				{
					Id = 17,
					Name = "Finance Manager",
					ResourceTypeId = 1
				},
				new ResourceList
				{
					Id = 18,
					Name = "Youth Care Worker",
					ResourceTypeId = 1
				},
				new ResourceList
				{
					Id = 19,
					Name = "Mentor",
					ResourceTypeId = 1
				},
				new ResourceList
				{
					Id = 20,
					Name = "Mentor Supervisor",
					ResourceTypeId = 1
				},
				new ResourceList
				{
					Id = 21,
					Name = "Site Administrator",
					ResourceTypeId = 1
				},
				new ResourceList
				{
					Id = 22,
					Name = "Senior Mentor",
					ResourceTypeId = 1
				},
				new ResourceList
				{
					Id = 23,
					Name = "Community Health Worker",
					ResourceTypeId = 1
				},
				new ResourceList
				{
					Id = 24,
					Name = "Pharmacy Manager",
					ResourceTypeId = 1
				},
				new ResourceList
				{
					Id = 25,
					Name = "Area Manager",
					ResourceTypeId = 1
				}
			);
		}
	}
}
