﻿using System.Linq;
using System.Security.Cryptography.X509Certificates;
using BowlingKata;
using FluentAssertions;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class RollsConstructorShould
    { 
        [Test]
        public void parse_empty_symbol_to_0()
        {
            var rolls = RollsConstructor.Construct("--------------------");

            rolls.Select(r => r.Pins).Sum().Should().Be(0);
        }

        [Test]
        public void parse_to_int_when_no_spare_or_strike_or_empty()
        {
            var rolls = RollsConstructor.Construct("5-------------------");

            rolls.First().Pins.Should().Be(5);
        }

        [Test]
        public void parse_strike_to_10()
        {
            var rolls = RollsConstructor.Construct("X------------------");

            rolls.First().Pins.Should().Be(10);
        }

        [Test]
        public void parse_spare_to_10_minus_previous_pins()
        {
            var rolls = RollsConstructor.Construct("5/------------------");

            rolls[1].Pins.Should().Be(5);
        }

        [Test]
        public void multiply_by_2_next_of_a_spare()
        {
            var rolls = RollsConstructor.Construct("5/3-----------------");

            rolls[2].Multiplier.Should().Be(2);
        }

        [Test]
        public void multiply_by_2_next_two_rolls_of_a_strike()
        {
            var rolls = RollsConstructor.Construct("X35-----------------");

            rolls[1].Multiplier.Should().Be(2);
            rolls[2].Multiplier.Should().Be(2);
        }
    }
}