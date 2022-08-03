﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NPOMS.Domain.Entities;
using NPOMS.Domain.Enumerations;
using NPOMS.Services.Email;
using NPOMS.Services.Email.EmailTemplates;
using NPOMS.Services.Interfaces;
using System;
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

		#endregion
	}
}
