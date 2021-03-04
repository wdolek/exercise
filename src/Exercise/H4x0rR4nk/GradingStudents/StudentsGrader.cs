using System.Collections.Generic;

namespace Exercise.H4x0rR4nk.GradingStudents
{
    // https://www.hackerrank.com/challenges/grading/problem
    public class StudentsGrader
    {
        public static List<int> gradingStudents(List<int> grades)
        {
            var result = new List<int>();
            foreach (var grade in grades)
            {
                if (grade < 38)
                {
                    result.Add(grade);
                    continue;
                }

                var roundUp = ((grade / 5) + 1) * 5;
                if (roundUp - grade < 3)
                {
                    result.Add(roundUp);
                }
                else
                {
                    result.Add(grade);
                }
            }

            return result;
        }
    }
}
