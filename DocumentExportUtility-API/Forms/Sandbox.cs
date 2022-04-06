using DocumentExportUtility_API.Log;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DocumentExportUtility_API.Forms
{
    public partial class Sandbox : Form
    {
        public Sandbox()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mtbConsole.AppendText($"******************************************" + Environment.NewLine);
            mtbConsole.AppendText($"{DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff tt")} {GlobalValues.LogActions.info}:.main_log_start: *** Process Unassigned Attachments ***" + Environment.NewLine);
        }

        //private StringContent CreatePayload(string fileName, int _size, string _title)
        //{
        //    var body = new UploadAttachBodyModel
        //    {
        //        file = new EncFile
        //        {
        //            contentType = "application/pdf",
        //            name = $"{fileName}",
        //            size = _size
        //        },
        //        title = $"{_title}"
        //    };

        //    var payload = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");

        //    return payload;
        //}

        //private async void ProcessAttachmentsForImport()
        //{
        //    _fileCount = 0;
        //    _sideMenu.Enabled = false;
        //    mtbConsole.AppendText($"{_dtNow} {GlobalValues.LogActions.info}:...IMPORTING FILES" + Environment.NewLine);
        //    foreach (var file in _fileNames)
        //    {
        //        _fileCount++;
        //        mtbConsole.AppendText($"{_dtNow} {GlobalValues.LogActions.info}:...Importing File {_fileCount} of {_fileNames.Count}" + Environment.NewLine);
        //        _fileName = Path.GetFileName(file);               
        //        var title = Path.GetFileNameWithoutExtension(file);
        //        _sbLog.Append($"{_dtNow} {GlobalValues.LogActions.info}:...fileName: {_fileName}\r");
        //        _sbLog.Append($"{_dtNow} {GlobalValues.LogActions.info}:...title: {title}\r");

        //        mtbConsole.AppendText($"{_dtNow} {GlobalValues.LogActions.info}:...fileName: {_fileName}" + Environment.NewLine);
        //        mtbConsole.AppendText($"{_dtNow} {GlobalValues.LogActions.info}:...title: {title}" + Environment.NewLine);
        //        mtbConsole.AppendText($"{_dtNow} {GlobalValues.LogActions.info}:...filepath: {_filePaths[_fileCount - 1]}" + Environment.NewLine);

        //        try
        //        {
        //            _sbLog.Append($"{_dtNow} {GlobalValues.LogActions.info}:...creating byte array\r");
        //            mtbConsole.AppendText($"{_dtNow} {GlobalValues.LogActions.info}:...creating byte array" + Environment.NewLine);
        //            _pdfByteArray = _pdfHelper.ConvertToByteArray(file);
        //            _size = _pdfByteArray.Length;
        //            _sbLog.Append($"{_dtNow} {GlobalValues.LogActions.info}:...byte array created...size: {_size}\r");
        //            mtbConsole.AppendText($"{_dtNow} {GlobalValues.LogActions.info}:...byte array created...size: {_size}" + Environment.NewLine);
        //        }
        //        catch (Exception ex)
        //        {
        //            _sbLog.Append($"{_dtNow} {GlobalValues.LogActions.error}:.error creating byte array\r");
        //            mtbConsole.AppendText($"{_dtNow} {GlobalValues.LogActions.error}:.error creating byte array" + Environment.NewLine);
        //            mtbConsole.AppendText($"{_dtNow} {GlobalValues.LogActions.error}:.exception: {ex}" + Environment.NewLine);
        //        }

        //        _sbLog.Append($"{_dtNow} {GlobalValues.LogActions.info}:...creating payload\r");
        //        mtbConsole.AppendText($"{_dtNow} {GlobalValues.LogActions.info}:...creating payload" + Environment.NewLine);
        //        _payload = CreatePayload(_fileName, _size, title);

        //        if (_payload != null)
        //        {
        //            _sbLog.Append($"{_dtNow} {GlobalValues.LogActions.info}:...payload created\r");
        //            mtbConsole.AppendText($"{_dtNow} {GlobalValues.LogActions.info}:...payload created" + Environment.NewLine);

        //            _guid = tbLoanGuid.Text;
        //            _sbLog.Append($"{_dtNow} {GlobalValues.LogActions.info}:...processing guid: {_guid}\r");
        //            mtbConsole.AppendText($"{_dtNow} {GlobalValues.LogActions.info}:...processing guid: {_guid}" + Environment.NewLine);

        //            _sbLog.Append($"{_dtNow} {GlobalValues.LogActions.apiEvent}:..api_GetAttachmentUrl: api request\r");
        //            mtbConsole.AppendText($"{_dtNow} {GlobalValues.LogActions.apiEvent}:..api_GetAttachmentUrl: api request" + Environment.NewLine);
        //            var request = await _encClient.GetUploadAttachmentUrl(_token, _guid, _payload);
        //            if (request.IsSuccessStatusCode)
        //            {
        //                _sbLog.Append($"{_dtNow} {GlobalValues.LogActions.info}:...mediaUrl retrieved\r");
        //                mtbConsole.AppendText($"{_dtNow} {GlobalValues.LogActions.info}:...mediaUrl retrieved" + Environment.NewLine);
        //                var requestContent = await request.Content.ReadAsStringAsync();
        //                var attachmentInfo = JsonConvert.DeserializeObject<MediaUrlModel>(requestContent);
        //                _authHeader = attachmentInfo.authorizationHeader;
        //                _sbLog.Append($"{_dtNow} {GlobalValues.LogActions.info}:...setting auth header\r");
        //                mtbConsole.AppendText($"{_dtNow} {GlobalValues.LogActions.info}:...setting auth header" + Environment.NewLine);
        //                _uploadUrl = attachmentInfo.uploadUrl;
        //                _sbLog.Append($"{_dtNow} {GlobalValues.LogActions.info}:...uploadUrl: {_uploadUrl}\r");
        //                mtbConsole.AppendText($"{_dtNow} {GlobalValues.LogActions.info}:...uploadUrl: {_uploadUrl}" + Environment.NewLine);


        //                _sbLog.Append($"{_dtNow} {GlobalValues.LogActions.apiEvent}:..api_UploadAttachment: api request\r");
        //                mtbConsole.AppendText($"{_dtNow} {GlobalValues.LogActions.apiEvent}:..api_UploadAttachment: api request" + Environment.NewLine);
        //                var uploadRequest = await _encClient.UploadAttachment(_uploadUrl, _authHeader, _pdfByteArray);
        //                if (uploadRequest.IsSuccessStatusCode)
        //                {
        //                    _sbLog.Append($"{_dtNow} {GlobalValues.LogActions.info}:...attachment uploaded into eFolder\r");
        //                    mtbConsole.AppendText($"{_dtNow} {GlobalValues.LogActions.info}:...attachment uploaded into eFolder" + Environment.NewLine);
        //                    mtbConsole.AppendText($"{_dtNow} {GlobalValues.LogActions.info}:...Processing result: Success" + Environment.NewLine);
        //                    mtbConsole.AppendText($"{_dtNow} {GlobalValues.LogActions.info}:...Processed File {_fileCount} of {_fileNames.Count}"
        //                        + Environment.NewLine + Environment.NewLine);
        //                    _pdfByteArray = null;
        //                    _size = 0;
        //                    _authHeader = string.Empty;
        //                    _uploadUrl = string.Empty;

        //                    _result = true;
        //                    MoveFiles(_result);
        //                }
        //                else
        //                {
        //                    _sbLog.Append($"{_dtNow} {GlobalValues.LogActions.error}:.failed attaching attachment to eFolder\r");
        //                    mtbConsole.AppendText($"{_dtNow} {GlobalValues.LogActions.error}:.failed attaching attachment to eFolder" + Environment.NewLine);
        //                    mtbConsole.AppendText($"{_dtNow} {GlobalValues.LogActions.error}:.status code {uploadRequest.StatusCode}" + Environment.NewLine);

        //                    _result = false;
        //                    MoveFiles(_result);
        //                }
        //            }
        //            else
        //            {
        //                _sbLog.Append($"{_dtNow} {GlobalValues.LogActions.error}:..api_GetAttachmentUrl: bad request\r");
        //                _sbLog.Append($"{_dtNow} {GlobalValues.LogActions.error}:..status code: {request.StatusCode}\r");

        //                mtbConsole.AppendText($"{_dtNow} {GlobalValues.LogActions.error}:..api_GetAttachmentUrl: bad request" + Environment.NewLine);
        //                mtbConsole.AppendText($"{_dtNow} {GlobalValues.LogActions.error}:..status code: {request.StatusCode}" + Environment.NewLine);

        //                _result = false;
        //                MoveFiles(_result);
        //            }
        //        }
        //        else
        //        {
        //            _sbLog.Append($"{_dtNow} {GlobalValues.LogActions.error}:..payload is null\r");
        //            _sbLog.Append($"{_dtNow} {GlobalValues.LogActions.error}:..file: {_fileName}\r");
        //            mtbConsole.AppendText($"{_dtNow} {GlobalValues.LogActions.error}:..payload is null" + Environment.NewLine);

        //            _result = false;
        //            MoveFiles(_result);
        //        }
        //    }

        //    _sbLog.Append($"{_dtNow} {GlobalValues.LogActions.complete}:...process complete!\r");
        //    mtbConsole.AppendText($"{_dtNow} {GlobalValues.LogActions.complete}:...process complete!" + Environment.NewLine);
        //    _log.CreateLog(_sbLog);
        //    _sbLog.Clear();
        //    _sideMenu.Enabled = true;
        //    btnImport.Enabled = true;
        //    btnAssignDocs.Enabled = true;
        //    _fileNames.Clear();
        //    MessageBox.Show("Process complete.", "File Import", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //}
        //private void MoveFiles(bool result)
        //{
        //    try
        //    {
        //        if (result)
        //        {
        //            File.Move($@"{_fullFolderPath}\{_fileName}", $@"{_successFolder}\{_fileName}");
        //        }
        //        else
        //        {
        //            File.Move($@"{_fullFolderPath}\{_fileName}", $@"{_failedFolder}\{_fileName}");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"{ex}");
        //    }
        //}
    }
}
