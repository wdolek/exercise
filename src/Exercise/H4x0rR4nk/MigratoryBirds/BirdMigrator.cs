using System.Collections.Generic;
using System.Linq;

namespace Exercise.H4x0rR4nk.MigratoryBirds
{
    // https://www.hackerrank.com/challenges/migratory-birds/problem
    public class BirdMigrator
    {
        static int migratoryBirds(List<int> arr)
        {
            var c = new int[5];
            for (var i = 0; i < arr.Count; i++)
            {
                ++c[arr[i] - 1];
            }

            return c.Select((v, i) => new { TypeId = i + 1, Count = v })
                .OrderByDescending(t => t.Count)
                .ThenBy(t => t.TypeId)
                .First()
                .TypeId;
        }
    }
}
