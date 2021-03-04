namespace Exercise.H4x0rR4nk.BirthDayCandles
{
    // https://www.hackerrank.com/challenges/birthday-cake-candles/problem
    public class BirthDayCandlator
    {
        static int birthdayCakeCandles(int[] ar)
        {
            var maxHeight = int.MinValue;
            var counter = 0;

            for (var i = 0; i < ar.Length; i++)
            {
                if (ar[i] > maxHeight)
                {
                    maxHeight = ar[i];
                    counter = 1;
                }
                else if (ar[i] == maxHeight)
                {
                    ++counter;
                }
            }

            return counter;
        }
    }
}
