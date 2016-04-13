using System.Linq;

namespace BowlingKata
{
    public class ScoreCalculator
    {
        public static int CalculateScore(string line)
        {
            var rolls = RollsConstructor.Construct(line);
            return rolls.Sum(r => r.Pins * r.Multiplier);
        }
    }
}