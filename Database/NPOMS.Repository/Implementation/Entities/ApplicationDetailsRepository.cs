using Microsoft.EntityFrameworkCore;
using NPOMS.Domain.Entities;
using NPOMS.Repository.Interfaces.Entities;
using System.Threading.Tasks;

namespace NPOMS.Repository.Implementation.Entities
{
    public class ApplicationDetailsRepository : BaseRepository<ApplicationDetail>, IApplicationDetailsRepository
    {
        public ApplicationDetailsRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {

        }
        public async Task<ApplicationDetail> GetById(int id)
        {
            var results = await FindByCondition(x => x.Id.Equals(id))
                    .Include(x => x.FundAppSDADetail).ThenInclude(dis => dis.DistrictCouncil)
                    .Include(x => x.FundAppSDADetail)
                    .ThenInclude(local => local.LocalMunicipality).FirstOrDefaultAsync();
            return results;
        }
    }

}