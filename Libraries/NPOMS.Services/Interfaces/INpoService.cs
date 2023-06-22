﻿using NPOMS.Domain.Entities;
using NPOMS.Domain.Enumerations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Services.Interfaces
{
	public interface INpoService
	{
		Task<IEnumerable<Npo>> Get(string userIdentifier, AccessStatusEnum accessStatus);

		Task<Npo> GetById(int id);

		Task<IEnumerable<Npo>> Search(string name);

		Task<IEnumerable<Npo>> SearchApprovedNpo(string name);

		Task<Npo> GetByNameAndOrgTypeId(string name, int organisationTypeId);

		Task Create(Npo npo, string userIdentifier);

		Task Update(Npo npo, string userIdentifier);

		Task UpdateNpoStatus(Npo npo, string userIdentifier);
	}
}
