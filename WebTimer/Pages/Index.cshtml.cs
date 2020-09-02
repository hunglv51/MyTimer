using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;
using WorkTimer;

namespace WebTimer.Pages
{
    public class IndexModel : PageModel, INotifier
    {
        private readonly IHubContext<LogHub> _hubContext;
        public IndexModel(IHubContext<LogHub> hubContext, Worker worker)
        {
            _hubContext = hubContext;
            worker.SetDisplayer(this);
            worker.Start();
        }

        public void Notify(string s)
        {
            _hubContext.Clients.All.SendAsync("GetLogs", s);
        }

        public void OnGet()
        {
        }

    }
}