using DocumentExportUtility_API.Models;
using DocumentExportUtility_API.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Windows.Forms;
using System.Net.Http;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Linq;
using DocumentExportUtility_API.Utils;
using DocumentExportUtility_API.Log;

namespace DocumentExportUtility_API.Forms
{
    public partial class AttachmentsExport : Form
    {
        //private EncompassTokenModel _token;
        //private TokenHandler _tokenHandler { get; set; }
        //private EncompassClient _encompassClient { get; set; }
        //private PdfHelper _pdfHelper;
        //private Log.Logger _log;
        //private List<ExcelGuidModel> _loanGuidList = new List<ExcelGuidModel>();
        //private List<AttachmentDataModel> _attachmentDataList = new List<AttachmentDataModel>();

        //private string _exportFolderPath;
        //private List<string> _filePathList = new List<string>();
        //private StringBuilder _sbLog = new StringBuilder();
        //private DateTime _dtNow = DateTime.Now;

        public AttachmentsExport()
        {
            InitializeComponent();
        }

        //public void FormLoad(EncompassTokenModel token, List<ExcelGuidModel> loanGuidList, TokenHandler tokenHandler, EncompassClient encompassClient)
        //{
        //    _token = token;
        //    _loanGuidList = loanGuidList;
        //    _tokenHandler = tokenHandler;
        //    _encompassClient = encompassClient;
        //    tbLog.ScrollBars = ScrollBars.Vertical;
        //    _pdfHelper = new PdfHelper();
        //    _log = new Logging();

        //    AllocConsole();
        //    ProcessAttachments();
        //}

        //[DllImport("kernel32.dll", SetLastError = true)]
        //[return: MarshalAs(UnmanagedType.Bool)]
        //static extern bool AllocConsole();

        //private async void ProcessAttachments()
        //{
        //    if (_token.Active)
        //    {
        //        DownloadAttachments();
        //    }
        //    else
        //    {
        //        _token = await _tokenHandler.GetEncompassToken();
        //        DownloadAttachments();
        //    }
        //}

        //private async void DownloadAttachments()
        //{
        //    tbLog.Text += "Downloading attachments! Please do NOT leave this page or exit this program...";
        //    _sbLog.Append($"{_dtNow} {GlobalValues.LogActions.info}:.******************************************\r");
        //    _sbLog.Append($"{_dtNow} {GlobalValues.LogActions.info}:.main: *** Download Attachments Started ***\r"
        //        + Environment.NewLine);
        //    _sbLog.Append($"{_dtNow} {GlobalValues.LogActions.info}:.Total loans being processed. {_loanGuidList.Count}\r");
        //    Console.WriteLine($"Total loans being processed. {_loanGuidList.Count}\r\n" + Environment.NewLine);

        //    foreach (var loan in _loanGuidList)
        //    {
        //        _sbLog.Append($"{_dtNow} {GlobalValues.LogActions.apiEvent}:..api_GetAttachments: api request\r");
        //        var request = await _encompassClient.GetAttachments($"{loan.Guid}", _token);
        //        if (request.IsSuccessStatusCode)
        //        {
        //            _sbLog.Append($"{_dtNow} {GlobalValues.LogActions.info}:...getting attachments for loan...guid: {loan.Guid}\r");
        //            Console.WriteLine($"Getting attachments for Loan: {loan.Guid}\r");
        //            var content = await request.Content.ReadAsStringAsync();
        //            var attachmentList = JsonConvert.DeserializeObject<List<AttachResponseModel>>(content);

