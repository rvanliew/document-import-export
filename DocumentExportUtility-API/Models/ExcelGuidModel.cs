using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentExportUtility_API.Models
{
    public class ExcelGuidModel
    {
        public string Guid { get; set; }

        public string LoanNumber { get; set; }

        public ExcelGuidModel(string guid, string loanNumber)
        {
            Guid = guid;
            LoanNumber = loanNumber;
        }
    }
}
