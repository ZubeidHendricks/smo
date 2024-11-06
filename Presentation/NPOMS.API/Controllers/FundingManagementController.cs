using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NPOMS.Domain.Enumerations;
using NPOMS.Services.Email.EmailTemplates;
using NPOMS.Services.Email;
using NPOMS.Services.Implementation;
using NPOMS.Services.Interfaces;
using NPOMS.Services.Models.FundingManagement;
using System;
using System.Threading.Tasks;

namespace NPOMS.API.Controllers
{
    [Route("api/funding-management")]
    [ApiController]
    public class FundingManagementController : ExternalBaseController
    {
        #region Fields

        private ILogger<FundingManagementController> _logger;
        private IFundingManagementService _fundingManagementService;
        private IEmailService _emailService;

        #endregion

        #region Constructors

        public FundingManagementController(
            ILogger<FundingManagementController> logger,
            IFundingManagementService fundingManagementService,
            IEmailService emailService
            )
        {
            _logger = logger;
            _fundingManagementService = fundingManagementService;
            _emailService = emailService;
        }

        #endregion

        #region Methods

        [HttpGet(Name = "GetNposForFunding")]
        public async Task<IActionResult> GetNposForFunding()
        {
            try
            {
                var results = await _fundingManagementService.GetNposForFunding(base.GetUserIdentifier());
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetNposForFunding action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost(Name = "CreateFundingCapture")]
        public async Task<IActionResult> CreateFundingCapture([FromBody] FundingCaptureViewModel model)
        {
            try
            {
                var result = await this._fundingManagementService.CreateFundingCapture(model, base.GetUserIdentifier());
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateFundingCapture action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("funding-capture", Name = "UpdateFundingCapture")]
        public async Task<IActionResult> UpdateFundingCapture([FromBody] FundingCaptureViewModel model)
        {
            try
            {
                await this._fundingManagementService.UpdateFundingCapture(model, base.GetUserIdentifier());
                await ConfigureEmail(model);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateFundingCapture action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("id/{id}", Name = "GetFundingById")]
        public async Task<IActionResult> GetFundingById(int id)
        {
            try
            {
                var results = await this._fundingManagementService.GetById(id);
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetFundingById action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("funding-detail", Name = "UpdateFundingDetail")]
        public async Task<IActionResult> UpdateFundingDetail([FromBody] FundingDetailViewModel model)
        {
            try
            {
                await this._fundingManagementService.UpdateFundingDetail(model, base.GetUserIdentifier());
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateFundingDetail action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("service-delivery-area", Name = "UpdateSDA")]
        public async Task<IActionResult> UpdateSDA([FromBody] SDAViewModel model)
        {
            try
            {
                await this._fundingManagementService.UpdateSDA(model, base.GetUserIdentifier());
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateSDA action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("fundingCaptureId/{fundingCaptureId}/frequencyId/{frequencyId}/startDate/{startDate}/amountAwarded/{amountAwarded}", Name = "GeneratePaymentSchedule")]
        public async Task<IActionResult> GeneratePaymentSchedule(int fundingCaptureId, int frequencyId, string startDate, double amountAwarded)
        {
            try
            {
                var results = await this._fundingManagementService.GeneratePaymentSchedule(fundingCaptureId, frequencyId, startDate, amountAwarded);
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GeneratePaymentSchedule action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("payment-schedule", Name = "UpdatePaymentSchedules")]
        public async Task<IActionResult> UpdatePaymentSchedules([FromBody] PaymentScheduleViewModel model)
        {
            try
            {
                await this._fundingManagementService.UpdatePaymentSchedules(model, base.GetUserIdentifier());
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdatePaymentSchedules action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("bank-detail", Name = "UpdateBankDetails")]
        public async Task<IActionResult> UpdateBankDetails([FromBody] BankDetailViewModel model)
        {
            try
            {
                await this._fundingManagementService.UpdateBankDetail(model, base.GetUserIdentifier());
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateBankDetails action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("document", Name = "UpdateDocument")]
        public async Task<IActionResult> UpdateDocument([FromBody] DocumentViewModel model)
        {
            try
            {
                await this._fundingManagementService.UpdateDocument(model, base.GetUserIdentifier());
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateDocument action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("approver-detail", Name = "UpdateApproverDetail")]
        public async Task<IActionResult> UpdateApproverDetail([FromBody] FundingCaptureViewModel model)
        {
            try
            {
                await this._fundingManagementService.UpdateApproverDetail(model, base.GetUserIdentifier());
                await ConfigureEmail(model);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateApproverDetail action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        private async Task ConfigureEmail(FundingCaptureViewModel model)
        {
            try
            {
                StatusEnum status = (StatusEnum)model.StatusId;

                switch (status)
                {
                    case StatusEnum.PendingApproval:
                        //send email to funding capturer
                        var newFunding = EmailTemplateFactory
                                    .Create(EmailTemplateTypeEnum.NewFunding)
                                    .Get<NewFundingEmailTemplate>()
                                    .Init(model);

                        //send email to funding approver
                        var fundingPendingApproval = EmailTemplateFactory
                                    .Create(EmailTemplateTypeEnum.FundingStatusChangedPending)
                                    .Get<FundingStatusChangedPendingEmailTemplate>()
                                    .Init(model);

                        await newFunding.SubmitToQueue();
                        await fundingPendingApproval.SubmitToQueue();
                        break;
                    case StatusEnum.Declined:
                        //send email to funding capturer
                        var fundingDeclined = EmailTemplateFactory
                                    .Create(EmailTemplateTypeEnum.FundingStatusChanged)
                                    .Get<FundingStatusChangedEmailTemplate>()
                                    .Init(model);

                        await fundingDeclined.SubmitToQueue();
                        break;
                    case StatusEnum.Approved:
                        //send email to funding capturer
                        var fundingApproved = EmailTemplateFactory
                                    .Create(EmailTemplateTypeEnum.FundingStatusChanged)
                                    .Get<FundingStatusChangedEmailTemplate>()
                                    .Init(model);

                        await fundingApproved.SubmitToQueue();
                        break;
                }

                await _emailService.SendEmailFromQueue(true);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside FundingManagementConfigureEmail action: {ex.Message} Inner Exception: {ex.InnerException}");
            }
        }

        #endregion
    }
}
