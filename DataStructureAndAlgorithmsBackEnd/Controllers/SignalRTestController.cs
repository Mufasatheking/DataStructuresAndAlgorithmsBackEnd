using DataStructureAndAlgorithmsBackEnd.Hubs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace DataStructureAndAlgorithmsBackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SignalRTestController: ControllerBase
    {
        private readonly IHubContext<SignalRTestHub> _hubContext;

        public SignalRTestController(IHubContext<SignalRTestHub> hubContext)
        {
            _hubContext = hubContext;
        }
        
        [HttpGet]
        public string Get()
        {
            var date = DateTime.Now;
            var message = $"The current DateTime is: {date.ToString()}";
            _hubContext.Clients.All.SendAsync("receivemessage", message);
            return message;
        }
    }
}