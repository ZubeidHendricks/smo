using Microsoft.EntityFrameworkCore;
using NPOMS.Domain.Budget;
using NPOMS.Domain.Core;
using NPOMS.Repository.Interfaces.Budget;
using NPOMS.Repository.Interfaces.Core;
using NPOMS.Repository.Interfaces.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Repository.Implementation.Budget
{
    public class BudgetAdjustmentRepository : BaseRepository<BudgetAdjustment>, IBudgetAdjustmentRepository
    {

        #region Constructors
        private ISegmentCodeRepository _segmentCodeRepository;

        public BudgetAdjustmentRepository(RepositoryContext repositoryContext,
            ISegmentCodeRepository segmentCodeRepository )
            : base(repositoryContext)
        {
            _segmentCodeRepository = segmentCodeRepository;
        }

        #endregion


        #region Methods

        public async Task <List<BudgetAdjustment>> GetAdjustmentAmount(string responsibilityCode, string objectiveCode)
        {
            return await FindByCondition(x => x.ResponsibilityCode.Equals(responsibilityCode) && x.ObjectiveCode.Equals(objectiveCode))
                .AsNoTracking().ToListAsync();
                            
        }

        public async Task<BudgetAdjustment> AddBudgetAdjustmentAmount(string responsibilityCode, string objectiveCode, decimal budgetAmount)
        {
            
            var segmentValue = await _segmentCodeRepository.GetByValue(responsibilityCode, objectiveCode);
            var ProgrammeId = segmentValue[0].ProgrammeId;
            var SubProgrammeTypeId = segmentValue[0].SubProgrammeTypeId;

            var budgetAdjustment = new BudgetAdjustment()
            {
                ProgrammeId = ProgrammeId,
                SubProgrammeTypeId = SubProgrammeTypeId,
                ResponsibilityCode = responsibilityCode,
                ObjectiveCode = objectiveCode,
                Amount = budgetAmount
            };

            await CreateAsync(budgetAdjustment);
            return budgetAdjustment;
        }

        #endregion
    }
}
