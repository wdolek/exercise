using System.Collections.Generic;

namespace Exercise.H4x0rR4nk.CompareTriplets
{
    // https://www.hackerrank.com/challenges/compare-the-triplets/problem
    public class TripletComparator
    {
        static List<int> compareTriplets(List<int> a, List<int> b)
        {
            var result = new List<int>() { 0, 0 };

            for (var i = 0; i < a.Count; i++)
            {
                if (a[i] > b[i])
                {
                    result[0] += 1;
                }
                else if (a[i] < b[i])
                {
                    result[1] += 1;
                }
            }

            return result;
        }
    }
}
