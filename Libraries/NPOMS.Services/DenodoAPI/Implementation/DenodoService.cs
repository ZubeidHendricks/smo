using NPOMS.Domain.ResourceParameters;
using NPOMS.Services.DenodoAPI.Interfaces;
using NPOMS.Services.Models;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Services.DenodoAPI.Implementation
{
	public class DenodoService : IDenodoService
	{
		private static HttpClient httpClient = null;
		private DenodoAPIConfig _denodoAPIConfig;

		public DenodoService(DenodoAPIConfig denodoAPIConfig)
		{
			_denodoAPIConfig = denodoAPIConfig;
		}

		private static HttpClient PrepareClient(DenodoAPIConfig denodoAPIConfig)
		{
			if (httpClient == null)
			{
				var httpClientHandler = new HttpClientHandler()
				{
					Credentials = new NetworkCredential(denodoAPIConfig.Username, denodoAPIConfig.Pwd)
				};

				httpClient = new HttpClient(httpClientHandler);
				httpClient.BaseAddress = new Uri(denodoAPIConfig.BaseUri);
				httpClient.DefaultRequestHeaders.Accept.Clear();
				httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			}

			return httpClient;
		}

		public async Task<FacilityAPIWrapperModel> Get(DenodoFacilityResourceParameters denodoFacilityResourceParameters)
		{
			StringBuilder sbFullQuery = new StringBuilder();
			StringBuilder sbFilter = new StringBuilder();

            sbFullQuery.AppendFormat($"{_denodoAPIConfig.FacilityView}?$count={0}", denodoFacilityResourceParameters.PageSize);

            if (!string.IsNullOrEmpty(denodoFacilityResourceParameters.FacilityName))
			{
				//encoded parameters
				sbFilter.AppendFormat($"name+like+%27%25{denodoFacilityResourceParameters.FacilityName}%25%27");
			}

			if (!string.IsNullOrEmpty(denodoFacilityResourceParameters.Status))
			{
				if (sbFilter.Length > 1)
				{
					sbFilter.Append("+AND+");
				}

				//encoded parameters
				sbFilter.AppendFormat($"status+like+%27%25{denodoFacilityResourceParameters.Status}%25%27");
			}

			if (sbFilter.Length > 1)
			{
				sbFullQuery.AppendFormat($"&$filter={sbFilter}");
			}

			FacilityAPIWrapperModel facilities = null;

			HttpResponseMessage response = await PrepareClient(_denodoAPIConfig).GetAsync(sbFullQuery.ToString());
			if (response.IsSuccessStatusCode)
			{
				facilities = await response.Content.ReadAsAsync<FacilityAPIWrapperModel>();
			}

			return facilities;
		}

        public async Task<BudgetAPIWrapperModel> GetBudgets(string department, string financialYear, string responsibilitylowestlevelcode, string objectivelowestlevelcode)
		{
            StringBuilder sbFullQuery = new StringBuilder();
            StringBuilder sbFilter = new StringBuilder();

            //Append view to Denodo URL
            sbFullQuery.AppendFormat($"{_denodoAPIConfig.BudgetView}");
			_denodoAPIConfig.BaseUri = "https://ldw.westerncape.gov.za/server/dev_ldw/";

			//Filter by 
			sbFilter.AppendFormat($"?DepartmentName={department}&FinancialYear={financialYear}");

			//Append filter to query
			sbFullQuery.AppendFormat($"{sbFilter}");

			BudgetAPIWrapperModel data = null;

            HttpResponseMessage response = await PrepareClient(_denodoAPIConfig).GetAsync(sbFullQuery.ToString());
            if (response.IsSuccessStatusCode)
            {
                data = await response.Content.ReadAsAsync<BudgetAPIWrapperModel>();
            }

            return data;
        }

        public async Task<BudgetAPIWrapperModel> GetBudgets(string department, string financialYear)
        {
            StringBuilder sbFullQuery = new StringBuilder();
            StringBuilder sbFilter = new StringBuilder();

            //Append view to Denodo URL
            sbFullQuery.AppendFormat($"{_denodoAPIConfig.BudgetView}");
            _denodoAPIConfig.BaseUri = "https://ldw.westerncape.gov.za/server/dev_ldw/";

            //Filter by 
            sbFilter.AppendFormat($"?DepartmentName={department}&FinancialYear={financialYear}");

            //Append filter to query
            sbFullQuery.AppendFormat($"{sbFilter}");

            BudgetAPIWrapperModel data = null;

            HttpResponseMessage response = await PrepareClient(_denodoAPIConfig).GetAsync(sbFullQuery.ToString());
            if (response.IsSuccessStatusCode)
            {
                data = await response.Content.ReadAsAsync<BudgetAPIWrapperModel>();
            }
			var d = data;
            return d;
        }
    }
}
