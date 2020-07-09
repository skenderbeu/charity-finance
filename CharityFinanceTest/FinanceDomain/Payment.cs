using System;

namespace FinanceDomain
{
    public class Payment : Transaction
    {
        public virtual SpendType SpendType { get; protected set; }
        public virtual string ChequeNumber { get; protected set; }

        private Payment(
        TransactionDescription description,
           DateTime transactionDate,
            PaymentType paymentType,
            double amount,
            BudgetType budgetType,
            SpendType spendType,
            Note note,
            string chequeNumber,
            FundType fundType) :
            base(description, transactionDate,
                paymentType, amount, budgetType, note, fundType)
        {
            SpendType = spendType;
            ChequeNumber = chequeNumber;
        }

        protected Payment()
        {
        }

        public static Payment Create(
          TransactionDescription description,
          DateTime transactionDate,
          PaymentType paymentType,
          Double amount,
          BudgetType budgetType,
          SpendType spendType,
          Note note,
          string chequeNumber,
          FundType fundType)
        {
            if (paymentType == null) return null;
            if (budgetType == null) return null;
            if (spendType == null) return null;
            if (fundType == null) return null;
            if (transactionDate == DateTime.MinValue) return null;
            if (amount <= 0.00) return null;
            if (!string.IsNullOrWhiteSpace(chequeNumber))
            {
                int result; 
                if (!int.TryParse(chequeNumber, out result)) return null;
            }

            return new Payment(
                description, transactionDate,
                paymentType, amount, budgetType,
                spendType, note, chequeNumber, fundType);
        }

        public override string ToString()
        {
            return $"Payment {Description} made {Date} for {Amount} from budget {BudgetType.LongDescription}";
        }
    }
}