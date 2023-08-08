using NPOMS.Domain.Evaluation;
using NPOMS.Repository.Interfaces.Evaluation;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NPOMS.Repository.Implementation.Evaluation
{
	public class ResponseTypeRepository : BaseRepository<ResponseType>, IResponseTypeRepository
	{
		#region Constructors

		public ResponseTypeRepository(RepositoryContext repositoryContext)
			: base(repositoryContext)
		{

		}

		#endregion

		#region Methods

		public async Task<IEnumerable<ResponseType>> GetAllAsync(bool returnInactive)
		{
			if (returnInactive)
				return await FindAll().AsNoTracking().ToListAsync();
			else
				return await FindAll().Where(x => x.IsActive).AsNoTracking().ToListAsync();
		}

        public async Task<ResponseType> DeleteById(int id)
        {
            var model = await FindByCondition(x => x.Id.Equals(id)).FirstOrDefaultAsync();
            await DeleteAsync(model);
            return model;
        }

        #endregion
    }
}
