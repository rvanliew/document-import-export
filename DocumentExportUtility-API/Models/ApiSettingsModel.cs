using DocumentExportUtility_API.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentExportUtility_API.Models
{
    public class ApiSettingsModel
    {

        [JsonConverter(typeof(EncryptingJsonConverter), "#environment*S3cr3t")]
        public string environment { get; set; }

        [JsonConverter(typeof(EncryptingJsonConverter), "#clientId*S3cr3t")]
        public string client_id { get; set; }

        [JsonConverter(typeof(EncryptingJsonConverter), "#clientSecret*S3cr3t")]
        public string client_secret { get; set; }
    }
}
