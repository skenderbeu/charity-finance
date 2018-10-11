using System;
using FinanceDomain;

namespace FinanceServices
{
    public interface IIncomeCommands
    {
        Result Add(string description, double amount, DateTime date, string note,
           PaymentType paymentType,
            BudgetType budgetType, FundType fundType, bool? giftAid = false);

        void Delete(Income income);

        void Update(Income income);
    }
}