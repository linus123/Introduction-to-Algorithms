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
            var grd = new Grid(grid);

            if (grd.Width <= 2
                && grd.Height <= 2)
            {
                return grd.GetMaxValue();
            }

            for (int y = 0; y < grd.Height; y++)
            {
                for (int x = 0; x < grd.Width; x++)
                {
                    if (grd.IsPeak(x, y))
                        return grd.GetValue(x, y);
                }
            }

            return grid[0, 0];
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

            public int GetMaxValue()
            {
                int max = int.MinValue;

                for (int x = 0; x < _grid.GetLength(1); x++)
                {
                    for (int y = 0; y < _grid.GetLength(0); y++)
                    {
                        if (_grid[y, x] > max)
                            max = _grid[y, x];
                    }
                }

                return max;

            }

            public int GetValue(int x, int y)
            {
                return _grid[y, x];
            }

            public int GetAboveValue(int x, int y)
            {
                var adjustedY = y - 1;

                if (adjustedY < 0)
                {
                    return GetValue(x, y);
                }

                return _grid[adjustedY, x];
            }

            public int GetBelowValue(int x, int y)
            {
                var adjustedY = y + 1;

                if (adjustedY > Height)
                {
                    return GetValue(x, y);
                }

                return _grid[adjustedY, x];
            }

            public int GetLeftValue(int x, int y)
            {
                var adjustedX = x - 1;

                if (adjustedX < 0)
                {
                    return GetValue(x, y);
                }

                return _grid[y, adjustedX];
            }

            public int GetRightValue(int x, int y)
            {
                var adjustedX = x + 1;

                if (adjustedX > Width)
                {
                    return GetValue(x, y);
                }

                return _grid[y, adjustedX];
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