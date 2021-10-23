using System;

namespace carries_cars
{
    public class PricingEngine
    {
        public struct UnverifiedDuration
        {
            public int DurationInMinutes;
            public Duration Verify()
            {
                return DurationInMinutes(this.DurationInMinutes);
            }
        }

        public struct Duration
        {
            public int DurationInMinutes;
        }

        public static Duration DurationInMinutes(int durationInMinutes)
        {
            if (durationInMinutes <= 0)
            {
                throw new ArgumentException("DurationInMinutes must be greater than zero.");
            }
            return new Duration { DurationInMinutes = durationInMinutes };
        }

        public static Money CalculatePrice(Money pricePerMinute, Duration duration)
        {
            var durationInMinutes = (double)duration.DurationInMinutes;
            return pricePerMinute.MultiplyAndRound(durationInMinutes);
        }
    }
}
