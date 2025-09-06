namespace miniproj.Domain.ValueObjects
{
    public enum M
    {
        USD,
        EUR,
        EGP
    }
    public class Money
    {
        public decimal Amount { get; set;}
        public string Currency { get; set;}
        public Money(){}


        public Money(decimal amount, string currency)
        {
            this.Amount = (amount >= 0) ? amount : throw new ArgumentException("amount has to be positive");
            this.Currency = currency;
        }

        public override string ToString()
        {
            return $"{Amount} {Currency}";
        }
        public Money subtract(decimal val)
        {
            return (val >= 0 && val <= Amount) ? new Money(Amount - val, Currency) : throw new ArgumentException("val has to be positive and less than or equal to amount");
        }
        public bool Equals(Money other)
        {
            return this.Amount == other.Amount && this.Currency == other.Currency;
        }
    }
}