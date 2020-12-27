using System;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new InMemoryBook("John Doe's CS grade book");

            while (true)
            {
                var input = ReadInput();
                if (input == "q")
                {
                    break;
                }

                var grade = double.Parse(input);
                book.AddGrade(grade);
            }

            var stats = book.Statistics;

            Console.WriteLine($"\nLetter grade for '{book.Name}' is {stats.LetterGrade}");
        }

        private static string ReadInput()
        {
            Console.Write("Enter a grade between 0 - 100 (q to quit): ");
            return Console.ReadLine();
        }
    }
}
