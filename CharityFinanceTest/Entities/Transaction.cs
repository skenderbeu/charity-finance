using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceEntities
{
    public class Transaction
    {
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public PaymentTypes PaymentType { get; set; }
        public Double Amount { get; set; }
        public BudgetTypes BudgetType { get; set; }
        public string Notes { get; set; }
        public FundTypes FundType { get; set; }

        public virtual bool FieldsValidated()
        {
            var isValid = this.Date > DateTime.MinValue 
                && !string.IsNullOrEmpty(this.Description)
                && PaymentType != PaymentTypes.NotSet 
                && Amount > 0.00 
                && BudgetType != BudgetTypes.NotSet ?  true :  false;

            return isValid;
        }
    }
}
