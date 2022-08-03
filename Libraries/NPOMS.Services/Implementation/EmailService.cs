using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NPOMS.Domain.ResourceParameters;
using NPOMS.Services.Interfaces;
using NPOMS.Services.Models;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace NPOMS.Services.Implementation
{
	public class EmailService : IEmailService
	{
		#region Fields

		private ILogger<EmailService> _logger;
		private IMapper _mapper;
		private IEmailQueueService _emailQueueService;

		#endregion

		#region Constructors

		public EmailService(
			ILogger<EmailService> logger,
			IMapper mapper,
			IEmailQueueService emailQueueService
			)
		{
			_logger = logger;
			_mapper = mapper;
			_emailQueueService = emailQueueService;
		}

		#endregion

		#region Methods

		public async Task SendEmailFromQueue()
		{
			try
			{
				var emailQueueResourceParameters = new EmailQueueResourceParameters();
				emailQueueResourceParameters.OnlyNotSent = true;

				var queuedEmails = _emailQueueService.Get(emailQueueResourceParameters).ToListAsync().Result;

				var httpClient = PrepareClient();

				foreach (var queuedEmail in queuedEmails)
				{
					using (var request = new HttpRequestMessage(new HttpMethod("POST"), queuedEmail.EmailTemplate.EmailAccount.Host))
					{
						request.Headers.TryAddWithoutValidation("accept", "*/*");

						var content = "\"to\":\"{0}\",\"from\":\"{1}\",\"from_text\":\"{2}\",\"subject\":\"{3}\",\"body\":\"{4}\",\"attachments\":[]";
						content = string.Format(content, queuedEmail.RecipientEmail, queuedEmail.EmailTemplate.EmailAccount.FromEmail, queuedEmail.EmailTemplate.EmailAccount.FromDisplayName, queuedEmail.Subject, queuedEmail.Message.Replace("\"", "'"));
						request.Content = new StringContent("{" + content + "}");
						request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json-patch+json");

						var response = await _httpClient.SendAsync(request);

						if (response.StatusCode == System.Net.HttpStatusCode.OK)
						{
							queuedEmail.SentDateTime = DateTime.Now;

							var viewModel = _mapper.Map<EmailQueueViewModel>(queuedEmail);
							await _emailQueueService.Update(viewModel);
						}
						else
						{
							_logger.LogError($"The following email cannot be send: {content}. Sending Email Failed");
						}
					}
				}
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside SendEmailFromQueue action: {ex.Message} Inner Exception: { ex.InnerException}");
				throw;
			}
		}

		private static HttpClient _httpClient = null;

		private static HttpClient PrepareClient()
		{
			if (_httpClient == null)
			{
				_httpClient = new HttpClient();
				_httpClient.DefaultRequestHeaders.Accept.Clear();
			}

			return _httpClient;
		}

		#endregion
	}
}
