namespace Core.Unit01
{
    public class PeakFinding2D
    {
        private AlgoType _algoType;

        public enum AlgoType
        {
            BruteForce
        }

        public PeakFinding2D(
            AlgoType algoType)
        {
            _algoType = algoType;
        }

        public int FindPeek(int[,] grid)
        {
            if (grid.GetLength(0) == 1
                && grid.GetLength(1) == 1)
                return grid[0, 0];

            if (grid.GetLength(0) == 2
                && grid.GetLength(1) == 1)
            {
                if (grid[0, 0] >= grid[1, 0])
                    return grid[0, 0];

                return grid[1, 0];
            }

            if (grid.GetLength(0) == 1
                && grid.GetLength(1) == 2)
            {
                if (grid[0, 0] >= grid[0, 1])
                    return grid[0, 0];

                return grid[0, 1];
            }

            return grid[0, 0];
        }
    }
}