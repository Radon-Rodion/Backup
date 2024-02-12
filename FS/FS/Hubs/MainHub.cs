using FS.Models;
using Microsoft.AspNetCore.SignalR;

namespace FS.Hubs
{
    public class MainHub : Hub
    {
        public override async Task OnConnectedAsync() //SendMessage(MessageModel message)
        {
            int i = 0;
            while (true)
            {
                await Clients.All.SendAsync("ReceiveMessage", i);
                await Task.Delay(1000);
                i+= 1;
            }
        }
    }
}
