using NPOMS.Domain.Core;
using NPOMS.Repository.Interfaces;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using NPOMS.Domain.Entities;

namespace NPOMS.Repository.Interfaces.Entities
{

    public interface IBidRepository : IBaseRepository<FundingApplicationDetail>
    {

        Task<FundingApplicationDetail> GetById(int id);
        Task<FundingApplicationDetail> GetapplicationIDAsync(int applicationId);
    }
}