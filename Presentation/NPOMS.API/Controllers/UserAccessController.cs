using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NPOMS.Domain.Enumerations;
using NPOMS.Domain.Mapping;
using NPOMS.Services.Email;
using NPOMS.Services.Email.EmailTemplates;
using NPOMS.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace NPOMS.API.Controllers
{
	[Route("api/user-access")]
	[ApiController]
	public class UserAccessController : ExternalBaseController
	{
		#region Fields

		private ILogger<UserAccessController> _logger;
		private IUserNpoService _userNpoService;
		private IEmailService _emailService;
		private readonly IMapper _mapper;

		#endregion

		#region Constructors

		public UserAccessController(
			ILogger<UserAccessController> logger,
			IUserNpoService userNpoService,
			IEmailService emailService,
			IMapper mapper)
		{
			_logger = logger;
			_userNpoService = userNpoService;
			_emailService = emailService;
			_mapper = mapper;
		}

		#endregion

		#region Methods

		[HttpGet(Name = "GetAllUserNpoMappings")]
		public async Task<IActionResult> GetAllUserNpoMappings()
		{
			try
			{
				var results = await _userNpoService.Get(base.GetUserIdentifier());
				return Ok(results);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside GetAllUserNpoMappings action: {ex.Message} Inner Exception: {ex.InnerException}");
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

		[HttpPost(Name = "CreateUserNpoMapping")]
		public async Task<IActionResult> CreateUserNpoMapping([FromBody] UserNpo model)
		{
			try
			{
				var mapping = await _userNpoService.GetByUserIdAndNpoId(model.UserId, model.NpoId);

				if (mapping == null)
					await _userNpoService.Create(model, base.GetUserIdentifier());
				else
				{
					await _userNpoService.UpdateEntity(mapping, base.GetUserIdentifier());
					model = _mapper.Map<UserNpo>(mapping);
				}

				await ConfigureEmail(model);
				return Ok(model);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside CreateUserNpoMapping action: {ex.Message} Inner Exception: {ex.InnerException}");
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

		[HttpPut(Name = "UpdateUserNpoMapping")]
		public async Task<IActionResult> UpdateUserNpoMapping([FromBody] UserNpo model)
		{
			try
			{
				await _userNpoService.Update(model, base.GetUserIdentifier());
				await ConfigureEmail(model);
				return Ok(model);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside UpdateUserNpoMapping action: {ex.Message} Inner Exception: {ex.InnerException}");
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

		private async Task ConfigureEmail(UserNpo model)
		{
			try
			{
				AccessStatusEnum status = (AccessStatusEnum)model.AccessStatusId;

				switch (status)
				{
					case AccessStatusEnum.Pending:
						var newAccessRequest = EmailTemplateFactory
								.Create(EmailTemplateTypeEnum.NewAccessRequest)
								.Get<NewAccessRequestEmailTemplate>()
								.Init(model);

						var accessRequestPending = EmailTemplateFactory
								.Create(EmailTemplateTypeEnum.AccessRequestPending)
								.Get<AccessRequestPendingEmailTemplate>()
								.Init(model);

						await newAccessRequest.SubmitToQueue();
						await accessRequestPending.SubmitToQueue();
						break;
					case AccessStatusEnum.Approved:
						var accessRequestApproved = EmailTemplateFactory
								.Create(EmailTemplateTypeEnum.AccessRequestApproved)
								.Get<AccessRequestApprovedEmailTemplate>()
								.Init(model);

						await accessRequestApproved.SubmitToQueue();
						break;
					case AccessStatusEnum.Rejected:
						var accessRequestRejected = EmailTemplateFactory
								.Create(EmailTemplateTypeEnum.AccessRequestRejected)
								.Get<AccessRequestRejectedEmailTemplate>()
								.Init(model);

						await accessRequestRejected.SubmitToQueue();
						break;
				}

				await _emailService.SendEmailFromQueue();
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside UserAccessConfigureEmail action: {ex.Message} Inner Exception: {ex.InnerException}");
			}
		}

		#endregion
	}
}
