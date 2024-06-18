using Microsoft.EntityFrameworkCore;
using NPOMS.Domain.Mapping;
using NPOMS.Repository.Interfaces.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Repository.Implementation.Mapping
{
    public class SegmentCodeRepository : BaseRepository<SegmentCode>, ISegmentCodeRepository
    {
        #region Constructors

        public SegmentCodeRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {

        }

        #endregion

        #region Methods

        public async Task<IEnumerable<SegmentCode>> GetEntities(bool returnInactive)
        {
            return await FindAll().AsNoTracking()
               .OrderBy(ow => ow.Id).ToListAsync();
        }
         

        #endregion

    }
}
