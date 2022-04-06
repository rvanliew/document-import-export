using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentExportUtility_API.Models
{
    public class AssignAttachBodyModel
    {
        public string entityId { get; set; }

        public string entityType { get; set; }

        public AssignAttachBodyModel(string _entityId, string _entityType)
        {
            entityId = _entityId;
            entityType = _entityType;
        }
    }
}
