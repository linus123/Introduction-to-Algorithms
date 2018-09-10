namespace Core.Unit01
{
    public class PeakFinding2D
    {
        private AlgoType _algoType;

        public enum AlgoType
        {
            BruteForce,
            Algoritim1
        }

        public PeakFinding2D(
            AlgoType algoType)
        {
            _algoType = algoType;
        }

        public int FindPeek(int[,] array2D)
        {
            if (_algoType == AlgoType.Algoritim1)
                return FindPeakAlgo1(array2D);

            return FindPeakBruteForce(array2D);
        }

        private int FindPeakAlgo1(
            int[,] array2D)
        {
            var grid = new Grid(array2D);

            var middleIndexX = grid.Width / 2;

            var max = int.MinValue;
            var maxIndexY = 0;

            for (int y = 0; y < grid.Height; y++)
            {
                var value = grid.GetValue(middleIndexX, y);
                if (max < value)
                {
                    max = value;
                    maxIndexY = y;
                }
            }

            if (middleIndexX == 0)
            {
                return max;
            }

            var leftValue = grid.GetLeftValue(middleIndexX, maxIndexY);
            var rightValue = grid.GetRightValue(middleIndexX, maxIndexY);

            if (max >= leftValue && max >= rightValue)
            {
                return max;
            }

            if (leftValue > max)
            {
                var subArray = grid.GetSubArray(
                    0, 0,
                    middleIndexX, grid.Height);

                return FindPeakAlgo1(subArray);
            }

            if (rightValue >= max)
            {
                var subArray = grid.GetSubArray(
                    middleIndexX + 1, 0,
                    grid.Width - middleIndexX - 1, grid.Height);

                return FindPeakAlgo1(subArray);
            }

            return grid.GetValue(0, 0);
        }

        private int FindPeakBruteForce(
            int[,] array2D)
        {
            var grid = new Grid(array2D);

            for (int y = 0; y < grid.Height; y++)
            {
                for (int x = 0; x < grid.Width; x++)
                {
                    if (grid.IsPeak(x, y))
                        return grid.GetValue(x, y);
                }
            }

            return grid.GetValue(0, 0);
        }
    }
}