        //            if (attachmentList.Count.Equals(0))
        //            {
        //                _sbLog.Append($"{_dtNow} {GlobalValues.LogActions.warning}:.eFolder empty for loan: {loan.Guid}\r");
        //                _sbLog.Append($"{_dtNow} {GlobalValues.LogActions.info}:.processing next loan...\r");
        //                Console.WriteLine($"eFolder empty for loan {loan.Guid}\r");
        //                Console.WriteLine($"Processing next loan...\r" + Environment.NewLine);
        //            }
        //            else
        //            {
        //                _sbLog.Append($"{_dtNow} {GlobalValues.LogActions.info}:...adding to attachment list\r");
        //                Console.WriteLine($"Adding to attachment list...\r" + Environment.NewLine);
        //                foreach (var item in attachmentList)
        //                {
        //                    _attachmentDataList.Add(new AttachmentDataModel { Guid = loan.Guid, AttachmentId = item.attachmentId, LoanNumber = loan.LoanNumber });
        //                }
        //            }
        //        }
        //        else
        //        {
        //            _sbLog.Append($"{_dtNow} {GlobalValues.LogActions.error}:..bad request:\r");
        //            _sbLog.Append($"{_dtNow} {GlobalValues.LogActions.error}:..status code: {request.StatusCode}\r");
        //            _sbLog.Append($"{_dtNow} {GlobalValues.LogActions.error}:..guid: {loan.Guid}\r");
        //            _sbLog.Append($"{_dtNow} {GlobalValues.LogActions.info}:..processing next loan in list\r");
        //            tbLog.Text += $"Bad Request: {request.StatusCode}" +
        //                $"GUID: {loan.Guid}\r\n" +
        //                $"Proceeding with next loan..." + Environment.NewLine;
        //        }
        //    }

        //    _sbLog.Append($"{_dtNow} {GlobalValues.LogActions.info}:....attachment list complete\r");
        //    _sbLog.Append($"{_dtNow} {GlobalValues.LogActions.info}:....proceeding to download attachments\r");
        //    _sbLog.Append($"{_dtNow} {GlobalValues.LogActions.info}:....attachment list count {_attachmentDataList.Count}\r");
        //    Console.WriteLine($"Attachment List complete! Proceeding to download attachments.\r");
        //    Console.WriteLine($"Attachment list count: {_attachmentDataList.Count}\r" + Environment.NewLine);

        //    foreach(var item in _attachmentDataList)
        //    {
        //        _sbLog.Append($"{_dtNow} {GlobalValues.LogActions.apiEvent}:..api_GetAttachment: api request\r");
        //        _sbLog.Append($"{_dtNow} {GlobalValues.LogActions.apiEvent}:..attachmentId: {item.AttachmentId}\r");
        //        _sbLog.Append($"{_dtNow} {GlobalValues.LogActions.info}:...getting attachment\r");
        //        Console.WriteLine($"Getting attachment: {item.AttachmentId}\r");
        //        var attachmentRequest = await _encompassClient.GetAttachment($"{item.Guid}", _token, $"{item.AttachmentId}");
        //        if (attachmentRequest.IsSuccessStatusCode)
        //        {
        //            _sbLog.Append($"{_dtNow} {GlobalValues.LogActions.info}:....attachment received\r");
        //            _sbLog.Append($"{_dtNow} {GlobalValues.LogActions.info}:....attachmentId: {item.AttachmentId}\r");
        //            Console.WriteLine("Attachment received!\r");
        //            var content = await attachmentRequest.Content.ReadAsStringAsync();
        //            var attachment = JsonConvert.DeserializeObject<AttachResponseModel>(content);

        //            _sbLog.Append($"{_dtNow} {GlobalValues.LogActions.info}:....processing attachment pages\r");
        //            Console.WriteLine($"Processing attachment pages...\r");
        //            try
        //            {
        //                List<Page> pageList = attachment.pages.OfType<Page>().ToList();

        //                foreach (var page in pageList)
        //                {
        //                    SaveImageUriToDisk(page.mediaUrl, page.imageKey, item.LoanNumber, attachment.title);
        //                }

        //                var filePathArray = _filePathList.ToArray();
        //                _pdfHelper.ConcatenateDocuments(filePathArray, _exportFolderPath, attachment.title);
        //                _filePathList.Clear();

