using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;
using WorkTimer;

namespace WebTimer.Pages
{
    public class IndexModel : PageModel
    {
        private readonly Worker _worker;

        public IndexModel(Worker worker)
        {
            _worker = worker;
        }

        public void OnGet()
        {
            if (!_worker.IsRunning)
            {
                _worker.Start();
            }
        }
    }
}
