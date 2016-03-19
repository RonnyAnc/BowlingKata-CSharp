namespace BowlingKata
{
	public class Frame
	{
		private int FirstRoll { get; }
		private int SecondRoll { get; }
		private Roll FirstRoll1 { get; }
		private Roll SecondRoll1 { get; }

		public Frame(int firstRoll, int secondRoll)
		{
			FirstRoll = firstRoll;
			SecondRoll = secondRoll;
		}

		public Frame(Roll firstRoll, Roll secondRoll)
		{
			FirstRoll1 = firstRoll;
			SecondRoll1 = secondRoll;
		}

		public int Score()
		{
			if (SecondRoll1 == Roll.Spare) return 10;
			return (int) FirstRoll1 + (int) SecondRoll1;
		}
	}
}