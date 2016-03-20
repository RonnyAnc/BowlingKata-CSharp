namespace BowlingKata
{
	public class Frame
	{
	    private const int SpareBasePunctuation = 10;
	    private const int StrikeBasePunctuation = 10;

	    private Roll FirstRoll { get; }
		private Roll SecondRoll { get; }
	    public Frame Next { get; set; }

	    public Frame(Roll firstRoll, Roll secondRoll)
		{
			FirstRoll = firstRoll;
			SecondRoll = secondRoll;
		}

		public int Score()
		{
		    if (IsStrike()) return StrikeBasePunctuation + GetTwoNextRollsPins();
			if (IsSpare()) return SpareBasePunctuation + GetNextRollPins();
			return (int) FirstRoll + (int) SecondRoll;
		}

	    private int GetTwoNextRollsPins()
	    {
	        return GetNextRollPins() + GetNextToNextRollPins();
	    }

	    private int GetNextToNextRollPins()
	    {
	        return (int) Next.SecondRoll;
	    }

	    private bool IsStrike()
	    {
	        return FirstRoll == Roll.Strike;
	    }

	    private bool IsSpare()
	    {
	        return SecondRoll == Roll.Spare;
	    }

	    private int GetNextRollPins()
	    {
	        return (int) Next.FirstRoll;
	    }

	    public bool HasNext()
	    {
	        return Next != null;
	    }
	}
}