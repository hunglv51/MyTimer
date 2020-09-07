using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace WebTimer.Hubs
{
    public class WorkerHub : Hub
    {
        public async Task SendMessage(string msg)
        {
            await Clients.Caller.SendAsync("ReceiveMessage", msg);
        }

    }
}
