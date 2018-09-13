using System;

namespace TestChat.Models.ViewModels
{
    public class MessageViewModel {
        public string Message { get; set; }
        public string User { get; set; }
        public DateTime Time { get; set; }
    }
}