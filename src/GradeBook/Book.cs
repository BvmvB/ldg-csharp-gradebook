using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class Book
    {
        public Book()
        {
            this.grades = new List<double>();
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

            stats.LowestGrade = double.MaxValue;

            foreach (var grade in grades)
            {
                stats.LowestGrade = Math.Min(grade, stats.LowestGrade);
            }

            return stats;

        }

        private List<double> grades;
    }
}