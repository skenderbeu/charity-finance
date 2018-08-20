using FinanceEntities;
using System;
using System.Collections.Generic;

namespace Repositories
{
    public interface IPaymentRepository : IDisposable
    {
        IEnumerable<Payment> GetPaymentsByDescription(string description);

        IEnumerable<Payment> GetPaymentsByDescription(string description, IEnumerable<Payment> paymentsToFilterBy);

        IEnumerable<Payment> GetPaymentsByDate(DateTime date);

        IEnumerable<Payment> GetPaymentsByDateRange(DateTime dateFrom, DateTime dateTo);

        IEnumerable<Payment> GetPaymentsByBudgetType(BudgetType budgetType);

        IEnumerable<Payment> GetPaymentsByBudgetType(BudgetType budgetType, IEnumerable<Payment> paymentsToFilterBy);

        IEnumerable<Payment> GetPaymentsByPaymentType(PaymentType paymentType);

        IEnumerable<Payment> GetPaymentsByPaymentType(PaymentType paymentType, IEnumerable<Payment> paymentsToFilterBy);

        IEnumerable<Payment> GetPaymentsByAmount(double amount);

        IEnumerable<Payment> GetPaymentsByAmount(double amount, IEnumerable<Payment> paymentsToFilterBy);
    }
}