using System;

namespace FinanceDomain
{
    public class Income : Transaction
    {
        private string _payingInSlip;

        private Income(
            TransactionDescription description,
            DateTime transactionDate,
            PaymentType paymentType,
            double amount,
            BudgetType budgetType,
            Note note,
            FundType fundType) :
            base(description, transactionDate,
                paymentType, amount, budgetType, note, fundType)
        { }

        protected Income()
        {
        }

        public static Income Create(
            TransactionDescription description,
            DateTime transactionDate,
            PaymentType paymentType,
            Double amount,
            BudgetType budgetType,
            Note note,
            FundType fundType)
        {
            if (paymentType == null) return null;
            if (budgetType == null) return null;
            if (fundType == null) return null;
            if (transactionDate == DateTime.MinValue) return null;
            if (amount <= 0.00) return null;

            return new Income(
                description, transactionDate,
                paymentType, amount, budgetType, note, fundType);
        }

        public virtual string PayingInSlip
        {
            get { return _payingInSlip; }
            set
            {
                int result;
                if (int.TryParse(value, out result))
                {
                    _payingInSlip = value;
                }
                else
                {
                    throw new ArgumentException("A PayingIn Slip with non numeric characters is not allowed.");
                }
            }
        }

        public virtual GiftAidStatus GiftAidStatus { get; set; }

        public override bool FieldsValidated()
        {
            if (PaymentType == null) return false;
            if ((PaymentType.Description == "CSH" || PaymentType.Description == "CHQ") && !string.IsNullOrEmpty(PayingInSlip))
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
            return $"Income {Description} received {Date} for {Amount} into budget {BudgetType.LongDescription}";
        }
    }
}