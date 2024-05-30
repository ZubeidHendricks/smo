using Microsoft.EntityFrameworkCore;
using NPOMS.Domain.Core;
using NPOMS.Domain.Dropdown;
using NPOMS.Repository.Interfaces.Dropdown;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NPOMS.Repository.Implementation.Dropdown
{
	public class ProgrammeRepository : BaseRepository<Programme>, IProgrammeRepository
	{
        #region Constructors
        private readonly RepositoryContext _repositoryContext;


        public ProgrammeRepository(RepositoryContext repositoryContext)
			: base(repositoryContext)
		{
            _repositoryContext = repositoryContext;
        }

		#endregion

		#region Methods

		public async Task<IEnumerable<Programme>> GetEntities(bool returnInactive)
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

		public async Task<Programme> GetById(int id)
		{
			return await FindByCondition(x => x.Id.Equals(id)).AsNoTracking().FirstOrDefaultAsync();
		}

        public async Task<IEnumerable<Programme>> GetProgramsByDepartment(string name, int id)
        {
            switch (name.ToLower())
            {
                case "all departments":

                    return await FindAll()
                                    .Where(x => x.IsActive)
                                    .AsNoTracking()
                                    .OrderBy(x => x.Name)
                                    .ToListAsync();

                case "none":
                    return Enumerable.Empty<Programme>();

                default:

                    return await FindAll()
                                    .Where(x => x.IsActive && x.DepartmentId == id)
                                    .AsNoTracking()
                                    .OrderBy(x => x.Name)
                                    .ToListAsync();
            }
        }

        public async Task<List<int>> GetProgrammesIdOfLoggenInUserAsync(int userid)
        {
            return await _repositoryContext.UserProgramMappings
                         .Where(x => x.UserId == userid)
                         .Select(x => x.ProgramId)
                         .ToListAsync();
        }
        #endregion
    }
}
