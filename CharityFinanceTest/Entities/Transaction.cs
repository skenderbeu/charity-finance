using System;

namespace FinanceDomain
{
    public abstract class Transaction : DBBase
    {
        public virtual DateTime Date { get; set; }
        public virtual string Description { get; set; }
        public virtual PaymentType PaymentType { get; set; }
        public virtual Double Amount { get; set; }
        public virtual BudgetType BudgetType { get; set; }
        public virtual string Notes { get; set; }
        public virtual FundType FundType { get; set; }
        public virtual Boolean BankCleared { get; set; }

        public virtual bool FieldsValidated()
        {
            var isValid = this.Date > DateTime.MinValue
                && !string.IsNullOrEmpty(this.Description)
                && PaymentType != null
                && Amount > 0.00
                && BudgetType != null ? true : false;

            return isValid;
        }

        public virtual void GetFund()
        {
            throw new NotImplementedException();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Transaction item))
            {
                return false;
            }

            return this.Id.Equals(item.Id);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}