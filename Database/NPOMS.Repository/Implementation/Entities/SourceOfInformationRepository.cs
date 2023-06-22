using Microsoft.EntityFrameworkCore;
using NPOMS.Domain.Core;
using NPOMS.Domain.Entities;
using NPOMS.Repository.Interfaces;
using NPOMS.Repository.Interfaces.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Repository.Implementation.Entities
{
    public class SourceOfInformationRepository : BaseRepository<SourceOfInformation>, ISourceOfInformationRepository
    {
        public SourceOfInformationRepository(RepositoryContext repositoryContext)
          : base(repositoryContext)
        {

        }

        public async Task<IEnumerable<SourceOfInformation>> GetSourceOfInformationByIdAsync(int fundingApplicationId)
        {
            return await FindByCondition(x => x.NpoProfileId.Equals(fundingApplicationId)).OrderBy(x => x.CreatedDateTime).AsNoTracking().ToListAsync();
        }
    }
}
