using DocumentExportUtility_API.Log;
using DocumentExportUtility_API.Models;
using DocumentExportUtility_API.Services;
using DocumentExportUtility_API.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace DocumentExportUtility_API.Controllers
{
    public class ExportAttachmentsController
    {
        private EncompassTokenModel _token { get; set; }
        private TokenHandler _tokenHandler { get; set; }
        private EncompassClient _encompassClient { get; set; }
        private ReadExcelHelper _readExcelHelper { get; set; }
        private PdfHelper _pdfHelper { get; set; }
        private Logger _log { get; set; }
        private UserData _userData { get; set; }

        private List<Button> _buttonList { get; set; }    
        private List<string> _filePathList = new List<string>();
        private List<string> _quattroDocList = new List<string>();
        private List<AttachmentDataModel> _attachmentDataList = new List<AttachmentDataModel>();

        private StringBuilder _sbLog = new StringBuilder();
        private Match _match;
        private Dictionary<string, string> _regexDic = new Dictionary<string, string>();

        private int _attachmentCount = 0;
        private string _exportFolderPath, _selectedExportPath;

        //Ui Controls
        private TextBox _tbConsole;
        private Panel _sideMenu;

        public ExportAttachmentsController(EncompassTokenModel token, TokenHandler tokenHandler, 
            EncompassClient encClient, ReadExcelHelper readExcelHelper,
            PdfHelper pdfHelper, TextBox tbConsole, List<Button> buttonList, Logger log, 
            string selectedExportPath, Panel sidePanel, UserData userData)
        {
            _token = token;
            _tokenHandler = tokenHandler;
            _encompassClient = encClient;
            _readExcelHelper = readExcelHelper;
            _pdfHelper = pdfHelper;
            _tbConsole = tbConsole;
            _buttonList = buttonList;
            _log = log;
            _selectedExportPath = selectedExportPath;
            _sideMenu = sidePanel;
            _userData = userData;
        }

        public void ExportProcess()
        {
            GetToken();
            DownloadAttachments();
        }

        private async void GetToken()
        {
            _token = await _tokenHandler.GetEncompassToken(_userData.UserId, _userData.Password, _userData.Instance,
                _userData.ClientId, _userData.Secret);
        }

        private async void DownloadAttachments()
        {
            UiController();
            _sideMenu.Enabled = false;
            _sbLog.Append($"{DateTime.Now} {GlobalValues.LogActions.info}:.******************************************\r");
            _sbLog.Append($"{DateTime.Now} {GlobalValues.LogActions.info}:.main: *** Download Attachments Started ***\r"
                + Environment.NewLine);
            _sbLog.Append($"{DateTime.Now} {GlobalValues.LogActions.info}:.Total loans being processed. {_readExcelHelper.LoanGuidList.Count}\r");

            _tbConsole.AppendText($"{DateTime.Now} {GlobalValues.LogActions.info}:.******************************************" + Environment.NewLine);
            _tbConsole.AppendText($"{DateTime.Now} {GlobalValues.LogActions.info}:.main: *** Download Attachments Started ***" + Environment.NewLine);
            _tbConsole.AppendText($"{DateTime.Now} {GlobalValues.LogActions.info}:.Total loans being processed. {_readExcelHelper.LoanGuidList.Count}"
                + Environment.NewLine);

            _quattroDocList = _readExcelHelper.QuattroDocList
                .Where(x => !string.IsNullOrWhiteSpace(x.EncDocName))
                .Select(s => (string)s.QuattroDocName)
                .ToList();

            _regexDic = _readExcelHelper.QuattroDocList
                .Where(x => x.QuattroDocName.Contains(".*"))
                .Select(s => new { s.QuattroDocName, s.EncDocName })
                .ToDictionary(d => d.QuattroDocName, d => d.EncDocName);

            foreach (var loan in _readExcelHelper.LoanGuidList)
            {
                _sbLog.Append($"{DateTime.Now} {GlobalValues.LogActions.apiEvent}:..api_GetAttachments: api request\r");
                _tbConsole.AppendText($"{DateTime.Now} {GlobalValues.LogActions.apiEvent}:..api_GetAttachments: api request" + Environment.NewLine);

                var request = await _encompassClient.GetAttachments($"{loan.Guid}", _token);
                if (request.IsSuccessStatusCode)
                {
                    _sbLog.Append($"{DateTime.Now} {GlobalValues.LogActions.info}:...getting attachments for loan...guid: {loan.Guid}\r");
                    _tbConsole.AppendText($"{DateTime.Now} {GlobalValues.LogActions.info}:...getting attachments for loan...guid: {loan.Guid}"
                        + Environment.NewLine);

                    var content = await request.Content.ReadAsStringAsync();
                    var attachmentList = JsonConvert.DeserializeObject<List<AttachResponseModel>>(content);

                    if (attachmentList.Count.Equals(0))
                    {
                        _sbLog.Append($"{DateTime.Now} {GlobalValues.LogActions.warning}:.eFolder empty for loan: {loan.Guid}\r");
                        _sbLog.Append($"{DateTime.Now} {GlobalValues.LogActions.info}:.processing next loan...\r");

                        _tbConsole.AppendText($"{DateTime.Now} {GlobalValues.LogActions.warning}:.eFolder empty for loan: {loan.Guid}" + Environment.NewLine);
                        _tbConsole.AppendText($"{DateTime.Now} {GlobalValues.LogActions.info}:.processing next loan..." + Environment.NewLine);
                    }
                    else
                    {
                        _sbLog.Append($"{DateTime.Now} {GlobalValues.LogActions.info}:...adding to attachment list\r");
                        _tbConsole.AppendText($"{DateTime.Now} {GlobalValues.LogActions.info}:...adding to attachment list" + Environment.NewLine);

                        foreach (var item in _regexDic)
                        {
                            foreach (var attachment in attachmentList)
                            {
                                string pattern = $@"{item.Key}";
                                string input = $@"{attachment.title}.pdf";
                                _match = Regex.Match(input, pattern);
                                if (_match.Success)
                                {
                                    _attachmentDataList.Add(new AttachmentDataModel { Guid = loan.Guid, AttachmentId = attachment.attachmentId, 
                                        AttachmentTitle = attachment.title, LoanNumber = loan.LoanNumber });
                                    _tbConsole.AppendText($"{DateTime.Now} {GlobalValues.LogActions.info}:...attachmentDataList count: {_attachmentDataList.Count}" + Environment.NewLine);
                                }
                            }
                        }

                        foreach (var attachment in attachmentList)
                        {
                            foreach (var quattroDoc in _quattroDocList)
                            {
                                if (quattroDoc.Equals($"{attachment.title}.pdf"))
                                {
                                    _attachmentDataList.Add(new AttachmentDataModel { Guid = loan.Guid, AttachmentId = attachment.attachmentId, 
                                        AttachmentTitle = attachment.title, LoanNumber = loan.LoanNumber });
                                    _tbConsole.AppendText($"{DateTime.Now} {GlobalValues.LogActions.info}:...attachmentDataList count: {_attachmentDataList.Count}" + Environment.NewLine);
                                }
                            }
                        }

                        _sbLog.Append($"{DateTime.Now} {GlobalValues.LogActions.info}:....attachment list complete\r");
                        _sbLog.Append($"{DateTime.Now} {GlobalValues.LogActions.info}:....proceeding to download attachments\r");
                        _sbLog.Append($"{DateTime.Now} {GlobalValues.LogActions.info}:....attachment list count {_attachmentDataList.Count}\r");

                        _tbConsole.AppendText($"{DateTime.Now} {GlobalValues.LogActions.info}:....attachment list complete" + Environment.NewLine);
                        _tbConsole.AppendText($"{DateTime.Now} {GlobalValues.LogActions.info}:....proceeding to download attachments" + Environment.NewLine);
                        _tbConsole.AppendText($"{DateTime.Now} {GlobalValues.LogActions.info}:....attachment list count {_attachmentDataList.Count}" + Environment.NewLine);
                    }
                }
                else
                {
                    _sbLog.Append($"{DateTime.Now} {GlobalValues.LogActions.error}:..bad request:\r");
                    _sbLog.Append($"{DateTime.Now} {GlobalValues.LogActions.error}:..status code: {request.StatusCode}\r");
                    _sbLog.Append($"{DateTime.Now} {GlobalValues.LogActions.error}:..guid: {loan.Guid}\r");
                    _sbLog.Append($"{DateTime.Now} {GlobalValues.LogActions.info}:..processing next loan in list\r");

                    _tbConsole.AppendText($"{DateTime.Now} {GlobalValues.LogActions.error}:..bad request:" + Environment.NewLine);
                    _tbConsole.AppendText($"{DateTime.Now} {GlobalValues.LogActions.error}:..status code: {request.StatusCode}" + Environment.NewLine);
                    _tbConsole.AppendText($"{DateTime.Now} {GlobalValues.LogActions.error}:..guid: {loan.Guid}" + Environment.NewLine);
                    _tbConsole.AppendText($"{DateTime.Now} {GlobalValues.LogActions.info}:..processing next loan in list" + Environment.NewLine);
                }
            }

            CreateAttachmentPdf();
        }

        private async void CreateAttachmentPdf()
        {
            foreach (var item in _attachmentDataList)
            {
                _attachmentCount++;
                _sbLog.Append($"{DateTime.Now} {GlobalValues.LogActions.apiEvent}:..api_GetAttachment: api request\r");
                _sbLog.Append($"{DateTime.Now} {GlobalValues.LogActions.apiEvent}:..attachmentId: {item.AttachmentId}\r");
                _sbLog.Append($"{DateTime.Now} {GlobalValues.LogActions.info}:...getting attachment\r");

                _tbConsole.AppendText($"{DateTime.Now} {GlobalValues.LogActions.info}:..processing attachment {_attachmentCount} of {_attachmentDataList.Count}" + Environment.NewLine);
                _tbConsole.AppendText($"{DateTime.Now} {GlobalValues.LogActions.apiEvent}:..api_GetAttachment: api request" + Environment.NewLine);
                _tbConsole.AppendText($"{DateTime.Now} {GlobalValues.LogActions.apiEvent}:..attachmentId: {item.AttachmentId}" + Environment.NewLine);
                _tbConsole.AppendText($"{DateTime.Now} {GlobalValues.LogActions.info}:...getting attachment" + Environment.NewLine);

                var attachmentRequest = await _encompassClient.GetAttachment($"{item.Guid}", _token, $"{item.AttachmentId}");
                if (attachmentRequest.IsSuccessStatusCode)
                {
                    _sbLog.Append($"{DateTime.Now} {GlobalValues.LogActions.info}:....attachment received\r");
                    _sbLog.Append($"{DateTime.Now} {GlobalValues.LogActions.info}:....attachmentId: {item.AttachmentId}\r");

                    _tbConsole.AppendText($"{DateTime.Now} {GlobalValues.LogActions.info}:....attachment received" + Environment.NewLine);
                    _tbConsole.AppendText($"{DateTime.Now} {GlobalValues.LogActions.info}:....attachmentId: {item.AttachmentId}" + Environment.NewLine);
                    _tbConsole.AppendText($"{DateTime.Now} {GlobalValues.LogActions.info}:....attachment title: {item.AttachmentTitle}" + Environment.NewLine);

                    var content = await attachmentRequest.Content.ReadAsStringAsync();
                    var attachment = JsonConvert.DeserializeObject<AttachResponseModel>(content);

                    _sbLog.Append($"{DateTime.Now} {GlobalValues.LogActions.info}:....processing pages\r");
                    _tbConsole.AppendText($"{DateTime.Now} {GlobalValues.LogActions.info}:....processing pages" + Environment.NewLine);

                    try
                    {
                        List<Page> pageList = attachment.pages.OfType<Page>().ToList();
                        var pageCount = 1;

                        foreach (var page in pageList)
                        {
                            _sbLog.Append($"{DateTime.Now} {GlobalValues.LogActions.info}:....{item.AttachmentTitle} page {pageCount} of {pageList.Count}" + Environment.NewLine);
                            _tbConsole.AppendText($"{DateTime.Now} {GlobalValues.LogActions.info}:....{item.AttachmentTitle} page {pageCount} of {pageList.Count}" + Environment.NewLine);
                            SaveImageUriToDisk(page.mediaUrl, page.imageKey, item.LoanNumber);
                            pageCount++;
                        }

                        var filePathArray = _filePathList.ToArray();                       
                        _pdfHelper.ConcatenateDocuments(filePathArray, _exportFolderPath, attachment.title);
                        _filePathList.Clear();

                        _sbLog.Append($"{DateTime.Now} {GlobalValues.LogActions.info}:....clearing pages list\r");
                        _tbConsole.AppendText($"{DateTime.Now} {GlobalValues.LogActions.info}:....clearing pages list" + Environment.NewLine);
                        _tbConsole.AppendText($"{DateTime.Now} {GlobalValues.LogActions.info}:....combined pdfs and cleaned up" + Environment.NewLine);
                        pageList.Clear();                       
                    }
                    catch (Exception ex)
                    {
                        _sbLog.Append($"{DateTime.Now} {GlobalValues.LogActions.error}:..exception:\r");
                        _sbLog.Append($"{DateTime.Now} {GlobalValues.LogActions.error}:..{ex}\r");

                        _tbConsole.AppendText($"{DateTime.Now} {GlobalValues.LogActions.error}:..exception:" + Environment.NewLine);
                        _tbConsole.AppendText($"{DateTime.Now} {GlobalValues.LogActions.error}:..{ex}" + Environment.NewLine);
                    }
                }
                else
                {
                    _sbLog.Append($"{DateTime.Now} {GlobalValues.LogActions.error}:..bad request:\r");
                    _sbLog.Append($"{DateTime.Now} {GlobalValues.LogActions.error}:..status code: {attachmentRequest.StatusCode}\r");
                    _sbLog.Append($"{DateTime.Now} {GlobalValues.LogActions.error}:..guid: {item.Guid}\r");
                    _sbLog.Append($"{DateTime.Now} {GlobalValues.LogActions.info}:..processing next attachment...\r");

                    _tbConsole.AppendText($"{DateTime.Now} {GlobalValues.LogActions.error}:..bad request:" + Environment.NewLine);
                    _tbConsole.AppendText($"{DateTime.Now} {GlobalValues.LogActions.error}:..status code: {attachmentRequest.StatusCode}" + Environment.NewLine);
                    _tbConsole.AppendText($"{DateTime.Now} {GlobalValues.LogActions.error}:..guid: {item.Guid}" + Environment.NewLine);
                    _tbConsole.AppendText($"{DateTime.Now} {GlobalValues.LogActions.info}:..processing next attachment..." + Environment.NewLine);
                }
            }

            if (_attachmentCount == _attachmentDataList.Count)
            {
                ProcessComplete();
                UiController();
                _sideMenu.Enabled = true;
            }
        }

        private void SaveImageUriToDisk(string remoteUri, string imageKey, string folderName)
        {
            try
            {
                WebClient wc = new WebClient();
                string myStringWebResource = null;
                string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

                _exportFolderPath = Path.Combine(folder, "LoganDocumentExport", "Temp", $"{folderName}");
                Directory.CreateDirectory(_exportFolderPath);

                myStringWebResource = remoteUri;
                string filePath = @$"{_exportFolderPath}\{imageKey}";
                string pdfFilePath = $@"{_exportFolderPath}\{imageKey}.pdf";

                _sbLog.Append($"{DateTime.Now} {GlobalValues.LogActions.info}:....downloading file\r");
                _sbLog.Append($"{DateTime.Now} {GlobalValues.LogActions.info}:....imageKey {imageKey}\r");

                wc.DownloadFile(myStringWebResource, @$"{_exportFolderPath}\{imageKey}");

                _sbLog.Append($"{DateTime.Now} {GlobalValues.LogActions.info}:....successfully downloaded file\r");

                _sbLog.Append($"{DateTime.Now} {GlobalValues.LogActions.info}:....saving file as pdf\r");
                Console.WriteLine($"Saving file as PDF...\r");
                _filePathList.Add(pdfFilePath);
                _pdfHelper.SaveImageAsPdf(filePath, pdfFilePath, 600, true);
            }
            catch (Exception ex)
            {
                _sbLog.Append($"{DateTime.Now} {GlobalValues.LogActions.error}:..error:\r");
                _sbLog.Append($"{DateTime.Now} {GlobalValues.LogActions.error}:..remote uri: {remoteUri}\r");
                _sbLog.Append($"{DateTime.Now} {GlobalValues.LogActions.error}:..imageKey(fileName): {imageKey}\r");
                _sbLog.Append($"{DateTime.Now} {GlobalValues.LogActions.error}:..title: {folderName}\r");
                _sbLog.Append($"{DateTime.Now} {GlobalValues.LogActions.error}:..exception: {ex}...\r");

                _tbConsole.AppendText($"{DateTime.Now} {GlobalValues.LogActions.error}:..error:" + Environment.NewLine);
                _tbConsole.AppendText($"{DateTime.Now} {GlobalValues.LogActions.error}:..remote uri: {remoteUri}" + Environment.NewLine);
                _tbConsole.AppendText($"{DateTime.Now} {GlobalValues.LogActions.error}:..imageKey(fileName): {imageKey}" + Environment.NewLine);
                _tbConsole.AppendText($"{DateTime.Now} {GlobalValues.LogActions.error}:..title: {folderName}" + Environment.NewLine);
                _tbConsole.AppendText($"{DateTime.Now} {GlobalValues.LogActions.error}:..exception: {ex}..." + Environment.NewLine);
            }
        }

        private void ProcessComplete()
        {
            _attachmentCount = 0;
            _sbLog.Append($"{DateTime.Now} {GlobalValues.LogActions.complete}:.process complete...\r");
            _tbConsole.AppendText($"{DateTime.Now} {GlobalValues.LogActions.complete}:.process complete..." + Environment.NewLine);

            _log.CreateLog(_sbLog);
            _sbLog.Clear();
        }

        private void UiController()
        {
            foreach(var button in _buttonList)
            {
                if (button.Enabled)
                {
                    button.Enabled = false;
                }
                else
                {
                    button.Enabled = true;
                }
            }
        }
    }
}
