using System;
using System.IO;
using System.Text;

namespace DocumentExportUtility_API.Log
{
    public class Logger
    {
        public string path;

        public Logger()
        {
            //
        }

        public void CreateLog(StringBuilder sb)
        {
            string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string logFolder = Path.Combine(folder, "LoganDocumentExport", "_Log");
            Directory.CreateDirectory(logFolder);

            path = $@"{logFolder}{GlobalValues.FileLocation.log}";

            File.AppendAllText(path, sb.ToString());
        }
    }
}
