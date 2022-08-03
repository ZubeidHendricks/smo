using Microsoft.Azure.Services.AppAuthentication;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Repository
{
    public class AzureSqlAuthTokenService : IDBAuthTokenService
    {
        public async Task<string> GetToken()
        {
            AzureServiceTokenProvider provider = new AzureServiceTokenProvider();
            var token = await provider.GetAccessTokenAsync("https://database.windows.net/");

            return token;
        }
    }

    public interface IDBAuthTokenService
    {
        Task<string> GetToken();
    }
}
