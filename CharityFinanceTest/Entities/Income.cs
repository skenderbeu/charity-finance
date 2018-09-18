using System;

namespace FinanceDomain
{
    public class Income : Transaction
    {
        private string _payingInSlip;

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