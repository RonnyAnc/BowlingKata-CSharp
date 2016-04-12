using System.Linq;
using System.Runtime.Remoting.Messaging;

namespace BowlingKata
{
    public class ScoreCalculator
    {
        public static int CalculateScore(string line)
        {
            var multiplier = new Multiplier();
            var score = line.Select((roll, index) =>
            {
                var rollScore = multiplier.Apply(ToValue(line, index));
                multiplier = GetNextMultiplierFor(roll);
                return rollScore;
            }).Sum();
            return score;
        }

        private static Multiplier GetNextMultiplierFor(char roll)
        {
            return roll == '/' ? new Multiplier(2) : new Multiplier();
        }

        private static int ToValue(string line, int index)
        {
            if (line[index] == '-') return 0;
            if (line[index] == '/') return 10 - ToValue(line, index - 1);
            if (line[index] == 'X') return 10;
            return int.Parse(line[index].ToString());
        }
    }

    public class Multiplier
    {
        public int Value { get; }
        public int Charge { get; private set; }

        public Multiplier(int value = 1, int charge = 1)
        {
            Value = value;
            Charge = charge;
        }

        public int Apply(int value)
        {
            Charge -= 1;
            return value * Value;
        }
    }
}