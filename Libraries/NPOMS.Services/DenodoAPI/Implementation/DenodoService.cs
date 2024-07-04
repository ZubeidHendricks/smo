//using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.PowerBI.Api.Models;
using NPOMS.Domain.Budget;
using NPOMS.Domain.Core;
using NPOMS.Domain.ResourceParameters;
using NPOMS.Repository.Interfaces.Budget;
using NPOMS.Repository.Interfaces.Core;
using NPOMS.Repository.Interfaces.Mapping;
using NPOMS.Services.DenodoAPI.Interfaces;
using NPOMS.Repository.Interfaces.Dropdown;
using NPOMS.Services.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Linq;
using NPOMS.Repository;
using System.Globalization;
using Microsoft.EntityFrameworkCore;
using NPOMS.Repository.Implementation.Budget;
using NPOMS.Domain.Enumerations;
using NPOMS.Domain.Dropdown;
using System.Collections;

namespace NPOMS.Services.DenodoAPI.Implementation
{
	public class DenodoService : IDenodoService
	{
		private static HttpClient httpClient = null;
		private DenodoAPIConfig _denodoAPIConfig;
		private IBudgetAdjustmentRepository _budgetAdjustmentRepository;
        private IUserRepository _userRepository;
		private ISegmentCodeRepository _segmentCodeRepository;
		private IDepartmentRepository _departmentRepository;
		private ISubProgrammeRepository _subProgrammeRepository;
		private IProgrammeRepository _programmeRepository;
		private IProgrammeBudgetRepository _programmeBudgetRepository;
        private RepositoryContext _repositoryContext;
		ISubProgrammeTypeRepository _subProgrammeTypeRepository;

        public DenodoService(DenodoAPIConfig denodoAPIConfig,
			IBudgetAdjustmentRepository budgetAdjustmentRepository,
            IUserRepository userRepository,
			ISegmentCodeRepository segmentCodeRepository,
			IDepartmentRepository departmentRepository,
			ISubProgrammeRepository subProgrammeRepository,
			IProgrammeRepository programmeRepository,
            RepositoryContext repositoryContext,
			IProgrammeBudgetRepository programmeBudgetRepository,
			ISubProgrammeTypeRepository subProgrammeTypeRepository)
		{
			_denodoAPIConfig = denodoAPIConfig;
			_budgetAdjustmentRepository = budgetAdjustmentRepository;
            _userRepository = userRepository;
			_segmentCodeRepository = segmentCodeRepository;
			_departmentRepository = departmentRepository;
			_subProgrammeRepository = subProgrammeRepository;
			_programmeRepository = programmeRepository;
			_repositoryContext = repositoryContext;
			_programmeBudgetRepository = programmeBudgetRepository;
			_subProgrammeTypeRepository = subProgrammeTypeRepository;
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

        public async Task<IEnumerable<ProgrammeBudget>> GetDepartmentBudgetsSummary(int department, string financialYear, string userIdentifier)
        {
            var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);
            var results = await _programmeBudgetRepository.GetProgrammeBudgetsByIds(department, financialYear);
            var departmentIds = await _departmentRepository.GetDepartmentIdOfLogggedInUserAsync(loggedInUser.Id);
            var programmesIds = await _programmeRepository.GetProgrammesIdOfLoggenInUserAsync(loggedInUser.Id);



            if (loggedInUser.Roles.Any(x => x.IsActive && (x.RoleId.Equals((int)RoleEnum.SystemAdmin))))
            {
                return results;
            }
            else if (loggedInUser.Roles.Any(x => x.IsActive && x.RoleId.Equals((int)RoleEnum.Admin)))
            {
                results = results.Where(x => departmentIds.Contains(x.DepartmentId));

                return results;
            }
            else if (loggedInUser.Roles.Any(x => x.IsActive && !x.RoleId.Equals((int)RoleEnum.Applicant)))
            {
                results = results.Where(x => departmentIds.Contains(x.DepartmentId)
                         && programmesIds.Contains(x.ProgrammeId));

                return results;
            }
            else
            {
                results = results.Where(x => departmentIds.Contains(x.DepartmentId)
                        && programmesIds.Contains(x.ProgrammeId));
                return results;
            }


            //return results;           

        }

        public async Task<IEnumerable<ProgrammeBudget>> GetFilteredBudgets(int department, string financialYear, string userIdentifier)
		{
            var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);
            var results = await _programmeBudgetRepository.GetProgrammeBudgetsByIds(department, financialYear);
            var departmentIds = await _departmentRepository.GetDepartmentIdOfLogggedInUserAsync(loggedInUser.Id);
            var programmesIds = await _programmeRepository.GetProgrammesIdOfLoggenInUserAsync(loggedInUser.Id);

           

