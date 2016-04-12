using System;
using System.Collections.Generic;

namespace BowlingKata
{
	public class ScoreCalculator
	{
		private Frame Frame { get; }

	    public ScoreCalculator(IEnumerable<char> line)
		{
            Frame = GetFramesFrom(line);
		}

	    private static Frame GetFramesFrom(IEnumerable<char> line)
		{
		    var rolls = Rolls.From(line);
		    return Frames.From(rolls, 0);
		}

	    public int CalculateScore() => Frame.GetScore();
	}
}

