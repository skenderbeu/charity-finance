using FinanceDomain;
using System;
using System.Collections.Generic;

namespace FinanceServices
{
    public interface IIncomeServices
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