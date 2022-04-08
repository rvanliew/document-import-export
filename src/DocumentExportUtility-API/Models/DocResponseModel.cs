using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentExportUtility_API.Models
{
    public class DocumentAttachment
    {

        [JsonProperty("entityId")]
        public string entityId { get; set; }

        [JsonProperty("entityType")]
        public string entityType { get; set; }

        [JsonProperty("entityName")]
        public string entityName { get; set; }

        [JsonProperty("entityUri")]
        public string entityUri { get; set; }
    }

    public class Role
    {
        [JsonProperty("entityId")]
        public string entityId { get; set; }

        [JsonProperty("entityType")]
        public string entityType { get; set; }

        [JsonProperty("entityName")]
        public string entityName { get; set; }
    }

    public class DocResponseModel
    {

        [JsonProperty("documentId")]
        public string documentId { get; set; }

        [JsonProperty("title")]
        public string title { get; set; }

        [JsonProperty("titleWithIndex")]
        public string titleWithIndex { get; set; }

        [JsonProperty("applicationId")]
        public string applicationId { get; set; }

        [JsonProperty("applicationName")]
        public string applicationName { get; set; }

        [JsonProperty("milestoneId")]
        public string milestoneId { get; set; }

        [JsonProperty("webCenterAllowed")]
        public bool webCenterAllowed { get; set; }

        [JsonProperty("tpoAllowed")]
        public bool tpoAllowed { get; set; }

        [JsonProperty("thirdPartyAllowed")]
        public bool thirdPartyAllowed { get; set; }

        [JsonProperty("isProtected")]
        public bool isProtected { get; set; }

        [JsonProperty("daysDue")]
        public int daysDue { get; set; }

        [JsonProperty("daysTillExpire")]
        public int daysTillExpire { get; set; }

        [JsonProperty("dateCreated")]
        public DateTime dateCreated { get; set; }

        [JsonProperty("createdBy")]
        public string createdBy { get; set; }

        [JsonProperty("status")]
        public string status { get; set; }

        [JsonProperty("docGroups")]
        public IList<string> docGroups { get; set; }

        [JsonProperty("comments")]
        public IList<object> comments { get; set; }

        [JsonProperty("attachments")]
        public IList<AttachResponseModel> attachments { get; set; }

        [JsonProperty("conditions")]
        public IList<object> conditions { get; set; }

        [JsonProperty("roles")]
        public IList<Role> roles { get; set; }

        [JsonProperty("description")]
        public string description { get; set; }

        [JsonProperty("isSettlementServicesDocument")]
        public bool? isSettlementServicesDocument { get; set; }

        [JsonProperty("dateExpires")]
        public DateTime? dateExpires { get; set; }

        [JsonProperty("statusDate")]
        public DateTime? statusDate { get; set; }

        [JsonProperty("isReceived")]
        public bool? isReceived { get; set; }

        [JsonProperty("dateReceived")]
        public DateTime? dateReceived { get; set; }

        [JsonProperty("receivedBy")]
        public string receivedBy { get; set; }
    }
}
