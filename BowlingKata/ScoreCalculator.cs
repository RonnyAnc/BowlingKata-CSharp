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
            var score = Frame.Score();
            while (Frame.HasNext())
		    {
                Frame = Frame.Next;
                score += Frame.Score();
		    }
		    return score;
		}
	}

    internal class FrameStructureConstructor
    {
        public Frame ConstructFrames(List<Roll> rolls, int index)
        {
            if (index == rolls.Count - 2) return new Frame(rolls[index], rolls[index + 1]);
            if (rolls[index] == Strike) return StrikeFrame(rolls, index);
            return NormalFrame(rolls, index);
        }

        private Frame NormalFrame(List<Roll> rolls, int index)
        {
            var frame = new Frame(rolls[index], rolls[index + 1]);
            frame.Next = ConstructFrames(rolls, index + 2);
            return frame;
        }

        private Frame StrikeFrame(List<Roll> rolls, int index)
        {
            var frame = new Frame(Strike, Zero);
            frame.Next = ConstructFrames(rolls, index + 1);
            return frame;
        }
    }
}

