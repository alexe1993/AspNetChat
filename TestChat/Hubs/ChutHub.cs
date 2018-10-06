using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestChat.Hubs
{
    public class ChutHub:Hub
    {
        public void Send()
        {
            Clients.All.addMessage();
        }
    }
}