using System;
using System.Collections.Generic;
using FinanceEntities;

namespace FinanceServices
{
    public interface IPaymentServices
    {
        IList<Payment> GetPaymentsByAmount(double amount);
        IList<Payment> GetPaymentsByAmount(double amount, IList<Payment> paymentsToFilterBy);
        IList<Payment> GetPaymentsByBudgetType(BudgetType budgetType);
        IList<Payment> GetPaymentsByBudgetType(BudgetType budgetType, IList<Payment> paymentsToFilterBy);
        IList<Payment> GetPaymentsByDate(DateTime date);
        IList<Payment> GetPaymentsByDateRange(DateTime dateFrom, DateTime dateTo);
        IList<Payment> GetPaymentsByDescription(string description);
        IList<Payment> GetPaymentsByDescription(string description, IList<Payment> paymentsToFilterBy);
        IList<Payment> GetPaymentsByPaymentType(PaymentType paymentType);
        IList<Payment> GetPaymentsByPaymentType(PaymentType paymentType, IList<Payment> paymentsToFilterBy);
    }
}