using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCCrudCodeFirst
{
    public class ChatHub : Hub
    {
        //public void Hello()
        //{
        //    Clients.All.hello();
        //}

        public void Send(string name, string message)
        {
            //call the broadcastMessage method to update clients.
            Clients.All.broadcastMessage(name, message);
        }
    }
}