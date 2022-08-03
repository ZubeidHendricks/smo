using System;

namespace NPOMS.Services.Models
{
	public class UserNpoViewModel
	{
		public int Id { get; set; }

		public int UserId { get; set; }

		public int NpoId { get; set; }

		public int AccessStatusId { get; set; }

		public int CreatedUserId { get; set; }

		public DateTime CreatedDateTime { get; set; }

		public int? UpdatedUserId { get; set; }

		public DateTime? UpdatedDateTime { get; set; }
	}
}
