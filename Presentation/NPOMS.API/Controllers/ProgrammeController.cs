using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NPOMS.Services.Implementation;
using NPOMS.Services.Interfaces;
using System.Threading.Tasks;
using System;
using NPOMS.Domain.Budget;
using NPOMS.Domain.Entities;
using NPOMS.Domain.Dropdown;
using NPOMS.Services.Models;

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
        private INpoProfileService _npoProfilService;
        #endregion

        #region Constructors

        public ProgrammeController(
            ILogger<ProgrammeController> logger,
            IApplicationService applicationService,
            IEmailService emailService,
            IBankService bankService,
            IContactService contactService,
            IProgrammeService programmeService,
            IProgrameDeliveryService programeDeliveryService,
            INpoProfileService npoProfilService
            )
        {
            _logger = logger;
            _applicationService = applicationService;
            _emailService = emailService;
            _bankService = bankService;
            _contactService = contactService;
            _programmeService = programmeService;
            _programeDeliveryService = programeDeliveryService;
            _npoProfilService = npoProfilService;
        }
        #endregion

        [HttpGet("bank/programmeId/{programmeId}/npoProfileId/{npoProfileId}", Name = "GetBankDetailsByProgramId")]
        public async Task<IActionResult> GetBankDetailsByProgramId(int programmeId, int npoProfileId)
        {
            try
            {
                var npoId = await _npoProfilService.GetById(npoProfileId);
                var results = await _bankService.GetBankDetailsByProgramId(programmeId, npoProfileId);
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetBankDetailsByProgramId action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("bank/npoProfileId/{npoProfileId}", Name = "GetProgrammeBankDetails")]
        public async Task<IActionResult> GetProgrammeBankDetails(int npoProfileId)
        {
            try
            {
                var npo = await _applicationService.GetApplicationById(npoProfileId);
                var npoProfile = await _npoProfilService.GetByNpoId(npo.NpoId);
                var results = await _bankService.GetBankDetailsByIds(npoProfile.Id);
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetBankDetailsById action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("contact/programmeId/{programmeId}/npoProfileId/{npoProfileId}", Name = "GetContactDetailsByProgramId")]
        public async Task<IActionResult> GetContactDetailsByProgramId(int programmeId, int npoProfileId)
        {
            try
            {
                var results = await _contactService.GetContactDetailsByProgramId(programmeId, npoProfileId);
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetContactDetailsByProgramId action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("contact/npoProfileId/{npoProfileId}", Name = "GetContactDetails")]
        public async Task<IActionResult> GetContactDetails(int npoProfileId)
        {
            try
            {
                var results = await _contactService.GetContactDetails(npoProfileId);
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetContactDetails action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("delivery/programmeId/{programmeId}/npoProfileId/{npoProfileId}", Name = "GetDeliveryDetailsByProgramId")]
        public async Task<IActionResult> GetDeliveryDetailsByProgramId(int programmeId, int npoProfileId)
        {
            try
            {
                var npoId = await _npoProfilService.GetById(npoProfileId);
                var results = await _programeDeliveryService.GetDeliveryDetailsByProgramId(programmeId, npoProfileId);
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetDeliveryDetailsByProgramId action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("delivery/selectedApplicationId/{selectedApplicationId}", Name = "GetDeliveryDetails")]
        public async Task<IActionResult> GetDeliveryDetails(int selectedApplicationId)
        {
            try
            {
                var npo = await _applicationService.GetApplicationById(selectedApplicationId);
                var npoProfile = await _npoProfilService.GetByNpoId(npo.NpoId);
                var results = await _programeDeliveryService.GetDeliveryDetails(npoProfile.Id);
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetDeliveryDetails action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        //[HttpGet("contact/npoProfileId/{npoProfileId}", Name = "GetContactDetails")]
        //public async Task<IActionResult> GetContactDetails(int npoProfileId)
        //{
        //    try
        //    {
        //        var npoProfile = await _applicationService.GetApplicationById(npoProfileId);
        //        var results = await _contactService.GetContactDetailsByProgramId(npoProfile.NpoId);
        //        return Ok(results);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError($"Something went wrong inside GetContactDetails action: {ex.Message} Inner Exception: {ex.InnerException}");
        //        return StatusCode(500, $"Internal server error: {ex.Message}");
        //    }
        //}

        [HttpPost("create-contact/{npoProfileId}", Name = "CreateProgrameContact")]
        public async Task<IActionResult> CreateProgrameContact([FromBody] ProgramContactInformation model, int npoProfileId)
        {
            try
            {
                ClearObjects(model);
                await _programmeService.CreateContact(model, base.GetUserIdentifier(), npoProfileId);
                return Ok(model);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateProgrameContact action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("update-contact/{npoProfileId}", Name = "UpdateProgrameContact")]
        public async Task<IActionResult> UpdateProgrameContact([FromBody] ProgramContactInformation model, int npoProfileId)
        {
            try
            {
                ClearObjects(model);
                await _programmeService.UpdateContact(model, base.GetUserIdentifier(), npoProfileId);
                return Ok(model);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateProgrameContact action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("create-bank/{npoProfileId}", Name = "CreateProgramBankDetails")]
        public async Task<IActionResult> CreateProgramBankDetails([FromBody] ProgramBankDetails model, int npoProfileId)
        {
            try
            {
                //var npo = await _applicationService.GetApplicationById(applicationId);
                await _programmeService.CreateBankDetails(model, base.GetUserIdentifier(), npoProfileId);
                return Ok(model);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateProgramBankDetails action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("update-bank/{npoProfileId}", Name = "UpdateProgramBankDetails")]
        public async Task<IActionResult> UpdateProgramBankDetails([FromBody] ProgramBankDetails model, int npoProfileId)
        {
            try
            {
                await _programmeService.UpdateBankDetails(model, base.GetUserIdentifier(), npoProfileId);
                return Ok(model);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateProgramBankDetails action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("create-delivery/{npoProfileId}", Name = "CreateProgrameDelivery")]
        public async Task<IActionResult> CreateProgrameDelivery([FromBody] ProgrammeServiceDeliveryVM model, int npoProfileId)
        {
            try
            {
                //ClearDeliveryObjects(model);
                await _programmeService.CreateDelivery(model, base.GetUserIdentifier(), npoProfileId);
                return Ok(model);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateProgrameDelivery action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("update-delivery/{npoProfileId}", Name = "UpdateProgrameDelivery")]
        public async Task<IActionResult> UpdateProgrameDelivery([FromBody] ProgrammeServiceDeliveryVM model, int npoProfileId)
        {
            try
            {
                //ClearDeliveryObjects(model);
                await _programmeService.UpdateDelivery(model, base.GetUserIdentifier(), npoProfileId);
                return Ok(model);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateProgrameDelivery action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("update-DeliveryServiceAreaSelection/id/{id}/selection/{selection}", Name = "DeliveryServiceAreaSelection")]
        public async Task<IActionResult> DeliveryServiceAreaSelection( int id, bool selection)
        {
            try
            {
                 await _programmeService.UpdateDeliveryAreaSelection(base.GetUserIdentifier(), id, selection);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeliveryServiceAreaSelection action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("update-BankSelection/id/{id}/selection/{selection}/npoId/{npoId}", Name = "UpdateBankSelection")]
        public async Task<IActionResult> UpdateBankSelection(int id, bool selection, int npoId)
        {
            try
            {
                var npoProfile = await _npoProfilService.GetByNpoId(npoId);
                await _programmeService.UpdateBankSelection(base.GetUserIdentifier(), id, selection, npoProfile.Id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateBankSelection action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        private static void ClearDeliveryObjects(ProgrammeServiceDeliveryVM model)
        {
            model.DistrictCouncilId = model.DistrictCouncil.Id;
            model.LocalMunicipalityId = model.LocalMunicipality.ID;
            //model.RegionId = model.Region.Id;
            //model.ServiceDeliveryAreaId = model.ServiceDeliveryArea.Id;

            model.DistrictCouncil = null;
            model.LocalMunicipality = null;
            //model.Region = null;
            //model.ServiceDeliveryArea = null;
        }
        private static void ClearObjects(ProgramContactInformation model)
        {
            model.TitleId = model.Title?.Id ?? model.TitleId;
            model.PositionId = model.Position?.Id ?? model.PositionId;
            model.RaceId = model.Race?.Id ?? model.RaceId;
            model.GenderId = model.Gender?.Id ?? model.GenderId;
            model.LanguageId = model.Language?.Id ?? model.LanguageId;

            model.Position = null;
            model.Race = null;
            model.Gender = null;
            model.Language = null;
            model.Title = null;
        }
    }
}