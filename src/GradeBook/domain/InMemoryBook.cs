using System.Collections.Generic;

namespace GradeBook
{
    public class InMemoryBook : IBook
    {
        public InMemoryBook(string name)
        {
            this.Name = name;
            this.Grades = new List<double>();
            this.Statistics = new Statistics();

            this.GradeAdded += Statistics.OnGradeAdded;
        }

        public event GradeAddedDelegate GradeAdded;

        public string Name { get; private set; }
        public List<double> Grades { get; private set; }
        public Statistics Statistics { get; private set; }

        public void AddGrade(double grade)
        {
            if (grade >= 0 && grade <= 100)
            {
                Grades.Add(grade);
                if (GradeAdded != null)
                {
                    GradeAdded(grade);
                }
            }
        }

    }
}