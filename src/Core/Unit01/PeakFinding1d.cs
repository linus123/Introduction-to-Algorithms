namespace Core.Unit01
{
    public class PeakFinding1D
    {
        private AlgoType _algoType;

        public enum AlgoType
        {
            Slow,
            Faster
        }

        public PeakFinding1D(
            AlgoType algoType)
        {
            _algoType = algoType;
        }

        public int? FindPeek(
            int[] numbers)
        {
            if (_algoType == AlgoType.Slow)
                return FindPeekSlow(numbers);

            return FindPeekFast(numbers);
        }

        private static int? FindPeekFast(int[] numbers)
        {
            if (numbers.Length == 1)
                return numbers[0];

            for (int i = 0; i < numbers.Length; i++)
            {
                if (i == 0)
                {
                    if (numbers[0] >= numbers[1])
                        return numbers[0];
                }
                else if (i == (numbers.Length - 1))
                {
                    if (numbers[i] >= numbers[i - 1])
                        return numbers[i];
                }
                else if (numbers[i] >= numbers[i - 1]
                         && numbers[i] >= numbers[i + 1])
                {
                    return numbers[i];
                }
            }

            return null;
        }


        private static int? FindPeekSlow(int[] numbers)
        {
            if (numbers.Length == 1)
                return numbers[0];

            for (int i = 0; i < numbers.Length; i++)
            {
                if (i == 0)
                {
                    if (numbers[0] >= numbers[1])
                        return numbers[0];
                }
                else if (i == (numbers.Length - 1))
                {
                    if (numbers[i] >= numbers[i - 1])
                        return numbers[i];
                }
                else if (numbers[i] >= numbers[i - 1]
                         && numbers[i] >= numbers[i + 1])
                {
                    return numbers[i];
                }
            }

            return null;
        }
    }
}