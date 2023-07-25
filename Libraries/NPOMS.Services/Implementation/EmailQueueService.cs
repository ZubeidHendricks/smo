using AutoMapper;
using Microsoft.Extensions.Logging;
using NPOMS.Domain.Core;
using NPOMS.Domain.ResourceParameters;
using NPOMS.Repository.Interfaces.Core;
using NPOMS.Services.Helpers.Paging;
using NPOMS.Services.Interfaces;
using NPOMS.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NPOMS.Services.Implementation
{
	public class EmailQueueService : IEmailQueueService
	{
		#region Fields

		private ILogger<EmailQueueService> _logger;
		private IMapper _mapper;
		private IEmailQueueRepository _emailQueueRepository;

		#endregion

		#region Constructors

		public EmailQueueService(
			ILogger<EmailQueueService> logger,
			IMapper mapper,
			IEmailQueueRepository emailQueueRepository
			)
		{
			_logger = logger;
			_mapper = mapper;
			_emailQueueRepository = emailQueueRepository;
		}

		#endregion

		#region Methods

		public IQueryable<EmailQueue> Get(EmailQueueResourceParameters emailQueueResourceParameters)
		{
			try
			{
				if (emailQueueResourceParameters == null)
				{
					throw new ArgumentNullException(nameof(emailQueueResourceParameters));
				}

				var query = _emailQueueRepository.GetEntities();

				if (!emailQueueResourceParameters.EmailTemplateIsActive)
				{
					query = query.Where(x => x.EmailTemplate.IsActive == false);
				}

				if (emailQueueResourceParameters.OnlyNotSent)
				{
					query = query.Where(x => x.SentDateTime.HasValue == false);
				}

				return query;
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside GetAll action: {ex.Message} Inner Exception: { ex.InnerException}");
				throw;
			}
		}

		public async Task<PagedList<EmailQueueViewModel>> GetAll(EmailQueueResourceParameters emailQueueResourceParameters)
		{
			try
			{
				var query = this.Get(emailQueueResourceParameters).OrderByDescending(x => x.CreatedDateTime);

				var pageList = await PagedList<EmailQueue>.Create(query, emailQueueResourceParameters.PageNumber, emailQueueResourceParameters.PageSize);

				var viewModelItems = _mapper.Map<List<EmailQueueViewModel>>(pageList.Items);

				return PagedList<EmailQueueViewModel>.CreateForView(viewModelItems, emailQueueResourceParameters.PageNumber, emailQueueResourceParameters.PageSize);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside GetAllEmailQueues action: {ex.Message} Inner Exception: { ex.InnerException}");
				throw;
			}
		}

		public async Task<EmailQueueViewModel> GetById(int emailQueueId)
		{
			try
			{
				var emailQueue = await _emailQueueRepository.GetById(emailQueueId);

				if (emailQueue == null)
				{
					throw new ArgumentNullException(nameof(emailQueue));
				}

				return _mapper.Map<EmailQueueViewModel>(emailQueue);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside GetById action: {ex.Message} Inner Exception: { ex.InnerException}");
				throw;
			}
		}

		public async Task Create(EmailQueue entity)
		{
			try
			{
				if (entity == null)
					throw new ArgumentNullException(nameof(entity));

				await _emailQueueRepository.CreateEntity(entity);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside CreateEmailQueue action: {ex.Message} Inner Exception: { ex.InnerException}");
				throw;
			}
		}

		public async Task Update(EmailQueueViewModel viewModel)
		{
			try
			{
				if (viewModel == null)
					throw new ArgumentNullException(nameof(viewModel));

				var entity = await _emailQueueRepository.GetById(viewModel.Id);

				if (entity != null)
				{
					entity.CreatedDateTime = viewModel.CreatedDateTime;
					entity.SentDateTime = viewModel.SentDateTime;
					entity.Message = viewModel.Message;
					entity.RecipientEmail = viewModel.RecipientEmail;
					entity.RecipientName = viewModel.RecipientName;
					entity.Subject = viewModel.Subject;

					await _emailQueueRepository.UpdateEntity(entity, 1);
				}
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside UpdateEmailQueue action: {ex.Message} Inner Exception: { ex.InnerException}");
				throw;
			}
		}

		public Task CreateEmailQueue(EmailQueue entity)
		{
			throw new NotImplementedException();
		}

		#endregion
	}
}
