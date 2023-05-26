using NPOMS.Domain.Entities;
using NPOMS.Repository.Implementation.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Entities
{
    public interface IFundAppSDADetailRepository : IBaseRepository<FundAppSDADetail>
    { 

        Task CreateEntity(FundAppSDADetail model);

        Task UpdateEntity(FundAppSDADetail model, int currentUserId);

        Task<FundAppSDADetail> GetById(int id);
    }
}
