using System;
using System.Collections.Generic;

namespace FinanceDomain
{
    public abstract class Transaction : Entity
    {
        public virtual DateTime Date { get; protected set; }
        public virtual TransactionDescription Description { get; protected set; }
        public virtual PaymentType PaymentType { get; protected set; }
        public virtual Double Amount { get; protected set; }
        public virtual BudgetType BudgetType { get; protected set; }
        public virtual Note Notes { get; protected set; }
        public virtual FundType FundType { get; set; }
        public virtual Boolean BankCleared { get; set; }

        public Transaction(
            TransactionDescription description,
            DateTime transactionDate,
            PaymentType paymentType,
            Double amount,
            BudgetType budgetType,
            Note note
            )
        {
            Description = description;
            Date = transactionDate;
            PaymentType = paymentType;
            BudgetType = budgetType;
            Amount = amount;
            Notes = note;
        }

        public Transaction()
        {
        }

        public virtual void UpdateDescription(TransactionDescription description)
        {
            Description = description;
        }

        public virtual void UpdateNote(Note note)
        {
            Notes = note;
        }

        public virtual void UpdatePaymentType(PaymentType paymentType)
        {
            PaymentType = paymentType;
        }

        public virtual void UpdateBudgetType(BudgetType budgetType)
        {
            BudgetType = budgetType;
        }

        public virtual bool FieldsValidated()
        {
            var isValid = this.Date > DateTime.MinValue
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