using FinanceEntities;
using System;
using System.Collections.Generic;

namespace Repositories
{
    public interface IMonthRepository
    {
        double GetPaymentsTotalByMonth(Month month, int year);
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
    }
}
