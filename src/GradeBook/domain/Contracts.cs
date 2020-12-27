using System.Collections.Generic;

namespace GradeBook
{

    public delegate void GradeAddedDelegate(double grade);

    public interface IBook
    {
        string Name { get; }
        List<double> Grades { get; }
        void AddGrade(double grade);
    }
}