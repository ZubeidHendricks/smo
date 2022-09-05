using NPOMS.Domain.Core;
using NPOMS.Domain.Entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NPOMS.Domain.Mapping
{
	[Table("Users_Npos", Schema = "mapping")]
	public class UserNpo : BaseEntity
	{
		public int UserId { get; set; }

		public int NpoId { get; set; }

		public int AccessStatusId { get; set; }

		public int CreatedUserId { get; set; }

		public DateTime CreatedDateTime { get; set; }

		public int? UpdatedUserId { get; set; }

		public DateTime? UpdatedDateTime { get; set; }

		//[NotMapped]
		public Npo Npo { get; set; }

		public AccessStatus AccessStatus { get; set; }

		public User CreatedUser { get; set; }

		public User UpdatedUser { get; set; }

		/// <summary>
		/// This is the user that will receive the access
		/// </summary>
		//[NotMapped]
		public User User { get; set; }
	}
}
