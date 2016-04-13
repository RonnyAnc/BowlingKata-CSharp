using System.Collections.Generic;

namespace BowlingKata
{
    public class RollsConstructor
    {
        public static List<Roll> Construct(string line)
        {
            var rolls = new List<Roll>();
            foreach (var rollSymbol in line)
            {
                if (rollSymbol == '-') rolls.Add(new Roll {Pins = 0});
            }
            return rolls;
        }
    }
}