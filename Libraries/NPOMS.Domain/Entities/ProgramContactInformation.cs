using NPOMS.Domain.Dropdown;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NPOMS.Domain.Entities
{
    [Table("ProgramContactInformation", Schema = "dbo")]
    public class ProgramContactInformation : BaseEntity
    {
        public int ProgrammeId { get; set; }

        public int TitleId { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string FirstName { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string LastName { get; set; }

        public bool RSAIdNumber { get; set; }

        [Column(TypeName = "nvarchar(13)")]
        public string IdNumber { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string PassportNumber { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string EmailAddress { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Telephone { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Cellphone { get; set; }

        public int? PositionId { get; set; }

        [Column(TypeName = "nvarchar(1000)")]
        public string Comments { get; set; }

        public bool? IsPrimaryContact { get; set; }
        public bool? IsDisabled { get; set; }
        public bool? IsBoardMember { get; set; }
        public bool? IsSignatory { get; set; }
        public bool? IsWrittenAgreementSignatory { get; set; }

        public int? YearsOfExperience { get; set; }
        public int? RaceId { get; set; }
        public int? GenderId { get; set; }
        public int? LanguageId { get; set; }
        public DateTime? DateOfEmployment { get; set; }
        public string Qualifications { get; set; }
        public string AddressInformation { get; set; }

        public bool IsActive { get; set; }

        public int CreatedUserId { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public int? UpdatedUserId { get; set; }

        public DateTime? UpdatedDateTime { get; set; }

        public Title Title { get; set; }

        public Position Position { get; set; }

        public Race Race { get; set; }

        public Gender Gender { get; set; }

        public Language Language { get; set; }
        public int ApprovalStatusId { get; set; }
        public AccessStatus ApprovalStatus { get; set; }
    }
}
