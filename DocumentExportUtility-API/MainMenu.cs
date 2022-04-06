using System;
using System.Text;
using System.Windows.Forms;
using DocumentExportUtility_API.Services;
using System.Net.Http;
using Newtonsoft.Json;
using DocumentExportUtility_API.Models;
using DocumentExportUtility_API.Forms;
using DocumentExportUtility_API.Log;
using DocumentExportUtility_API.Utils;
using System.IO;
using System.Drawing;
using FontAwesome.Sharp;

namespace DocumentExportUtility_API
{
    public partial class MainMenu : Form
    {
        private EncompassClient _encompassClient { get; set; }
        private TokenHandler _tokenHandler { get; set; }
        private Logger _logging { get; set; }
        private PdfHelper _pdfHelper { get; set; }
        private ReadExcelHelper _readExcelHelper { get; set; }
        private HttpClient _client { get; set; }
        private EncompassTokenModel _token { get; set; }
        private UserData _userData { get; set; }

        //Ui Elements
        private IconButton _currentBtn;
        private Panel _leftBorderColorPanel;

        public MainMenu(EncompassClient encompassClient, TokenHandler tokenHandler, HttpClient client, 
            EncompassTokenModel token, UserData userData)
        {
            InitializeComponent();

            _encompassClient = encompassClient;
            _tokenHandler = tokenHandler;
            _client = client;
            _token = token;
            _userData = userData;
        }

        private struct RGBColors
        {
            public static Color green = Color.FromArgb(3, 218, 198);
            public static Color purple = Color.FromArgb(195, 143, 255);
            public static Color red = Color.FromArgb(255, 88, 88);
            public static Color blue = Color.FromArgb(88, 182, 255);
            public static Color gray = Color.FromArgb(226, 226, 226);
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            _logging = new Logger();
            _pdfHelper = new PdfHelper();
            _readExcelHelper = new ReadExcelHelper();

            //Ui Elements
            _leftBorderColorPanel = new Panel();
            _leftBorderColorPanel.Size = new Size(7, 45);
            panelSideMenu.Controls.Add(_leftBorderColorPanel);
        }

        #region UI Controls
        private void ClearMainPanel()
        {
            panelMainMenu.Controls.Clear();
        }

        private void ActivateButton(object senderBtn, Color color)
        {
            if (senderBtn != null)
            {
                DisableButton();
                //Button
                _currentBtn = (IconButton)senderBtn;
                _currentBtn.BackColor = Color.FromArgb(58, 58, 58);
                _currentBtn.ForeColor = color;
                _currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                _currentBtn.IconColor = color;
                _currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                _currentBtn.ImageAlign = ContentAlignment.MiddleRight;

                //Left Button Border
                _leftBorderColorPanel.BackColor = color;
                _leftBorderColorPanel.Location = new Point(0, _currentBtn.Location.Y);
                _leftBorderColorPanel.Visible = true;
                _leftBorderColorPanel.BringToFront();
            }
        }

        private void DisableButton()
        {
            if (_currentBtn != null)
            {
                _currentBtn.BackColor = Color.FromArgb(26, 26, 36);
                _currentBtn.ForeColor = Color.White;
                _currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                _currentBtn.IconColor = Color.White;
                _currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                _currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }

        private void HideSubMenu()
        {
            if(panelImportExportSubMenu.Visible == true)
            {
                panelImportExportSubMenu.Visible = false;
            }
        }

        private void ShowSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                HideSubMenu();
                subMenu.Visible = true;
            }
            else
            {               
                subMenu.Visible = false;
                DisableButton();
            }
        }
        #endregion

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            ActivateButton(btnDashboard, RGBColors.green);
            var dashboard = new Dashboard() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            dashboard.FormBorderStyle = FormBorderStyle.None;
            ClearMainPanel();
            panelMainMenu.Controls.Add(dashboard);
            dashboard.Show();
        }

        private void btnFileManager_Click(object sender, EventArgs e)
        {
            ShowSubMenu(panelImportExportSubMenu);
            ActivateButton(btnFileManager, RGBColors.purple);
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            var import = new Import() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            import.FormBorderStyle = FormBorderStyle.None;
            ClearMainPanel();
            panelMainMenu.Controls.Add(import);
            import.FormLoad(_token, _tokenHandler, _encompassClient, _pdfHelper, _logging, panelSideMenu, _readExcelHelper, _userData);
            import.Show();

            HideSubMenu();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            var export = new Export() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            export.FormBorderStyle = FormBorderStyle.None;
            ClearMainPanel();
            panelMainMenu.Controls.Add(export);
            export.FormLoad(_token, _tokenHandler, _encompassClient, _pdfHelper, _logging, panelSideMenu, _readExcelHelper, _userData);
            export.Show();

            HideSubMenu();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            var settings = new Settings() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            settings.FormBorderStyle = FormBorderStyle.None;
            ClearMainPanel();
            panelMainMenu.Controls.Add(settings);
            settings.FormLoad(_logging);
            settings.Show();
        }

        private void btnSandbox_Click(object sender, EventArgs e)
        {
            var sandbox = new Sandbox() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            sandbox.FormBorderStyle = FormBorderStyle.None;
            ClearMainPanel();
            panelMainMenu.Controls.Add(sandbox);
            sandbox.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
