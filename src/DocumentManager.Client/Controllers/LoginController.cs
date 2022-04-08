using DocumentExportUtility_API.Forms;
using DocumentExportUtility_API.Log;
using DocumentExportUtility_API.Models;
using DocumentExportUtility_API.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DocumentExportUtility_API.Controllers
{
    public class LoginController
    {
        private TokenHandler _tokenHandler { get; set; }
        private EncompassClient _encompassClient { get; set; }
        private HttpClient _client { get; set; }
        private EncompassTokenModel _token { get; set; }
        private UserData _userData { get; set; }
        private Form _loginForm { get; set; }

        private string _apiSettingsPath = @"S:\Shared Folders\Encompass\API Config\ApiConfig.json";
        private string _clientId, _clientSecret, _userId, _password, _selectedEnvironment;
        private bool _isValid;

        public LoginController(TokenHandler tokenHandler,EncompassClient encompassClient, HttpClient client, UserData userData, Form loginForm)
        {
            _tokenHandler = tokenHandler;
            _encompassClient = encompassClient;
            _client = client;
            _userData = userData;
            _loginForm = loginForm;
        }

        private void DecryptJson()
        {
            try
            {
                using (StreamReader sr = new StreamReader(_apiSettingsPath))
                {
                    string json = sr.ReadToEnd();
                    var deserializedList = JsonConvert.DeserializeObject<ApiSettingsModel>(json);

                    _userData.ClientId = deserializedList.client_id;
                    _userData.Secret = deserializedList.client_secret;
                    _isValid = true;
                }
            }
            catch (Exception ex)
            {
                _isValid = false;
            }
        }

        private async void GetToken()
        {
            _token = await _tokenHandler.GetEncompassToken(_userData.UserId, _userData.Password, _userData.Instance, 
                _userData.ClientId, _userData.Secret);
            if (string.IsNullOrWhiteSpace(_token.AccessToken))
            {
                MessageBox.Show($"Could not authenticate user.",
                    "Encompass Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                LoadDashboard();
                _loginForm.Hide();
            }
        }

        public void LoginSequence()
        {
            DecryptJson();
            if (_isValid)
            {
                GetToken();
            }
            else
            {
                MessageBox.Show("Could not retrieve api settings!", "API Settings", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void LoadDashboard()
        {
            var mainMenu = new MainMenu(_encompassClient, _tokenHandler, _client, _token, _userData);
            mainMenu.Show();
            mainMenu.BringToFront();
        }
    }
}
