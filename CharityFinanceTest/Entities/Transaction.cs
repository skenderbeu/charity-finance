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
    }
}
