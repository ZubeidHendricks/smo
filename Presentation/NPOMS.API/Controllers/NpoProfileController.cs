using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Graph;
using Newtonsoft.Json;
using NPOMS.Domain.Entities;
using NPOMS.Domain.Enumerations;
using NPOMS.Domain.Mapping;
using NPOMS.Services.Email;
using NPOMS.Services.Email.EmailTemplates;
using NPOMS.Services.Implementation;
using NPOMS.Services.Interfaces;
using NPOMS.Services.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.API.Controllers
{
	[Route("api/npo-profiles")]
	[ApiController]
	public class NpoProfileController : ExternalBaseController
	{
		#region Fields

		private ILogger<NpoProfileController> _logger;
		private INpoProfileService _npoProfileService;
		private INpoService _npoService;
		private IEmailService _emailService;

		#endregion+

		#region Constructors

		public NpoProfileController(
			ILogger<NpoProfileController> logger,
			INpoProfileService npoProfileService,
			INpoService npoService,
			IEmailService emailService
			)
		{
			_logger = logger;
			_npoProfileService = npoProfileService;
			_npoService = npoService;
			_emailService = emailService;
		}

		#endregion

		#region Methods

		[HttpGet(Name = "GetAllNpoProfiles")]
		public async Task<IActionResult> GetAllNpoProfiles()
		{
			try
			{
				var results = await _npoProfileService.Get(base.GetUserIdentifier());
				return Ok(results);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside GetAllNpoProfiles action: {ex.Message} Inner Exception: {ex.InnerException}");
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

		[HttpGet("npoProfileId/{npoProfileId}", Name = "GetNpoProfileById")]
		public async Task<IActionResult> GetNpoProfileById(int npoProfileId)
		{
			try
			{
				var results = await _npoProfileService.GetById(npoProfileId);
				return Ok(results);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside GetNpoProfileById action: {ex.Message} Inner Exception: {ex.InnerException}");
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

		[HttpPost(Name = "CreateNpoProfile")]
		public async Task<IActionResult> CreateNpoProfile([FromBody] NpoProfile model)
		{
			try
			{
				await _npoProfileService.Create(model, base.GetUserIdentifier());
				return Ok(model);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside CreateNpoProfile action: {ex.Message} Inner Exception: {ex.InnerException}");
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

		[HttpPut(Name = "UpdateNpoProfile")]
		public async Task<IActionResult> UpdateNpoProfile([FromBody] NpoProfile model)
		{
			try
			{
				await _npoProfileService.Update(model, base.GetUserIdentifier());
				await ConfigureEmail(model);
				return Ok(model);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside UpdateNpoProfile action: {ex.Message} Inner Exception: {ex.InnerException}");
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

		[HttpGet("NpoId/{NpoId}", Name = "GetNpoProfileByNpoId")]
		public async Task<IActionResult> GetNpoProfileByNpoId(int NpoId)
		{
			try
			{
				var results = await _npoProfileService.GetByNpoId(NpoId);
				return Ok(results);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside GetNpoProfileByNpoId action: {ex.Message} Inner Exception: {ex.InnerException}");
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

		private async Task ConfigureEmail(NpoProfile model)
		{
			try
			{
				var npo = await _npoService.GetById(model.NpoId);
				AccessStatusEnum approvalStatus = (AccessStatusEnum)npo.ApprovalStatusId;

				switch (approvalStatus)
				{
					case AccessStatusEnum.Pending:
						var newOrganisationalApproval = EmailTemplateFactory
								.Create(EmailTemplateTypeEnum.NewOrganisationApproval)
								.Get<NewOrganisationApprovalEmailTemplate>()
								.Init(npo);

						var pendingOrganisationApproval = EmailTemplateFactory
								.Create(EmailTemplateTypeEnum.PendingOrganisationApproval)
								.Get<PendingOrganisationApprovalEmailTemplate>()
								.Init(npo);

						await newOrganisationalApproval.SubmitToQueue();
						await pendingOrganisationApproval.SubmitToQueue();
						break;
				}

				await _emailService.SendEmailFromQueue();
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside NpoProfileConfigureEmail action: {ex.Message} Inner Exception: {ex.InnerException}");
			}
		}

		[HttpGet("facilities/npoProfileId/{npoProfileId}", Name = "GetFacilitiesByNpoProfileId")]
		public async Task<IActionResult> GetFacilitiesByNpoProfileId(int npoProfileId)
		{
			try
			{
				var results = await _npoProfileService.GetFacilitiesByNpoProfileId(npoProfileId);
				return Ok(results);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside GetFacilitiesByNpoProfileId action: {ex.Message} Inner Exception: {ex.InnerException}");
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

        [HttpGet("npoFacilities/npoId/{npoId}", Name = "GetFacilitiesByNpoId")]
        public async Task<IActionResult> GetFacilitiesByNpoId(int npoId)
        {
            try
            {
				var npoProfile = await _npoProfileService.GetByNpoId(npoId);
                var results = await _npoProfileService.GetFacilitiesByNpoProfileId(npoProfile.Id);
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetFacilitiesByNpoProfileId action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("facilities", Name = "CreateFacilityMapping")]
		public async Task<IActionResult> CreateFacilityMapping([FromBody] NpoProfileFacilityList model)
		{
			try
			{
				await _npoProfileService.Create(model, base.GetUserIdentifier());
				return Ok(model);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside CreateFacilityMapping action: {ex.Message} Inner Exception: {ex.InnerException}");
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

		[HttpPut("facilities", Name = "UpdateFacilityMapping")]
		public async Task<IActionResult> UpdateFacilityMapping([FromBody] NpoProfileFacilityList model)
		{
			try
			{
				await _npoProfileService.Update(model, base.GetUserIdentifier());
				return Ok(model);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside UpdateFacilityMapping action: {ex.Message} Inner Exception: {ex.InnerException}");
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

        [HttpGet("services-rendered/{source}/npoProfileId/{npoProfileId}", Name = "GetServicesRenderedByNpoProfileId")]
        public async Task<IActionResult> GetServicesRenderedByNpoProfileId(string source, int npoProfileId)
        {
            try
            {
                var results = await _npoProfileService.GetServicesRenderedByNpoProfileId(source, npoProfileId);
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetServicesRenderedByNpoProfileId action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpPost("services-rendered", Name = "CreateServicesRendered")]
        public async Task<IActionResult> CreateServicesRendered([FromBody] ServicesRendered model)
        {
            try
            {
                await _npoProfileService.Create(model, base.GetUserIdentifier());
                return Ok(model);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateServicesRendered action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpPut("services-rendered", Name = "UpdateServicesRendered")]
        public async Task<IActionResult> UpdateServicesRendered([FromBody] ServicesRendered model)
        {
            try
            {
                await _npoProfileService.Update(model, base.GetUserIdentifier());
                return Ok(model);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateServicesRendered action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("projImpl/npoProfileId/{npoProfileId}", Name = "GetProjImplByNpoProfileId")]
        public async Task<IActionResult> GetProjImplByNpoProfileId(int npoProfileId)
        {
            try
            {
                var results = await _npoProfileService.GetProjImplByNpoProfileId(npoProfileId);
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetBankDetailsByNpoProfileId action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("projImpl/appDetailId/{appDetailId}", Name = "GetProjImplByAppDetailId")]
        public async Task<IActionResult> GetProjImplByAppDetailId(int appDetailId)
        {
            try
            {
                var results = await _npoProfileService.GetProjImplByAppDetailId(appDetailId);
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetBankDetailsByNpoProfileId action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("bank-detail/npoProfileId/{npoProfileId}", Name = "GetBankDetailsByNpoProfileId")]
		public async Task<IActionResult> GetBankDetailsByNpoProfileId(int npoProfileId)
		{
			try
			{
				var results = await _npoProfileService.GetBankDetailsByNpoProfileId(npoProfileId);
				return Ok(results);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside GetBankDetailsByNpoProfileId action: {ex.Message} Inner Exception: {ex.InnerException}");
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

		[HttpPost("createBankDetail", Name = "CreateBankDetail")]
		public async Task<IActionResult> CreateBankDetail([FromBody] BankDetail model)
		{
			try
			{
				await _npoProfileService.Create(model, base.GetUserIdentifier());
				return Ok(model);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside CreateBankDetail action: {ex.Message} Inner Exception: {ex.InnerException}");
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

		[HttpPut("updateBankDetail", Name = "UpdateBankDetail")]
		public async Task<IActionResult> UpdateBankDetail([FromBody] BankDetail model)
		{
			try
			{
				await _npoProfileService.Update(model, base.GetUserIdentifier());
				return Ok(model);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside UpdateBankDetail action: {ex.Message} Inner Exception: {ex.InnerException}");
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

		[HttpPut("updateProjImpl", Name = "UpdateProjImpl")]
		public async Task<IActionResult> UpdateProjImpl([FromBody] ProjectImplementation model)
		{
			try
			{
				await _npoProfileService.Update(model, base.GetUserIdentifier());
				return Ok(model);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside ProjectImplementation action: {ex.Message} Inner Exception: {ex.InnerException}");
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

        [HttpPut("updateFinancialMattersOthers/applicationId/{applicationId}", Name = "updateFinancialMattersOthers")]
        public async Task<IActionResult> updateFinancialMattersOthers([FromBody] FinancialMattersOthers model, string applicationId)
        {
            await _npoProfileService.UpdateOthers(model, base.GetUserIdentifier(), applicationId);
            return Ok(model);
        }

        [HttpPut("updateFinancialMattersExpenditure/applicationId/{applicationId}", Name = "updateFinancialMattersExpenditure")]
        public async Task<IActionResult> updateFinancialMattersExpenditure([FromBody] FinancialMattersExpenditure model, string applicationId)
        {
            await _npoProfileService.UpdateExpenditure(model, base.GetUserIdentifier(), applicationId);
            return Ok(model);
        }


        [HttpPut("updateFinancialMattersIncome/applicationId/{applicationId}", Name = "updateFinancialMattersIncome")]
        public async Task<IActionResult> updateFinancialMattersIncome([FromBody] FinancialMattersIncome model, string applicationId)
        {
            await _npoProfileService.UpdateIncome(model, base.GetUserIdentifier(), applicationId);
            return Ok();
        }


        [HttpPut("updatePreviousYearFinance/npoProfileId/{npoProfileId}", Name = "UpdatePreviousYearFinance")]
        public async Task<IActionResult> UpdatePreviousYearFinance([FromBody] PreviousYearFinance model, string npoProfileId)
        {
			await _npoProfileService.Update(model, base.GetUserIdentifier(), npoProfileId);
			return Ok(model);
        }


        [HttpGet("getFinancialMattersIncomeByNpoProfileId/npoProfileId/{npoProfileId}", Name = "GetIncomeByNpoProfileIdAsync")]
        public async Task<IActionResult> GetIncomeByNpoProfileIdAsync(int npoProfileId)
        {
            try
            {
                var results = await _npoProfileService.GetIncomeByNpoProfileIdAsync(npoProfileId);
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetIncomeByNpoProfileIdAsync action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("getFinancialMattersExpenditureByNpoProfileId/npoProfileId/{npoProfileId}", Name = "GetExpenditureByNpoProfileIdAsync")]
        public async Task<IActionResult> GetExpenditureByNpoProfileIdAsync(int npoProfileId)
        {
            try
            {
                var results = await _npoProfileService.GetExpenditureByNpoProfileIdAsync(npoProfileId);
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetExpenditureByNpoProfileIdAsync action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("getFinancialMattersOthersByNpoProfileId/npoProfileId/{npoProfileId}", Name = "GetOthersByNpoProfileIdAsync")]
        public async Task<IActionResult> GetOthersByNpoProfileIdAsync(int npoProfileId)
        {
            try
            {
                var results = await _npoProfileService.GetOthersByNpoProfileIdAsync(npoProfileId);
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetOthersByNpoProfileIdAsync action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        [HttpGet("getPreviousYearFinanceByNpoProfileId/npoProfileId/{npoProfileId}", Name = "GetPreviousYearFinanceByNpoProfileId")]
        public async Task<IActionResult> GetPreviousYearFinanceByNpoProfileId(int npoProfileId)
        {
            try
            {
                var results = await _npoProfileService.GetByNpoProfileIdAsync(npoProfileId);
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetPreviousYearFinanceByNpoProfileId action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

		[HttpPost("previous-financial-year/fundingApplicationId/{fundingApplicationId}", Name = "CreatePreviousYearData")]
		public async Task<IActionResult> CreatePreviousYearData(int fundingApplicationId)
		{
			try
			{
				await _npoProfileService.CreatePreviousYearFinance(fundingApplicationId, base.GetUserIdentifier());
				return Ok();
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside CreatePreviousYearData action: {ex.Message} Inner Exception: {ex.InnerException}");
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

		[HttpPut("deleteById/id/{id}", Name = "DeleteById")]
        public async Task<IActionResult> DeleteById(int id)
        {
            try
            {
                await _npoProfileService.DeleteById(id, base.GetUserIdentifier());
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteById action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("deleteIncomeById/id/{id}", Name = "DeleteIncomeById")]
        public async Task<IActionResult> DeleteIncomeById(int id)
        {
            try
            {
                await _npoProfileService.DeleteIncomeById(id, base.GetUserIdentifier());
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteIncomeById action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("deleteExpenditureById/id/{id}", Name = "DeleteExpenditureById")]
        public async Task<IActionResult> DeleteExpenditureById(int id)
        {
            try
            {
                await _npoProfileService.DeleteExpenditureById(id, base.GetUserIdentifier());
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteExpenditureById action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("deleteOthersById/id/{id}", Name = "DeleteOthersById")]
        public async Task<IActionResult> DeleteOthersById(int id)
        {
            try
            {
               await _npoProfileService.DeleteOthersById(id, base.GetUserIdentifier());
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteOthersById action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("deleteBankDetailById/id/{id}", Name = "DeleteBankDetailById")]
        public async Task<IActionResult> DeleteBankDetailById(int id)
        {
            try
            {
                await _npoProfileService.DeleteBankDetailById(id, base.GetUserIdentifier());
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteBankDetailById action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("deleteProjImplById/id/{id}", Name = "DeleteProjectImplementationById")]
        public async Task<IActionResult> DeleteProjectImplementationById(int id)
        {
            try
            {
                var results = await _npoProfileService.DeleteProjectImplementationById(id);
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteProjectImplementationById action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("getSourceOfInformationById/npoProfileId/{npoProfileId}", Name = "GetSourceOfInformationById")]
		public async Task<IActionResult> GetSourceOfInformationById(int npoProfileId)
		{
			try
			{
				var results = await _npoProfileService.GetSourceOfInformationById(npoProfileId);
				return Ok(results);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside GetSourceOfInformationById action: {ex.Message} Inner Exception: {ex.InnerException}");
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

		[HttpGet("getAffiliatedOrganisationById/npoProfileId/{npoProfileId}", Name = "GetAffiliatedOrganisationById")]
		public async Task<IActionResult> GetAffiliatedOrganisationById(int npoProfileId)
		{
			try
			{
				var results = await _npoProfileService.GetAffiliatedOrganisationById(npoProfileId);
				return Ok(results);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside GetAffiliatedOrganisationById action: {ex.Message} Inner Exception: {ex.InnerException}");
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

        [HttpPut("updateAffiliatedOrganisationData/npoProfileId/{npoProfileId}", Name = "UpdateAffiliatedOrganisationData")]
        public async Task<IActionResult> UpdateAffiliatedOrganisationData([FromBody] AffiliatedOrganisationInformation model, string npoProfileId)
        {
            await _npoProfileService.Update(model, base.GetUserIdentifier(), npoProfileId);
            return Ok(model);
        }

        [HttpPost("updateSourceOfInformation/npoProfileId/{npoProfileId}", Name = "UpdateSourceOfInformation")]
        public async Task<IActionResult> UpdateSourceOfInformation([FromBody] SourceOfInformation model, string npoProfileId)
        {
            //SourceOfInformation sourceOfInformation = JsonConvert.DeserializeObject<SourceOfInformation>(Convert.ToString(entity));
            await _npoProfileService.Update(model, base.GetUserIdentifier(), npoProfileId);
            return Ok(model);
        }

		[HttpGet("auditor-affiliation/entityId/{entityId}", Name = "GetAuditorOrAffiliations")]
		public async Task<IActionResult> GetAuditorOrAffiliations(int entityId)
		{
			try
			{
				var results = await _npoProfileService.GetAuditorOrAffiliations(entityId);
				return Ok(results);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside GetAuditorOrAffiliations action: {ex.Message} Inner Exception: {ex.InnerException}");
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

		[HttpPost("auditor-affiliation", Name = "CreateAuditorOrAffiliation")]
		public async Task<IActionResult> CreateAuditorOrAffiliation([FromBody] AuditorOrAffiliation model)
		{
			try
			{
				await _npoProfileService.CreateAuditorOrAffiliation(model, base.GetUserIdentifier());
				return Ok(model);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside CreateAuditorOrAffiliation action: {ex.Message} Inner Exception: {ex.InnerException}");
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

		[HttpPut("auditor-affiliation", Name = "UpdateAuditorOrAffiliation")]
		public async Task<IActionResult> UpdateAuditorOrAffiliation([FromBody] AuditorOrAffiliation model)
		{
			try
			{
				await _npoProfileService.UpdateAuditorOrAffiliation(model, base.GetUserIdentifier());
				return Ok(model);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside UpdateAuditorOrAffiliation action: {ex.Message} Inner Exception: {ex.InnerException}");
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

		[HttpGet("staff-member-profile/npoProfileId/{npoProfileId}", Name = "GetStaffMemberProfiles")]
		public async Task<IActionResult> GetStaffMemberProfiles(int npoProfileId)
		{
			try
			{
				var results = await _npoProfileService.GetStaffMemberProfiles(npoProfileId);
				return Ok(results);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside GetStaffMemberProfiles action: {ex.Message} Inner Exception: {ex.InnerException}");
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

		[HttpPut("staff-member-profile", Name = "UpdateStaffMemberProfile")]
		public async Task<IActionResult> UpdateStaffMemberProfile([FromBody] StaffMemberProfile model)
		{
			try
			{
				if (model.Id == 0)
					await _npoProfileService.CreateStaffMemberProfile(model, base.GetUserIdentifier());
				else
					await _npoProfileService.UpdateStaffMemberProfile(model, base.GetUserIdentifier());

				return Ok(model);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside UpdateStaffMemberProfile action: {ex.Message} Inner Exception: {ex.InnerException}");
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

		[HttpPost("financial-matters-income/fundingApplicationId/{fundingApplicationId}", Name = "CreateFinancialMattersIncome")]
		public async Task<IActionResult> CreateFinancialMattersIncome(int fundingApplicationId)
		{
			try
			{
				await _npoProfileService.CreateFinancialMattersIncome(fundingApplicationId, base.GetUserIdentifier());
				return Ok();
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside CreateFinancialMattersIncome action: {ex.Message} Inner Exception: {ex.InnerException}");
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

		[HttpPost("financial-matters-expenditure/fundingApplicationId/{fundingApplicationId}", Name = "CreateFinancialMattersExpenditure")]
		public async Task<IActionResult> CreateFinancialMattersExpenditure(int fundingApplicationId)
		{
			try
			{
				await _npoProfileService.CreateFinancialMattersExpenditure(fundingApplicationId, base.GetUserIdentifier());
				return Ok();
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside CreateFinancialMattersExpenditure action: {ex.Message} Inner Exception: {ex.InnerException}");
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

		[HttpPost("financial-matters-other/fundingApplicationId/{fundingApplicationId}", Name = "CreateFinancialMattersOther")]
		public async Task<IActionResult> CreateFinancialMattersOther(int fundingApplicationId)
		{
			try
			{
				await _npoProfileService.CreateFinancialMattersOther(fundingApplicationId, base.GetUserIdentifier());
				return Ok();
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside CreateFinancialMattersOther action: {ex.Message} Inner Exception: {ex.InnerException}");
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

        [HttpPost("approve/{npoProfileId}", Name = "ApproveNpoProfile")]
        public async Task<IActionResult> ApproveNpoProfile(int npoProfileId)
        {
            await _npoProfileService.ApproveNpoProfile(npoProfileId, base.GetUserIdentifier());
            return Ok(npoProfileId);
        }

        [HttpPost("reject/{npoProfileId}", Name = "RejectNpoProfile")]
        public async Task<IActionResult> RejectNpoProfile(int npoProfileId)
        {
            await _npoProfileService.RejectNpoProfile(npoProfileId, base.GetUserIdentifier());
            return Ok(npoProfileId);
        }

        [HttpPost("submitProfile/{npoProfileId}", Name = "SubmitProfileNpoProfile")]
        public async Task<IActionResult> SubmitProfileNpoProfile(int npoProfileId)
        {
            await _npoProfileService.SubmitProfileNpoProfile(npoProfileId, base.GetUserIdentifier());
            return Ok(npoProfileId);
        }
        #endregion
    }
}
