using Microsoft.AspNetCore.SignalR;
using WebTimer.Hubs;
using WorkTimer;

namespace WebTimer.Utils
{
    public class HubNotifier : INotifier
    {
        private readonly IHubContext<WorkerHub> _hubContext;
        public HubNotifier(IHubContext<WorkerHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public void Notify(string s)
        {
            _hubContext.Clients.All.SendAsync("ReceiveMessage", s).Wait();
        }
    }
}
