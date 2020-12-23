using System;
using Xunit;

namespace GradeBook.Tests
{
    public class BookTest
    {
        [Fact]
        public void AddGrade_Between_0_and_100_WillSucceed()
        {
            var book = new Book();

            book.AddGrade(10.1);

            Assert.Equal(1, book.Grades.Count);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(101)]
        public void AddGrade_LowerThen_0_Or_GreaterThen_100_ShouldNotSucceed(double grade)
        {
            var book = new Book();

            book.AddGrade(grade);

            Assert.Equal(0, book.Grades.Count);
        }
    }
}
