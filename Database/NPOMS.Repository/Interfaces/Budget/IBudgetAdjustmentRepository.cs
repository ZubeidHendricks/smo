using NPOMS.Domain.Budget;
using NPOMS.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Budget
{
    public interface IBudgetAdjustmentRepository : IBaseRepository<BudgetAdjustment>
    {
        Task<List<BudgetAdjustment>> GetAdjustmentAmount(string responsibilityCode, string objectiveCode);
        Task<BudgetAdjustment> AddBudgetAdjustmentAmount(string responsibilityCode, string objectiveCode, decimal budgetAmount);
    }
}
