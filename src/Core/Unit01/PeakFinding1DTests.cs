using System.Linq;
using FluentAssertions;
using Xunit;

namespace Core.Unit01
{
    public class PeakFinding1DTests
    {
        [Theory]
        [InlineData(PeakFinding1D.AlgoType.Slow)]
        [InlineData(PeakFinding1D.AlgoType.Faster)]
        public void ShouldNotFindPeakGivenNoElements(
            PeakFinding1D.AlgoType algoType)
        {
            var peakFinding1D = new PeakFinding1D(algoType);

            var peek = peakFinding1D.FindPeek(
                new int[0]);

            peek.Should().NotHaveValue();
        }

        [Theory]
        [InlineData(PeakFinding1D.AlgoType.Slow)]
        [InlineData(PeakFinding1D.AlgoType.Faster)]
        public void ShouldReturnNumberGivenSingleItmeInArray(
            PeakFinding1D.AlgoType algoType)
        {
            var peakFinding1D = new PeakFinding1D(algoType);

            var peek = peakFinding1D.FindPeek(
                new int[] { 1 });

            peek.Should().HaveValue();
            peek.Should().Be(1);
        }

        [Theory]
        [InlineData(PeakFinding1D.AlgoType.Slow)]
        [InlineData(PeakFinding1D.AlgoType.Faster)]
        public void ShouldReturnLargerNumberGivenTwoLenghtArray(
            PeakFinding1D.AlgoType algoType)
        {
            var peakFinding1D = new PeakFinding1D(algoType);

            int? peek;

            peek = peakFinding1D.FindPeek(
                new int[] { 1, 2 });

            peek.Should().HaveValue();
            peek.Should().Be(2);

            peek = peakFinding1D.FindPeek(
                new int[] { 2, 1 });

            peek.Should().HaveValue();
            peek.Should().Be(2);
        }

        [Theory]
        [InlineData(PeakFinding1D.AlgoType.Slow)]
        [InlineData(PeakFinding1D.AlgoType.Faster)]
        public void ShouldReturnNumberGivenTwoLengthArrayWithSameValues(
            PeakFinding1D.AlgoType algoType)
        {
            var peakFinding1D = new PeakFinding1D(algoType);

            var peek = peakFinding1D.FindPeek(
                new int[] { 2, 2 });

            peek.Should().HaveValue();
            peek.Should().Be(2);
        }

        [Theory]
        [InlineData(PeakFinding1D.AlgoType.Slow)]
        [InlineData(PeakFinding1D.AlgoType.Faster)]
        public void ShouldFindPeekWhenMiddleIsLargestGiven3LengthArray(
            PeakFinding1D.AlgoType algoType)
        {
            var peakFinding1D = new PeakFinding1D(algoType);

            var peek = peakFinding1D.FindPeek(
                new int[] { 1, 2, 1 });

            peek.Should().HaveValue();
            peek.Should().Be(2);
        }

        [Theory]
        [InlineData(PeakFinding1D.AlgoType.Slow)]
        [InlineData(PeakFinding1D.AlgoType.Faster)]
        public void RandomTest01(
            PeakFinding1D.AlgoType algoType)
        {
            var peakFinding1D = new PeakFinding1D(algoType);

            var peek = peakFinding1D.FindPeek(
                new int[] { 1, 2, 3, 2, 1 });

            peek.Should().HaveValue();
            peek.Should().Be(3);
        }

        [Theory]
        [InlineData(PeakFinding1D.AlgoType.Slow)]
        [InlineData(PeakFinding1D.AlgoType.Faster)]
        public void RandomTest02(
            PeakFinding1D.AlgoType algoType)
        {
            var peakFinding1D = new PeakFinding1D(algoType);

            var peek = peakFinding1D.FindPeek(
                new int[] { 1, 2, 3, 1, 4, 2, 1 });

            peek.Should().HaveValue();

            var validPeeks = new int[] {3, 4};

            validPeeks.Any(v => v == peek.Value).Should().BeTrue();
        }

        [Theory]
        [InlineData(PeakFinding1D.AlgoType.Slow)]
        [InlineData(PeakFinding1D.AlgoType.Faster)]
        public void RandomTest03(
            PeakFinding1D.AlgoType algoType)
        {
            var peakFinding1D = new PeakFinding1D(algoType);

            var peek = peakFinding1D.FindPeek(
                new int[] { 1, 3, 3, 3, 1, 10, 10, 10, 1 });

            peek.Should().HaveValue();

            var validPeeks = new int[] { 3, 10 };

            validPeeks.Any(v => v == peek.Value).Should().BeTrue();
        }

        [Theory]
        [InlineData(PeakFinding1D.AlgoType.Slow)]
        [InlineData(PeakFinding1D.AlgoType.Faster)]
        public void RandomTest04(
            PeakFinding1D.AlgoType algoType)
        {
            var peakFinding1D = new PeakFinding1D(algoType);

            var peek = peakFinding1D.FindPeek(
                new int[] { 10, 0, 0, 1 });

            peek.Should().HaveValue();

            var validPeeks = new int[] { 10, 1 };

            validPeeks.Any(v => v == peek.Value).Should().BeTrue();
        }

        [Theory]
        [InlineData(PeakFinding1D.AlgoType.Slow)]
        [InlineData(PeakFinding1D.AlgoType.Faster)]
        public void RandomTest05(
            PeakFinding1D.AlgoType algoType)
        {
            var peakFinding1D = new PeakFinding1D(algoType);

            var peek = peakFinding1D.FindPeek(
                new int[] { 1, 4, 4, 6, 7, 6, 3, 3, 1 });

            peek.Should().HaveValue();

            var validPeeks = new int[] { 4, 7, 3 };

            validPeeks.Any(v => v == peek.Value).Should().BeTrue();
        }
    }
}