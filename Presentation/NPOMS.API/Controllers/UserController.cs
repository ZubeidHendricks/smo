using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NPOMS.Services.Implementation;
using NPOMS.Services.Interfaces;
using NPOMS.Services.Models;
using System;
using System.Threading.Tasks;

namespace NPOMS.API.Controllers
{
	[Route("api/users")]
    [ApiController]
    public class UserController : ExternalBaseController
    {
        #region Fields

        private ILogger<UserController> _logger;
        private IUserService _userService;

        #endregion

        #region Constructors

        public UserController(
			ILogger<UserController> logger,
            IUserService userService
            )
        {
            _logger = logger;
            _userService = userService;
        }

        #endregion

        #region Methods

        [HttpGet(Name = "Get")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var results = await _userService.GetAll();
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside Get action: {ex.Message} Inner Exception: { ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

		[HttpGet("{userName}", Name = "GetLoggedInUser")]
		public async Task<IActionResult> GetLoggedInUser(string userName)
		{
			try
			{
				var results = await _userService.Get(GetUserIdentifier(), base.GetGivenName(), base.GetSurname(), true);
				return Ok(results);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside GetLoggedInUser action: {ex.Message} Inner Exception: { ex.InnerException}");
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

		[HttpPost(Name = "CreateUser")]
		public async Task<IActionResult> CreateUser([FromBody] UserViewModel user)
		{
			try
			{
				if (user == null)
				{
					return BadRequest("User object is null");
				}

				var userViewModel = await this._userService.Create(user, base.GetUserIdentifier());
				return Ok(userViewModel);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside CreateUser action: {ex.Message} Inner Exception: { ex.InnerException}");
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

		[HttpPut(Name = "UpdateUser")]
		public async Task<IActionResult> UpdateUser([FromBody] UserViewModel user)
		{
			try
			{
				if (user == null)
				{
					return BadRequest("User object is null");
				}

				var userViewModel = await this._userService.Update(user, base.GetUserIdentifier());
				return Ok(userViewModel);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside UpdateUser action: {ex.Message} Inner Exception: { ex.InnerException}");
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

		[HttpGet("global", Name = "OrganizationalSearch")]
		public async Task<IActionResult> OrganizationalSearch([FromQuery] string searchTerm)
		{
			try
			{
				var accounts = await this._userService.Search(searchTerm);
				return Ok(accounts);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside OrganizationalSearch action: {ex.Message} Inner Exception: { ex.InnerException}");
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

		[HttpGet("id/{id}", Name = "GetUserById")]
		public async Task<IActionResult> GetUserById(int id)
		{
			try
			{
				var results = await this._userService.GetById(id);
				return Ok(results);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside GetUserById action: {ex.Message} Inner Exception: {ex.InnerException}");
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

		#endregion
	}
}
