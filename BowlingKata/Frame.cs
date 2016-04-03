namespace BowlingKata
{
	public class Frame
	{
	    private const int SpareBasePunctuation = 10;
	    private const int StrikeBasePunctuation = 10;

	    protected Roll FirstRoll { get; }
		protected Roll SecondRoll { get; }
	    public Frame Next { get; set; }

	    public Frame(Roll firstRoll, Roll secondRoll)
		{
			FirstRoll = firstRoll;
			SecondRoll = secondRoll;
		}

	    public int GetScore()
	    {
	        if (DoesNotHaveNext()) return CalculateScore();
	        return CalculateScore() + Next.GetScore();
	    }

	    protected virtual int CalculateScore()
		{
		    if (IsStrike()) return StrikeBasePunctuation + GetTwoNextRollsPins();
			if (IsSpare()) return SpareBasePunctuation + GetNextRollPins();
			return (int) FirstRoll + (int) SecondRoll;
		}

	    protected virtual int GetNextToNextRollPins()
	    {
	        if (Next.Next == null) return (int) Next.SecondRoll;
	        if (Next.IsStrike()) return (int) Next.Next.FirstRoll;
	        return (int) Next.SecondRoll;
	    }

	    private int GetTwoNextRollsPins() => GetNextRollPins() + GetNextToNextRollPins();

	    private int GetNextRollPins() => (int) Next.FirstRoll;

        private bool IsStrike() => FirstRoll == Roll.Strike;

	    protected bool IsSpare() => SecondRoll == Roll.Spare;

	    private bool HasNext() => Next != null;

	    private bool DoesNotHaveNext() => !HasNext();
	}
}