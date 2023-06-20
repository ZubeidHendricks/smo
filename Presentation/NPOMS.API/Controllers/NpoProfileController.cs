using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Graph;
using NPOMS.Domain.Entities;
using NPOMS.Domain.Enumerations;
using NPOMS.Domain.Mapping;
using NPOMS.Services.Email;
using NPOMS.Services.Email.EmailTemplates;
using NPOMS.Services.Interfaces;
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

		#endregion

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

		[HttpGet("services-rendered/npoProfileId/{npoProfileId}", Name = "GetServicesRenderedByNpoProfileId")]
		public async Task<IActionResult> GetServicesRenderedByNpoProfileId(int npoProfileId)
		{
			try
			{
				var results = await _npoProfileService.GetServicesRenderedByNpoProfileId(npoProfileId);
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

		[HttpPut("bank-detail", Name = "UpdateBankDetail")]
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

        [HttpPut("updatePreviousYearFinance/npoProfileId/{npoProfileId}", Name = "UpdatePreviousYearFinance")]
        public async Task<IActionResult> UpdatePreviousYearFinance([FromBody] List<PreviousYearFinance> model, string npoProfileId)
        {
			await _npoProfileService.Update(model, base.GetUserIdentifier(), npoProfileId);
			return Ok(model);
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
                _logger.LogError($"Something went wrong inside GetBankDetailsByNpoProfileId action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("deleteById/id/{id}", Name = "DeleteById")]
        public async Task<IActionResult> DeleteById(int id)
        {
            try
            {
                var results = await _npoProfileService.DeleteById(id);
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetBankDetailsByNpoProfileId action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("deleteBankDetailById/id/{id}", Name = "DeleteBankDetailById")]
        public async Task<IActionResult> DeleteBankDetailById(int id)
        {
            try
            {
                var results = await _npoProfileService.DeleteBankDetailById(id);
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetBankDetailsByNpoProfileId action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        #endregion
    }
}
