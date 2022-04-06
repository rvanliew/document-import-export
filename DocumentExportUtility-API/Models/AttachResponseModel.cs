using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentExportUtility_API.Models
{
    public class AttachResponseModel
    {
        public string title { get; set; }
        public string attachmentId { get; set; }
        public DateTime dateCreated { get; set; }
        public string createdBy { get; set; }
        public string createdByName { get; set; }
        public bool isRemoved { get; set; }
        public int attachmentType { get; set; }
        public int fileSize { get; set; }
        public bool isActive { get; set; }
        public Page[] pages { get; set; }
    }

    public class Page
    {
        public string imageKey { get; set; }
        public string zipKey { get; set; }
        public string nativeKey { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public float horizontalResolution { get; set; }
        public float verticalResolution { get; set; }
        public int rotation { get; set; }
        public int fileSize { get; set; }
        public string mediaUrl { get; set; }
        public Thumbnail thumbnail { get; set; }
    }

    public class Thumbnail
    {
        public string imageKey { get; set; }
        public string zipKey { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public float horizontalResolution { get; set; }
        public float verticalResolution { get; set; }
        public string mediaUrl { get; set; }
    }
}
