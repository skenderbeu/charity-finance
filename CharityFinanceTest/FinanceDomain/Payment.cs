using System;

namespace FinanceDomain
{
    public class Payment : Transaction
    {
        private Payment(
        TransactionDescription description,
           DateTime transactionDate,
            PaymentType paymentType,
            double amount,
            BudgetType budgetType,
            Note note) :
            base(description, transactionDate,
                paymentType, amount, budgetType, note)
        { }

        protected Payment()
        {
        }

        public static Payment Create(
          TransactionDescription description,
          DateTime transactionDate,
          PaymentType paymentType,
          Double amount,
          BudgetType budgetType,
          Note note)
        {
            return new Payment(
                description, transactionDate,
                paymentType, amount, budgetType, note);
        }

        public virtual SpendType SpendType { get; set; }
        public virtual string ChequeNumber { get; set; }

        public override bool FieldsValidated()
        {
            if (SpendType != null)
            {
                return base.FieldsValidated();
            }
            else
            {
                return false;
            }
        }

        public override string ToString()
        {
            return $"Payment {Description} made {Date} for {Amount} from budget {BudgetType.LongDescription}";
        }
    }
}