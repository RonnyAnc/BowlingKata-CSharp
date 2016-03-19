using System.Collections.Generic;
using System.Linq;

namespace BowlingKata
{
	public class ScoreCalculator
	{
		private Frame Frame { get; }

		public ScoreCalculator(char[] line)
		{
			Frame = GetFramesFrom(line);
		}

		private Frame GetFramesFrom(char[] line)
		{
			var rolls = RollsFrom(line);
			return new Frame(rolls[0], rolls[1]);
		}

		private List<Roll> RollsFrom(char[] line)
		{
			return line.Map(ToRoll).ToList();
		}

		private Roll ToRoll(char character)
		{
			if (character == '-') return Roll.Zero;
			if (character == '/') return Roll.Spare;
			if (character == 'X') return Roll.Strike;
			return (Roll) int.Parse(character.ToString());
		}

		public int CalculateScore()
		{
			return Frame.Score();
		}
	}
}

