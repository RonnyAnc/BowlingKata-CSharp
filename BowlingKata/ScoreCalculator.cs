using System.Collections.Generic;
using System.Linq;
using static BowlingKata.Roll;

namespace BowlingKata
{
	public class ScoreCalculator
	{
		private Frame Frame { get; set; }
	    private FrameStructureConstructor constructor;

	    public ScoreCalculator(char[] line)
		{
            constructor = new FrameStructureConstructor();
            Frame = GetFramesFrom(line);
		}

		private Frame GetFramesFrom(char[] line)
		{
			var rolls = RollsFrom(line);
		    Frame frame = constructor.ConstructFrames(rolls, 0);
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
		    return Frame.GetScore();
		}
	}
}

