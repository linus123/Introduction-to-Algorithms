namespace Core.Unit01
{
    public class PeakFinding1D
    {
        public int? FindPeek(
            int[] numbers)
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
                else if (numbers[i] >= numbers[i - 1] && numbers[i] >= numbers[i + 1])
                    return numbers[i];
            }

            return null;
        }
    }
}