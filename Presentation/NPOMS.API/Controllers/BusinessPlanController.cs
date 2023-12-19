using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NPOMS.Domain.Enumerations;
using NPOMS.Domain.Indicator;
using NPOMS.Services.Email;
using NPOMS.Services.Email.EmailTemplates;
using NPOMS.Services.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace NPOMS.API.Controllers
{
    [Route("api/businessPlan")]
    [ApiController]
    public class BusinessPlanController : ExternalBaseController
    {

        #region Fields

        private ILogger<IndicatorController> _logger;
        private IIndicatorService _indicatorService;
        private IDropdownService _dropdownService;
        private IApplicationService _applicationService;
        private IEmailService _emailService;

        #endregion

        #region Constructors

        public BusinessPlanController(
            ILogger<IndicatorController> logger,
            IIndicatorService indicatorService,
            IDropdownService dropdownService,
            IApplicationService applicationService,
            IEmailService emailService)
        {
            _logger = logger;
            _indicatorService = indicatorService;
            _dropdownService = dropdownService;
            _applicationService = applicationService;
            _emailService = emailService;
        }

        #endregion

        #region Methods

        #endregion
    }
}
