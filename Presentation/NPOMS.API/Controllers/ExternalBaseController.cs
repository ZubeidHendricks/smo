using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace NPOMS.API.Controllers
{
	[Authorize]
	public class ExternalBaseController : ControllerBase
	{
		protected string GetUserIdentifier(string userIdentifier = null)
		{
			var claim = User.FindFirst("emails")?.Value;

			if (claim == null)
				return null;

			return claim;
		}

		protected string GetGivenName()
		{
			var claim = User.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/givenname")?.Value;

			if (claim == null)
				return null;

			return claim;
		}

		protected string GetSurname()
		{
			var claim = User.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/surname")?.Value;

			if (claim == null)
				return null;

			return claim;
		}
	}
}
