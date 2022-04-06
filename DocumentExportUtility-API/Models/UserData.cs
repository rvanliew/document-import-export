using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentExportUtility_API.Models
{
    public class UserData
    {
        public string UserId { get; set; }
        public string Password { get; set; }
        public string ClientId { get; set; }
        public string Secret { get; set; }
        public string Instance { get; set; }
    }
}
