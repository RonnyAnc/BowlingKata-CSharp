namespace BowlingKata
{
    public class ScoreCalculator
    {
        public static int CalculateScore(string line)
        {
            var multiplier = 1;
            var score = 0;
            foreach (var roll in line)
            {
                score += ToValue(roll) * multiplier;
            }
            return score;
        }

        private static int ToValue(char roll)
        {
            if (roll == '-') return 0;
            return int.Parse(roll.ToString());
        }
    }
}