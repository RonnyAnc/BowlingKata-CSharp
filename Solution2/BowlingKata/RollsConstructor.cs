using System.Collections.Generic;

namespace BowlingKata
{
    public class RollsConstructor
    {
        public static Roll[] Construct(string line)
        {
            var rolls = RollsWithDefaultValues(line.Length);
            
            for (var i = 0; i < line.Length; i++)
            {
                if (line[i] == '/')
                {
                    rolls[i].Pins = 10 - int.Parse(line[i - 1].ToString());
                }
                else if (line[i] == 'X')
                {
                    rolls[i].Pins = 10;
                }
                else if (line[i] == '-')
                {
                    rolls[i].Pins = 0;
                }
                else
                {
                    rolls[i].Pins = int.Parse(line[i].ToString());
                }
            }
            return rolls;
        }

        private static Roll[] RollsWithDefaultValues(int size)
        {
            var rolls = new Roll[size];
            for (int i = 0; i < rolls.Length; i++)
            {
                rolls[i] = new Roll();
            }
            return rolls;
        }
    }
}