using System;
using System.Collections.Generic;

namespace FinanceDomain
{
    public abstract class Transaction : Entity
    {
        public virtual DateTime Date { get; set; }
        public virtual TransactionDescription Description { get; set; }
        public virtual PaymentType PaymentType { get; set; }
        public virtual Double Amount { get; set; }
        public virtual BudgetType BudgetType { get; set; }
        public virtual Note Notes { get; set; }
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

        public override bool Equals(object obj)
        {
            var item = obj as Transaction;

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

        public virtual void GetFund()
        {
            throw new NotImplementedException();
        }
    }
}