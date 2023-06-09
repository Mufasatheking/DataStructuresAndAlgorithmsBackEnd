using DataStructureAndAlgorithmsBackEnd.Hubs;
using DataStructureAndAlgorithmsBackEnd.Model;
using DataStructureAndAlgorithmsBackEnd.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace DataStructureAndAlgorithmsBackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BubbleSortController : ControllerBase
    {
        private readonly IHubContext<BubbleSortHub> _hubContext;

        public BubbleSortController(IHubContext<BubbleSortHub> hubContext)
        {
            _hubContext = hubContext;
        }
        
        [HttpGet]
        public IActionResult BubbleSort()
        {
            SetUpBubbleSort();

            var response = new { message = "Bubble Sort Finished" };
            return Ok(response);
        }

        private void SetUpBubbleSort()
        {
            var array = RandomIntArray.Generate(10,100);
            var initialStep = new BubbleSortStep(array, 0, 0,0, initial:true);
            _hubContext.Clients.All.SendAsync("sendBubbleSortStep", initialStep);
            var finalstep = this.PerformBubbleSort(array);
            _hubContext.Clients.All.SendAsync("sendBubbleSortStep", finalstep);
        }

        private BubbleSortStep PerformBubbleSort(int[] array)
        {
            int sleepTime = 1000;
            int iterations = 0;
            int steps = 0;
            bool wasSwapped = true;
            while (wasSwapped) {
                wasSwapped = false;
                iterations++;
                for (int i = 0; i < array.Length - 1; i++)
                {
                    steps++;
                    Thread.Sleep(sleepTime);
                    var currentStep = new BubbleSortStep(array, i, iterations, steps, comparing: true);
                    _hubContext.Clients.All.SendAsync("sendBubbleSortStep", currentStep);
                    if (array[i] > array[i + 1]) {
                        steps++;
                        Thread.Sleep(sleepTime);
                        (array[i], array[i + 1]) = (array[i + 1], array[i]);
                        wasSwapped = true;
                        var currentStep2 = new BubbleSortStep(array, i, iterations, steps, swapped: true);
                        _hubContext.Clients.All.SendAsync("sendBubbleSortStep", currentStep2);
                    }
                }
            }
            return new BubbleSortStep(array, array.Length-1, iterations, steps, sorted:true);
        }
    }
}