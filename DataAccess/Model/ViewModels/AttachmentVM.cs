using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataAccess.Models.ViewModels
{
    public class AttachmentVM
    {
        public string transaction_ID { get; set; }
        public int attachment_Index { get; set; }
        public int? form_ID { get; set; }
        public string attachment { get; set; }
        public string displayName { get; set; }
    }
}