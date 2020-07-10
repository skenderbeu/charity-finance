using FinanceDomain;
using Repositories;
using System;
using System.Collections.Generic;

namespace FinanceServices
{
    public class PaymentTypeViewModel : IPaymentTypeViewModel
    {
        private ITransactionTypeRepository<PaymentType> paymentTypeRepository;

        public PaymentTypeViewModel()
        {
            paymentTypeRepository = new PaymentTypeRepository();
        }

        public PaymentType GetPaymentTypeById(Guid Id)
        {
            return paymentTypeRepository.GetById(Id);
        }

        public IEnumerable<PaymentType> GetPaymentTypes()
        {
            return paymentTypeRepository.GetAll();
        }
    }
}
