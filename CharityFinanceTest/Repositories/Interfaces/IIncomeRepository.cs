using FinanceEntities;
using System;
using System.Collections.Generic;

namespace Repositories
{
    public interface IIncomeRepository : IDisposable
    {
        IEnumerable<Income> GetIncomeByDescription(string description);

        IEnumerable<Income> GetIncomeByDescription(string description, IEnumerable<Income> incomeToFilterBy);

        IEnumerable<Income> GetIncomeByDate(DateTime date);

        IEnumerable<Income> GetIncomeByDateRange(DateTime dateFrom, DateTime dateTo);

        IEnumerable<Income> GetIncomeByBudgetType(BudgetTypes budgetType);

        IEnumerable<Income> GetIncomeByBudgetType(BudgetTypes budgetType, IEnumerable<Income> incomeToFilterBy);

        IEnumerable<Income> GetIncomeByPaymentType(PaymentTypes paymentType);

        IEnumerable<Income> GetIncomeByPaymentType(PaymentTypes paymentType, IEnumerable<Income> incomeToFilterBy);

        IEnumerable<Income> GetIncomeByAmount(double amount);

        IEnumerable<Income> GetIncomeByAmount(double amount, IEnumerable<Income> incomeToFilterBy);

        void Add(Income income);

        void Update(Income income);

        void Save();
    }
}