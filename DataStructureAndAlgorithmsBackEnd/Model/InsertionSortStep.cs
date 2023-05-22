namespace DataStructureAndAlgorithmsBackEnd.Model
{
    public class InsertionSortStep
    {
        public int?[] Array { get; }
        public int StartIndex { get; }
        public int CompareIndex { get; }
        public int GapIndex { get; }
        public int? CurrentNumber { get; }
        public int Iterations { get; }
        public int Steps { get; }
        public bool Sorted { get; }
        public bool Initial { get; }

        public InsertionSortStep(int?[] array, int startIndex, int compareIndex, int gapIndex, int? currentNumber, int iterations, int steps, bool sorted = false, bool initial = false)
        {
            Array = array;
            StartIndex = startIndex;
            CompareIndex = compareIndex;
            GapIndex = gapIndex;
            CurrentNumber = currentNumber;
            Iterations = iterations;
            Steps = steps;
            Sorted = sorted;
            Initial = initial;
        }
    }

}