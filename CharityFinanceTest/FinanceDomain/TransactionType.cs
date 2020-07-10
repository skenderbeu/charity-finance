using System;
using System.Collections.Generic;

namespace FinanceDomain
{
    public abstract class TransactionType : Entity
    {
        public virtual string Description { get; set; }
        public virtual string LongDescription { get; set; }

        protected TransactionType(string description, string longDescription)
        {
            Id = Guid.NewGuid();
            Description = description;
            LongDescription = longDescription;
        }

        protected TransactionType()
        {
        }

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
    public class FundType : TransactionType
    {
        private FundType(string description, string longDescription) : base(description, longDescription)
        {
        }

        protected FundType() : base()
        {
        }

        public static FundType Create(string description, string longDescription)
        {
            return new FundType(description, longDescription);
        }
    }

    [Serializable]
    public class BudgetType : TransactionType
    {
        private BudgetType(string description, string longDescription) : base(description, longDescription)
        {
        }

        protected BudgetType() : base()
        {
        }

        public static BudgetType Create(string description, string longDescription)
        {
            return new BudgetType(description, longDescription);
        }
    }

    [Serializable]
    public class SpendType : TransactionType
    {
        private SpendType(string description, string longDescription) : base(description, longDescription)
        {
        }

        protected SpendType() : base()
        {
        }

        public static SpendType Create(string description, string longDescription)
        {
            return new SpendType(description, longDescription);
        }
    }
}