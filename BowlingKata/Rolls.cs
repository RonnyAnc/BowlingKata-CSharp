using System.Collections.Generic;
using System.Linq;

namespace BowlingKata
{
    internal static class Rolls
    {
        internal static List<Roll> From(IEnumerable<char> line)
        {
            return line.Map(ToRoll).ToList();
        }

        private static Roll ToRoll(char character)
        {
            if (character == '-') return Roll.Zero;
            if (character == '/') return Roll.Spare;
            if (character == 'X') return Roll.Strike;
            return (Roll) int.Parse(character.ToString());
        }
    }
}