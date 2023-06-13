using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NPOMS.Services.Interfaces;

namespace NPOMS.API.Controllers
{
    [Route("api/bankDetails")]
    [ApiController]
    public class BankController
    {
        #region Fields

        private ILogger<BudgetController> _logger;
        private IBankService _bankService;

        #endregion

        #region Constructors

        public BankController(
            ILogger<BankController> logger,
            IBankService bankService)
        {
            //_logger = logger;
            _bankService = bankService;
        }

        #endregion


    }
}
