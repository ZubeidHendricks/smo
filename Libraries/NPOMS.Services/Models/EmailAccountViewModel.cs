namespace NPOMS.Services.Models
{
	public class EmailAccountViewModel
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public string FromDisplayName { get; set; }

        public string FromEmail { get; set; }

        public string Host { get; set; }

        public int Port { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public bool EnableSSL { get; set; }
    }
}
