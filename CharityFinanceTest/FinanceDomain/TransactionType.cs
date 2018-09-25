using System;
using System.Collections.Generic;

namespace FinanceDomain
{
    public class TransactionType : Entity
    {
        public virtual string Description { get; set; }
        public virtual string LongDescription { get; set; }

        public override string ToString()
        {
            return $"{LongDescription}";
        }

        public override bool Equals(object obj)
        {
            var item = obj as TransactionType;

            if (item == null)
            {
                return false;
            }

            return this.Id.Equals(item.Id);
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
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