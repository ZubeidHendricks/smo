﻿using NPOMS.Domain.Dropdown;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Dropdown
{
    public interface IFacilitySubStructureRepository :IBaseRepository<FacilitySubStructure>
    {
        Task<IEnumerable<FacilitySubStructure>> GetEntities(bool returnInactive);

    }
}
