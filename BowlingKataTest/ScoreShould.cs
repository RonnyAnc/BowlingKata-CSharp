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
		public void sum_rolls_when_no_special_frame()
		{
			var score = CalculateScore("53------------------");
			score.Should().Be(8);
		}

		[Test]
		public void sum_rolls_when_there_is_a_spare()
		{
			var score = CalculateScore("5/------------------");
			score.Should().Be(10);
		}

		[Test]
		public void sum_rolls_when_there_is_a_spare_followed_by_non_zero_rolls()
		{
			var score = CalculateScore("5321----------------");
			score.Should().Be(11);
		}
		
		private static int CalculateScore(string line)
		{
			return new ScoreCalculator(line.ToCharArray()).CalculateScore();
		}
	}
}
