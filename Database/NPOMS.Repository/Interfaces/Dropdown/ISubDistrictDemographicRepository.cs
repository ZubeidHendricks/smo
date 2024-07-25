using NPOMS.Domain.Dropdown;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Dropdown
{
        public interface ISubDistrictDemographicRepository : IBaseRepository<SubDistrictDemographic>
        {
            Task<IEnumerable<SubDistrictDemographic>> GetEntities(bool returnInactive);

        }
}
