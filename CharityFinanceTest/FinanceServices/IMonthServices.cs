using System.Collections.Generic;
using FinanceDomain;

namespace FinanceServices
{
    public interface IMonthServices
    {
        double GetBankedClearedIncomeTotalByMonth(Month month, int year);
        double GetBankedClearedPaymentsTotalByMonth(Month month, int year);
        double GetIncomeTotalByMonth(Month month, int year);
        double GetOSChequesAmountByMonth(Month month, int year);
        IList<Payment> GetOSChequesByMonth(Month month, int year);
        double GetOSPaidInAmountByMonth(Month month, int year);
        IList<Income> GetOSPaidInByMonth(Month month, int year);
        double GetPaymentsTotalByMonth(Month month, int year);
    }
}