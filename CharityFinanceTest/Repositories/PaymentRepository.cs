using System;
using System.Collections.Generic;
using System.Linq;
using FinanceEntities;

namespace Repositories
{
    public interface IPaymentRepository : IDisposable
    {
        IEnumerable<Payment> GetPaymentsByDescription(string description);
        IEnumerable<Payment> GetPaymentsByDescription(string description, IEnumerable<Payment> paymentsToFilterBy);
        IEnumerable<Payment> GetPaymentsByDate(DateTime date);
        IEnumerable<Payment> GetPaymentsByDateRange(DateTime dateFrom, DateTime dateTo);
        IEnumerable<Payment> GetPaymentsByBudgetType(BudgetTypes budgetType);
        IEnumerable<Payment> GetPaymentsByBudgetType(BudgetTypes budgetType, IEnumerable<Payment> paymentsToFilterBy);
        IEnumerable<Payment> GetPaymentsByPaymentType(PaymentTypes paymentType);
        IEnumerable<Payment> GetPaymentsByPaymentType(PaymentTypes paymentType, IEnumerable<Payment> paymentsToFilterBy);
        IEnumerable<Payment> GetPaymentsByAmount(double amount);
        IEnumerable<Payment> GetPaymentsByAmount(double amount, IEnumerable<Payment> paymentsToFilterBy);
    }

    public class PaymentRepository : IPaymentRepository
    {
        IEnumerable<Payment> payments;

        public PaymentRepository()
        {
        }

        //Used for Testing
        public PaymentRepository(IEnumerable<Payment> payments)
        {
            this.payments = payments;
        }

        public IEnumerable<Payment> GetPaymentsByAmount(double amount)
        {
            return payments.Where(p => p.Amount == amount);
        }

        public IEnumerable<Payment> GetPaymentsByAmount(double amount, IEnumerable<Payment> paymentsToFilterBy)
        {
            return paymentsToFilterBy.Where(p => p.Amount == amount);
        }

        public IEnumerable<Payment> GetPaymentsByBudgetType(BudgetTypes budgetType)
        {
            return payments.Where(p => p.BudgetType == budgetType);
        }

        public IEnumerable<Payment> GetPaymentsByBudgetType(BudgetTypes budgetType, IEnumerable<Payment> paymentsToFilterBy)
        {
            return paymentsToFilterBy.Where(p => p.BudgetType == budgetType);
        }

        public IEnumerable<Payment> GetPaymentsByDate(DateTime date)
        {
            return payments.Where(p => p.Date.Date == date.Date);
        }

        public IEnumerable<Payment> GetPaymentsByDateRange(DateTime dateFrom, DateTime dateTo)
        {
            return payments.Where(p => p.Date.Date >= dateFrom && p.Date.Date <= dateTo);
        }

        public IEnumerable<Payment> GetPaymentsByDescription(string description)
        {
            return payments.Where(p => TrimUpperReplaceBlank(p.Description).Contains(TrimUpperReplaceBlank(description)));
        }

        public IEnumerable<Payment> GetPaymentsByDescription(string description, IEnumerable<Payment> paymentsToFilterBy)
        {
            return paymentsToFilterBy.Where(p => TrimUpperReplaceBlank(p.Description).Contains(TrimUpperReplaceBlank(description)));
        }

        public IEnumerable<Payment> GetPaymentsByPaymentType(PaymentTypes paymentType)
        {
            return payments.Where(p => p.PaymentType == paymentType);
        }

        public IEnumerable<Payment> GetPaymentsByPaymentType(PaymentTypes paymentType, IEnumerable<Payment> paymentsToFilterBy)
        {
            return paymentsToFilterBy.Where(p => p.PaymentType == paymentType);
        }

        private string TrimUpperReplaceBlank(string input)
        {
            return input.ToUpper().Trim().Replace(" ", "");
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    payments = null;
                }

                disposedValue = true;
            }
        }

     
        public void Dispose()
        {
            Dispose(true);
    
        }

        #endregion
    }
}
