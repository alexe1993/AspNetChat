using System;
using System.Collections.Generic;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TestChat.Connnection
{
    public class ChatConnection: PersistentConnection
    {
        protected override Task OnConnected(IRequest request, string connectionId)
        {
            var chatData = connectionId;
            return Connection.Broadcast(chatData);
        }

        protected override Task OnReceived(IRequest request, string connectionId, string data)
        {
            var chatData = data;
            return Connection.Broadcast(chatData);
        }

        protected override Task OnDisconnected(IRequest request, string connectionId, bool stopCalled)
        {
            var chatData = connectionId;
            return Connection.Broadcast(chatData);
        }
    }
}