using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestChat.Models.ViewModels
{
    public class ChatViewModel
    {
        public string Message { get; set; }
        public int MessagesCount { get; set; }
    }
   
}