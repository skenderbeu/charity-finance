using FinanceDomain;
using System;
using System.Collections.Generic;


namespace FinanceServices
{
    public interface IPaymentTypeViewModel
    {
        PaymentType GetPaymentTypeById(Guid Id);
         IEnumerable<PaymentType> GetPaymentTypes();
    }
}
