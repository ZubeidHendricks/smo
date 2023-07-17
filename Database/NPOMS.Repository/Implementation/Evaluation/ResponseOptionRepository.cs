using NPOMS.Domain.Evaluation;
using NPOMS.Repository.Interfaces.Evaluation;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NPOMS.Repository.Implementation.Evaluation
{
	public class ResponseOptionRepository : BaseRepository<ResponseOption>, IResponseOptionRepository
	{
		#region Constructors

		public ResponseOptionRepository(RepositoryContext repositoryContext)
			: base(repositoryContext)
		{

		}

		#endregion

		#region Methods

		public async Task<IEnumerable<ResponseOption>> GetAllAsync(bool returnInactive)
		{
			if (returnInactive)
				return await FindAll().AsNoTracking().ToListAsync();
			else
				return await FindAll().Where(x => x.IsActive).AsNoTracking().ToListAsync();
		}

		#endregion
	}
}
