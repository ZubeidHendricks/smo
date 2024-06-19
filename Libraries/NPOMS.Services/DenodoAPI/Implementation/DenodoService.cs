using Microsoft.PowerBI.Api.Models;
using NPOMS.Domain.Budget;
using NPOMS.Domain.Core;
using NPOMS.Domain.ResourceParameters;
using NPOMS.Repository.Interfaces.Budget;
using NPOMS.Repository.Interfaces.Core;
using NPOMS.Repository.Interfaces.Mapping;
using NPOMS.Services.DenodoAPI.Interfaces;
using NPOMS.Services.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NPOMS.Services.DenodoAPI.Implementation
{
	public class DenodoService : IDenodoService
	{
		private static HttpClient httpClient = null;
		private DenodoAPIConfig _denodoAPIConfig;
		private IBudgetAdjustmentRepository _budgetAdjustmentRepository;
        private IUserRepository _userRepository;
		private ISegmentCodeRepository _segmentCodeRepository;

        public DenodoService(DenodoAPIConfig denodoAPIConfig,
			IBudgetAdjustmentRepository budgetAdjustmentRepository,
            IUserRepository userRepository,
			ISegmentCodeRepository segmentCodeRepository)
		{
			_denodoAPIConfig = denodoAPIConfig;
			_budgetAdjustmentRepository = budgetAdjustmentRepository;
            _userRepository = userRepository;
			_segmentCodeRepository = segmentCodeRepository;
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

		public async Task<FacilityAPIWrapperModel> Get(DenodoFacilityResourceParameters denodoFacilityResourceParameters, string userIdentifier)
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

		public async Task<BudgetAPIWrapperModel> GetBudgets(string department, string financialYear, string responsibilitylowestlevelcode, string objectivelowestlevelcode, string userIdentifier)
		{
            var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);
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

		public async Task<BudgetAPIWrapperModel> GetBudgets(string department, string financialYear, string userIdentifier)
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

		public async Task<BudgetAdjustment> Create(string responsibilityCode, string objectiveCode, decimal amount)
		{
			return await _budgetAdjustmentRepository.AddBudgetAdjustmentAmount(responsibilityCode, objectiveCode, amount);
        }

        public async Task<BudgetAPIWrapperModel> ImportBudgets(string department, string financialYear, string responsibilitylowestlevelcode, string objectivelowestlevelcode, string userIdentifier)
        {
            var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);
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

            List<BudgetAPIModel> data1 = new List<BudgetAPIModel>();
            try
            {
                for (int row = 0; row < data.elements.Count; row++)
                {
                    data1.Add(data.elements[row]);

                }
            }
            catch (Exception ex)
            {

            }

            var ddd = new List<ProgrammeBudget>();
            foreach (var r in data1)
            {
				var progId = await _segmentCodeRepository.GetByValue(r.responsibilitylowestlevelcode, r.objectivelowestlevelcode);
                
				var dtoRow = new ProgrammeBudget();
                dtoRow.FinancialYearId = r.financialyear;
                dtoRow.DepartmentId = 1;
                dtoRow.DepartmentName = "";
                dtoRow.ProgrammeId = progId[0].ProgrammeId;
                dtoRow.ProgrammeName = "";
                dtoRow.SubProgrammeId = 1;
                dtoRow.SubProgrammeName = "";
                dtoRow.SubProgrammeTypeId = progId[0].SubProgrammeTypeId;
                dtoRow.SubProgrammeTypeName = "";
                dtoRow.OriginalBudgetAmount = Convert.ToDecimal(r.originalbudget);
                dtoRow.AdjustedBudgetAmount = 0;
                dtoRow.ResponsibilityCode = r.responsibilitylowestlevelcode;
                dtoRow.ObjectiveCode = r.objectivelowestlevelcode;
                dtoRow.CreatedUserId = loggedInUser.Id;
                dtoRow.CreatedDateTime = DateTime.Now;
            }


            return data;
        }
    }
}
