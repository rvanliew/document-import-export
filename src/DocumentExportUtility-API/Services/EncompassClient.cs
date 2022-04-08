using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using DocumentExportUtility_API.Models;
using System.Net.Http.Headers;
using System.Text.Json;

namespace DocumentExportUtility_API.Services
{
    public class EncompassClient
    {
        private HttpClient _httpClient { get; set; }
        private string _smartClientUser;
        private string _smartClientPassword;
        private string _instance;
        private string _clientId;
        private string _clientSecret;
        private object _cdoName;

        public EncompassClient(HttpClient client)
        {
            _httpClient = client;
        }

        public async Task<HttpResponseMessage> GetAccessToken(string smartClientUser, string smartClientPassword, string instance,
            string clientId, string clientSecret)
        {
            _smartClientUser = smartClientUser;
            _smartClientPassword = smartClientPassword;
            _instance = instance;
            _clientId = clientId;
            _clientSecret = clientSecret;

            var parameters = new Dictionary<string, string>
            {
                {"grant_type", "password" },
                {"username", $"{_smartClientUser}@encompass:{_instance}" },
                {"password", $"{_smartClientPassword}" },
                {"client_id", $"{_clientId}" },
                {"client_secret", $"{_clientSecret}" }
            };
            var content = new FormUrlEncodedContent(parameters);
            var response = await _httpClient.PostAsync("https://api.elliemae.com/oauth2/v1/token", content);
            return response;
        }

        /// <summary>
        /// V1 API: Gets a single attachment for specific loanGuid
        /// </summary>
        /// <param name="loanGuid"></param>
        /// <param name="token"></param>
        /// <param name="attachmentId"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> GetAttachment(string loanGuid, EncompassTokenModel token, string attachmentId)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://api.elliemae.com/encompass/v1/loans/{loanGuid}/attachments/{attachmentId}?generateURL=true"),
            };
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token.AccessToken);
            var response = await _httpClient.SendAsync(request);
            return response;
        }

        /// <summary>
        /// V1 API: Gets all attachments for specified loanGuid
        /// </summary>
        /// <param name="loanGuid"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> GetAttachments(string loanGuid, EncompassTokenModel token)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://api.elliemae.com/encompass/v1/loans/{loanGuid}/attachments")
            };
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token.AccessToken);
            var response = await _httpClient.SendAsync(request);
            return response;
        }

        public async Task<HttpResponseMessage> GetDocuments(string loanGuid, EncompassTokenModel token)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://api.elliemae.com/encompass/v1/loans/{loanGuid}/documents")
            };
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token.AccessToken);
            var response = await _httpClient.SendAsync(request);
            return response;
        }

        public async Task<HttpResponseMessage> CreateDocument(string loanGuid, EncompassTokenModel token, StringContent payload)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri($"https://api.elliemae.com/encompass/v1/loans/{loanGuid}/documents?view=id"),
                Content = payload
            };
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token.AccessToken);
            var response = await _httpClient.SendAsync(request);
            return response;
        }

        public async Task<HttpResponseMessage> AssignAttachments(EncompassTokenModel token, string loanGuid, string docId, StringContent payload)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Patch,
                RequestUri = new Uri($"https://api.elliemae.com/encompass/v1/loans/{loanGuid}/documents/{docId}/attachments?action=add"),
                Content = payload
            };
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token.AccessToken);
            var response = await _httpClient.SendAsync(request);
            return response;
        }

        public async Task<HttpResponseMessage> GetSpecificCDO(EncompassTokenModel token)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://api.elliemae.com/encompass/v1/company/customObjects/{_cdoName}")
            };
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token.AccessToken);
            var response = await _httpClient.SendAsync(request);
            return response;
        }

        /// <summary>
        /// V3 API: Get URL to Upload Attachment to eFolder
        /// </summary>
        /// <param name="token"></param>
        /// <param name="loanGuid"></param>
        /// <param name="payload"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> GetUploadAttachmentUrl(EncompassTokenModel token, string loanGuid, StringContent payload)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri($"https://api.elliemae.com/encompass/v3/loans/{loanGuid}/attachmentUploadUrl"),
                Content = payload
            };
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token.AccessToken);
            var response = await _httpClient.SendAsync(request);
            return response;
        }

        /// <summary>
        /// V3 API: Upload Attachment
        /// </summary>
        /// <param name="uploadUrl"></param>
        /// <param name="authorization"></param>
        /// <param name="payload"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> UploadAttachment(string uploadUrl, string authorization, byte[] payload)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Put,
                RequestUri = new Uri($"{uploadUrl}"),
                Content = new ByteArrayContent(payload)
            };
            //Clear out old auth header
            _httpClient.DefaultRequestHeaders.Clear();
            //Add new auth header
            _httpClient.DefaultRequestHeaders.Add("Authorization", authorization);
            var response = await _httpClient.SendAsync(request);
            return response;
        }

        public async Task<HttpResponseMessage> AddComments(EncompassTokenModel token, string loanGuid, string docId, StringContent payload)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Patch,
                RequestUri = new Uri($"https://api.elliemae.com/encompass/v3/loans/{loanGuid}/documents/{docId}/comments?action=add&view=entity"),
                Content = payload
            };
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token.AccessToken);
            var response = await _httpClient.SendAsync(request);
            return response;
        }
    }
}
