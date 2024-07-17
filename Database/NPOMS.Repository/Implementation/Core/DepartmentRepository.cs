using Microsoft.EntityFrameworkCore;
using NPOMS.Domain.Core;
using NPOMS.Domain.Mapping;
using NPOMS.Repository.Interfaces.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NPOMS.Repository.Implementation.Core
{
	public class DepartmentRepository : BaseRepository<Department>, IDepartmentRepository
	{
		#region Constructors
		private readonly RepositoryContext _context;

		public DepartmentRepository(RepositoryContext repositoryContext,RepositoryContext context)
			: base(repositoryContext)
		{
			_context = context;

        }

        public async Task<Department> GetDepartmentById(int id)
        {
           return  await _context.Departments.Where(x => x.Id == id && x.IsActive).FirstOrDefaultAsync();
        }

        public async Task<List<int>> GetDepartmentIdOfLogggedInUserAsync(int userId)
        {
            var dep = await _context.UserDepartments
                                       .Where(x => x.UserId == userId)
                                       .Select(x => x.DepartmentId)
                                       .ToListAsync();
            return dep;
            //try
            //{
            //    var dep = await _context.UserDepartments
            //                            .Where(x => x.UserId == userId)
            //                            .Select(x => x.DepartmentId)
            //                            .ToListAsync();
            //    return dep;
            //}
            //catch (Exception ex)
            //{
            //    ex.ToString(); // Re-throw the exception to be handled by the calling method
            //}
        }

        #endregion

        #region Methods

        public async Task<IEnumerable<Department>> GetEntities(bool returnInactive)
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

		#endregion
	}
}
