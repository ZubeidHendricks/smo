using System;
using System.Collections.Generic;

namespace NPOMS.Services.Models
{
	public class UserViewModel
    {
        public UserViewModel()
        {
            this.Roles = this.Roles ?? new List<RoleViewModel>();
            this.Departments = this.Departments ?? new List<DepartmentViewModel>();
            this.UserPrograms = this.UserPrograms ?? new List<UserProgramViewModel>();
            this.Permissions = this.Permissions ?? new List<PermissionViewModel>();
            this.UserNpos = this.UserNpos ?? new List<UserNpoViewModel>();
        }

		public int Id { get; set; }

		public string Email { get; set; }

		public string UserName { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }

		public string FullName { get; set; }

		public bool IsActive { get; set; }

		public bool IsB2C { get; set; }

		public int CreatedUserId { get; set; }

		public DateTime CreatedDateTime { get; set; }

		public int UpdatedUserId { get; set; }

		public DateTime UpdatedDateTime { get; set; }

		public List<RoleViewModel> Roles { get; set; }

		public List<DepartmentViewModel> Departments { get; set; }
        public List<UserProgramViewModel> UserPrograms { get; set; }

        public List<PermissionViewModel> Permissions { get; set; }

		public List<UserNpoViewModel> UserNpos { get; set; }
	}
}
