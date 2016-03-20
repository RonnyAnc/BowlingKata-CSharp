namespace BowlingKata
{
	public class Frame
	{
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
			if (SecondRoll == Roll.Spare) return 10;
			return (int) FirstRoll + (int) SecondRoll;
		}
	}
}