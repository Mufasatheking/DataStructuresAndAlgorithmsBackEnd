using DataStructureAndAlgorithmsBackEnd.Hubs;
using DataStructureAndAlgorithmsBackEnd.Model;
using DataStructureAndAlgorithmsBackEnd.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace DataStructureAndAlgorithmsBackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SelectSortController : ControllerBase
    {
        private readonly IHubContext<SelectSortHub> _hubContext;

        public SelectSortController(IHubContext<SelectSortHub> hubContext)
        {
            _hubContext = hubContext;
        }
        
        [HttpGet]
        public IActionResult SelectSort()
        {
            SetUpSelectSort();
            var response = new { message = "Select Sort Finished" };
            return Ok(response);
        }
        private void SetUpSelectSort()
        {
            var array = RandomIntArray.Generate(10,100);
            var initialStep = new SelectSortStep(array, 0, 0,0, 0,0,initial:true);
            _hubContext.Clients.All.SendAsync("sendSelectSortStep", initialStep);
            var finalStep = this.PerformSelectSort(array);
            _hubContext.Clients.All.SendAsync("sendSelectSortStep", finalStep);
        }

        private SelectSortStep PerformSelectSort(int[] array)
        {
            int sleepTime = 200;
            int iterations = 0;
            int steps = 0;
            int startIndex = 0;
            while (startIndex < array.Length)
            {
                iterations++;
                int minimumIndex = startIndex;
                var newIterationStep = new SelectSortStep(array, startIndex, startIndex,startIndex, iterations,steps);
                _hubContext.Clients.All.SendAsync("sendSelectSortStep", newIterationStep);
                Thread.Sleep(sleepTime);
                for (int currentIndex = startIndex; currentIndex < array.Length; currentIndex++)
                {
                    var compareStep = new SelectSortStep(array, startIndex, currentIndex,minimumIndex, iterations,steps);
                    _hubContext.Clients.All.SendAsync("sendSelectSortStep", compareStep);
                    Thread.Sleep(sleepTime);
                    if (array[currentIndex] < array[minimumIndex])
                    {
                        steps++;
                        minimumIndex = currentIndex;
                        var assignStep = new SelectSortStep(array, startIndex, currentIndex,minimumIndex, iterations,steps);
                        _hubContext.Clients.All.SendAsync("sendSelectSortStep", assignStep);
                        Thread.Sleep(sleepTime);
                    }
                }

                steps++;
                (array[startIndex], array[minimumIndex]) = (array[minimumIndex], array[startIndex]);
                var swapStep = new SelectSortStep(array, startIndex, array.Length,startIndex, iterations,steps);
                _hubContext.Clients.All.SendAsync("sendSelectSortStep", swapStep);
                Thread.Sleep(sleepTime);
                startIndex++;
            }

            return new SelectSortStep(array, array.Length - 1, array.Length - 1, 0, iterations, steps, true, false);
        }
    }
}