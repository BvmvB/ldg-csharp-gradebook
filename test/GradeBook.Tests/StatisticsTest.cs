using Xunit;

namespace GradeBook.Tests
{
    public class StatisticsTest
    {
        [Fact]
        public void NewlyConstructedInstance_LowestGrade_ShouldBeMaxDoubleValue()
        {
            var stats = new Statistics();

            Assert.Equal(double.MaxValue, stats.LowestGrade);
        }

        [Fact]
        public void NewlyConstructedInstance_HighestGrade_ShouldBeMinDoubleValue()
        {
            var stats = new Statistics();

            Assert.Equal(double.MinValue, stats.HighestGrade);
        }

        [Fact]
        public void NewlyConstructedInstance_AverageGrade_ShouldBeZero()
        {
            var stats = new Statistics();

            Assert.Equal(0, stats.AverageGrade);
        }

        [Fact]
        public void NewlyConstructedInstance_LetterGrade_ShouldBeF()
        {
            var stats = new Statistics();

            Assert.Equal('F', stats.LetterGrade);
        }

        [Fact]
        public void OnGradeAdded_ShouldCompute_LowestGrade()
        {
            var stats = new Statistics();

            stats.OnGradeAdded(100);
            stats.OnGradeAdded(88.9);

            Assert.Equal(88.9, stats.LowestGrade, 1);
        }

        [Fact]
        public void OnGradeAdded_ShouldCompute_HighestGrade()
        {
            var stats = new Statistics();

            stats.OnGradeAdded(100);
            stats.OnGradeAdded(88.9);

            Assert.Equal(100, stats.HighestGrade, 1);
        }

        [Fact]
        public void OnGradeAdded_ShouldCompute_AverageGrade()
        {
            var stats = new Statistics();

            stats.OnGradeAdded(50);
            stats.OnGradeAdded(50);
            stats.OnGradeAdded(50);

            Assert.Equal(50, stats.AverageGrade);
        }

        [Fact]
        public void OnGradeAdded_ShouldCompute_LetterGrade()
        {
            var stats = new Statistics();

            stats.OnGradeAdded(100);
            stats.OnGradeAdded(99.5);
            stats.OnGradeAdded(89.9);

            Assert.Equal('A', stats.LetterGrade);
        }
    }
}