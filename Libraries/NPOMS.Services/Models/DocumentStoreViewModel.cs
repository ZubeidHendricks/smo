using NPOMS.Domain.Core;
using System;

namespace NPOMS.Services.Models
{
	public class DocumentStoreViewModel
    {
        public int Id { get; set; } = 0;

        public string RefNo { get; set; }

        public int? DocumentTypeId { get; set; } = 0;

        public int EntityTypeId { get; set; } = 0;

        public int EntityId { get; set; } = 0;

        public string Entity { get; set; }

        public string Name { get; set; }

        public string ResourceId { get; set; } = "";

        public string FileSize { get; set; } = "";

        public bool IsActive { get; set; } = true;

        public int CreatedUserId { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public int? UpdatedUserId { get; set; }

        public DateTime? UpdatedDateTime { get; set; }

        public DocumentType DocumentType { get; set; }
    }
}
