using NPOMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Entities
{
    public interface ISourceOfInformationRepository : IBaseRepository<SourceOfInformation>
    {
        Task<IEnumerable<SourceOfInformation>> GetSourceOfInformationByIdAsync(int npoProfileId);
    }
}
