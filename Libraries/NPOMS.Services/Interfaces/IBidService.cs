
using NPOMS.Domain.Core;
using NPOMS.Domain.Dropdown;
using NPOMS.Domain.Entities;
using NPOMS.Services.Models;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Services.Interfaces
{
    public interface IBidService
    {        
        Task<FundAppDetailViewModel> Create(string userIdentifier, FundAppDetailViewModel model);
        Task<FundAppDetailViewModel> GetapplicationIDAsync(int bidId);

        IEnumerable<FinYearViewModel> GetFinYears();
        Task<FundAppDetailViewModel> Update(string userIdentifier, int bidId, FundAppDetailViewModel model);
        //Task<FundAppDetailViewModel> UpdateSDA(string userIdentifier, int bidId, FundAppDetailViewModel model);

        void UpdateIncome(FinancialMatters model);
        Task<FundAppDetailViewModel> GetById(int bidId);
        IEnumerable<Place> GetPlaces(List<int> sdaIds);
        IEnumerable<SubPlace> GetSubplaces(List<int> placeIds);
    }
}