            if (loggedInUser.Roles.Any(x => x.IsActive && (x.RoleId.Equals((int)RoleEnum.SystemAdmin))))
			{
				return results;
			}
            else if (loggedInUser.Roles.Any(x => x.IsActive && x.RoleId.Equals((int)RoleEnum.Admin)))
            {
                results = results.Where(x => departmentIds.Contains(x.DepartmentId));

                return results;
            }
            else if (loggedInUser.Roles.Any(x => x.IsActive && !x.RoleId.Equals((int)RoleEnum.Applicant)))
			{
                results = results.Where(x => departmentIds.Contains(x.DepartmentId)
                         && programmesIds.Contains(x.ProgrammeId));

                return results;
            }
			else
			{
                results = results.Where(x => departmentIds.Contains(x.DepartmentId)
                        && programmesIds.Contains(x.ProgrammeId));
                return results;
            }
           
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

        public async Task<IEnumerable<ImportBudget>> ImportBudget(string department, string financialYear, string userIdentifier)
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

            for (int row = 0; row < data.elements.Count; row++)
            {
                data1.Add(data.elements[row]);

            }
           
            var budgetData = new List<ImportBudget>();

            foreach (var r in data1)
            {
                var dtoRow = new ImportBudget();
				if(!string.IsNullOrEmpty(r.originalbudget))
				{
					//if (r.originalbudget != "0.00")
					//{
						try
						{
                            var prog = await _segmentCodeRepository.GetByValue(r.responsibilitylowestlevelcode, r.objectivelowestlevelcode);
                            if (prog.Count > 0)
                            {
                                var programme = await _programmeRepository.GetById(prog[0].ProgrammeId);
                                var subProg = await _subProgrammeRepository.GetById(prog[0].SubProgramId);
                                var subProgType = await _subProgrammeTypeRepository.GetById(prog[0].SubProgrammeTypeId);

								if (subProg != null)
								{
									dtoRow.SubProgrammeId = subProg.Id;
									dtoRow.SubProgrammeName = subProg.Name;
								}
								else
								{
                                    dtoRow.SubProgrammeId = 0;
                                }							
                               
                                dtoRow.DepartmentId = programme.DepartmentId;
                                dtoRow.ProgrammeName = programme.Name;

                                dtoRow.FinancialYearId = r.financialyear;
                                dtoRow.DepartmentName = "";

                                dtoRow.ProgrammeId = prog[0].ProgrammeId;

                                dtoRow.SubProgrammeTypeId = prog[0].SubProgrammeTypeId;
                                dtoRow.SubProgrammeTypeName = subProgType[0].Name;
                                dtoRow.OriginalBudgetAmount = decimal.Parse(r.originalbudget, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture);
                                dtoRow.AdjustedBudgetAmount = decimal.Parse("0.00", NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture);
                                dtoRow.ResponsibilityCode = int.Parse(r.responsibilitylowestlevelcode, CultureInfo.InvariantCulture);
                                dtoRow.ObjectiveCode = int.Parse(r.objectivelowestlevelcode, CultureInfo.InvariantCulture);
								dtoRow.IsActive = true;
								dtoRow.CreatedUserId = loggedInUser.Id;
                                dtoRow.CreatedDateTime = DateTime.Now;
                            }
                            budgetData.Add(dtoRow);
                        }
						catch(Exception ex) 
						{
							ex.ToString();
						}
						
					//}
                }
            }		
            
            this._repositoryContext.ImportBudget.AddRange(budgetData);
            await this._repositoryContext.SaveChangesAsync();

            var sql = @"exec dbo.ImportBudget_Summary";
            await this._repositoryContext.Database.ExecuteSqlRawAsync(sql);

            return budgetData;
        }

        public async Task<ProgrammeBudget> Update(string amount, int id, string userIdentifier)
        {
            var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);
            var model = await _programmeBudgetRepository.GetProgrammeBudgetById(id);           

			model.AdjustedBudgetAmount = decimal.Parse(amount, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture); ;
            model.UpdatedUserId = loggedInUser.Id;
            model.UpdatedDateTime = DateTime.Now;

            var oldEntity = await this._repositoryContext.ProgrammeBudgets.FindAsync(model.Id);
            await _programmeBudgetRepository.UpdateAsync(oldEntity, model, true, loggedInUser.Id);
			return model;
        }

        public async Task<ProgrammeBudget> ProvisionalAmountUpdate(string amount, int id, string userIdentifier)
        {
            var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);
            var model = await _programmeBudgetRepository.GetProgrammeBudgetById(id);

            model.ProvisionalBudgetAmount = decimal.Parse(amount, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture); ;
            model.UpdatedUserId = loggedInUser.Id;
            model.UpdatedDateTime = DateTime.Now;

            var oldEntity = await this._repositoryContext.ProgrammeBudgets.FindAsync(model.Id);
            await _programmeBudgetRepository.UpdateAsync(oldEntity, model, true, loggedInUser.Id);
            return model;
        }
        
    }
}
