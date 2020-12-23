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
            var book = CreateTestBook(grades: new[] { 1.0 }, bookName);

            Assert.Equal(bookName, book.Name);
        }

        [Fact]
        public void AddGrade_Between_0_and_100_WillSucceed()
        {
            var book = CreateTestBook(grades: new[] { 100.0 });

            book.AddGrade(10.1);

            Assert.Equal(2, book.Grades.Count);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(101)]
        public void AddGrade_LowerThen_0_Or_GreaterThen_100_ShouldNotSucceed(double grade)
        {
            var book = CreateTestBook(grades: new[] { 100.0 });

            book.AddGrade(grade);

            Assert.Single(book.Grades);
        }

        [Fact]
        public void ComputeStatistics_ShouldCompute_LowestGrade()
        {
            var book = CreateTestBook(new[] { 10.5, 55.5, 89.9 });

            var stats = book.ComputeStatistics();

            Assert.Equal(10.5, stats.LowestGrade);
        }

        [Fact]
        public void ComputeStatistics_ShouldCompute_HighestGrade()
        {
            var book = CreateTestBook(new[] { 89.6, 78.5, 50.5 });

            var stats = book.ComputeStatistics();

            Assert.Equal(89.6, stats.HighestGrade);
        }

        [Fact]
        public void ComputeStatistics_ShouldCompute_AverageGrade()
        {
            var book = CreateTestBook(grades: new[] { 50.0, 50.0, 50.0 });

            var stats = book.ComputeStatistics();

            Assert.Equal(50.0, stats.AverageGrade, 1);
        }

        [Theory]
        [InlineData('D', new[] { 60, 65.5, 75.5 })]
        [InlineData('B', new[] { 80.5, 90, 85.0 })]
        [InlineData('C', new[] { 70.0, 70.0, 70.0 })]
        [InlineData('A', new[] { 90.5, 95.5, 100.0 })]
        [InlineData('F', new[] { 20.5, 50.5, 100.0 })]
        public void ComputeStatistics_ShouldCompute_LetterGrade(char letterGrade, double[] grades)
        {
            var book = CreateTestBook(grades);

            var stats = book.ComputeStatistics();

            Assert.Equal(letterGrade, stats.LetterGrade);
        }

        private Book CreateTestBook(double[] grades, string name = "")
        {
            var book = new Book(name);

            foreach (var grade in grades)
            {
                book.AddGrade(grade);
            }

            return book;
        }
    }
}
