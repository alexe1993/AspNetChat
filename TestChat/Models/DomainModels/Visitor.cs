using System;

namespace TestChat.Models
{
    public class Visitor
    {
        public long Id { get; set; }
        public string Url { get; set; }
        public string Ip { get; set; }
        public string Browser { get; set; }
        public string UserAgent { get; set; }
        public string UserLanguages { get; set; }
        public DateTime DateTime { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}