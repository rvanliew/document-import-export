using DocumentExportUtility_API.Forms;
using DocumentExportUtility_API.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace DocumentExportUtility_API.Services
{
    public class TokenHandler
    {
        private EncompassClient _encompassClient { get; set; }
        private static EncompassTokenModel _encompassToken = new EncompassTokenModel();
        private static SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);

        private string _userId, _password, _selectedEnvironment, _clientId, _clientSecret;

        public TokenHandler(EncompassClient encompassClient)
        {
            _encompassClient = encompassClient;
        }

        public async Task<EncompassTokenModel> GetEncompassToken(string userId, string password, string selectedEnvironment,
            string clientId, string clientSecret)
        {
            _userId = userId;
            _password = password;
            _selectedEnvironment = selectedEnvironment;
            _clientId = clientId;
            _clientSecret = clientSecret;

            await _semaphore.WaitAsync();
            try
            {
                if (!EncompassTokenIsActive())
                {
                    await RequestEncompassToken();
                }
            }
            finally
            {
                _semaphore.Release();
            }
            return _encompassToken;
        }

        private bool EncompassTokenIsActive()
        {
            if (string.IsNullOrWhiteSpace(_encompassToken.AccessToken))
            {
                return false;
            }
            var offset = DateTimeOffset.FromUnixTimeSeconds(_encompassToken.Exp);
            if (DateTime.UtcNow.AddMinutes(5) < offset.UtcDateTime)
            {
                return true;
            }
            return false;
        }

        private async Task RequestEncompassToken()
        {
            var response = await _encompassClient.GetAccessToken(_userId, _password, _selectedEnvironment, _clientId, _clientSecret);
            var responseContent = await response.Content.ReadAsStringAsync();
            var newToken = JsonConvert.DeserializeObject<EncompassTokenModel>(responseContent);
            _encompassToken = newToken;
        }
    }
}
