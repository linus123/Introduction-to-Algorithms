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

        public int FindPeek(int[,] array2D)
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

        private class Grid
        {
            private readonly int[,] _grid;

            public Grid(
                int[,] grid)
            {
                _grid = grid;
            }

            public int Height
            {
                get { return _grid.GetLength(0); }
            }

            public int Width
            {
                get { return _grid.GetLength(1); }
            }

            public int GetValue(int x, int y)
            {
                return _grid[y, x];
            }

            private int GetAboveValue(int x, int y)
            {
                var adjustedY = y - 1;

                if (adjustedY < 0)
                {
                    return GetValue(x, y);
                }

                return GetValue(x, adjustedY);
            }

            private int GetBelowValue(int x, int y)
            {
                var adjustedY = y + 1;

                if (adjustedY >= Height)
                {
                    return GetValue(x, y);
                }

                return GetValue(x, adjustedY);
            }

            private int GetLeftValue(int x, int y)
            {
                var adjustedX = x - 1;

                if (adjustedX < 0)
                {
                    return GetValue(x, y);
                }

                return GetValue(adjustedX, y);
            }

            private int GetRightValue(int x, int y)
            {
                var adjustedX = x + 1;

                if (adjustedX >= Width)
                {
                    return GetValue(x, y);
                }

                return GetValue(adjustedX, y);
            }

            public bool IsPeak(
                int x, int y)
            {
                return GetValue(x, y) >= GetAboveValue(x, y)
                       && GetValue(x, y) >= GetBelowValue(x, y)
                       && GetValue(x, y) >= GetLeftValue(x, y)
                       && GetValue(x, y) >= GetRightValue(x, y);
            }
        }

    }
}