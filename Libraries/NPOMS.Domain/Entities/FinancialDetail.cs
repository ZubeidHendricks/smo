using NPOMS.Domain.Dropdown;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Domain.Entities
{
    [Table("FinancialDetails", Schema = "fa")]
    public class FinancialDetail : BaseEntity
    {
        public int ApplicationId { get; set; }
        public int PropertyId { get; set; }
        public int SubPropertyId { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Property { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string SubProperty { get; set; }
        [Column(TypeName = "numeric(18,6)")]
        public decimal AmountOne { get; set; }
        [Column(TypeName = "numeric(18,6)")]
        public decimal AmountTwo { get; set; }
        [Column(TypeName = "numeric(18,6)")]
        public decimal AmountThree { get; set; }
        public string Type { get; set; }

        public bool IsActive { get; set; }

        public int CreatedUserId { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public int? UpdatedUserId { get; set; }

        public DateTime? UpdatedDateTime { get; set; }

        public bool? ChangesRequired { get; set; }

        public bool? IsNew { get; set; }
        public virtual PropertyType PropertyType { get; set; }
        public virtual PropertySubType PropertySubType { get; set; }
    }
}
