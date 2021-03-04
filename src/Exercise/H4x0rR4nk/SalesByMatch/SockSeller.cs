using System.Collections.Generic;

namespace Exercise.H4x0rR4nk.SalesByMatch
{
    // https://www.hackerrank.com/challenges/sock-merchant/problem
    public class SockSeller
    {
        static int sockMerchant(int n, int[] ar)
        {
            var sockCounts = new Dictionary<int, int>(n);
            for (var i = 0; i < ar.Length; i++)
            {
                var sockColor = ar[i];
                if (!sockCounts.ContainsKey(sockColor))
                {
                    sockCounts[sockColor] = 0;
                }
                ++sockCounts[sockColor];
            }

            var pairs = 0;
            foreach (var kvp in sockCounts)
            {
                pairs += kvp.Value / 2;
            }

            return pairs;
        }
    }
}
