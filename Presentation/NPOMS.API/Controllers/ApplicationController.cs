﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NPOMS.Domain.Entities;
using NPOMS.Domain.Enumerations;
using NPOMS.Repository.Implementation.Core;
using NPOMS.Repository.Interfaces.Core;
using NPOMS.Repository.Interfaces.Entities;
using NPOMS.Services.Email;
using NPOMS.Services.Email.EmailTemplates;
using NPOMS.Services.Interfaces;
using NPOMS.Services.Models;
using System;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using NPOMS.Repository.Implementation.Entities;

namespace NPOMS.API.Controllers
{
    [Route("api/applications")]
    [ApiController]
    public class ApplicationController : ExternalBaseController
    {
        #region Fields

        private ILogger<ApplicationController> _logger;
        private IApplicationService _applicationService;
        private IEmailService _emailService;
        private IUserService _userService;
        private INpoProfileService _npoProfileService;
        private IIndicatorService _indicatorService;
        private IPostService _postService;
        private IIncomeAndExpenditureService _incomeAndExpenditureService;
        private IGovernanceService _governanceService;
        private IAnyOtherService _anyOtherService;
        private ISDIPService _sdipService;
        private IReportChecklistService _reportChecklistService;
        private IVerifyActualService _verifyActualService;

        private IApplicationRepository _applicationRepository;
        private IUserRepository _userRepository;
        private IProjectInformationRepository _projectInformationRepository;
        private IObjectiveRepository _objectiveRepository;
        private IActivityRepository _activityRepository;
        #endregion

        #region Constructors

        public ApplicationController(
            ILogger<ApplicationController> logger,
            IApplicationService applicationService,
            IEmailService emailService,
            IUserService userService,
            INpoProfileService npoProfileService,
            IIndicatorService indicatorService,
            IPostService postService,
            IIncomeAndExpenditureService incomeAndExpenditureService,
            IGovernanceService governanceService,
            IAnyOtherService anyOtherService,
            ISDIPService sdipService,
            IReportChecklistService reportChecklistService,
            IVerifyActualService verifyActualService,

            IApplicationRepository applicationRepository,
            IUserRepository userRepository,
            IProjectInformationRepository projectInformationRepository,
            IObjectiveRepository objectiveRepository,
            IActivityRepository activityRepository
            )
        {
            _logger = logger;
            _applicationService = applicationService;
            _emailService = emailService;
            _userService = userService;
            _npoProfileService = npoProfileService;
            _indicatorService = indicatorService;
            _postService = postService; 
            _incomeAndExpenditureService = incomeAndExpenditureService;
            _governanceService = governanceService;
            _anyOtherService = anyOtherService;
            _sdipService = sdipService;
            _reportChecklistService = reportChecklistService;
            _verifyActualService = verifyActualService;
            _applicationRepository = applicationRepository;
            _userRepository = userRepository;
            _objectiveRepository = objectiveRepository;
            _activityRepository = activityRepository;
            projectInformationRepository = _projectInformationRepository;
        }

        #endregion

        #region Methods

