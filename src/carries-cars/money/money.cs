using CurrencyIsoCode = System.String;
using System;

namespace carries_cars
{
    public static class Constants
    {
        public const string Euro = "EUR";
        public const string UnitedStatesDollar = "USD";
    }

    public record Money
    {
        public int Amount { get; init; }
        public CurrencyIsoCode CurrencyIsoCode { get; init; }

        public Money(int amount, CurrencyIsoCode currencyIsoCode)
        {
            this.Amount = amount;
            this.CurrencyIsoCode = currencyIsoCode;
        }

        public static Money EUR(int amount) => new Money(amount, "EUR");
        public static Money USD(int amount) => new Money(amount, "USD");

        public Money MultiplyAndRound(double multiplier)
        {
            var multipliedAmount = Amount * multiplier;
            var rounded = (int)Math.Round(multipliedAmount);
            return new Money(rounded, CurrencyIsoCode);
        }
    }
}