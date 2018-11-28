using System;
using System.Linq;

namespace WebPrefer.Tests.BL
{
    public struct Money
    {
        public static readonly string[] SupportedCurrencies = new string[] { "EUR", "SEK" };

        public string Currency { get; }
        public decimal Amount { get; }

        public Money(string currency, decimal amount = 0m)
        {
            if (!SupportedCurrencies.Contains(currency))
            {
                throw new ArgumentException($"{currency} not supported", nameof(currency));
            }

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

        public static Money operator *(Money a, Money b)
        {
            if (a.Currency != b.Currency) throw new InvalidOperationException("currency mismatch");

            return new Money(a.Currency, a.Amount * b.Amount);
        }

        public static Money operator /(Money a, Money b)
        {
            if (a.Currency != b.Currency) throw new InvalidOperationException("currency mismatch");

            return new Money(a.Currency, a.Amount / b.Amount);
        }

        public static bool operator <(Money a, Money b)
        {
            if (a.Currency != b.Currency) throw new InvalidOperationException("currency mismatch");

            return a.Amount < b.Amount;
        }

        public static bool operator >(Money a, Money b)
        {
            if (a.Currency != b.Currency) throw new InvalidOperationException("currency mismatch");

            return a.Amount > b.Amount;
        }

        public static bool operator ==(Money a, Money b)
        {
            if (a.Currency != b.Currency) throw new InvalidOperationException("currency mismatch");

            return a.Amount == b.Amount;
        }

        public static bool operator !=(Money a, Money b)
        {
            if (a.Currency != b.Currency) throw new InvalidOperationException("currency mismatch");

            return a.Amount != b.Amount;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Money))
                return false;

            return this == (Money)obj;
        }

        public override int GetHashCode()
            => base.GetHashCode();

        public override string ToString()
            => $"{Currency} {Amount}";
    }
}