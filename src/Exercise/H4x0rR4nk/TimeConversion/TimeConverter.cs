using System;
using System.Linq;

namespace Exercise.H4x0rR4nk.TimeConversion
{
    // https://www.hackerrank.com/challenges/time-conversion/problem
    public class TimeConverter
    {
        static string timeConversion(string s)
        {
            // DateTime.Parse(s) ... obviously
            var isAnteMeridiem = string.Equals(
                "AM",
                s.Substring(8, 2),
                StringComparison.OrdinalIgnoreCase);

            var time = s.Substring(0, s.Length - 2);
            var timeParts =
                time.Split(':')
                    .Select(v => int.Parse(v))
                    .ToArray();

            var hours = isAnteMeridiem
                ? timeParts[0] % 12
                : timeParts[0] < 12
                    ? timeParts[0] + 12
                    : timeParts[0];

            return string.Format("{0:00}:{1:00}:{2:00}", hours, timeParts[1], timeParts[2]);
        }
    }
}
