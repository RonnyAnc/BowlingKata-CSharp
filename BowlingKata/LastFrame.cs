namespace BowlingKata
{
    internal class LastFrame : Frame
    {
        private Roll ThirdRoll { get; }

        public LastFrame(Roll firstRoll, Roll secondRoll, Roll thirdRoll) : base(firstRoll, secondRoll)
        {
            ThirdRoll = thirdRoll;
        }

        protected override int CalculateScore()
        {
            if (IsSpare()) return SpareBasePunctuation + (int) ThirdRoll; 
            return (int) FirstRoll + (int) SecondRoll + (int) ThirdRoll;
        }
    }
}