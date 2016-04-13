using System.Linq;
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
    }
}