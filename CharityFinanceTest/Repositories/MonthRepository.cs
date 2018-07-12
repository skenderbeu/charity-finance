using FinanceEntities;
using System;

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
