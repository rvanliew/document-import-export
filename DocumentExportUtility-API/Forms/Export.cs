using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Windows.Forms;
using DocumentExportUtility_API.Models;
using DocumentExportUtility_API.Services;
using DocumentExportUtility_API.Utils;
using DocumentExportUtility_API.Log;
using Newtonsoft.Json;
using System.IO;
using DocumentExportUtility_API.Controllers;
using System.Drawing;

namespace DocumentExportUtility_API.Forms
{
    public partial class Export : Form
    {
        private EncompassTokenModel _token;
        private TokenHandler _tokenHandler { get; set; }
        private EncompassClient _encClient { get; set; }
        private PdfHelper _pdfHelper { get; set; }
        private ReadExcelHelper _readExcelHelper { get; set; }
        private Logger _log { get; set; }
        private UserData _userData { get; set; }

        private Panel _sideMenu;
        private StringBuilder _sbLog = new StringBuilder();
        private DateTime _dtNow = DateTime.Now;
        private string _exportFolderPath;
        private string _fileName;
        private List<Button> _buttonList = new List<Button>();

        public Export()
        {
            InitializeComponent();
        }

        public void FormLoad(EncompassTokenModel token, TokenHandler tokenHandler, EncompassClient encompassClient, 
            PdfHelper pdfHelper, Log.Logger log, Panel sideMenu, ReadExcelHelper readExcelHelper, UserData userData)
        {
            _token = token;
            _tokenHandler = tokenHandler;
            _encClient = encompassClient;
            _pdfHelper = pdfHelper;
            _log = log;
            _sideMenu = sideMenu;
            _readExcelHelper = readExcelHelper;
            _userData = userData;
            tbConsole.ScrollBars = ScrollBars.Vertical;

            _buttonList.Add(btnBrowseLoanReport);
            _buttonList.Add(btnBrowseDocConfig);
            _buttonList.Add(btnExportPathBrowse);
            _buttonList.Add(btnExport);
        }

        private void btnBrowseDocConfig_Click(object sender, EventArgs e)
        {
            OpenFileDialog _openFileDialog = new OpenFileDialog
            {
                InitialDirectory = @"S:\Shared Folders\Encompass Quattro Files\Document Configs",
                Title = "Select Configuration File",
                CheckFileExists = true,
                CheckPathExists = true,
                DefaultExt = "xlsx",
                RestoreDirectory = true,
                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (_openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var file = Path.GetFileName(_openFileDialog.FileName);
                tbConfig.Text = file;
                var fileName = _openFileDialog.FileName;
                var dataType = "quattro";
                var success = _readExcelHelper.ReadExcel(fileName, dataType);

                if (!success)
                {
                    tbConfig.Text = string.Empty;
                }
            }
        }

        private void btnBrowseLoanReport_Click(object sender, EventArgs e)
        {
            OpenFileDialog _openFileDialog = new OpenFileDialog
            {
                InitialDirectory = @"C:\",
                Title = "Select Encompass Loan Report",
                CheckFileExists = true,
                CheckPathExists = true,
                DefaultExt = "xlsx",
                RestoreDirectory = true,
                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (_openFileDialog.ShowDialog() == DialogResult.OK)
            {
                tbFileName.Text = _openFileDialog.FileName;
                _fileName = _openFileDialog.FileName;
                var dataType = "loanList";
                var success = _readExcelHelper.ReadExcel(tbFileName.Text, dataType);

                if(success)
                {
                    _sbLog.Append($"{_dtNow} {GlobalValues.LogActions.info}:...file path: {_openFileDialog.FileName}\r");
                    _sbLog.Append($"{_dtNow} {GlobalValues.LogActions.info}:...loan count: {_readExcelHelper.LoanGuidList.Count}\r");
                    tbConsole.Text += $"Encompass Loan List selected: {_openFileDialog.FileName}\r\n" +
                        $"Loan Count: {_readExcelHelper.LoanGuidList.Count}" + Environment.NewLine;
                }
                else
                {
                    tbFileName.Text = string.Empty;
                }             
            }
        }

        private void btnExportPathBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                tbExportPath.Text = folderBrowserDialog.SelectedPath;
                _exportFolderPath = folderBrowserDialog.SelectedPath;
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbConfig.Text))
            {
                MessageBox.Show("Please select a document configuration.", "Document Config", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (string.IsNullOrWhiteSpace(tbFileName.Text))
            {
                MessageBox.Show("Loan list cannot be blank.", "Loan List", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (string.IsNullOrWhiteSpace(tbExportPath.Text))
            {
                MessageBox.Show("Please select an export folder.", "Export Folder", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                ExportAttachmentsController exportAttachments = new ExportAttachmentsController(_token, _tokenHandler, 
                    _encClient, _readExcelHelper, _pdfHelper, tbConsole, 
                    _buttonList, _log, _exportFolderPath, _sideMenu, _userData);
                exportAttachments.ExportProcess();
            }
        }

        private void btnCloseForm_MouseHover(object sender, EventArgs e)
        {
            btnCloseForm.IconColor = Color.Red;
        }

        private void btnCloseForm_MouseLeave(object sender, EventArgs e)
        {
            btnCloseForm.IconColor = Color.White;
        }

        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
