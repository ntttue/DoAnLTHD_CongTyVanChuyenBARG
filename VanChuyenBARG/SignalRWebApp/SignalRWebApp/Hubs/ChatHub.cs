using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace SignalRWebApp.Hubs
{
    public class ChatHub : Hub
    {
        public static Dictionary<string, string> dicConns = new Dictionary<string, string>();
        public void Connect(string userName)
        {
            dicConns.Add(userName, Context.ConnectionId);
        }

        public void SendPrivate(string userName, string message)
        {
            string userConn = dicConns[userName];

            Clients.Client(userConn).NotifyForSomeOne(message);
        }
        ////Gọi hàm phía server
        public void Send(string userName, string message)
        {
            //Gọi hàm phía client
            Clients.All.NotifyMessage(userName, message);
        }
    }
}