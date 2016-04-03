using System.Collections.Generic;

namespace BowlingKata
{
    internal static class FrameStructureConstructor
    {
        public static Frame ConstructFrames(List<Roll> rolls, int index)
        {
            if (index == rolls.Count - 3 && (rolls[index] == Roll.Strike || rolls[index + 1] == Roll.Spare))
            {
                return new LastFrame(rolls[index], rolls[index + 1], rolls[index + 2]);
            }
            if (index == rolls.Count - 2) return new Frame(rolls[index], rolls[index + 1]);
            if (rolls[index] == Roll.Strike) return StrikeFrame(rolls, index);
            return NormalFrame(rolls, index);
        }

        private static Frame NormalFrame(List<Roll> rolls, int index)
        {
            var frame = new Frame(rolls[index], rolls[index + 1]);
            frame.Next = ConstructFrames(rolls, index + 2);
            return frame;
        }

        private static Frame StrikeFrame(List<Roll> rolls, int index)
        {
            var frame = new Frame(Roll.Strike, Roll.Zero);
            frame.Next = ConstructFrames(rolls, index + 1);
            return frame;
        }
    }
}