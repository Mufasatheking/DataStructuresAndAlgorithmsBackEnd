namespace DataStructureAndAlgorithmsBackEnd.Model
{
    public class SelectSortStep
    {
        public int[] Array { get; }
        public int StartIndex { get; }
        public int CurrentIndex { get; }
        public int MinimumIndex { get; }
        public int Iterations { get; }
        public int Steps { get; }
        public bool Sorted { get; }
        public bool Initial { get; }

        public SelectSortStep(int[] array, int startIndex, int currentIndex, int minimumIndex, int iterations, int steps, bool sorted = false, bool initial = false)
        {
            Array = array;
            StartIndex = startIndex;
            CurrentIndex = currentIndex;
            MinimumIndex = minimumIndex;
            Iterations = iterations;
            Steps = steps;
            Sorted = sorted;
            Initial = initial;
        }
    }
}