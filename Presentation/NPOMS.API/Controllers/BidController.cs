using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NPOMS.Domain.Dropdown;
using NPOMS.Domain.Entities;
using NPOMS.Services.Implementation;
using NPOMS.Services.Interfaces;
using NPOMS.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Place = NPOMS.Domain.Dropdown.Place;

namespace NPOMS.API.Controllers
{
    [Route("api/bid")]
    [ApiController]
    public class BidController : ExternalBaseController
    {
        #region Fields

        private ILogger<BidController> _logger;
        private readonly IBidService _bidService;
        private IApplicationPeriodService _applicationPeriodService;
        private IApplicationService _applicationService;
        private INpoProfileService _npoProfilService;
        private IProgrammeService _programmeService;
        private IProgrameDeliveryService _programeDeliveryService;

        #endregion

        #region Constructors

        public BidController(IBidService bidService,
        ILogger<BidController> logger, IApplicationPeriodService applicationPeriodService,
        IApplicationService applicationService, INpoProfileService npoProfilService,
        IProgrammeService programmeService,
         IProgrameDeliveryService programeDeliveryService

        )
        {
            _bidService = bidService;
            _logger = logger;
            _applicationPeriodService = applicationPeriodService;
            _applicationService = applicationService;
            _npoProfilService = npoProfilService;
            _programmeService = programmeService;
            _programeDeliveryService = programeDeliveryService;
        }

        #endregion



        #region Methods


        // POST: api/Bid
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] FundAppDetailViewModel value)
        {
            try
            {


                var userIdentifier = GetUserIdentifier();
                var bid = await _bidService.Create(userIdentifier, value);

                _logger.LogError($"Create Application, User Identifier: {userIdentifier}, Data: {value}");

                return Ok(bid);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Create Application, data: {value}", ex);
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // PUT: api/Bid/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] FundAppDetailViewModel value)
        {
            try
            {
                var userIdentifier = GetUserIdentifier();
                var bid = await _bidService.Update(userIdentifier, id, value);

                _logger.LogError($"Edit Application,Id: {id}, User Identifier: {userIdentifier}, Data: {value}");

                return Ok(bid);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Create Application, data: {value}", ex);
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}/income")]
        public void  Put(int id, [FromBody] FinancialMatters value)
        {
            try
            {
                var userIdentifier = GetUserIdentifier();
                  _bidService.UpdateIncome( value);

                _logger.LogError($"Edit Application,Id: {id}, User Identifier: {userIdentifier}, Data: {value}");

               // return Ok(bid);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Create Application, data: {value}", ex);
               //return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        //[HttpPut("{id}/applicationDetail")]
        //public void Put(int id, [FromBody] ApplicationDetail value)
        //{
        //    try
        //    {
        //        var userIdentifier = GetUserIdentifier();
        //        _bidService.UpdateIncome(value);

        //        _logger.LogError($"Edit Application,Id: {id}, User Identifier: {userIdentifier}, Data: {value}");

        //        // return Ok(bid);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError($"Create Application, data: {value}", ex);
        //        //return StatusCode(500, $"Internal server error: {ex.Message}");
        //    }
        //}

        //[HttpPut("{id}", Name = "UpdateIncome")]
        //public async Task<IActionResult> UpdateFundingApplicationEntity(int id, [FromBody] FinancialMattersViewModel value)
        //{


        //    //List<FinancialMattersViewModel> contactInformation = JsonConvert.DeserializeObject<List<FinancialMattersViewModel>>(Convert.ToString(value.FinancialMatters));

        //    //var bid = await _bidService.Update(id, value);

        //   // _logger.LogError($"Edit Application,Id: {id}, User Identifier: {userIdentifier}, Data: {value}");

        //   // return Ok(bid);
        //}

        // GET: api/Bid/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var userIdentifier = GetUserIdentifier();
                var bid = await _bidService.GetById(id);

                return Ok(bid);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Get one Application, id: {id}", ex);
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        [HttpGet("applicationId/{applicationId}", Name = "GetapplicationIDAsync")]
        public async Task<IActionResult> GetapplicationIDAsync(int applicationId)
        {


            try
            {
                var userIdentifier = GetUserIdentifier();
                var bid = await _bidService.GetapplicationIDAsync(applicationId);

                return Ok(bid);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Get one Application, id: {applicationId}", ex);
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        [HttpGet]
        [Route("finyears")]
        public async Task<IActionResult> GetFinYears()
        {
            try
            {
                var finYears = _bidService.GetFinYears();

                return Ok(finYears);
            }
            catch (Exception ex)
            {
                _logger.LogError("Get financial years", ex);
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        [HttpPost]
        [Route("places")]
        public async Task<IActionResult> GetPlaces([FromBody] IEnumerable<ServiceDeliveryArea> sdas)
        {
            try
            {
                var sdaIds = sdas.Select(p => p.Id).ToList();
                var items = _bidService.GetPlaces(sdaIds);

                return Ok(items);
            }
            catch (Exception ex)
            {
                _logger.LogError("Get places", ex);
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        [Route("places/applicationId/{applicationId}/programId/{programId}")]
        public async Task<IActionResult> GetPlaces([FromBody] IEnumerable<ServiceDeliveryArea> sdas, int applicationId, int programId)
        {
            try
            {
                var npo = await _applicationService.GetApplicationById(applicationId);
                var npoProfile = await _npoProfilService.GetByNpoId(npo.NpoId);
                var results = await _programeDeliveryService.GetDeliveryDetailsByProgramId(programId, npoProfile.Id);

                var lists = new List<int>();
                foreach (var res in results)
                {
                   if(res.IsSelected == true)
                    {
                        lists.Add(Convert.ToInt32(res.ServiceDeliveryAreas.FirstOrDefault().ID));
                    }
                }
                var items = _bidService.GetPlaces(lists);

                return Ok(items);
            }
            catch (Exception ex)
            {
                _logger.LogError("Get places", ex);
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        [Route("subPlaces")]
        public ActionResult GetSubPlaces([FromBody] IEnumerable<Place> places)
        {
            try
            {
                var placesIds = places.Select(p => p.Id).ToList();
                var items = _bidService.GetSubplaces(placesIds);

                return Ok(items);
            }
            catch (Exception ex)
            {
                _logger.LogError("Get sub-places", ex);
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }



        #endregion

    }
}
