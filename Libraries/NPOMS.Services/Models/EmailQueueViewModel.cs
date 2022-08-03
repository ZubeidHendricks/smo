using System;

namespace NPOMS.Services.Models
{
	public class EmailQueueViewModel
    {
        public int Id { get; set; }

        public string Message { get; set; }

        public string Subject { get; set; }

        public string FromEmailName { get; set; }

        public string FromEmailAddress { get; set; }

        public string RecipientName { get; set; }

        public string RecipientEmail { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public DateTime? SentDateTime { get; set; }
    }
}
