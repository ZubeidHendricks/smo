﻿using Microsoft.EntityFrameworkCore;
using NPOMS.Domain.Entities;
using NPOMS.Repository.Interfaces;
using NPOMS.Repository.Interfaces.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Repository.Implementation.Entities
{
    public class AnyOtherRepository : BaseRepository<AnyOtherInformationReport>, IAnyOtherRepository
    {
        public AnyOtherRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
            
        }

        public async Task CreateEntity(AnyOtherInformationReport model)
        {
            await CreateAsync(model);
        }

        public async Task<AnyOtherInformationReport> GetById(int id)
        {
            return await FindByCondition(x => x.Id.Equals(id)).AsNoTracking().FirstOrDefaultAsync();
        }

        public Task<AnyOtherInformationReport> GetByIds(int financialYearId, int applicationTypeId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<AnyOtherInformationReport>> GetByNpoId(int npoId)
        {
            return null;
            //return await FindByCondition(x => x.Id.Equals(npoId)).AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<AnyOtherInformationReport>> GetByPeriodId(int applicationPeriodId)
        {
            return await FindByCondition(x => x.ApplicationId == applicationPeriodId && x.IsActive)
                         .AsNoTracking()
                         .ToListAsync();
        }

        public async Task<IEnumerable<AnyOtherInformationReport>> GetEntities()
        {
            return await FindByCondition(x => x.IsActive).AsNoTracking().ToListAsync();
        }

        public async Task UpdateEntity(AnyOtherInformationReport model, int currentUserId)
        {
            await UpdateAsync(null, model, false, currentUserId);
        }

        public Task UpdateEntityQC(AnyOtherInformationReport model, int currentUserId)
        {
            throw new NotImplementedException();
        }
    }
}