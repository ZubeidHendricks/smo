using NPOMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Entities
{
    public interface IPostRepository : IBaseRepository<PostReport>
    {
        Task<IEnumerable<PostReport>> GetEntities();

        Task<PostReport> GetById(int id);

        Task<IEnumerable<PostReport>> GetByPeriodId(int applicationPeriodId);

        Task<IEnumerable<PostReport>> GetByNpoId(int npoId);

        Task<PostReport> GetByIds(int financialYearId, int applicationTypeId);

        Task CreateEntity(PostReport model);

        Task UpdateEntity(PostReport model, int currentUserId);
        Task UpdateEntityQC(PostReport model, int currentUserId);
        Task<IEnumerable<PostReport>> CompletePost(int applicationId, int financialId, int quarter, int currentUserId);
    }
}
