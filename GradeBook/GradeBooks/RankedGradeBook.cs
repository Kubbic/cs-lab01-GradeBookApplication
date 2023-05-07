using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
	public class RankedGradeBook : BaseGradeBook
	{
		public RankedGradeBook(string name, bool isWeighted) : base(name, isWeighted)
		{
			Type = GradeBookType.Ranked;
			IsWeighted = isWeighted;
		}

		public override char GetLetterGrade(double averageGrade)
		{
			if (Students.Count < 5)
			{
				throw new InvalidOperationException();
			}

			var countHigherGrades = Students.Count(student => student.Grades.Average() >= averageGrade);
			var percentile = (double)countHigherGrades / Students.Count;

			if (percentile <= 0.2)
				return 'A';
			if (percentile <= 0.4)
				return 'B';
			if (percentile <= 0.6)
				return 'C';
			return percentile <= 0.8 ? 'D' : 'F';
		}

		public override void CalculateStatistics()
		{
			if (Students.Count >= 5)
			{
				base.CalculateStatistics();
			}
			else
			{
				Console.WriteLine("Ranked grading requires at least 5 students.");
			}
		}

		public override void CalculateStudentStatistics(string name)
		{
			if (Students.Count >= 5)
			{
				base.CalculateStudentStatistics(name);
			}
			else
			{
				Console.WriteLine("Ranked grading requires at least 5 students.");
			}
		}
	}
}
