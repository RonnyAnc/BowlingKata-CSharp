namespace BowlingKata
{
	public class Frame
	{
	    protected const int SpareBasePunctuation = 10;
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
		    if (IsStrike()) return StrikeBasePunctuation + TwoNextRollsPins();
			if (IsSpare()) return SpareBasePunctuation + NextRollPins();
			return FirstRoll.Value() + SecondRoll.Value();
		}

	    private int GetNextToNextRollPins()
	    {
	        if (Next.IsStrike() && Next.HasNext())
                return Next.Next.FirstRoll.Value();
	        return Next.SecondRoll.Value();
	    }

	    private int TwoNextRollsPins() => NextRollPins() + GetNextToNextRollPins();

	    private int NextRollPins() => Next.FirstRoll.Value();

        private bool IsStrike() => FirstRoll == Roll.Strike;

	    protected bool IsSpare() => SecondRoll == Roll.Spare;

	    private bool HasNext() => Next != null;

	    private bool DoesNotHaveNext() => !HasNext();
	}
}