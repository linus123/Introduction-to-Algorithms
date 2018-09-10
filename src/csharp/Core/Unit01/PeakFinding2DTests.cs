using System;
using FluentAssertions;
using Xunit;

namespace Core.Unit01
{
    public class PeakFinding2DTests
    {
        [Fact]
        public void ArrayGetLength()
        {
            var grid = new int[1, 2];

            grid.GetLength(0).Should().Be(1);
            grid.GetLength(1).Should().Be(2);
        }

        [Theory(DisplayName = "Should return only value given 1 x 1 grid.")]
        [InlineData(PeakFinding2D.AlgoType.BruteForce)]
        [InlineData(PeakFinding2D.AlgoType.Algoritim1)]
        public void Test001(
            PeakFinding2D.AlgoType algoType)
        {
            var random = new Random();
            var val = random.Next();

            var peakFinding2D = new PeakFinding2D(algoType);

            var peak = peakFinding2D.FindPeek(new int[,]
            {
                { val }
            });

            peak.Should().Be(val);
        }

        [Theory(DisplayName = "Should return only value given 2 x 1 and 1 x 2 grid.")]
        [InlineData(PeakFinding2D.AlgoType.BruteForce)]
        [InlineData(PeakFinding2D.AlgoType.Algoritim1)]
        public void Test002(
            PeakFinding2D.AlgoType algoType)
        {
            var random = new Random();
            var val = random.Next();

            var peakFinding2D = new PeakFinding2D(algoType);

            int peak = 0;

            peak = peakFinding2D.FindPeek(new int[,]
            {
                { val, val }
            });
            
            peak.Should().Be(val);

            peak = peakFinding2D.FindPeek(new int[,]
            {
                { val },
                { val }
            });

            peak.Should().Be(val);
        }

        [Theory(DisplayName = "Should return larger value given 2 x 1 and 1 x 2 grid.")]
        [InlineData(PeakFinding2D.AlgoType.BruteForce)]
        [InlineData(PeakFinding2D.AlgoType.Algoritim1)]
        public void Test003(
            PeakFinding2D.AlgoType algoType)
        {
            var peakFinding2D = new PeakFinding2D(algoType);

            int peak = 0;

            peak = peakFinding2D.FindPeek(new int[,]
            {
                { 0, 1 }
            });
            peak.Should().Be(1);

            peak = peakFinding2D.FindPeek(new int[,]
            {
                { 1, 0 }
            });
            peak.Should().Be(1);

            peak = peakFinding2D.FindPeek(new int[,]
            {
                { 0 },
                { 1 }
            });
            peak.Should().Be(1);

            peak = peakFinding2D.FindPeek(new int[,]
            {
                { 1 },
                { 0 }
            });
            peak.Should().Be(1);
        }

        [Theory(DisplayName = "Should return only value given 2 x 2 grid with all the same value.")]
        [InlineData(PeakFinding2D.AlgoType.BruteForce)]
        [InlineData(PeakFinding2D.AlgoType.Algoritim1)]
        public void Test010(
            PeakFinding2D.AlgoType algoType)
        {
            var random = new Random();
            var val = random.Next();

            var peakFinding2D = new PeakFinding2D(algoType);

            var peak = peakFinding2D.FindPeek(new int[,]
            {
                { val, val },
                { val, val }
            });

            peak.Should().Be(val);
        }

        [Theory(DisplayName = "Should return only value given 3 x 3 grid with all the same values.")]
        [InlineData(PeakFinding2D.AlgoType.BruteForce)]
        [InlineData(PeakFinding2D.AlgoType.Algoritim1)]
        public void Test012(
            PeakFinding2D.AlgoType algoType)
        {
            var random = new Random();
            var val = random.Next();

            var peakFinding2D = new PeakFinding2D(algoType);

            var peak = peakFinding2D.FindPeek(new int[,]
            {
                { val, val, val },
                { val, val, val },
                { val, val, val }
            });

            peak.Should().Be(val);
        }

        [Theory(DisplayName = "Should find peak when in center of 3 x 3 grid.")]
        [InlineData(PeakFinding2D.AlgoType.BruteForce)]
        [InlineData(PeakFinding2D.AlgoType.Algoritim1)]
        public void Test013(
            PeakFinding2D.AlgoType algoType)
        {
            var peakFinding2D = new PeakFinding2D(algoType);

            var peak = peakFinding2D.FindPeek(new int[,]
            {
                { 0, 1, 0 },
                { 1, 2, 1 },
                { 0, 1, 0 }
            });

            peak.Should().Be(2);
        }

