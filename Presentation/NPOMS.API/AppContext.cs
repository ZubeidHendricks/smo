using Microsoft.AspNetCore.Http;
using System;
using System.Linq;

namespace NPOMS.API
{
	public static class AppContext
    {
        private static IHttpContextAccessor _httpContextAccessor;

        public static void Configure(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            // ...
        }

        public static int GetClientID()
        {
            int result = 0;
            var claim = CurrentHttpContext.User.Claims.FirstOrDefault(c => c.Type == "ClientID");
            if (claim != null)
            {
                result = Convert.ToInt32(claim.Value);
            }
            return result;
        }

        // You can even expose the current HTTP context
        public static HttpContext CurrentHttpContext { get { return _httpContextAccessor.HttpContext; } }
    }
}
