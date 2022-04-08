using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentExportUtility_API.Models
{
    public class NewCommentModel
    {
        public string comments { get; set; }

        public NewCommentModel(string _newComment)
        {
            comments = _newComment;
        }
    }
}
