using System.Collections.Generic;
using System.Linq;

namespace BowlingKata
{
	public class ScoreCalculator
	{
		private Frame Frame { get; set; }

	    public ScoreCalculator(char[] line)
		{
			Frame = GetFramesFrom(line);
		}

		private Frame GetFramesFrom(char[] line)
		{
			var rolls = RollsFrom(line);
		    Frame frame;
		    if (rolls[0] == Roll.Strike)
		    {
		        frame = new Frame(Roll.Strike, Roll.Zero);
                frame.Next = new Frame(rolls[1], rolls[2]);
            }
			else
		    {
		        frame = new Frame(rolls[0], rolls[1]);
                frame.Next = new Frame(rolls[2], rolls[3]);
            }
            
		    return frame;
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
            var score = Frame.Score();
            while (Frame.HasNext())
		    {
                Frame = Frame.Next;
                score += Frame.Score();
		    }
		    return score;
		}
	}
}

