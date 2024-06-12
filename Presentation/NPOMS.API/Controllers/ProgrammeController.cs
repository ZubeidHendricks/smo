using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NPOMS.Services.Implementation;
using NPOMS.Services.Interfaces;
using System.Threading.Tasks;
using System;
using NPOMS.Domain.Budget;
using NPOMS.Domain.Entities;

namespace NPOMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgrammeController : ExternalBaseController
    {
        #region Fields

        private ILogger<ProgrammeController> _logger;
        private IApplicationService _applicationService;
        private IEmailService _emailService;
        private IBankService _bankService;
        private IContactService _contactService;
        private IProgrammeService _programmeService;
        private IProgrameDeliveryService _programeDeliveryService;

        #endregion

        #region Constructors

        public ProgrammeController(
            ILogger<ProgrammeController> logger,
            IApplicationService applicationService,
            IEmailService emailService,
            IBankService bankService,
            IContactService contactService,
            IProgrammeService programmeService,
            IProgrameDeliveryService programeDeliveryService
            )
        {
            _logger = logger;
            _applicationService = applicationService;
            _emailService = emailService;
            _bankService = bankService;
            _contactService = contactService;
            _programmeService = programmeService;
            _programeDeliveryService = programeDeliveryService;
        }
        #endregion

        [HttpGet("bank/programmeId/{programmeId}", Name = "GetBankDetailsByProgramId")]
        public async Task<IActionResult> GetBankDetailsByProgramId(int programmeId)
        {
            try
            {
                var results = await _bankService.GetBankDetailsByProgramId(programmeId);
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetBankDetailsByProgramId action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("contact/programmeId/{programmeId}", Name = "GetContactDetailsByProgramId")]
        public async Task<IActionResult> GetContactDetailsByProgramId(int programmeId)
        {
            try
            {
                var results = await _contactService.GetContactDetailsByProgramId(programmeId);
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetContactDetailsByProgramId action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("create-contact", Name = "CreateProgrameContact")]
        public async Task<IActionResult> CreateProgrameContact([FromBody] ProgramContactInformation model)
        {
            try
            {
                ClearObjects(model);
                await _programmeService.CreateContact(model, base.GetUserIdentifier());
                return Ok(model);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateProgrameContact action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("update-contact", Name = "UpdateProgrameContact")]
        public async Task<IActionResult> UpdateProgrameContact([FromBody] ProgramContactInformation model)
        {
            try
            {
                ClearObjects(model);
                await _programmeService.UpdateContact(model, base.GetUserIdentifier());
                return Ok(model);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateProgrameContact action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("create-bank", Name = "CreateProgramBankDetails")]
        public async Task<IActionResult> CreateProgramBankDetails([FromBody] ProgramBankDetails model)
        {
            try
            {
                await _programmeService.CreateBankDetails(model, base.GetUserIdentifier());
                return Ok(model);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateProgramBankDetails action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("update-bank", Name = "UpdateProgramBankDetails")]
        public async Task<IActionResult> UpdateProgramBankDetails([FromBody] ProgramBankDetails model)
        {
            try
            {
                await _programmeService.UpdateBankDetails(model, base.GetUserIdentifier());
                return Ok(model);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateProgramBankDetails action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }





        [HttpGet("delivery/programmeId/{programmeId}", Name = "GetDeliveryDetailsByProgramId")]
        public async Task<IActionResult> GetDeliveryDetailsByProgramId(int programmeId)
        {
            try
            {
                var results = await _programeDeliveryService.GetDeliveryDetailsByProgramId(programmeId);
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetDeliveryDetailsByProgramId action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("create-delivery", Name = "CreateProgrameDelivery")]
        public async Task<IActionResult> CreateProgrameDelivery([FromBody] ProgrammeServiceDelivery model)
        {
            try
            {
                ClearDeliveryObjects(model);
                await _programmeService.CreateDelivery(model, base.GetUserIdentifier());
                return Ok(model);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateProgrameDelivery action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("update-delivery", Name = "UpdateProgrameDelivery")]
        public async Task<IActionResult> UpdateProgrameDelivery([FromBody] ProgrammeServiceDelivery model)
        {
            try
            {
                ClearDeliveryObjects(model);
                await _programmeService.UpdateDelivery(model, base.GetUserIdentifier());
                return Ok(model);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateProgrameDelivery action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        private static void ClearDeliveryObjects(ProgrammeServiceDelivery model)
        {
            model.DistrictCouncilId = model.DistrictCouncil.Id;
            model.LocalMunicipalityId = model.LocalMunicipality.Id;
            model.RegionId = model.Region.Id;

            model.DistrictCouncil = null;
            model.LocalMunicipality = null;
            model.Region = null;
        }

        private static void ClearObjects(ProgramContactInformation model)
        {
                model.TitleId = model.Title.Id;
                model.PositionId = model.Position.Id;
                model.RaceId = model.Race.Id;
                model.GenderId = model.Gender.Id;
                model.LanguageId = model.Language.Id;

                model.Position = null;
                model.Race = null;
                model.Gender = null;
                model.Language = null;
                model.Title = null;
        }
    }
}