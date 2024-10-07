using Microsoft.EntityFrameworkCore;
using NPOMS.Domain.Dropdown;
using NPOMS.Repository.Interfaces;
using NPOMS.Repository.Interfaces.Dropdown;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Repository.Implementation.Dropdown
{
    public class AreaRepository : BaseRepository<Area>, IAreaRepository
    {
        public AreaRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void Create(SubDistrictDemographic entity)
        {
            throw new NotImplementedException();
        }

        public Task CreateAsync(SubDistrictDemographic entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(SubDistrictDemographic entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(SubDistrictDemographic entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<SubDistrictDemographic> FindByCondition(Expression<Func<SubDistrictDemographic, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Area>> GetEntities(bool returnInactive)
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

        public void InsertMultiItemsAsync(List<SubDistrictDemographic> entity)
        {
            throw new NotImplementedException();
        }

        public void Update(SubDistrictDemographic entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(SubDistrictDemographic oldEntity, SubDistrictDemographic newEntity, bool trackChanges, int currentUserId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(SubDistrictDemographic entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync1(SubDistrictDemographic entity)
        {
            throw new NotImplementedException();
        }

        IQueryable<SubDistrictDemographic> IBaseRepository<SubDistrictDemographic>.FindAll()
        {
            throw new NotImplementedException();
        }

        Task IBaseRepository<SubDistrictDemographic>.InsertMultiItemsAsync(List<SubDistrictDemographic> entity)
        {
            throw new NotImplementedException();
        }
    }
}
