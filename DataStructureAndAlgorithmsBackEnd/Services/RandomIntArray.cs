namespace DataStructureAndAlgorithmsBackEnd.Services
{
    public static class RandomIntArray
    {
        public static int[] Generate(int length, int max)
        {
            Random random = new Random();
            int[] array = new int[length];

            for (int i = 0; i < length; i++)
            {
                array[i] = random.Next(0, max + 1);
            }

            return array;
        }
    }
}