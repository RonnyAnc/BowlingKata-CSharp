namespace BowlingKata
{
    public class ScoreCalculator
    {
        public static int CalculateScore(string line)
        {
            var rolls = RollsConstructor.Construct(line);
            var score = 0;
            for (var i = 0; i < rolls.Length; i++)
            {
                score += rolls[i].Pins * rolls[i].Multiplier;
            }
            return score;
        }
    }
}