        [Theory(DisplayName = "Should find peak when in x = 0, y = 0 of 3 x 3 grid.")]
        [InlineData(PeakFinding2D.AlgoType.BruteForce)]
        [InlineData(PeakFinding2D.AlgoType.Algoritim1)]
        public void Test014(
            PeakFinding2D.AlgoType algoType)
        {
            var peakFinding2D = new PeakFinding2D(algoType);

            var peak = peakFinding2D.FindPeek(new int[,]
            {
                { 4, 3, 1 },
                { 3, 2, 1 },
                { 1, 1, 0 }
            });

            peak.Should().Be(4);
        }

        [Theory(DisplayName = "Should find peak when in x = 1, y = 0 of 3 x 3 grid.")]
        [InlineData(PeakFinding2D.AlgoType.BruteForce)]
        [InlineData(PeakFinding2D.AlgoType.Algoritim1)]
        public void Test015(
            PeakFinding2D.AlgoType algoType)
        {
            var peakFinding2D = new PeakFinding2D(algoType);

            var peak = peakFinding2D.FindPeek(new int[,]
            {
                { 3, 4, 1 },
                { 3, 2, 1 },
                { 1, 1, 0 }
            });

            peak.Should().Be(4);
        }

        [Theory(DisplayName = "Should find peak when in x = 2, y = 0 of 3 x 3 grid.")]
        [InlineData(PeakFinding2D.AlgoType.BruteForce)]
        [InlineData(PeakFinding2D.AlgoType.Algoritim1)]
        public void Test016(
            PeakFinding2D.AlgoType algoType)
        {
            var peakFinding2D = new PeakFinding2D(algoType);

            var peak = peakFinding2D.FindPeek(new int[,]
            {
                { 1, 3, 4 },
                { 1, 2, 3 },
                { 0, 1, 1 }
            });

            peak.Should().Be(4);
        }

        [Theory(DisplayName = "Should find peak when in x = 2, y = 0 of 3 x 3 grid.")]
        [InlineData(PeakFinding2D.AlgoType.BruteForce)]
        [InlineData(PeakFinding2D.AlgoType.Algoritim1)]
        public void Test017(
            PeakFinding2D.AlgoType algoType)
        {
            var peakFinding2D = new PeakFinding2D(algoType);

            var peak = peakFinding2D.FindPeek(new int[,]
            {
                { 0, 1, 1 },
                { 1, 2, 3 },
                { 1, 3, 4 },
            });

            peak.Should().Be(4);
        }

        [Theory(DisplayName = "Should find peak when in x = 2, y = 0 of 3 x 3 grid.")]
        [InlineData(PeakFinding2D.AlgoType.BruteForce)]
        [InlineData(PeakFinding2D.AlgoType.Algoritim1)]
        public void Test018(
            PeakFinding2D.AlgoType algoType)
        {
            var peakFinding2D = new PeakFinding2D(algoType);

            var peak = peakFinding2D.FindPeek(new int[,]
            {
                { 4, 5, 6, 7, 8, 7, 6, 5, 4, 3, 2 },
                { 5, 6, 7, 8, 9, 8, 7, 6, 5, 4, 3 },
                { 6, 7, 8, 9, 10, 9, 8, 7, 6, 5, 4 },
                { 7, 8, 9, 10, 11, 10, 9, 8, 7, 6, 5 },
                { 8, 9, 10, 11, 12, 11, 10, 9, 8, 7, 6 },
                { 7, 8, 9, 10, 11, 10, 9, 8, 7, 6, 5 },
                { 6, 7, 8, 9, 10, 9, 8, 7, 6, 5, 4 },
                { 5, 6, 7, 8, 9, 8, 7, 6, 5, 4, 3 },
                { 4, 5, 6, 7, 8, 7, 6, 5, 4, 3, 2 },
                { 3, 4, 5, 6, 7, 6, 5, 4, 3, 2, 1 },
                { 2, 3, 4, 5, 6, 5, 4, 3, 2, 1, 0 },
            });

            peak.Should().Be(12);
        }

    }
}