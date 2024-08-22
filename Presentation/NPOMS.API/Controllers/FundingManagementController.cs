using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System;
using NPOMS.Services.Interfaces;

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

        [HttpGet(Name = "GetAllFundingCaptures")]
        public async Task<IActionResult> GetAllFundingCaptures()
        {
            try
            {
                var results = await _fundingManagementService.GetAll();
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllFundingCaptures action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("id/{id}", Name = "GetFundingCaptureById")]
        public async Task<IActionResult> GetFundingCaptureById(int id)
        {
            try
            {
                var results = await this._fundingManagementService.GetById(id);
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetFundingCaptureById action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("npoId/{npoId}", Name = "GetFundingCaptureByNpoId")]
        public async Task<IActionResult> GetFundingCaptureByNpoId(int npoId)
        {
            try
            {
                var results = await this._fundingManagementService.GetByNpoId(npoId);
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetFundingCaptureByNpoId action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        #endregion
    }
}
