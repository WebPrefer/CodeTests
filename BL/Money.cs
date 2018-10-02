using System;

namespace WebPrefer.Tests.BL
{
    public struct Money
    {
        public string Currency { get; }
        public decimal Amount { get; }

        public Money(string currency, decimal amount = 0m)
        {
            Currency = currency;
            Amount = amount;
        }

        public static Money operator +(Money a, Money b)
        {
            if (a.Currency != b.Currency) throw new InvalidOperationException("currency mismatch");

            return new Money(a.Currency, a.Amount + b.Amount);
        }

        public static Money operator -(Money a, Money b)
        {
            if (a.Currency != b.Currency) throw new InvalidOperationException("currency mismatch");

            return new Money(a.Currency, a.Amount - b.Amount);
        }
    }
}