using FinanceEntities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repositories
{
    public class MonthRepository : IMonthRepository
    {
        private IEnumerable<Payment> payments;
        private IEnumerable<Income> incomes;

        public MonthRepository()
        {
        }

        //Used for Testing
        public MonthRepository(IEnumerable<Payment> payments, IEnumerable<Income> incomes)
        {
            this.payments = payments;
            this.incomes = incomes;
        }

        public double GetPaymentsTotalByMonth(Month month, int year)
        {
            if (month == Month.NotSet) { throw new ArgumentException("Month has not been set properly"); }

            return payments
                .Where(p => p.Date.Month == (int)month && p.Date.Year == year)
                .Sum(p => p.Amount);
        }

        public double GetIncomeTotalByMonth(Month month, int year)
        {
            if (month == Month.NotSet) { throw new ArgumentException("Month has not been set properly"); }

            return incomes
                .Where(i => i.Date.Month == (int)month && i.Date.Year == year)
                .Sum(i => i.Amount);
        }

        public double GetBankedClearedPaymentsTotalByMonth(Month month, int year)
        {
            return payments
                .Where(p => p.BankCleared == true && p.Date.Month == (int)month && p.Date.Year == year)
                .Sum(p => p.Amount);
        }

        public double GetBankedClearedIncomeTotalByMonth(Month month, int year)
        {
            return incomes
                .Where(i => i.BankCleared == true && i.Date.Month == (int)month && i.Date.Year == year)
                .Sum(p => p.Amount);
        }

        public double GetOSChequesAmountByMonth(Month month, int year)
        {
            return payments
                .Where(p => p.PaymentType == PaymentTypes.CHQ
                    && p.BankCleared == false
                    && p.Date.Month == (int)month
                    && p.Date.Year == year)
                .Sum(p => p.Amount);
        }

        public double GetOSPaidInAmountByMonth(Month month, int year)
        {
            return incomes
                .Where(i => !string.IsNullOrWhiteSpace(i.PayingInSlip)
                    && i.Date.Month == (int)month
                    && i.Date.Year == year
                    && i.BankCleared == false)
                .Sum(i => i.Amount);
        }

        public IEnumerable<Payment> GetOSChequesByMonth(Month month, int year)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Income> GetOSPaidInByMonth(Month month, int year)
        {
            throw new NotImplementedException();
        }
    }
}