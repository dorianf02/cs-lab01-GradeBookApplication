
using GradeBook.Enums;
using System;
using System.Linq;
using System.Runtime.CompilerServices;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool isWeighted) : base(name, isWeighted)
        {
            Type = GradeBookType.Ranked;
        }
        public override char GetLetterGrade(double avgGrade)
        {
            if (Students.Count < 5)
                throw new InvalidOperationException("Less than 5 students");
            var scale = (int)Math.Ceiling(Students.Count * 0.2);
            var grades = Students.OrderByDescending(e => e.AverageGrade).Select(e => e.AverageGrade).ToList();

            if (grades[scale - 1] <= avgGrade)
                return 'A';
            else if (grades[(scale * 2) - 1] <= avgGrade)
                return 'B';
            else if (grades[(scale * 3) - 1] <= avgGrade)
                return 'C';
            else if (grades[(scale * 4) - 1] <= avgGrade)
                return 'D';
            else
                return 'F';
        }
        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students");
                return;
            }
            base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {
            if(Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students");
                return;
            }
            base.CalculateStudentStatistics(name);
        }


    }
}
