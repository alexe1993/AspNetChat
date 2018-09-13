using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestChat.Models.ViewModels
{
    public class ChatViewModel
    {
        public IEnumerable<MessageViewModel> Messages { get; set; }

        public string Message { get; set; }
    }
}