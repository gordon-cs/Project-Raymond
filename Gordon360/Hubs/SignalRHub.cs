﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Gordon360;
using System.Web.Http;

namespace Gordon360.Hubs
{
    [RoutePrefix("api/signalr")]
    [HubName("ChatHub")]
    public class ChatHub : Hub
    {
       
        public async Task refreshMessages(string user)
         {
                await Clients.All.SendAsync("ReceivedMessagerefresh", user);

         }
        
        public async Task test()
        {
            await Clients.All.SendAsync("It's working boss");

        }
        
        public string test2()
        {
            return "It worked";

        }
    }
 

}