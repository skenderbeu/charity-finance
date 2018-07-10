using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinanceEntities;

namespace Repositories
{
    public enum Month{
        NotSet,
        January,
        February,
        March,
        April,
        May,
        June,
        July,
        August,
        September,
        October,
        November,
        December
    }

    public interface IPaymentRepository : IDisposable
    {
        List<Payment> GetPaymentsByDescription(string description);
        List<Payment> GetPaymentsByDescription(string description, List<Payment> paymentsToFilterBy);
        List<Payment> GetPaymentsByDate(DateTime date);
        List<Payment> GetPaymentsByDateRange(DateTime dateFrom, DateTime dateTo);
        List<Payment> GetPaymentsByBudgetType(BudgetTypes budgetTypes);
        List<Payment> GetPaymentsByBudgetType(BudgetTypes budgetTypes, List<Payment> paymentsToFilterBy);
        List<Payment> GetPaymentsByPaymentType(PaymentTypes paymentType);
        List<Payment> GetPaymentsByPaymentType(PaymentTypes paymentType, List<Payment> paymentsToFilterBy);
        List<Payment> GetPaymentsByAmount(double amount);
        List<Payment> GetPaymentsByAmount(double amount, List<Payment> paymentsToFilterBy);
        List<Payment> GetPaymentsByGiftAidStatus(GiftAidStatus giftAidStatus);
        List<Payment> GetPaymentsByGiftAidStatus(GiftAidStatus giftAidStatus, List<Payment> paymentsToFilterBy);
        double GetPaymentsTotalByMonth(Month month, int year);
        double GetBankedClearedPaymentsTotalByMonth(Month month, int year);
        double GetOSChequesByMonth(Month month, int year);
    }

    public class PaymentRepository : IPaymentRepository
    {
        List<Payment> payments;

        public PaymentRepository()
        {
        }

        //Used for Testing
        public PaymentRepository(List<Payment> payments)
        {
            this.payments = payments;
        }

        public List<Payment> GetPaymentsByAmount(double amount)
        {
            return payments.Where(p => p.Amount == amount).ToList();
        }

        public List<Payment> GetPaymentsByAmount(double amount, List<Payment> paymentsToFilterBy)
        {
            throw new NotImplementedException();
        }

        public List<Payment> GetPaymentsByBudgetType(BudgetTypes budgetTypes)
        {
            throw new NotImplementedException();
        }

        public List<Payment> GetPaymentsByBudgetType(BudgetTypes budgetTypes, List<Payment> paymentsToFilterBy)
        {
            throw new NotImplementedException();
        }

        public List<Payment> GetPaymentsByDate(DateTime date)
        {
            throw new NotImplementedException();
        }

        public List<Payment> GetPaymentsByDateRange(DateTime dateFrom, DateTime dateTo)
        {
            throw new NotImplementedException();
        }

        public List<Payment> GetPaymentsByDescription(string description)
        {
            throw new NotImplementedException();
        }

        public List<Payment> GetPaymentsByDescription(string description, List<Payment> paymentsToFilterBy)
        {
            throw new NotImplementedException();
        }

        public List<Payment> GetPaymentsByGiftAidStatus(GiftAidStatus giftAidStatus)
        {
            throw new NotImplementedException();
        }

        public List<Payment> GetPaymentsByGiftAidStatus(GiftAidStatus giftAidStatus, List<Payment> paymentsToFilterBy)
        {
            throw new NotImplementedException();
        }

        public List<Payment> GetPaymentsByPaymentType(PaymentTypes paymentType)
        {
            throw new NotImplementedException();
        }

        public List<Payment> GetPaymentsByPaymentType(PaymentTypes paymentType, List<Payment> paymentsToFilterBy)
        {
            throw new NotImplementedException();
        }

        public double GetPaymentsTotalByMonth(Month month, int year)
        {
            throw new NotImplementedException();
        }

        public double GetBankedClearedPaymentsTotalByMonth(Month month, int year)
        {
            throw new NotImplementedException();
        }

        public double GetOSChequesByMonth(Month month, int year)
        {
            throw new NotImplementedException();
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
