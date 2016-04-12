using System.Linq;
using System.Runtime.Remoting.Messaging;

namespace BowlingKata
{
    public class ScoreCalculator
    {
        public static int CalculateScore(string line)
        {
            var multiplier = 1;
            var score = line.Select((r, index) =>
            {
                var rollScore = ToValue(line, index) * multiplier;
                multiplier = r == '/' ? 2 : 1;
                return rollScore;
            }).Sum();
            return score;
        }

        private static int ToValue(string line, int index)
        {
            if (line[index] == '-') return 0;
            if (line[index] == '/') return 10 - ToValue(line, index - 1);
            if (line[index] == 'X') return 10;
            return int.Parse(line[index].ToString());
        }
    }
}