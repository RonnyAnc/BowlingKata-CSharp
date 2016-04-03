namespace BowlingKata
{
    internal class LastFrame : Frame
    {
        private Roll ThirdRoll { get; }
        public LastFrame(params Roll[] rolls) : base(rolls[0], rolls[1])
        {
            ThirdRoll = rolls[2];
        }

        protected override int CalculateScore()
        {
            if (IsSpare()) return 10 + (int) ThirdRoll; 
            return (int) FirstRoll + (int) SecondRoll + (int) ThirdRoll;
        }
    }
}