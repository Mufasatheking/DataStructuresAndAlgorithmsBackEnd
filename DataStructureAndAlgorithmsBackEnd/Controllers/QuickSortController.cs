using DataStructureAndAlgorithmsBackEnd.Hubs;
using DataStructureAndAlgorithmsBackEnd.Model;
using DataStructureAndAlgorithmsBackEnd.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace DataStructureAndAlgorithmsBackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QuickSortController : ControllerBase
    {
        private readonly IHubContext<PartitionExampleHub> _partitionHubContext;

        public QuickSortController(IHubContext<PartitionExampleHub> partitionHubContext)
        {
            _partitionHubContext = partitionHubContext;
        }

        [Route("[action]")]
        [HttpGet]
        public IActionResult PartitionExample()
        {
            SetUpPartitionExample();
            var response = new { message = "PartitionExample Finished" };
            return Ok(response);
        }

        private void SetUpPartitionExample()
        {
            var array = RandomIntArray.Generate(15,100);
            //var array = new int[] { 0, 1,4,0,1,4,9,2,5,6,2,5,6, 3 }; // RandomIntArray.Generate(10,100);
            var leftPointerIndex = 0;
            var rightPointerIndex = array.Length - 1;
            var pivotIndex = rightPointerIndex;
            var initialStep = new QuickSortStep(array, pivotIndex, leftPointerIndex, true, null,rightPointerIndex-1, false,
                null,false, 0, 0,"Initializing Partition Example", initial: true);
            _partitionHubContext.Clients.All.SendAsync("sendPartitionExampleStep", initialStep);
            var finalStep = this.Partition(array, leftPointerIndex, rightPointerIndex);
            //_partitionHubContext.Clients.All.SendAsync("sendPartitionExampleStep", array);
        }

        private int Partition(int[] array, int leftPointer, int rightPointer)
        {
            int pivotIndex = rightPointer;

            int pivot = array[pivotIndex];

            rightPointer -= 1;
            
            while (true)
            {
                while (array[leftPointer] < pivot)
                {
                    Thread.Sleep(1000);
                    leftPointer++;
                    var leftStep = new QuickSortStep(array, pivotIndex, leftPointer, true, null, rightPointer, false,
                        null,false, 0, 0, "Left Pointer finding values greater than pivot");
                    _partitionHubContext.Clients.All.SendAsync("sendPartitionExampleStep", leftStep);
                }
                var leftValueFoundStep = new QuickSortStep(array, pivotIndex, leftPointer, false, array[leftPointer], rightPointer, false,
                    null,false, 0, 0, $"Left Pointer found value: {array[leftPointer]} which is greater than pivot value: {pivot}");
                _partitionHubContext.Clients.All.SendAsync("sendPartitionExampleStep", leftValueFoundStep);
                Thread.Sleep(3000);
                
                while (array[rightPointer] > pivot)
                {
                    Thread.Sleep(1000);
                    rightPointer--;
                    var rightStep = new QuickSortStep(array, pivotIndex, leftPointer, false, array[leftPointer],rightPointer, true,
                        null,false, 0, 0,"Right Pointer finding values less than pivot");
                    _partitionHubContext.Clients.All.SendAsync("sendPartitionExampleStep", rightStep);
                }
                var rightValueFoundStep = new QuickSortStep(array, pivotIndex, leftPointer, false, array[leftPointer], rightPointer, false,
                    array[rightPointer],false, 0, 0,$"Right Pointer found value: {array[rightPointer]} which is less than pivot value: {pivot}");
                _partitionHubContext.Clients.All.SendAsync("sendPartitionExampleStep", rightValueFoundStep);
                Thread.Sleep(3000);

                if (leftPointer >= rightPointer)
                    break;
                else
                {
                    var preSwapStep = new QuickSortStep(array, pivotIndex, leftPointer, false, array[leftPointer],rightPointer, false,
                        array[rightPointer],true, 0, 0, "As left pointer index is less than right pointer index swap their values");
                    _partitionHubContext.Clients.All.SendAsync("sendPartitionExampleStep", preSwapStep);
                    Thread.Sleep(1000);
                    (array[leftPointer], array[rightPointer]) = (array[rightPointer], array[leftPointer]);
                    var postSwapStep = new QuickSortStep(array, pivotIndex, leftPointer, false, array[leftPointer],rightPointer, false,
                        array[rightPointer],true, 0, 0, "Left and Right values swapped");
                    _partitionHubContext.Clients.All.SendAsync("sendPartitionExampleStep", postSwapStep);
                    Thread.Sleep(2000);
                    leftPointer++;
                    var postleftIncrementStep = new QuickSortStep(array, pivotIndex, leftPointer, false, array[leftPointer],rightPointer, false,
                        array[rightPointer],false, 0, 0, "Incremented Left Pointer Value to get ready for the next stage");
                    _partitionHubContext.Clients.All.SendAsync("sendPartitionExampleStep", postleftIncrementStep);
                    Thread.Sleep(2000);
                }
            }
            
            var pivotSwapStep = new QuickSortStep(array, pivotIndex, leftPointer, false, array[leftPointer],rightPointer, false,
                array[rightPointer],false, 0, 0, "As Left Pointer value is greater than Right Pointer Value we swap the Left Pointer value with the Pivot",true);
            _partitionHubContext.Clients.All.SendAsync("sendPartitionExampleStep", pivotSwapStep);
            Thread.Sleep(4000);
            (array[leftPointer], array[pivotIndex]) = (array[pivotIndex], array[leftPointer]);
            
            var finalStep = new QuickSortStep(array, leftPointer, leftPointer, false, array[leftPointer],rightPointer, false,
                array[rightPointer],false, 0, 0, "Array successfully partitioned");
            _partitionHubContext.Clients.All.SendAsync("sendPartitionExampleStep", finalStep);
            Thread.Sleep(2000);
            return leftPointer;
        }
    }
}