using System;
using Xunit;

namespace GradeBook.Tests
{
    public class BookTest
    {
        [Fact]
        public void Book_ShouldRequireAName()
        {
            var bookName = "John Doe's computer science book";
            var book = CreateTestBook(bookName);

            Assert.Equal(bookName, book.Name);
        }

        [Fact]
        public void AddGrade_Between_0_and_100_WillSucceed()
        {
            var book = CreateTestBook();

            book.AddGrade(10.1);

            Assert.Equal(4, book.Grades.Count);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(101)]
        public void AddGrade_LowerThen_0_Or_GreaterThen_100_ShouldNotSucceed(double grade)
        {
            var book = CreateTestBook();

            book.AddGrade(grade);

            Assert.Equal(3, book.Grades.Count);
        }

        [Fact]
        public void ComputeStatistics_ShouldCompute_LowestGrade()
        {
            var book = CreateTestBook();

            var stats = book.ComputeStatistics();

            Assert.Equal(10.5, stats.LowestGrade);
        }

        [Fact]
        public void ComputeStatistics_ShouldCompute_HighestGrade()
        {
            var book = CreateTestBook();

            var stats = book.ComputeStatistics();

            Assert.Equal(89.6, stats.HighestGrade);
        }

        [Fact]
        public void ComputeStatistics_ShouldCompute_AverageGrade()
        {
            var book = CreateTestBook();

            var stats = book.ComputeStatistics();

            Assert.Equal(53.6, stats.AverageGrade, 1);
        }

        private Book CreateTestBook(string name = "")
        {
            var book = new Book(name);

            book.AddGrade(10.5);
            book.AddGrade(60.7);
            book.AddGrade(89.6);

            return book;
        }
    }
}
