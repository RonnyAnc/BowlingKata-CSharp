using System.Collections.Generic;

namespace BowlingKata
{
    public class RollsConstructor
    {
        private const int MaxPins = 10;
        private const int NoPins = 0;

        public static Roll[] Construct(string line)
        {
            var rolls = RollsWithDefaultValues(line.Length);
            
            for (var i = 0; i < line.Length; i++)
            {
                if (line[i] == '/')
                {
                    rolls[i].Pins = MaxPins - ToInt(line[i - 1]);
                    if (i < rolls.Length - 2)
                    {
                        rolls[i + 1].Multiplier += 1;
                    }
                }
                else if (line[i] == 'X')
                {
                    rolls[i].Pins = MaxPins;
                    if (i < line.Length - 3)
                    {
                        rolls[i + 1].Multiplier += 1;
                        rolls[i + 2].Multiplier += 1;
                    }
                }
                else if (line[i] == '-')
                {
                    rolls[i].Pins = NoPins;
                }
                else
                {
                    rolls[i].Pins = ToInt(line[i]);
                }
            }
            return rolls;
        }

        private static int ToInt(char roll)
        {
            return int.Parse(roll.ToString());
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