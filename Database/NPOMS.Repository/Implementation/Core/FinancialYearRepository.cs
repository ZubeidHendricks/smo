using Microsoft.EntityFrameworkCore;
using NPOMS.Domain.Core;
using NPOMS.Repository.Interfaces.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NPOMS.Repository.Implementation.Core
{
	public class FinancialYearRepository : BaseRepository<FinancialYear>, IFinancialYearRepository
	{
		#region Constructors

		public FinancialYearRepository(RepositoryContext repositoryContext)
			: base(repositoryContext)
		{

		}

		#endregion

		#region Methods

		public async Task<IEnumerable<FinancialYear>> GetEntities(bool returnInactive)
		{
			if (returnInactive)
			{
				return await FindAll()
								.AsNoTracking()
								.OrderBy(x => x.Name)
								.ToListAsync();
			}
			else
			{
				return await FindAll()
								.Where(x => x.IsActive)
								.AsNoTracking()
								.OrderBy(x => x.Name)
								.ToListAsync();
			}
		}

		public async Task<IEnumerable<FinancialYear>> GetFromCurrentFinancialYear()
		{
			var currentDate = DateTime.Now;
			var currentFinancialYear = await FindAll().Where(x => x.StartDate <= currentDate && x.EndDate >= currentDate && x.IsActive).AsNoTracking().OrderBy(x => x.Name).FirstOrDefaultAsync();
			return await FindByCondition(x => x.Id >= currentFinancialYear.Id).AsNoTracking().OrderBy(x => x.Name).ToListAsync();
		}

		public async Task<FinancialYear> GetById(int id)
		{
			return await FindByCondition(x => x.Id.Equals(id)).AsNoTracking().FirstOrDefaultAsync();
		}

		#endregion
	}
}
