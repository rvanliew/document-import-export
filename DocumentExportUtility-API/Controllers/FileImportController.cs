using DocumentExportUtility_API.Log;
using DocumentExportUtility_API.Models;
using DocumentExportUtility_API.Services;
using DocumentExportUtility_API.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Windows.Forms;

namespace DocumentExportUtility_API.Controllers
{
    public class FileImportController
    {
        private EncompassTokenModel _token { get; set; }
        private EncompassClient _encompassClient { get; set; }
        private PdfHelper _pdfHelper { get; set; }
        private Logger _log { get; set; }

        private StringBuilder _sbLog = new StringBuilder();
        private DateTime _dtNow = DateTime.Now;
        private DirectoryInfo _successFolder, _failedFolder;
        private List<string> _fileNames = new List<string>();
        private List<string> _filePaths = new List<string>();
        private int _fileCount = 0;
        private int _successCount, _errorCount;
        private string _fullFolderPath, _fileName, _guid, _authHeader, _uploadUrl;
        private StringContent _payload;
        private byte[] _pdfByteArray;
        private int _size;
        private bool _result;

        //UI Elements
        private Panel _sideMenu, _panelImportSingle;
        private TextBox _mtbConsole, tbLoanGuid;

        public FileImportController(EncompassTokenModel token, EncompassClient encompassClient,
            PdfHelper pdfHelper, Logger log, List<string> fileNames, string fullFolderPath, string fileName,
            List<string> filePaths, string guid, Panel sideMenu, TextBox mtbConsole, Panel panelImportSingle)
        {
            _token = token;
            _encompassClient = encompassClient;
            _pdfHelper = pdfHelper;
            _log = log;
            _fileNames = fileNames;
            _fullFolderPath = fullFolderPath;
            _fileName = fileName;
            _filePaths = filePaths;
            _guid = guid;
            _sideMenu = sideMenu;
            _mtbConsole = mtbConsole;
            _panelImportSingle = panelImportSingle;
        }

