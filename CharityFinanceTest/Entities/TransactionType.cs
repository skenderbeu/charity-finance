using System;

namespace FinanceEntities
{
    public class TransactionType : DBBase
    {
        public virtual string Description { get; set; }
        public virtual string LongDescription { get; set; }

        public override bool Equals(object obj)
        {
            if (!(obj is TransactionType item))
            {
                return false;
            }

            return this.Id.Equals(item.Id);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public override string ToString()
        {
            return $"{LongDescription}";
        }
    }

    public class PaymentType : TransactionType { }

    public class FundType : TransactionType { }

    public class BudgetType : TransactionType { }

    public class SpendType : TransactionType { }
}