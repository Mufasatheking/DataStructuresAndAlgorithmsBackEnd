using Microsoft.AspNetCore.SignalR;

namespace DataStructureAndAlgorithmsBackEnd.Hubs
{
    public class BubbleSortHub: Hub
    {
        public async Task SendMessage(string message)
        {
            await Clients.All.SendAsync("receivemessage", message);
        }
    }
}