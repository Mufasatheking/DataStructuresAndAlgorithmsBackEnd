namespace DataStructureAndAlgorithmsBackEnd.Model
{
    public class QuickSortStep
    {
        public int[] Array { get; }
        public int PivotIndex { get; }
        public int LeftPointerIndex { get; }
        public bool LeftComparing { get; }
        public int? LeftPointerValue { get; }
        public int RightPointerIndex { get; }
        public bool RightComparing { get; }
        public int? RightPointerValue { get; }
        public bool Swapping { get; }
        public int Iterations { get; }
        public int Steps { get; }
        public string Message { get; }
        public bool PivotSwap { get; }
        public bool Sorted { get; }
        public bool Initial { get; }

        public QuickSortStep(int[] array, int pivotIndex, int leftPointerIndex, bool leftComparing,int? leftPointerValue, int rightPointerIndex, bool rightComparing, int? rightPointerValue, bool swapping, int iterations, int steps,string message,bool pivotSwap = false, bool sorted = false, bool initial = false)
        {
            Array = array;
            PivotIndex = pivotIndex;
            LeftPointerIndex = leftPointerIndex;
            LeftComparing = leftComparing;
            LeftPointerValue = leftPointerValue;
            RightPointerIndex = rightPointerIndex;
            RightComparing = rightComparing;
            RightPointerValue = rightPointerValue;
            Swapping = swapping;
            Iterations = iterations;
            Steps = steps;
            Message = message;
            PivotSwap = pivotSwap;
            Sorted = sorted;
            Initial = initial;
        }
    }
}