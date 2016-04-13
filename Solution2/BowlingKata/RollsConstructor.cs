using System.Collections.Generic;
using System.Linq;

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
            
            for (index = 0; index < rolls.Length; index++)
            {
                ConstructCurrentRollIn(line);
            }
            return rolls;
        }

        private static void ConstructCurrentRollIn(string line)
        {
            var rollSymbol = line[index];
            if (IsSpare(rollSymbol)) ConstructSpareRoll(PreviousPins(line));
            else if (IsStrike(rollSymbol)) ConstructStrikeRoll();
            else if (IsEmpty(rollSymbol)) ConstructEmptyRoll();
            else ConstructStandardRoll(rollSymbol);
        }

        private static bool IsEmpty(char rollSymbol)
        {
            return rollSymbol == '-';
        }

        private static bool IsStrike(char rollSymbol)
        {
            return rollSymbol == 'X';
        }

        private static bool IsSpare(char rollSymbol)
        {
            return rollSymbol == '/';
        }

        private static int PreviousPins(string line) => ToInt(line[index - 1]);

        private static void ConstructStandardRoll(char rollSymbol)
        {
            rolls[index].Pins = ToInt(rollSymbol);
        }

        private static void ConstructEmptyRoll()
        {
            rolls[index].Pins = NoPins;
        }

        private static void ConstructStrikeRoll()
        {
            CurrentRoll.Pins = MaxPins;
            IncrementMultiplierForTwoNextRolls();
        }

        private static void ConstructSpareRoll(int previousPins)
        {
            CurrentRoll.Pins = MaxPins - previousPins;
            IncrementMultiplierForNextRoll();
        }

        private static void IncrementMultiplierForTwoNextRolls()
        {
            if (index >= rolls.Length - 3) return;
            CurrentRoll.Next.Multiplier += 1;
            CurrentRoll.Next.Next.Multiplier += 1;
        }

        private static void IncrementMultiplierForNextRoll()
        {
            if (index >= rolls.Length - 2) return;
            CurrentRoll.Next.Multiplier += 1;
        }

        private static int ToInt(char roll) => int.Parse(roll.ToString());

        private static Roll[] RollsWithDefaultValues(int size)
        {
            var rolls = new Roll[size]
                            .Select(e => new Roll())
                            .ToArray();
            for (var i = 0; i < rolls.Length - 1; i++)
            {
                rolls[i].Next = rolls[i + 1];
            }
            return rolls;
        }
    }
}