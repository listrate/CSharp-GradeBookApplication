using System;
using System.Collections.Generic;
using System.Linq;
using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade) 
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException("Ranked-Grading requires a minimum of 5 students to work");
            }

            int threshold = (int)Math.Ceiling(Students.Count * 0.2);
            
            var grades = Students.Select(s => s.AverageGrade).OrderByDescending(s => s).ToList();

            //if the average grade of 20% of the class is higher than averageGrade - return A
            if (grades[threshold - 1] <= averageGrade)
            {
                return 'A';
            } 
            else if (grades[(threshold * 2) - 1] <= averageGrade)
            {
                return 'B';
            } 
            else if (grades[(threshold * 3) - 1] <= averageGrade)
            {
                return 'C';
            } 
            else if (grades[(threshold * 4) - 1] <= averageGrade)
            {
                return 'D';
            } 
            else 
            {
                return 'F';
            }
        }
    }
}