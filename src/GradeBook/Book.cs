using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class Book
    {
        public Book(string name)
        {
            this.name = name;
            this.grades = new List<double>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
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

            return stats;
        }

        private string name;
        private List<double> grades;
    }
}