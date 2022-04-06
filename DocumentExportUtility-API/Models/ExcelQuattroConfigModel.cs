using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentExportUtility_API.Models
{
    public class ExcelQuattroConfigModel
    {
        public string QuattroDocName { get; set; }
        public string EncDocName { get; set; }

        public ExcelQuattroConfigModel(string quattroDocName, string encDocName)
        {
            QuattroDocName = quattroDocName;
            EncDocName = encDocName;
        }
    }
}
