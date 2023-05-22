namespace DataStructureAndAlgorithmsBackEnd.Model
{
    public class BubbleSortStep
    {
        public BubbleSortStep(int[] array, int index, int iterations, int steps, bool comparing= false, bool swapped= false, bool sorted= false,bool initial = false)
        {
            Array = array;
            Index = index;
            Iterations = iterations;
            Steps = steps;
            Comparing = comparing;
            Swapped = swapped;
            Sorted = sorted;
            Initial = initial;
        }
        
        public int[] Array { get; set; }
        public int Index { get; set; }
        public int Iterations { get; set; }
        public int Steps { get; set; }
        public bool Comparing { get; set; }
        public bool Swapped { get; set; }
        public bool Sorted { get; set; }
        public bool Initial { get; set; }
    }
}