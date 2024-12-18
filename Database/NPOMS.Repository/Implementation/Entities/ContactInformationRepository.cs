﻿using Microsoft.EntityFrameworkCore;
using NPOMS.Domain.Entities;
using NPOMS.Repository.Interfaces.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Repository.Implementation.Entities
{
	public class ContactInformationRepository : BaseRepository<ContactInformation>, IContactInformationRepository
	{
		#region Constructors

		public ContactInformationRepository(RepositoryContext repositoryContext)
			: base(repositoryContext)
		{

		}

		#endregion

		#region Methods

		public async Task<IEnumerable<ContactInformation>> GetByNpoId(int NpoId)
		{
			return await FindByCondition(x => x.NpoId.Equals(NpoId) && x.IsActive)
							.Include(x => x.Title)
							.Include(x => x.Position)
							.Include(x => x.Gender)
							.Include(x => x.Race)
							.Include(x => x.Language)
							.AsNoTracking()
							.ToListAsync();
		}

		public async Task DeleteEntity(int id, Npo model, int currentUserId)
		{
			var existingEntity = await FindByCondition(x => x.Id.Equals(id)).AsNoTracking().FirstOrDefaultAsync();
			existingEntity.IsActive = false;
			existingEntity.UpdatedUserId = currentUserId;
			existingEntity.UpdatedDateTime = DateTime.Now;

			var oldEntity = await this.RepositoryContext.ContactInformation.FindAsync(id);
			await UpdateAsync(oldEntity, existingEntity, true, currentUserId);
		}

		public Task<ContactInformation> GetByFundingApplicationIdAsync(int fundingApplicationId)
		{
			throw new NotImplementedException();
		}

		#endregion
	}
}
