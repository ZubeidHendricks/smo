using NPOMS.Domain.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Mapping
{
    public interface ISegmentCodeRepository : IBaseRepository<SegmentCode>
    {
        Task<IEnumerable<SegmentCode>> GetEntities(bool returnInactive);
    }
}
