using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using FinanceDomain;

namespace FinanceServices
{
    public interface IIncomeViewModel
    {
        IList<BudgetType> GetBudgetTypes();

        IList<FundType> GetFundTypes();

        IList<PaymentType> GetPaymentTypes();

        IList<SpendType> GetSpendTypes();
    }
}