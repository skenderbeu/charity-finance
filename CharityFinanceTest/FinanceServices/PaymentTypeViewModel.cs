using FinanceDomain;
using Repositories;
using System;
using System.Collections.Generic;

namespace FinanceServices
{
    public class PaymentTypeViewModel : IPaymentTypeViewModel
    {
        private readonly ITransactionTypeRepository<PaymentType> paymentTypeRepository;

        public PaymentTypeViewModel(ITransactionTypeRepository<PaymentType> paymentTypeRepository)
        {
            this.paymentTypeRepository = paymentTypeRepository;
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
