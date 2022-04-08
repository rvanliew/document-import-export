using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentExportUtility_API.Log
{
    public static class GlobalValues
    {
        public static class LogActions
        {
            public const string info =      "INFO     ";
            public const string warning =   "WARNING  ";
            public const string apiEvent =  "EVENT    ";
            public const string error =     "ERROR    ";
            public const string trace =     "TRACE    ";
            public const string complete =  "COMPLETE ";
        }

        public static class FileLocation
        {
            public const string log = @"\Log.txt";
        }
    }
}
