using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentExportUtility_API.Models
{
    public class AttachmentDataModel
    {
        public string Guid { get; set; }
        public string AttachmentId { get; set; }
        public string AttachmentTitle { get; set; }
        public string LoanNumber { get; set; }
    }
}
