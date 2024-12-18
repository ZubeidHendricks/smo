﻿using Microsoft.EntityFrameworkCore;
using NPOMS.Domain.Core;
using NPOMS.Repository.Interfaces.Core;
using System.Linq;
using System.Threading.Tasks;

namespace NPOMS.Repository.Implementation.Core
{
	public class PermissionRepository : BaseRepository<Permission>, IPermissionRepository
	{
        #region Constructors

        public PermissionRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {

        }

        #endregion

        #region Methods

        public async Task<Permission> GetBySystemName(string systemName)
        {
            return await FindByCondition(x => x.SystemName == systemName)
                        .FirstOrDefaultAsync();
        }

        public async Task<Permission> GetById(int id)
        {
            return await FindByCondition(x => x.Id == id)
                        .FirstOrDefaultAsync();
        }

        public IQueryable<Permission> GetEntities()
        {
            return FindAll().Where(x => x.IsActive)
                .Include(x => x.Roles).ThenInclude(x => x.Role)
                .AsQueryable();
        }

        public async Task CreateEntity(Permission entity)
        {
            await CreateAsync(entity);
        }

        public async Task UpdateEntity(Permission entity, int currentUserId)
        {
            await UpdateAsync(null, entity, false, currentUserId);
        }

        public async Task DeleteEntity(Permission entity)
        {
            await DeleteAsync(entity);
        }

        #endregion
    }
}
