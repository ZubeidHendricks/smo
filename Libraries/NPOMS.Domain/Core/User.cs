using NPOMS.Domain.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NPOMS.Domain.Core
{
	[Table("Users", Schema = "core")]
	public class User : BaseEntity
	{
		[Required]
		[Column(TypeName = "nvarchar(255)")]
		public string Email { get; set; }

		[Required]
		[Column(TypeName = "nvarchar(255)")]
		public string UserName { get; set; }

		[Required]
		[Column(TypeName = "nvarchar(255)")]
		public string FirstName { get; set; }

		[Required]
		[Column(TypeName = "nvarchar(255)")]
		public string LastName { get; set; }

		[Column(TypeName = "nvarchar(500)")]
		public string FullName { get { return $"{FirstName} {LastName}"; } }

		public bool IsActive { get; set; }

		public bool IsB2C { get; set; }

		public int CreatedUserId { get; set; }

		public DateTime CreatedDateTime { get; set; }

		public int? UpdatedUserId { get; set; }

		public DateTime? UpdatedDateTime { get; set; }

		public List<UserDepartment> Departments { get; set; } = new List<UserDepartment>();
        public List<UserProgramMapping> UserPrograms { get; set; } = new List<UserProgramMapping>();
        public List<UserRole> Roles { get; set; } = new List<UserRole>();
	}
}
