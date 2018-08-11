using System;

namespace FinanceEntities
{
    public abstract class Transaction
    {
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public PaymentTypes PaymentType { get; set; }
        public Double Amount { get; set; }
        public BudgetTypes BudgetType { get; set; }
        public string Notes { get; set; }
        public FundTypes FundType { get; set; }
        public Boolean BankCleared { get; set; }

        public virtual bool FieldsValidated()
        {
            var isValid = this.Date > DateTime.MinValue 
                && !string.IsNullOrEmpty(this.Description)
                && PaymentType != PaymentTypes.NotSet 
                && Amount > 0.00 
                && BudgetType != BudgetTypes.NotSet ?  true :  false;

            return isValid;
        }

        public virtual void GetFund()
        {
            if (BudgetType == BudgetTypes.NotSet) throw new ArgumentOutOfRangeException("No Budget Type Selected before setting Fund");

            if (BudgetType == BudgetTypes.MessyChurch)
            {
                FundType = FundTypes.MessyChurch;
            }
            if (BudgetType == BudgetTypes.Building)
            {
                FundType = FundTypes.BuildingFund;
            }
            else
            {
                FundType = FundTypes.Revenue;
            }
        }


    }
}
