using DataStructureAndAlgorithmsBackEnd.Hubs;
using DataStructureAndAlgorithmsBackEnd.Model;
using DataStructureAndAlgorithmsBackEnd.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace DataStructureAndAlgorithmsBackEnd.Controllers
{   
    [ApiController]
    [Route("[controller]")]
    public class InsertionSortController: ControllerBase
    {
        private readonly IHubContext<InsertionSortHub> _hubContext;

        public InsertionSortController(IHubContext<InsertionSortHub> hubContext)
        {
            _hubContext = hubContext;
        }
        
        [HttpGet]
        public IActionResult InsertionSort()
        {
            SetUpInsertionSort();
            var response = new { message = "Insertion Sort Finished" };
            return Ok(response);
        }
           private void SetUpInsertionSort()
        {
            var array = RandomIntArray.Generate(15,100).Select(p => (int?)p).ToArray();
            var initialStep = new InsertionSortStep(array, 1, 1,1, 0,0,0,initial:true);
            _hubContext.Clients.All.SendAsync("sendInsertionSortStep", initialStep);
            var finalStep = this.PerformInsertionSort(array);
            _hubContext.Clients.All.SendAsync("sendInsertionSortStep", finalStep);
        }

        private InsertionSortStep PerformInsertionSort(int?[] array)
        {
            int sleepTime = 200;
            int iterations = 0;
            int steps = 0;
            int startIndex = 1;
            while (startIndex < array.Length)
            {
                iterations++;
                int? currentNumber = array[startIndex];
                array[startIndex] = null;
                var iterationStartStep = new InsertionSortStep(array, startIndex, startIndex,startIndex, currentNumber??-1,iterations,steps);
                _hubContext.Clients.All.SendAsync("sendInsertionSortStep", iterationStartStep);
                Thread.Sleep(sleepTime);
                for (int compareIndex = startIndex - 1; compareIndex >= 0; compareIndex--)
                {
                    steps++;
                    if (array[compareIndex] > currentNumber)
                    {
                        array[compareIndex + 1] = array[compareIndex];
                        array[compareIndex] = null;
                        steps++;
                        var shiftStep = new InsertionSortStep(array, startIndex, compareIndex,compareIndex, currentNumber??-1,iterations,steps);
                        _hubContext.Clients.All.SendAsync("sendInsertionSortStep", shiftStep);
                        Thread.Sleep(sleepTime);
                    }
                    else
                    {
                        array[compareIndex + 1] = currentNumber;
                        steps++;
                        var insertionStep = new InsertionSortStep(array, startIndex, compareIndex+1,compareIndex, null,iterations,steps);
                        _hubContext.Clients.All.SendAsync("sendInsertionSortStep", insertionStep);
                        Thread.Sleep(sleepTime*10);
                        currentNumber = null;
                        break;
                    }
                }

                if (currentNumber != null)
                {
                    array[0] = currentNumber;
                    steps++;
                    var insertionStep = new InsertionSortStep(array, startIndex, 0,0, null,iterations,steps);
                    _hubContext.Clients.All.SendAsync("sendInsertionSortStep", insertionStep);
                    Thread.Sleep(sleepTime*10);
                }

                startIndex++;
            }

            return new InsertionSortStep(array, array.Length - 1, array.Length - 1, 0, null, iterations, steps,  true, false);
        }
    }
}