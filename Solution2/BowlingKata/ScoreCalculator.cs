using System.Collections.Generic;

namespace BowlingKata
{
    public class ScoreCalculator
    {
        public static int CalculateScore(string line)
        {
            var constructor = RollsConstructor.Construct(line);
            return 0;
        }
    }

    public class RollsConstructor
    {
        public static List<Rolls> Construct(string line)
        {
            throw new System.NotImplementedException();
        }
    }

    public class Rolls
    {
        public int Pins { get; set; }
        public int Multiplier { get; set; }
    }
}