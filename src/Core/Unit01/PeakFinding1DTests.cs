using FluentAssertions;
using Xunit;

namespace Core.Unit01
{
    public class PeakFinding1DTests
    {
        [Fact]
        public void ShouldNotFindPeakGivenNoElements()
        {
            var peakFinding1D = new PeakFinding1D();

            var peek = peakFinding1D.FindPeek(
                new int[0]);

            peek.Should().NotHaveValue();
        }

        [Fact]
        public void ShouldReturnNumberGivenSingleItmeInArray()
        {
            var peakFinding1D = new PeakFinding1D();

            var peek = peakFinding1D.FindPeek(
                new int[] { 1 });

            peek.Should().HaveValue();
            peek.Should().Be(1);
        }

    }
}