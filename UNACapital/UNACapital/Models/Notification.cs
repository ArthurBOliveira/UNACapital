using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UNACapital.Models
{
    public class Notification
    {
        public string RestKey { get; set; }
        public string ApiKey { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string  SubTitle { get; set; }
        public string Url { get; set; }
        public string Error { get; set; }
    }
}