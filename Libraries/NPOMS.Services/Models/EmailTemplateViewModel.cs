namespace NPOMS.Services.Models
{
	public class EmailTemplateViewModel
    {
        public int Id { get; set; }

        public int EmailAccountId { get; set; }

        public string Name { get; set; }

        public string Body { get; set; }

        public string Subject { get; set; }

        public bool IsActive { get; set; }

        public string Description { get; set; }

        public EmailAccountViewModel EmailAccount { get; set; }
    }
}