        public async void Import()
        {
            ResetCounts();
            _sideMenu.Enabled = false;
            _mtbConsole.AppendText($"{_dtNow} {GlobalValues.LogActions.info}:...IMPORTING FILES" + Environment.NewLine);
            foreach (var file in _fileNames)
            {
                _fileCount++;
                _mtbConsole.AppendText($"{_dtNow} {GlobalValues.LogActions.info}:...Importing File {_fileCount} of {_fileNames.Count}" + Environment.NewLine);
                _fileName = Path.GetFileName(file);
                var title = Path.GetFileNameWithoutExtension(file);
                _sbLog.Append($"{_dtNow} {GlobalValues.LogActions.info}:...fileName: {_fileName}\r");
                _sbLog.Append($"{_dtNow} {GlobalValues.LogActions.info}:...title: {title}\r");

                _mtbConsole.AppendText($"{_dtNow} {GlobalValues.LogActions.info}:...fileName: {_fileName}" + Environment.NewLine);
                _mtbConsole.AppendText($"{_dtNow} {GlobalValues.LogActions.info}:...title: {title}" + Environment.NewLine);
                _mtbConsole.AppendText($"{_dtNow} {GlobalValues.LogActions.info}:...filepath: {_filePaths[_fileCount - 1]}" + Environment.NewLine);

                try
                {
                    _sbLog.Append($"{_dtNow} {GlobalValues.LogActions.info}:...creating byte array\r");
                    _mtbConsole.AppendText($"{_dtNow} {GlobalValues.LogActions.info}:...creating byte array" + Environment.NewLine);
                    _pdfByteArray = _pdfHelper.ConvertToByteArray(file);
                    _size = _pdfByteArray.Length;
                    _sbLog.Append($"{_dtNow} {GlobalValues.LogActions.info}:...byte array created...size: {_size}\r");
                    _mtbConsole.AppendText($"{_dtNow} {GlobalValues.LogActions.info}:...byte array created...size: {_size}" + Environment.NewLine);
                }
                catch (Exception ex)
                {
                    _sbLog.Append($"{_dtNow} {GlobalValues.LogActions.error}:.error creating byte array\r");
                    _mtbConsole.AppendText($"{_dtNow} {GlobalValues.LogActions.error}:.error creating byte array" + Environment.NewLine);
                    _mtbConsole.AppendText($"{_dtNow} {GlobalValues.LogActions.error}:.exception: {ex}" + Environment.NewLine);
                }

                _sbLog.Append($"{_dtNow} {GlobalValues.LogActions.info}:...creating payload\r");
                _mtbConsole.AppendText($"{_dtNow} {GlobalValues.LogActions.info}:...creating payload" + Environment.NewLine);
                _payload = CreatePayload(_fileName, _size, title);

                if (_payload != null)
                {
                    _sbLog.Append($"{_dtNow} {GlobalValues.LogActions.info}:...payload created\r");
                    _mtbConsole.AppendText($"{_dtNow} {GlobalValues.LogActions.info}:...payload created" + Environment.NewLine);

                    _sbLog.Append($"{_dtNow} {GlobalValues.LogActions.info}:...processing guid: {_guid}\r");
                    _mtbConsole.AppendText($"{_dtNow} {GlobalValues.LogActions.info}:...processing guid: {_guid}" + Environment.NewLine);

                    _sbLog.Append($"{_dtNow} {GlobalValues.LogActions.apiEvent}:..api_GetAttachmentUrl: api request\r");
                    _mtbConsole.AppendText($"{_dtNow} {GlobalValues.LogActions.apiEvent}:..api_GetAttachmentUrl: api request" + Environment.NewLine);
                    var request = await _encompassClient.GetUploadAttachmentUrl(_token, _guid, _payload);
                    if (request.IsSuccessStatusCode)
                    {
                        _sbLog.Append($"{_dtNow} {GlobalValues.LogActions.info}:...mediaUrl retrieved\r");
                        _mtbConsole.AppendText($"{_dtNow} {GlobalValues.LogActions.info}:...mediaUrl retrieved" + Environment.NewLine);
                        var requestContent = await request.Content.ReadAsStringAsync();
                        var attachmentInfo = JsonConvert.DeserializeObject<MediaUrlModel>(requestContent);
                        _authHeader = attachmentInfo.authorizationHeader;
                        _sbLog.Append($"{_dtNow} {GlobalValues.LogActions.info}:...setting auth header\r");
                        _mtbConsole.AppendText($"{_dtNow} {GlobalValues.LogActions.info}:...setting auth header" + Environment.NewLine);
                        _uploadUrl = attachmentInfo.uploadUrl;
                        _sbLog.Append($"{_dtNow} {GlobalValues.LogActions.info}:...uploadUrl: {_uploadUrl}\r");
                        _mtbConsole.AppendText($"{_dtNow} {GlobalValues.LogActions.info}:...uploadUrl: {_uploadUrl}" + Environment.NewLine);


                        _sbLog.Append($"{_dtNow} {GlobalValues.LogActions.apiEvent}:..api_UploadAttachment: api request\r");
                        _mtbConsole.AppendText($"{_dtNow} {GlobalValues.LogActions.apiEvent}:..api_UploadAttachment: api request" + Environment.NewLine);
                        var uploadRequest = await _encompassClient.UploadAttachment(_uploadUrl, _authHeader, _pdfByteArray);
                        if (uploadRequest.IsSuccessStatusCode)
                        {
                            _sbLog.Append($"{_dtNow} {GlobalValues.LogActions.info}:...attachment uploaded into eFolder\r");
                            _mtbConsole.AppendText($"{_dtNow} {GlobalValues.LogActions.info}:...attachment uploaded into eFolder" + Environment.NewLine);
                            _mtbConsole.AppendText($"{_dtNow} {GlobalValues.LogActions.info}:...Processing result: Success" + Environment.NewLine);
                            _mtbConsole.AppendText($"{_dtNow} {GlobalValues.LogActions.info}:...Processed File {_fileCount} of {_fileNames.Count}"
                                + Environment.NewLine + Environment.NewLine);
                            _pdfByteArray = null;
                            _size = 0;
                            _authHeader = string.Empty;
                            _uploadUrl = string.Empty;

                            _result = true;
                            MoveFiles(_result);

                            _successCount++;
                        }
                        else
                        {
                            _sbLog.Append($"{_dtNow} {GlobalValues.LogActions.error}:.failed attaching attachment to eFolder\r");
                            _mtbConsole.AppendText($"{_dtNow} {GlobalValues.LogActions.error}:.failed attaching attachment to eFolder" + Environment.NewLine);
                            _mtbConsole.AppendText($"{_dtNow} {GlobalValues.LogActions.error}:.status code {uploadRequest.StatusCode}" + Environment.NewLine);

                            _result = false;
                            MoveFiles(_result);

                            _errorCount++;
                        }
                    }
                    else
                    {
                        _sbLog.Append($"{_dtNow} {GlobalValues.LogActions.error}:..api_GetAttachmentUrl: bad request\r");
                        _sbLog.Append($"{_dtNow} {GlobalValues.LogActions.error}:..status code: {request.StatusCode}\r");

                        _mtbConsole.AppendText($"{_dtNow} {GlobalValues.LogActions.error}:..api_GetAttachmentUrl: bad request" + Environment.NewLine);
                        _mtbConsole.AppendText($"{_dtNow} {GlobalValues.LogActions.error}:..status code: {request.StatusCode}" + Environment.NewLine);

                        _result = false;
                        MoveFiles(_result);

                        _errorCount++;
                    }
                }
                else
                {
                    _sbLog.Append($"{_dtNow} {GlobalValues.LogActions.error}:..payload is null\r");
                    _sbLog.Append($"{_dtNow} {GlobalValues.LogActions.error}:..file: {_fileName}\r");
                    _mtbConsole.AppendText($"{_dtNow} {GlobalValues.LogActions.error}:..payload is null" + Environment.NewLine);
                    _errorCount++;

                    _result = false;
                    MoveFiles(_result);
                }

                var total = _successCount + _errorCount;

                if (total == _fileNames.Count)
                {
                    ProcessComplete();
                    break;
                }
            }
        }

