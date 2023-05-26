﻿using NPOMS.Domain.Dropdown;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Dropdown
{
    public interface ISubPlaceRepository : IBaseRepository<SubPlace>
    {
        Task<IEnumerable<SubPlace>> GetEntities(bool returnInactive);
        Task<SubPlace> GetById(int id);
    }
}