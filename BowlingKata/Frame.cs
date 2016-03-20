namespace BowlingKata
{
	public class Frame
	{
	    private const int SparePunctuation = 10;

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
		    if (FirstRoll == Roll.Strike) return 10 + GetNextRollPins() + (int) Next.SecondRoll;
			if (IsSpare()) return SparePunctuation + GetNextRollPins();
			return (int) FirstRoll + (int) SecondRoll;
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