﻿using Microsoft.EntityFrameworkCore;
using NPOMS.Domain.Dropdown;
using NPOMS.Repository.Interfaces.Dropdown;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Repository.Implementation.Dropdown
{
    public class PropertySubTypeRepository : BaseRepository<PropertySubType>, IPropertySubTypeRepository
    {
        #region Constructors

        public PropertySubTypeRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {

        }

        #endregion

        #region Methods

        public async Task<IEnumerable<PropertySubType>> GetEntities(bool returnInactive)
        {
            if (returnInactive)
            {
                return await FindAll()
                                .AsNoTracking()
                                .OrderBy(x => x.Name)
                                .ToListAsync();
            }
            else
            {
                return await FindAll()
                                .Where(x => x.IsActive)
                                .AsNoTracking()
                                .OrderBy(x => x.Name)
                                .ToListAsync();
            }
        }

        public async Task<PropertySubType> GetById(int id)
        {
            return await FindByCondition(x => x.Id.Equals(id)).AsNoTracking().FirstOrDefaultAsync();
        }

        #endregion
    }
}
