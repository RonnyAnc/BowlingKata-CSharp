using System.Collections.Generic;
using System.Linq;
using static BowlingKata.Roll;

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
		    Frame frame = fooFrames(rolls, 0);
		    return frame;
		    if (rolls[0] == Strike)
		    {
		        frame = new Frame(Strike, Zero);
                frame.Next = new Frame(rolls[1], rolls[2]);
            }
			else
		    {
		        frame = new Frame(rolls[0], rolls[1]);
		        if (rolls[2] == Strike)
		        {
		            frame.Next = new Frame(Strike, Zero);
		            frame.Next.Next = new Frame(rolls[3], rolls[4]);
		        }
		        else
		        {
                    frame.Next = new Frame(rolls[2], rolls[3]);
                    frame.Next.Next = new Frame(rolls[4], rolls[5]);
                }
            }
            
		    return frame;
		}

	    private Frame fooFrames(List<Roll> rolls, int index)
	    {
	        if (index == rolls.Count - 2) return new Frame(rolls[index], rolls[index + 1]);
            if (rolls[index] == Strike) return StrikeFrame(rolls, index);
            return NormalFrame(rolls, index);
        }

	    private Frame NormalFrame(List<Roll> rolls, int index)
	    {
	        var frame = new Frame(rolls[index], rolls[index + 1]);
	        frame.Next = fooFrames(rolls, index + 2);
	        return frame;
	    }

	    private Frame StrikeFrame(List<Roll> rolls, int index)
	    {
	        var frame = new Frame(Strike, Zero);
	        frame.Next = fooFrames(rolls, index + 1);
	        return frame;
	    }

	    private List<Roll> RollsFrom(char[] line)
		{
			return line.Map(ToRoll).ToList();
		}

		private Roll ToRoll(char character)
		{
			if (character == '-') return Zero;
			if (character == '/') return Spare;
			if (character == 'X') return Strike;
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

