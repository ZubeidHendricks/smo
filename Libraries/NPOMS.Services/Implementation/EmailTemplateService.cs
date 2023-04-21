using AutoMapper;
using Microsoft.Extensions.Logging;
using NPOMS.Domain.Core;
using NPOMS.Domain.Enumerations;
using NPOMS.Domain.ResourceParameters;
using NPOMS.Repository.Interfaces.Core;
using NPOMS.Services.Helpers.Paging;
using NPOMS.Services.Interfaces;
using NPOMS.Services.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Services.Implementation
{
	public class EmailTemplateService : IEmailTemplateService
	{
		#region Fields

		private ILogger<EmailTemplateService> _logger;
		private IMapper _mapper;
		private IEmailTemplateRepository _emailTemplateRepository;
		private IUserRepository _userRepository;

		#endregion

		#region Constructors

		public EmailTemplateService(
			ILogger<EmailTemplateService> logger,
			IMapper mapper,
			IEmailTemplateRepository emailTemplateRepository,
			IUserRepository userRepository)
		{
			_logger = logger;
			_mapper = mapper;
			_emailTemplateRepository = emailTemplateRepository;
			_userRepository = userRepository;
		}

		#endregion

		#region Methods

		public async Task<PagedList<EmailTemplateViewModel>> GetAll(EmailTemplateResourceParameters emailTemplateResourceParameters)
		{
			try
			{
				if (emailTemplateResourceParameters == null)
				{
					throw new ArgumentNullException(nameof(emailTemplateResourceParameters));
				}

				var query = _emailTemplateRepository.GetEntities();

				var pageList = await PagedList<EmailTemplate>.Create(query, emailTemplateResourceParameters.PageNumber, emailTemplateResourceParameters.PageSize);

				var viewModelItems = _mapper.Map<List<EmailTemplateViewModel>>(pageList.Items);

				return PagedList<EmailTemplateViewModel>.CreateForView(viewModelItems, emailTemplateResourceParameters.PageNumber, emailTemplateResourceParameters.PageSize);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside GetAllEmailTemplates action: {ex.Message} Inner Exception: {ex.InnerException}");
				throw;
			}
		}

		public async Task<EmailTemplateViewModel> GetById(int emailTemplateId)
		{
			try
			{
				var emailTemplate = await _emailTemplateRepository.GetById(emailTemplateId);

				if (emailTemplate == null)
				{
					throw new ArgumentNullException(nameof(emailTemplate));
				}

				return _mapper.Map<EmailTemplateViewModel>(emailTemplate);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside GetById action: {ex.Message} Inner Exception: {ex.InnerException}");
				throw;
			}
		}

		public async Task<EmailTemplateViewModel> GetByType(EmailTemplateTypeEnum emailTemplateTypeEnum)
		{
			try
			{
				string emailTypeName = emailTemplateTypeEnum.ToString();
				var emailTemplate = await _emailTemplateRepository.GetByType(emailTemplateTypeEnum);

				if (emailTemplate == null)
				{
					throw new ArgumentNullException(nameof(emailTemplate));
				}

				var viewModel = _mapper.Map<EmailTemplateViewModel>(emailTemplate);
				viewModel.EmailAccount = _mapper.Map<EmailAccountViewModel>(emailTemplate.EmailAccount);
				return viewModel;
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside GetByType action: {ex.Message} Inner Exception: {ex.InnerException}");
				throw;
			}
		}

		public async Task Create(EmailTemplateViewModel viewModel)
		{
			try
			{
				if (viewModel == null)
					throw new ArgumentNullException(nameof(viewModel));

				EmailTemplate entity = new EmailTemplate()
				{
					Body = viewModel.Body,
					Description = viewModel.Description,
					EmailAccountId = viewModel.EmailAccountId,
					IsActive = viewModel.IsActive,
					Name = viewModel.Name,
					Subject = viewModel.Subject
				};

				await _emailTemplateRepository.CreateEntity(entity);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside CreateEmailTemplate action: {ex.Message} Inner Exception: {ex.InnerException}");
				throw;
			}
		}

		public async Task Update(EmailTemplateViewModel viewModel, string userIdentifier)
		{
			try
			{
				var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

				if (viewModel == null)
					throw new ArgumentNullException(nameof(viewModel));

				var entity = await _emailTemplateRepository.GetById(viewModel.Id);

				if (entity != null)
				{
					entity.Description = viewModel.Description;
					entity.Body = viewModel.Body;
					entity.EmailAccountId = viewModel.EmailAccountId;
					entity.IsActive = viewModel.IsActive;
					entity.Name = entity.Name;
					entity.Subject = viewModel.Subject;

					await _emailTemplateRepository.UpdateEntity(entity, loggedInUser.Id);
				}
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside UpdateEmailTemplate action: {ex.Message} Inner Exception: {ex.InnerException}");
				throw;
			}
		}

		public Task Delete(EmailTemplateViewModel viewModel)
		{
			throw new NotImplementedException();
		}

		#endregion
	}
}
