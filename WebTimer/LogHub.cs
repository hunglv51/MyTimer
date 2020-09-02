using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkTimer;

namespace WebTimer
{
    public class LogHub : Hub
    {
        public void Notify(string s)
        {
            Clients.All.SendAsync("GetLogs", s);
        }
    }
}
