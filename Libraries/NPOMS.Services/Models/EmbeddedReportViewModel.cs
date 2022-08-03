using System;

namespace NPOMS.Services.Models
{
	public class EmbeddedReportViewModel
	{
        public int Id { get; set; }

        public string Name { get; set; }
        
        public string Description { get; set; }

        public string ReportId { get; set; }
        
        public string WorkspaceId { get; set; }
        
        public bool IsActive { get; set; }
        
        public string CategoryName { get; set; }

        public int CreatedUserId { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public int? UpdatedUserId { get; set; }

        public DateTime? UpdatedDateTime { get; set; }
    }
}
