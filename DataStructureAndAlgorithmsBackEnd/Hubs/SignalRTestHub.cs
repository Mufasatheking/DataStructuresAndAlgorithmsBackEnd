using Microsoft.AspNetCore.SignalR;

namespace DataStructureAndAlgorithmsBackEnd.Hubs
{
    public class SignalRTestHub : Hub
    {
        public async Task SendMessage(string message)
        {
            await Clients.All.SendAsync("receivemessage", message);
        }
    }
}