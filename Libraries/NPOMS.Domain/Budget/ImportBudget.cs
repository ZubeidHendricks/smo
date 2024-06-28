using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Domain.Budget
{
    [Table("ImportBudgets", Schema = "budget")]
    public class ImportBudget : BaseEntity
    {
        public string FinancialYearId { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public int ProgrammeId { get; set; }
        public string ProgrammeName { get; set; }
        public int SubProgrammeId { get; set; }
        public string SubProgrammeName { get; set; }
        public int SubProgrammeTypeId { get; set; }
        public string SubProgrammeTypeName { get; set; }
        public decimal OriginalBudgetAmount { get; set; }
        public decimal AdjustedBudgetAmount { get; set; }
        public int ResponsibilityCode { get; set; }
        public int ObjectiveCode { get; set; }
        public bool IsActive { get; set; }
        public int? CreatedUserId { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public int? UpdatedUserId { get; set; }
        public DateTime? UpdatedDateTime { get; set; }
    }
}
