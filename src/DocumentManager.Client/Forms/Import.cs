using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using DocumentExportUtility_API.Models;
using DocumentExportUtility_API.Log;
using DocumentExportUtility_API.Services;
using DocumentExportUtility_API.Utils;
using DocumentExportUtility_API.Controllers;
using System.Net.Http;
using Newtonsoft.Json;

namespace DocumentExportUtility_API.Forms
{
    public partial class Import : Form
    {
        private EncompassTokenModel _token;
        private TokenHandler _tokenHandler { get; set; }
        private EncompassClient _encClient { get; set; }
        private PdfHelper _pdfHelper { get; set; }
        private ReadExcelHelper _readExcelHelper { get; set; }
        private Logger _log { get; set; }
        private UserData _userData { get; set; }

        private DirectoryInfo _successFolder;
        private DirectoryInfo _failedFolder;
        private StringBuilder _sbLog = new StringBuilder();
        private DateTime _dtNow = DateTime.Now;
        private string _fileName, _guid, _assignDocsGuid, _fullFolderPath;
        private List<string> _fileNames = new List<string>();
        private List<string> _filePaths = new List<string>();
        private Panel _sideMenu;
        private List<BatchImportModel> _batchImportList = new List<BatchImportModel>();

        public Import()
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

            mtbConsole.ScrollBars = ScrollBars.Vertical;
        }

        private void btnBrowsePdfs_Click(object sender, EventArgs e)
        {
            OpenFileDialog _openFileDialog = new OpenFileDialog
            {
                InitialDirectory = @"S:\Shared Folders\Encompass Quattro Files",
                Title = "Select files to import",
                CheckFileExists = true,
                CheckPathExists = true,
                RestoreDirectory = true,
                ReadOnlyChecked = true,
                ShowReadOnly = true,
                Multiselect = true,
                Filter = "PDF Files(*.pdf)|*.pdf|All Files(*.*)|*.*",
            };

            if (_openFileDialog.ShowDialog() == DialogResult.OK)
            {
                _sbLog.Append($"{_dtNow} {GlobalValues.LogActions.info}:." + Environment.NewLine);
                _sbLog.Append($"{_dtNow} {GlobalValues.LogActions.info}:.******************************************\r");
                _sbLog.Append($"{_dtNow} {GlobalValues.LogActions.info}:.main: *** Upload PDFs into eFolder ***\r"
                    + Environment.NewLine);

                _fullFolderPath = Path.GetDirectoryName(_openFileDialog.FileName);
                CreateFolders();

                if (_openFileDialog.FileNames.Length != 0)
                {
                    foreach (var file in _openFileDialog.FileNames)
                    {
                        _fileNames.Add(file);
                        FileInfo info = new FileInfo(file);
                        _filePaths.Add(info.FullName);
                    }
                }
                else
                {
                    MessageBox.Show("Please select at least one file(pdf).", "Import Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnBrowseConfig_Click(object sender, EventArgs e)
        {
            OpenFileDialog _openFileDialog = new OpenFileDialog
            {
                InitialDirectory = @"S:\Shared Folders\Encompass Quattro Files\Document Configs",
                Title = "Select Excel Config File",
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
                tbAssignDocsConfigPath.Text = file;
                var fileName = _openFileDialog.FileName;
                var _dataType = "quattro";
                var success = _readExcelHelper.ReadExcel(fileName, _dataType);

                if(!success)
                {
                    tbAssignDocsConfigPath.Text = string.Empty;
                }
            }
        }

        private async void btnImport_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbLoanGuid.Text))
            {
                MessageBox.Show("Loan Guid cannot be blank.", "Loan GUID", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(_filePaths.Count == 0)
            {
                MessageBox.Show("Please select at least one file(pdf).", "Import Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                _token = await _tokenHandler.GetEncompassToken(_userData.UserId, _userData.Password, _userData.Instance,
                _userData.ClientId, _userData.Secret);
                _guid = tbLoanGuid.Text;
                FileImportController fileImportController = new FileImportController(_token, _encClient, _pdfHelper, _log,
                    _fileNames, _fullFolderPath, _fileName, _filePaths, _guid, _sideMenu, mtbConsole, panelImportSingle);
                fileImportController.Import();
                panelImportSingle.Enabled = false;
            }
        }

        private void btnAssignDocs_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbAssignDocsGuid.Text))
            {
                MessageBox.Show("Loan Guid cannot be blank.", "Loan GUID", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (string.IsNullOrWhiteSpace(tbAssignDocsConfigPath.Text))
            {
                MessageBox.Show("Please select a document configuration.", "Document Config", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                _assignDocsGuid = tbAssignDocsGuid.Text;
                AssignAttachmentsController assignDocs = new AssignAttachmentsController(_tokenHandler, _encClient,
                    _assignDocsGuid, _readExcelHelper, _token, _log, _sideMenu, mtbConsole, _userData);
                assignDocs.ProcessUnassignedAttachments();
            }
        }

        private void cbCopyGuid_CheckedChanged(object sender, EventArgs e)
        {
            if (cbCopyGuid.Checked)
            {
                if (!string.IsNullOrWhiteSpace(tbLoanGuid.Text))
                {
                    tbAssignDocsGuid.Text = tbLoanGuid.Text;
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
                lbLoanReportPath.Text = _openFileDialog.FileName;
                _fileName = _openFileDialog.FileName;
                var _dataType = "loanList";
                var success = _readExcelHelper.ReadExcel(lbLoanReportPath.Text, _dataType);

                if(success)
                {
                    _sbLog.Append($"{_dtNow} {GlobalValues.LogActions.info}:...file path: {_openFileDialog.FileName}\r");
                    _sbLog.Append($"{_dtNow} {GlobalValues.LogActions.info}:...loan count: {_readExcelHelper.LoanGuidList.Count}\r");
                    mtbConsole.Text += $"Encompass Loan List selected: {_openFileDialog.FileName}\r\n" +
                        $"Loan Count: {_readExcelHelper.LoanGuidList.Count}" + Environment.NewLine;
                }
                else
                {
                    lbLoanReportPath.Text = "No file selected.";
                }
            }
        }

        private void btnBrowseRootFolder_Click(object sender, EventArgs e)
        {
            using (var fdb = new FolderBrowserDialog())
            {
                DialogResult result = fdb.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fdb.SelectedPath))
                {
                    lbRootFolderPath.Text = fdb.SelectedPath;

                    string[] dirs = Directory.GetDirectories(fdb.SelectedPath);
                    string[] filePaths = Directory.GetFiles(fdb.SelectedPath, "*.pdf", SearchOption.AllDirectories);

                    foreach (var dir in dirs)
                    {
                        string loanNumber = Path.GetFileName(dir.TrimEnd(Path.DirectorySeparatorChar));

                        foreach(var file in filePaths)
                        {
                            string fileName = Path.GetFileName(file.TrimEnd(Path.DirectorySeparatorChar));
                            _batchImportList.Add(new BatchImportModel(loanNumber, fileName));
                        }
                    }
                }
            }
        }

        private void CreateFolders()
        {
            string successFolderPath = Path.Combine(_fullFolderPath, "Success");
            string failFolderPath = Path.Combine(_fullFolderPath, "Failed");
            _successFolder = Directory.CreateDirectory(successFolderPath);
            _failedFolder = Directory.CreateDirectory(failFolderPath);
        }   

        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
