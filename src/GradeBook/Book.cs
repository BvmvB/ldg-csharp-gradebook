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

        private List<double> grades;
    }
}