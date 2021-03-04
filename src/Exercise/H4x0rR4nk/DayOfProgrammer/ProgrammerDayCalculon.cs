namespace Exercise.H4x0rR4nk.DayOfProgrammer
{
    // https://www.hackerrank.com/challenges/day-of-the-programmer/problem
    public class ProgrammerDayCalculon
    {
        static string dayOfProgrammer(int year)
        {
            var isGregorian = year > 1918;
            var isGregorianLeap =
                isGregorian
                && ((year % 4 == 0 && year % 100 != 0) || (year % 400 == 0));

            var isJulian = year < 1918;
            var isJulianLeap =
                isJulian
                && (year % 4 == 0);

            return isGregorianLeap || isJulianLeap
                ? string.Format("12.09.{0}", year)
                : year == 1918
                    ? "26.09.1918"
                    : string.Format("13.09.{0}", year);
        }
    }
}
