using DocumentExportUtility_API.Controllers;
using DocumentExportUtility_API.Models;
using DocumentExportUtility_API.Services;
using System;
using System.Net.Http;
using System.Windows.Forms;

namespace DocumentExportUtility_API.Forms
{
    public partial class Login : Form
    {
        private TokenHandler TokenHandler { get; set; }
        private UserData UserData { get; set; }
        private HttpClient HttpClient;
        private EncompassClient EncompassClient;

        private string _instance;
        private string _devEnvironement = "TEBE11229004";
        private string _prodEnvironment = "BE11222097";

        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            HttpClient = new HttpClient();
            EncompassClient = new EncompassClient(HttpClient);
            TokenHandler = new TokenHandler(EncompassClient);
            UserData = new UserData();
        }

        private void ddServer_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (ddServer.SelectedIndex)
            {
                case 1:
                    _instance = _prodEnvironment;
                    break;
                case 2:
                    _instance = _devEnvironement;
                    break;
            }
        }

        private void tbPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                UserLogin();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            UserLogin();
        }

        private void UserLogin()
        {
            if (string.IsNullOrWhiteSpace(tbUsername.Text) || string.IsNullOrWhiteSpace(tbPassword.Text))
            {
                MessageBox.Show("UserId or Password is empty.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (string.IsNullOrWhiteSpace(ddServer.Text))
            {
                MessageBox.Show("Please select a server.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                UserData.UserId = tbUsername.Text;
                UserData.Password = tbPassword.Text;
                UserData.Instance = _instance;

                LoginController loginController = new LoginController(TokenHandler, EncompassClient, HttpClient, UserData, this);
                loginController.LoginSequence();
            }
        }
    }
}
