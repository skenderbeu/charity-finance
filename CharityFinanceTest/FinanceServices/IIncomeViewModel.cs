using System.Collections.Generic;
using FinanceEntities;

namespace FinanceServices
{
    public interface IIncomeViewModel
    {
        void Add(Income income);

        void Delete(Income income);

        IList<BudgetType> GetBudgetTypes();

        IList<FundType> GetFundypes();

        IList<PaymentType> GetPaymentTypes();

        IList<SpendType> GetSpendTypes();

        void Update(Income income);
    }
}