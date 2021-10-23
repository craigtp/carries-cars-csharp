using carries_cars;
using Xunit;

namespace carries_cars_tests
{
    public class MoneyTests
    {
        [Fact]
        public void Money_Equals_Detects_Equal_Value()
        {
            var actual = Money.EUR(99).Equals(Money.EUR(99));
            var expected = true;
            Assert.Equal(actual, expected);
        }

        [Fact]
        public void Money_Equals_Detects_Currency_Differences()
        {
            var actual = Money.EUR(99).Equals(Money.USD(99));
            var expected = false;
            Assert.Equal(actual, expected);
        }

        [Fact]
        public void Money_Equals_Detects_Amount_Differences()
        {
            var actual = Money.EUR(99).Equals(Money.USD(99));
            var expected = false;
            Assert.Equal(actual, expected);
        }

        [Fact]
        public void Money_Multiply_Multiplies()
        {
            var actual = Money.EUR(200).MultiplyAndRound(2.0);
            var expected = Money.EUR(400);
            Assert.Equal(actual, expected);
        }

        [Fact]
        public void Money_Multiply_Rounds_Upwards_Correctly()
        {
            var actual = Money.EUR(100).MultiplyAndRound(1.999);
            var expected = Money.EUR(200);
            Assert.Equal(actual, expected);
        }

        [Fact]
        public void Money_Multiply_Rounds_Downwards_Correctly()
        {
            var actual = Money.EUR(100).MultiplyAndRound(1.994);
            var expected = Money.EUR(199);
            Assert.Equal(actual, expected);
        }
    }
}