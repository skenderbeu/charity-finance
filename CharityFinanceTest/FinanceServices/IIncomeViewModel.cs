using System;
using System.Collections.Generic;
using FinanceEntities;

namespace FinanceServices
{
    public interface IEditIncomeViewModel
    {
        void Add(Income income);

        void Delete(Income income);

        IList<BudgetType> GetBudgetTypes();

        IList<FundType> GetFundypes();

        IList<PaymentType> GetPaymentTypes();

        IList<SpendType> GetSpendTypes();

        void Update(Income income);
    }

    public interface IIncomeViewModel
    {
        IList<Income> GetIncomeByAmount(double amount);

        IList<Income> GetIncomeByAmount(double amount, IList<Income> incomeToFilterBy);

        IList<Income> GetIncomeByBudgetType(BudgetType budgetType);

        IList<Income> GetIncomeByBudgetType(BudgetType budgetType, IList<Income> incomeToFilterBy);

        IList<Income> GetIncomeByDate(DateTime date);

        IList<Income> GetIncomeByDateRange(DateTime dateFrom, DateTime dateTo);

        IList<Income> GetIncomeByDescription(string description);

        IList<Income> GetIncomeByDescription(string description, IList<Income> incomeToFilterBy);

        IList<Income> GetIncomeByPaymentType(PaymentType paymentType);

        IList<Income> GetIncomeByPaymentType(PaymentType paymentType, IList<Income> incomeToFilterBy);
    }
}