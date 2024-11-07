using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NPOMS.Services.Implementation;
using NPOMS.Services.Interfaces;
using System.Threading.Tasks;
using System;
using NPOMS.Services.DTOs.FundingAssessments;

namespace NPOMS.API.Controllers
{
    [Route("api/funding-assessments")]
    [ApiController]
    public class ApplicationFundingAssessmentController : ExternalBaseController
    {
        private ILogger<ApplicationFundingAssessmentController> _logger;
        private IApplicationFundingAssessmentService _applicationFundingAssessmentService;

        public ApplicationFundingAssessmentController(
                    ILogger<ApplicationFundingAssessmentController> logger,
                    IApplicationFundingAssessmentService applicationFundingAssessmentService
                    )
        {
            _logger = logger;
            _applicationFundingAssessmentService = applicationFundingAssessmentService;
        }

        [HttpGet(Name = "GetAllFundingAssessmentApplications")]
        public async Task<IActionResult> GetAllFundingAssessmentApplications()
        {
            try
            {
                var results = await this._applicationFundingAssessmentService.GetAllFundingAssessmentApplications(base.GetUserIdentifier());
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllApplications action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}/application/{applicationId}", Name = "GetFundingAssessmentById")]
        public async Task<IActionResult> GetFundingAssessmentById(int id, int applicationId)
        {
            try
            {
                var results = await this._applicationFundingAssessmentService.GetFundingAssessmentById(id, applicationId);
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetFundingAssessmentForm action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}/application/{applicationId}/programeServiceDeliveryArea", Name = "FundingAssessmentApplicationFormSDAUpsert")]
        public async Task<IActionResult> FundingAssessmentApplicationFormSDAUpsert(int id, int applicationId, [FromBody] dtoFundingAssessmentApplicationFormSDAUpsert dto)
        {
            try
            {
                await this._applicationFundingAssessmentService.FundingAssessmentApplicationFormSDAUpsert(id, dto, GetUserIdentifier());
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetFundingAssessmentForm action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}/application/{applicationId}/doi-confirm-capturer", Name = "ConfirmDOICapturer")]
        public async Task<IActionResult> ConfirmDOICapturer(int id, int applicationId)
        {
            try
            {
                await this._applicationFundingAssessmentService.ConfirmDOICapturer(applicationId, base.GetUserIdentifier());
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside ConfirmDOICapturer action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}/application/{applicationId}/submit-form", Name = "SubmitForm")]
        public async Task<IActionResult> SubmitForm(int id, int applicationId)
        {
            try
            {
                await this._applicationFundingAssessmentService.SubmitForm(applicationId, base.GetUserIdentifier());
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside ConfirmDOICapturer action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}/question/{questionId}/responses", Name = "UpsertQuestionResponse")]
        public async Task<IActionResult> UpsertQuestionResponse(int id, [FromBody] dtoFundingAssessmentFormQuestionResponseUpsert dto)
        {
            try
            {
               await this._applicationFundingAssessmentService.UpsertQuestionResponse(dto, base.GetUserIdentifier());
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside ConfirmDOICapturer action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
