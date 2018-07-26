using FinanceEntities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repositories
{
    public interface IMonthRepository
    {
        double GetPaymentsTotalByMonth(Month month, int year);
        double GetIncomeTotalByMonth(Month month, int year);
        double GetBankedClearedPaymentsTotalByMonth(Month month, int year);
        double GetOSChequesByMonth(Month month, int year);
    }

    public class MonthRepository: IMonthRepository
    {
        IEnumerable<Payment> payments;
        IEnumerable<Income> incomes;

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
            throw new NotImplementedException();
        }

        public double GetOSChequesByMonth(Month month, int year)
        {
            throw new NotImplementedException();
        }
    }
}
