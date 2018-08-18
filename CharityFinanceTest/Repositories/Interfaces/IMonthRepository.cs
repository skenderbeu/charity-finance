using FinanceEntities;
using System.Collections.Generic;

namespace Repositories
{
    public interface IMonthRepository
    {
        double GetPaymentsTotalByMonth(Month month, int year);

        double GetIncomeTotalByMonth(Month month, int year);

        double GetBankedClearedPaymentsTotalByMonth(Month month, int year);

        double GetBankedClearedIncomeTotalByMonth(Month month, int year);

        double GetOSChequesAmountByMonth(Month month, int year);

        double GetOSPaidInAmountByMonth(Month month, int year);

        IEnumerable<Payment> GetOSChequesByMonth(Month month, int year);

        IEnumerable<Income> GetOSPaidInByMonth(Month month, int year);
    }
}