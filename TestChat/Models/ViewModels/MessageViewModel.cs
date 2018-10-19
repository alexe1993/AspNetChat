using System;

namespace TestChat.Models.ViewModels
{
    public class MessageViewModel {
        public string Message { get; set; }
        public string User { get; set; }
        public DateTime Time { get; set; }
        public long Id { get; set; }
        public MessageStatus MessageStatus {get;set;}
    }
    public enum MessageStatus
    {
        None,
        New,
        Deleted,
        Edited
    }
}