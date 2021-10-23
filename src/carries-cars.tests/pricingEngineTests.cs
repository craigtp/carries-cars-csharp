using System;
using carries_cars;
using Xunit;

namespace carries_cars_tests
{
    public class PricingEngineTests
    {
        [Fact]
        public void CalculatePrice_Charged_Per_Minute()
        {
            var pricePerMinute = Money.EUR(30);
            var duration = PricingEngine.DurationInMinutes(1);
            var expected = Money.EUR(30);
            var actual = PricingEngine.CalculatePrice(pricePerMinute, duration);
            Assert.Equal(actual, expected);
        }

        [Fact]
        public void Duration_Guards_Against_Zero_Or_Negative_Duration()
        {
            Assert.Throws<ArgumentException>(() => PricingEngine.DurationInMinutes(0));
        }

        [Fact]
        public void UnverifiedDuration_Valid_Input()
        {
            var inMinutes = 1;
            var unverifiedInput = new PricingEngine.UnverifiedDuration { DurationInMinutes = inMinutes };
            var actual = unverifiedInput.Verify();
            var expected = PricingEngine.DurationInMinutes(1);
            Assert.Equal(actual, expected);
        }

        [Fact]
        public void UnverifiedDuration_Invalid_Input()
        {
            var inMinutes = 0;
            var unverifiedInput = new PricingEngine.UnverifiedDuration { DurationInMinutes = inMinutes };
            Assert.Throws<ArgumentException>(() => unverifiedInput.Verify());
        }
    }
}