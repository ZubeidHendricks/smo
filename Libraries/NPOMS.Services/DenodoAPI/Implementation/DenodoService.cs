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

			sbFullQuery.AppendFormat("bv_sinjani_facility_view/views/vwdohfacility?$count={0}", denodoFacilityResourceParameters.PageSize);

			if (!string.IsNullOrEmpty(denodoFacilityResourceParameters.FacilityName))
			{
				//encoded parameters
				sbFilter.AppendFormat("name+like+%27%25{0}%25%27", denodoFacilityResourceParameters.FacilityName);
			}

			if (!string.IsNullOrEmpty(denodoFacilityResourceParameters.Status))
			{
				if (sbFilter.Length > 1)
				{
					sbFilter.Append("+AND+");
				}

				//encoded parameters
				sbFilter.AppendFormat("status+like+%27%25{0}%25%27", denodoFacilityResourceParameters.Status);
			}

			if (sbFilter.Length > 1)
			{
				sbFullQuery.AppendFormat("&$filter={0}", sbFilter);
			}

			FacilityAPIWrapperModel facilities = null;

			HttpResponseMessage response = await PrepareClient(_denodoAPIConfig).GetAsync(sbFullQuery.ToString());
			if (response.IsSuccessStatusCode)
			{
				facilities = await response.Content.ReadAsAsync<FacilityAPIWrapperModel>();
			}

			return facilities;
		}
	}
}
