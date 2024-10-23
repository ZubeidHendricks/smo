using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NPOMS.Services.Implementation;
using NPOMS.Services.Interfaces;
using System.Threading.Tasks;
using System;

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
    }
}
