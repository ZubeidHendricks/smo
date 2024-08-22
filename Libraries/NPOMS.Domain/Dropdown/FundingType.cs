﻿using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NPOMS.Domain.Dropdown
{
    [Table("FundingTypes", Schema = "dropdown")]
    public class FundingType : BaseEntity
    {
        #region Properties

        [Required]
        [Column(TypeName = "nvarchar(255)")]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string SystemName { get; set; }

        public bool IsActive { get; set; }

        public int CreatedUserId { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public int? UpdatedUserId { get; set; }

        public DateTime? UpdatedDateTime { get; set; }

        #endregion
    }
}
