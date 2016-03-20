using BowlingKata;
using FluentAssertions;
using NUnit.Framework;

/* TODO
	- (X------------------) -> 10
	- (5/1-----------------) -> 12
	- (X53-----------------) -> 26
	- (XX----------------) -> 30
	- (XXX----------------) -> 60
	- (-------------------XXX) -> 30
	- (-------------------5/5) -> 15
	- (5/5/5/5/5/5/5/5/5/5/5) -> 150
	- (XXXXXXXXXXXX) -> 300
*/

namespace BowlingKataTest
{
	[TestFixture]
	class ScoreShould
	{
        [Test]
        public void sum_rolls_when_there_are_more_than_one_frame()
        {
            var score = CalculateScore("5321----------------");
            score.Should().Be(11);
        }

        [Test]
		public void sum_rolls_when_there_is_a_spare()
		{
			var score = CalculateScore("5/------------------");
			score.Should().Be(10);
		}

        [Test]
		public void sum_rolls_when_there_is_a_strike()
		{
			var score = CalculateScore("X------------------");
			score.Should().Be(10);
		}
		
		private static int CalculateScore(string line)
		{
			return new ScoreCalculator(line.ToCharArray()).CalculateScore();
		}                  
	}
}
