using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercise.H4x0rR4nk.BillDivision
{
    // https://www.hackerrank.com/challenges/bon-appetit/problem
    public class BillDivider
    {
        static void bonAppetit(List<int> bill, int k, int b)
        {
            var annasBill = bill.Sum() - bill[k];
            var split = annasBill / 2;

            if (split == b)
            {
                Console.WriteLine("Bon Appetit");
            }
            else
            {
                Console.WriteLine(b - split);
            }
        }
    }
}
