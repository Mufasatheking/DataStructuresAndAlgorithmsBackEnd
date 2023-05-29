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

        private List<int> previousPivotIndexes = new List<int>();
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
                null,false, 0, 0,"Initializing Partition Example", initial: true,previousPivotIndexes:previousPivotIndexes);
            _partitionHubContext.Clients.All.SendAsync("sendPartitionExampleStep", initialStep);
            var finalStep = this.Partition(array, leftPointerIndex, rightPointerIndex);
            //_partitionHubContext.Clients.All.SendAsync("sendPartitionExampleStep", array);
        }
        
        [HttpGet]
        public IActionResult QuickSort()
        {
            SetUpQuickSort();
            var response = new { message = "SetUpQuickSort Finished" };
            return Ok(response);
        }

        private void SetUpQuickSort()
        {
            var array = RandomIntArray.Generate(35,100);
            //var array = new int[] { 0, 1,4,0,1,4,9,2,5,6,2,5,6, 3 }; // RandomIntArray.Generate(10,100);
            var leftPointerIndex = 0;
            var rightPointerIndex = array.Length - 1;
            var pivotIndex = rightPointerIndex;
            var initialStep = new QuickSortStep(array, pivotIndex, leftPointerIndex, true, null,rightPointerIndex-1, false,
                null,false, 0, 0,"Initializing Partition Example", initial: true,previousPivotIndexes:previousPivotIndexes);
            _partitionHubContext.Clients.All.SendAsync("sendPartitionExampleStep", initialStep);
            this.QuickSort(array, leftPointerIndex, rightPointerIndex);
            //_partitionHubContext.Clients.All.SendAsync("sendPartitionExampleStep", array);
        }
        private void QuickSort(int[] array, int leftIndex, int rightIndex)
        {
            // Base case: the subarray has 0 or 1 elements:
            if (rightIndex - leftIndex <= 0)
            {
                if (array.Length == 1)
                {
                    this.previousPivotIndexes.Add(leftIndex);
                }
                return;
            }

            // Partition the range of elements and grab the index of the pivot:
            int pivotIndex = Partition(array,leftIndex, rightIndex);
        
            // Recursively call this QuickSort method on whatever
            // is to the left of the pivot:
            QuickSort(array,leftIndex, pivotIndex - 1);

            // Recursively call this QuickSort method on whatever
            // is to the right of the pivot:
            QuickSort(array,pivotIndex + 1, rightIndex);
        }
        private int Partition(int[] array, int leftPointer, int rightPointer)
        {
            int pivotIndex = rightPointer;

            int pivot = array[pivotIndex];

            rightPointer -= 1;
            var threadSleep = 20;
            while (true)
            {
                while (array[leftPointer] < pivot)
                {
                    Thread.Sleep(threadSleep*2);
                    leftPointer++;
                    var leftStep = new QuickSortStep(array, pivotIndex, leftPointer, true, null, rightPointer, false,
                        null,false, 0, 0, "Left Pointer finding values greater than pivot",previousPivotIndexes);
                    _partitionHubContext.Clients.All.SendAsync("sendPartitionExampleStep", leftStep);
                }
                var leftValueFoundStep = new QuickSortStep(array, pivotIndex, leftPointer, false, array[leftPointer], rightPointer, false,
                    null,false, 0, 0, $"Left Pointer found value: {array[leftPointer]} which is greater than pivot value: {pivot}",previousPivotIndexes);
                _partitionHubContext.Clients.All.SendAsync("sendPartitionExampleStep", leftValueFoundStep);
                Thread.Sleep(threadSleep*6);
                
                while (array[rightPointer] > pivot)
                {
                    Thread.Sleep(threadSleep*2);
                    rightPointer--;
                    var rightStep = new QuickSortStep(array, pivotIndex, leftPointer, false, array[leftPointer],rightPointer, true,
                        null,false, 0, 0,"Right Pointer finding values less than pivot",previousPivotIndexes);
                    _partitionHubContext.Clients.All.SendAsync("sendPartitionExampleStep", rightStep);
                }
                var rightValueFoundStep = new QuickSortStep(array, pivotIndex, leftPointer, false, array[leftPointer], rightPointer, false,
                    array[rightPointer],false, 0, 0,$"Right Pointer found value: {array[rightPointer]} which is less than pivot value: {pivot}",previousPivotIndexes);
                _partitionHubContext.Clients.All.SendAsync("sendPartitionExampleStep", rightValueFoundStep);
                Thread.Sleep(threadSleep*6);

                if (leftPointer >= rightPointer)
                    break;
                else
                {
                    var preSwapStep = new QuickSortStep(array, pivotIndex, leftPointer, false, array[leftPointer],rightPointer, false,
                        array[rightPointer],true, 0, 0, "As left pointer index is less than right pointer index swap their values",previousPivotIndexes);
                    _partitionHubContext.Clients.All.SendAsync("sendPartitionExampleStep", preSwapStep);
                    Thread.Sleep(threadSleep*2);
                    (array[leftPointer], array[rightPointer]) = (array[rightPointer], array[leftPointer]);
                    var postSwapStep = new QuickSortStep(array, pivotIndex, leftPointer, false, array[leftPointer],rightPointer, false,
                        array[rightPointer],true, 0, 0, "Left and Right values swapped",previousPivotIndexes);
                    _partitionHubContext.Clients.All.SendAsync("sendPartitionExampleStep", postSwapStep);
                    Thread.Sleep(threadSleep*4);
                    leftPointer++;
                    var postleftIncrementStep = new QuickSortStep(array, pivotIndex, leftPointer, false, array[leftPointer],rightPointer, false,
                        array[rightPointer],false, 0, 0, "Incremented Left Pointer Value to get ready for the next stage",previousPivotIndexes);
                    _partitionHubContext.Clients.All.SendAsync("sendPartitionExampleStep", postleftIncrementStep);
                    Thread.Sleep(threadSleep*4);
                }
            }
            
            var pivotSwapStep = new QuickSortStep(array, pivotIndex, leftPointer, false, array[leftPointer],rightPointer, false,
                array[rightPointer],false, 0, 0, "As Left Pointer value is greater than Right Pointer Value we swap the Left Pointer value with the Pivot",previousPivotIndexes,true);
            _partitionHubContext.Clients.All.SendAsync("sendPartitionExampleStep", pivotSwapStep);
            Thread.Sleep(threadSleep*6);
            (array[leftPointer], array[pivotIndex]) = (array[pivotIndex], array[leftPointer]);
            previousPivotIndexes.Add(leftPointer);
            var finalStep = new QuickSortStep(array, leftPointer, leftPointer, false, array[leftPointer],rightPointer, false,
                array[rightPointer],false, 0, 0, "Array successfully partitioned",previousPivotIndexes);
            _partitionHubContext.Clients.All.SendAsync("sendPartitionExampleStep", finalStep);
            Thread.Sleep(threadSleep*4);
            return leftPointer;
        }
    }
}