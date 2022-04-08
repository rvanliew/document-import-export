using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentExportUtility_API.Models
{
    public class MediaUrlModel
    {
        [JsonProperty("multiChunkRequired")]
        public bool multiChunkRequired { get; set; }

        [JsonProperty("attachmentId")]
        public string attachmentId { get; set; }

        [JsonProperty("authorizationHeader")]
        public string authorizationHeader { get; set; }

        [JsonProperty("expiresAt")]
        public DateTime expiresAt { get; set; }

        [JsonProperty("uploadUrl")]
        public string uploadUrl { get; set; }
    }
}
