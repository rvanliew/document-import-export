using DocumentExportUtility_API.Log;
using DocumentExportUtility_API.Models;
using DocumentExportUtility_API.Services;
using DocumentExportUtility_API.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace DocumentExportUtility_API.Controllers
{
    public class AssignAttachmentsController
    {
        private TokenHandler _tokenHandler { get; set; }
        private EncompassClient _encompassClient { get; set; }
        private ReadExcelHelper _readExcel { get; set; }
        private Logger _log { get; set; }
        private UserData _userData { get; set; }
        private StringBuilder _sbLog = new StringBuilder();
        private EncompassTokenModel _token;   
        private StringContent _payload;
        private string _guid;

        private List<DocResponseModel> _docList;
        private bool _isNullOrEmpty;
        private List<AttachResponseModel> _attList;
        private List<string> _quattroDocList = new List<string>();
        private StringContent _docPayload;
        private StringContent _newComment;
        private int _encDocCreatedCount;
        private int _docCreatedCount;
        private Match _match;

        private Panel _sideMenu;
        private List<Panel> _panelsList = new List<Panel>();
        private TextBox _console;
        private int _docAssignedCount;

        public AssignAttachmentsController(TokenHandler tokenHandler, EncompassClient encompassClient, string guid, ReadExcelHelper readExcelHelper,
            EncompassTokenModel token, Logger log, Panel sideMenu, TextBox console, UserData userData)
        {
            _tokenHandler = tokenHandler;
            _encompassClient = encompassClient;
            _guid = guid;
            _readExcel = readExcelHelper;
            _token = token;
            _log = log;
            _sideMenu = sideMenu;
            _console = console;
            _userData = userData;
        }

        public void ProcessUnassignedAttachments()
        {
            //StartLog
            _console.AppendText($"******************************************" + Environment.NewLine);
            _console.AppendText($"{DateTime.Now} {GlobalValues.LogActions.info}:.main_log_start: *** Process Unassigned Attachments ***" + Environment.NewLine);
            _sbLog.Append($"{DateTime.Now} {GlobalValues.LogActions.info}:." + Environment.NewLine);
            _sbLog.Append($"{DateTime.Now} {GlobalValues.LogActions.info}:.******************************************\r");
            _sbLog.Append($"{DateTime.Now} {GlobalValues.LogActions.info}:.main_log_start: *** Process Unassigned Attachments ***\r"
                + Environment.NewLine);
            _console.AppendText($"{DateTime.Now} {GlobalValues.LogActions.apiEvent}:..api_GetEncompassToken" + Environment.NewLine);
            _sbLog.Append($"{DateTime.Now} {GlobalValues.LogActions.apiEvent}:..api_GetEncompassToken\r");

            GetToken();

            _sbLog.Append($"{DateTime.Now} {GlobalValues.LogActions.apiEvent}:..api_GetEncompassToken...token received\r");
            _sbLog.Append($"{DateTime.Now} {GlobalValues.LogActions.info}:.....executing GetDocuments\r");
            _console.AppendText($"{DateTime.Now} {GlobalValues.LogActions.apiEvent}:..api_GetEncompassToken...token received" + Environment.NewLine);
            _console.AppendText($"{DateTime.Now} {GlobalValues.LogActions.info}:.....executing GetDocuments" + Environment.NewLine);

            GetDocuments();
        }

        private async void GetToken()
        {
            _token = await _tokenHandler.GetEncompassToken(_userData.UserId, _userData.Password, _userData.Instance, 
                _userData.ClientId, _userData.Secret);
        }

        private async void GetDocuments()
        {
            //PanelController();
            _sideMenu.Enabled = false;

            _sbLog.Append($"{DateTime.Now} {GlobalValues.LogActions.info}:.....creating quattro document list\r");
            _console.AppendText($"{DateTime.Now} {GlobalValues.LogActions.info}:.....creating quattro document list" + Environment.NewLine);

            _quattroDocList = _readExcel.QuattroDocList
                .Where(x => !string.IsNullOrWhiteSpace(x.EncDocName))
                .Select(s => (string)s.EncDocName)
                .ToList();

            _sbLog.Append($"{DateTime.Now} {GlobalValues.LogActions.info}:.....list complete...count: {_quattroDocList.Count}\r");
            _console.AppendText($"{DateTime.Now} {GlobalValues.LogActions.info}:.....list complete...count: {_quattroDocList.Count}" + Environment.NewLine);

            _sbLog.Append($"{DateTime.Now} {GlobalValues.LogActions.apiEvent}:..api_GetDocuments\r");
            _console.AppendText($"{DateTime.Now} {GlobalValues.LogActions.apiEvent}:..api_GetDocuments" + Environment.NewLine);

            var docRequest = await _encompassClient.GetDocuments(_guid, _token);
            if (docRequest.IsSuccessStatusCode)
            {
                _sbLog.Append($"{DateTime.Now} {GlobalValues.LogActions.apiEvent}:..docRequest received\r");
                _console.AppendText($"{DateTime.Now} {GlobalValues.LogActions.apiEvent}:..docRequest received" + Environment.NewLine);

                var docRequestContent = await docRequest.Content.ReadAsStringAsync();
                _docList = JsonConvert.DeserializeObject<List<DocResponseModel>>(docRequestContent);

                _sbLog.Append($"{DateTime.Now} {GlobalValues.LogActions.apiEvent}:..creating docList...count: {_docList.Count}\r");
                _console.AppendText($"{DateTime.Now} {GlobalValues.LogActions.apiEvent}:..creating docList...count: {_docList.Count}" + Environment.NewLine);

                _isNullOrEmpty = _docList?.Any() != true;
            }

            if (_isNullOrEmpty)
            {
                _sbLog.Append($"{DateTime.Now} {GlobalValues.LogActions.info}:.....docList is empty..asking user for next steps\r");
                _console.AppendText($"{DateTime.Now} {GlobalValues.LogActions.info}:.....docList is empty..asking user for next steps" + Environment.NewLine);

                DialogResult result = MessageBox.Show("There are no documents in the eFolder. Would you like to create them?", "Document Info",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    _sbLog.Append($"{DateTime.Now} {GlobalValues.LogActions.info}:.....creating encompass documents\r");
                    _console.AppendText($"{DateTime.Now} {GlobalValues.LogActions.info}:.....creating encompass documents" + Environment.NewLine);

                    foreach (var document in _quattroDocList)
                    {
                        _docCreatedCount++;
                        CreateDocument(document);
                    }
                }
                else if (result == DialogResult.No)
                {
                    _sbLog.Append($"{DateTime.Now} {GlobalValues.LogActions.info}:.....user selected 'No'...no further action taken\r");
                    _console.AppendText($"{DateTime.Now} {GlobalValues.LogActions.info}:.....user selected 'No'...no further action taken" + Environment.NewLine);

                    //PanelController();
                    _sideMenu.Enabled = true;
                }
            }
            else
            {
                var transmuteDocList = _docList.Select(s => (string)s.title).ToList();
                var missingQuattroDocs = _quattroDocList.Except(transmuteDocList).ToList();
                var isEmptyList = !missingQuattroDocs.Any();

                _sbLog.Append($"{DateTime.Now} {GlobalValues.LogActions.info}:.....comparing enc doc list to quattro doc list\r");
                _sbLog.Append($"{DateTime.Now} {GlobalValues.LogActions.info}:.....number of missing docs: {missingQuattroDocs.Count}\r");
                _console.AppendText($"{DateTime.Now} {GlobalValues.LogActions.info}:.....comparing enc doc list to quattro doc list" + Environment.NewLine);
                _console.AppendText($"{DateTime.Now} {GlobalValues.LogActions.info}:.....number of missing docs: {missingQuattroDocs.Count}" + Environment.NewLine);

                if (isEmptyList)
                {
                    //MessageBox.Show("No files to assign.", "Document Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GetAttachments();
                }
                else
                {
                    foreach (var document in missingQuattroDocs)
                    {
                        _docCreatedCount++;
                        CreateDocument(document);
                    }
                }
            }
        }

        private async void GetAttachments()
        {
            _attList = new List<AttachResponseModel>();

            _sbLog.Append($"{DateTime.Now} {GlobalValues.LogActions.apiEvent}:..api_GetAttachments\r");
            _console.AppendText($"{DateTime.Now} {GlobalValues.LogActions.apiEvent}:..api_GetAttachments" + Environment.NewLine);

            var attRequest = await _encompassClient.GetAttachments(_guid, _token);
            if (attRequest.IsSuccessStatusCode)
            {
                var attRequestContent = await attRequest.Content.ReadAsStringAsync();
                _attList = JsonConvert.DeserializeObject<List<AttachResponseModel>>(attRequestContent);

                _sbLog.Append($"{DateTime.Now} {GlobalValues.LogActions.apiEvent}:..successfully received attachment list...count: {_attList.Count}\r");
                _console.AppendText($"{DateTime.Now} {GlobalValues.LogActions.apiEvent}:..successfully received attachment list...count: {_attList.Count}" + Environment.NewLine);
            }

            _sbLog.Append($"{DateTime.Now} {GlobalValues.LogActions.info}:.....clearing doc list\r");
            _console.AppendText($"{DateTime.Now} {GlobalValues.LogActions.info}:.....clearing doc list" + Environment.NewLine);

            _docList.Clear();

            _sbLog.Append($"{DateTime.Now} {GlobalValues.LogActions.info}:.....re-requesting api_GetDocuments\r");
            _sbLog.Append($"{DateTime.Now} {GlobalValues.LogActions.apiEvent}:..api_GetDocuments\r");
            _console.AppendText($"{DateTime.Now} {GlobalValues.LogActions.info}:.....re-requesting api_GetDocuments" + Environment.NewLine);
            _console.AppendText($"{DateTime.Now} {GlobalValues.LogActions.apiEvent}:..api_GetDocuments" + Environment.NewLine);

            var docReRequest = await _encompassClient.GetDocuments(_guid, _token);
            if (docReRequest.IsSuccessStatusCode)
            {
                var docRequestContent = await docReRequest.Content.ReadAsStringAsync();
                _docList = JsonConvert.DeserializeObject<List<DocResponseModel>>(docRequestContent);

                _sbLog.Append($"{DateTime.Now} {GlobalValues.LogActions.info}:.....docList repopulated with newly created docs...count: {_docList.Count}\r");
                _console.AppendText($"{DateTime.Now} {GlobalValues.LogActions.info}:.....docList repopulated with newly created docs...count: {_docList.Count}" + Environment.NewLine);
            }

            _sbLog.Append($"{DateTime.Now} {GlobalValues.LogActions.info}:.....looping through attachmentList and quattroDocList\r");
            _console.AppendText($"{DateTime.Now} {GlobalValues.LogActions.info}:.....looping through attachmentList and quattroDocList" + Environment.NewLine);

            CreateNewCommentPayload();

            var regexList = _readExcel.QuattroDocList
                .Where(x => x.QuattroDocName.Contains(".*"))
                .Select(s => new { s.QuattroDocName, s.EncDocName })
                .ToDictionary(d => d.QuattroDocName, d => d.EncDocName);

            foreach(var item in regexList)
            {
                foreach(var attachment in _attList)
                {
                    string pattern = $@"{item.Key}";
                    string input = $@"{attachment.title}.pdf";
                    _match = Regex.Match(input, pattern);
                    if (_match.Success)
                    {
                        AssignAttachments(attachment, item.Value);
                    }
                }
            }                                

            foreach (var attachment in _attList)
            {
                foreach (var item in _readExcel.QuattroDocList)
                {
                    if (item.QuattroDocName.Equals($"{attachment.title}.pdf"))
                    {
                        AssignAttachments(attachment, item.EncDocName.ToString());
                    }
                }
            }
        }

        private async void AssignAttachments(AttachResponseModel attachment, string item)
        {
            List<AssignAttachBodyModel> data = new List<AssignAttachBodyModel>();
            data.Add(new AssignAttachBodyModel($"{attachment.attachmentId}", "attachment"));

            _payload = new StringContent(
                JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");

            foreach (var document in _docList)
            {
                if (item == document.title)
                {
                    _sbLog.Append($"{DateTime.Now} {GlobalValues.LogActions.apiEvent}:..api_AssaignAttachments\r");
                    _console.AppendText($"{DateTime.Now} {GlobalValues.LogActions.apiEvent}:..api_AssignAttachments" + Environment.NewLine);

                    var assignAttRequest = await _encompassClient.AssignAttachments(_token, _guid, document.documentId, _payload);
                    if (assignAttRequest.IsSuccessStatusCode)
                    {
                        _sbLog.Append($"{DateTime.Now} {GlobalValues.LogActions.info}:.....attachment assigned: {attachment.title}\r");
                        _sbLog.Append($"{DateTime.Now} {GlobalValues.LogActions.info}:.....assigned to document title: {document.title}\r");
                        _sbLog.Append($"{DateTime.Now} {GlobalValues.LogActions.info}:.....document_id: {document.documentId}\r");
                        _console.AppendText($"{DateTime.Now} {GlobalValues.LogActions.info}:.....attachment assigned: {attachment.title}" + Environment.NewLine);
                        _console.AppendText($"{DateTime.Now} {GlobalValues.LogActions.info}:.....assigned to document title: {document.title}" + Environment.NewLine);
                        _console.AppendText($"{DateTime.Now} {GlobalValues.LogActions.info}:.....document_id: {document.documentId}" + Environment.NewLine);                      

                        var newCommentRequest = await _encompassClient.AddComments(_token, _guid, document.documentId, _newComment);
                        if (newCommentRequest.IsSuccessStatusCode)
                        {
                            _sbLog.Append($"{DateTime.Now} {GlobalValues.LogActions.info}:.....new comment added\r");
                            _console.AppendText($"{DateTime.Now} {GlobalValues.LogActions.info}:.....new comment added" + Environment.NewLine);
                            _docAssignedCount++;
                        }
                        else
                        {
                            _sbLog.Append($"{DateTime.Now} {GlobalValues.LogActions.error}:.failed to create new comment...status code: {newCommentRequest.StatusCode}\r");
                            _console.AppendText($"{DateTime.Now} {GlobalValues.LogActions.error}:.failed to create new comment...status code: {newCommentRequest.StatusCode}" + Environment.NewLine);
                        }
                    }
                    else
                    {
                        _sbLog.Append($"{DateTime.Now} {GlobalValues.LogActions.error}:.failed to assign attachment...status code: {assignAttRequest.StatusCode}\r");
                        _console.AppendText($"{DateTime.Now} {GlobalValues.LogActions.error}:.failed to assign attachment...status code: {assignAttRequest.StatusCode}" + Environment.NewLine);
                    }
                }
            }

            if (_docAssignedCount == _docList.Count)
            {
                ProcessComplete();
            }
        }

        private async void CreateDocument(string docName)
        {
            _sbLog.Append($"{DateTime.Now} {GlobalValues.LogActions.info}:...creating document payload\r");
            Console.WriteLine($"{DateTime.Now} {GlobalValues.LogActions.info}:...creating document payload\r");

            CreateDocPayload(docName);

            _sbLog.Append($"{DateTime.Now} {GlobalValues.LogActions.info}:...payload created\r");
            _sbLog.Append($"{DateTime.Now} {GlobalValues.LogActions.apiEvent}:..api_CreateDocument\r");
            Console.WriteLine($"{DateTime.Now} {GlobalValues.LogActions.info}:...payload created\r");
            Console.WriteLine($"{DateTime.Now} {GlobalValues.LogActions.apiEvent}:..api_CreateDocument\r");

            var createDocRequest = await _encompassClient.CreateDocument(_guid, _token, _docPayload);
            if (createDocRequest.IsSuccessStatusCode)
            {
                _encDocCreatedCount++;
                _sbLog.Append($"{DateTime.Now} {GlobalValues.LogActions.info}:...created document...count: {_encDocCreatedCount}\r");
                Console.WriteLine($"{DateTime.Now} {GlobalValues.LogActions.info}:...created document...count: {_encDocCreatedCount}\r");

                if (_docCreatedCount == _encDocCreatedCount)
                {
                    _docCreatedCount = 0;
                    _encDocCreatedCount = 0;
                    GetAttachments();
                }
            }
        }

        private void CreateDocPayload(string docName)
        {
            var body = new CreateDocumentModel
            {
                title = $"{docName}",
                description = "",
                requestedFrom = "",
                applicationId = "All",
                emnSignature = "string",
                dateReceived = DateTime.Now,
                comments = new List<Comment>
                                {
                                    new Comment
                                    {
                                        comments = "Document index created using document import utility",
                                        forRoleId = 1
                                    }
                                }
            };

            _docPayload = new StringContent(
                JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");
        }

        private void CreateNewCommentPayload()
        {
            List<NewCommentModel> data = new List<NewCommentModel>();
            data.Add(new NewCommentModel($"file added to document"));

            _newComment = new StringContent(
                JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
        }

        //private void PanelController()
        //{
        //    foreach(var panel in _panelsList)
        //    {
        //        if (!panel.Enabled)
        //        {
        //            panel.Enabled = true;
        //        }
        //        else
        //        {
        //            panel.Enabled = false;
        //        }
        //    }
        //}

        private void ProcessComplete()
        {
            _sbLog.Append($"{DateTime.Now} {GlobalValues.LogActions.complete}:.....assignment complete\r");
            _console.AppendText($"{DateTime.Now} {GlobalValues.LogActions.complete}:.....assignment complete" + Environment.NewLine);

            _log.CreateLog(_sbLog);
            _sbLog.Clear();
            _sideMenu.Enabled = true;

            MessageBox.Show("Assignment complete", "Attachment Assignment Process", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //PanelController();
        }
    }
}
