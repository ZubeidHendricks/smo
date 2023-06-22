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
    public class AffiliatedOrganisationInformationRepository : BaseRepository<AffiliatedOrganisationInformation>, IAffiliatedOrganisationInformationRepository
    {
        public AffiliatedOrganisationInformationRepository(RepositoryContext repositoryContext)
         : base(repositoryContext)
        {

        }

        public async Task<IEnumerable<AffiliatedOrganisationInformation>> GetAffiliatedOrganisationByIdAsync(int fundingApplicationId)
        {
            return await FindByCondition(x => x.npoProfileId.Equals(fundingApplicationId)).OrderBy(x => x.CreatedDateTime).AsNoTracking().ToListAsync();
        }

        public Task Update(List<AffiliatedOrganisationInformation> model, string userIdentifier, string npoProfileId)
        {
            throw new NotImplementedException();
        }
    }
}
