using Microsoft.EntityFrameworkCore;
using NPOMS.Domain.Mapping;
using NPOMS.Repository.Interfaces.Mapping;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Repository.Implementation.Mapping
{
	public class ObjectiveProgrammeRepository : BaseRepository<ObjectiveProgramme>, IObjectiveProgrammeRepository
	{
		#region Constructors

		public ObjectiveProgrammeRepository(RepositoryContext repositoryContext)
			: base(repositoryContext)
		{

		}

		#endregion

		#region Methods

		public async Task<ObjectiveProgramme> GetByModel(ObjectiveProgramme model)
		{
			return await FindByCondition(x => x.ObjectiveId.Equals(model.ObjectiveId) &&
											  x.ProgrammeId.Equals(model.ProgrammeId) &&
											  x.SubProgrammeId.Equals(model.SubProgrammeId))
								.FirstOrDefaultAsync();
		}

		public async Task<IEnumerable<ObjectiveProgramme>> GetByObjectiveId(int objectiveId)
		{
			return await FindByCondition(x => x.ObjectiveId.Equals(objectiveId)).AsNoTracking().ToListAsync();
		}

		public async Task DeleteEntity(int objectiveId)
		{
			var mappings = await FindByCondition(x => x.ObjectiveId.Equals(objectiveId)).AsNoTracking().ToListAsync();

			foreach (var mapping in mappings)
			{
				await DeleteAsync(mapping);
			}
		}

		#endregion
	}
}
