﻿using BowlingKata;
using FluentAssertions;
using NUnit.Framework;

namespace BowlingKataTest
{
	[TestFixture]
	internal class ScoreShould
	{
        [Test]
        public void sum_rolls_when_there_are_more_than_one_frame()
        {
            CalculateScore("53211---------------").Should().Be(12);
        }

        [Test]
		public void sum_rolls_when_there_is_a_spare()
		{
            CalculateScore("5/------------------").Should().Be(10);
		}

        [Test]
		public void sum_rolls_when_there_is_a_strike()
		{
            CalculateScore("X------------------").Should().Be(10);
		}

        [Test]
		public void calculate_a_spare_frame_score_using_next_roll()
		{
            CalculateScore("5/1-----------------").Should().Be(12);
		}

        [Test]
        public void calculate_a_strike_frame_score_using_two_next_roll()
        {
            CalculateScore("X53----------------").Should().Be(26);
            CalculateScore("XXX--------------").Should().Be(60);
        }

	    [Test]
	    public void all_strikes_in_the_last_frame()
	    {
	        CalculateScore("------------------XXX").Should().Be(30);
	    }

        [Test]
	    public void a_spare_in_the_last_frame()
	    {
	        CalculateScore("------------------5/5").Should().Be(15);
	    }

	    [Test]
	    public void all_spares()
	    {
	        CalculateScore("5/5/5/5/5/5/5/5/5/5/5").Should().Be(150);
	    }

	    [Test]
	    public void all_strikes()
	    {
	        CalculateScore("XXXXXXXXXXXX").Should().Be(300);
	    }

        private static int CalculateScore(string line)
		{
			return ScoreCalculator.CalculateScore(line);
		}      
	}
}
