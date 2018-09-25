namespace FinanceDomain
{
    public class TransactionDescription : ValueObject<TransactionDescription>
    {
        public virtual string Value { get; set; }

        public TransactionDescription()
        {
            new TransactionDescription("Something");
        }

        public TransactionDescription(string value)
        {
            Value = value;
        }

        public static Result<TransactionDescription> Create(string description)
        {
            if (string.IsNullOrWhiteSpace(description))
                return Result.Fail<TransactionDescription>("Description should not be empty");

            description = description.Trim();
            if (description.Length > 100)
                return Result.Fail<TransactionDescription>("Description is too long");

            return Result.Ok(new TransactionDescription(description));
        }

        protected override bool EqualsCore(TransactionDescription other)
        {
            return Value == other.Value;
        }

        protected override int GetHashCodeCore()
        {
            return Value.GetHashCode();
        }

        public static explicit operator TransactionDescription(string description)
        {
            return Create(description).Value;
        }

        public static implicit operator string(TransactionDescription description)
        {
            return description.Value;
        }
    }
}