        private StringContent CreatePayload(string fileName, int _size, string _title)
        {
            var body = new UploadAttachBodyModel
            {
                file = new EncFile
                {
                    contentType = "application/pdf",
                    name = $"{fileName}",
                    size = _size
                },
                title = $"{_title}"
            };

            var payload = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");

            return payload;
        }

        private void MoveFiles(bool result)
        {
            try
            {
                if (result)
                {
                    //File.Move($@"{_fullFolderPath}\{_fileName}", $@"{_successFolder}\{_fileName}");
                }
                else
                {
                    //File.Move($@"{_fullFolderPath}\{_fileName}", $@"{_failedFolder}\{_fileName}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex}");
            }
        }

        private void ProcessComplete()
        {
            _sbLog.Append($"{_dtNow} {GlobalValues.LogActions.complete}:...process complete!\r");
            _mtbConsole.AppendText($"{_dtNow} {GlobalValues.LogActions.complete}:...process complete!" + Environment.NewLine);
            _log.CreateLog(_sbLog);
            _sbLog.Clear();
            _sideMenu.Enabled = true;
            _fileNames.Clear();
            MessageBox.Show($"Process complete...Successful: {_successCount} Errors: {_errorCount}", "File Import", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            _panelImportSingle.Enabled = true;
        }

        private void ResetCounts()
        {
            _fileCount = 0;
            _successCount = 0;
            _errorCount = 0;
        }
    }
}