        [HttpGet(Name = "GetAllApplications")]
        public async Task<IActionResult> GetAllApplications()
        {
            try
            {
                var results = await _applicationService.GetAllApplicationsAsync(base.GetUserIdentifier());
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllApplications action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("applicationId/{applicationId}", Name = "GetApplicationById")]
        public async Task<IActionResult> GetApplicationById(int applicationId)
        {
            try
            {
                var results = await _applicationService.GetApplicationById(applicationId);
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetApplicationById action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("NpoId/{NpoId}/applicationPeriodId/{applicationPeriodId}", Name = "GetApplicationByNpoIdAndPeriodId")]
        public async Task<IActionResult> GetApplicationByNpoIdAndPeriodId(int NpoId, int applicationPeriodId)
        {
            try
            {
                var results = await _applicationService.GetApplicationByNpoIdAndPeriodId(NpoId, applicationPeriodId);
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetApplicationByNpoIdAndPeriodId action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("npoId/{npoId}", Name = "GetApplicationsByNpoId")]
        public async Task<IActionResult> GetApplicationsByNpoId(int npoId)
        {
            try
            {
                var results = await _applicationService.GetApplicationsByNpoId(npoId);
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetApplicationsByNpoId action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        [HttpPost("createNew/{createNew}/financialYearId/{financialYearId}", Name = "CreateApplication")]
        public async Task<IActionResult> CreateApplication([FromBody] Application model, bool createNew, int financialYearId)
        {
            try
            {
                var applicationPeriod = await _applicationService.GetApplicationPeriodById(model.ApplicationPeriodId);

                if ((applicationPeriod.ApplicationTypeId == (int)ApplicationTypeEnum.FundingApplication) && (applicationPeriod.DepartmentId != (int)DepartmentEnum.DOH))
                {
                    var npoProfile = await _npoProfileService.GetByNpoId(model.NpoId);
                    var servicesRendered = await _npoProfileService.GetServiceRenderedByProperties(npoProfile.Id, model.ProgrammeId, model.SubProgrammeId, model.SubProgrammeTypeId);
                    if (servicesRendered == null)
                    {
                        var data = new { Message = "Please ensure that services rendered under your profile and the required sub sections (i.e. banking detail, contact detail and SDA) are updated, to be able to continue with your application." };
                        return Ok(data);
                    }
                }

                var application = await _applicationService.GetApplicationByNpoIdAndPeriodIdAndYear(model.NpoId, model.ApplicationPeriodId, applicationPeriod.FinancialYear.Name);

                if (application == null)
                {
                    model.IsCloned = !createNew;
                    await _applicationService.CreateApplication(model, base.GetUserIdentifier());
                    await CreateApplicationAudit(model);

                    if (!createNew)
                    {
                        await _applicationService.CloneWorkplan(model, financialYearId, base.GetUserIdentifier());
                        await _applicationService.CreateActivityRecipients(model, financialYearId);
                    }

                    var modelToReturn = application == null ? model : application;
                    return Ok(modelToReturn);

                }
                else
                {
                    if(model.StatusId == 3)
                    {
                        await _applicationService.UpdateApplication(model, base.GetUserIdentifier());
                        return Ok(application);
                    }
                    else
                    {
                        var data = new { Message = "Application already captured for the selected programme. Please go to 'Submissions' to access this application." };
                        return Ok(data);
                    }
                    
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateApplication action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("validateNew", Name = "ValidateBeforeCreateQCApplication")]
        public async Task<IActionResult> ValidateBeforeCreateQCApplication([FromBody] Application model)
        {
            try
            {
                var applicationPeriod = await _applicationService.GetApplicationPeriodById(model.ApplicationPeriodId);

                var npoProfile = await _npoProfileService.GetByNpoId(model.NpoId);

                var application = await _applicationService.GetApplicationByNpoIdAndPeriodIdAndYear(model.NpoId, model.ApplicationPeriodId, applicationPeriod.FinancialYear.Name);

                if (application != null)
                {
                    var data = new { Message = "Application already captured for the selected programme. Please go to 'Submissions' to access this application." };
                    return Ok(data);
                }
                else
                {
                    var data = new { Message = "Create" };
                    return Ok(data);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateApplication action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("createIndicatorReport", Name = "CreateIndicatorReport")]
        public async Task<IActionResult> CreateIndicatorReport(IndicatorReport model)
        {
            try
            {
                model.StatusId = 2;
                model.CreatedDateTime = DateTime.Now;
                await _indicatorService.CreateIndicatorReportEntity(model, base.GetUserIdentifier());
                await CreateIndicatorReportAudit(model);
                return Ok(model);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateIndicatorReport action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        [HttpPost("createChecklistReport", Name = "CreateChecklistReport")]
        public async Task<IActionResult> CreateChecklistReport(ReportChecklist model)
        {
            try
            {
              
                model.CreatedDateTime = DateTime.Now;
                await _reportChecklistService.CreateEntity(model, base.GetUserIdentifier());
            
                return Ok(model);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateReportChecklist action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }



        [HttpPost("createSDIPReport", Name = "CreateSDIPReport")]
        public async Task<IActionResult> CreateSDIPReport(SDIPReport model)
        {
            try
            {
                model.StatusId = 2;
                model.CreatedDateTime = DateTime.Now;
                await _sdipService.CreateSDIPReportEntity(model, base.GetUserIdentifier());
                await CreateSDIPAudit(model);
                return Ok(model);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateSDIPReport action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        [HttpPost("createVerifyActual", Name = "CreateVerifyActual")]
        public async Task<IActionResult> CreateVerifyActual(VerifyActual model)
        {
            try
            {
                model.StatusId = 2;
                model.CreatedDateTime = DateTime.Now;
                await _verifyActualService.CreateVerifiedActualsEntity(model, base.GetUserIdentifier());
                return Ok(model);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateVerifyActual action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("createPostReport", Name = "CreatePostReport")]
        public async Task<IActionResult> CreatePostReport(PostReport model)
        {
            try
            {
                model.StatusId = 2;
                model.CreatedDateTime = DateTime.Now;
                await _postService.CreatePostReportEntity(model, base.GetUserIdentifier());
                await CreatePostAudit(model);
                return Ok(model);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreatePostReport action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("updatePostReportStatus", Name = "UpdatePostReportStatus")]
        public async Task<IActionResult> UpdatePostReportStatus(BaseCompleteViewModel model)
        {
            try
            {
                var results = await _postService.CompletePost(model, base.GetUserIdentifier());
                foreach (var result in results)
                {
                    await CreatePostAudit(result);
                }
                return Ok(model);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateReportStatus action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        private async Task CreateIndicatorReportAudit(IndicatorReport model)
        {
            try
            {
                //var applicationAudit = new IndicatorReportAudit { IndicatorReportId = model.Id, StatusId = model.StatusId };
                var applicationAudit = new IndicatorReportAudit
                {
                    IndicatorReportId = model.Id,
                    StatusName = model.StatusId == (int)StatusEnum.Completed ? StatusEnum.Completed.ToString() : ((StatusEnum)model.StatusId).ToString()
                };

                await _indicatorService.CreateAudit(applicationAudit, base.GetUserIdentifier());

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateAudit action: {ex.Message} Inner Exception: {ex.InnerException}");
            }
        }
        private async Task CreatePostAudit(PostReport model)
        {
            try
            {
                //var applicationAudit = new PostAudit { PostReportId = model.Id, StatusId = model.StatusId };
                var applicationAudit = new PostAudit
                {
                    PostReportId = model.Id,
                    StatusName = model.StatusId == (int)StatusEnum.Completed ? StatusEnum.Completed.ToString() : ((StatusEnum)model.StatusId).ToString()
                };

                await _postService.CreateAudit(applicationAudit, base.GetUserIdentifier());

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateAudit action: {ex.Message} Inner Exception: {ex.InnerException}");
            }
        }

        private async Task CreateAnyOtherAudit(AnyOtherInformationReport model)
        {
            try
            {
                //var applicationAudit = new AnyOtherReportAudit { AnyOtherInformationReportId = model.Id, StatusId = model.StatusId };
                var applicationAudit = new AnyOtherReportAudit
                {
                    AnyOtherInformationReportId = model.Id,
                    StatusName = model.StatusId == (int)StatusEnum.Completed ? StatusEnum.Completed.ToString() : ((StatusEnum)model.StatusId).ToString()
                };

                await _anyOtherService.CreateAudit(applicationAudit, base.GetUserIdentifier());

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateAudit action: {ex.Message} Inner Exception: {ex.InnerException}");
            }
        }

        private async Task CreateSDIPAudit(SDIPReport model)
        {
            try
            {
                //var applicationAudit = new SDIPReportAudit { SDIPReportId = model.Id, StatusId = model.StatusId };
                var applicationAudit = new SDIPReportAudit
                {
                    SDIPReportId = model.Id,
                    StatusName = model.StatusId == (int)StatusEnum.Completed ? StatusEnum.Completed.ToString() : ((StatusEnum)model.StatusId).ToString()
                };

                await _sdipService.CreateAudit(applicationAudit, base.GetUserIdentifier());

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateAudit action: {ex.Message} Inner Exception: {ex.InnerException}");
            }
        }

        private async Task CreateIncomeAudit(IncomeAndExpenditureReport model)
        {
            try
            {
                //var applicationAudit = new IncomeReportAudit { IncomeAndExpenditureReportId = model.Id, StatusId = model.StatusId };
                var applicationAudit = new IncomeReportAudit
                {
                    IncomeAndExpenditureReportId = model.Id,
                    StatusName = model.StatusId == (int)StatusEnum.Completed ? StatusEnum.Completed.ToString() : ((StatusEnum)model.StatusId).ToString()
                };

                await _incomeAndExpenditureService.CreateAudit(applicationAudit, base.GetUserIdentifier());

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateAudit action: {ex.Message} Inner Exception: {ex.InnerException}");
            }
        }
        private async Task CreateGovernaceAudit(GovernanceReport model)
        {
            try
            {
                //var applicationAudit = new GovernanceAudit { GovernanceReportId = model.Id, StatusId = model.StatusId };
                var applicationAudit = new GovernanceAudit
                {
                    GovernanceReportId = model.Id,
                    StatusName = model.StatusId == (int)StatusEnum.Completed ? StatusEnum.Completed.ToString() : ((StatusEnum)model.StatusId).ToString()
                };

                await _governanceService.CreateAudit(applicationAudit, base.GetUserIdentifier());

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateAudit action: {ex.Message} Inner Exception: {ex.InnerException}");
            }
        }

        [HttpPost("createGovernanceReport", Name = "CreateGovernanceReport")]
        public async Task<IActionResult> CreateGovernanceReport(GovernanceReport model)
        {
            try
            {
                model.CreatedDateTime = DateTime.Now;
                model.StatusId = 2;
                await _governanceService.CreateGovernanceReportEntity(model, base.GetUserIdentifier());
                await CreateGovernaceAudit(model);
                return Ok(model);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateGovernanceReport action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("createIncomeReport", Name = "CreateIncomeReport")]
        public async Task<IActionResult> CreateIncomeReport(IncomeAndExpenditureReport model)
        {
            try
            {
                model.StatusId = 2;
                model.CreatedDateTime = DateTime.Now;
                await _incomeAndExpenditureService.CreateIncomeReportEntity(model, base.GetUserIdentifier());
                await CreateIncomeAudit(model);
                return Ok(model);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateIncomeReport action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("createAnyOther", Name = "CreateAnyOther")]
        public async Task<IActionResult> CreateAnyOther(AnyOtherInformationReport model)
        {
            try
            {
                model.StatusId = 2;
                model.CreatedDateTime = DateTime.Now;
                await _anyOtherService.CreateEntity(model, base.GetUserIdentifier());
                await CreateAnyOtherAudit(model);
                return Ok(model);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside createAnyOther action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("updatAnyOtherReport", Name = "UpdateAnyOtherReport")]
        public async Task<IActionResult> UpdateAnyOtherReport(AnyOtherInformationReport model)
        {
            try
            {
                model.CreatedDateTime = DateTime.Now;
                await _anyOtherService.UpdateEntity(model, base.GetUserIdentifier());
                return Ok(model);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside updatAnyOtherReport action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }



        [HttpPut("updateVerifyActual", Name = "updateVerifyActual")]
        public async Task<IActionResult> updateVerifyActual(VerifyActual model)
        {
            try
            {
                model.CreatedDateTime = DateTime.Now;
                await _verifyActualService.UpdateVerifiedActualsEntity(model, base.GetUserIdentifier());
                return Ok(model);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside updateVerifyActual action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("updateAnyOtherStatus", Name = "UpdateAnyOtherStatus")]
        public async Task<IActionResult> UpdateAnyOtherStatus(BaseCompleteViewModel model)
        {
            try
            {
                var result = await _anyOtherService.UpdateAnyOtherStatus(model, base.GetUserIdentifier());
                foreach (var item in result) {
                    await CreateAnyOtherAudit(item);
                }
                return Ok(model);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateReportStatus action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("updateSDIPReport", Name = "UpdateSDIPReport")]
        public async Task<IActionResult> UpdateSDIPReport(SDIPReport model)
        {
            try
            {
                model.CreatedDateTime = DateTime.Now;
                await _sdipService.UpdateSDIPReportEntity(model, base.GetUserIdentifier());
                return Ok(model);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside updatSDIPReport action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        [HttpPut("updateChecklistReport", Name = "UpdateChecklistReport")]
        public async Task<IActionResult> UpdateChecklistReport(ReportChecklist model)
        {
            try
            {
                model.CreatedDateTime = DateTime.Now;
                await _reportChecklistService.UpdateEntity(model, base.GetUserIdentifier());
                return Ok(model);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside updateChecklistReport action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("updateSDIPStatus", Name = "UpdateSDIPStatus")]
        public async Task<IActionResult> UpdateSDIPStatus(BaseCompleteViewModel model)
        {
            try
            {
                var result =   await _sdipService.UpdateSDIPStatus(model, base.GetUserIdentifier());
                foreach (var item in result)
                {
                   await CreateSDIPAudit(item);
                }
                return Ok(model);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateReportStatus action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("updatIncomeReport", Name = "UpdateIncomeReport")]
        public async Task<IActionResult> UpdateIncomeReport(IncomeAndExpenditureReport model)
        {
            try
            {
                model.CreatedDateTime = DateTime.Now;
                await _incomeAndExpenditureService.UpdateIncomeReportEntity(model, base.GetUserIdentifier());
                return Ok(model);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateIncomeReport action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("updateIncomeReportStatus", Name = "UpdateIncomeReportStatus")]
        public async Task<IActionResult> UpdateIncomeReportStatus(BaseCompleteViewModel model)
        {
            try
            {
                var results = await _incomeAndExpenditureService.UpdateIncomeReportStatus(model, base.GetUserIdentifier());
                foreach (var result in results)
                {
                    await CreateIncomeAudit(result);
                }
                return Ok(model);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateReportStatus action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("updatePostReport", Name = "UpdatePostReport")]
        public async Task<IActionResult> UpdatePostReport(PostReport model)
        {
            try
            {
                model.CreatedDateTime = DateTime.Now;
                await _postService.UpdatePostReportEntity(model, base.GetUserIdentifier());
                //await CreatePostAudit(model);
                return Ok(model);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdatePostReport action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("updateGovernanceReport", Name = "UpdateGovernanceReport")]
        public async Task<IActionResult> UpdateGovernanceReport(GovernanceReport model)
        {
            try
            {
                model.CreatedDateTime = DateTime.Now;
                await _governanceService.UpdateGovernanceReportEntity(model, base.GetUserIdentifier());
                return Ok(model);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateGovernanceReport action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("updateGovernanceReportStatus", Name = "UpdateGovernanceReportStatus")]
        public async Task<IActionResult> UpdateGovernanceReportStatus(BaseCompleteViewModel model)
        {
            try
            {
                var results = await _governanceService.CompleteGovernanceReportPost(model, base.GetUserIdentifier());
                foreach (var result in results)
                {
                    await CreateGovernaceAudit(result);
                }
                return Ok(model);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateReportStatus action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("updateIndicatorReport", Name = "UpdateIndicatorReport")]
        public async Task<IActionResult> UpdateIndicatorReport(IndicatorReport model)
        {
            try
            {
                model.CreatedDateTime = DateTime.Now;
                await _indicatorService.UpdateIndicatorReportEntity(model, base.GetUserIdentifier());
                return Ok(model);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateIndicatorReport action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("updateIndicatorReportStatus", Name = "UpdateIndicatorReportStatus")]
        public async Task<IActionResult> UpdateIndicatorReportStatus(BaseCompleteViewModel model)
        {
            try
            {
                var results = await _indicatorService.UpdateIndicatorReportStatus(model, base.GetUserIdentifier());
                foreach (var result in results)
                {
                    await CreateIndicatorReportAudit(result);
                }

                return Ok(model);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateReportStatus action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

        }

        [HttpGet("getReportChecklistByAppIdQtrId/appid/qtrId/{appid}/{qtrId}", Name = "GetReportChecklistByAppIdQuarterId")]
        public async Task<IActionResult> GetReportChecklistByAppIdQuarterId(int appid, int qtrId)
        {
            try
            {
                var results = await _reportChecklistService.GetByPeriodIdAndqtrId(appid, qtrId);
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetReportChecklistByAppIdQuarterId action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        [HttpGet("GetVeifiedActualByActualId/actualId/{actualId}/quarterId/{quarterId}", Name = "GetVeifiedActualByActualId")]
        public async Task<IActionResult> GetVeifiedActualByAppId(int actualId, int quarterId)
        {
            try
            {
                var results = await _verifyActualService.GetVerifiedActualsByPeriodId(actualId, quarterId);
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetVeifiedActualByAppIdQuarterId action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("getVeifiedActuals", Name = "GetVeifiedActuals")]
        public async Task<IActionResult> GetVeifiedActuals()
        {
            try
            {
                var results = await _verifyActualService.GetVerifiedActuals();
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetVeifiedActualByAppIdQuarterId action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("getanyotherbyappid/appid/{appid}", Name = "GetAnyOtherByAppid")]
        public async Task<IActionResult> GetAnyOtherByAppid(int appid)
        {
            try
            {
                var results = await _anyOtherService.GetByPeriodId(appid);
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAnyOtherByAppid action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("getsdipbyappid/appid/{appid}", Name = "GetSDIPByAppid")]
        public async Task<IActionResult> GetSDIPByAppid(int appid)
        {
            try
            {
                var results = await _sdipService.GetSDIPReportByPeriodId(appid);
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetSDIPByAppid action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        [HttpGet("getpostreportsbyappid/appid/{appid}", Name = "GetPostReportsByAppid")]
        public async Task<IActionResult> GetPostReportByAppid(int appid)
        {
            try
            {
                var results = await _postService.GetPostReportByPeriodId(appid);
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetPostReportByAppid action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("getincomereportsbyappid/appid/{appid}", Name = "GetIncomeReportsByAppid")]
        public async Task<IActionResult> GetIncomeReportByAppid(int appid)
        {
            try
            {
                var results = await _incomeAndExpenditureService.GetIncomeReportByPeriodId(appid);
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetIncomeReportByAppid action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("getgovernancereportsbyappid/appid/{appid}", Name = "GetGovernanceReportsByAppid")]
        public async Task<IActionResult> GetGovernanceReportByAppid(int appid)
        {
            try
            {
                var results = await _governanceService.GetGovernanceReportByPeriodId(appid);
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetGovernanceReportByAppid action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("getallindicatorreports", Name = "GetAllIndicatorReports")]
        public async Task<IActionResult> GetAllIndicatorReports()
        {
            try
            {
                var results = await _indicatorService.GetIndicatorReports();
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllIndicatorReports action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }



        [HttpGet("getindicatorreportsbyappid/appid/{appid}", Name = "GetIndicatorReportsByAppid")]
        public async Task<IActionResult> GeIndicatorReportByAppid(int appid)
        {
            try
            {
                var results = await _indicatorService.GetIndicatorReportByPeriodId(appid);
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GeIndicatorReportByAppid action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("createQC", Name = "CreateQCApplication")]
        public async Task<IActionResult> CreateQCApplication([FromBody] Application model)
        {
            try
            {
                var applicationPeriod = await _applicationService.GetApplicationPeriodById(model.ApplicationPeriodId);

                var npoProfile = await _npoProfileService.GetByNpoId(model.NpoId);

                var application = await _applicationService.GetApplicationByNpoIdAndPeriodIdAndYear(model.NpoId, model.ApplicationPeriodId, applicationPeriod.FinancialYear.Name);

                if (application != null)
                {
                    return Ok(application);
                }
                else
                {
                    await _applicationService.CreateApplication(model, base.GetUserIdentifier());

                    await CreateApplicationAudit(model);

                    var modelToReturn = application == null ? model : application;

                    return Ok(modelToReturn);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateApplication action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut(Name = "UpdateApplication")]
        public async Task<IActionResult> UpdateApplication([FromBody] Application model)
        {
            try
            {
                await _applicationService.UpdateApplication(model, base.GetUserIdentifier());
                await CreateApplicationAudit(model);

                await ConfigureEmail(model);
                return Ok(model);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateApplication action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("submitReport", Name = "SubmitReport")]
        public async Task<IActionResult> SubmitReport([FromBody] Application model)
        {
            try
            {
                await _applicationService.SubmitReport(model, base.GetUserIdentifier());
                //await CreateApplicationAudit(model);

                //await ConfigureEmail(model);
                return Ok(model);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside SubmitReport action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("applicationId/{applicationId}", Name = "DeleteApplicationById")]
        public async Task<IActionResult> DeleteApplicationById(int applicationId)
        {
            try
            {
                await _applicationService.DeleteApplicationById(applicationId, base.GetUserIdentifier());
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteApplicationById action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("submitCfpApplication/applicationId/{applicationId}", Name = "SubmitCfpApplication")]
        public async Task<IActionResult> SubmitCfpApplication([FromBody] int applicationId)
        {
            try
            {
                await _applicationService.SubmitCfpApplication(applicationId, base.GetUserIdentifier());
                return Ok(applicationId);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteApplicationById action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        private async Task CreateApplicationAudit(Application model)
        {
            try
            {
                var applicationAudit = new ApplicationAudit { ApplicationId = model.Id, StatusId = model.StatusId };
                await _applicationService.CreateApplicationAudit(applicationAudit, base.GetUserIdentifier());
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateApplicationAudit action: {ex.Message} Inner Exception: {ex.InnerException}");
            }
        }

        private async Task ConfigureEmail(Application model)
        {
            try
            {
                var applicationPeriod = await _applicationService.GetApplicationPeriodById(model.ApplicationPeriodId);
                
                if (applicationPeriod.ApplicationType.Id == (int)ApplicationTypeEnum.FundingApplication)
                {
                    StatusEnum status = (StatusEnum)model.StatusId;

                    switch (status)
                    {
                        case StatusEnum.PendingReview:
                            var newDSDApplication = EmailTemplateFactory
                                    .Create(EmailTemplateTypeEnum.DSDFundingApplicationSubmitted)
                                    .Get<DSDFundingApplicationSubmitted>()
                                    .Init(model);
                            await newDSDApplication.SubmitToQueue();
                            break;
                    }
                }

                if (applicationPeriod.ApplicationType.Id == (int)ApplicationTypeEnum.ServiceProvision)
                {
                    StatusEnum status = (StatusEnum)model.StatusId;

                    switch (status)
                    {
                        case StatusEnum.PendingReview:
                            var newApplication = EmailTemplateFactory
                                    .Create(EmailTemplateTypeEnum.NewApplication)
                                    .Get<NewApplicationEmailTemplate>()
                                    .Init(model);

                            var statusChangedPendingReview = EmailTemplateFactory
                                    .Create(EmailTemplateTypeEnum.StatusChangedPendingReview)
                                    .Get<StatusChangedPendingReviewEmailTemplate>()
                                    .Init(model);

                            await newApplication.SubmitToQueue();
                            await statusChangedPendingReview.SubmitToQueue();
                            break;
                        case StatusEnum.AmendmentsRequired:
                            var statusChangedAmendmentsRequired = EmailTemplateFactory
                                    .Create(EmailTemplateTypeEnum.StatusChangedAmendmentsRequired)
                                    .Get<StatusChangedAmendmentsRequiredEmailTemplate>()
                                    .Init(model);

                            await statusChangedAmendmentsRequired.SubmitToQueue();
                            break;
                        case StatusEnum.PendingApproval:
                            var statusChangedApproved = EmailTemplateFactory
                                    .Create(EmailTemplateTypeEnum.StatusChangedPendingApproval)
                                    .Get<StatusChangedPendingApprovalEmailTemplate>()
                                    .Init(model);

                            await statusChangedApproved.SubmitToQueue();
                            break;
                        case StatusEnum.Declined:
                            var statusChangedRejected = EmailTemplateFactory
                                    .Create(EmailTemplateTypeEnum.StatusChangedRejected)
                                    .Get<StatusChangedRejectedEmailTemplate>()
                                    .Init(model);

                            await statusChangedRejected.SubmitToQueue();
                            break;
                        case StatusEnum.PendingSLA:
                            var statusChangesPendingSLA = EmailTemplateFactory
                                    .Create(EmailTemplateTypeEnum.StatusChangedPendingSLA)
                                    .Get<StatusChangedPendingSLAEmailTemplate>()
                                    .Init(model);

                            await statusChangesPendingSLA.SubmitToQueue();
                            break;
                        case StatusEnum.PendingSignedSLA:
                            var statusChangesPendingSignedSLA = EmailTemplateFactory
                                    .Create(EmailTemplateTypeEnum.StatusChangedPendingSignedSLA)
                                    .Get<StatusChangedPendingSignedSLAEmailTemplate>()
                                    .Init(model);

                            await statusChangesPendingSignedSLA.SubmitToQueue();
                            break;
                        case StatusEnum.AcceptedSLA:
                            var statusChangesAcceptedSLA = EmailTemplateFactory
                                    .Create(EmailTemplateTypeEnum.StatusChangedAcceptedSLA)
                                    .Get<StatusChangedAcceptedSLAEmailTemplate>()
                                    .Init(model);

                            await statusChangesAcceptedSLA.SubmitToQueue();
                            break;
                        case StatusEnum.DeptComments:
                            var statusChangedDeptReviewComments = EmailTemplateFactory
                                    .Create(EmailTemplateTypeEnum.StatusChangedDeptComments)
                                    .Get<StatusChangedDeptCommentsEmailTemplate>()
                                    .Init(model);

                            await statusChangedDeptReviewComments.SubmitToQueue();
                            break;
                        case StatusEnum.OrgComments:
                            var statusChangedOrgReviewComments = EmailTemplateFactory
                                    .Create(EmailTemplateTypeEnum.StatusChangedOrgComments)
                                    .Get<StatusChangedOrgCommentsEmailTemplate>()
                                    .Init(model);

                            await statusChangedOrgReviewComments.SubmitToQueue();
                            break;
                        case StatusEnum.PendingReviewerSatisfaction:
                            var statusChangedPendingReviewerSatisfaction = EmailTemplateFactory
                                    .Create(EmailTemplateTypeEnum.StatusChangedPendingReviewerSatisfaction)
                                    .Get<StatusChangedPendingReviewerSatisfactionEmailTemplate>()
                                    .Init(model);

                            await statusChangedPendingReviewerSatisfaction.SubmitToQueue();
                            break;
                    }
                }

                await _emailService.SendEmailFromQueue();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside ApplicationConfigureEmail action: {ex.Message} Inner Exception: {ex.InnerException}");
            }
        }

        [HttpGet("objectives/NpoId/{NpoId}/applicationPeriodId/{applicationPeriodId}", Name = "GetAllObjectives")]
        public async Task<IActionResult> GetAllObjectives(int NpoId, int applicationPeriodId)
        {
            try
            {
                var results = await _applicationService.GetAllObjectivesAsync(NpoId, applicationPeriodId);
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllObjectives action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("funding-application-details/{id}")]
        public async Task<IActionResult> GetFundingApplicationDetails(int id)
        {
            try
            {
                var results = await _applicationService.GetFundingApplicationDetailsByApplicationId(id);
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetFundingApplicationDetails action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("funding-application-details")]
        public async Task<IActionResult> CreateFundingApplicationDetails([FromBody] FundingApplicationDetail model, int NpoId, int applicationPeriodId)
        {
            try
            {
                //var application = await _applicationService.GetApplicationByNpoIdAndPeriodId(NpoId, applicationPeriodId);
                //model.ApplicationId = application.Id;

                await _applicationService.CreateFundingApplicationDetails(model, base.GetUserIdentifier());
                return Ok(model);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateFundingApplicationDetails action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("funding-application-details")]
        public async Task<IActionResult> UpdateFundingApplicationDetails([FromBody] FundingApplicationDetail model)
        {
            try
            {
                await _applicationService.UpdateFundingApplicationDetails(model, base.GetUserIdentifier());
                return Ok(model);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateFundingApplicationDetails action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        //[HttpPost("addProjectImplementation")]
        //public async Task<IActionResult> AddProjectImplementation([FromBody] ProjectImplementationViewModel model)
        //{
        //    try
        //    {
        //        await _applicationService.AddProjectImplementation(model, base.GetUserIdentifier());
        //        return Ok(model);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError($"Something went wrong inside AddProjectImplementation action: {ex.Message} Inner Exception: {ex.InnerException}");
        //        return StatusCode(500, $"Internal server error: {ex.Message}");
        //    }
        //}

        //[HttpPut("updateProjectImplementation")]
        //public async Task<IActionResult> UpdateProjectImplementation([FromBody] ProjectImplementation model)
        //{
        //    try
        //    {
        //       // await _applicationService.UpdateProjectImplementation(model, base.GetUserIdentifier());
        //        return Ok(model);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError($"Something went wrong inside AddProjectImplementation action: {ex.Message} Inner Exception: {ex.InnerException}");
        //        return StatusCode(500, $"Internal server error: {ex.Message}");
        //    }
        //}

        [HttpGet("region/{id}")]
        public async Task<IActionResult> GetRegions(int id)
        {
            try
            {
                var results = await _applicationService.GetRegions(id);
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetRegions action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("sdas/{id}")]
        public async Task<IActionResult> GetServiceDeliveryAreas(int id)
        {
            try
            {
                var results = await _applicationService.GetServiceDeliveryAreas(id);
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetServiceDeliveryAreas action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        //[HttpPost("projectInformation/NpoId/{NpoId}/applicationPeriodId/{applicationPeriodId}", Name = "CreateProjectInformation")]
        //public async Task<IActionResult> CreateProjectInformation([FromBody] ProjectInformation model, int NpoId, int applicationPeriodId)
        //{
        //    try
        //    {
        //        var application = await _applicationService.GetApplicationByNpoIdAndPeriodId(NpoId, applicationPeriodId);
        //        model.ApplicationId = application.Id;

        //        await _applicationService.CreateProjectInformation(model, base.GetUserIdentifier());
        //        return Ok();
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError($"Something went wrong inside CreateProjectInformation action: {ex.Message} Inner Exception: {ex.InnerException}");
        //        return StatusCode(500, $"Internal server error: {ex.Message}");
        //    }
        //}



        //[HttpPost("financialDetail/NpoId/{NpoId}/applicationPeriodId/{applicationPeriodId}", Name = "CreateFinancialDetail")]
        //      public async Task<IActionResult> CreateFinancialDetail([FromBody] FinancialDetail model, int NpoId, int applicationPeriodId)
        //      {
        //          try
        //          {
        //              var application = await _applicationService.GetApplicationByNpoIdAndPeriodId(NpoId, applicationPeriodId);
        //              model.ApplicationId = application.Id;

        //              await _applicationService.CreateFinancialDetail(model, base.GetUserIdentifier());
        //              return Ok();
        //          }
        //          catch (Exception ex)
        //          {
        //              _logger.LogError($"Something went wrong inside CreateFinancialDetail action: {ex.Message} Inner Exception: {ex.InnerException}");
        //              return StatusCode(500, $"Internal server error: {ex.Message}");
        //          }
        //      }

        [HttpPost("monitoringEvaluation/NpoId/{NpoId}/applicationPeriodId/{applicationPeriodId}", Name = "CreateMonitoringEvaluation")]
        public async Task<IActionResult> CreateMonitoringEvaluation([FromBody] MonitoringEvaluation model, int NpoId, int applicationPeriodId)
        {
            try
            {
                var application = await _applicationService.GetApplicationByNpoIdAndPeriodId(NpoId, applicationPeriodId);
                model.ApplicationId = application.Id;

                await _applicationService.CreateMonitoringEvaluation(model, base.GetUserIdentifier());
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateMonitoringEvaluation action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        //[HttpPut("projectInformation", Name = "UpdateProjectInformation")]
        //public async Task<IActionResult> UpdateProjectInformation([FromBody] ProjectInformation model)
        //{
        //    try
        //    {
        //        await _applicationService.UpdateProjectInformation(model, base.GetUserIdentifier());
        //        return Ok();
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError($"Something went wrong inside UpdateProjectInformation action: {ex.Message} Inner Exception: {ex.InnerException}");
        //        return StatusCode(500, $"Internal server error: {ex.Message}");
        //    }
        //}

        [HttpPut("monitoringEvaluation", Name = "UpdateMonitoringEvaluation")]
        public async Task<IActionResult> UpdateMonitoringEvaluation([FromBody] MonitoringEvaluation model)
        {
            try
            {
                await _applicationService.UpdateMonitoringEvaluation(model, base.GetUserIdentifier());
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside MonitoringEvaluation action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        //[HttpPut("financialDetail", Name = "UpdateFinancialDetail")]
        //public async Task<IActionResult> UpdateFinancialDetail([FromBody] FinancialDetail model)
        //{
        //    try
        //    {
        //        await _applicationService.UpdateFinancialDetail(model, base.GetUserIdentifier());
        //        return Ok();
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError($"Something went wrong inside UpdateFinancialDetail action: {ex.Message} Inner Exception: {ex.InnerException}");
        //        return StatusCode(500, $"Internal server error: {ex.Message}");
        //    }
        //}

        //[HttpGet("financialDetail/NpoId/{NpoId}/applicationPeriodId/{applicationPeriodId}", Name = "GetAllFinancialDetails")]
        //public async Task<IActionResult> GetAllFinancialDetails(int NpoId, int applicationPeriodId)
        //{
        //    try
        //    {
        //        var results = await _applicationService.GetAllFinancialDetailsAsync(NpoId, applicationPeriodId);
        //        return Ok(results);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError($"Something went wrong inside GetAllFinancialDetailsAsync action: {ex.Message} Inner Exception: {ex.InnerException}");
        //        return StatusCode(500, $"Internal server error: {ex.Message}");
        //    }
        //}

        /*
		[HttpPost("CreateBankDetail", Name = "CreateBankDetail")]
		public async Task<IActionResult> CreateBankDetail([FromBody] BankDetail model)
		{
			try
			{
				await _applicationService.CreateBankDetail(model, base.GetUserIdentifier());
				return Ok();
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside CreateBankDetail action: {ex.Message} Inner Exception: {ex.InnerException}");
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}
		*/

        [HttpPost("objectives/NpoId/{NpoId}/applicationPeriodId/{applicationPeriodId}", Name = "CreateObjective")]
        public async Task<IActionResult> CreateObjective([FromBody] Objective model, int NpoId, int applicationPeriodId)
        {
            try
            {
                var application = await _applicationService.GetApplicationByNpoIdAndPeriodId(NpoId, applicationPeriodId);
                model.ApplicationId = application.Id;

                await _applicationService.CreateObjective(model, base.GetUserIdentifier());
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateObjective action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("objectives", Name = "UpdateObjective")]
        public async Task<IActionResult> UpdateObjective([FromBody] Objective model)
        {
            try
            {
                await _applicationService.UpdateObjective(model, base.GetUserIdentifier());
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateObjective action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("activities/NpoId/{NpoId}/applicationPeriodId/{applicationPeriodId}", Name = "GetAllActivities")]
        public async Task<IActionResult> GetAllActivities(int NpoId, int applicationPeriodId)
        {
            try
            {
                var results = await _applicationService.GetAllActivitiesAsync(NpoId, applicationPeriodId);
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllActivities action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("activities/applicationId/{applicationId}", Name = "GetAllActivitiesByApplicationId")]
        public async Task<IActionResult> GetAllActivitiesByApplicationId(int applicationId)
        {
            try
            {
                var results = await _applicationService.GetAllActivitiesByApplicationIdAsync(applicationId);
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllActivities action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("allactivities", Name = "allactivities")]
        public async Task<IActionResult> allactivities()
        {
            try
            {
                var results = await _applicationService.AllActivitiesAsync();
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllActivities action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        [HttpGet("activityId/{activityId}", Name = "GetActivityById")]
        public async Task<IActionResult> GetActivityById(int activityId)
        {
            try
            {
                var results = await _applicationService.GetActivityById(activityId);
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetActivityById action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        

        [HttpGet("getCfpActivityById/activityId/{activityId}", Name = "GetCfpActivityById")]
        public async Task<IActionResult> GetCfpActivityById(int activityId)
        {
            try
            {
                var results = await _applicationService.GetCfpActivityById(activityId);
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetActivityById action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("activities/NpoId/{NpoId}/applicationPeriodId/{applicationPeriodId}", Name = "CreateActivity")]
        public async Task<IActionResult> CreateActivity([FromBody] Activity model, int NpoId, int applicationPeriodId)
        {
            try
            {
                var application = await _applicationService.GetApplicationByNpoIdAndPeriodId(NpoId, applicationPeriodId);
                model.ApplicationId = application.Id;

                await _applicationService.CreateActivity(model, base.GetUserIdentifier());
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateActivity action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("activities", Name = "UpdateActivity")]
        public async Task<IActionResult> UpdateActivity([FromBody] Activity model)
        {
            try
            {
                await _applicationService.UpdateActivity(model, base.GetUserIdentifier());
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateActivity action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("resources/NpoId/{NpoId}/applicationPeriodId/{applicationPeriodId}", Name = "GetAllResources")]
        public async Task<IActionResult> GetAllResources(int NpoId, int applicationPeriodId)
        {
            try
            {
                var results = await _applicationService.GetAllResourcesAsync(NpoId, applicationPeriodId);
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllResources action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("resources/NpoId/{NpoId}/applicationPeriodId/{applicationPeriodId}", Name = "CreateResource")]
        public async Task<IActionResult> CreateResource([FromBody] Resource model, int NpoId, int applicationPeriodId)
        {
            try
            {
                var application = await _applicationService.GetApplicationByNpoIdAndPeriodId(NpoId, applicationPeriodId);
                model.ApplicationId = application.Id;

                await _applicationService.CreateResource(model, base.GetUserIdentifier());
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateResource action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("resources", Name = "UpdateResource")]
        public async Task<IActionResult> UpdateResource([FromBody] Resource model)
        {
            try
            {
                await _applicationService.UpdateResource(model, base.GetUserIdentifier());
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateResource action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("sustainability-plans/NpoId/{NpoId}/applicationPeriodId/{applicationPeriodId}", Name = "GetAllSustainabilityPlans")]
        public async Task<IActionResult> GetAllSustainabilityPlans(int NpoId, int applicationPeriodId)
        {
            try
            {
                var results = await _applicationService.GetAllSustainabilityPlansAsync(NpoId, applicationPeriodId);
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllSustainabilityPlans action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("sustainability-plans/NpoId/{NpoId}/applicationPeriodId/{applicationPeriodId}", Name = "CreateSustainabilityPlan")]
        public async Task<IActionResult> CreateSustainabilityPlan([FromBody] SustainabilityPlan model, int NpoId, int applicationPeriodId)
        {
            try
            {
                var application = await _applicationService.GetApplicationByNpoIdAndPeriodId(NpoId, applicationPeriodId);
                model.ApplicationId = application.Id;

                await _applicationService.CreateSustainabilityPlan(model, base.GetUserIdentifier());
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateSustainabilityPlan action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("sustainability-plans", Name = "UpdateSustainabilityPlan")]
        public async Task<IActionResult> UpdateSustainabilityPlan([FromBody] SustainabilityPlan model)
        {
            try
            {
                await _applicationService.UpdateSustainabilityPlan(model, base.GetUserIdentifier());
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateSustainabilityPlan action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("facilities/NpoId/{NpoId}", Name = "GetAssignedFacilities")]
        public async Task<IActionResult> GetAssignedFacilities(int NpoId)
        {
            try
            {
                var results = await _applicationService.GetAssignedFacilitiesByNpoId(NpoId);
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAssignedFacilities action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("application-comments/applicationId/{applicationId}", Name = "GetAllApplicationComments")]
        public async Task<IActionResult> GetAllApplicationComments(int applicationId)
        {
            try
            {
                var results = await _applicationService.GetAllApplicationComments(applicationId);
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllApplicationComments action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("application-comments/applicationId/{applicationId}/serviceProvisionStepId/{serviceProvisionStepId}/entityId/{entityId}", Name = "GetApplicationComments")]
        public async Task<IActionResult> GetApplicationComments(int applicationId, int serviceProvisionStepId, int entityId)
        {
            try
            {
                var results = await _applicationService.GetApplicationComments(applicationId, serviceProvisionStepId, entityId);
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetApplicationComments action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("application-comments/changesRequired/{changesRequired}", Name = "CreateApplicationComment")]
        public async Task<IActionResult> CreateApplicationComment([FromBody] ApplicationComment model, bool changesRequired)
        {
            try
            {
                await _applicationService.CreateApplicationComment(model, base.GetUserIdentifier());

                if (changesRequired)
                    await _applicationService.UpdateChangesRequired(model, changesRequired, base.GetUserIdentifier());

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateApplicationComment action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("application-audits/applicationId/{applicationId}", Name = "GetApplicationAudits")]
        public async Task<IActionResult> GetApplicationAudits(int applicationId)
        {
            try
            {
                var results = await _applicationService.GetApplicationAudits(applicationId);
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetApplicationAudits action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("approval/applicationId/{applicationId}", Name = "GetApplicationApprovals")]
        public async Task<IActionResult> GetApplicationApprovals(int applicationId)
        {
            try
            {
                var results = await _applicationService.GetApplicationApprovals(applicationId);
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetApplicationApprovals action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("approval", Name = "CreateApplicationApproval")]
        public async Task<IActionResult> CreateApplicationApproval([FromBody] ApplicationApproval model)
        {
            try
            {
                await _applicationService.CreateApplicationApproval(model, base.GetUserIdentifier());
                var results = await _applicationService.GetApplicationApprovals(model.ApplicationId);
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateApplicationApproval action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("approval", Name = "UpdateApplicationApproval")]
        public async Task<IActionResult> UpdateApplicationApproval([FromBody] ApplicationApproval model)
        {
            try
            {
                var results = await _applicationService.GetApplicationApprovals(model.ApplicationId);

                foreach (var item in results)
                {
                    await _applicationService.UpdateApplicationApproval(item, base.GetUserIdentifier());
                }

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateApplicationApproval action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("application-reviewer-satisfaction/applicationId/{applicationId}/serviceProvisionStepId/{serviceProvisionStepId}/entityId/{entityId}", Name = "GetApplicationReviewerSatisfactions")]
        public async Task<IActionResult> GetApplicationReviewerSatisfactions(int applicationId, int serviceProvisionStepId, int entityId)
        {
            try
            {
                var results = await _applicationService.GetApplicationReviewerSatisfactions(applicationId, serviceProvisionStepId, entityId);
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetApplicationReviewerSatisfactions action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("application-reviewer-satisfaction/applicationId/{applicationId}", Name = "GetReviewerSatisfactionByApplicationId")]
        public async Task<IActionResult> GetReviewerSatisfactionByApplicationId(int applicationId)
        {
            try
            {
                var results = await _applicationService.GetReviewerSatisfactionByApplicationId(applicationId);
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetReviewerSatisfactionByApplicationId action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("application-reviewer-satisfaction", Name = "CreateApplicationReviewerSatisfaction")]
        public async Task<IActionResult> CreateApplicationReviewerSatisfaction([FromBody] ApplicationReviewerSatisfaction model)
        {
            try
            {
                await _applicationService.CreateApplicationReviewerSatisfaction(model, base.GetUserIdentifier());
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateApplicationReviewerSatisfaction action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("my-content-link/applicationId/{applicationId}", Name = "GetMyContentLinks")]
        public async Task<IActionResult> GetMyContentLinks(int applicationId)
        {
            try
            {
                var results = await _applicationService.GetMyContentLinks(applicationId);
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetMyContentLinks action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("my-content-link", Name = "CreateMyContentLink")]
        public async Task<IActionResult> CreateMyContentLink([FromBody] MyContentLink model)
        {
            try
            {
                await _applicationService.CreateMyContentLink(model, base.GetUserIdentifier());
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateMyContentLink action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("my-content-link", Name = "UpdateMyContentLink")]
        public async Task<IActionResult> UpdateMyContentLink([FromBody] MyContentLink model)
        {
            try
            {
                await _applicationService.UpdateMyContentLink(model, base.GetUserIdentifier());
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateMyContentLink action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("my-content-links", Name = "UpdateMyContentLinks")]
        public async Task<IActionResult> UpdateMyContentLinks([FromBody] MyContentLink model)
        {
            try
            {
                await _applicationService.UpdateMyContentLink(model, base.GetUserIdentifier());
                var results = await _applicationService.GetMyContentLinks(model.Id);
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateMyContentLink action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        //[HttpPut("UpdateInitiateScorecardValue/applicationId/{applicationId}", Name = "UpdateInitiateScorecardValue")]
        //public async Task<IActionResult> UpdateInitiateScorecardValue(int applicationId)
        //{
        //    try
        //    {
        //        var fundingApplication = await _applicationService.GetById(applicationId);
        //        await _applicationService.UpdateInitiateScorecardValue(applicationId, base.GetUserIdentifier());
        //        await InitiateScorecardNotificationEmail(fundingApplication);

        //        return Ok();
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError($"Something went wrong inside UpdateInitiateScorecardValue action: {ex.Message} Inner Exception: {ex.InnerException}");
        //        return StatusCode(500, $"Internal server error: {ex.Message}");
        //    }
        //}

        [HttpPut("UpdateInitiateScorecardValueAndEmail/applicationId/{applicationId}", Name = "UpdateInitiateScorecardValueAndEmail")]
        public async Task<IActionResult> UpdateInitiateScorecardValueAndEmail(int applicationId, [FromBody] UserVM[] users)
        {
            try
            {
                var fundingApplication = await _applicationService.GetById(applicationId);
                await _applicationService.UpdateInitiateScorecardValue(applicationId, base.GetUserIdentifier());

                await InitiateScorecardNotificationWithEmails(fundingApplication, users);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateInitiateScorecardValueAndEmail action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("UpdatesatisfactionReviewers/applicationId/{applicationId}", Name = "UpdatesatisfactionReviewers")]
        public async Task<IActionResult> UpdatesatisfactionReviewers(int applicationId, [FromBody] UserVM[] users)
        {
            try
            {
                var fundingApplication = await _applicationService.GetById(applicationId);
                await UpdatesatisfactionReviewers(fundingApplication, users);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateInitiateScorecardValueAndEmail action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("UpdateReviewers/applicationId/{applicationId}", Name = "UpdateReviewers")]
        public async Task<IActionResult> UpdateReviewers(int applicationId, [FromBody] UserVM[] users)
        {
            try
            {
                var fundingApplication = await _applicationService.GetById(applicationId);
                await UpdateReviewers(fundingApplication, users);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateInitiateScorecardValueAndEmail action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        private async Task UpdateReviewers(Application fundingApplication, UserVM[] users)
        {
            try
            {
                var initiateScorecardEmail = EmailTemplateFactory
                            .Create(EmailTemplateTypeEnum.NpoReviewer)
                            .Get<NpoReviewerEmailTemplates>()
                            .Init(fundingApplication, users);

                await initiateScorecardEmail.SubmitToQueue();

                await _emailService.SendEmailFromQueue();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside EvaluationController-ConfigureEmail action: {ex.Message} Inner Exception: {ex.InnerException}");
            }
        }




        [HttpPut("Addworkplanapprovers", Name = "Addworkplanapprovers")]
        public async Task<IActionResult> Addworkplanapprovers([FromBody] ApplicationWithUsers model)
        {
            try
            {
                await _applicationService.UpdateApplication(model.application, base.GetUserIdentifier());
                await CreateApplicationAudit(model.application);

                await AddworkplanapproversEmails(model.application, model.userVM);
                return Ok(model.application);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateApplication action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        //[HttpPut(Name = "UpdateApplication")]
        //public async Task<IActionResult> UpdateApplication([FromBody] Application model)
        //{
        //    try
        //    {
        //        await _applicationService.UpdateApplication(model, base.GetUserIdentifier());
        //        await CreateApplicationAudit(model);

        //        await ConfigureEmail(model);
        //        return Ok(model);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError($"Something went wrong inside UpdateApplication action: {ex.Message} Inner Exception: {ex.InnerException}");
        //        return StatusCode(500, $"Internal server error: {ex.Message}");
        //    }
        //}

        [HttpGet("depReviewers/{departmentId}", Name = "depReviewers")]
        public async Task<IActionResult> DepReviewers(int departmentId)
        {
            try
            {
                var users = await _userService.GetByRoleAndDepartmentId((int)RoleEnum.Reviewer, departmentId);

                return Ok(users);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateInitiateScorecardValue action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("workplanapprovers/{departmentId}", Name = "workplanapprovers")]
        public async Task<IActionResult> Workplanapprovers(int departmentId)
        {
            try
            {
                var users = await _userService.WorkplanApprovers((int)RoleEnum.DOHApprover, departmentId);

                return Ok(users);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateInitiateScorecardValue action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("reviewers", Name = "Reviewers")]
        public async Task<IActionResult> Reviewers()
        {
            try
            {
                var users = await _userService.GetByRoleAndDepartmentId(4, 11);

                return Ok(users);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateInitiateScorecardValue action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("UpdateCloseScorecardValue/applicationId/{applicationId}", Name = "UpdateCloseScorecardValue")]
        public async Task<IActionResult> UpdateApplicationById(int applicationId)
        {
            try
            {
                await _applicationService.UpdateCloseScorecardValue(applicationId, base.GetUserIdentifier());
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteApplicationById action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        [HttpPost("createCfp", Name = "CreateCfpApplication")]
        public async Task<IActionResult> CreateCfpApplication(dtoCfpApplication model)
        {
            try
            {
                var applicationPeriod = await _applicationService.GetApplicationPeriodById(model.applicationPeriodId);

                var loggedInUser = await _userRepository.GetByUserNameWithDetails(base.GetUserIdentifier());
                var application = new Application()
                {
                    ApplicationPeriod = null,
                    IsActive = true,
                    CreatedUserId = loggedInUser.Id,
                    CreatedDateTime = DateTime.Now,
                    StatusId = 2,
                    ApplicationPeriodId = model.applicationPeriodId,
                    NpoId = model.npoId,
                    ProgrammeId = model.programmeId,
                    SubProgrammeId = model.subProgrammeId,
                    SubProgrammeTypeId = model.subProgrammeTypeId
                };

                await _applicationRepository.CreateEntity(application);

                var projectInformation = new ProjectInformation()
                {
                    ApplicationId = application.Id,
                    purposeQuestion = model.purposeOfProject,
                    IsActive = true,
                    CreatedUserId = loggedInUser.Id,
                    CreatedDateTime = DateTime.Now
                };

                await _applicationService.CreateProjectInformation(projectInformation);
                
                return Ok(application.Id);
                

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateApplication action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        [HttpGet("objectives/applicationId/{applicationId}", Name = "GetAllObjectivesByApplicationId")]
        public async Task<IActionResult> GetAllObjectivesByApplicationId(int applicationId)
        {
            try
            {
                var results = await _applicationService.GetAllCfpObjectivesAsync(applicationId);
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllObjectives action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("objectives/id/{id}", Name = "GetAObjectivesById")]
        public async Task<IActionResult> GetAObjectivesById(int id)
        {
            try
            {
                var results = await _objectiveRepository.GetById(id);
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllObjectives action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("createObjectives", Name = "CreateObjectives")]
        public async Task<IActionResult> CreateObjectives([FromBody] DtoObjectives model)
        {
            try
            {
                await _applicationService.CreateObjective(model, base.GetUserIdentifier());
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateObjective action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("updateObjectives", Name = "UpdateObjectives")]
        public async Task<IActionResult> UpdateObjectives([FromBody] DtoObjectives model)
        {
            try
            {
                await _applicationService.UpdateObjective(model, base.GetUserIdentifier());
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateObjective action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("deleteObjectives/id/{id}", Name = "DeleteObjectives")]
        public async Task<IActionResult> DeleteObjectives(int id)
        {
            try
            {
                var model = await _objectiveRepository.GetById(id);
                await _objectiveRepository.DeleteAsync(model);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateObjective action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("createCfpActivities", Name = "CreateCfpActivities")]
        public async Task<IActionResult> CreateCfpActivities([FromBody] DtoActivity model)
        {
            try
            {
                await _applicationService.createCfpActivities(model, base.GetUserIdentifier());
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside Create CFP Activity action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("editCfpActivities", Name = "EditCfpActivities")]
        public async Task<IActionResult> EditCfpActivities([FromBody] DtoActivity model)
        {
            try
            {
                await _applicationService.editCfpActivities(model, base.GetUserIdentifier());
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateObjective action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("deleteActivity/id/{id}", Name = "DeleteActivity")]
        public async Task<IActionResult> DeleteActivity(int id)
        {
            try
            {
                var model = await _activityRepository.GetById(id);
                await _activityRepository.DeleteAsync(model);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateObjective action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        private async Task UpdatesatisfactionReviewers(Application fundingApplication, UserVM[] users)
        {
            try
            {
                var initiateScorecardEmail = EmailTemplateFactory
                            .Create(EmailTemplateTypeEnum.SatisficationApprovalEmail)
                            .Get<SatisficationEmailTemplates>()
                            .Init(fundingApplication, users);

                await initiateScorecardEmail.SubmitToQueue();

                await _emailService.SendEmailFromQueue();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside EvaluationController-ConfigureEmail action: {ex.Message} Inner Exception: {ex.InnerException}");
            }
        }


        private async Task AddworkplanapproversEmails(Application fundingApplication, UserVM[] users)
        {
            try
            {
                var initiateScorecardEmail = EmailTemplateFactory
                            .Create(EmailTemplateTypeEnum.AddworkplanapproversEmails)
                            .Get<AddworkplanapproversEmailsTemplates>()
                            .Init(fundingApplication, users);

                await initiateScorecardEmail.SubmitToQueue();

                await _emailService.SendEmailFromQueue();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside EvaluationController-ConfigureEmail action: {ex.Message} Inner Exception: {ex.InnerException}");
            }
        }

        private async Task InitiateScorecardNotificationWithEmails(Application fundingApplication, UserVM[] users)
        {
            try
            {
                var initiateScorecardEmail = EmailTemplateFactory
                            .Create(EmailTemplateTypeEnum.InitiateScorecard)
                            .Get<InitiateScorecardEmailTemplates>()
                            .Init(fundingApplication, users);

                await initiateScorecardEmail.SubmitToQueue();

                await _emailService.SendEmailFromQueue();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside EvaluationController-ConfigureEmail action: {ex.Message} Inner Exception: {ex.InnerException}");
            }
        }

        //private async Task InitiateScorecardNotificationEmail(Application fundingApplication)
        //{
        //    try
        //    {
        //        // Send email to Capturer
        //        var initiateScorecardEmail = EmailTemplateFactory
        //                    .Create(EmailTemplateTypeEnum.InitiateScorecard)
        //                    .Get<InitiateScorecardEmailTemplates>()
        //                    .Init(fundingApplication);

        //        await initiateScorecardEmail.SubmitToQueue();

        //        await _emailService.SendEmailFromQueue();
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError($"Something went wrong inside EvaluationController-ConfigureEmail action: {ex.Message} Inner Exception: {ex.InnerException}");
        //    }
        //}
        #endregion       
    }
}
