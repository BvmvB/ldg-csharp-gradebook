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
    }
}
