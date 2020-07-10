using FinanceDomain;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public PaymentType GetPaymentTypeById(Guid Id)
        {
            return PaymentTypes.Where(p => p.Id == Id).FirstOrDefault();
        }

        public IEnumerable<PaymentType> GetPaymentTypes()
        {
            return PaymentTypes;
        }
    }
}
