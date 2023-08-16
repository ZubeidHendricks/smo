using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Domain.Entities
{
    [Table("PreviousYearFinance", Schema = "dbo")]
    public class PreviousYearFinance : BaseEntity
    {
        public int npoProfileId { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string IncomeDescription { get; set; }

        public int? IncomeAmount { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string ExpenditureDescription { get; set; }

        public int? ExpenditureAmount { get; set; }

        public bool IsActive { get; set; }

        public int CreatedUserId { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public int? UpdatedUserId { get; set; }

        public DateTime? UpdatedDateTime { get; set; }
    }
}
