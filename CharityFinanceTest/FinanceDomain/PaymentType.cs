using System;

namespace FinanceDomain
{
    [Serializable]
    public class PaymentType : TransactionType
    {
        private PaymentType(string description, string longDescription) : base(description, longDescription)
        {
        }

        protected PaymentType() : base()
        {
        }

        public static Result<PaymentType> Create(string description, string longDescription)
        {
            if (description.Length != 3) return Result.Fail<PaymentType>("Payment Type Code must be 3 characters");
            if (string.IsNullOrWhiteSpace(longDescription)) return Result.Fail<PaymentType>("Payment Type Long Description cannot be blank");
            if (longDescription.Length > 20) return Result.Fail<PaymentType>("Payment Type Long Description must be under 21 characters");

            return Result.Ok(new PaymentType(description, longDescription));
        }
    }
}