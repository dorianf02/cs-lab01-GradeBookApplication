﻿
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
        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
                throw new InvalidOperationException("Ranked grading requires at least 5 students");
            var scale = (int)Math.Ceiling(Students.Count * 0.2);
            var grades = Students.OrderByDescending(e => e.AverageGrade).Select(e => e.AverageGrade).ToList();

            if (grades[scale - 1] <= averageGrade)
                return 'A';
            else if (grades[(scale * 2) - 1] <= averageGrade)
                return 'B';
            else if (grades[(scale * 3) - 1] <= averageGrade)
                return 'C';
            else if (grades[(scale * 4) - 1] <= averageGrade)
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
