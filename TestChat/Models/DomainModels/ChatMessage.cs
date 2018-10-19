using System;

namespace TestChat.Models
{

    public class ChatMessage
    {
        public long Id { get; set; }
        public string Text { get; set; }
        public DateTime Time { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}