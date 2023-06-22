using NPOMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Entities
{
    public interface IAffiliatedOrganisationInformationRepository : IBaseRepository<AffiliatedOrganisationInformation>
    {
        Task Update(List<AffiliatedOrganisationInformation> model, string userIdentifier, string npoProfileId);
        Task<IEnumerable<AffiliatedOrganisationInformation>> GetAffiliatedOrganisationByIdAsync(int npoProfileId);
    }
}
