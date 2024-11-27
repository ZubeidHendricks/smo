using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NPOMS.Domain.Entities;
using NPOMS.Domain.Enumerations;
using NPOMS.Domain.Mapping;
using NPOMS.Services.Email;
using NPOMS.Services.Email.EmailTemplates;
using NPOMS.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace NPOMS.API.Controllers
{
	[Route("api/npos")]
	[ApiController]
	public class NpoController : ExternalBaseController
	{
		#region Fields

		private ILogger<NpoController> _logger;
		private INpoService _npoService;
		private IUserNpoService _userNpoService;
		private INpoProfileService _npoProfileService;
		private IEmailService _emailService;

		#endregion

		#region Constructors

		public NpoController(
			ILogger<NpoController> logger,
			INpoService npoService,
			IUserNpoService userNpoService,
			INpoProfileService npoProfileService,
			IEmailService emailService
			)
		{
			_logger = logger;
			_npoService = npoService;
			_userNpoService = userNpoService;
			_npoProfileService = npoProfileService;
			_emailService = emailService;
		}

		#endregion

		#region Methods

		[HttpGet("quick-captures/access-status/{accessStatus}", Name = "GetAllQuickCaptures")]
		public async Task<IActionResult> GetAllQuickCaptures(AccessStatusEnum accessStatus)
		{
			try
			{
				var results = await _npoService.GetQuickCaptures(base.GetUserIdentifier(), accessStatus);
				return Ok(results);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside GetAllQuickCaptures action: {ex.Message} Inner Exception: {ex.InnerException}");
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

		[HttpGet("access-status/{accessStatus}", Name = "GetAllNpos")]
		public async Task<IActionResult> GetAllNpos(AccessStatusEnum accessStatus)
		{
			try
			{
				var results = await _npoService.Get(base.GetUserIdentifier(), accessStatus);
				return Ok(results);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside GetAllNpos action: {ex.Message} Inner Exception: { ex.InnerException}");
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

        [HttpGet("email/{email}", Name = "GetAllNposPublic")]
        public async Task<IActionResult> GetAllNposPublic(string email)
        {
            try
            {
                var results = await _npoService.Get(email);
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllNpos action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("NpoId/{NpoId}", Name = "GetNpoById")]
		public async Task<IActionResult> GetNpoById(int NpoId)
		{
			try
			{
				var results = await _npoService.GetById(NpoId);
				return Ok(results);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside GetNpoById action: {ex.Message} Inner Exception: { ex.InnerException}");
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

		[HttpGet("name/{name}", Name = "GetNpoByName")]
		public async Task<IActionResult> GetNpoByName(string name)
		{
			try
			{
				var results = await _npoService.Search(name);
				return Ok(results);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside GetNpoByName action: {ex.Message} Inner Exception: { ex.InnerException}");
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

		[HttpGet("approved-npo/name/{name}", Name = "GetApprovedNpoByName")]
		public async Task<IActionResult> GetApprovedNpoByName(string name)
		{
			try
			{
				var results = await _npoService.SearchApprovedNpo(name);
				return Ok(results);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside GetApprovedNpoByName action: {ex.Message} Inner Exception: {ex.InnerException}");
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

		[HttpPost(Name = "CreateNpo")]
		public async Task<IActionResult> CreateNpo([FromBody] Npo model)
		{
			try
			{
				ClearObjects(model);
				var npo = await _npoService.GetByNameAndOrgTypeId(model.Name, model.OrganisationTypeId, model.CCode);

				if (npo == null)
				{
					model.IsNew = true;
					model.IsActive = true;
					await _npoService.Create(model, base.GetUserIdentifier());

					npo = await _npoService.GetByNameAndOrgTypeId(model.Name, model.OrganisationTypeId, model.CCode);
					await _npoProfileService.Create(new NpoProfile { NpoId = npo.Id, IsActive = true }, base.GetUserIdentifier());
				}
				else
				{
					npo.Name = model.Name;
					npo.OrganisationTypeId = model.OrganisationTypeId;
					npo.CCode = model.CCode;
					npo.RegistrationStatusId = model.RegistrationStatusId;
					npo.RegistrationNumber = model.RegistrationNumber;
					npo.YearRegistered = model.YearRegistered;
					npo.PBONumber = model.PBONumber;
					npo.Section18Receipts = model.Section18Receipts;
					npo.Website = model.Website;
					npo.ContactInformation = model.ContactInformation;
					await _npoService.Update(npo, base.GetUserIdentifier());
				}

				var mapping = new UserNpo
				{
					NpoId = npo.Id,
					AccessStatusId = (int)AccessStatusEnum.Approved
				};

				await _userNpoService.Create(mapping, base.GetUserIdentifier());				
				return Ok(npo);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside CreateNpo action: {ex.Message} Inner Exception: { ex.InnerException}");
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

		[HttpPut(Name = "UpdateNpo")]
		public async Task<IActionResult> UpdateNpo([FromBody] Npo model)
		{
			try
			{
				ClearObjects(model);
				await _npoService.Update(model, base.GetUserIdentifier());
				return Ok(model);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside UpdateNpo action: {ex.Message} Inner Exception: { ex.InnerException}");
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

		private static void ClearObjects(Npo model)
		{
			model.OrganisationType = null;
			model.RegistrationStatus = null;

			foreach (var item in model.ContactInformation)
			{
				item.Title = null;
				item.Position = null;
				item.Race = null;
				item.Gender = null;
				item.Language = null;
			}
		}

		[HttpPut("approval-status", Name = "UpdateNpoApprovalStatus")]
		public async Task<IActionResult> UpdateNpoApprovalStatus([FromBody] Npo model)
		{
			try
			{
				await _npoService.UpdateNpoStatus(model, base.GetUserIdentifier());
				await ConfigureEmail(model);
				return Ok(model);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside UpdateNpoApprovalStatus action: {ex.Message} Inner Exception: { ex.InnerException}");
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

		private async Task ConfigureEmail(Npo model)
		{
			try
			{
				AccessStatusEnum approvalStatus = (AccessStatusEnum)model.ApprovalStatusId;

				switch (approvalStatus)
				{
					case AccessStatusEnum.Approved:
						var approvedOrganisationApproval = EmailTemplateFactory
								.Create(EmailTemplateTypeEnum.ApprovedOrganisationApproval)
								.Get<ApprovedOrganisationApprovalEmailTemplate>()
								.Init(model);

						await approvedOrganisationApproval.SubmitToQueue();
						break;
					case AccessStatusEnum.Rejected:
						var rejectedOrganisationApproval = EmailTemplateFactory
								.Create(EmailTemplateTypeEnum.RejectedOrganisationApproval)
								.Get<RejectedOrganisationApprovalEmailTemplate>()
								.Init(model);

						await rejectedOrganisationApproval.SubmitToQueue();
						break;
				}

				await _emailService.SendEmailFromQueue();
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside NpoConfigureEmail action: {ex.Message} Inner Exception: {ex.InnerException}");
			}
		}

        [HttpGet("generateccode", Name = "GenerateCCode")]
        public async Task<IActionResult> GenerateCCode()
		{


			string ccode = string.Empty;
			ccode = await _npoService.GenerateCCode("C");

			var model = new { TypeCode = "C", CCode = ccode };


            return Ok(model);

        }

		#endregion
	}
}
