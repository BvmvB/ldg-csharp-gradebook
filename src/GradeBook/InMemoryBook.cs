using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class InMemoryBook : IBook
    {
        public InMemoryBook(string name)
        {
            this.Name = name;
            this.grades = new List<double>();
        }

        public string Name
        {
            get;
            private set;

        }
        public List<double> Grades
        {
            get
            {
                return grades;
            }
        }

        public void AddGrade(double grade)
        {
            if (grade >= 0 && grade <= 100)
            {
                grades.Add(grade);
            }
        }

        public Statistics ComputeStatistics()
        {
            var stats = new Statistics();

            var sum = 0.0;
            stats.LowestGrade = double.MaxValue;
            stats.HighestGrade = double.MinValue;

            foreach (var grade in grades)
            {
                sum += grade;
                stats.LowestGrade = Math.Min(grade, stats.LowestGrade);
                stats.HighestGrade = Math.Max(grade, stats.HighestGrade);
            }

            stats.AverageGrade = sum / grades.Count;
            stats.LetterGrade = ComputeLetterGrade(stats.AverageGrade);

            return stats;
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

        private List<double> grades;
    }
}