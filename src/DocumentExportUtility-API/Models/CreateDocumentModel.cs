using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentExportUtility_API.Models
{
    public class Comment
    {
        [JsonProperty("comments")]
        public string comments { get; set; }

        [JsonProperty("forRoleId")]
        public int forRoleId { get; set; }
    }

    public class CreateDocumentModel
    {

        [JsonProperty("title")]
        public string title { get; set; }

        [JsonProperty("description")]
        public string description { get; set; }

        [JsonProperty("requestedFrom")]
        public string requestedFrom { get; set; }

        [JsonProperty("applicationId")]
        public string applicationId { get; set; }

        [JsonProperty("emnSignature")]
        public string emnSignature { get; set; }

        [JsonProperty("dateRequested")]
        public DateTime dateRequested { get; set; }

        [JsonProperty("dateExpected")]
        public DateTime dateExpected { get; set; }

        [JsonProperty("dateReceived")]
        public DateTime dateReceived { get; set; }

        [JsonProperty("dateReviewed")]
        public DateTime dateReviewed { get; set; }

        [JsonProperty("dateReadyForUw")]
        public DateTime dateReadyForUw { get; set; }

        [JsonProperty("dateReadyToShip")]
        public DateTime dateReadyToShip { get; set; }

        [JsonProperty("comments")]
        public IList<Comment> comments { get; set; }
    }
}