        //                _sbLog.Append($"{_dtNow} {GlobalValues.LogActions.info}:....clearing pages list\r");
        //                Console.WriteLine("Clearing pages list...\r");
        //                pageList.Clear();
        //            }
        //            catch(Exception ex)
        //            {
        //                _sbLog.Append($"{_dtNow} {GlobalValues.LogActions.error}:..exception:\r");
        //                _sbLog.Append($"{_dtNow} {GlobalValues.LogActions.error}:..{ex}\r");
        //                Console.WriteLine($"Attachment pages is null or empty.\r");
        //                Console.WriteLine($"Attachment Id: {attachment.attachmentId}\r");
        //            }
        //        }
        //        else
        //        {
        //            _sbLog.Append($"{_dtNow} {GlobalValues.LogActions.error}:..bad request:\r");
        //            _sbLog.Append($"{_dtNow} {GlobalValues.LogActions.error}:..status code: {attachmentRequest.StatusCode}\r");
        //            _sbLog.Append($"{_dtNow} {GlobalValues.LogActions.error}:..guid: {item.Guid}\r");
        //            _sbLog.Append($"{_dtNow} {GlobalValues.LogActions.info}:..processing next attachment...\r");
        //            tbLog.Text += $"Bad Request: {attachmentRequest.StatusCode}" +
        //                $"GUID: {item.Guid}\r\n" +
        //                $"AttachmendId: {item.AttachmentId}\r" +
        //                $"Proceeding with next attachment..." + Environment.NewLine;
        //        }
        //    }

        //    _sbLog.Append($"{_dtNow} {GlobalValues.LogActions.complete}:.process complete...\r");
        //    _log.CreateLog(_sbLog);
        //    _sbLog.Clear();
        //    Console.WriteLine("Process Complete!");
        //}

        //private void SaveImageUriToDisk(string remoteUri, string imageKey, string folderName, string attachmentTitle)
        //{
        //    try
        //    {
        //        WebClient wc = new WebClient();
        //        string myStringWebResource = null;
        //        string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

        //        _exportFolderPath = Path.Combine(folder, "LoganDocumentExport", $"{folderName}", $"{attachmentTitle}");
        //        Directory.CreateDirectory(_exportFolderPath);

        //        myStringWebResource = remoteUri;
        //        string filePath = @$"{_exportFolderPath}\{imageKey}";
        //        string pdfFilePath = $@"{_exportFolderPath}\{imageKey}.pdf";

        //        _sbLog.Append($"{_dtNow} {GlobalValues.LogActions.info}:....downloading file\r");
        //        _sbLog.Append($"{_dtNow} {GlobalValues.LogActions.info}:....imageKey {imageKey}\r");
        //        Console.WriteLine($"Downloading File: {imageKey} from {myStringWebResource}\r");
        //        wc.DownloadFile(myStringWebResource, @$"{_exportFolderPath}\{imageKey}");

        //        _sbLog.Append($"{_dtNow} {GlobalValues.LogActions.info}:....successfully downloaded file\r");
        //        Console.WriteLine($"Successfully Downloaded File.\r" + Environment.NewLine);

        //        _sbLog.Append($"{_dtNow} {GlobalValues.LogActions.info}:....saving file as pdf\r");
        //        Console.WriteLine($"Saving file as PDF...\r");
        //        _filePathList.Add(pdfFilePath);
        //        _pdfHelper.SaveImageAsPdf(filePath, pdfFilePath, 600, true);
        //    }
        //    catch(Exception ex)
        //    {
        //        _sbLog.Append($"{_dtNow} {GlobalValues.LogActions.error}:..error:\r");
        //        _sbLog.Append($"{_dtNow} {GlobalValues.LogActions.error}:..remote uri: {remoteUri}\r");
        //        _sbLog.Append($"{_dtNow} {GlobalValues.LogActions.error}:..imageKey(fileName): {imageKey}\r");
        //        _sbLog.Append($"{_dtNow} {GlobalValues.LogActions.info}:..title: {folderName}\r");
        //        _sbLog.Append($"{_dtNow} {GlobalValues.LogActions.info}:..exception: {ex}...\r");
        //        tbLog.Text += $"{ex}\r" + Environment.NewLine +
        //            $"remoteUri: {remoteUri}\r" +
        //            $"fileName: {imageKey}\r" +
        //            $"title: {folderName}" + Environment.NewLine;
        //    }
        //}
    }
}
