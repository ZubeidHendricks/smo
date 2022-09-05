using NPOMS.Domain.Dropdown;
using NPOMS.Domain.Lookup;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NPOMS.Domain.Entities
{
	[Table("Resources", Schema = "dbo")]
	public class Resource : BaseEntity
	{
		public int ApplicationId { get; set; }

		public int ActivityId { get; set; }

		public int ResourceTypeId { get; set; }

		public int ServiceTypeId { get; set; }

		public int AllocationTypeId { get; set; }

		[Column(TypeName = "nvarchar(2000)")]
		public string Description { get; set; }

		public int ProvisionTypeId { get; set; }

		public int ResourceListId { get; set; }

		public int NumberOfResources { get; set; }

		public bool IsActive { get; set; }

		public int CreatedUserId { get; set; }

		public DateTime CreatedDateTime { get; set; }

		public int? UpdatedUserId { get; set; }

		public DateTime? UpdatedDateTime { get; set; }

		public bool? ChangesRequired { get; set; }

		public Activity Activity { get; set; }

		public ResourceType ResourceType { get; set; }

		public ServiceType ServiceType { get; set; }

		public AllocationType AllocationType { get; set; }

		public ProvisionType ProvisionType { get; set; }

		public ResourceList ResourceList { get; set; }
	}
}
