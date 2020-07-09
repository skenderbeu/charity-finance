using FinanceDomain;
using System.Collections.Generic;


namespace FinanceServices
{
    public interface IPaymentTypeViewModel
    {
         IList<PaymentType> GetPaymentTypes();
    }
}
