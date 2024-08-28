using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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

        #endregion

        #region Constructors

        public FundingManagementController(
            ILogger<FundingManagementController> logger,
            IFundingManagementService fundingManagementService
            )
        {
            _logger = logger;
            _fundingManagementService = fundingManagementService;
        }

        #endregion

        #region Methods

        [HttpGet(Name = "GetNposForFunding")]
        public async Task<IActionResult> GetNposForFunding()
        {
            try
            {
                var results = await _fundingManagementService.GetNposForFunding();
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetNposForFunding action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("financialYearId/{financialYearId}/programmeId/{programmeId}/subProgrammeId/{subProgrammeId}/subProgrammeTypeId/{subProgrammeTypeId}", Name = "CanCaptureFunding")]
        public async Task<IActionResult> CanCaptureFunding(int financialYearId, int programmeId, int subProgrammeId, int subProgrammeTypeId)
        {
            try
            {
                var result = await this._fundingManagementService.CanCaptureFunding(financialYearId, programmeId, subProgrammeId, subProgrammeTypeId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CanCaptureFunding action: {ex.Message} Inner Exception: {ex.InnerException}");
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

        #endregion
    }
}
