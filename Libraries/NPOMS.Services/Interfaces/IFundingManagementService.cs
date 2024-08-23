using NPOMS.Services.Models.FundingManagement;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Services.Interfaces
{
    public interface IFundingManagementService
    {
        Task<IEnumerable<NpoViewModel>> GetAll();

        Task<NpoViewModel> GetById(int id);

        Task<NpoViewModel> GetByNpoId(int npoId);
    }
}
