using System.Linq;

namespace Exercise.H4x0rR4nk.ClimbingLeaderboard
{
    // https://www.hackerrank.com/challenges/climbing-the-leaderboard/problem
    public class LeaderboardClimber
    {
        // -> https://www.hackerrank.com/challenges/climbing-the-leaderboard/forum/comments/350600
        static int[] climbingLeaderboard(int[] scores, int[] alice)
        {
            var distinctScores = scores.Distinct().ToArray();

            var last = distinctScores.Length - 1;
            var res = new int[alice.Length];

            for (var i = 0; i < alice.Length; i++)
            {
                var score = alice[i];
                while (last >= 0)
                {
                    if (score >= distinctScores[last])
                    {
                        --last;
                    }
                    else
                    {
                        res[i] = last + 2;
                        break;
                    }
                }

                if (last < 0)
                {
                    res[i] = 1;
                }
            }

            return res;
        }
    }
}
