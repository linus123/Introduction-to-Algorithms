using System.Linq;
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

        [Fact]
        public void ShouldReturnLargerNumberGivenTwoLenghtArray()
        {
            var peakFinding1D = new PeakFinding1D();

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

        [Fact]
        public void ShouldReturnNumberGivenTwoLengthArrayWithSameValues()
        {
            var peakFinding1D = new PeakFinding1D();

            var peek = peakFinding1D.FindPeek(
                new int[] { 2, 2 });

            peek.Should().HaveValue();
            peek.Should().Be(2);
        }

        [Fact]
        public void ShouldFindPeekWhenMiddleIsLargestGiven3LengthArray()
        {
            var peakFinding1D = new PeakFinding1D();

            var peek = peakFinding1D.FindPeek(
                new int[] { 1, 2, 1 });

            peek.Should().HaveValue();
            peek.Should().Be(2);
        }

        [Fact]
        public void RandomTest01()
        {
            var peakFinding1D = new PeakFinding1D();

            var peek = peakFinding1D.FindPeek(
                new int[] { 1, 2, 3, 2, 1 });

            peek.Should().HaveValue();
            peek.Should().Be(3);
        }

        [Fact]
        public void RandomTest02()
        {
            var peakFinding1D = new PeakFinding1D();

            var peek = peakFinding1D.FindPeek(
                new int[] { 1, 2, 3, 1, 4, 2, 1 });

            peek.Should().HaveValue();

            var validPeeks = new int[] {3, 4};

            validPeeks.Any(v => v == peek.Value).Should().BeTrue();
        }

        [Fact]
        public void RandomTest03()
        {
            var peakFinding1D = new PeakFinding1D();

            var peek = peakFinding1D.FindPeek(
                new int[] { 1, 3, 3, 3, 1, 10, 10, 10, 1 });

            peek.Should().HaveValue();

            var validPeeks = new int[] { 3, 10 };

            validPeeks.Any(v => v == peek.Value).Should().BeTrue();
        }

        [Fact]
        public void RandomTest04()
        {
            var peakFinding1D = new PeakFinding1D();

            var peek = peakFinding1D.FindPeek(
                new int[] { 10, 0, 0, 1 });

            peek.Should().HaveValue();

            var validPeeks = new int[] { 10, 1 };

            validPeeks.Any(v => v == peek.Value).Should().BeTrue();
        }

        [Fact]
        public void RandomTest05()
        {
            var peakFinding1D = new PeakFinding1D();

            var peek = peakFinding1D.FindPeek(
                new int[] { 1, 4, 4, 6, 7, 6, 3, 3, 1 });

            peek.Should().HaveValue();

            var validPeeks = new int[] { 4, 7, 3 };

            validPeeks.Any(v => v == peek.Value).Should().BeTrue();
        }
    }
}