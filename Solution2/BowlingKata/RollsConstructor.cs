using System.Collections.Generic;

namespace BowlingKata
{
    public class RollsConstructor
    {
        private const int MaxPins = 10;
        private const int NoPins = 0;
        private static int index;
        private static Roll[] rolls;

        private static Roll CurrentRoll => rolls[index];

        public static Roll[] Construct(string line)
        {
            rolls = RollsWithDefaultValues(line.Length);
            
            for (index = 0; index < line.Length; index++)
            {
                if (line[index] == '/')
                    ConstructSpare(ToInt(line[index - 1]));
                else if (line[index] == 'X')
                    ConstructStrike();
                else if (line[index] == '-')
                    rolls[index].Pins = NoPins;
                else
                    rolls[index].Pins = ToInt(line[index]);
            }
            return rolls;
        }

        private static void ConstructStrike()
        {
            CurrentRoll.Pins = MaxPins;
            IncrementMultiplierForTwoNextRolls();
        }

        private static void ConstructSpare(int previousPins)
        {
            CurrentRoll.Pins = MaxPins - previousPins;
            IncrementMultiplierForNextRoll();
        }

        private static void IncrementMultiplierForTwoNextRolls()
        {
            if (index < rolls.Length - 3)
            {
                CurrentRoll.Next.Multiplier += 1;
                CurrentRoll.Next.Next.Multiplier += 1;
            }
        }

        private static void IncrementMultiplierForNextRoll()
        {
            if (index < rolls.Length - 2)
                CurrentRoll.Next.Multiplier += 1;
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
            for (int i = 0; i < rolls.Length - 1; i++)
            {
                rolls[i].Next = rolls[i + 1];
            }
            return rolls;
        }
    }
}