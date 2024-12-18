﻿using NPOMS.Domain.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Core
{
	public interface IRoleRepository : IBaseRepository<Role>
	{
		Task<IEnumerable<Role>> GetEntities(bool returnInactive);

		IEnumerable<Role> GetRoles();
        Task<IEnumerable<Role>> GetRolesByDepartment(string name, List<int> roleIds);
        Task<IEnumerable<Role>> GetRoleIdsByDepartmentIdsAsync(List<int> departmentIds);
    }
}
