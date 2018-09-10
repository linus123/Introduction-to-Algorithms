namespace Core.Unit01
{
    public class Grid
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

        public int GetAboveValue(int x, int y)
        {
            var adjustedY = y - 1;

            if (adjustedY < 0)
            {
                return GetValue(x, y);
            }

            return GetValue(x, adjustedY);
        }

        public int GetBelowValue(int x, int y)
        {
            var adjustedY = y + 1;

            if (adjustedY >= Height)
            {
                return GetValue(x, y);
            }

            return GetValue(x, adjustedY);
        }

        public int GetLeftValue(int x, int y)
        {
            var adjustedX = x - 1;

            if (adjustedX < 0)
            {
                return GetValue(x, y);
            }

            return GetValue(adjustedX, y);
        }

        public int GetRightValue(int x, int y)
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

        public int[,] GetSubArray(
            int startX, int startY,
            int countX, int countY)
        {
            var subGrid = new int[countY, countX];

            for (int x = 0; x < countX; x++)
            {
                for (int y = 0; y < countY; y++)
                {
                    subGrid[y, x] = GetValue(x + startX, y + startY);
                }
            }

            return subGrid;
        }
    }
}