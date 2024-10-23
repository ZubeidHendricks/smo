using NPOMS.Domain.Core;
using NPOMS.Domain.Dropdown;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NPOMS.Domain.Entities

{
    [Table("PostReports", Schema = "dbo")]
    public class PostReport : BaseEntity
    {
        public int StatusId { get; set; }
        public int StaffCategoryId { get; set; }
        public int NumberOfPosts { get; set; }

        public int NumberFilled { get; set; }

        public string MonthsFilled { get; set; }

        public string Vacant { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string DateOfVacancies { get; set; }

        public string VacancyReasons { get; set; }
        public  string  Plans { get; set; }

        public int ApplicationId { get; set; }

        public int QaurterId { get; set; }

        public bool IsActive { get; set; } = true;

        public int CreatedUserId { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public int? UpdatedUserId { get; set; }

        public DateTime? UpdatedDateTime { get; set; }

        public DateTime? ApprovalDateTime { get; set; }

        public User CreatedUser { get; set; }

        public Status Status { get; set; }
        public StaffCategory StaffCategory { get; set; }
    }
}
