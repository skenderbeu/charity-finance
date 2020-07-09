using FinanceDomain;
using System.Collections.Generic;

namespace FinanceServices
{
    public class MockPaymentTypeViewModel : IPaymentTypeViewModel
    {
        List<PaymentType> PaymentTypes;
        public MockPaymentTypeViewModel()
        {
            PaymentTypes = new List<PaymentType>() { 
                PaymentType.Create("BAC", "Bank Transfer").Value,
                PaymentType.Create("STO", "Standing Order").Value, 
                PaymentType.Create("CHG", "Charge").Value, 
            };
        }
        public IList<PaymentType> GetPaymentTypes()
        {
            return PaymentTypes;
        }
    }
}
