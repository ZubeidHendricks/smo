using Microsoft.EntityFrameworkCore;
using NPOMS.Domain.Dropdown;
using NPOMS.Repository.Interfaces.Dropdown;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NPOMS.Repository.Implementation.Dropdown
{
	public class SubProgrammeRepository : BaseRepository<SubProgramme>, ISubProgrammeRepository
	{
		#region Constructors

		public SubProgrammeRepository(RepositoryContext repositoryContext)
			: base(repositoryContext)
		{

		}

		#endregion

		#region Methods

		public async Task<IEnumerable<SubProgramme>> GetEntities(bool returnInactive)
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

		public async Task<IEnumerable<SubProgramme>> GetByProgrammeId(int programmeId)
		{
			return await FindByCondition(x => x.ProgrammeId.Equals(programmeId) && x.IsActive).AsNoTracking().ToListAsync();
		}

		#endregion
	}
}
