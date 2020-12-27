using System;

namespace GradeBook
{
    public class Statistics
    {
        public Statistics()
        {
            GradesSum = 0.0;
            GradesCount = 0;
            AverageGrade = 0;
            LowestGrade = double.MaxValue;
            HighestGrade = double.MinValue;
            LetterGrade = ComputeLetterGrade(AverageGrade);
        }

        public char LetterGrade { get; private set; }
        public double LowestGrade { get; private set; }
        public double HighestGrade { get; private set; }
        public double AverageGrade { get; private set; }

        public void OnGradeAdded(double grade)
        {
            GradesCount += 1;
            GradesSum += grade;

            AverageGrade = GradesSum / GradesCount;
            LowestGrade = Math.Min(LowestGrade, grade);
            HighestGrade = Math.Max(HighestGrade, grade);
            LetterGrade = ComputeLetterGrade(AverageGrade);
        }




        private char ComputeLetterGrade(double averageGrade)
        {
            switch (averageGrade)
            {
                case var d when d >= 90:
                    return 'A';
                case var d when d >= 80:
                    return 'B';
                case var d when d >= 70:
                    return 'C';
                case var d when d >= 60:
                    return 'D';
                default:
                    return 'F';
            }
        }
        private int GradesCount { get; set; }
        private double GradesSum { get; set; }
    }
}