namespace NPOMS.Services.Extensions
{
	public class AzureAdB2C
    {
		public string ServiceUrl { get; set; }

		public string Tenant { get; set; }

		public string ApiClientId { get; set; }

		public string Policy { get; set; }

		public string AllowedOrigins { get; set; }

		public string ScopeRead { get; set; }

		public string ScopeWrite { get; set; }
	}
}
