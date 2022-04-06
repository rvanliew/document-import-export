using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentExportUtility_API.Models
{
    public class EncFile
    {

        [JsonProperty("contentType")]
        public string contentType { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("size")]
        public int size { get; set; }
    }

    public class UploadAttachBodyModel
    {

        [JsonProperty("file")]
        public EncFile file { get; set; }

        [JsonProperty("title")]
        public string title { get; set; }
    }
}
