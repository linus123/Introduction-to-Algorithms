using System.Linq;

namespace Core.Unit01
{
    public class PeakFinding1D
    {
        public int? FindPeek(
            int[] numbers)
        {
            if (!numbers.Any())
                return null;

            return numbers[0];
        }
    }
}