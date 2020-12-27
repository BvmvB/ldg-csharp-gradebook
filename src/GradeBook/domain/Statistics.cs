using System;

namespace GradeBook
{
    public class Statistics
    {
        public Statistics()
        {
            GradesSum = 0.0;
            GradesCount = 0;
            LowestGrade = double.MaxValue;
            HighestGrade = double.MinValue;
        }

        public double LowestGrade { get; private set; }
        public double HighestGrade { get; private set; }
        public char LetterGrade { get { return ComputeLetterGrade(AverageGrade); } }
        public double AverageGrade { get { return GradesCount != 0 ? GradesSum / GradesCount : 0; } }

        public void OnGradeAdded(double grade)
        {
            GradesCount += 1;
            GradesSum += grade;

            LowestGrade = Math.Min(LowestGrade, grade);
            HighestGrade = Math.Max(HighestGrade, grade);
        }

        private int GradesCount { get; set; }
        private double GradesSum { get; set; }
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
    }
}