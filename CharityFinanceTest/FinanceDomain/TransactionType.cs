using System;
using System.Collections.Generic;

namespace FinanceDomain
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

    [Serializable]
    public class PaymentType : TransactionType
    {
    }

    [Serializable]
    public class FundType : TransactionType { }

    [Serializable]
    public class BudgetType : TransactionType { }

    [Serializable]
    public class SpendType : TransactionType { }
}