using System;

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

        private int? FindPeekFast(int[] numbers)
        {
            if (numbers.Length == 0)
                return null;

            if (numbers.Length == 1)
                return numbers[0];

            if (numbers.Length == 2)
            {
                if (numbers[0] >= numbers[1])
                    return numbers[0];

                return numbers[1];
            }

            var middleIndex = numbers.Length / 2;

            if (numbers[middleIndex] >= numbers[middleIndex - 1]
                && numbers[middleIndex] >= numbers[middleIndex + 1])
            {
                return numbers[middleIndex];
            }

            if (numbers[middleIndex] <= numbers[middleIndex - 1])
            {
                var leftArray = SubArray(numbers, 0, middleIndex);

                return FindPeekFast(leftArray);
            }

            if (numbers[middleIndex] <= numbers[middleIndex + 1])
            {
                var rightArray = SubArray(numbers, middleIndex + 1, numbers.Length - middleIndex - 1);

                return FindPeekFast(rightArray);
            }

            return null;
        }

        private int[] SubArray(int[] data, int index, int length)
        {
            int[] result = new int[length];
            Array.Copy(data, index, result, 0, length);
            return result;
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